using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using System.Diagnostics;




namespace MVC.Controllers
{

   
    public class HomeController : Controller
    {
        private readonly StudentDBContext StdDB;

        public HomeController(StudentDBContext StudentDB)
        {
            this.StdDB = StudentDB;
        }
        
        public IActionResult user() 
        {

            var studentData = StdDB.Students.ToList();

            return View(studentData);
        }

        public IActionResult AgGrid()
        {

            var studentData = StdDB.Students.ToList();

            return View(studentData);
        }


        [HttpGet]
        public IActionResult Index() //Display data on screen from DB //Read
        {
            var studentData= StdDB.Students.ToList();

            return View(studentData);
        }

        [HttpGet]
        public IActionResult Create() //Get
        {
           
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Student std) //Create ->Insert
        {
            if (ModelState.IsValid)
            {
                StdDB.Students.Add(std);
                StdDB.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Edit(int id) // Fetching data in edit form to Update
        {
            var stud= StdDB.Students.Find(id);
            return View(stud);
        }
        [HttpPost]
        public IActionResult Edit(int id,Student std) //Update
        {
            if (ModelState.IsValid)
            {
                StdDB.Students.Update(std);
                StdDB.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();

           
        }
        public IActionResult Delete(int id) //Delete Get
        {
            var stud = StdDB.Students.FirstOrDefault(x=>x.Id==id);

            return View(stud);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id) //Delete
        {
            var stud = StdDB.Students.Find(id);
            StdDB.Students.Remove(stud);
            StdDB.SaveChanges();
            return RedirectToAction("Index", "Home");
            
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}