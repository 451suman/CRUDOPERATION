using CRUDOPERATION.Data;
using CRUDOPERATION.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOPERATION.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;            
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList= _db.categories;
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
     
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {



            if(ModelState.IsValid)    
            {
               /* if (obj.Name == "suman")
                {
                    ModelState.AddModelError("Name", "The Name cannot be 'suman'.");
                    return View(obj); // Return the view with errors
                }*/
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
          //if validation code written in model is validat redirect to Index
          // stay on same page

        }
    }
   
}
