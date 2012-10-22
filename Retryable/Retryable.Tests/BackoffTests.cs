using System;

using Xunit;

namespace Retryable.Tests
{
    public class BackoffTests
    {
        [Fact]
        public void RandomExponential_should_be_greater_or_equal_to_minimum_and_less_than_or_equal_to_maximum()
        {
            // arrange
            TimeSpan minimum = TimeSpan.FromSeconds(1);
            TimeSpan maximum = TimeSpan.FromSeconds(10);
            TimeSpan delta = TimeSpan.FromSeconds(1);

            // act
            TimeSpan value = BackoffPolicies.RandomExponential(0, minimum, maximum, delta);

            // assert
            Assert.True(minimum <= value);
            Assert.True(value <= maximum);
        }
    }
}