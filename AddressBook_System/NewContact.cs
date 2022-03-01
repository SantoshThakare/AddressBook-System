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
                            " " + data.LastName + " " + data.Address + " " +data.City+ " " +data.PhoneNumber + " " +data.State +
                            " " + data.Zip + " " + data.Email);
                    }
                } 
            }
        }
        public static void CheckDuplicateEntry(List<ContactManager> contacts, ContactManager contactBook)
        {
            foreach (var Details in contacts)
            {
                var person = contacts.Find (e => e.FirstName.Equals(contactBook.FirstName));
                if (person != null)
                {
                    Console.WriteLine("This Contact Already Exists with same first name :" +contactBook.FirstName);
                }
                else
                {
                    Console.WriteLine("continue with other");
                }
            }
        }

    }
}

