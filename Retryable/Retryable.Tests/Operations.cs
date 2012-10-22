using System;

namespace Retryable.Tests
{
    public partial class Operations
    {
        /// <summary>
        /// A string like "Executed {0} times"
        /// </summary>
        public const string ExceptionMessageFormat = "Executed {0} times";

        private readonly int _failCount;

        private int _throwCount;
        private int _executeCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Operations" /> class.
        /// </summary>
        /// <param name="failCount">The fail count.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="failCount"/> is less than zero.
        /// </exception>
        public Operations(int failCount)
        {
            if (failCount < 0)
            {
                throw new ArgumentOutOfRangeException("failCount");
            }

            this._executeCount = 0;
            this._failCount = failCount;          
        }

        /// <summary>
        /// Gets the number of times the core operation was called.
        /// </summary>
        /// <value>
        /// The number of times the core operation was called.
        /// </value>
        public int ExecuteCount
        {
            get { return this._executeCount; }
        }

        /// <summary>
        /// Gets the number of times an <see cref="Exception"/> was thrown.
        /// </summary>
        /// <value>
        /// The throw count.
        /// </value>
        public int ThrowCount
        {
            get { return this._throwCount; }
        }

        /// <summary>
        /// Gets a method that has no parameters and does not return a value.
        /// </summary>
        /// <returns></returns>
        public Action GetAction()
        {
            Action action = () => { Execute(); };
            return action;
        }

        /// <summary>
        /// Gets a method that has no parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <returns></returns>
        public Func<TReturn> GetFunc<TReturn>()
        {
            Func<TReturn> wrapper = () => { Execute(); return default(TReturn); };
            return wrapper;
        }

        /// <summary>
        /// Gets a method that has a single parameter and does not return a value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Action<T> GetAction<T>()
        {
            Action<T> action = (arg) => { Execute(); };
            return action;
        }

        /// <summary>
        /// Gets a method that has one parameter and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <returns></returns>
        public Func<T, TReturn> GetFunc<T, TReturn>()
        {
            Func<T, TReturn> wrapper = (arg) => { Execute(); return default(TReturn); };
            return wrapper;
        }

        private void Execute()
        {
            if (this._executeCount++ < this._failCount)
            {
                this._throwCount++;
                throw new Exception(string.Format(ExceptionMessageFormat, this._executeCount));
            }
        }
    }
}