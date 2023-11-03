namespace PhotoGallery_BackeEnd.Context
{
    public class TaskDbContext : DbContext
    {
        public DbSet<SectionUploadPathData> sectionUploadPathData { get; set; }
        public DbSet<TaskModel> taskModels { get; set; }
        public DbSet<TaskOrderData> taskOrderData { get; set; }
        public DbSet<TaskReviewData> taskReviewData { get; set; }
        public DbSet<User> users => Set<User>();
        public DbSet<UserAccessLevel> userAccessLevel => Set<UserAccessLevel>();
        public DbSet<SectionUploadPathData> uploadPathData => Set<SectionUploadPathData>();
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure any additional model configurations or relationships here

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAccessLevel>().HasData(
                new UserAccessLevel { id = 1, accessLevel = 1, accessLevelName = "SuperAdmin" },
                new UserAccessLevel { id = 2, accessLevel = 2, accessLevelName = "Admin" },
                new UserAccessLevel { id = 3, accessLevel = 3, accessLevelName = "User" },
                new UserAccessLevel { id = 4, accessLevel = 4, accessLevelName = "Guest" },
                new UserAccessLevel { id = 99, accessLevel = 99, accessLevelName = "Unknown" }
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
    }

}
