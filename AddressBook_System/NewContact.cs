using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

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
        public void CityCount()
        {
            Console.WriteLine("Enter the city name to check its count : ");
            string city = Console.ReadLine();
            List<ContactManager> cityList = addressList.FindAll(e => e.City == city);
            Console.WriteLine("The Number of contact persons in the city {0} are {1}", city, cityList.Count());
        }
        public void StateCount()
        {
            Console.WriteLine("Enter the state name to check its count : ");
            string state = Console.ReadLine();
            List<ContactManager> stateList = addressList.FindAll(e => e.State == state);
            Console.WriteLine("The number of contact persons in the state {0} are {1}", state, stateList.Count());
        }
        public void AddressBookSorting()
        {
            Console.WriteLine("Enter the Address Book name that you want to sort : ");
            string addressBookName = Console.ReadLine();
            if (dict.ContainsKey(addressBookName))
            {
                dict[addressBookName].Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
                Console.WriteLine("After Sorting alphabetically, The Address Book is arranged as : ");
                Display();
            }
            else
            {
                Console.WriteLine("The {0} Addressbook does not exist. Please Enter a Valid Addressbook Name. ", addressBookName);
            }
        }
        public void Sorting()
        {
            Console.WriteLine("Enter the Address Book name that you want to sort : ");
            string addressBookName = Console.ReadLine();
            Console.WriteLine("How do you want the Sort the Addressbook : \n 1. Sort based on City \n 2. Sort based on State \n 3. Sort based on Zip");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    dict[addressBookName].Sort((x, y) => x.City.CompareTo(y.City));
                    Console.WriteLine("After Sorting alphabetically, The Address Book is arranged as : ");
                    Display();
                    break;
                case 2:
                    dict[addressBookName].Sort((x, y) => x.State.CompareTo(y.State));
                    Console.WriteLine("After Sorting alphabetically, The Address Book is arranged as : ");
                    Display();
                    break;
                case 3:
                    dict[addressBookName].Sort((x, y) => x.Zip.CompareTo(y.Zip));
                    Console.WriteLine("After Sorting alphabetically, The Address Book is arranged as : ");
                    Display();
                    break;
            }
        }
        public void ReadFile()
        {
            Console.WriteLine("The Contact details in the file after reading : \n ");
            string filePath = @"E:\VSCode\BasicProgram\AddressBook-System\AddressBook_System\TextFile1.txt";
            string text = File.ReadAllText(filePath);
            Console.WriteLine(text);
        }
        public void WritingUsingStreamWriter()
        {
            Console.WriteLine("\n The Contact details in the file after writing : ");
            String filePath = @"E:\VSCode\BasicProgram\AddressBook-System\AddressBook_System\TextFile1.txt";
            StreamWriter writer = File.AppendText(filePath);
            writer.WriteLine("\nAlternative Number : 98343980285");
            writer.Close();
            Console.WriteLine(File.ReadAllText(filePath));
        }
        public void ImplementAddressBookinCsv()
        {
            string importFilePath = (@"E:\VSCode\BasicProgram\AddressBook-System\AddressBook_System\info.csv");
            string exportFilePath = (@"E:\VSCode\BasicProgram\AddressBook-System\AddressBook_System\export.csv");
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                var records = csv.GetRecords<ContactManager>().ToList();

                foreach (var addressData in records)
                {
                    Console.Write("\t" + addressData.FirstName + "\t" + addressData.LastName + "\t" +
                       addressData.Address + "\t" + addressData.City + "\t" + addressData.State + "\t" +
                       addressData.Zip + "\t" + addressData.PhoneNumber + "\t" + addressData.Email);

                }

                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.CurrentCulture))
                {
                    csvExport.WriteRecords(records);

                }
            }
        }
        public  void ImplementAddressBookinJson()
        {
            string importFilePath = @"E:\VSCode\BasicProgram\AddressBook-System\AddressBook_System\info1.json";
            string exportFilePath = @"E:\VSCode\BasicProgram\AddressBook-System\AddressBook_System\Export.json";

             StreamReader reader = new StreamReader(importFilePath);
            var json = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject<List<ContactManager>>(json);
            foreach (var addressData in data)
            {
                Console.Write("\t" + addressData.FirstName + "\t" + addressData.LastName + "\t" +
                   addressData.Address + "\t" + addressData.City + "\t" + addressData.State + "\t" + addressData.Zip);
            }
            JsonSerializer serializer = new JsonSerializer();
            {
                 StreamWriter sw = new StreamWriter(exportFilePath);
                 JsonWriter writer = new JsonTextWriter(sw);
                  serializer.Serialize(writer, data);
            }
        }
    }

}


