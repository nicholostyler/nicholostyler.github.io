using System;
using System.Collections.Generic;
using System.Text;

namespace Grand_Strand_Systems
{
    public class TaskModel
    {
        //Properties
        private string _name;
        private string _description;
        public string ID { get; private set; }
        public bool Done { get; set; }
        public string Name {
            get
            {
                return _name;
            }

            set
            {
                // Validate that the value is less than 20 and is not null
                if (value.Length <= 20)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        _name = value;
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
                else
                {
                    // Throw an an exception if value is greater than 20
                    throw new ArgumentException();
                }
                
                
            }
        }
        public string Description 
        {
            get
            {
                return _description;
            }
            set
            {
                // Validate that the value is less than 20 and is not null
                if (value.Length <= 50)
                {
                    // If value is not null of empty
                    if (!string.IsNullOrEmpty(value))
                    {
                        _description = value;
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
                
            }
        }

        public TaskModel(string name, string description)
        {
            // Create a unique ID per task and set the values to paramters
            ID = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
        }

        // Empty Constructor
        public TaskModel() { }
    }
}
