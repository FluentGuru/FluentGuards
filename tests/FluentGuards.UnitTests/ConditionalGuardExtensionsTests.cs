using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards.UnitTests
{
    public class ConditionalGuardExtensionsTests
    {
        [Test]
        public void ShouldTryGuardAgainstCondition()
        {
            var value = "VAL";

            var guarded = value.Condition(s => s == "VALUE").TryGuard();

            Assert.IsFalse(guarded);
        }

        [Test]
        public async Task ShouldTryGuardAgainstConditionAsync()
        {
            var value = Task.FromResult("VAL");

            var guarded = await value.Condition(s => s == "VALUE").TryGuardAsync();

            Assert.IsFalse(guarded);
        }

        [Test]
        public void ShouldGuardAgainstCondition()
        {
            var value = "VAL";

            var guard = value.Condition(s => s == "VALUE");

            Assert.Throws<ConditionalGuardFailedException>(() => guard.Guard());
        }

        [Test]
        public void ShouldGuardAgainstConditionAsync()
        {
            var value = Task.FromResult("VAL");

            var guard = value.Condition(s => s == "VALUE");

            Assert.ThrowsAsync<ConditionalGuardFailedException>(() => guard.GuardAsync());
        }
    }
}
