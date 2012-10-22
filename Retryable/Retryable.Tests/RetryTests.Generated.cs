using System;
using Xunit;

namespace Retryable.Tests
{
    public partial class RetryTests
    {
        [Fact]
        public void Action_With_2_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_2_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_3_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_3_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_4_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_4_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_5_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_5_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_6_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_6_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_7_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_7_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_8_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int,int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_8_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_9_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int,int,int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_9_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int,int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_10_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int,int,int,int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_10_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int,int,int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_11_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int,int,int,int,int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_11_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int,int,int,int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_12_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int,int,int,int,int,int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_12_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int,int,int,int,int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_13_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int,int,int,int,int,int,int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_13_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int,int,int,int,int,int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_14_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int,int,int,int,int,int,int,int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_14_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int,int,int,int,int,int,int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_15_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int,int,int,int,int,int,int,int,int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_15_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int,int,int,int,int,int,int,int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Action_With_16_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var action = operations.GetAction<int,int,int,int,int,int,int,int,int,int,int,int,int,int,int,int>();

            // act
            action.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

        [Fact]
        public void Func_With_16_Args_InvokeWithNoRetry()
        {
            // arrange
            Operations operations = new Operations(0);

            var func = operations.GetFunc<int,int,int,int,int,int,int,int,int,int,int,int,int,int,int,int,int>();

            // act
            func.InvokeWithRetry(RetryPolicies.NoRetry(),0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);

            // assert
            Assert.Equal(0, operations.ThrowCount);
            Assert.Equal(1, operations.ExecuteCount);
        }

    }
}

