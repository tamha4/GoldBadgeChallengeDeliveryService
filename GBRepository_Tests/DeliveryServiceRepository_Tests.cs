using System.Security.Cryptography.X509Certificates;
using GoldBadgeChallenge.Data;
using GoldBadgeChallenge.Data.Enum;
using GoldBadgeChallenge.Repository;

namespace GBRepository_Tests 
{
    public class DeliveryServiceRepository_Tests {
        private DeliveryRepository _repo;
        private DeliveryService _deliveryServiceA;
        private DeliveryService _deliveryServiceB;

        public DeliveryServiceRepository_Tests()
        {
            _repo = new DeliveryRepository();

            _deliveryServiceA = new DeliveryService("05-26-2001","05-27-2001",StatusOrder.Complete,2,5,01);
            _deliveryServiceB = new DeliveryService("02-26-2001","02-30-2001",StatusOrder.EnRoute,55,65,05);

            _repo.AddDeliveryService(_deliveryServiceA);
            _repo.AddDeliveryService(_deliveryServiceB);
        }
            [Fact]
            public void TotalCount()
            {
                // act
                int expcepted = 2;
                int actual = _deliveryServiceA.CustomerId;
                // Assert
                Assert.Equal(expcepted,actual);
            
                // Then
            }

            [Fact]
            public void GetAllDeliveryService_ShouldGiveMeListOfDeliveryServices(){
                //Act
                List<DeliveryService> retrivedDeliveryService = _repo.GetDeliveryServices();

                int expceptedCount = 4;
                int actual = retrivedDeliveryService.Count;

                //Assert
                Assert.Equal(expceptedCount,actual);
            }

            [Fact]
            public void GetAllListOfEnRoutes(){
                //Act
                List<DeliveryService> retrivedEnRoutes = _repo.GetListOfEnRoutes();
                
                int expceptedCount = 2;
                int actual = retrivedEnRoutes.Count;

                //Assert
                Assert.Equal(expceptedCount,actual);
            }

            [Fact]
            public void GetAllListOfCompletedDeliveries()
            {
                //Act
                List<DeliveryService> retrivedCompeletedDeliveries = _repo.GetListOfCompletedOrders();
                
                int expceptedCount = 2;
                int actual = retrivedCompeletedDeliveries.Count;

                //Assert
                Assert.Equal(expceptedCount,actual);
            }
    }
}