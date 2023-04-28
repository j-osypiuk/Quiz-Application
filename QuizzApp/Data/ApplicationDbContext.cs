using Microsoft.EntityFrameworkCore;
using QuizzApp.Model;

namespace QuizzApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<UserCredential> UserCredential { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>(etb =>
            {
                etb.HasMany(ua => ua.Quizzes).WithOne(t => t.User).HasForeignKey(ua => ua.UserId);
                etb.Property(ua => ua.FirstName).IsRequired().HasColumnType("varchar(30)");
                etb.Property(ua => ua.LastName).IsRequired().HasColumnType("varchar(30)");
                etb.Property(ua => ua.Email).IsRequired();
                etb.HasIndex(ua => ua.Email).IsUnique(true);
                etb.HasOne(ua => ua.UserCredential).WithOne(uc => uc.UserAccount).HasForeignKey<UserCredential>(uc => uc.UserAccountId);
            });

            modelBuilder.Entity<UserCredential>(etb =>
            {
                etb.Property(uc => uc.Username).IsRequired().HasColumnType("varchar(30)");
                etb.HasIndex(uc => uc.Username).IsUnique(true);
                etb.Property(uc => uc.Password).IsRequired();
            });

            modelBuilder.Entity<Quiz>(etb =>
            {
                etb.Property(q => q.Title).IsRequired().HasColumnType("varchar(30)");
                etb.Property(q => q.QuizCode).IsRequired();
                etb.HasIndex(q => q.QuizCode).IsUnique(true);
                etb.HasMany(q => q.Results).WithOne(r => r.Quiz).HasForeignKey(r => r.QuizId);
                etb.HasMany(q => q.Questions).WithOne(qu => qu.Quiz).HasForeignKey(qu => qu.QuizId);

            });

            modelBuilder.Entity<Result>(etb =>
            {
                etb.Property(r => r.Score).IsRequired();
                etb.Property(r => r.FirstName).IsRequired().HasColumnType("varchar(30)");
                etb.Property(r => r.LastName).IsRequired().HasColumnType("varchar(30)"); ;
                etb.Property(r => r.CreateDate).IsRequired().HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<Question>(etb =>
            {
                etb.HasIndex(q => q.QuestionContent).IsUnique(true);
                etb.Property(q => q.QuestionContent).IsRequired().HasColumnType("varchar(250)");
                etb.HasMany(q => q.Answers).WithOne(a => a.Question).HasForeignKey(a => a.QuestionId);
            });

            modelBuilder.Entity<Answer>(etb =>
            {
                etb.Property(a => a.AnswerContent).IsRequired().HasColumnType("varchar(250)");
                etb.Property(a => a.IsCorrect).IsRequired();
            });
        }
    }
}
