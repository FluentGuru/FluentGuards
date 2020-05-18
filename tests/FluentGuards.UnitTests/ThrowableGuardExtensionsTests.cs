using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards.UnitTests
{
    public class ThrowableGuardExtensionsTests
    {
        [Test]
        public void ShouldThrowCustomExceptionAgainstNullObjects()
        {
            string obj = null;

            var guard = obj.NotNull().Throw(new InvalidOperationException());

            Assert.Throws<InvalidOperationException>(() => guard.Guard());
        }

        [Test]
        public void ShouldThrowCustomExceptionAgainstNullObjectsAsync()
        {
            var obj = Task.FromResult<string>(null);

            var guard = obj.NotNull().Throw(new InvalidOperationException());

            Assert.ThrowsAsync<InvalidOperationException>(() => guard.GuardAsync());
        }

        [Test]
        public void ShouldNotThrowGuardExceptionAgainstNullObjects()
        {
            string obj = null;

            var guard = obj.NotNull().DoNotThrow();

            Assert.DoesNotThrow(() => guard.Guard());
        }

        [Test]
        public void ShouldNotThrowGuardExceptionAgaisntNullObjectsAsync()
        {
            var obj = Task.FromResult<string>(null);

            var guard = obj.NotNull().DoNotThrow();

            Assert.DoesNotThrowAsync(() => guard.GuardAsync());
        }
    }
}
