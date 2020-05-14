using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards.UnitTests
{
    public class StringGuardExtensionsTests
    {
        [Test]
        public void ShouldTryGuardAgainstNotEmptyString()
        {
            string value = "";

            var guarded = value.NotEmpty().TryGuard();

            Assert.IsFalse(guarded.IsGuarded);
        }

        [Test]
        public void ShouldGuardAgainstNotEmptyString()
        {
            string value = "";

            Assert.Throws<ArgumentNullException>(() => value.NotEmpty().Guard());
        }

        [Test]
        public async Task ShouldTryGuardEmptyStringAsync()
        {
            var value = Task.FromResult("");

            var guarded = await value.NotEmpty().TryGuardAsync();

            Assert.IsFalse(guarded.IsGuarded);
        }

        [Test]
        public void ShouldGuardAgainstNotEmptyStringAsync()
        {
            var value = Task.FromResult("");

            Assert.ThrowsAsync<ArgumentNullException>(() => value.NotEmpty().GuardAsync());
        }
    }
}
