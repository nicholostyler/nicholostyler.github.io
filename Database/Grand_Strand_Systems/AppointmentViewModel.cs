using System;
using System.Collections.Generic;
using System.Text;

namespace Grand_Strand_Systems
{
    public class AppointmentViewModel
    {
        List<AppointmentModel> Appointments { get; set; }

        public AppointmentViewModel()
        {
            Appointments = new List<AppointmentModel>();
        }

        /// <summary>
        /// Add a new Apppointment 
        /// </summary>
        /// <param name="date">Datetime object of new date</param>
        /// <param name="description">Description of the appointment</param>
        public void Add(DateTime date, string description)
        {
            try
            {
                //TaskModel newTask = new TaskModel(name, description);
                //Tasks.Add(newTask);
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

        public AppointmentModel Get(int index)
        {
            // Loop through contacts
            foreach (AppointmentModel appointment in Appointments)
            {
                // If looped model matches the passed in index
                if (Appointments[index - 1] == appointment)
                {
                    return appointment;
                }
            }

            // If a contact is not found
            Console.WriteLine("No Contact found at that index.");
            return null;
        }

        /// <summary>
        /// Remove an appointment from the list
        /// </summary>
        /// <param name="index">Index of the appointment to remove.</param>
        public void Remove(int index)
        {
            // If the list count is less than the index print error
            if (Appointments.Count <= index)
            {
                Console.WriteLine("Position not in the list.");
                throw new ArgumentException();
            }

            // Subtract one as users do not count by 0
            Appointments.RemoveAt(index - 1);
        }

        /// <summary>
        /// Remove an appointment from the list
        /// </summary>
        /// <param name="appointment">AppointmentModel object to remove</param>
        public void Remove(AppointmentModel appointment)
        {
            if (Appointments.Contains(appointment))
            {
                Appointments.Remove(appointment);
            }
            else
            {
                Console.WriteLine("This appointment is not in the list, try again.");
            }
        }

        /// <summary>
        /// Verify the month of the year the user selected.
        /// </summary>
        /// <param name="month">String -- value of the user selected month</param>
        /// <returns></returns>
        public int VerifyMonth(string month)
        {
            int verifiedMonth = 0;
            
            // convert from string to int
            try
            {
                verifiedMonth = Int32.Parse(month);
                if (verifiedMonth <= 12)
                {
                    return verifiedMonth;
                }
            }
            catch (ArgumentNullException ex)
            {
                // Argument is null
                Console.WriteLine("Month given was null, please try again.");
                return -1;
            }
            catch (FormatException ex)
            {
                // Is not a string
                Console.WriteLine("Month given was not correct, please try again.");
                return -1;
            }

            // Everything failed
            return -1;
        }

        /// <summary>
        /// Verify the day of the user passed by the user
        /// </summary>
        /// <param name="month">int value of the user selected month</param>
        /// <param name="day">String -- value of the user selected day</param>
        /// <returns></returns>
        public int VerifyDay(int month, string day)
        {
            int verifiedDay = 0;
            int year = DateTime.Now.Year;

            // convert from string to int
            try
            {
                verifiedDay = Int32.Parse(day);
                switch (month)
                {
                    // if its Feb, account for leap year.
                    case 2:
                        if (DateTime.IsLeapYear(year))
                        {
                            if (verifiedDay <= 29) return verifiedDay;
                        }
                        else
                        {
                            if (verifiedDay <= 28) return verifiedDay;
                        }
                        break;
                    case 8: case 3: case 5:
                    case 10:
                        if (verifiedDay <= 30) return verifiedDay;
                        break;
                    default:
                        if (verifiedDay <= 31) return verifiedDay;
                        break;
                 
                }
            }
            catch (ArgumentNullException ex)
            {
                // Argument is null
                Console.WriteLine("Month given was null, please try again.");
                return -1;
            }
            catch (FormatException ex)
            {
                // Is not a string
                Console.WriteLine("Month given was not correct, please try again.");
                return -1;
            }

            // Everything failed
            return -1;
        }

        /// <summary>
        /// Search for an appointment by the day or the month
        /// </summary>
        /// <param name="query">A string with the search query</param>
        /// <param name="month">A boolean value if the search if by month</param>
        /// <returns></returns>
        public List<AppointmentModel> Search(string query, bool month)
        {
            int intConvert = 0;
            List<AppointmentModel> matchedAppointments = new List<AppointmentModel>();

            try
            {
                intConvert = Int32.Parse(query);
            }
            catch (FormatException)
            {
                Console.WriteLine("Provider search query is not a number.");
            }

            // Enumerable through all of the appointments in the list
            foreach (AppointmentModel appointment in Appointments)
            {
                // if the user is looking for month or day
                if (month)
                {
                    if (appointment.Date.Month == intConvert)
                    {
                        matchedAppointments.Add(appointment);
                    }
                }
                else
                {
                    if (appointment.Date.Day == intConvert)
                    {
                        matchedAppointments.Add(appointment);
                    }
                }
            }

            return matchedAppointments;
        }

        /// <summary>
        /// Display only a specific list of appointments
        /// </summary>
        /// <param name="appointments">A list of AppointmentModels</param>
        public void Display(List<AppointmentModel> appointments)
        {
            if (appointments.Count == 0)
            {
                Console.WriteLine("List is empty -- try refining your search");
            }

            // counter to show index
            int loopCount = 0;

            // Loop through the contacts
            foreach (AppointmentModel appointment in appointments)
            {
                // iterate the loopcount and show the model and index
                loopCount++;
                Console.WriteLine($"\n{loopCount} -- {appointment.Date.Day}/{appointment.Date.Month}/{appointment.Date.Year} -- {appointment.Description}");

            }
        }

        /// <summary>
        /// Display all appointments in list
        /// </summary>
        public void DisplayAll()
        {
            // Write out if the list is empty
            if (Appointments.Count == 0)
            {
                Console.WriteLine("List is empty -- try adding an appointment");
            }

            // counter to show index
            int loopCount = 0;

            // Loop through the contacts
            foreach(AppointmentModel appointment in Appointments)
            {
                // iterate the loopcount and show the model and index
                loopCount++;
                Console.WriteLine($"\n{loopCount} -- {appointment.Date.Day}/{appointment.Date.Month}/{appointment.Date.Year} -- {appointment.Description}");

            }
        }
    }

    
}
