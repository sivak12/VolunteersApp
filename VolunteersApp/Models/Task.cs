using System;
namespace VolunteersApp.Models
{
    public class Task
    {
        public int Id { get; set; }
		public string Name { get; set; }
		public string CoordinatorName { get; set; }
		public string CoordinatorPhone { get; set; }
        public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Description { get; set; }
		public int VolunteersRequired { get; set; }
		public int VolunteersSigned { get; set; }

	}
}
