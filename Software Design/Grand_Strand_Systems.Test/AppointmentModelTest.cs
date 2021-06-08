using System;
using NUnit.Framework;

namespace Grand_Strand_Systems.Test
{
    class AppointmentModelTest
    {
        AppointmentModel testModel;

        [SetUp]
        public void Setup()
        {
            testModel = new AppointmentModel();
        }

        [Test]
        public void NullAppointmentDescription()
        {
            DateTime testAppointment = new DateTime(2021, 5, 23);
            Assert.Throws<ArgumentNullException>(() => new AppointmentModel(testAppointment, ""));
        }

        [Test]
        public void ThrowErrorAddPastAppointment()
        {
            DateTime testAppointmentFalse = new DateTime(2020, 5, 23);
            Assert.Throws<ArgumentException>(() => new AppointmentModel(testAppointmentFalse, "fake description"));
        }

        [Test]
        public void ThrowErrorLongDescription()
        {
            DateTime testAppointment = new DateTime(2021, 5, 23);

            Assert.Throws<ArgumentException>(() => new AppointmentModel(testAppointment, "lkajsd;flajwe;ofiawje;foiawej;foiawef;oiawejf"));
        }
    }
}
