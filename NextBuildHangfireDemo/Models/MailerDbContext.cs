namespace NextBuildHangfireDemo.Models
{
    using System.Data.Entity;

    public class MailerDbContext : DbContext
    {
        public MailerDbContext()
            : base("MailerDb")
        {
        }

        public DbSet<Comment> Comments { get; set; }
    }
}