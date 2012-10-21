using System;

namespace Retryable
{
    /// <summary>
    /// Determines whether a request should be retried.
    /// </summary>
    /// <param name="retryCount">The number of times the request has been retried.</param>
    /// <param name="exception">The exception raised by the most recent operation.</param>
    /// <param name="delay">An optional delay that specifies how long to wait before retrying a request.</param>
    /// <returns><c>true</c> if the request should be retried; otherwise, <c>false</c>.</returns>
    public delegate bool ShouldRetry(int retryCount, Exception exception, out TimeSpan delay);
}
