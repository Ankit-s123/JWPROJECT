using JWPROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JWPROJECT.Controllers
{
    public class AdminController : Controller
    {

        private readonly JWContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(JWContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("admin_session");
            if (user != null)
            {
                return View("Index");
            }
            else
            {
                return View("Login");
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            ViewData["total_user"] = _context.tbl_user.Count();
            ViewData["total_project"] = _context.tbl_project.Count();
            //ViewData["total_Other_user"] = _context.tbl_Other_users.Count();
            //ViewData["total_Add"] = _context.tbl_Add_Query.Where(n => n.read_status == 1).Count();
            //var usersession = HttpContext.Session.GetString("user_session");
            base.OnActionExecuting(context);

        }

        public IActionResult Login()
        {

            var user = HttpContext.Session.GetString("admin_session");
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

        public IActionResult Login(string admin_email,string admin_password)
        {
            var admin = _context.tbl_login.Where(a => a.admin_email == admin_email && a.admin_password==admin_password).FirstOrDefault();
            if(admin!=null)
            {
                HttpContext.Session.SetString("admin_session", admin.admin_email);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Invalid username or password";
                return View("Login");
            }
        }


        public IActionResult AddProject()
        {
            var user = HttpContext.Session.GetString("admin_session");
            if (user != null)
            {
                
                return View();
            }
            else
            {
                return View("Login");
            }
        }
        [HttpPost]
        public IActionResult AddProject(Project project, IFormFile PZip, IFormFile PDocument)
        {
            var user = HttpContext.Session.GetString("admin_session");

            if (user == null)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                // Handle ZIP File
                if (PZip != null)
                {
                    if (Path.GetExtension(PZip.FileName).ToLower() != ".zip")
                    {
                        TempData["error"] = "Only ZIP files are allowed.";
                        return View();
                    }

                    string zipName = Guid.NewGuid().ToString() + Path.GetExtension(PZip.FileName);
                    string zipPath = Path.Combine(_webHostEnvironment.WebRootPath, "AllProjects", zipName);

                    using var stream = new FileStream(zipPath, FileMode.Create);
                    PZip.CopyTo(stream);
                    project.PZip = zipName;
                }

                // Handle Document File
                if (PDocument != null)
                {
                    var validExtensions = new[] { ".pdf", ".ppt", ".pptx" };
                    if (!validExtensions.Contains(Path.GetExtension(PDocument.FileName).ToLower()))
                    {
                        TempData["error"] = "Only PDF, PPT, and PPTX files are allowed.";
                        return View();
                    }

                    string docName = Guid.NewGuid().ToString() + Path.GetExtension(PDocument.FileName);
                    string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "AllDocuments", docName);

                    using var stream = new FileStream(docPath, FileMode.Create);
                    PDocument.CopyTo(stream);
                    project.PDocument = docName;
                }

                _context.tbl_project.Add(project);
                _context.SaveChanges();
                TempData["success"] = "Project added successfully!";
                return RedirectToAction("AddProject");
            }

            TempData["error"] = "Invalid form data.";
            return View();
        }
      
        public IActionResult AllProject()
        {
            var user = HttpContext.Session.GetString("admin_session");
            if (user != null)
            {
                return View(_context.tbl_project.ToList());
            }
            else
            {
                return View("Login");
            }
        }

        public IActionResult AllUsers()
        {
            var user = HttpContext.Session.GetString("admin_session");
            if (user != null)
            {
                return View(_context.tbl_user.ToList());
            }
            else
            {
                return View("Login");
            }
        }
        public IActionResult AllContact()
        {
            var user = HttpContext.Session.GetString("admin_session");
            if (user != null)
            {
                return View(_context.tbl_contact.ToList());
            }
            else
            {
                return View("Login");
            }
        }

        public IActionResult Delete_Project(int id)
        {
            var user = HttpContext.Session.GetString("admin_session");
            if (user != null)
            {
                
                var pro = _context.tbl_project.Where(b => b.PId == id).FirstOrDefault();

                _context.tbl_project.Remove(pro);
               
                _context.SaveChanges();
                return RedirectToAction("AllProject");

            }
            else
            {
                return View("Login");
            }
        }


        public IActionResult Branch()
        {
            var user = HttpContext.Session.GetString("admin_session");
            if (user != null)
            {

                return View(_context.tbl_branch.ToList());

            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        [HttpPost]
        public IActionResult SaveBranch(int? id, string email, string contact, string address, string description, string ins_link, string fb_link, string you_link, string li_link, IFormFile logo_image)
        {
            if (email == null)
            {
                TempData["error"] = "Please Enter Email!!";
            }
            else if (contact == null)
            {
                TempData["error"] = "Please Enter Contact Nubmer!!";
            }
            else if (address == null)
            {
                TempData["error"] = "Please Enter Address!!";
            }
            else if (description == null)
            {
                TempData["error"] = "Please Enter Description!!";
            }
            else if (ins_link == null)
            {
                TempData["error"] = "Please Enter Instagram Link!!";
            }
            else if (fb_link == null)
            {
                TempData["error"] = "Please Enter Facebook Link!!";
            }
            else if (li_link == null)
            {
                TempData["error"] = "Please Enter Linkedin Link!!";
            }
            else if (you_link == null)
            {
                TempData["error"] = "Please Enter Youtube Link!!";
            }

            else
            {

                if (id.HasValue)
                {
                    var existingB = _context.tbl_branch.Find(id.Value);
                    // Store the existing image filename
                    var existimage = existingB.logo_image;
                   

                    if (existingB != null)
                    {
                        if (logo_image != null)
                        {
                            // Process the new image if provided
                            var imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "logo_image");
                            if (!Directory.Exists(imageDirectory))
                            {
                                Directory.CreateDirectory(imageDirectory);
                            }
                            string uniqueFileName = Path.Combine(imageDirectory, logo_image.FileName);
                            //string uniqueFileName = Guid.NewGuid().ToString() + image.FileName;
                            string imagePath = Path.Combine(imageDirectory, uniqueFileName);

                            using (var fs = new FileStream(imagePath, FileMode.Create))
                            {
                                logo_image.CopyTo(fs);
                            }

                            existingB.logo_image = logo_image.FileName; // Save the new image filename
                        }
                        else
                        {

                            existingB.logo_image = existimage;
                        }
                      
                        existingB.email = email;
                        existingB.contact = contact;
                        existingB.address = address;
                        existingB.description = description;

                        existingB.ins_link = ins_link;
                        existingB.fb_link = fb_link;
                        existingB.you_link = you_link;
                        existingB.li_link = li_link;

                        TempData["success"] = "Branch Updated Successfully!!";
                        _context.SaveChanges();
                    }
                }

            }



            return RedirectToAction("Branch");
        }
        [HttpPost]
        public IActionResult Branch(Branch branch, IFormFile logo_image)
        {
            if (branch.email == null)
            {
                TempData["error"] = "Please Enter Email!!";

            }
            else if (branch.contact == null)
            {
                TempData["error"] = "Please Enter Contact Number!!";

            }
            else if (branch.address == null)
            {

                TempData["error"] = "Please Enter Address.!!";

            }
            else if (branch.description == null)
            {

                TempData["error"] = "Please Enter Description.!!";

            }
            else if (branch.ins_link == null)
            {

                TempData["error"] = "Please Enter Instagram Link.!!";

            }
            else if (branch.fb_link == null)
            {

                TempData["error"] = "Please Enter Facebook Link.!!";

            }
            else if (branch.you_link == null)
            {

                TempData["error"] = "Please Enter Twitter Link.!!";

            }
            else if (branch.li_link == null)
            {

                TempData["error"] = "Please Enter Linkedin Link.!!";

            }
            else if (logo_image == null)
            {

                TempData["error"] = "Please Uplodad Logo.!!";

            }

            else
            {
                if (logo_image != null)
                {
                    var imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "logo_image");
                    if (!Directory.Exists(imageDirectory))
                    {
                        Directory.CreateDirectory(imageDirectory);
                    }
                    string imagePath = Path.Combine(imageDirectory, logo_image.FileName);
                    using (var fs = new FileStream(imagePath, FileMode.Create))
                    {
                        logo_image.CopyTo(fs);
                    }

                }
               
                branch.logo_image = logo_image.FileName;
               

                _context.tbl_branch.Add(branch);
                _context.SaveChanges();
                TempData["success"] = "Branch Added Successfully!!";
            }


            return RedirectToAction("Branch");
        }

        [HttpGet]
        public IActionResult EditBranch(int id)
        {
            var branchToUpdate = _context.tbl_branch.Find(id);
            var branches = _context.tbl_branch.ToList();

            ViewBag.FormTitle = "Update Teacher";
            ViewBag.BId = branchToUpdate.id;
            ViewBag.Bemail = branchToUpdate.email;
            ViewBag.Baddress = branchToUpdate.address;
            ViewBag.Bcontact = branchToUpdate.contact;
            ViewBag.Bdes = branchToUpdate.description;
            ViewBag.Blogo = branchToUpdate.logo_image;
            ViewBag.Bins = branchToUpdate.ins_link;
            ViewBag.Btwt = branchToUpdate.you_link;
            ViewBag.Bfb = branchToUpdate.fb_link;
            ViewBag.Bli = branchToUpdate.li_link;
            return View("Branch", branches);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("admin_session");
            return RedirectToAction("Login");
        }
    }
}
