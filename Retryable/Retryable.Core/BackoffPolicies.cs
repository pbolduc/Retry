using System;
using System.Diagnostics.Contracts;

namespace Retryable
{
    /// <summary>
    /// </summary>
    public static class BackoffPolicies
    {
        /// <summary>
        /// Computes an exponentially increasing delay based on the number of retries.
        /// Randomization is added to avoid a 'thundering herd' of retries when
        /// the service becomes available.
        /// </summary>
        /// <param name="retryCount">The retry count.</param>
        /// <param name="minBackoff">The minimum delay.</param>
        /// <param name="maxBackoff">The maximum delay.</param>
        /// <param name="deltaBackoff"></param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="retryCount"/>, <paramref name="minBackoff"/> or
        /// <paramref name="maxBackoff"/> are less then zero.
        /// </exception>
        /// <returns>
        /// A randomized timeout value based on the retry count. 
        /// </returns>
        public static TimeSpan RandomExponential(int retryCount, TimeSpan minBackoff, TimeSpan maxBackoff, TimeSpan deltaBackoff)
        {
            Contract.Requires(0 <= retryCount);
            Contract.Requires(TimeSpan.Zero <= minBackoff && minBackoff <= TimeSpan.MaxValue);
            Contract.Requires(TimeSpan.Zero <= maxBackoff && maxBackoff <= TimeSpan.MaxValue);
            Contract.Requires(TimeSpan.Zero <= deltaBackoff && deltaBackoff <= TimeSpan.MaxValue);

            Contract.Ensures(TimeSpan.Zero <= Contract.Result<TimeSpan>());

            // Seed the random number generator with new guid. This helps to prevent
            // a 'thundering herd' of retries when a service becomes available again.
            Random r = new Random(Guid.NewGuid().GetHashCode());

            double increment = (Math.Pow(2, retryCount) - 1) * r.Next(
                        (int)(deltaBackoff.TotalMilliseconds * 0.8), 
                        (int)(deltaBackoff.TotalMilliseconds * 1.2));
            int timeToSleepMsec = (int)Math.Min(minBackoff.TotalMilliseconds + increment, maxBackoff.TotalMilliseconds);

            TimeSpan retryInterval = TimeSpan.FromMilliseconds(timeToSleepMsec);
            return retryInterval;
        }

        /// <summary>
        /// Computes a linearly increasing delay based on the number of retries.
        /// Randomization is added to avoid a 'thundering herd' of retries when
        /// the service becomes available.
        /// </summary>
        /// <param name="retryCount">The retry count.</param>
        /// <param name="minBackoff"></param>
        /// <param name="maxBackoff"></param>
        /// <param name="deltaBackoff"></param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="retryCount"/>, <paramref name="maxBackoff"/> 
        /// are less then zero, or
        /// <paramref name="delay"/> is less than or equal to zero.
        /// </exception>
        /// <returns></returns>
        public static TimeSpan Linear(int retryCount, TimeSpan minBackoff, TimeSpan maxBackoff, TimeSpan deltaBackoff)
        {
            Contract.Requires(0 <= retryCount);
            Contract.Requires(TimeSpan.Zero <= minBackoff && minBackoff <= TimeSpan.MaxValue);
            Contract.Requires(TimeSpan.Zero <= maxBackoff && maxBackoff <= TimeSpan.MaxValue);
            Contract.Requires(TimeSpan.Zero <= deltaBackoff && deltaBackoff <= TimeSpan.MaxValue);

            Contract.Ensures(TimeSpan.Zero <= Contract.Result<TimeSpan>());

            double increment = retryCount * deltaBackoff.TotalMilliseconds;
            int timeToSleepMsec = (int)Math.Min(minBackoff.TotalMilliseconds + increment, maxBackoff.TotalMilliseconds);

            TimeSpan retryInterval = TimeSpan.FromMilliseconds(timeToSleepMsec);
            return retryInterval;
        }
    }
}
