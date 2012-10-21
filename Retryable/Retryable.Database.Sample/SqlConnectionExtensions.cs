using System;
using System.Data.SqlClient;

namespace Retryable.Database.Sample
{
    public static class SqlConnectionExtensions
    {
        public static void OpenWithRetry(this SqlConnection connection)
        {
            Action action = connection.Open;

            SqlConnectionOpenRetryPolicy policy = new SqlConnectionOpenRetryPolicy(TimeSpan.FromSeconds(60));

            action.InvokeWithRetry(policy.RetryPolicy());
        }
    }
}