using Microsoft.AspNetCore.Mvc;
using PhoneStore.Controllers;
using System.Linq;
using PhoneStore.Models;

namespace PhoneStore.Controllers
{
    public class ListsController : Controller
    {
        PhoneStoreContext db;
        public ListsController(PhoneStoreContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.PhoneId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return "Спасибо, " + order.User + ", за покупку!";
        }
    }
}
