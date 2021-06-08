using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Grand_Strand_Systems
{
    public class ContactModel
    {
        // Properties
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _phoneNumber;

        public string ID { get; private set; }

        public string FirstName 
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (ValidateName(value))
                {
                    _firstName = value;
                }
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (ValidateName(value))
                {
                    _lastName = value;
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }

            set
            {
                // Validate that the value is less than 20 and is not null
                if (value.Length == 10)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        _phoneNumber = value;
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
                else
                {
                    // Throw an an exception if value is not 10
                    throw new ArgumentException();
                }
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                // Validate that the value is less than 20 and is not null
                if (value.Length <= 30)
                {
                    // Validate that the value is not null or empty
                    if (!string.IsNullOrEmpty(value))
                    {
                        _address = value;
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
                else
                {
                    // Throw an an exception if value is not 10
                    throw new ArgumentException();
                }
            }
        }
        
        public List<TaskModel> Tasks { get; set; }
        public AppointmentViewModel Appointments { get; set; }

        public ContactModel(string firstName, string lastName, string phoneNumber, string address)
        {
            // Initialize variables with default values
            // Not used for SQL 

            // Create a unique ID per task and set the values to paramters
            ID = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            Tasks = new List<TaskModel>();
            Appointments = new AppointmentViewModel();
        }

        // Used to initalize a default contact before selecting
        public ContactModel()
        {
            ID = Guid.NewGuid().ToString();
            Tasks = new List<TaskModel>();
            Appointments = new AppointmentViewModel();
        }

        /// <summary>
        /// Validate the Name Properties for the contact
        /// </summary>
        /// <param name="toValidate"></param>
        /// <returns>A boolean if the name is validated.</returns>
        private bool ValidateName(string toValidate)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(toValidate))
            {
                isValid = false;
                throw new ArgumentNullException();
            }
            else
            {

                // Loop to see if name contains all characters
                foreach (char letter in toValidate)
                {
                    if (!Char.IsLetter(letter))
                    {
                        isValid = false;
                        throw new ArgumentException();
                    }   
                }
            }

            return isValid;
        }

        /// <summary>
        /// Validate the Phone Property for the contact
        /// </summary>
        /// <param name="toValidate"></param>
        /// <returns>A boolean if the phone is validated.</returns>
        private bool ValidatePhone(string toValidate)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(toValidate) || toValidate.Length != 10)
                isValid = false;
            else
            {
                // Loop to see if phone number contains all digits
                foreach (char number in PhoneNumber)
                {
                    if (!Char.IsDigit(number))
                        isValid = false;
                }
            }

            return isValid;
        }


    }
}
