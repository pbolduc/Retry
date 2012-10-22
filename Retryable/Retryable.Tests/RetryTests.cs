using System;
using Xunit;

namespace Retryable.Tests
{
    public partial class RetryTests
    {
        [Fact]
        public void Action_With_No_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var policy = Policy.NoRetry();
            var action = operations.GetAction();

            // act
            action.InvokeWithRetry(policy.RetryPolicy);

            // assert
            Assert.Equal(0, policy.ShouldRetryCallCount);
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_No_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var policy = Policy.NoRetry();
            var func = operations.GetFunc<int>();

            // act
            func.InvokeWithRetry(policy.RetryPolicy);

            // assert
            Assert.Equal(0, policy.ShouldRetryCallCount);
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_1_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var policy = Policy.NoRetry();
            var func = operations.GetFunc<int, int>();

            // act
            func.InvokeWithRetry(policy.RetryPolicy, 0);

            // assert
            Assert.Equal(0, policy.ShouldRetryCallCount);
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_will_throw_when_policy_returns_false()
        {
            // arrange
            Operations operations = new Operations(1);

            var policy = Policy.NoRetry();
            var func = operations.GetFunc<int>();

            Assert.ThrowsDelegate testCode = () => func.InvokeWithRetry(policy.RetryPolicy);

            // act
            Exception exception = Assert.Throws<Exception>(testCode);

            // assert
            Assert.Equal(1, policy.ShouldRetryCallCount);
            Assert.Equal(string.Format(Operations.ExceptionMessageFormat, 1), exception.Message);
            Assert.Equal(1, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_will_throw_when_policy_returns_false()
        {
            // arrange
            Operations operations = new Operations(1);

            var policy = Policy.NoRetry();
            var action = operations.GetAction();

            Assert.ThrowsDelegate testCode = () => action.InvokeWithRetry(policy.RetryPolicy);

            // act
            Exception exception = Assert.Throws<Exception>(testCode);

            // assert
            Assert.Equal(string.Format(Operations.ExceptionMessageFormat, 1), exception.Message);
            Assert.Equal(1, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        private class Policy
        {
            private int _shouldRetryCallCount;

            private int _retryCount;

            private Policy(int retryCount)
            {
                _retryCount = retryCount;
            }

            public int ShouldRetryCallCount
            {
                get { return _shouldRetryCallCount; }
            }

            public RetryPolicy RetryPolicy
            {
                get { return () => ShouldRetry; }
            }

            public static Policy NoRetry()
            {
                Policy policy = new Policy(0);
                return policy;
            }

            public static Policy Times(int times)
            {
                Policy policy = new Policy(times);
                return policy;
            }

            private bool ShouldRetry(int retryCount, Exception exception, out TimeSpan retryInterval)
            {
                this._shouldRetryCallCount++;
                retryInterval = TimeSpan.Zero;
                return _retryCount-- <= 0;
            }
        }
    }
}
