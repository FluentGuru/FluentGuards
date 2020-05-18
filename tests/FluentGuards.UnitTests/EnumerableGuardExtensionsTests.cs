using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards.UnitTests
{
    public class EnumerableGuardExtensionsTests
    {
        [Test]
        public void ShouldTryGuardAgainstEmptyEnumerables()
        {
            var empty = Enumerable.Empty<string>();

            var guarded = empty.NotEmpty().TryGuard();

            Assert.IsFalse(guarded.IsGuarded);
        }

        [Test]
        public async Task ShouldTryGuardAgainsEmptyEnumerablesAsync()
        {
            var empty = Task.FromResult(Enumerable.Empty<string>());

            var guarded = await empty.NotEmpty().TryGuardAsync();

            Assert.IsFalse(guarded.IsGuarded);
        }

        [Test]
        public void ShouldGuardAgainstEmptyEnumerables()
        {
            var empty = Task.FromResult(Enumerable.Empty<string>());

            Assert.Throws<NotEmptyGuardFailedException>(() => empty.NotEmpty().Guard());
        }

        [Test]
        public void ShouldGuardAgainstEmtpyEnumerablesAsync()
        {
            var empty = Task.FromResult(Enumerable.Empty<string>());

            Assert.ThrowsAsync<NotEmptyGuardFailedException>(() => empty.NotEmpty().GuardAsync());
        }
    }
}
