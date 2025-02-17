﻿using CRUDOPERATION.Data;
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


        //EDit 
        public IActionResult Edit(int? id)
        {
            if(id== null || id==0)
            {
                return RedirectToAction("Index");
            }
            var categoryFromDB = _db.categories.Find(id);
            /*var categoryFormDbFirst = _db.categories.FirstOrDefault(c => c.Id == id);
            var categoryFormDbFirst = _db.categories.SingleOrDefault(c => c.Id == id); */           
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                /* if (obj.Name == "suman")
                 {
                     ModelState.AddModelError("Name", "The Name cannot be 'suman'.");
                     return View(obj); // Return the view with errors
                 }*/
                _db.categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            //if validation code written in model is validat redirect to Index
            // stay on same page

        }


        //Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Index");
            }
            var categoryFromDB = _db.categories.Find(id);
            /*var categoryFormDbFirst = _db.categories.FirstOrDefault(c => c.Id == id);
            var categoryFormDbFirst = _db.categories.SingleOrDefault(c => c.Id == id); */
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
           var obj = _db.categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           
           

        }


    }
   
}
