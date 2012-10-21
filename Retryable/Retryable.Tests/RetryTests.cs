using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace Retryable.Tests
{
    public class RetryTests
    {
        [Fact]
        public void Execute()
        {
            Actions actions = new Actions(0);


            //actions.Action.Retry(RetryPolicies.NoRetry());

            Assert.Equal(0, actions.ThrowCount);
            Assert.Equal(1, actions.ExecuteCount);
        }
    }

    public class FunctionRetryTests
    {
        [Fact]
        public void Execute()
        {
            Functions functions = new Functions(0);

            Func<int> func = functions.Func<int>;

            int result = func.InvokeWithRetry(RetryPolicies.NoRetry());

            Assert.Equal(0, functions.ThrowCount);
            Assert.Equal(1, functions.ExecuteCount);
            Assert.Equal(0, result);
        }

        [Fact]
        public void ExecuteWithThrow()
        {
            Functions functions = new Functions(1);

            Func<int> func = functions.Func<int>;
            
            //Exception exception = Assert.Throws<Exception>(() => Retry.Retry(func, RetryPolicies.NoRetry()));

            Assert.Equal(1, functions.ThrowCount);
            Assert.Equal(1, functions.ExecuteCount);
        }

        [Fact]
        public void RandomExponentialTest()
        {
            TimeSpan minimum = TimeSpan.FromSeconds(1);
            TimeSpan maximum = TimeSpan.FromSeconds(10);

            for (int i = 0; i < 1000; i++)
            {
                TimeSpan value = BackoffPolicies.RandomExponential(0, minimum, maximum, TimeSpan.FromSeconds(1));

                Assert.True(minimum <= value);
                Assert.True(value <= maximum);
            }
        }
    }


    public abstract class RetryBase
    {
        private int _throwCount;
        private int _executeCount;

        private int _failCount;

        protected RetryBase(int failCount)
        {
            _executeCount = 0;
            _failCount = failCount;          
        }

        public int ExecuteCount { get { return _executeCount; } }

        public int ThrowCount { get { return _throwCount; } }

        protected void Execute()
        {
            if (_executeCount++ < _failCount)
            {
                _throwCount++;
                throw new Exception(string.Format("Executed {0} times", _executeCount));
            }
        }
    }

    public class Functions : RetryBase
    {
        public Functions(int failCount)
            : base(failCount)
        {            
        }

        public TReturn Func<TReturn>()
        {
            Execute();
            return default(TReturn);
        }
    }

    public class Actions : RetryBase
    {
        public Actions(int failCount) : base(failCount)
        {
        }

        public Action GetAction()
        {
            return Execute;
        }
    }
}
