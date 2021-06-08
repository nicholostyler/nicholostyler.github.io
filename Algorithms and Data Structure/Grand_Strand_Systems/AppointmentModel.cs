using System;


namespace Grand_Strand_Systems
{
    public class AppointmentModel
    {
        // private member variables to use as backing fields.
        private DateTime _date;
        private string _description;

        public String ID { get; private set; }
        public DateTime Date 
        {
            get
            {
                return Date;
            }
            set
            {
                // if date is null throw exception
                if (value != null)
                {
                    if (!(value < DateTime.Now))
                    {
                        _date = value;
                    }
                    else
                    {
                        // The date is in the past
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new ArgumentNullException();
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
                // if the value passed is null or empty throw exception
                if (!string.IsNullOrEmpty(value))
                {
                    // if value is greater than 50 throw exception
                    if (value.Length <= 50)
                    {
                        _description = value;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        /// <summary>
        /// Constructor to add all the member variab les
        /// </summary>
        /// <param name="date">DateTime object</param>
        /// <param name="description">String description of the appointment</param>
        public AppointmentModel(DateTime date, string description)
        {
            ID = Guid.NewGuid().ToString();
            Date = date;
            Description = description;
        }

        public AppointmentModel() { }
    }
}
