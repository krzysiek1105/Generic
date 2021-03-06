using System;
using Generic.Shared.Domain;
using Generic.Users.Domain;
using NUnit.Framework;

namespace Generic.Users.Tests
{
    internal class FirstNameTests
    {
        [Test]
        public void Should_Throw_Exception_If_Value_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var firstName = new FirstName(null!);
            });
        }

        [Test]
        public void Should_Throw_Exception_If_Value_Is_Empty()
        {
            Assert.Throws<DomainException>(() =>
            {
                var firstName = new FirstName("");
            });
        }

        [Test]
        public void Should_Throw_Exception_If_Value_Is_Too_Short()
        {
            Assert.Throws<DomainException>(() =>
            {
                var firstName = new FirstName("A");
            });
        }

        [Test]
        public void Should_Throw_Exception_If_Value_Is_Too_Long()
        {
            Assert.Throws<DomainException>(() =>
            {
                var firstName = new FirstName(new string('a', 51));
            });
        }

        [Test]
        [TestCase("John1")]
        [TestCase("12Jack")]
        [TestCase("12")]
        [TestCase("$!")]
        [TestCase("&&&Rose$")]
        [TestCase("&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@!111123123123990$#@123123$")]
        [TestCase("N1ck")]
        [TestCase("Nick ")]
        [TestCase(" Nick ")]
        [TestCase("Nick ")]
        [TestCase("N ick ")]
        public void Should_Throw_Exception_If_Value_Contains_Other_Characters_Than_Letters(string value)
        {
            Assert.Throws<DomainException>(() =>
            {
                var firstName = new FirstName(value);
            });
        }

        [Test]
        [TestCase("John")]
        [TestCase("Anna")]
        [TestCase("Mark")]
        [TestCase("George")]
        [TestCase("Ian")]
        [TestCase("Christoper")]
        [TestCase("Bożydar")]
        [TestCase("Fuß")]
        public void Should_Create_First_Name_From_Value(string value)
        {
            var firstName = new FirstName(value);
            Assert.AreEqual(value, firstName.Value);
        }
    }
}
