using System;
namespace VolunteersApp.Models
{
    public class LoginUser
    {
		public int Id { get; set; }
		public string AbhyasiId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Mobile { get; set; }
		public string Gender { get; set; }
		public string Password { get; set; }
    }
}