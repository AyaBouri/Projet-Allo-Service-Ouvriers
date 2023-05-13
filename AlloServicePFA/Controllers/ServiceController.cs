using AlloServicePFA.Filtres;
using AlloServicePFA.Models;
using AlloServicePFA.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlloServicePFA.Controllers
{
    [IsAdmin]
    public class ServiceController : Controller
    {
        MyContext db;
        public ServiceController(MyContext db)
        {
            this.db = db;
        }
        [IsAdmin]
        public IActionResult Index()
        {
            List<ServiceIndexViewModel> serviceCreateModelViews = db.services.Select(serv => new ServiceIndexViewModel(serv)).ToList();
            return View(serviceCreateModelViews);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [IsAdmin]
        public IActionResult Add(ServiceCreateModelView model)
        {
            if (ModelState.IsValid)
            {
                db.services.Add(new Service(model));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        [IsAdmin]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Service service = db.services.Where(s => s.ServiceId == id).FirstOrDefault();
                if (service != null)
                {
                    db.services.Remove(service);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(); 
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [IsAdmin]
        public IActionResult Edit(ServicEditModelView model)
        {
            if (ModelState.IsValid)
            {
                Service serice = db.services.Where(p => p.ServiceId == model.Id).FirstOrDefault();
                if (serice != null)
                {
                    serice.Libelle = model.Libelle;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                //else
                //{
                //    serice.Libelle = model.Libelle;
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
            }
            return View(model);
        }
    }
}