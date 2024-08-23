namespace ContosoApiApp
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public class OrderDetails
    {
        public List<Item> Items { get; set; }
        public TotalValue TotalValue { get; set; }
        public string OrderDate { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
    }

    public class Item
    {
        public string ItemId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }

    public class TotalValue
    {
        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public double TotalIncludingTax { get; set; }
    }

    public class ShippingAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }

    public class OrderStatus
    {
        public string CurrentStatus { get; set; }
        public ShipmentDetails ShipmentDetails { get; set; }
    }

    public class ShipmentDetails
    {
        public string ShippedDate { get; set; }
        public string EstimatedDeliveryDate { get; set; }
        public string ShippingMethod { get; set; }
    }

}
