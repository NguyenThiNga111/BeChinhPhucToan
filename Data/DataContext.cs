using Microsoft.EntityFrameworkCore;
using BeChinhPhucToan_BE.Models;

namespace BeChinhPhucToan_BE.Data
{
    public class DataContext : DbContext
    {
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

        //Set Key
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotifyParent>().HasKey(np => new { np.parentEmail, np.notificationID });
            modelBuilder.Entity<Purchase>().HasKey(p => new { p.badgeID, p.studentID });
            modelBuilder.Entity<JoinGroup>().HasKey(jg => new { jg.groupID, jg.studentID });
            modelBuilder.Entity<Message>().HasKey(m => new { m.groupID, m.studentID });
            modelBuilder.Entity<NotifyStudent>().HasKey(nt => new { nt.studentID, nt.notificationID });
            modelBuilder.Entity<RankedScore>().HasKey(rs => new { rs.studentID, rs.rateTypeID });
            modelBuilder.Entity<StarPoint>().HasKey(sp => new { sp.studentID, sp.lessonID });
            modelBuilder.Entity<Comment>().HasKey(c => new { c.studentID, c.exerciseID });
        }

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
    }
}
