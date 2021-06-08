using NUnit.Framework;
using System;

namespace Grand_Strand_Systems.Test
{
    public class TaskModelTest
    {
        TaskModel testModel;

        [SetUp]
        public void Setup()
        {
            testModel = new TaskModel();
        }

        [Test]
        public void ErrorOnTaskName()
        {
            Assert.Throws<NullReferenceException>(() => new TaskModel("", "Take out Garbage"));
        }

        [Test]
        public void ErrorOnLongDescription()
        {
            Assert.Throws<ArgumentException>(() => new TaskModel("Get Pizza", "alskdjfa;lsdkjfa;sldkjfadsl;kjfla;sdkjfa;sdkfjla;sdkfja;sdkjf;alsdkjfa;lsdkjf"));
        }

        [Test]
        public void ErrorOnNullDescription()
        {
            Assert.Throws<NullReferenceException>(() => new TaskModel("Get pizza", ""));
        }
    }
}