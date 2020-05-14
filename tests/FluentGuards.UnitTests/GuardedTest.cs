using NUnit.Framework;

namespace FluentGuards.UnitTests
{
    public class Tests
    {

        [Test]
        public void ShouldCastObjectCorrectly()
        {
            var guarded = (Guarded<string>)"GUARDED";

            Assert.IsTrue(guarded.IsGuarded);
            Assert.AreEqual("GUARDED", guarded.Subject);
        }
    }
}