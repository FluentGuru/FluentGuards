using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards.UnitTests
{
    public class ObjectGuardExtensionsTests
    {
        [Test]
        public void ShouldTryGuardAgainstNullObjects()
        {
            string obj = null;

            var guarded = obj.NotNull().TryGuard();

            Assert.IsFalse(guarded.IsGuarded);
        }

        [Test]
        public void ShouldGuardAgainstNullObjects()
        {
            string obj = null;

            Assert.Throws<ArgumentNullException>(() => obj.NotNull().Guard());
        }

        public async Task ShouldTryGuardAgainstNullObjectsAsync()
        {
            var obj = Task.FromResult<string>(null);

            var guarded = await obj.NotNull().TryGuardAsync();

            Assert.IsFalse(guarded.IsGuarded);
        }

        [Test]
        public void ShouldGuardAgainstNullObjectsAsync()
        {
            var obj = Task.FromResult<string>(null);

            Assert.ThrowsAsync<ArgumentNullException>(() => obj.NotNull().GuardAsync());
        }
    }
}
