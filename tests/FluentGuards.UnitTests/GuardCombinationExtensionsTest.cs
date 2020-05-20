using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards.UnitTests
{
    public class GuardCombinationExtensionsTest
    {
        [Test]
        public void ShouldTryGuardAgainstAndCombination()
        {
            string value = "TEST";

            var andGuarded = value.NotEmpty().And(s => s.NotNull()).TryGuard();
            var andUnGuarded = value.NotEmpty().And(s => s.EqualsTo("test")).TryGuard();

            Assert.IsTrue(andGuarded);
            Assert.IsFalse(andUnGuarded);
        }

        [Test]
        public async Task ShouldTryGuardAgainstAndCombinationAsync()
        {
            var value = Task.FromResult("TEST");

            var andGuarded = await value.NotEmpty().And(s => s.NotNull()).TryGuardAsync();
            var andUnGuarded = await value.NotEmpty().And(s => s.EqualsTo("test")).TryGuardAsync();

            Assert.IsTrue(andGuarded);
            Assert.IsFalse(andUnGuarded);
        }

        [Test]
        public void ShouldGuardAgainstAndCombination()
        {
            var value = "TEST";

            var andGuarded = value.NotEmpty().And(s => s.NotNull());
            var andUnGuarded = value.NotEmpty().And(s => s.EqualsTo("test"));

            Assert.DoesNotThrow(() => andGuarded.Guard());
            Assert.Throws<CombinedGuardFailedException>(() => andUnGuarded.Guard());
        }

        [Test]
        public void ShouldGuardAgainstAndCombinationAsync()
        {
            var value = Task.FromResult("TEST");

            var andGuarded = value.NotEmpty().And(s => s.NotNull());
            var andUnGuarded = value.NotEmpty().And(s => s.EqualsTo("test"));

            Assert.DoesNotThrowAsync(() => andGuarded.GuardAsync());
            Assert.ThrowsAsync<CombinedGuardFailedException>(() => andUnGuarded.GuardAsync());
        }

        [Test]
        public void ShouldTryGuardAgainstOrCombination()
        {
            var value = "TEST";

            var orGuardedAllTrue = value.NotEmpty().Or(s => s.NotNull()).TryGuard();
            var orGuardedFirstTrue = value.NotEmpty().Or(s => s.EqualsTo("test")).TryGuard();
            var orGuardedAllFalse = value.EqualsTo("test").Or(s => s.EqualsTo("Test")).TryGuard();

            Assert.IsTrue(orGuardedAllTrue);
            Assert.IsTrue(orGuardedFirstTrue);
            Assert.IsFalse(orGuardedAllFalse);
        }
    }
}
