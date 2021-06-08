using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grand_Strand_Systems
{
    [Keyless]
    public class TaskViewModel
    {
        public List<TaskModel> Tasks { get; set; }

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
        public void Add(string name, string description, string contactID)
        {
            try
            {
                TaskModel newTask = new TaskModel(name, description, contactID);
                Tasks.Add(newTask);

                // If database has information in it, try to pull contacts from there
                using (var db = new ContactsContext())
                {
                    Console.WriteLine("Writing Task To Database");
                    
                    //contact.FirstOrDefault().Tasks.Tasks.Add(newTask);
                    //db.Entry(contact.FirstOrDefault()).Property(e => e.).IsModified = true;
                    try
                    {
                      //  db.Update(contact.FirstOrDefault());
                        db.SaveChanges();
                        

                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Failed...");
                    }
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
                Console.WriteLine(e.Message);
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

        

        

        


    }
}
