using GoldBadgeChallenge.Data;
using GoldBadgeChallenge.Data.Enum;
using GoldBadgeChallenge.Repository;
using static System.Console;

namespace GoldBadgeChallenge.UI
{
    public class ProgramUI
    {
        private readonly DeliveryRepository _DeliveryServiceRepo = new DeliveryRepository();
        public void Run(){
            RunApplication();
        }

        private void RunApplication(){
            bool IsRunning = true;
            while(IsRunning){
                Clear();
                WriteLine("Welcome to Delivery Service \n"+
                          "1. Add Delivery Service\n"+
                          "2. List All En Route Deliveries\n"+
                          "3. List All Completed Deliveries\n"+
                          "4. Update Delivery Status\n"+
                          "5. Cancel a Delivery\n"+
                          "6. List all Delivery Service\n"+
                          "0. Exist!!\n");
                int userInput = int.Parse(ReadLine()!);
                switch(userInput){
                    case 1:
                    AddDeliveryService();
                    break;

                    case 2:
                    ListAllEnRoutes();
                    break;

                    case 3:
                    ListAllCompleteDeliveries();
                    break;

                    case 4:
                    UpdateDeliveryStatus();
                    break;

                    case 5:
                    DeleteDelivery();
                    break;

                    case 6:
                    ListAllDeliveryService();
                    break;

                    case 0:
                    IsRunning = CloseApplication();
                    break;

                    default:
                    WriteLine("Invalid Selections, Press any keys to continue");
                    PressAnyKey();
                    break;
                }
            }
        }

        private void ListAllDeliveryService()
        {
            Clear();
            if(_DeliveryServiceRepo.GetDeliveryServices().Count() > 0){
                Clear();
                DisplayDeliveryService();
            }
            else{
                WriteLine("Sorry, there is no List of Delivery Service");
            }
            PressAnyKey();
        }

        private void DisplayDeliveryService()
        {
            foreach(var deliveryService in _DeliveryServiceRepo.GetDeliveryServices()){
                DisplayDeliveryServiceInfo(deliveryService);
            }
        }

        private void DisplayDeliveryServiceInfo(DeliveryService deliveryService)
        {
            WriteLine($"deliveryService Id: {deliveryService.Id}\n"+
                      $"OrderDate: {deliveryService.OrderDate}\n"+
                      $"DeliveryDate: {deliveryService.DeliveryDate}\n"+
                      $"OrderStatus: {deliveryService.StatusOrder}\n"+
                      $"ItemNumber: {deliveryService.ItemNumber}\n"+
                      $"ItemQuantity: {deliveryService.ItemQuantity}\n"+
                      $"CustomerId: {deliveryService.CustomerId}\n");
        }

        private void AddDeliveryService()
        {
            Clear();
            DeliveryService deliveryServiceForm = PopularDeliveryServiceData();
            if(_DeliveryServiceRepo.AddDeliveryService(deliveryServiceForm)){
                WriteLine("Success");
            }
            else
            {
                WriteLine("Fails!");
            }
            PressAnyKey();
        }

        private DeliveryService PopularDeliveryServiceData()
        {
            DeliveryService deliveryServiceData = new DeliveryService();
            Write("Please Enter Date Order(mm-dd-yyyy): \n");
            deliveryServiceData.OrderDate = ReadLine()!;

            Write("Please enter Delivery Date(mm-dd-yyyy): \n");
            deliveryServiceData.DeliveryDate = ReadLine()!;

            Write("Please enter the Status Order: \n"+
                  "1. Scheduled \n"+
                  "2. EnRoute \n"+
                  "3. Complete \n"+
                  "4. Canceled\n");
            int initialValue = int.Parse(ReadLine()!);
            StatusOrder selectedStatusOrder = (StatusOrder)initialValue;
            deliveryServiceData.StatusOrder = selectedStatusOrder;

            Write("Please enter the number of Items: \n");
            deliveryServiceData.ItemNumber = int.Parse(ReadLine()!);

            Write("Please enter the number of Quantity: \n");
            deliveryServiceData.ItemQuantity = int.Parse(ReadLine()!);

            Write("Please enter Customer Id: \n");
            deliveryServiceData.CustomerId = int.Parse(ReadLine()!);
            return deliveryServiceData;

        }

