using NUnit.Framework;
using System;

namespace Grand_Strand_Systems.Test
{
    public class ContactModelTests
    {
        ContactModel testModel;

        [SetUp]
        public void Setup()
        {
            testModel = new ContactModel();
        }

        [Test]
        public void ErrorOnEmptyFirstName()
        {
            Assert.Throws<ArgumentNullException>(() => new ContactModel("", "Tyler", "3012472642", "123 Fake Street"));
        }

        [Test]
        public void ErrorOnLongLastName()
        {
            Assert.Throws<ArgumentNullException>(() => new ContactModel("Nick", "", "3012472642", "123 Fake Street"));
        }

        [Test]
        public void ErrorOnTooLongPhoneNUmber()
        {
            Assert.Throws<ArgumentException>(() => new ContactModel("Nick", "Tyler", "30124726426780", "123 Fake Street"));
        }

        [Test]
        public void EmptyOnEmptyAddress()
        {
            Assert.Throws<ArgumentNullException>(() => new ContactModel("", "Tyler", "3012472642", ""));
        }
    }
}