using AlloServicePFA.Models;
using AlloServicePFA.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
namespace AlloServicePFA.Controllers
{
    public class UserController : Controller
    {
        MyContext db;
        public UserController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                WebMaster wm = db.webmasters.FirstOrDefault(d => d.Email == user.Email && d.password == user.password);
              
                if (wm != null)
                {
                    HttpContext.Session.SetString("Name", user.Nom + " " + user.Prenom);
                    HttpContext.Session.SetString("Role", "Web MAster");
                    HttpContext.Session.SetString("Id", user.UserId.ToString());
                    return RedirectToAction("../User/WebMaster/Index");
                }
                else
                {
                    Client clt = db.clients.FirstOrDefault(u => u.Email == user.Email && u.password == user.password);
                    if (clt != null)
                    {
                        HttpContext.Session.SetString("Name", user.Nom + " " + user.Prenom);
                        HttpContext.Session.SetString("Role", "Web MAster");
                        HttpContext.Session.SetString("Id", user.UserId.ToString());
                        return RedirectToAction("../User/Client/Index");
                    }
                    else
                    {
                        Ouvrier o = db.ouvriers.FirstOrDefault(s => s.Email == user.Email && s.password == user.password);
                        if (o != null)
                        {
                            HttpContext.Session.SetString("Name", user.Nom + " " + user.Prenom);
                            HttpContext.Session.SetString("Role", "Web MAster");
                            HttpContext.Session.SetString("Id", user.UserId.ToString());
                            return RedirectToAction("../User/Ouvrier/Index");
                        }
                    }
                }
                message = "Login/password Incorrecte";
                ViewBag.msg = message;
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult Inscription()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Inscription(UserRegisterModelView model)
        {
            if (ModelState.IsValid)
            {
                int count = db.users.Where(us => us.Login == model.Login).Count();
                if (count == 0)
                {
                    User user = new User(model);
                    db.users.Add(user);
                    db.SaveChanges();
                    HttpContext.Session.SetString("Nom", user.Nom);
                    HttpContext.Session.SetString("Prenom", user.Prenom);
                    HttpContext.Session.SetString("Role", user.Role);
                    return RedirectToAction("Index", "Inscription");
                }
                ModelState.AddModelError("Login", "Login déja exists!");
            }
            return View();
        }
        public IActionResult forgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult forgotPassword(User u)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                WebMaster d = db.webmasters.FirstOrDefault(d => d.Login == u.Login && d.password == u.password);
                Client e = db.clients.FirstOrDefault(e => e.Login == u.Login && e.password == u.password);
                Ouvrier s = db.ouvriers.FirstOrDefault(s => s.Login == u.Login && s.password == u.password);
                if (d != null)
                {
                    HttpContext.Session.SetString("Name", d.Nom + " " + d.Prenom);
                    HttpContext.Session.SetString("Role", "Directeur");
                    HttpContext.Session.SetString("Id", d.UserId.ToString());
                    return RedirectToAction("../User/WebMaster");
                }
                else if (e != null)
                {
                    HttpContext.Session.SetString("Name", e.Nom + " " + e.Prenom);
                    HttpContext.Session.SetString("Role", "Admin");
                    HttpContext.Session.SetString("Id", e.ClientId.ToString());
                    return RedirectToAction("../User/Client");
                }
                else if (s != null)
                {
                    HttpContext.Session.SetString("Name", s.Nom + " " + s.Prenom);
                    HttpContext.Session.SetString("Role", "Superviseur");
                    HttpContext.Session.SetString("Id", s.OuvrierId.ToString());
                    return RedirectToAction("../User/Ouvrier");
                }
                else msg = "Login/Password incorrect!!";
            }
            ViewBag.msg = msg;
            return View();
        }
    }
}