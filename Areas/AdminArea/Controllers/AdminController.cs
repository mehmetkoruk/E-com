using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EticaretShoes.Interface;
using EticaretShoes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private IShoes shoes;
        private IPasswordValidator<ApplicationUser> passwordValidator;
        private IPasswordHasher<ApplicationUser> passwordHasher;

        public AdminController(UserManager<ApplicationUser> _userManager,
                    IPasswordValidator<ApplicationUser> _passwordValidator,
                    IPasswordHasher<ApplicationUser> _passwordHasher,IShoes _shoes)
        {
            userManager = _userManager;
            passwordHasher = _passwordHasher;
            passwordValidator = _passwordValidator;
            shoes = _shoes;
        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterModel r)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();

                user.UserName = r.UserName;
                user.Email = r.Email;

                var result = await userManager.CreateAsync(user, r.Password);

                if (result.Succeeded)
                {
                    //return RedirectToAction("SepetiGetir","Home");
                    return RedirectToAction("SepetGetir", "Home", new { area = "area" });
                }


               

                
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(r);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(Id);
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            if (user!=null)
            {
                return View(user);
            }
            else
            {
                return View("Index");
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string Id, string Password, string Email)
        {
            var user = await userManager.FindByIdAsync(Id);
            if (user != null)
            {
                user.Email = Email;
                IdentityResult validPassword = null;
                if (!string.IsNullOrEmpty(Password))
                {
                    validPassword = await passwordValidator.ValidateAsync(userManager, user, Password);
                    if (validPassword.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, Password);
                    }
                }
                else
                {
                    foreach (var item in validPassword.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                if (validPassword.Succeeded)
                {
                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "user Not Fount");
            }
            return View(user);
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Shoes s)
        {
            var newproduct = new Shoes()
            {
                ShoesName = s.ShoesName,
                imageUrl=s.imageUrl,
                Price=s.Price,
                Gender=s.Gender,
                CategoryNo=s.CategoryNo,
                

            };
           var x= shoes.AddProduct(newproduct);
            return View();
        }
    }
}