using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards.UnitTests
{
    public class DefaultValueGuardExtensionsTests
    {
        [Test]
        public void ShouldReturnSpecifiedDefaultValueAgainstNullObject()
        {
            string obj = null;

            var guard = obj.NotNull().Default("DEFAULT");

            Assert.AreEqual("DEFAULT", guard.Guard());
        }

        [Test]
        public async Task ShouldReturnSpecifiedDefaultValueAgainstNullObjectAsync()
        {
            var obj = Task.FromResult<string>(null);

            var guard = obj.NotNull().Default("DEFAULT");

            var result = await guard.GuardAsync();
            Assert.AreEqual("DEFAULT", result);
        }
    }
}
