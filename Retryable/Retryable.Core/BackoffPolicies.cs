using System;

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
        /// <param name="minimumDelay">The minimum delay.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="retryCount"/>, <paramref name="minimumDelay"/> or
        /// <paramref name="maximumDelay"/> are less then zero.
        /// </exception>
        /// <returns></returns>
        public static TimeSpan RandomExponential(int retryCount, int minimumDelay, int maximumDelay)
        {
            if (retryCount < 0)
            {
                throw new ArgumentOutOfRangeException("retryCount", retryCount, "Parameter retryCount cannot be less than zero.");
            }

            if (minimumDelay < 0)
            {
                throw new ArgumentOutOfRangeException("minimumDelay", minimumDelay, "Parameter minimumDelay cannot be less than zero.");
            }

            if (maximumDelay < 0)
            {
                throw new ArgumentOutOfRangeException("maximumDelay", maximumDelay, "Parameter maximumDelay cannot be less than zero.");
            }

            // Seed the random number generator with new guid. This helps to prevent
            // a 'thundering herd' of retries when a services becomes available.
            Random random = new Random(Guid.NewGuid().GetHashCode());

            // Using power of two, the delays will be:
            // Retry   Min   Max
            //   0       0     1
            //   1       1     4
            //   2       4     9
            //   3       9    16
            //   4      16    25
            //   5      25    36
            //   6      36    49
            //   7      49    64
            //   8      64    81
            //   9      81   100
            //  10     100   121
            int milliseconds = random.Next((int)Math.Pow(retryCount, 2) + minimumDelay, (int)Math.Pow(retryCount + 1, 2) + 1 + minimumDelay);
            if (milliseconds > maximumDelay)
            {
                milliseconds = maximumDelay;
            }

            return TimeSpan.FromMilliseconds(milliseconds);
        }

        /// <summary>
        /// Computes a linearly increasing delay based on the number of retries.
        /// Randomization is added to avoid a 'thundering herd' of retries when
        /// the service becomes available.
        /// </summary>
        /// <param name="retryCount">The retry count.</param>
        /// <param name="delay">The delay.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="retryCount"/> or <paramref name="maximumDelay"/> are less then zero, or
        /// <paramref name="delay"/> is less than or equal to zero.
        /// </exception>
        /// <returns></returns>
        public static TimeSpan Linear(int retryCount, int delay, int maximumDelay)
        {
            if (retryCount < 0)
            {
                throw new ArgumentOutOfRangeException("retryCount", retryCount, "Parameter retryCount cannot be less than zero.");
            }

            if (delay <= 0)
            {
                throw new ArgumentOutOfRangeException("delay", delay, "Parameter delay cannot be less than or equal to zero.");
            }

            if (maximumDelay < 0)
            {
                throw new ArgumentOutOfRangeException("maximumDelay", maximumDelay, "Parameter maximumDelay cannot be less than zero.");
            }

            int milliseconds = (retryCount + 1) * delay;
            if (milliseconds > maximumDelay)
            {
                milliseconds = maximumDelay;
            }

            return TimeSpan.FromMilliseconds(milliseconds);
        }
    }
}
