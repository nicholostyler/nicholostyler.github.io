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
        /// REmove an appointment from the list
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
