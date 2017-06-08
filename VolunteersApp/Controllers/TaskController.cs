
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VolunteersApp.Models;
using System.Linq;

namespace VolunteersApp.Controllers
{

	[Route("api/[controller]")]
	public class TaskController : Controller
	{
		private readonly TaskContext _context;

		public TaskController(TaskContext context)
		{
			_context = context;
		}


		[HttpGet]
		public IEnumerable<Task> GetAll()
		{
			return _context.Task.ToList();
		}


		[HttpGet("{id}", Name = "GetTask")]
		public IActionResult GetById(int id)
		{
			var task = _context.Task.FirstOrDefault(t => t.Id == id);
			if (task == null)
			{
				return NotFound();
			}
			return new ObjectResult(task);
		}


		[HttpPost]
		public IActionResult Create([FromBody] Task task)
		{
			if (task == null)
			{
				return BadRequest();
			}

			_context.Task.Add(task);
			_context.SaveChanges();

			return CreatedAtRoute("GetTodo", new { id = task.Id }, task);
		}



		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] Task task)
		{
			if (task == null || task.Id != id)
			{
				return BadRequest();
			}

			var existingTask = _context.Task.FirstOrDefault(t => t.Id == id);
			if (existingTask == null)
			{
				return NotFound();
			}

			existingTask.Name = task.Name;
			existingTask.CoordinatorName = task.CoordinatorName;
			existingTask.CoordinatorPhone = task.CoordinatorPhone;
			existingTask.StartDate = task.StartDate;
			existingTask.EndDate = task.EndDate;
			existingTask.Description = task.Description;
			existingTask.VolunteersRequired = task.VolunteersRequired;
			existingTask.VolunteersSigned = task.VolunteersSigned;

	    	_context.Task.Update(existingTask);
			_context.SaveChanges();
			return new NoContentResult();
		}



		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var task = _context.Task.First(t => t.Id == id);
			if (task == null)
			{
				return NotFound();
			}

			_context.Task.Remove(task);
			_context.SaveChanges();
			return new NoContentResult();
		}
		
	}

}




