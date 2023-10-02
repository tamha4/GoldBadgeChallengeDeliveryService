
namespace GoldBadgeChallenge.Data.AddressBook
{
    public class AddressBook
    {
        public AddressBook()
        {
            
        }

        public AddressBook(int id, string name, string address, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address {get; set;}
        public string Email {get; set;}
        public string PhoneNumber {get; set;}
    }
}