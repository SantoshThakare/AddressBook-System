using System;
using System.Collections.Generic;

namespace AddressBook_System
{
    public class NewContact
    {
        List<ContactManager> addressList = new List<ContactManager>();
        Dictionary<string, List<ContactManager>> dict = new Dictionary<string, List<ContactManager>>();
        public void AddContact(ContactManager contact)
        {
            addressList.Add(contact);
        }
        public void Display()
        {
            foreach (var contact in addressList)
            {
                Console.WriteLine(contact.FirstName + " " + contact.LastName);
                Console.WriteLine("Last Name: " + contact.LastName);
                Console.WriteLine("Address : " + contact.Address);
                Console.WriteLine("City : " + contact.City);
                Console.WriteLine("State : " + contact.State);
                Console.WriteLine("Zip : " + contact.Zip);
                Console.WriteLine("PhoneNumber : " + contact.PhoneNumber);
                Console.WriteLine("Email : " + contact.Email);
            }
        }
        public void EditContact(string name)
        {
            foreach (var contact in addressList)
            {
                if (contact.FirstName == name || contact.LastName == name)
                {
                    Console.WriteLine("What is Required to be Edited");
                }
                Console.ReadKey();
            }
        }
        public void DeleteContact(string user)
        {
            ContactManager delete = new ContactManager();
            foreach (var contact in addressList)
            {
                if (contact.FirstName == user || contact.LastName == user)
                {
                    addressList.Remove(contact);
                }

            }
        }
        public void AddUniqueContact(string nam)
        {
            foreach (var contact in addressList)
            {
                if (addressList.Contains(contact))
                {
                    string uniqueName = Console.ReadLine();
                    dict.Add(uniqueName, addressList);
                }

            }
        }
        public void DisplayUniqueContacts()
        {
            Console.WriteLine("Enter name display that contact details");
            string name = Console.ReadLine().ToLower();
            foreach (var contacts in dict)
            {
                if (contacts.Key == name)
                {
                    foreach (var data in contacts.Value)
                    {
                        Console.WriteLine("The Contact of " + data.FirstName + "Details are \n :" + data.FirstName +
                            " " + data.LastName + " " + data.Address + " " + data.City + " " + data.PhoneNumber + " " + data.State +
                            " " + data.Zip + " " + data.Email);
                    }
                }
            }
        }
        public static void CheckDuplicateEntry(List<ContactManager> contacts, ContactManager contactBook)
        {
            foreach (var Details in contacts)
            {
                var person = contacts.Find(e => e.FirstName.Equals(contactBook.FirstName));
                if (person != null)
                {
                    Console.WriteLine("This Contact Already Exists with same first name :" + contactBook.FirstName);
                }
                else
                {
                    Console.WriteLine("continue with other");
                }
            }
        }
        public void PersonInCity()
        {
            Console.WriteLine("Enter the City name to Check Persons");
            string City = Console.ReadLine();
            List<ContactManager> cityList = addressList.FindAll(e => e.City == City);
            foreach (var place in cityList)
            {
                Console.WriteLine("Found person {0} {1} in the Address Book, living in the City {2}", place.FirstName, place.LastName, place.City);
            }
        }

        public void ForState()
        {
            Console.WriteLine("Enter the State name to check Persons");
            string state = Console.ReadLine();
            List<ContactManager> stateList = addressList.FindAll(e => e.State == state);
            foreach (var sta in stateList)
            {
                Console.WriteLine("Found the name of {0} {1} in the Address Book, living in the City {2}", sta.FirstName, sta.LastName, sta.State);
            }
        }
        public void View_person_city_state()
        {
            Console.WriteLine("Enter your Choice for Searching a Person in");
            Console.WriteLine("\n1.City \n2.State");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter City Name:");
                    String City = Console.ReadLine();

                    foreach (ContactManager data in this.addressList.FindAll(e => e.City == City))
                    {
                        Console.WriteLine(data.FirstName + " " + data.LastName + " is from " + data.City);
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter State Name:");
                    String State = Console.ReadLine();

                    foreach (ContactManager data in this.addressList.FindAll(e => e.State == State))
                    {
                        Console.WriteLine(data.FirstName + " " + data.LastName + " is from " + data.State);
                    }
                    break;
            }

        }
    }
}
