using System;

namespace Retryable
{
    public static partial class RetryableAction
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
        public static void Execute<T1, T2>(Action<T1, T2> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2)
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
                    action(arg1, arg2);
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
        public static TResult Execute<T1, T2, TResult>(Func<T1, T2, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2)
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
                    TResult result = function(arg1, arg2);
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
        public static void Execute<T1, T2, T3>(Action<T1, T2, T3> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3)
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
                    action(arg1, arg2, arg3);
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
        public static TResult Execute<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3)
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
                    TResult result = function(arg1, arg2, arg3);
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
        public static void Execute<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
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
                    action(arg1, arg2, arg3, arg4);
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
        public static TResult Execute<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
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
                    TResult result = function(arg1, arg2, arg3, arg4);
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
        public static void Execute<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
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
                    action(arg1, arg2, arg3, arg4, arg5);
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
        public static TResult Execute<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
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
                    TResult result = function(arg1, arg2, arg3, arg4, arg5);
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
        public static void Execute<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
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
                    action(arg1, arg2, arg3, arg4, arg5, arg6);
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
        public static TResult Execute<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
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
                    TResult result = function(arg1, arg2, arg3, arg4, arg5, arg6);
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
        public static void Execute<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
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
                    action(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
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
        public static TResult Execute<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
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
                    TResult result = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
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
        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
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
                    action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
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
        public static TResult Execute<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
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
                    TResult result = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
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
        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
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
                    action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
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
        public static TResult Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
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
                    TResult result = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
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
        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
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
                    action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
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
        public static TResult Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
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
                    TResult result = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
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
        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
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
                    action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
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
        public static TResult Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
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
                    TResult result = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
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
        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
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
                    action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
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
        public static TResult Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
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
                    TResult result = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
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
        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
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
                    action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
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
        public static TResult Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
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
                    TResult result = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
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
        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
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
                    action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
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
        public static TResult Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
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
                    TResult result = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
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
        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
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
                    action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
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
        public static TResult Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
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
                    TResult result = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
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
        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
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
                    action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
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
        public static TResult Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function, RetryPolicy retryPolicy, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
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
                    TResult result = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
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
    }
}

