using Microsoft.EntityFrameworkCore;
using QuizzApp.Model;

namespace QuizzApp.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<UserAccount> UsersAccounts { get; set; }
		public DbSet<UserCredentials> UserCredentials { get; set; }
		public DbSet<Test> Tests { get; set; }
		public DbSet<Result> Results { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{	
			modelBuilder.Entity<UserAccount>(etb =>
			{
				etb.HasMany(ua => ua.Test).WithOne(t => t.User).HasForeignKey(ua => ua.UserId);
				etb.Property(ua => ua.FirstName).IsRequired();
                etb.Property(ua => ua.Email).IsRequired();
				etb.HasIndex(ua => ua.Email).IsUnique(true);
				etb.HasOne(ua => ua.UserCredentials).WithOne(uc => uc.UserAccount).HasForeignKey<UserCredentials>(uc => uc.UserAccountId);
			});

			modelBuilder.Entity<UserCredentials>(etb =>
			{
				etb.Property(uc => uc.Username).IsRequired();
                etb.HasIndex(uc => uc.Username).IsUnique(true);
				etb.Property(uc => uc.Password).IsRequired();
			});

			modelBuilder.Entity<Test>(etb =>
			{
				etb.Property(t => t.Title).IsRequired();
				etb.HasMany(t => t.Results).WithOne(r => r.Test).HasForeignKey(t => t.TestId);
				etb.HasMany(t => t.Questions).WithOne(q => q.Test).HasForeignKey(t => t.TestId);	

			});

			modelBuilder.Entity<Result>(etb => 
			{
				etb.Property(r => r.Score).IsRequired();
				etb.Property(r => r.FirstName).IsRequired();
				etb.Property(r => r.LastName).IsRequired();
				etb.Property(r => r.CreateDate).IsRequired();
			});

			modelBuilder.Entity<Question>(etb =>
			{
				etb.HasIndex(q => q.QuestionContent).IsUnique(true);
				etb.Property(q => q.QuestionContent).IsRequired();
				etb.HasMany(q => q.Answers).WithOne(a => a.Question).HasForeignKey(a => a.QuestionId);
			});

			modelBuilder.Entity<Answer>(etb =>
			{
				etb.Property(a => a.AnswerContent).IsRequired();
				etb.Property(a => a.IsCorrect).IsRequired();
			});
		}
    }
}
