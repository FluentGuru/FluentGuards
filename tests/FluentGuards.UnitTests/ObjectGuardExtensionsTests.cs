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
        public void ShouldThrowWhenObjectIsNull()
        {
            string obj = null;

            Assert.Throws<ArgumentNullException>(() => obj.NotNull().Guard());
        }

        [Test]
        public void ShouldThrowWhenObjectIsNullAsync()
        {
            var obj = Task.FromResult<string>(null);

            Assert.ThrowsAsync<ArgumentNullException>(() => obj.NotNull().GuardAsync());
        }
    }
}
