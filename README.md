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
	
	Action action = () => { /* some action to retry */ };
    action.InvokeWithRetry(noRetryPolicy);

Simple example with 100ms delay between retries with up to 5 retries:

    RetryPolicy simpleRetryPolicy = () =>
    {
        return (int retryCount, Exception exception, out TimeSpan retryInterval) =>
        {
            retryInterval = TimeSpan.FromMilliseconds(100);
            return retryCount < 5;
        };
    };

	Action action = () => { /* some action to retry */ };
    action.InvokeWithRetry(simpleRetryPolicy);

	Func<int> func = () => { /* some action to retry */ return 0; };
    int result = func.InvokeWithRetry(simpleRetryPolicy);

You can also provide an ManualResetEventSlim to cancel any wait and throw the last error:

	SqlConnection connection = ...
    // try to open a connection to the database 	
	Action action = connection.Open;
    ManualResetEventSlim cancel = new ManualResetEventSlim(false);
    action.InvokeWithRetry(retryPolicy, cancel);
	
	// on another thread, cancel any current executing wait
	cancel.Set();