        private void ListAllEnRoutes()
        {
            Clear();
            List<DeliveryService> enRoutesDeliveries = _DeliveryServiceRepo.GetListOfEnRoutes();
            WriteLine("List of En Routes");
            foreach(var deliveryService in enRoutesDeliveries )
            {
                WriteLine($"deliveryService Id: {deliveryService.Id}\n"+
                          $"OrderDate: {deliveryService.OrderDate}\n"+
                          $"DeliveryDate: {deliveryService.DeliveryDate}\n"+
                          $"OrderStatus: {deliveryService.StatusOrder}\n"+
                          $"ItemNumber: {deliveryService.ItemNumber}\n"+
                          $"ItemQuantity: {deliveryService.ItemQuantity}\n"+
                          $"CustomerId: {deliveryService.CustomerId}\n"+
                          "====================================================");
            }   
            PressAnyKey();
       
        }

        private void ListAllCompleteDeliveries()
        {
            Clear();
            List<DeliveryService> completedDeliveries = _DeliveryServiceRepo.GetListOfCompletedOrders();
            WriteLine("List of Completed Deliveries");
            foreach(var deliveryService in completedDeliveries )
            {
                WriteLine($"deliveryService Id: {deliveryService.Id}\n"+
                          $"OrderDate: {deliveryService.OrderDate}\n"+
                          $"DeliveryDate: {deliveryService.DeliveryDate}\n"+
                          $"OrderStatus: {deliveryService.StatusOrder}\n"+
                          $"ItemNumber: {deliveryService.ItemNumber}\n"+
                          $"ItemQuantity: {deliveryService.ItemQuantity}\n"+
                          $"CustomerId: {deliveryService.CustomerId}\n"+
                          "====================================================");
            }   
            PressAnyKey();
        }

        private void UpdateDeliveryStatus()
        {
            Clear();
            foreach(var deliveryService in _DeliveryServiceRepo.GetDeliveryServices()){
                WriteLine($"Id: {deliveryService.Id} -- OrderDate: {deliveryService.OrderDate}\n");
            }
            WriteLine("Please select a delivery service by Id: ");
            int deliveryServiceId = int.Parse(ReadLine()!);

            DeliveryService deliveryServiceInDatabase = _DeliveryServiceRepo.GetDeliveryServiceById(deliveryServiceId);

            if(deliveryServiceInDatabase is not null){
                DeliveryService newDeliveryServiceData = PopularDeliveryServiceData();
                
                if(_DeliveryServiceRepo.UpdateDeliveryService((deliveryServiceInDatabase.Id), newDeliveryServiceData)){
                    WriteLine("Success!");
                }
                else
                {
                    WriteLine("Fails!");
                }
            }else{
                WriteLine("Sorry, no delivery service avilable");
            }
            PressAnyKey();
        }

        private void DeleteDelivery()
        {
            Clear();
            if(_DeliveryServiceRepo.GetDeliveryServices().Count() > 0){
                foreach(var deliveryService in _DeliveryServiceRepo.GetDeliveryServices()){
                    WriteLine($"Id: {deliveryService.Id} -- OrderDate: {deliveryService.OrderDate}\n");
                }
                WriteLine("Please select a delivery service by Id: ");
                int deliveryServiceId = int.Parse(ReadLine()!);

                DeliveryService deliveryServiceInDatabase = _DeliveryServiceRepo.GetDeliveryServiceById(deliveryServiceId);

                if(deliveryServiceInDatabase is not null){
                    if(_DeliveryServiceRepo.DeleteDeliveryService(deliveryServiceInDatabase)){
                        WriteLine("Success");
                    }else
                    {
                        WriteLine("Fails");
                    }
                }else{
                    WriteLine("sorry, no delivery service avilable");
                }
            }else{
                WriteLine("Sorry, no delivery service avilable at the moment!");
            }
            PressAnyKey();
            
        }

        private bool CloseApplication()
        {
            WriteLine("Thanks for using Devliery Service");
            Clear();
            PressAnyKey();
            return false;
        }

        private void PressAnyKey()
        {
            WriteLine("Press any Key to contiune");
            ReadLine();
        }
    }
}