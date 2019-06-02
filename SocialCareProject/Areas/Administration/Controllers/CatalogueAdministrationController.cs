using System.Web.Mvc;
using Services.Product;
using SocialCareProject.Authentication;
using SocialCareProject.Factories;
using SocialCareProject.Models;

namespace SocialCareProject.Areas.Administration.Controllers
{
    public class CatalogueAdministrationController : BaseAdministrationController
    {

        private readonly IProductService _productService;
        private readonly IProductFactory _productFactory;

        public CatalogueAdministrationController(IProductService productService,
            IProductFactory productFactory)
        {
            _productService = productService;
            _productFactory = productFactory;
        }


        // GET: Customer/Product
        public ActionResult Index(SimplePagerModel pager)
        {
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