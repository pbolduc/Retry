Retry
=====

Library to assist implementing application retry logic.  RetryPolicy/ShouldRetry taken
from Windows Azure SDK for .NET (https://github.com/WindowsAzure/azure-sdk-for-net).

More samples will be added to the source code.

Simple example with no retry:

    RetryPolicy noRetryPolicy = () =>
    {
        return (int retryCount, Exception exception, out TimeSpan retryInterval) =>
        {
            retryInterval = TimeSpan.Zero;
            return false;
        };
    };

    Retry.Execute(() => { /* some action to retry */ }, noRetryPolicy);

Simple example with 100ms delay between retries with up to 5 retries:

    RetryPolicy simpleRetryPolicy = () =>
    {
        return (int retryCount, Exception exception, out TimeSpan retryInterval) =>
        {
            retryInterval = TimeSpan.FromMilliseconds(100);
            return retryCount < 5;
        };
    };

    Retry.Execute(() => { /* some action to retry */ }, simpleRetryPolicy);
