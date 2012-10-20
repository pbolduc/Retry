using System.Diagnostics.Contracts;

namespace System.Data.SqlClient
{
    /// <summary>
    /// 
    /// </summary>
    public static class SqlExceptionExtensions
    {
        /// <summary>
        /// The service queue "x" is currently disabled.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>
        ///   <c>true</c> if the service queue is disabled; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsServiceQueueDisabled(this SqlException exception)
        {
            Contract.Requires(exception != null);

            // 9617 -> The service queue "%.*ls" is currently disabled.
            return exception.Number == 9617;
        }

        /// <summary>
        /// Determines whether the specified exception represents a login error.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>
        ///   <c>true</c> the specified exception represents a login error; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLoginError(this SqlException exception)
        {
            Contract.Requires(exception != null);

            // 4060 -> Cannot open database "%.*ls" requested by the login. The login failed.
            // 4064 -> Cannot open user default database. Login failed.
            // 18461 -> Login failed for user '%.*ls'. Reason: Server is in single user mode. Only one administrator can connect at this time.%.*ls
            return exception.Number == 4060 || exception.Number == 18461;
        }

        /// <summary>
        /// Determines whether the specified exception represents a connection error.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>
        ///   <c>true</c> if [is connection error] [the specified exception]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsConnectionError(this SqlException exception)
        {
            Contract.Requires(exception != null);

            return IsNamedPipeConnectionError(exception) ||
                   IsTcpIpConnectionError(exception);
        }

        /// <summary>
        /// Determines whether <see cref="SqlConnection"/> will be closed when this exception is raised.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>
        ///   <c>true</c> if <paramref name="exception"/> has severity 20 or higher; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// The SqlConnection remains open when the severity level is 19 or less.
        /// When the severity level is 20 or greater, the server ordinarily closes the SqlConnection.
        /// (source=http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlexception.aspx)
        /// </remarks>
        public static bool IsConnectionClosed(this SqlException exception)
        {
            Contract.Requires(exception != null);

            for (int i = 0; i < exception.Errors.Count; i++)
            {
                if (20 <= exception.Errors[i].Class)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified exception represents a database availability error.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>
        ///   <c>true</c> if [is database availability error] [the specified exception]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDatabaseAvailabilityError(this SqlException exception)
        {
            Contract.Requires(exception != null);
            // TODO: determine the error numbers that represent the database if offline
            return exception.Class == 20;
        }

        private static bool IsNamedPipeConnectionError(SqlException exception)
        {
            // See http://blogs.msdn.com/b/sql_protocols/archive/2007/05/16/named-pipes-provider-error-40-could-not-open-a-connection-to-sql-server-microsoft-sql-server-error-xxx.aspx
            return exception.Class == 20 && (
                                                exception.Number == 2 ||    // The system cannot find the file specified
                                                exception.Number == 53 ||   // The network path was not found
                                                exception.Number == 233 ||  // No process is on the other end of the pipe
                                                false);
        }

        private static bool IsTcpIpConnectionError(SqlException exception)
        {
            return exception.Class == 20 && (
                                                exception.Number == 64 ||       // A connection was successfully established with the server, but then an error occurred during the login process. (provider: TCP Provider, error: 0 - The specified network name is no longer available.)
                                                exception.Number == 10053 ||    // ConnectionAborted - A connection was successfully established with the server, but then an error occurred during the login process. (provider: TCP Provider, error: 0 - An established connection was aborted by the software in your host machine.)
                                                exception.Number == 10054 ||    // ConnectionReset
                                                exception.Number == 10061 ||    // ConnectionRefused
                                                false);
        }
    }
}