using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldBadgeChallenge.Data;
using GoldBadgeChallenge.Data.Enum;

namespace GoldBadgeChallenge.Repository
{
    public class DeliveryRepository
    {
        public DeliveryRepository()
        {
            Seed();
        }
        private readonly List<DeliveryService> _deliveryServiceDbContext = new List<DeliveryService>();
        private int _count = 0;

        //Create
        public bool AddDeliveryService(DeliveryService deliveryService){
            if(deliveryService is null){
                return false;
            }
            else
            {
                _count ++;
                deliveryService.Id = _count;
                _deliveryServiceDbContext.Add(deliveryService);
                return true;
            }
        }

        //Read ALL
        public List<DeliveryService> GetDeliveryServices(){
            return _deliveryServiceDbContext;
        }

        //Read by ID only
        public DeliveryService GetDeliveryServiceById(int deliveryServiceId){
            return _deliveryServiceDbContext.FirstOrDefault(deliveryService => deliveryService.Id == deliveryServiceId)!;
        }

        //Get List of En route Deliveries based on StatusOrder
        public List<DeliveryService> GetListOfEnRoutes(){
            return _deliveryServiceDbContext.FindAll(deliveryService => deliveryService.StatusOrder == StatusOrder.EnRoute );
        }

        //Get List of Completed Deliveries based on StatusOrder
        public List<DeliveryService> GetListOfCompletedOrders(){
            return _deliveryServiceDbContext.FindAll(deliveryService => deliveryService.StatusOrder == StatusOrder.Complete );
        }

        //Upate DeliveryService
        public bool UpdateDeliveryService(int oldDeliveryServiceId, DeliveryService newDeliveryServiceData){
            var oldDeliveryServiceData = GetDeliveryServiceById(oldDeliveryServiceId);
            if(oldDeliveryServiceData is not null)
            {
                oldDeliveryServiceData.OrderDate = newDeliveryServiceData.OrderDate;
                oldDeliveryServiceData.DeliveryDate = newDeliveryServiceData.DeliveryDate;
                oldDeliveryServiceData.StatusOrder = newDeliveryServiceData.StatusOrder;
                oldDeliveryServiceData.ItemNumber = newDeliveryServiceData.ItemNumber;
                oldDeliveryServiceData.ItemQuantity = newDeliveryServiceData.ItemQuantity;
                oldDeliveryServiceData.CustomerId = newDeliveryServiceData.CustomerId;
                return true;

            }
            return false;
        }

        public bool DeleteDeliveryService(DeliveryService deliveryService){
            return _deliveryServiceDbContext.Remove(deliveryService);
        }

        private void Seed(){
            DeliveryService ds1 = new DeliveryService("05-10-2001","05-11-2001",StatusOrder.Complete,2,5,01);
            DeliveryService ds2 = new DeliveryService("07-26-2001","07-30-2001",StatusOrder.EnRoute,12,23,02);

            AddDeliveryService(ds1);
            AddDeliveryService(ds2);
        }

    }
}