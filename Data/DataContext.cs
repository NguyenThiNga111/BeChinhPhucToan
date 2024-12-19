using Microsoft.EntityFrameworkCore;
using BeChinhPhucToan_BE.Models;

namespace BeChinhPhucToan_BE.Data
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình 1-1 giữa User và Administrator
            modelBuilder.Entity<Administrator>()
                .HasOne(a => a.User) // Một Administrator có 1 User
                .WithOne(u => u.Administrator) // Một User có 1 Administrator
                .HasForeignKey<Administrator>(a => a.phoneNumber); // Khóa ngoại của Administrator là phoneNumber

            modelBuilder.Entity<Parent>()
                .HasOne(a => a.User)
                .WithOne(u => u.Parent)
                .HasForeignKey<Parent>(a => a.phoneNumber);
        }

        //Create Database & Tables
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }        
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ParentNotification> ParentNotifications { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<StudentNotification> StudentNotifications { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<RankedTest> RankedTests { get; set; }
        public DbSet<RateType> RateTypes { get; set; }
        public DbSet<RankedScore> RankedScores { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<StarPoint> StarPoints { get; set; }
        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<NotifyParent> NotifyParents { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<JoinGroup> JoinGroups { get; set; }
        public DbSet<NotifyStudent> NotifyStudents { get; set; }


        //Add & Update Timestamp Automaticlly
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).createdAt = now;
                }
                ((BaseEntity)entity.Entity).updatedAt = now;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình mối quan hệ giữa NotifyParent và ParentNotification
            modelBuilder.Entity<NotifyParent>()
                .HasOne(np => np.ParentNotification)
                .WithMany(pn => pn.NotifyParents)
                .HasForeignKey(np => np.notificationID)
                .OnDelete(DeleteBehavior.Cascade); // Tùy chọn: Xóa liên quan nếu cần
        }
    }
}
