
using GoldBadgeChallenge.Data.Enum;

namespace GoldBadgeChallenge.Data
{
    public class DeliveryService
    {
        public DeliveryService(){}

        public DeliveryService(string orderDate, string deliveryDate, StatusOrder statusOrder, int itemNumber, int itemQuantity, int customerId )
        {
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            StatusOrder = statusOrder;
            ItemNumber = itemNumber;
            ItemQuantity = itemQuantity;
            CustomerId = customerId;
        }
        public int Id {get; set;}
        public string OrderDate {get; set;}
        public string DeliveryDate { get; set; }
        public StatusOrder StatusOrder {get; set;}
        public int ItemNumber {get; set;} = 100;
        public int ItemQuantity { get; set; } = 100;
        public int CustomerId { get; set; }
    }
}