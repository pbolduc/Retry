
using System;

namespace Retryable.Tests
{
    public partial class Operations
	{
        /// <summary>
        /// Gets a method that has two parameters and does not return a value.
        /// </summary>
        public Action<T1, T2> GetAction<T1, T2>()
		{
            Action<T1, T2> action = (arg1, arg2) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has two parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, TReturn> GetFunc<T1, T2, TReturn>()
		{
            Func<T1, T2, TReturn> func = (arg1, arg2) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has three parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3> GetAction<T1, T2, T3>()
		{
            Action<T1, T2, T3> action = (arg1, arg2, arg3) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has three parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, TReturn> GetFunc<T1, T2, T3, TReturn>()
		{
            Func<T1, T2, T3, TReturn> func = (arg1, arg2, arg3) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has four parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4> GetAction<T1, T2, T3, T4>()
		{
            Action<T1, T2, T3, T4> action = (arg1, arg2, arg3, arg4) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has four parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, TReturn> GetFunc<T1, T2, T3, T4, TReturn>()
		{
            Func<T1, T2, T3, T4, TReturn> func = (arg1, arg2, arg3, arg4) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has five parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4, T5> GetAction<T1, T2, T3, T4, T5>()
		{
            Action<T1, T2, T3, T4, T5> action = (arg1, arg2, arg3, arg4, arg5) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has five parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, T5, TReturn> GetFunc<T1, T2, T3, T4, T5, TReturn>()
		{
            Func<T1, T2, T3, T4, T5, TReturn> func = (arg1, arg2, arg3, arg4, arg5) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has six parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6> GetAction<T1, T2, T3, T4, T5, T6>()
		{
            Action<T1, T2, T3, T4, T5, T6> action = (arg1, arg2, arg3, arg4, arg5, arg6) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has six parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, T5, T6, TReturn> GetFunc<T1, T2, T3, T4, T5, T6, TReturn>()
		{
            Func<T1, T2, T3, T4, T5, T6, TReturn> func = (arg1, arg2, arg3, arg4, arg5, arg6) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has seven parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6, T7> GetAction<T1, T2, T3, T4, T5, T6, T7>()
		{
            Action<T1, T2, T3, T4, T5, T6, T7> action = (arg1, arg2, arg3, arg4, arg5, arg6, arg7) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has seven parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, T5, T6, T7, TReturn> GetFunc<T1, T2, T3, T4, T5, T6, T7, TReturn>()
		{
            Func<T1, T2, T3, T4, T5, T6, T7, TReturn> func = (arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has eight parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6, T7, T8> GetAction<T1, T2, T3, T4, T5, T6, T7, T8>()
		{
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has eight parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> GetFunc<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>()
		{
            Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> func = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has nine parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> GetAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
		{
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has nine parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> GetFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>()
		{
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> func = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has ten parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> GetAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
		{
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has ten parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> GetFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>()
		{
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> func = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has eleven parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> GetAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
		{
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has eleven parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> GetFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn>()
		{
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> func = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has twelve parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> GetAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
		{
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has twelve parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> GetFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn>()
		{
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> func = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has thirteen parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> GetAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
		{
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has thirteen parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> GetFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn>()
		{
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> func = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has fourteen parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> GetAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
		{
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has fourteen parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> GetFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn>()
		{
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> func = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has fifteen parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> GetAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
		{
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has fifteen parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> GetFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn>()
		{
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> func = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) =>  { Execute(); return default(TReturn); };
            return func;
		}

        /// <summary>
        /// Gets a method that has sixteen parameters and does not return a value.
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> GetAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
		{
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) => { Execute(); };
            return action;
		}

        /// <summary>
        /// Gets a method that has sixteen parameters and returns a value of the type specified by the <typeparamref name="TReturn"/> parameter.
        /// </summary>
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn> GetFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn>()
		{
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn> func = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) =>  { Execute(); return default(TReturn); };
            return func;
		}

	}
}


