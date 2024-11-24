using JWPROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace JWPROJECT.Controllers
{
    public class CustomerController : Controller
    {

        private readonly JWContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomerController(JWContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.Checksession = HttpContext.Session.GetString("user_session");
            return View();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {


            var branch = _context.tbl_branch.OrderByDescending(b => b.id).FirstOrDefault();
            if (branch != null)
            {

                ViewData["email"] = branch.email;
                ViewData["contact"] = branch.contact;
                ViewData["address"] = branch.address;
                ViewData["fb_link"] = branch.fb_link;
                ViewData["ins_link"] = branch.ins_link;
                ViewData["twt_link"] = branch.you_link;
                ViewData["description"] = branch.description;
                ViewData["logo_image"] = branch.logo_image;
                //ViewData["Bimage1"] = branch.ban_image1;
                //ViewData["Bimage2"] = branch.ban_image2;
                //ViewData["Bimage3"] = branch.ban_image3;
                ViewData["li_link"] = branch.li_link;

            }


            base.OnActionExecuting(context);
        }
        public IActionResult ULogin()
        {

            var user = HttpContext.Session.GetString("user_session");
            if (user != null)
            {
                return View("Index");
            }
            else
            {
                return View();
            }

        }


        [HttpPost]

        public IActionResult ULogin(string UPhone, string UPass)
        {
            var user = _context.tbl_user.Where(a => a.UPhone == UPhone && a.UPass == UPass).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetString("user_session", user.UPhone);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Invalid Phone Number or password !!";
                return View("ULogin");
            }
        }


        public IActionResult SignUp()
        {
            return View();
        }


 [HttpPost]
   
public IActionResult SignUp(User user, string UName, string UPhone, string UEmail, string UAddress, string UPass, string UCPass)
    {
          var user_data=  _context.tbl_user.Where(u => u.UPhone == UPhone).FirstOrDefault();
            if (user_data != null)
            {
                TempData["error"] = "Already This Phone Number !!";
                // Redirect to the Index action or another appropriate page
                return RedirectToAction("SignUp");
            }

            user.UName = UName;
            user.UPhone = UPhone;
            user.UEmail = UEmail;
            user.UAddress = UAddress;
            user.UPass = UPass; // Ensure to hash the password here
            user.UCPass = UCPass;
            // Add to the database
            _context.tbl_user.Add(user);
            _context.SaveChanges();

            TempData["success"] = "Regestration successfully Please Loign !!";
            // Redirect to the Index action or another appropriate page
            return RedirectToAction("SignUp");


        }

        public IActionResult Profile()
        {
            ViewBag.Checksession = HttpContext.Session.GetString("user_session");
            var user = HttpContext.Session.GetString("user_session");
            if (user != null)
            {
                var u_data = _context.tbl_user.Where(u => u.UPhone == user.ToString()).FirstOrDefault();
                return View(u_data);

            }
            else
            {
                return RedirectToAction("ULogin");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user_session");
            return RedirectToAction("Index");
        }

        public IActionResult Blog()
        {
            ViewBag.Checksession = HttpContext.Session.GetString("user_session");
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact contact)
        {

            _context.tbl_contact.Add(contact);
            _context.SaveChanges();
            TempData["success"] = "Thank You For Contact Us , We Will Contact Soon !!";
            return RedirectToAction("Index","Customer");
            
        }

    }
}
