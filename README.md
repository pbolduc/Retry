Retry
=====

Library to assist implementing application retry logic.  RetryPolicy/ShouldRetry taken
from Windows Azure SDK for .NET (https://github.com/WindowsAzure/azure-sdk-for-net)

    RetryPolicy noRetryPolicy = () => 
    {
	    return (int retryCount, Exception exception, out TimeSpan retryInterval)
		{
		    retryInterval = TimeSpan.Zero;
			return false;
		};
	};

    Retry.Execute(() => { /* some action to retry }, noRetryPolicy);
