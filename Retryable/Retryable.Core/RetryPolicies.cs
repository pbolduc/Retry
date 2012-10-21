using System;
using System.Diagnostics.Contracts;

namespace Retryable
{
    public static class RetryPolicies
    {
        /// <summary>
        /// Returns a retry policy that will not retry.
        /// </summary>
        /// <returns>The retry policy.</returns>
        public static RetryPolicy NoRetry()
        {
            Contract.Ensures(Contract.Result<RetryPolicy>() != null);

            return () =>
            {
                return (int retryCount, Exception exception, out TimeSpan retryInterval) =>
                {
                    retryInterval = TimeSpan.Zero;
                    return false;
                };
            };
        }
    }
}
