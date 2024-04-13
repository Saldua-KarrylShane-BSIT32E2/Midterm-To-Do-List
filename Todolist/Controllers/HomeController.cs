using Microsoft.AspNetCore.Mvc;
using System;
using Todo.Repositories;
using Todo.Domain;
using Todo.Service;

namespace Todolist.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _userService;

        public HomeController(UserService userService)
        {
            _userService = userService;
        }

        // GET: /Home/Index
        public ActionResult Index()
        {
            return View();
        }

        // POST: /Home/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newUser = new User { Email = model.Email, Password = model.Password };
                    _userService.Register(newUser);
                    ViewBag.Message = "User registered successfully.";
                    return RedirectToAction("Login", "Account");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = $"Error: {ex.Message}";
                }
            }
            return View(model);
        }

        // Other controller actions for other functionalities can be added here
    }
}

