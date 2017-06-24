using Microsoft.EntityFrameworkCore;

namespace VolunteersApp.Models
{
	public class LoginUserContext : DbContext
	{

		public LoginUserContext(DbContextOptions<LoginUserContext> options)
			: base(options)
		{
		}

		public DbSet<LoginUser> LoginUser { get; set; }
	}
}


