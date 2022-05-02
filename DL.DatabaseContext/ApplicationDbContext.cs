using DL.Entities;
using DL.IUnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DL.DatabaseContext.EntityConfigurations;
using Enums;

namespace DL.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Npgsql.NpgsqlConnection.GlobalTypeMapper.MapEnum<Correctness>();
        }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionItem> QuestionItems { get; set; }

        public DbSet<PollQuestion> PollQuestions { get; set; }

        public DbSet<TriviaQuestion> TriviaQuestions { get; set; }

        public DbSet<QuestionResult> QuestionResults { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("public");

            base.OnModelCreating(builder);
            builder.HasPostgresEnum<Correctness>();

            builder.ApplyConfiguration(new QuestionEntityTypeConfiguration());
        }
    }
}
