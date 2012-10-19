using System;
using System.Threading;

namespace Retryable
{
    public static partial class Retry
    {
        /// <summary>
        /// Retries the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        public static void Execute(Action action, RetryPolicy retryPolicy)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }

            for (int i = 0; /*forever*/; i++)
            {
                try
                {
                    action();
                    return;
                }
                catch (Exception exception)
                {
                    if (!EvaluateRetryPolicyAndDelay(retryPolicy, i, exception))
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Requires one argument and no return value
        /// </summary>
        /// <typeparam name="T">The type of the parameter to the action.</typeparam>
        /// <param name="action">The action</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="arg">Argument to the action</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        public static void Execute<T>(Action<T> action, RetryPolicy retryPolicy, T arg)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }

            for (int i = 0; /*forever*/; i++)
            {
                try
                {
                    action(arg);
                    return;
                }
                catch (Exception exception)
                {
                    if (!EvaluateRetryPolicyAndDelay(retryPolicy, i, exception))
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Executes the specified function.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <returns></returns>
        public static TResult Execute<TResult>(Func<TResult> function, RetryPolicy retryPolicy)
        {
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }

            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }

            for (int i = 0; /*forever*/; i++)
            {
                try
                {
                    TResult result = function();
                    return result;
                }
                catch (Exception exception)
                {
                    if (!EvaluateRetryPolicyAndDelay(retryPolicy, i, exception))
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Executes the specified function.
        /// </summary>
        /// <typeparam name="T">The type of the the first argument.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="arg">Argument to the function.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        public static TResult Execute<T, TResult>(Func<T, TResult> function, RetryPolicy retryPolicy, T arg)
        {
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }

            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }

            for (int i = 0; /*forever*/; i++)
            {
                try
                {
                    TResult result = function(arg);
                    return result;
                }
                catch (Exception exception)
                {
                    if (!EvaluateRetryPolicyAndDelay(retryPolicy, i, exception))
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Checks the should retry and delay.
        /// </summary>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="retryCount">The retry count.</param>
        /// <param name="exception">The exception.</param>
        /// <returns>
        /// <c>true</c> if retry should occur, otherwise <c>false</c>.
        /// </returns>
        private static bool EvaluateRetryPolicyAndDelay(RetryPolicy retryPolicy, int retryCount, Exception exception)
        {
            ShouldRetry shouldRetry = retryPolicy();

            TimeSpan retryInterval;
            if (!shouldRetry(retryCount, exception, out retryInterval))
            {
                return false;
            }

            Thread.Sleep(retryInterval); // todo: can we delay async?
            return true;
        }
    }
}
