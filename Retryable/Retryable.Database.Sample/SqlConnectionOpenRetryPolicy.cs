using System;
using System.Data.SqlClient;

namespace Retryable.Database.Sample
{
    public class SqlConnectionOpenRetryPolicy
    {
        public static readonly TimeSpan MinBackoff = TimeSpan.FromSeconds(0.5);
        public static readonly TimeSpan MaxBackoff = TimeSpan.FromSeconds(30);
        public static readonly TimeSpan BackoffIncrement = TimeSpan.FromSeconds(1);

        private TimeSpan retryDuration;
        private DateTime start;

        public SqlConnectionOpenRetryPolicy(TimeSpan retryFor)
        {
            if (retryFor <= TimeSpan.Zero) throw new ArgumentOutOfRangeException("retryFor");

            retryDuration = retryFor;
        }

        public RetryPolicy RetryPolicy()
        {
            this.start = DateTime.UtcNow;
            return () => this.Oracle;            
        }

        protected bool DontRetry(out TimeSpan retryInterval)
        {
            retryInterval = TimeSpan.Zero;
            return false;
        }

        private bool Oracle(int retryCount, Exception exception, out TimeSpan retryInterval)
        {
            // we will try as long as we haven't been retrying too long
            if (retryDuration < DateTime.UtcNow.Subtract(start))
            {
                return DontRetry(out retryInterval);
            }

            // was the failure caused by SqlException?
            SqlException sqlException = exception as SqlException;
            if (sqlException == null)
            {
                return DontRetry(out retryInterval);
            }

            // is it a connection error?
            if (!sqlException.IsConnectionError())
            {
                return DontRetry(out retryInterval);
            }

            retryInterval = BackoffPolicies.RandomExponential(retryCount, MinBackoff, MaxBackoff, BackoffIncrement);
            return true; // retry
        }
    }
}
