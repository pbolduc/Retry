using System;

using Xunit;

namespace Retryable.Tests
{
    public class RetryTests
    {
        [Fact]
        public void ActionInvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            Action action = operations.GetAction();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry());

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void FuncInvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            Func<int> func = operations.GetFunc<int>();

            // act
            int result = func.InvokeWithRetry(RetryPolicies.NoRetry());

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void ExecuteWithThrow()
        {
            // arrange
            Operations operations = new Operations(1);

            Func<int> func = operations.GetFunc<int>();

            Assert.ThrowsDelegate testCode = () =>
                {
                    func.InvokeWithRetry(RetryPolicies.NoRetry());
                };

            // act
            Exception exception = Assert.Throws<Exception>(testCode);

            // assert
            Assert.Equal(string.Format(Operations.ExceptionMessageFormat, 1), exception.Message);
            Assert.Equal(1, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void RandomExponentialTest()
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
