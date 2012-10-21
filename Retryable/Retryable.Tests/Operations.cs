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

        public Action GetAction()
        {
            Action action = () => this.Execute();
            return action;
        }

        public Action<T> GetAction<T>()
        {
            Action<T> action = (arg) => this.Execute();
            return action;
        }

        public Func<TReturn> GetFunc<TReturn>()
        {
            Func<TReturn> wrapper = () =>
            {
                this.Execute();
                return default(TReturn);
            };

            return wrapper;
        }

        public Func<T, TReturn> GetFunc<T, TReturn>()
        {
            Func<T, TReturn> wrapper = (arg) =>
            {
                this.Execute();
                return default(TReturn);
            };

            return wrapper;
        }

        protected void Execute()
        {
            if (this._executeCount++ < this._failCount)
            {
                this._throwCount++;
                throw new Exception(string.Format(ExceptionMessageFormat, this._executeCount));
            }
        }
    }
}