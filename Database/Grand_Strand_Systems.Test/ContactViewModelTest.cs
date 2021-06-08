using NUnit.Framework;
using System;

namespace Grand_Strand_Systems.Test
{
    public class ContactModelTest
    {
        ContactViewModel testModel;

        [SetUp]
        public void Setup()
        {
            // Initailize and set default values to the testModel
            testModel = new ContactViewModel();
            testModel.Add("Nick", "Tyler", "3012472642", "123 Fake Street");
            testModel.Add("Sara", "Ostrowski", "3012472642", "123 Fake Street");
        }

        [Test]
        public void AddMultipleContacts()
        {
            // Add Contacts to test
            Assert.IsTrue(testModel.Size() == 2);
        }

        [Test]
        public void DeleteConect()
        {
            // Remove the first object
            testModel.Remove(1);
            Assert.IsTrue(testModel.Get(1).FirstName == "Sara");
        }

        [Test]
        public void UpdateContact()
        {
            testModel.Update(1, first: "Brian", last: "Sams");
            Assert.IsTrue(testModel.Get(1).FirstName == "Brian");
        }
    }
}