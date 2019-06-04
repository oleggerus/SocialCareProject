using Services.Product;
using SocialCareProject.Authentication;
using SocialCareProject.Factories;
using SocialCareProject.Models;
using System.Web.Mvc;

namespace SocialCareProject.Areas.Customer.Controllers
{
    public class ProductController : BaseCustomerController
    {

        private readonly IProductService _productService;
        private readonly IProductFactory _productFactory;

        public ProductController(IProductService productService,
            IProductFactory productFactory)
        {
            _productService = productService;
            _productFactory = productFactory;
        }




        // GET: Customer/Product
        public ActionResult Index(SimplePagerModel pager)
        {
            var currentUser = HttpContext.User as CustomUser;
            var products = _productService.GetAllProducts(pager.PageIndex, pager.PageSize);

            var model = _productFactory.PrepareProductListModel(products);

            return View(model);
        }

        public JsonResult GetFilteredProducts(SimplePagerModel pager)
        {
            var products = _productService.GetAllProducts(pager.PageIndex, pager.PageSize);
            var model = _productFactory.PrepareProductListModel(products);
            var url = GetUrlWithFilters(pager);

            return CreateJsonResult(true, url, model);
        }

        public ActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            var model = _productFactory.PrepareProductDetailsModel(product);

            return View(model);
        }


        

        private string GetUrlWithFilters(SimplePagerModel pager)
        {
            var urlParams = new
            {
                pageIndex = pager.PageIndex,
                pageSize = pager.PageSize
            };

            return Url.Action("Index", urlParams);
        }
    }
}