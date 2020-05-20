using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards.UnitTests
{
    public class ComparisonGuardExtensionsTests
    {
        [Test]
        public void ShouldGuardForEqualValues()
        {
            int value = 1;

            Assert.DoesNotThrow(() => value.EqualsTo(1).Guard());
            Assert.Throws<CompareGuardFailedException>(() => value.EqualsTo(2).Guard());
        }

        [Test]
        public void ShouldGuardForEqualValuesAsync()
        {
            var value = Task.FromResult(1);

            Assert.DoesNotThrowAsync(() => value.EqualsTo(1).GuardAsync());
            Assert.ThrowsAsync<CompareGuardFailedException>(() => value.EqualsTo(2).GuardAsync());
        }

        [Test]
        public void ShouldGuardForGreaterThanValues()
        {
            var value = 2;

            Assert.DoesNotThrow(() => value.GreaterThan(1).Guard());
            Assert.Throws<CompareGuardFailedException>(() => value.GreaterThan(2).Guard());
        }

        [Test]
        public void ShouldGuardForGreaterThanValuesAsync()
        {
            var value = Task.FromResult(2);

            Assert.DoesNotThrowAsync(() => value.GreaterThan(1).GuardAsync());
            Assert.ThrowsAsync<CompareGuardFailedException>(() => value.GreaterThan(2).GuardAsync());
        }

        [Test]
        public void ShouldGuardForLessThanValues()
        {
            var value = 2;

            Assert.DoesNotThrow(() => value.LessThan(3).Guard());
            Assert.Throws<CompareGuardFailedException>(() => value.LessThan(2).Guard());
        }

        [Test]
        public void ShouldGuardForLessThanValuesAsync()
        {
            var value = Task.FromResult(2);

            Assert.DoesNotThrowAsync(() => value.LessThan(3).GuardAsync());
            Assert.ThrowsAsync<CompareGuardFailedException>(() => value.LessThan(2).GuardAsync());
        }

        [Test]
        public void ShouldGuardForGreaterOrEqualThanValues()
        {
            var value = 2;

            Assert.DoesNotThrow(() => value.GreaterOrEqualThan(1).Guard());
            Assert.DoesNotThrow(() => value.GreaterOrEqualThan(2).Guard());
            Assert.Throws<CompareGuardFailedException>(() => value.GreaterOrEqualThan(3).Guard());
        }
    }
}
