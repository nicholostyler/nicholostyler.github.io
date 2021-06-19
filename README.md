# Grand Strand Systems
by **Nicholos Tyler**

### Self Assessment
One of the first classes that helped shape my skills in data structures and algorithms is in CS-260. The projects in this course went through all the different basic types of data structures and algorithms. For instance, it goes through a project of parsing a CSV file by reading files and applying a token processing algorithm. CS-310 allowed me to showcase and learn skills on team collaboration by building a calculator app and learning about GitHub. Next, I learned skills of software engineering and database design with CS-340 where I developed skills with MongoDB and python to build and design a client that interacts with a server. Lastly, I learned the skills of communicating with stakeholders is also CS-310 as the final project was made to simulate a company’s actual plan for what they wanted in a program. 

### Code Review 
**Initial code review before enhancements, showcasing original features of program from CS-320.**
**<a href="https://github.com/nicholostyler/CS-320AutomationClass" target="_blank">See the original code on GitHub</a>**

[![Code Review](https://res.cloudinary.com/marcomontalbano/image/upload/v1622760522/video_to_markdown/images/vimeo--558766356-c05b58ac6eb4c4700831b2b3070cd403.jpg)](https://vimeo.com/558766356 "Code Review")

### Introduction To Artifacts
All of the enhancements for the capstone project came from just one original artifact for all three categories. The original artifact comes from the class CS-320. The reason I chose the final project from this class is that it contains a carefully written Java application that demonstrated a skill for coding design by utilizing encapsulation and error checking. It also showcases a skill with unit testing that follows the business requirements closely and makes sure the code written is secure. Next, it showcases the skill in databases and data structures by utilizing lists and my own algorithm for determining a correct date. Lastly, the project set up the foundations for establishing a database. The classes referenced each other and utilized data structures which easily translated into database configurations.

### Software Design and Engineering
**<a href="https://github.com/nicholostyler/nicholostyler.github.io/tree/main/Software%20Design" target="_blank">See the code on GitHub</a>**

I included this artifact in my portfolio because it highlights a lot of the skills of writing secure code by using exceptions and unit testing. It showcased my proficiency with software design by breaking the code into maintainable chunks through encapsulation. Skills in reusability and maintainability of code was another highlight of the artifact due to the validation being separated into methods and used in the mutator and accessor methods instead of rewriting in the implementation. 

The artifact was improved dramatically by introducing new features such as user interaction through the console and deeper code safety interaction. I achieved user interaction by writing a console interface and adding menus that a user can add or remove contacts and tasks from. I achieved code safety by throwing exceptions and adding conditionals to check for null and incorrect values. For instance, I fixed all the bugs that I highlighted in my code review such as the ID for the classes not being properly set. I addressed the holes from the previous code where some spots in the task and contact model classes did not validate input. All the comments are now uniform across the whole project and are included in every method and any complex code that needed to be clarified.  

I planned to merge the contacts to have their own tasks and appointments instead of being separate. I also managed to convert all the code into .NET and cross platform .NET Core. The other planned updates that I wanted to make for Module One made more sense to be included and worked on for the algorithms section as it involved developing a search algorithm. Instead, I created a whole new menu system to allow the user to delete, update, and create contacts, tasks, appointments. 

The process of creating and enhancing the artifact was tough and I learned a lot. I learned about how C# handles their syntax and how it implements throwing exceptions. In CS-320, it did not cover user input and output in the console terminal. Some hurdles that I faced were trying to do too much all at once, this created timeline issues where I had trouble finishing all of it in the time alloted.

*Example of an enhancement - showcasing the addition of a interactive menu for the user.*
```
string newFirstName = string.Empty;
string newLastName = string.Empty;
string newPhoneNumber = string.Empty;
string newAddress = string.Empty;

while (true) {
    try {
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
    catch (ArgumentNullException ex) {
        Console.WriteLine("Value cannot be null, try again.");
    } catch (ArgumentException ex) {
        Console.WriteLine("Value is too long or not correct, try again");
    }
}
```

### Algorithms and Data Structures
**<a href="https://github.com/nicholostyler/nicholostyler.github.io/tree/main/Algorithms%20and%20Data%20Structure" target="_blank">See the code on GitHub</a>**

The original artifact is a program that has model and service classes for contacts, tasks and appointments. These service classes allow for performing CRUD operations to allow the user to manipulate their data. The artifact was mostly created to highlight security problems in code using Unit Tests. It was created for CS-320-T3228 and was created using Java as the programming language. 

I included this artifact in my portfolio because data structures are a focal point in how the tasks, appointments, and contacts are accessed. A specific component in the artifact that showcases skill of data structures is by using an ArrayList. I used an ArrayList due to the fewer number of items used in the code. Another component in the original version of the artifact was the use of an algorithm to determine the date is legitimate by calculating a previous day and comparing to the current date. 
  
The artifact was improved firstly through adding a search feature to each view-model class. This pairs with the console menu developed in the previous enhancement and allows for searching using built-in list search. Another example of search is I have added a menu to the main program that allows the user to search by the month or any appointment by day. This search algorithm was also added for the task class and contacts class where you can find each one by the user providing a string that is contained in the corresponding class lists. Lastly, I added an algorithm for checking if a task is completed and will hide or show it depending on a user choice in the menu. 

The process of enhancing the artifact was interesting as I learned a lot about how .NET handles dates differently than Java. This took a lot of research and helped with crafting the algorithm needed to create the search. I also learned about the performance benefits of how C# uses foreach which can be faster than a traditional for loop using a variable, which was important as I needed a variable to count each item in the list. 

*An example of an enhancement made to verify the day for leap year and which month has more or less than 30 days.* 

```
public int VerifyDay(int month, string day) {
    int verifiedDay = 0;
    int year = DateTime.Now.Year;

    // convert from string to int
    try {
        verifiedDay = Int32.Parse(day);
        switch (month) {
            // if its Feb, account for leap year.
        case 2:
            if (DateTime.IsLeapYear(year)) {
                if (verifiedDay <= 29) return verifiedDay;
            } else {
                if (verifiedDay <= 28) return verifiedDay;
            }
            break;
        case 8:
        case 3:
        case 5:
        case 10:
            if (verifiedDay <= 30) return verifiedDay;
            break;
        default:
            if (verifiedDay <= 31) return verifiedDay;
            break;

        }
    } catch (ArgumentNullException ex) {
        // Argument is null
        Console.WriteLine("Month given was null, please try again.");
        return -1;
    } catch (FormatException ex) {
        // Is not a string
        Console.WriteLine("Month given was not correct, please try again.");
        return -1;
    }

    // Everything failed
    return -1;
}
```


### Databases
**<a href="https://github.com/nicholostyler/nicholostyler.github.io/tree/main/Database" target="_blank">See the code on GitHub</a>**

The artifact is a program that has model and service classes for contacts, tasks and appointments. These service classes allow for performing CRUD operations to allow the user to manipulate their data. The artifact was mostly created to highlight security problems in code using Unit Tests. It was created for CS-320-T3228 and was created using Java as the programming language. 

I included this artifact because the structure of having tasks and contacts already stored in local data structures led to a perfect opportunity to use a database. It was a perfect opportunity to showcase 

The artifact was improved firstly through the addition of a complete overhaul of the way classes handled CRUD. This was done by keeping local data structures in place and manipulated the SQLite database in the background. EFCore is a layer above SQL that allows for simple interaction with classes. I added a migration to my ContactViewModel class that converts all the objects in that class to SQL objects. This allows for the user to continue using the application while it is saving in the background. For instance, when a user adds or updates a task, it will save in the background and can be used and manipulated the next time they open the app. 

The process of enhancing the artifact was the most difficult of the three categories. Since this project did not already have a database and was re-written in C#, I had to research how .NET Core is able to manipulate SQL. This took a lot of research with trial and error every step of the way. In the end I learned how EF Core has incredible performance and security that is used by people in the industry.

*An example of writing to the database using EFCore, also showing example of how I properly implemented code security.* 

```
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
```
