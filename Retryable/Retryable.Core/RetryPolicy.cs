namespace Retryable
{
    /// <summary>
    /// Returns a delegate that implements a custom retry policy.
    /// </summary>
    /// <returns>A delegate that determines whether or not to retry an operation.</returns>
    public delegate ShouldRetry RetryPolicy();
}
