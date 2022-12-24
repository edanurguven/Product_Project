using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _user;
        public ProductController(IProduct user)
        {
            _user = user;
        }
        public IActionResult Index()
        {
            return View(_user.GetAll());
        }

        public IActionResult Add(Product user)
        {

            if (user.Name == null)
            { return View(new Product()); }
            else
            {
                _user.Add(user);
                return RedirectToAction("GetAll");

            }
        }

        public IActionResult Delete()
        {
            var _id = Int32.Parse(RouteData.Values["id"].ToString());
            _user.Delete(_id);
            return RedirectToAction("GetAll");
        }

        public IActionResult Update(Product user)
        {

            if (user.Name == null)
            {
                return View(new Product());
            }
            else
            {
                var id = Int32.Parse(RouteData.Values["id"].ToString());
                Product u = _user.GetById(id);
                u.Name = user.Name;
                u.Explanation = user.Explanation;
                _user.Update(u);
                return RedirectToAction("GetAll");
            }
        }
        public IActionResult Profil()
        {
            var id = Int32.Parse(RouteData.Values["id"].ToString());
            Product u = _user.GetById(id);
            return View(u);
        }

        public IActionResult GetAll()
        {
            return View(_user.GetAll());
        }

        [HttpGet]
        public IActionResult SearchResult(string productname)
        {
            //Show results
            if (productname != null)
            {
                char[] delimiterChars = { ',', '.', ':' };
                string[] array = productname.Split(delimiterChars, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                var dbList = _user.GetChoose(array);
                return View(dbList);
            }
            else
            {
            
                return View();
            }
        }
    }
}
