using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Grand_Strand_Systems
{
    public class TaskViewModel
    {
        private List<TaskModel> Tasks { get; set; }

        public TaskViewModel()
        {
            // initalize a default List
            Tasks = new List<TaskModel>();
        }

        /// <summary>
        /// Returns the size of the tasks list
        /// </summary>
        /// <returns>Int of the tasks list size</returns>
        public int Size()
        {
            return Tasks.Count;
        }

        /// <summary>
        /// Add a new task 
        /// </summary>
        /// <param name="name">Name of the new task</param>
        /// <param name="description">Description of the task</param>
        public void Add(string name, string description)
        {
            try
            {
                TaskModel newTask = new TaskModel(name, description);
                Tasks.Add(newTask);
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
        /// RemoveTask based on its position in the list
        /// </summary>
        /// <param name="position">Position of task in list</param>
        public void Remove(int position)
        {
            // Remove a task at its position in index if position is in the index
            if (Tasks.Count <= position - 1)
            {
                Console.WriteLine("Position not in the list.");
                throw new ArgumentException();
            }

            // Subtract one as users do not count by 0
            Tasks.RemoveAt(position - 1);
        }

        /// <summary>
        /// Remove a task by passing in a task
        /// </summary>
        /// <param name="task">A TaskModel object</param>
        public void Remove(TaskModel task)
        {
            // If the Tasks list contains the task parameter, remove it.
            if (Tasks.Contains(task))
            {
                Tasks.Remove(task);
            }
            else
            {
                Console.WriteLine("This task is not in the list, try again.");
            }
        }

        /// <summary>
        /// Get a task by its index
        /// </summary>
        /// <param name="index">Index of task</param>
        /// <returns></returns>
        public TaskModel Get(int index)
        {
            // If Index - 1 greater than the count of the Tasks objects
            if (Tasks.Count < (index - 1))
            {
                Console.WriteLine("Index not found in list.");
            }

            // Use LINQ to find element at index.
            return Tasks.ElementAt(index - 1);

        }

        /// <summary>
        /// Update the name of the task
        /// </summary>
        /// <param name="position">Position of the task</param>
        /// <param name="name">New name for the task</param>
        public void UpdateName(int position, string name)
        {
            // Check if position is in the list
            if (Tasks.Count <= position)
            {
                Console.WriteLine("Position given is not in the list.");
                throw new ArgumentException();
            }

            try
            {
                Tasks[position - 1].Name = name;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Name given is null, please try again.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument is not valid, please try again.");
            }
        }

        /// <summary>
        /// Update the task's description
        /// </summary>
        /// <param name="position">Position of the task</param>
        /// <param name="description">The new description for the task</param>
        public void UpdateDesciption(int position, string description)
        {
            // Check if position is in the list.
            if (Tasks.Count <= position)
            {
                Console.WriteLine("Position given is not in the list.");
                throw new ArgumentException();
            }

            // Try to update the task description, it will throw exceptions if input is not valid.
            try
            {
                Tasks[position - 1].Description = description;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Name given is null, please try again.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument is not valid, please try again.");
            }
        }

        public List<TaskModel> Search(string query)
        {
            List<TaskModel> queryList = new List<TaskModel>();

            foreach(TaskModel task in Tasks)
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
        public void Display(List<TaskModel> tasks)
        {
            int loopCount = 0;
            // Loop through the tasks
            foreach (TaskModel task in tasks)
            {
                Console.WriteLine($"\n{loopCount} : {task.Name} -- {task.Description}");
            }
        }

        /// <summary>
        /// Display all of the tasks in the list.
        /// </summary>
        /// <param name="showCompleted">A boolean value if you want to view the completed items</param>
        public void DisplayAll(bool showCompleted)
        {
            // Write out if the contact list is empty
            if (Tasks.Count == 0)
            {
                Console.WriteLine("Task List is empty -- Try adding a task.");
            }

            // Counter to show index
            int loopCount = 0;

            Console.WriteLine("\nTASKS");
            // Loop through the tasks
            foreach (TaskModel task in Tasks)
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


    }
}
