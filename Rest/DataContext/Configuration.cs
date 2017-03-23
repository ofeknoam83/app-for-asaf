using System.Data.Entity.Migrations;

namespace Rest.DataContext
{
    public class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContext\Migrations";
        }

        protected override void Seed(AppDbContext context)
        {
        }
    }
}