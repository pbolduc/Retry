using System;
using System.Diagnostics.Contracts;
using WaitEvent = System.Threading.ManualResetEventSlim;
////using WaitEvent = System.Threading.ManualResetEvent;

namespace Retryable
{
    public static partial class RetryExtensions
    {

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2>(this Action<T1, T2> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2>(this Action<T1, T2> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, TResult>(this Func<T1, T2, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, TResult>(this Func<T1, T2, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3>(this Action<T1, T2, T3> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3>(this Action<T1, T2, T3> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4, arg5); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4, arg5);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4, arg5, arg6); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4, arg5, arg6);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4, arg5, arg6, arg7); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg15">The fifteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg15">The fifteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg15">The fifteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg15">The fifteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T16">The type of the sixteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg15">The fifteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg16">The sixteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);

		    InvokeWithRetry(action, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
		}

        /// <summary>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T16">The type of the sixteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg15">The fifteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg16">The sixteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static void InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
		{
            Contract.Requires(action != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

            Func<int> wrapper = () => { action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16); return 0; };
            int zero = InvokeWithRetry(wrapper, retryPolicy, cancel);
	    }

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T16">The type of the sixteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg15">The fifteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg16">The sixteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);

		    TResult result = InvokeWithRetry(function, retryPolicy, CanNotCancel, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
			return result;
		}

        /// <summary>
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="cancel">An event if set, will cancel waiting.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the nineth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T16">The type of the sixteenth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg9">The nineth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg15">The fifteenth parameter of the method that this delegate encapsulates.</param>
        /// <param name="arg16">The sixteenth parameter of the method that this delegate encapsulates.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> or <paramref name="retryPolicy"/> is null.
        /// </exception>
        /// <returns></returns>
        /// <remarks>
        /// This method will block the current thread while retrying.
        /// </remarks>
        public static TResult InvokeWithRetry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function, RetryPolicy retryPolicy, WaitEvent cancel, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            Contract.Requires(function != null);
            Contract.Requires(retryPolicy != null);
            Contract.Requires(cancel != null);

		    Func<TResult> wrapper = () => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
            return InvokeWithRetry(wrapper, retryPolicy, cancel);
        }		
    }
}

