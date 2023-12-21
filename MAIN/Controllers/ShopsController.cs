using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SERVICE.Dtos.Shops;
using SERVICE.Services;

namespace MAIN.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ShopsController : MainControllerBase
{
    private ShopService _shopService;
    public ShopsController(
        ShopService shopService
    )
    {
        _shopService = shopService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var shop = _shopService.GetAll()
            .Where(c => c.Id == CurrentShopId)
            .Include(s => s.ShopBranches)
            .FirstOrDefault();

        return Ok(ShopDto.Create(shop));
    }

    [HttpGet("{shopId}")]
    public IActionResult GetByShopId([FromRoute] long shopId)
    {
        var shop = _shopService.GetAll()
            .FirstOrDefault(u => u.Id == shopId);

        if (shop == null)
        {
            return NotFound();
        }

        return Ok(ShopDto.Create(shop));
    }

}
