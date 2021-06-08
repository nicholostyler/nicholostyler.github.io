using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Grand_Strand_Systems
{
    public class ContactViewModel
    {
        public List<ContactModel> Contacts;
        public ContactModel SelectedContact;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ContactViewModel()
        {
            // Init a default list 
            Contacts = new List<ContactModel>();
            SelectedContact = new ContactModel();
            // If database has information in it, try to pull contacts from there
            using (var db = new ContactsContext())
            {
                Console.WriteLine("Getting contacts from database...");
                foreach (var contact in db.Contacts)
                {
                    Contacts.Add(contact);
                    foreach (var task in db.Tasks)
                    {
                        if (contact.ID == task.ContactID)
                        {
                            contact.Tasks.Add(task);
                        }
                    }

                }
            }
        }

        public void AddTask(TaskModel task)
        {
            using (var db = new ContactsContext())
            {
                Console.WriteLine("Writing Task to database...");
                db.Tasks.Add(task);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Update the task name in the database.
        /// </summary>
        /// <param name="task"></param>
        public void UpdateName(TaskModel task)
        {
            using (var db = new ContactsContext())
            {
                db.Tasks.Update(task);
                Console.WriteLine("Update Task in database...");
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Update the task description in the database.
        /// </summary>
        /// <param name="task">TaskModel task</param>
        public void UpdateDescription(TaskModel task)
        {
            using (var db = new ContactsContext())
            {
                Console.WriteLine("Update Task in database...");
                db.Tasks.Add(task);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Remove a task by passing in a task
        /// </summary>
        /// <param name="task">A TaskModel object</param>
        public void RemoveTask(TaskModel task)
        {
            int contactIndex = Contacts.IndexOf(SelectedContact);
            // If the Tasks list contains the task parameter, remove it.
            if (Contacts[contactIndex].Tasks.Contains(task))
            {
                Contacts[contactIndex].Tasks.Remove(task);
            }
            else
            {
                Console.WriteLine("This task is not in the list, try again.");
            }

            // Find the task in database, then remove it
            using (var db = new ContactsContext())
            {
                Console.WriteLine("Removing task from database...");

                var selectedTask = db.Tasks.Select(t => task).FirstOrDefault();
                    
                db.Tasks.Remove(selectedTask);
                //db.Update(existingContact);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Display all of the tasks in the list.
        /// </summary>
        /// <param name="showCompleted">A boolean value if you want to view the completed items</param>
        public void DisplayAllTasks(bool showCompleted)
        {
            // Write out if the contact list is empty
            if (SelectedContact.Tasks.Count == 0)
            {
                Console.WriteLine("Task List is empty -- Try adding a task.");
            }

            // Counter to show index
            int loopCount = 0;

            Console.WriteLine("\nTASKS");
            // Loop through the tasks
            foreach (TaskModel task in SelectedContact.Tasks)
            {
                // iterate the loopcount and show the model and index
                loopCount++;
                if (showCompleted)
                {
                    if (task.Done)
                    {
                        Console.WriteLine($"\n{loopCount} completed : {task.Name} -- {task.Description}");
                    }
                }
                else
                {
                    Console.WriteLine($"\n{loopCount} : {task.Name} -- {task.Description}");
                }
            }
        }

        /// <summary>
        /// Get a task by its index
        /// </summary>
        /// <param name="index">Index of task</param>
        /// <returns></returns>
        public TaskModel GetTask(int index)
        {
            // If Index - 1 greater than the count of the Tasks objects
            if (SelectedContact.Tasks.Count < (index - 1))
            {
                Console.WriteLine("Index not found in list.");
            }

            // Use LINQ to find element at index.
            return SelectedContact.Tasks.ElementAt(index - 1);

        }

        public List<TaskModel> SearchTask(string query)
        {
            List<TaskModel> queryList = new List<TaskModel>();

            foreach (TaskModel task in SelectedContact.Tasks)
            {
                if (task.Name.Contains(query) || task.Description.Contains(query))
                {
                    queryList.Add(task);
                }
            }

            if (queryList.Count == 0)
            {
                Console.WriteLine("\nThere are no items that match the search query.");
            }
            return queryList;
        }

        /// <summary>
        /// Display only 
        /// </summary>
        /// <param name="tasks"></param>
        public void DisplayTasks(List<TaskModel> tasks)
        {
            int loopCount = 0;
            // Loop through the tasks
            foreach (TaskModel task in tasks)
            {
                Console.WriteLine($"\n{loopCount} : {task.Name} -- {task.Description}");
            }
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

                using (var db = new ContactsContext())
                {
                    // Save to the database
                    Console.WriteLine("Save to the database");
                    db.Add(newContact);
                    db.SaveChanges();
                }
                
                
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

            ContactModel toRemove = Contacts[position - 1];
            // Subtract one as users do not count by 0
            Contacts.Remove(toRemove);
            
            // Remove and save the database
            using (var db = new ContactsContext())
            {
                Console.WriteLine("Deleting from database...");
                db.Remove(toRemove);
                db.SaveChanges();
            }
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
                return;
            }

            // Remove and save the database
            using (var db = new ContactsContext())
            {
                Console.WriteLine("Deleting from database...");
                db.Remove(contact);
                db.SaveChanges();
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


            var updateContact = Contacts[index];


            // Update the database
            using (var db = new ContactsContext())
            {
                db.SaveChanges();
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
                if (contact.FirstName.ToLower().Contains(name.ToLower()) || contact.LastName.ToLower().Contains(name.ToLower()))
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
