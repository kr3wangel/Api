namespace ApiApplication.Models
{
	using System;

	public class Workout
	{
		public int WorkoutId { get; set; }

		public int WorkoutType { get; set; }

		public DateTime InsertedDate { get; set; }
	}
}
