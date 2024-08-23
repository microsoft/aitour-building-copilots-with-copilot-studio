using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ContosoApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        [SwaggerOperation(OperationId ="GetOrderDetails",
            Summary = "Get Order Details", 
            Description = "Get the details of an order, including the contents of the order, the total value of the order (plus the tax and pre tax values), and the status of the order, including shipping and delivery dates.")]
        [HttpGet(Name = "/GetOrderDetails/{orderNumber}")]
        public Order GetOrderDetails(
            [SwaggerParameter("The order number / reference.", Required = true)]
            string orderNumber)
        {
            return new Order
            {
                OrderNumber = orderNumber,
                OrderDetails = new OrderDetails
                {
                    Items = new List<Item>
            {
                new Item { ItemId = "A001", Description = "Industrial Motor", Quantity = 2, UnitPrice = 450.00 },
                new Item { ItemId = "B023", Description = "Hydraulic Pump", Quantity = 1, UnitPrice = 600.00 }
            },
                    TotalValue = new TotalValue
                    {
                        Subtotal = 1500.00,
                        Tax = 150.00,
                        TotalIncludingTax = 1650.00
                    },
                    OrderDate = "2023-12-17",
                    ShippingAddress = new ShippingAddress
                    {
                        Street = "1 Microsoft Way",
                        City = "Redmond",
                        State = "WA",
                        ZipCode = "98052",
                        Country = "USA"
                    }
                },
                OrderStatus = new OrderStatus
                {
                    CurrentStatus = "Shipped",
                    ShipmentDetails = new ShipmentDetails
                    {
                        ShippedDate = "2023-12-18",
                        EstimatedDeliveryDate = "2023-12-23",
                        ShippingMethod = "Express Delivery"
                    }
                }
            };
        }

    }
}
