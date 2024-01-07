using Business.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Simple.DAL.Context;

namespace Simple.MVC.Areas.Manage.Controllers
{
    public class BlogController : Controller
    {
		private readonly AppDbContext _context;

		public BlogController(AppDbContext context)
        {
			_context = context;
		}
        public IActionResult Index()
        {
		    List<Blog> blogs = _context.Blogs.ToList();
            return View(blogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        { 
            Blog blog = _context.Blogs.Find(id);
            _context.Blogs.Remove(blog);
            _context.SaveChanges() ;
            return RedirectToAction("Index");

        }
    }
}
