using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext _db)
        {
            _context = _db;
        }

        public async Task<IActionResult>   Index()
        {
            List<Category> category = await _context.Categories.ToListAsync();
            return View( category);
        }

        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult  Create( Category _category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Categories.Add(_category);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine(); 
                }
     
                
           
            }
            return View(_category);
        }

        public IActionResult Edit( int? id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            Category? data = _context.Categories.FirstOrDefault(c => c.Id == id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit( Category _category)
        {
            var yoy = _category.Name;
            if (ModelState.IsValid)
            {
             _context.Categories.Update(_category);
             _context.SaveChanges();
             return RedirectToAction("Index");
            }
            return Edit(_category);
        }

        public IActionResult Delete(int id)
        {

           var deleteItem =  _context.Categories.Find(id);
            _context.Categories.Remove(deleteItem);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }

}
