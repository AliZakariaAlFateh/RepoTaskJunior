using Microsoft.AspNetCore.Mvc;
using Task_Junior.Models;
using Task_Junior.Services;

namespace Task_Junior.Controllers
{
    public class ProductController : Controller
    {
        IRepostory<Product> repostory;

        public IProduct Product { get; }

        public ProductController(IRepostory<Product> _repostory,IProduct product)
        {
            this.repostory = _repostory;
            Product = product;
        }

        public IActionResult Index()
        {
            return View(repostory.GetAll());
        }
        public IActionResult Details(int id) { 
        
            return View(repostory.GetByID(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Cat= Product.GetAllcategories();
            return View(); 
        }
        [HttpPost]
        public IActionResult Create([FromBody] Product Newproduct)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    repostory.Add(Newproduct);
                    repostory.Save();
                    return RedirectToAction("Index");
                }catch(Exception ex)
                {
                    ModelState.AddModelError("", "product is invalid " + ex.Message);
                }
            }
            return View(Newproduct);
        }





    }
}
