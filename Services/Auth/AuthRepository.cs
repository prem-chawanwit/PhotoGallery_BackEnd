namespace PhotoGallery_BackEnd.Services.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly TaskDbContext _taskDbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthRepository(TaskDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _taskDbContext = context;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _taskDbContext.users
                .Include(u => u.userAccessLevels)
                .FirstOrDefaultAsync(u => u.username.ToLower().Equals(username.ToLower()));

            if (user is null)
            {
                response.success = false;

                response.message = "User not found.";

            }
            else if (!VerifypasswordHash(password, user.passwordHash, user.passwordSalt))
            {
                response.success = false;

                response.message = "Wrong Password.";
            }
            else
            {
                response.Data = CreateToken(user);
                response.user = _mapper.Map<UserDto>(user);
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();
            if (await UserExists(user.username))
            {
                response.success = false;
                response.message = "User already exists";
                return response;
            }
            CreatepasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;
            user.userAccessLevelid = 99;

            _taskDbContext.users.Add(user);
            await _taskDbContext.SaveChangesAsync();

            response.Data = user.id;
            return response;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _taskDbContext.users.AnyAsync(u => u.username.ToLower() == username.ToLower()))
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

            var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;
            if (appSettingsToken is null)
            {
                throw new Exception("Appsettings Token is null");
            }
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingsToken));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<ServiceResponse<string>> ResetPassword(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _taskDbContext.users.FirstOrDefaultAsync(u => u.username.ToLower().Equals(username.ToLower()));
            if (user is null)
            {
                response.success = false;
                response.message = "User not found.";

            }
            else
            {
                CreatepasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                user.passwordHash = passwordHash;
                user.passwordSalt = passwordSalt;
                await _taskDbContext.SaveChangesAsync();
                response.Data = "Reset Password success";
            }
            return response;
        }

        public async Task<ServiceResponse<List<UserDto>>> GetAllUser()
        {
            var response = new ServiceResponse<List<UserDto>>();
            var dbusers = await _taskDbContext.users.Include(u => u.userAccessLevels).ToListAsync();
            response.Data = dbusers.Select(u => _mapper.Map<UserDto>(u)).ToList();
            if (response.Data.Count == 0)
            {
                response.success = false;
                response.message = "No Data found";
            }
            return response;
        }

        public async Task<ServiceResponse<List<UserDto>>> DeleteUser(string username)
        {
            var serviceRespone = new ServiceResponse<List<UserDto>>();

            try
            {
                var user = await _taskDbContext.users.FirstOrDefaultAsync(c => c.username.ToLower() == username.ToLower());
                if (user is null)
                {
                    throw new Exception($"Character with username: '{username}' not found.");
                }
                _taskDbContext.users.Remove(user);
                await _taskDbContext.SaveChangesAsync();

                serviceRespone.Data = await _taskDbContext.users
                     .Select(c => _mapper.Map<UserDto>(c))
                     .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceRespone.success = false;
                serviceRespone.message = ex.Message;
            }

            return serviceRespone;
        }

        public async Task<ServiceResponse<List<UserDto>>> UpdateUser(string username, string accessLevelName)
        {
            var serviceRespone = new ServiceResponse<List<UserDto>>();

            try
            {
                var user = await _taskDbContext.users
                    .FirstOrDefaultAsync(c => c.username.ToLower() == username.ToLower());
                if (user is null)
                {
                    serviceRespone.success = false;
                    serviceRespone.message = $"username: '{username}' not found.";
                    return serviceRespone;
                }
                var accessLevelid = await _taskDbContext.userAccessLevel
                    .FirstOrDefaultAsync(c => c.accessLevelName.ToLower() == accessLevelName.ToLower());

                if (accessLevelid is null)
                {
                    serviceRespone.success = false;
                    serviceRespone.message = $"accessLevel Name: '{accessLevelName}' not found.";
                    return serviceRespone;
                }

                user!.userAccessLevelid = (int)accessLevelid!.id;
                await _taskDbContext.SaveChangesAsync();

                serviceRespone.Data = await _taskDbContext.users
                     .Select(c => _mapper.Map<UserDto>(c))
                     .ToListAsync();

            }
            catch (Exception ex)
            {
                serviceRespone.success = false;
                serviceRespone.message = ex.Message;
            }

            return serviceRespone;
        }
    }
}
