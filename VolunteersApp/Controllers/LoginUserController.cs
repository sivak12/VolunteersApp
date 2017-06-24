using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VolunteersApp.Models;
using System.Linq;
namespace VolunteersApp.Controllers
{
    [Route("api/[controller]")]
    public class LoginUserController : Controller
    {

		private readonly LoginUserContext _context;

		public LoginUserController(LoginUserContext context)
		{
			_context = context;
		}


		[HttpGet]
		public IEnumerable<LoginUser> GetAll()
		{
			return _context.LoginUser.ToList();
		}


		[HttpGet("{id}", Name = "GetLoginUser")]
		public IActionResult GetById(int id)
		{
			var loginUser = _context.LoginUser.FirstOrDefault(t => t.Id == id);
			if (loginUser == null)
			{
				return NotFound();
			}
			return new ObjectResult(loginUser);
		}

		[HttpPost]
		public IActionResult Create([FromBody] LoginUser loginUser)
		{
			if (loginUser == null)
			{
				return BadRequest();
			}

			_context.LoginUser.Add(loginUser);
			_context.SaveChanges();

			return CreatedAtRoute("GetLoginUser", new { id = loginUser.Id }, loginUser);
		}



		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] LoginUser loginUser)
		{
			if (loginUser == null || loginUser.Id != id)
			{
				return BadRequest();
			}

			var existingLoginUser = _context.LoginUser.FirstOrDefault(t => t.Id == id);
			if (existingLoginUser == null)
			{
				return NotFound();
			}

			existingLoginUser.AbhyasiId = loginUser.AbhyasiId;
			existingLoginUser.Name = loginUser.Name;
			existingLoginUser.Email = loginUser.Email;
			existingLoginUser.Mobile = loginUser.Mobile;
			existingLoginUser.Gender = loginUser.Gender;
			existingLoginUser.Password = loginUser.Password;

			_context.LoginUser.Update(existingLoginUser);
			_context.SaveChanges();
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var loginUser = _context.LoginUser.First(t => t.Id == id);
			if (loginUser == null)
			{
				return NotFound();
			}

			_context.LoginUser.Remove(loginUser);
			_context.SaveChanges();
			return new NoContentResult();
		}
		
	}
}
