using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Task_Junior.Models;
using Task_Junior.Services;
using Task_Junior.ViewModel;

namespace Task_Junior.Controllers
{
    public class ProductController : Controller
    {
        IRepostory<Product> repostory;
        private IProduct Product { get; }
        public ProductController(IRepostory<Product> _repostory,IProduct product)
        {
            this.repostory = _repostory;
            Product = product;
        }

        [HttpPost]
        public IActionResult search(int ID)
        {
            ViewBag.Cat = Product.GetAllcategories();
            return View("Index",Product.GetAllProductByGategoryID(ID));
        }
        public IActionResult Index()
        {
            ViewBag.Cat = Product.GetAllcategories();
            return View(repostory.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Cat= Product.GetAllcategories();
            return View(); 
        }
        [HttpPost]
        public IActionResult Create(Product Newproduct)
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


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Cat = Product.GetAllcategories();
            return View(repostory.GetByID(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, Product ProduEdit)
        {
            if (ModelState.IsValid)
            {
                
                Product ProductEdited = repostory.GetByID(id);
                if (ProductEdited != null)
                {
                    ProductEdited.Name = ProduEdit.Name;
                    ProductEdited.CreationDate = ProduEdit.CreationDate;
                    ProductEdited.StartDate= ProduEdit.StartDate;
                    ProductEdited.Duration_EndDate = ProduEdit.Duration_EndDate;
                    ProductEdited.Price = ProduEdit.Price;
                    ProductEdited.Categ_Id = ProduEdit.Categ_Id;
                }
                repostory.Update(ProductEdited);
                repostory.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(repostory.GetByID(id));

        }

        public IActionResult Delete(int id)
        {
            repostory.Delete(id);
            repostory.Save();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int id)
        {
            return View(repostory.GetByID(id));
        }


        [HttpGet]
        public IActionResult ShowProductsForClients() 
        {
            var DataMProductList = repostory.GetAll();
            if (DataMProductList != null)
            {
                List<ViewModeProductsAsCards> viewMProductList = new List<ViewModeProductsAsCards>();
                foreach (var item in DataMProductList)
                {
                    Product prodExpect = Product.GetProductByID(item.Id);
                    if (prodExpect != null)
                    {
                        viewMProductList.Add(new ViewModeProductsAsCards()
                        {
                            ProductName = prodExpect.Name,
                            ProductPrice = prodExpect.Price
                        });
                    }
                }
                //ViewModeProductsAsCards
                return View(viewMProductList);
            }
            return View(new List<ViewModeProductsAsCards>());

        }


    }
}
