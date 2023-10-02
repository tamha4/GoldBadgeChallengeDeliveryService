using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using GoldBadgeChallenge.Data.AddressBook;

namespace GoldBadgeChallenge.Repository.AddressBookRepository
{
    public class AddressBookRepository
    {
        private Dictionary<int, AddressBook> _addressBookInContext = new Dictionary<int, AddressBook>();
        int _count = 0;

        //Create

        public bool AddAddressBook(AddressBook addressBook){
            if(addressBook != null){
                return false;
            }
            else
            {
                _count++;
                addressBook.Id = _count;
                _addressBookInContext.Add(addressBook.Id, addressBook);
                return true;
            }
        }

        // List all address books
        public List<AddressBook> GetAddressBook(){
            return new List<AddressBook>(_addressBookInContext.Values).ToList();
        }

        //* List Adress book by ID
        public List<AddressBook> GetAddressBookById(int id){
            return _addressBookInContext.Values.Where(addressBook => addressBook.Id == id).ToList();
        }


        // Get address book by name
        public List<AddressBook> GetAddressBooksByName(string name){
            return _addressBookInContext.Values.Where(addresBook => addresBook.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // update address book by Id
        public bool UpdateAddressBookById(int id, AddressBook NewAddressBook){
            if(_addressBookInContext.ContainsKey(id)){
                NewAddressBook.Id = id;
                _addressBookInContext[id] = NewAddressBook;
                return true;
            }
            return false;
        }

        public bool DeleteAddressBookById(int id){
            if(_addressBookInContext.ContainsKey(id)){
                _addressBookInContext.Remove(id);
                return true;
            }
            return false;
        }

    }
}