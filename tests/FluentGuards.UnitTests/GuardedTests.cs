using NUnit.Framework;

namespace FluentGuards.UnitTests
{
    public class GuardedTests
    {

        [Test]
        public void ShouldCastObjectCorrectly()
        {
            var guarded = (Guarded<string>)"GUARDED";

            Assert.IsTrue(guarded.IsGuarded);
            Assert.AreEqual("GUARDED", guarded.Subject);
        }

        [Test]
        public void ShouldCastBooleanCorrectly()
        {
            var guarded = (Guarded<string>)false;

            Assert.IsFalse(guarded.IsGuarded);
            Assert.AreEqual(default(string), guarded.Subject);
        }
    }
}