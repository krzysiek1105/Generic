using System;
using Generic.Users.Domain;
using NUnit.Framework;

namespace Generic.Users.Tests
{
    public class UserActivationTests
    {
        [Test]
        public void Should_Activate_User()
        {
            var user = Users.JohnDoe(false);
            user.Activate(user.ActivationToken.Value);

            Assert.True(user.IsActivated);
            Assert.IsFalse(user.ActivationToken.HasValue);
        }

        [Test]
        public void User_Activation_Should_Fail_If_User_Has_Already_Been_Activated()
        {
            var user = Users.JohnDoe();
            Assert.Throws<UserActivationException>(() => user.Activate(Guid.Empty));
        }

        [Test]
        public void User_Activation_Should_Fail_If_Activation_Token_Is_Invalid()
        {
            var user = Users.JohnDoe(false);
            Assert.Throws<UserActivationException>(() => user.Activate(Guid.NewGuid()));
        }
    }
}