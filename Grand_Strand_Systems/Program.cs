using System;

namespace Grand_Strand_Systems
{
    class Program
    {
        // Main contact object
        public static ContactViewModel Contacts;
        public static ContactModel SelectedContact;

        static void Main(string[] args)
        {
            // Initailze the Contacts
            Contacts = new ContactViewModel();
            SelectedContact = new ContactModel();
            DisplayMainMenu();
        }

        /// <summary>
        /// The main menu for the application to show the user choices
        /// </summary>
        private static void DisplayMainMenu()
        {
            int choice = 0;
            Console.WriteLine("\n\nMAIN MENU");
            Console.WriteLine("---------------------");
            Console.WriteLine("a - Add a new Contact");
            Console.WriteLine("Type in index of contact to delete/see tasks.");
            Console.WriteLine("---------------------\n");
            Contacts.DisplayAll();

            Console.Write("Answer -- ");
            string userChoice = Console.ReadLine();
            if (Int32.TryParse(userChoice, out choice))
            {
                SelectedContact = Contacts.Get(choice);
                SelectedContactMenu();
                return;
            }
            else
            {
                if (userChoice == "a")
                {
                    AddContactMenu();
                    DisplayMainMenu();
                }
            }
     

        }

        /// <summary>
        /// Menu to allow user to add a new contact
        /// </summary>
        private static void AddContactMenu()
        {
            string newFirstName = string.Empty;
            string newLastName = string.Empty;
            string newPhoneNumber = string.Empty;
            string newAddress = string.Empty;
        
            while (true)
            {
                try
                {
                    // Educate the user on the size limits
                    Console.Write("New contact first name -- (10 character or less limit) -- ");
                    newFirstName = Console.ReadLine();

                    Console.Write("New contact last name -- (10 character or less limit) -- ");
                    newLastName = Console.ReadLine();

                    Console.Write("New contact phone number -- (10 character limit) -- ");
                    newPhoneNumber = Console.ReadLine();

                    Console.Write("New contact address -- (30 character or less limit) -- ");
                    newAddress = Console.ReadLine();

                    // If the size is too large, it will throw an error here
                    Contacts.Add(newFirstName, newLastName, newPhoneNumber, newAddress);

                    return;
                }
                // If the exceptions are caught, loop will continue.
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Value cannot be null, try again.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Value is too long or not correct, try again");
                }
            }
        }

        /// <summary>
        /// Show a menu that allows the user to view their selected contact
        /// </summary>
        private static void SelectedContactMenu()
        {
            bool isValid = true;
            string userChoice = "";
            // variable if user decides to select a task.
            int choice = 0;

            while (isValid)
            {
                Console.WriteLine("\n\nCONTACT SELECTED MENU");
                Console.WriteLine("---------------------");
                Console.WriteLine("r - Delete Current Contact and tasks associated.");
                Console.WriteLine("a - Add a new Task.");
                Console.WriteLine("b - To go back to the main menu.");
                //Console.WriteLine("c - Show completed tasks.");
                Console.WriteLine("Get task Detail by typing in the index.");
                Console.WriteLine("---------------------\n");
                SelectedContact.Tasks.DisplayAll();

                Console.Write("Answer -- ");
                userChoice = Console.ReadLine();

                // Use typeparse to check if string is a number, if not it is a string.
                if (Int32.TryParse(userChoice, out choice))
                {
                    // Pass by reference as I will be changing the value
                    TaskModel selectedTask = SelectedContact.Tasks.Get(choice);
                    SelectedTaskMenu(ref selectedTask);
                }


                // Based on the users choice, perform an action
                switch (userChoice)
                {
                    case "r":
                        Contacts.Remove(SelectedContact);
                        isValid = false;
                        break;
                    case "a":
                        AddTaskMenu();
                        break;
                    case "b":
                        DisplayMainMenu();
                        break;
                    default:
                        Console.Write("Enter one of the menu options.");
                        break;
                }
                
            }

            DisplayMainMenu();

        }

        private static void SelectedTaskMenu(ref TaskModel selectedTask)
        {
            string userChoice = string.Empty;
            bool isValid = true;

            while (isValid)
            {

                Console.WriteLine("\nSELECTED TASK MENU");
                Console.WriteLine("---------------------");
                Console.WriteLine("n -- Update task name");
                Console.WriteLine("d -- Update task description");
                //Console.WriteLine("c -- Mark as complete");
                Console.WriteLine("r -- Remove task from list");
                Console.WriteLine("b -- Go back to previous menu");
                Console.WriteLine("---------------------\n");

                Console.Write("Answer -- ");
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "n":
                        Console.Write("Enter a new name -- ");
                        selectedTask.Name = Console.ReadLine();
                        break;
                    case "d":
                        Console.Write("Enter a new description -- ");
                        selectedTask.Description = Console.ReadLine();
                        break;
                    //case "c":
                    //    // Whatever the opposite of the current done state is.
                    //    selectedTask.Done = !selectedTask.Done;
                    //    break;
                    case "r":
                        SelectedContact.Tasks.Remove(selectedTask);
                        isValid = false;
                        break;
                    case "b":
                        isValid = false;
                        break;
                    default:
                        break;
                }
            }

        }

        /// <summary>
        /// Show a menu to allow the user to add their own task
        /// </summary>
        private static void AddTaskMenu()
        {
            string newName = string.Empty;
            string newDescription = string.Empty;

            while (true)
            {
                try
                {
                    // Educate the user on the size limits
                    Console.Write("New task name -- (20 character limit) -- ");
                    newName = Console.ReadLine();

                    Console.Write("New task description -- (50 character limit) -- ");
                    newDescription = Console.ReadLine();

                    // If the size is too large, it will throw an error here
                    SelectedContact.Tasks.Add(newName, newDescription);
                    return;
                }
                // If the exceptions are caught, loop will continue.
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Value cannot be null, try again.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Not a proper limit, try again");
                }
            }
            
        }
    }
}
