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

            var andGuarded = value.NotEmpty().And(value.NotNull()).TryGuard();
            var andUnGuarded = value.NotEmpty().And(value.EqualsTo("test")).TryGuard();

            Assert.IsTrue(andGuarded);
            Assert.IsFalse(andUnGuarded);
        }

        [Test]
        public async Task ShouldTryGuardAgainstAndCombinationAsync()
        {
            var value = Task.FromResult("TEST");

            var andGuarded = await value.NotEmpty().And(value.NotNull()).TryGuardAsync();
            var andUnGuarded = await value.NotEmpty().And(value.EqualsTo("test")).TryGuardAsync();

            Assert.IsTrue(andGuarded);
            Assert.IsFalse(andUnGuarded);
        }

        [Test]
        public void ShouldGuardAgainstAndCombination()
        {
            var value = "TEST";

            var andGuarded = value.NotEmpty().And(value.NotNull());
            var andUnGuarded = value.NotEmpty().And(value.EqualsTo("test"));

            Assert.DoesNotThrow(() => andGuarded.Guard());
            Assert.Throws<CombinedGuardFailedException>(() => andUnGuarded.Guard());
        }

        [Test]
        public void ShouldGuardAgainstAndCombinationAsync()
        {
            var value = Task.FromResult("TEST");

            var andGuarded = value.NotEmpty().And(value.NotNull());
            var andUnGuarded = value.NotEmpty().And(value.EqualsTo("test"));

            Assert.DoesNotThrowAsync(() => andGuarded.GuardAsync());
            Assert.ThrowsAsync<CombinedGuardFailedException>(() => andUnGuarded.GuardAsync());
        }

        [Test]
        public void ShouldTryGuardAgainstOrCombination()
        {
            var value = "TEST";

            var orGuardedAllTrue = value.NotEmpty().Or(value.NotNull()).TryGuard();
            var orGuardedFirstTrue = value.NotEmpty().Or(value.EqualsTo("test")).TryGuard();
            var orGuardedLastTrue = value.EqualsTo("test").Or(value.NotNull()).TryGuard();
            var orGuardedAllFalse = value.EqualsTo("test").Or(value.EqualsTo("Test")).TryGuard();

            Assert.IsTrue(orGuardedAllTrue);
            Assert.IsTrue(orGuardedFirstTrue);
            Assert.IsTrue(orGuardedLastTrue);
            Assert.IsFalse(orGuardedAllFalse);
        }

        [Test]
        public async Task ShouldTryGuardAgainstOrCombinationAsync()
        {
            var value = Task.FromResult("TEST");

            var orGuardedAllTrue = await value.NotEmpty().Or(value.NotNull()).TryGuardAsync();
            var orGuardedFirstTrue = await value.NotEmpty().Or(value.EqualsTo("test")).TryGuardAsync();
            var orGuardedLastTrue = await value.EqualsTo("test").Or(value.NotNull()).TryGuardAsync();
            var orGuardedAllFalse = await value.EqualsTo("test").Or(value.EqualsTo("Test")).TryGuardAsync();

            Assert.IsTrue(orGuardedAllTrue);
            Assert.IsTrue(orGuardedFirstTrue);
            Assert.IsTrue(orGuardedLastTrue);
            Assert.IsFalse(orGuardedAllFalse);
        }

        [Test]
        public void ShouldGuardAgainstOrCombination()
        {
            var value = "TEST";

            var orGuardedAllTrue = value.NotEmpty().Or(value.NotNull());
            var orGuardedFirstTrue = value.NotEmpty().Or(value.EqualsTo("test"));
            var orGuardedLastTrue = value.EqualsTo("test").Or(value.NotNull());
            var orGuardedAllFalse = value.EqualsTo("test").Or(value.EqualsTo("Test"));

            Assert.DoesNotThrow(() => orGuardedAllTrue.Guard());
            Assert.DoesNotThrow(() => orGuardedFirstTrue.Guard());
            Assert.DoesNotThrow(() => orGuardedLastTrue.Guard());
            Assert.Throws<CombinedGuardFailedException>(() => orGuardedAllFalse.Guard());
        }

        [Test]
        public void ShouldGuardAgainstOrCombinationAsync()
        {
            var value = Task.FromResult("TEST");

            var orGuardedAllTrue = value.NotEmpty().Or(value.NotNull());
            var orGuardedFirstTrue = value.NotEmpty().Or(value.EqualsTo("test"));
            var orGuardedLastTrue = value.EqualsTo("test").Or(value.NotNull());
            var orGuardedAllFalse = value.EqualsTo("test").Or(value.EqualsTo("Test"));

            Assert.DoesNotThrowAsync(() => orGuardedAllTrue.GuardAsync());
            Assert.DoesNotThrowAsync(() => orGuardedFirstTrue.GuardAsync());
            Assert.DoesNotThrowAsync(() => orGuardedLastTrue.GuardAsync());
            Assert.ThrowsAsync<CombinedGuardFailedException>(() => orGuardedAllFalse.GuardAsync());
        }
    }
}
