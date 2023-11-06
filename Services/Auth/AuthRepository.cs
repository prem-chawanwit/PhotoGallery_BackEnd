namespace PhotoGallery_BackEnd.Services.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private int Minites_Of_Token_Expire = 20;
        private readonly APIDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthRepository(APIDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.users
                .Include(u => u.userAccessLevels)
                .FirstOrDefaultAsync(u => u.username.ToLower().Equals(username.ToLower()));

            if (user is null)
            {
                response.Success = false;
                response.User = new UserDto();
                response.Message = "User not found.";

            }
            else if (!VerifypasswordHash(password, user.passwordHash, user.passwordSalt))
            {
                response.Success = false;
                response.User = new UserDto();
                response.Message = "Wrong Password.";
            }
            else
            {
                var userLoggedIn = await _context.loginTimming
                    .Where(t => t.username.ToLower().Equals(username.ToLower()))
                    .FirstOrDefaultAsync();
                var currentTime = DateTime.UtcNow;
                var expirationTime = DateTime.UtcNow.AddMinutes(Minites_Of_Token_Expire);

                if (userLoggedIn == null)
                {
                    // User login timing information doesn't exist, create a new record.
                    var loginTime = new LoginTimming
                    {
                        username = username,
                        lastLoggedIn = currentTime,
                        expireToken = expirationTime,
                        isLoggedIn = true,
                    };

                    _context.loginTimming.Add(loginTime);
                    response.User = new UserDto
                    {
                        username = user.username,
                        userAccessLevelid = user.userAccessLevelid,
                        roles = user.userAccessLevels.accessLevel.ToString()
                };
                }
                else
                {
                    // Update the existing user login timing information.
                    userLoggedIn.lastLoggedIn = currentTime;
                    userLoggedIn.expireToken = expirationTime;
                    userLoggedIn.isLoggedIn = true;
                    response.User = new UserDto();
                }

                await _context.SaveChangesAsync();
                //
                response.Data = CreateToken(user);

                response.User = _mapper.Map<UserDto>(user);
            }
            return response;
        }
        public async Task<ServiceResponse<string>> Logout(string username)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.users
                .Include(u => u.userAccessLevels)
                .FirstOrDefaultAsync(u => u.username.ToLower().Equals(username.ToLower()));

            if (user is null)
            {
                response.Success = false;
                response.User = new UserDto();
                response.Message = "User not found.";
            }
            else
            {
                var userLoggedIn = await _context.loginTimming
                    .Where(t => t.username.ToLower().Equals(username.ToLower()))
                    .FirstOrDefaultAsync();

                if (userLoggedIn != null)
                {
                    var currentTime = DateTime.UtcNow;

                    // Set a very short expiration time to immediately invalidate the token
                    userLoggedIn.expireToken = currentTime.AddSeconds(5); // Set it to expire in 5 seconds

                    userLoggedIn.isLoggedIn = false;

                    await _context.SaveChangesAsync();
                }
            }
            response.Data = $"{username} Logout. successfully.";
            response.User = new UserDto();
            response.Success = true;
            response.Message = $"-";
            return response;
        }
        public async Task<ServiceResponse<bool>> CheckUser(string username)
        {
            var response = new ServiceResponse<bool>();
            var user = await _context.users
                .Include(u => u.userAccessLevels)
                .FirstOrDefaultAsync(u => u.username.ToLower().Equals(username.ToLower()));

            if (user is null)
            {
                response.Data = false;
                response.User = new UserDto();
                response.Success = false;
                response.Message = "User not found.";
            }
            else
            {
                var userLoggedIn = await _context.loginTimming.AsNoTracking()
                    .Where(t => t.username.ToLower().Equals(username.ToLower()))
                    .FirstOrDefaultAsync();

                if (userLoggedIn != null)
                {
                    var currentTime = DateTime.UtcNow;

                    if (currentTime >= userLoggedIn.expireToken)
                    {
                        // The session has expired
                        userLoggedIn.isLoggedIn = false;

                        await _context.SaveChangesAsync();

                        response.Data = false;
                        response.User = new UserDto();
                        response.Success = true;
                        response.Message = $"{username} session has expired.";
                    }
                    else
                    {
                        if(!userLoggedIn.isLoggedIn)
                        {
                            // The session has expired
                            userLoggedIn.isLoggedIn = false;

                            await _context.SaveChangesAsync();

                            response.Data = false;
                            response.User = new UserDto();
                            response.Success = true;
                            response.Message = $"{username} session has expired.";
                        }
                        else
                        {
                            // The session is still valid
                            response.Data = true;
                            response.User = new UserDto
                            {
                                username = user.username,
                                userAccessLevelid = user.userAccessLevelid,
                                roles = user.userAccessLevels.accessLevel.ToString()
                            };
                            response.Success = true;
                            response.Message = $"{username} session is still valid.";
                        }
                    }
                }
                else
                {
                    response.Data = false;
                    response.Success = false;
                    response.Message = "User's session not found.";
                }
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();
            if (await UserExists(user.username))
            {
                response.Success = false;
                response.User = new UserDto();
                response.Message = "User already exists";
                return response;
            }
            CreatepasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;
            user.userAccessLevelid = 99;

            _context.users.Add(user);
            await _context.SaveChangesAsync();

            response.Data = user.id;
            return response;
        }
        public async Task<bool> UserExists(string username)
        {
            if (await _context.users.AnyAsync(u => u.username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }
        private void CreatepasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifypasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, user.username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(Minites_Of_Token_Expire),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        public async Task<ServiceResponse<string>> ResetPassword(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.users.FirstOrDefaultAsync(u => u.username.ToLower().Equals(username.ToLower()));
            if (user is null)
            {
                response.Success = false;
                response.Message = "User not found.";

            }
            else
            {
                CreatepasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                var userLoggedIn = await _context.loginTimming
                                            .Where(t => t.username.ToLower().Equals(username.ToLower()))
                                            .FirstOrDefaultAsync();

                user.passwordHash = passwordHash;
                user.passwordSalt = passwordSalt;
                await _context.SaveChangesAsync();
                response.Data = "Reset Password Success";
            }
            return response;
        }
        public async Task<ServiceResponse<List<UserDto>>> GetAllUser()
        {
            var response = new ServiceResponse<List<UserDto>>();
            var dbusers = await _context.users.Include(u => u.userAccessLevels).ToListAsync();
            response.Data = dbusers.Select(u => _mapper.Map<UserDto>(u)).ToList();
            if (response.Data.Count == 0)
            {
                response.Success = false;
                response.Message = "No Data found";
            }
            return response;
        }
        public async Task<ServiceResponse<List<UserDto>>> DeleteUser(string username)
        {
            var serviceRespone = new ServiceResponse<List<UserDto>>();

            try
            {
                var user = await _context.users.FirstOrDefaultAsync(c => c.username.ToLower() == username.ToLower());
                if (user is null)
                {
                    throw new Exception($"Character with username: '{username}' not found.");
                }
                _context.users.Remove(user);
                await _context.SaveChangesAsync();

                serviceRespone.Data = await _context.users
                     .Select(c => _mapper.Map<UserDto>(c))
                     .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceRespone.Success = false;
                serviceRespone.Message = ex.Message;
            }

            return serviceRespone;
        }
        public async Task<ServiceResponse<List<UserDto>>> UpdateUser(string username, string accessLevelName)
        {
            var serviceRespone = new ServiceResponse<List<UserDto>>();

            try
            {
                var user = await _context.users
                    .FirstOrDefaultAsync(c => c.username.ToLower() == username.ToLower());
                if (user is null)
                {
                    serviceRespone.Success = false;
                    serviceRespone.Message = $"username: '{username}' not found.";
                    return serviceRespone;
                }
                var accessLevelid = await _context.userAccessLevel
                    .FirstOrDefaultAsync(c => c.accessLevelName.ToLower() == accessLevelName.ToLower());

                if (accessLevelid is null)
                {
                    serviceRespone.Success = false;
                    serviceRespone.Message = $"accessLevel Name: '{accessLevelName}' not found.";
                    return serviceRespone;
                }

                user!.userAccessLevelid = (int)accessLevelid!.id;
                await _context.SaveChangesAsync();

                serviceRespone.Data = await _context.users
                     .Select(c => _mapper.Map<UserDto>(c))
                     .ToListAsync();

            }
            catch (Exception ex)
            {
                serviceRespone.Success = false;
                serviceRespone.Message = ex.Message;
            }

            return serviceRespone;
        }
    }
}
