using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservice.Data;
using VendorMicroservice.Models;

namespace VendorMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly VendorDbContext _db;

        public VendorController(VendorDbContext db)
        {
            _db = db;
        }

        [HttpGet("{product_Id}")]
        public IActionResult getVendorDetails(int product_Id)
        {
            var result = _db.VendorStocks.Where(s => s.ProductId == product_Id && s.StockInHand > 0).OrderBy(s=>s.Vendor.DeliveryCharge).Select(s => new { VendorId = s.VendorId, VendorName = s.Vendor.VendorName, Rating = s.Vendor.Rating, DeliveryCharge = s.Vendor.DeliveryCharge });
            return Ok(result);
        }
    }
}
