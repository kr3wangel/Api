namespace ApiApplication.Data
{
	using Microsoft.EntityFrameworkCore;
	using Models;

	public class GymContext : DbContext
	{
		public GymContext(DbContextOptions<GymContext> options)
			:base(options)
		{ }

		public DbSet<User> Users { get; set; }
		public DbSet<Workout> Workouts { get; set; }
		public DbSet<WorkoutType> WorkoutTypes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=health.db");
		}
	}
}
