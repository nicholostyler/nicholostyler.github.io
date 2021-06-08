using System;
using System.Collections.Generic;
using System.Text;

namespace Grand_Strand_Systems
{
    public class ContactViewModel
    {
        private List<ContactModel> Contacts;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ContactViewModel()
        {
            // Init a default list 
            Contacts = new List<ContactModel>();
        }

        /// <summary>
        /// Get the size of the contacts
        /// </summary>
        /// <returns>An int of the size of the contacts</returns>
        public int Size()
        {
            return Contacts.Count;
        }

        /// <summary>
        /// Retrieve an appointment from the list by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ContactModel Get(int index)
        {
            // Loop through contacts
            foreach(ContactModel model in Contacts)
            {
                // If looped model matches the passed in index
                if (Contacts[index - 1] == model)
                {
                    return model;
                }
            }
            
            // If a contact is not found
            Console.WriteLine("No Contact found at that index.");
            return null;
        }


        /// <summary>
        /// Add a new contact to the list
        /// </summary>
        /// <param name="first">First name of contact</param>
        /// <param name="last">Last name of contact</param>
        /// <param name="phone">Phone number of contact</param>
        /// <param name="address">Address of contact</param>
        public void Add(string first, string last, string phone, string address)
        {
            try
            {
                // Create a new instance of Contact using variables
                ContactModel newContact = new ContactModel(first, last, phone, address);
                Contacts.Add(newContact);
            }
            // Value is null
            catch (NullReferenceException e)
            {
                Console.WriteLine("Value is null, try again.");
            }
            // Value is a generic argument exception
            catch (ArgumentException e)
            {
                Console.WriteLine("Argument passed is not valid, try again.");
            }
        }
        
        /// <summary>
        /// Remove contact from the list by position
        /// </summary>
        /// <param name="position">Position of contact in list</param>
        public void Remove(int position)
        {
            // Remove a contact at its position in index if position is in the index
            if (Contacts.Count <= position)
            {
                Console.WriteLine("Position not in the list.");
                throw new ArgumentException();
            }

            // Subtract one as users do not count by 0
            Contacts.RemoveAt(position - 1);
        }

        /// <summary>
        /// Remove an appointment by passing in its object
        /// </summary>
        /// <param name="contact">Appointment Model object</param>
        public void Remove(ContactModel contact)
        {
            // If the Contacts list contains the contact parameter, remove it.
            if (Contacts.Contains(contact))
            {
                Contacts.Remove(contact);
            }
            else
            {
                Console.WriteLine("This contact is not in the list, try again.");
            }
        }

        public void Update(int index, string first = "optional", string last = "optional", string phone = "optional", string address = "optional")
        {
            index = index - 1;

            if (Contacts.Count <= index)
            {
                throw new ArgumentException();
            }

            if (!string.IsNullOrEmpty(first) && !last.Equals("optional"))
            {
                Contacts[index].FirstName = first;
            }

            if (!string.IsNullOrEmpty(last) && !last.Equals("optional"))
            {
                Contacts[index].LastName = last;
            }

            if (!string.IsNullOrEmpty(phone) && !phone.Equals("optional"))
            {
                Contacts[index].PhoneNumber = phone;
            }

            if (!string.IsNullOrEmpty(address) && !address.Equals("optional"))
            {
                Contacts[index].Address = address;
            }
        }

        /// <summary>
        /// Search for a contact by first or last name
        /// </summary>
        /// <param name="name">A string with the query of first or last name.</param>
        /// <returns></returns>
        public List<ContactModel> SearchName(string name)
        {
            List<ContactModel> queryList = new List<ContactModel>();

            foreach (ContactModel contact in Contacts)
            {
                if (contact.FirstName.Contains(name) || contact.LastName.Contains(name))
                {
                    queryList.Add(contact);
                }
            }

            if (queryList.Count == 0)
            {
                Console.WriteLine("\nThere are no items that match the search query.");
            }
            return queryList;
        }

        /// <summary>
        /// Search for a contact by phone number
        /// </summary>
        /// <param name="name">A string with the query of phone number</param>
        /// <returns></returns>
        public List<ContactModel> SearchPhone(string phoneNumber)
        {
            List<ContactModel> queryList = new List<ContactModel>();

            foreach (ContactModel contact in Contacts)
            {
                if (contact.PhoneNumber.Contains(phoneNumber))
                {
                    queryList.Add(contact);
                }
            }

            if (queryList.Count == 0)
            {
                Console.WriteLine("\nThere are no items that match the search query.");
            }
            return queryList;
        }

        /// <summary>
        /// Search for a contact by address
        /// </summary>
        /// <param name="name">A string with the query of address</param>
        /// <returns></returns>
        public List<ContactModel> SearchAddress(string address)
        {
            List<ContactModel> queryList = new List<ContactModel>();

            foreach (ContactModel contact in Contacts)
            {
                if (contact.Address.Contains(address))
                {
                    queryList.Add(contact);
                }
            }

            if (queryList.Count == 0)
            {
                Console.WriteLine("\nThere are no items that match the search query.");
            }
            return queryList;
        }


        /// <summary>
        /// Display all of the appointments
        /// </summary>
        public void DisplayAll()
        {
            // Write out if the contact list is empty
            if (Contacts.Count == 0)
            {
                Console.WriteLine("Contact List is empty -- Try adding a contact.");
            }

            // Counter to show index
            int loopCount = 0;
            
            // Loop through the contacts
            foreach(ContactModel model in Contacts)
            {
                // iterate the loopcount and show the model and index
                loopCount++;
                Console.WriteLine($"\n{loopCount} -- {model.FirstName} {model.LastName}");
            }
        }

        public void Display(List<ContactModel> contacts)
        {
            // Write out if the contact list is empty
            if (Contacts.Count == 0)
            {
                Console.WriteLine("Search query List is empty -- try again.");
            }

            // Counter to show index
            int loopCount = 0;

            // Loop through the contacts
            foreach (ContactModel model in Contacts)
            {
                // iterate the loopcount and show the model and index
                loopCount++;
                Console.WriteLine($"\n{loopCount} -- {model.FirstName} {model.LastName}");
            }
        }
    }
}
