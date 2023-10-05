using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;
using Task_Junior.Models;
using Task_Junior.Services;
using Task_Junior.ViewModel;

namespace Task_Junior.Controllers
{
    public class ProductController : Controller
    {
        IRepostory<Product> repostory;
        private readonly UserManager<IdentityUser> userManager;

        private IProduct Product { get; }
        public ProductController(IRepostory<Product> _repostory,IProduct product,UserManager<IdentityUser> userManager)
        {
            this.repostory = _repostory;
            Product = product;
            this.userManager = userManager;
        }

        [HttpPost]
        public IActionResult search(int ID)
        {
            ViewBag.Cat = Product.GetAllcategories();
            return View("Index",Product.GetAllProductByGategoryID(ID));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username= userManager.FindByIdAsync(userId).Result;
           
            ViewBag.Cat = Product.GetAllcategories();
            return View(repostory.GetAll());
        }

        [HttpGet]

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Cat= Product.GetAllcategories();
            return View(); 
        }
        [HttpPost]

        [Authorize(Roles = "Admin")]
        public IActionResult Create(Product Newproduct,IFormFile ImageFile)
        {
            if(ModelState.IsValid)
            {
                try
                {
                  string ImageName=Product.UploadFile(ImageFile);
                    //var user = userManager.FindByIdAsync(User.Identity.Name);
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Newproduct.Image = ImageName;
                    Newproduct.UserID = userId;
                    repostory.Add(Newproduct);
                    repostory.Save();
                    return RedirectToAction("Index");
                }catch(Exception ex)
                {
                    ModelState.AddModelError("", "product is invalid " + ex.Message);
                }
            }
            ViewBag.Cat = Product.GetAllcategories();

            return View(Newproduct);
        }


        [HttpGet]

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            ViewBag.Cat = Product.GetAllcategories();
            return View(repostory.GetByID(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, Product ProduEdit,IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                string ImageName = Product.UploadFile(ImageFile);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Product ProductEdited = repostory.GetByID(id);
                if (ProductEdited != null)
                {
                    ProductEdited.Name = ProduEdit.Name;
                    ProductEdited.CreationDate = ProduEdit.CreationDate;
                    ProductEdited.StartDate= ProduEdit.StartDate;
                    ProductEdited.Duration_EndDate = ProduEdit.Duration_EndDate;
                    ProductEdited.Price = ProduEdit.Price;
                    ProductEdited.Categ_Id = ProduEdit.Categ_Id;
                    ProductEdited.Image = ImageName;
                    ProductEdited.UserID = userId;    
                }
                repostory.Update(ProductEdited);
                repostory.Save();
                return RedirectToAction(nameof(Index));

            }
            ViewBag.Cat = Product.GetAllcategories();
            return View(repostory.GetByID(id));

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            repostory.Delete(id);
            repostory.Save();
            return RedirectToAction(nameof(Index));

        }

        [Authorize]
        public IActionResult Details(int id)
        {
            return View(repostory.GetByID(id));
        }


        [HttpGet]
        [Authorize]
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
                            Id = item.Id,
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
