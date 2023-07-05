using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Entity.Concrete;
using ShoppingApp.Web.Areas.Admin.Models.Dtos;
using ShoppingApp.Web.Models.Dtos;

namespace ShoppingApp.Web.Controllers;

public class HomeController : Controller
{

    private readonly IProductService _productManager;

    public HomeController(IProductService productManager)
    {
        _productManager = productManager;
    }

    public async Task<IActionResult> Index()
    {
        List<Product> products = await _productManager.GetHomePageProductsAsync();
        List<ProductDto> productDtos= new List<ProductDto>();
        foreach (var product in products)
        {
            productDtos.Add(new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl=product.ImageUrl,
                Url = product.Url,
            });
        }
        return View(productDtos);
    }
    public async Task<IActionResult> Search(SearchQueryDto searchQueryDto)
    {
        List<Product> searchResults = await _productManager.GetSearchResultsAsync(p=>p.IsApproved);
        List<ProductDto> productDtos = new List<ProductDto>();
        foreach (var product in searchResults)
        {
            productDtos.Add(new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Url = product.Url
            });
        }
        return View(productDtos);
    }
}
