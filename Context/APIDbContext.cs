namespace PhotoGallery_BackeEnd.Context
{
    public class APIDbContext : DbContext
    {
        public DbSet<SectionUploadPathData> sectionUploadPathData { get; set; }
        public DbSet<TaskModel> taskModels { get; set; }
        public DbSet<TaskOrderData> taskOrderData { get; set; }
        public DbSet<TaskReviewData> taskReviewData { get; set; }
        public DbSet<User> users => Set<User>();
        public DbSet<UserAccessLevel> userAccessLevel => Set<UserAccessLevel>();
        public DbSet<SectionUploadPathData> uploadPathData => Set<SectionUploadPathData>();
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure any additional model configurations or relationships here
            string password0 = "1212312121";
            string password1 = "superadmin1212312121";
            string password2 = "admin5678";
            string password3 = "user98765";
            string password4 = "123456789";
            string password5 = "123456789";

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAccessLevel>().HasData(
                new UserAccessLevel { id = 1, accessLevel = 1, accessLevelName = "SuperAdmin" },
                new UserAccessLevel { id = 2, accessLevel = 2, accessLevelName = "Admin" },
                new UserAccessLevel { id = 3, accessLevel = 3, accessLevelName = "User" },
                new UserAccessLevel { id = 4, accessLevel = 4, accessLevelName = "Guest" },
                new UserAccessLevel { id = 99, accessLevel = 99, accessLevelName = "Unknown" }
                );

            CreatepasswordHash(password0, out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    id = 1,
                    username = "prem",
                    passwordHash = passwordHash, // Replace with the actual hashed password
                    passwordSalt = passwordSalt,    // Replace with the actual password salt
                    userAccessLevelid = 1 // Assuming SuperAdmin userAccessLevelid is 1
                }
            );
            CreatepasswordHash(password1, out passwordHash, out passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    id = 2,
                    username = "superadmin",
                    passwordHash = passwordHash, // Replace with the actual hashed password
                    passwordSalt = passwordSalt,    // Replace with the actual password salt
                    userAccessLevelid = 1 // Assuming SuperAdmin userAccessLevelid is 1
                }
            );
            CreatepasswordHash(password2, out passwordHash, out passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    id = 3,
                    username = "admin",
                    passwordHash = passwordHash, // Replace with the actual hashed password
                    passwordSalt = passwordSalt,    // Replace with the actual password salt
                    userAccessLevelid = 2 // Assuming SuperAdmin userAccessLevelid is 1
                }
            );
            CreatepasswordHash(password3, out passwordHash, out passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    id = 4,
                    username = "user",
                    passwordHash = passwordHash, // Replace with the actual hashed password
                    passwordSalt = passwordSalt,    // Replace with the actual password salt
                    userAccessLevelid = 3 // Assuming SuperAdmin userAccessLevelid is 1
                }
            );
            CreatepasswordHash(password4, out passwordHash, out passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    id = 5,
                    username = "guest",
                    passwordHash = passwordHash, // Replace with the actual hashed password
                    passwordSalt = passwordSalt,    // Replace with the actual password salt
                    userAccessLevelid = 4 // Assuming SuperAdmin userAccessLevelid is 1
                }
            );
            CreatepasswordHash(password5, out passwordHash, out passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    id = 6,
                    username = "unknow",
                    passwordHash = passwordHash, // Replace with the actual hashed password
                    passwordSalt = passwordSalt,    // Replace with the actual password salt
                    userAccessLevelid = 99 // Assuming SuperAdmin userAccessLevelid is 1
                }
            );
        }
        public async Task UpdateStatusForStartingProgramAsync()
        {
            var recordsToUpdate1 = await taskModels
                .Where(t => t.status == TaskStatus.Running)
                .ToListAsync();

            foreach (var record in recordsToUpdate1)
            {
                record.status = TaskStatus.Suspended;
            }
            var recordsToUpdate2 = await taskReviewData
                .Where(t => t.isRunning == "Running")
                .ToListAsync();
            foreach (var record in recordsToUpdate2)
            {
                record.isRunning = "Suspended";
            }
            var recordsToUpdate3 = await taskReviewData
                .Where(t => t.extractSta == "Running")
                .ToListAsync();
            foreach (var record in recordsToUpdate3)
            {
                record.extractSta = "Suspended";
            }
            await SaveChangesAsync();
        }
        private void CreatepasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }

}
