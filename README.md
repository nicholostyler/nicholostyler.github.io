# Grand Strand Systems
by **Nicholos Tyler**

### Self Assessment
One of the first classes that helped shape my skills in data structures and algorithms is in CS-260. The projects in this course went through all the different basic types of data structures and algorithms. For instance, it goes through a project of parsing a CSV file by reading files and applying a token processing algorithm. CS-310 allowed me to showcase and learn skills on team collaboration by building a calculator app and learning about GitHub. Next, I learned skills of software engineering and database design with CS-340 where I developed skills with MongoDB and python to build and design a client that interacts with a server. Lastly, I learned the skills of communicating with stakeholders is also CS-310 as the final project was made to simulate a company’s actual plan for what they wanted in a program. 

### Code Review 
**Initial code review before enhancements, showcasing original features of program from CS-320.**

[![Code Review](https://res.cloudinary.com/marcomontalbano/image/upload/v1622760522/video_to_markdown/images/vimeo--558766356-c05b58ac6eb4c4700831b2b3070cd403.jpg)](https://vimeo.com/558766356 "Code Review")

### Introduction To Artifacts
The capstone is made up of just one artifact for all three categories. The original artifact comes from the class CS-320. The reason I chose the final project from this class is that it contains a carefully written Java application that demonstrated a skill for coding design by utilizing encapsulation and error checking. It also showcases a skill with unit testing that follows the business requirements closely and makes sure the code written is secure. Next, it showcases the skill in databases and data structures by utilizing lists and my own algorithm for determining a correct date. Lastly, the project set up the foundations for establishing a database. The classes referenced each other and utilized data structures which easily translated into database configurations.  


### Software Design and Engineering
<a href="https://github.com/nicholostyler/nicholostyler.github.io/tree/main/Software%20Design" target="_blank">external link</a>
**See the code on [GitHub](https://github.com/nicholostyler/nicholostyler.github.io/tree/main/Software%20Design)**

[link text](https://github.com/nicholostyler/nicholostyler.github.io/tree/main/Software%20Design){:target="_blank"}

The artifact is a program that has model and service classes for contacts, tasks and appointments. These service classes allow for performing CRUD operations to allow the user to manipulate their data. The artifact was mostly created to highlight security problems in code using Unit Tests. It was created for CS-320-T3228 and was created using Java as the programming language. 

I included this artifact in my portfolio because it highlights a lot of the skills of writing secure code by using exceptions and unit testing. It showcased my proficiency with software design by breaking the code into maintainable chunks through encapsulation. Skills in reusability and maintainability of code was another highlight of the artifact due to the validation being broken into methods and used in the mutator and accessor methods instead of rewriting the code. 

The artifact was improved dramatically by introducing new features such as user interaction and deeper code safety interaction. For instance, I fixed all the bugs that I highlighted in my code review such as the ID for the classes not being properly set. I improved the holes in the previous code where some spots in the task and contact model classes did not validate input. All the comments are not uniform across the whole project and are included in every method and any complex code that needed to be clarified.  

I did meet the course objectives that I planned to meet with Module One. I planned to merge the contacts to have their own tasks and appointments instead of being separate. I also managed to convert all the code into .NET and cross platform .NET Core. The other planned updates that I wanted to make for Module One made more sense to be included and worked on for the algorithms section as it involved developing a search algorithm. Instead, I created a whole new menu system to allow the user to delete, update, and create contacts, tasks, appointments. 

The process of creating and enhancing the artifact was tough and I learned a lot. I learned about how C# handles their syntax and throwing exceptions. In the class that I created the artifact for originally never covered user input and output in the console terminal. Some hurdles that I faced were trying to do too much all at once, this created timeline issues where I had trouble finishing all of it in the week. 

### Algorithms and Data Structures
**See the code on [GitHub](https://github.com/nicholostyler/nicholostyler.github.io/tree/main/Algorithms%20and%20Data%20Structure)**

The artifact is a program that has model and service classes for contacts, tasks and appointments. These service classes allow for performing CRUD operations to allow the user to manipulate their data. The artifact was mostly created to highlight security problems in code using Unit Tests. It was created for CS-320-T3228 and was created using Java as the programming language. 

I included this artifact in my portfolio because data structures are a focal point in how the tasks, appointments, and contacts are accessed. A specific component in the artifact that showcases skill of data structures is by using an ArrayList due to the smaller nature of the use cases. Another component in the original version of the artifact was the use of an algorithm to determine the date is legitimate by calculating a previous day and comparing to the current date. 
  
The artifact was improved firstly through adding a search feature to each view-model class. For instance, I have added a menu to the main program that allows the user to search by the month or any appointment by day. This search algorithm was also added for the task class and contacts class where you can find each one by the user providing a string that is contained in the corresponding class lists. Lastly, I added an algorithm for checking if a task is completed and will hide or show it depending on a user choice in the menu. 
  
I did meet specific course objectives for this milestone with regards to security and data structures and algorithms. I met the security objectives by validating the user input and catching all the exceptions that are thrown safely. The main focal point of the objectives is with algorithms and data structures which is met by the enhancements with the search features added and the task completion algorithm.
  
The process of enhancing the artifact was interesting as I learned a lot about how .NET handles dates differently than Java. This took a lot of research and helped with crafting the algorithm needed to create the search. I also learned about the performance benefits of how C# uses foreach which can be faster than a traditional for loop using a variable, which was important as I needed a variable to count each item in the list. 

### Databases
**See the code on [GitHub](https://github.com/nicholostyler/nicholostyler.github.io/tree/main/Database)**

The artifact is a program that has model and service classes for contacts, tasks and appointments. These service classes allow for performing CRUD operations to allow the user to manipulate their data. The artifact was mostly created to highlight security problems in code using Unit Tests. It was created for CS-320-T3228 and was created using Java as the programming language. 

I included this artifact because the structure of having tasks and contacts already stored in local data structures led to a perfect opportunity to use a database. Since there was not a database included in the original design of the artifact, there is not much to showcase my skills compared to the enhanced version. 

The artifact was improved firstly through the addition of a complete overhaul of the way classes handled CRUD. This was done by keeping local data structures in place and manipulated the SQLite database in the background. This allows for the user to continue using the application while it is saving in the background. For instance, when a user adds or updates a task, it will save in the background and can be used and manipulated the next time they open the app. 

I met the course objectives with this assignment as I focused on researching and executing a solution to solve the specific goal of designing and developing a database. I decided to use SQLLite and EFCore because these have security already built-in and in mind. I also demonstrated storing, manipulating, and accessing data in a database using EFCore to save, get, and updating a task and contact. 

The process of enhancing the artifact was the most difficult of the three categories. Since this project did not already have a database and was re-written in C#, I had to research how .NET Core is able to manipulate SQL. This took a lot of research with trial and error every step of the way. In the end I learned how EF Core has incredible performance and security that is used by people in the industry. 
