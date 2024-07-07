using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;
using System.Linq.Expressions;

namespace StudentPortal.Web.Controllers
{
	public class StudentsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public StudentsController(ApplicationDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddStudentViewModel viewModel)
		{

			await _context.Students.AddAsync(new Student
			{
				Name = viewModel.Name,
				Age = viewModel.Age,
				Email = viewModel.Email,
				Subscribed = viewModel.Subscribed,
				Phone = viewModel.Phone,
			});

			await _context.SaveChangesAsync();

			return RedirectToAction("List");
		}


		[HttpGet]
		public async Task<IActionResult> List()
		{
			var students = await _context.Students.ToListAsync();
			return View(students);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid Id)
		{
			var student = await _context.Students.FindAsync(Id);

			if (student is null)
			{
				return NotFound();
			}

			return View(student);
		}


		[HttpPost]
		public async Task<IActionResult> Edit(Student viewModel)
		{
			var student = await _context.Students.FindAsync(viewModel.Id);


			if (student is not null)
			{
				student.Name = viewModel.Name;
				student.Age = viewModel.Age;
				student.Email = viewModel.Email;
				student.Subscribed = viewModel.Subscribed;
				student.Phone = viewModel.Phone;
				await _context.SaveChangesAsync();


			}

			return RedirectToAction("List");

		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var student = await _context.Students.FindAsync(Id);

			if(student is not null)
			{
				_context.Students.Remove(student);

				await _context.SaveChangesAsync();

			}

			return RedirectToAction("List");
		}
	}
}
