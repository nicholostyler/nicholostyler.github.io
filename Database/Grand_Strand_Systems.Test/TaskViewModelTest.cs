using NUnit.Framework;
using System;

namespace Grand_Strand_Systems.Test
{
    public class TaskViewModelTest
    {
        TaskViewModel testModel;

        [SetUp]
        public void Setup()
        {
            // Initailize and set default values to the testModel
            testModel = new TaskViewModel();
            testModel.Add("Take Out Garbage", "Go to garbage bin and throw trash", "123");
            testModel.Add("Grocery List", "Carrots, Cheese, Bread", "123");
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
            Assert.IsTrue(testModel.Get(1).Name == "Grocery List");
        }

        [Test]
        public void UpdateContact()
        {
            testModel.UpdateName(1, "Throw away steaks");
            Assert.IsTrue(testModel.Get(1).Name == "Throw away steaks");
        }
    }
}