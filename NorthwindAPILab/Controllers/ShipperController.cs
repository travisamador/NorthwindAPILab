using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPILab.Models;

namespace NorthwindAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        public NorthwindContext northwindcontext = new NorthwindContext();

        [HttpGet("GetByShipperId")]
        public Shipper GetByShipperId(int id)
        {
            return northwindcontext.Shippers.FirstOrDefault(s => s.ShipperId == id);
        }

        [HttpGet("GetByCompanyName")]
        public Shipper GetByShipperName(string name)
        {
            return northwindcontext.Shippers.FirstOrDefault(s => s.CompanyName == name);
        }

        [HttpPost("AddShipper")]
        public Shipper AddShipper(string companyName, string phone)
        {
            Shipper newShipper = new Shipper()
            {
                CompanyName = companyName,
                Phone = phone
            };
            northwindcontext.Shippers.Add(newShipper);
            northwindcontext.SaveChanges();
            return newShipper;
        }

        [HttpDelete("RemoveShipper")]
        public Shipper DeleteById(int id)
        {
            Shipper shipper = northwindcontext.Shippers.FirstOrDefault(s => s.ShipperId == id);
            northwindcontext.Shippers.Remove(shipper);
            northwindcontext.SaveChanges();
            return shipper;
        }

        [HttpPost("PutShipper")]
        public Shipper PutShipper(int id, string companyName, string phone)
        {
            Shipper currentShipper = northwindcontext.Shippers.FirstOrDefault(s => s.ShipperId == id);
            if (currentShipper != null)
            {
                currentShipper.CompanyName = companyName;
                currentShipper.Phone = phone;

                northwindcontext.SaveChanges();
            }
            return currentShipper;
        }
    }
}
