using System;
using System.Diagnostics.Contracts;

using WaitEvent = System.Threading.ManualResetEventSlim;
////using WaitEvent = System.Threading.ManualResetEvent;

namespace Retryable
{
    public static partial class RetryExtensions
    {
        /// <summary>
        /// Static instance to prevent creating dummy instances if the user did not supply an event.
        /// </summary>
        private static readonly WaitEvent CanNotCancel = new WaitEvent(false);

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
        public static void InvokeWithRetry(this Action action, RetryPolicy retryPolicy)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

            InvokeWithRetry(action, retryPolicy, CanNotCancel);
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
        public static void InvokeWithRetry(this Action action, RetryPolicy retryPolicy, WaitEvent cancel)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(); return 0; };
            InvokeWithRetry(wrapper, retryPolicy, cancel);
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
        public static void InvokeWithRetry<T>(this Action<T> action, RetryPolicy retryPolicy, T arg)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

            InvokeWithRetry(action, retryPolicy, CanNotCancel, arg);
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
        public static void InvokeWithRetry<T>(this Action<T> action, RetryPolicy retryPolicy, WaitEvent cancel, T arg)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg); return 0; };
            InvokeWithRetry(wrapper, retryPolicy, cancel);
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
        public static TResult InvokeWithRetry<TResult>(this Func<TResult> function, RetryPolicy retryPolicy)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

            TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel);
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
        public static TResult InvokeWithRetry<TResult>(this Func<TResult> function, RetryPolicy retryPolicy, WaitEvent cancel)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            TResult result = RetryImpl(function, retryPolicy, cancel);
            return result;
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
        public static TResult InvokeWithRetry<T, TResult>(this Func<T, TResult> function, RetryPolicy retryPolicy, T arg)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

            TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg);
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
        public static TResult InvokeWithRetry<T, TResult>(this Func<T, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T arg)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<TResult> wrapper = () => function(arg);

            TResult result = RetryImpl(wrapper, retryPolicy, cancel);
            return result;
        }

        private static TResult RetryImpl<TResult>(this Func<TResult> function, RetryPolicy retryPolicy, WaitEvent cancel)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

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
            WaitEvent cancel)
        {
            Contract.Requires(retryPolicy != null);
            Contract.Requires(0 <= retryCount);
            Contract.Requires(exception != null);
            Contract.Requires(cancel != null);

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
