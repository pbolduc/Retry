using System;
using System.Threading;

namespace Retryable
{
    public static partial class Retry
    {
        /// <summary>
        /// Static instance to prevent creating dummy instances if the user did not supply an event.
        /// </summary>
        private static readonly ManualResetEventSlim NeverCancelled = new ManualResetEventSlim();

        /// <summary>
        /// Retries the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void Execute(Action action, RetryPolicy retryPolicy)
        {
            Execute(action, retryPolicy, NeverCancelled);
        }

        /// <summary>
        /// Retries the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void Execute(Action action, RetryPolicy retryPolicy, ManualResetEventSlim cancel)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }

            if (cancel == null)
            {
                throw new ArgumentNullException("cancel");
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
                    if (!EvaluateRetryPolicyAndDelay(retryPolicy, i, exception, cancel))
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T">The type of the parameter to the action.</typeparam>
        /// <param name="action">The action</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="arg">Argument to the action</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void Execute<T>(Action<T> action, RetryPolicy retryPolicy, T arg)
        {
            Execute(action, retryPolicy, NeverCancelled, arg);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T">The type of the parameter to the action.</typeparam>
        /// <param name="action">The action</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="arg">Argument to the action</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void Execute<T>(Action<T> action, RetryPolicy retryPolicy, ManualResetEventSlim cancel, T arg)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }

            if (cancel == null)
            {
                throw new ArgumentNullException("cancel");
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
                    if (!EvaluateRetryPolicyAndDelay(retryPolicy, i, exception, cancel))
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
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult Execute<TResult>(Func<TResult> function, RetryPolicy retryPolicy)
        {
            TResult result = Execute(function, retryPolicy, NeverCancelled);
            return result;
        }

        /// <summary>
        /// Executes the specified function.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult Execute<TResult>(Func<TResult> function, RetryPolicy retryPolicy, ManualResetEventSlim cancel)
        {
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }

            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }

            if (cancel == null)
            {
                throw new ArgumentNullException("cancel");
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
                    if (!EvaluateRetryPolicyAndDelay(retryPolicy, i, exception, cancel))
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
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult Execute<T, TResult>(Func<T, TResult> function, RetryPolicy retryPolicy, T arg)
        {
            TResult result = Execute(function, retryPolicy, NeverCancelled, arg);
            return result;
        }

        /// <summary>
        /// Executes the specified function.
        /// </summary>
        /// <typeparam name="T">The type of the the first argument.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <param name="arg">Argument to the function.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult Execute<T, TResult>(Func<T, TResult> function, RetryPolicy retryPolicy, ManualResetEventSlim cancel, T arg)
        {
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }

            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }

            if (cancel == null)
            {
                throw new ArgumentNullException("cancel");
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
                    if (!EvaluateRetryPolicyAndDelay(retryPolicy, i, exception, cancel))
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
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <returns>
        /// <c>true</c> if retry should occur, otherwise <c>false</c>.
        /// </returns>
        private static bool EvaluateRetryPolicyAndDelay(
            RetryPolicy retryPolicy, 
            int retryCount, 
            Exception exception,
            ManualResetEventSlim cancel)
        {
            ShouldRetry shouldRetry = retryPolicy();

            TimeSpan retryInterval;
            if (!shouldRetry(retryCount, exception, out retryInterval))
            {
                return false;
            }

            if (TimeSpan.Zero < retryInterval)
            {
                // todo: can we delay async?
                var signalled = cancel.Wait(retryInterval);
                if (signalled)
                {
                    return false;
                }
            }

            return !cancel.IsSet;
        }
    }
}
