namespace ApiApplication
{
	using Data;
	using Models;
	using System;
	using Microsoft.AspNetCore;
	using Microsoft.AspNetCore.Hosting;


	public class Program
	{
		public static void Main(string[] args)
		{
			//using (var db = new GymContext())
			//{
			//	db.Users.Add(new User { Username = "angel@g.com" });
			//	var count = db.SaveChanges();
			//	Console.WriteLine($"{count} records saved to database");

			//	Console.WriteLine();
			//	Console.WriteLine("All users in database:");
			//	foreach (var user in db.Users)
			//	{
			//		Console.WriteLine($" - {user.Username}");
			//	}
			//}
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
