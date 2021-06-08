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
            Console.WriteLine("a - Add a new contact");
            Console.WriteLine("s - Search for a contact by query");
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
                else if (userChoice == "s")
                {
                    SearchContactMenu();
                }
            }
        }

        public static void SearchContactMenu()
        {
            string userChoice = string.Empty;
            string userQuery = string.Empty;
            bool userContinue = true;

            while (userContinue)
            {
                Console.WriteLine("\n\nSearch MENU");
                Console.WriteLine("---------------------");
                Console.WriteLine("1 - Search by first or last name");
                Console.WriteLine("2 - Search by phone number");
                Console.WriteLine("3 - Search by Address");
                Console.WriteLine("b - Go back to the previous menu");
                Console.WriteLine("---------------------\n");

            }

            Console.Write("Answer -- ");
            userChoice = Console.ReadLine();

            if (string.IsNullOrEmpty(userChoice)) userContinue = false;

            switch (userChoice)
            {
                case "1":
                    Console.Write("Search query -- ");
                    userQuery = Console.ReadLine();
                    Contacts.Display(Contacts.SearchName(userQuery));
                    break;
                case "2":
                    Console.Write("Search query -- ");
                    userQuery = Console.ReadLine();
                    Contacts.Display(Contacts.SearchPhone(userQuery));
                    break;
                case "3":
                    Console.Write("Search query -- ");
                    userQuery = Console.ReadLine();
                    Contacts.Display(Contacts.SearchAddress(userQuery));
                    break;
                case "b":
                    userContinue = false;
                    break;
                default:
                    break;
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

            Contacts.Add("Nick", "Tyler", "3012472642", "asdf");
            return;
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
                Console.WriteLine("p - Add a new appointment");
                Console.WriteLine("b - To go back to the main menu.");
                Console.WriteLine("c - Show completed tasks.");
                Console.WriteLine("as - Search for a task by query");
                Console.WriteLine("ps - Search for an appointment by query");
                Console.WriteLine("Get task Detail by typing in the index.");
                Console.WriteLine("---------------------\n");
                SelectedContact.Tasks.DisplayAll(false);

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
                    case "c":
                        SelectedContact.Tasks.DisplayAll(true);
                        break;
                    case "p":
                        AddAppointmentMenu();
                        break;
                    case "as":
                        SearchTaskMenu();
                        break;
                    case "ps":
                        SearchAppointmentMenu();
                        break;
                    default:
                        Console.Write("Enter one of the menu options.");
                        break;
                }
                
            }

            DisplayMainMenu();

        }

        private static void SearchAppointmentMenu()
        {
            string keyword = string.Empty;
            string choice = string.Empty;

            Console.Write("\nEnter in m to search by month and d to search by day");
            choice = Console.ReadLine();

            if (choice == "m")
            {
                Console.Write("\nEnter in keyword to search -- ");
                keyword = Console.ReadLine();
                SelectedContact.Appointments.Display(SelectedContact.Appointments.Search(keyword, true));

            }
            else if (choice == "d")
            {
                Console.Write("\nEnter in keyword to search -- ");
                keyword = Console.ReadLine();
            }

            if (string.IsNullOrEmpty(keyword)) return;

        }

        private static void SearchTaskMenu()
        {
            string keyword = string.Empty;
            Console.Write("\nEnter in keyword to search -- ");
            keyword = Console.ReadLine();

            if (string.IsNullOrEmpty(keyword)) return;

            SelectedContact.Tasks.Display(SelectedContact.Tasks.Search(keyword));
        }

        /// <summary>
        /// Menu for adding a new appointment
        /// </summary>
        private static void AddAppointmentMenu()
        {
            string userDescription = string.Empty;
            string userDay = string.Empty;
            string userMonth = string.Empty;
            DateTime completeDate;

            // int variables
            int day, month = 0;

            // Loop  in case user fails
            while (true)
            {
                // Use try because these methods throw exceptions
                try
                {
                    // Verify all of the months, description, and day.
                    Console.Write("\nDescription -- ");
                    userDescription = Console.ReadLine();

                    Console.Write("\nMonth -- ");
                    userMonth = Console.ReadLine();
                    month = SelectedContact.Appointments.VerifyMonth(userMonth);

                    Console.Write("\nDay -- ");
                    userDay = Console.ReadLine();
                    day = SelectedContact.Appointments.VerifyDay(month, userDay);


                    // Year will default to current year.
                    completeDate = new DateTime(DateTime.Now.Year, month, day);
                    Console.WriteLine($"Successful. Your appointment is for -- {completeDate.Day}/{completeDate.Month}/{completeDate.Year}");
                    return;
                }
                catch (ArgumentNullException ex)
                {
                    // Already printed in appointment model, this is to catch it
                }
                catch (FormatException ex)
                {
                    // Already printed in appointment model, this is to catch it
                }
            }
        }

        /// <summary>
        /// Menu for the when you select a task
        /// </summary>
        /// <param name="selectedTask"></param>
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
                Console.WriteLine("c -- Mark as complete");
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
                    case "c":
                        // Whatever the opposite of the current done state is.
                        selectedTask.Done = !selectedTask.Done;
                        break;
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
