namespace ApiApplication.Models
{
	using System;
	using System.Collections.Generic;

	public class User
	{
		public int UserId { get; set; }

		public string OAuthId { get; set; }

		public string Username { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime InsertedDate { get; set; }

		public List<Workout> Workouts { get; set; }
	}
}
