using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Common
{
    public class OperationResult
    {
        /// <summary>
        /// Set to <b>True</b> if request was executed successfully i.e. entity was saved, otherwise <b>False</b>:
        /// - Uncaught Exceptions (default service try/catch, Global Exception Handler)
        /// - Client version mismatch
        /// - Other fatal errors...
        /// <br/>
        /// <b>Client will not check success field, it uses Code property.</b>
        /// </summary>
        public bool Success => Code == OperationCode.Ok;

        /// <summary>
        /// Optional response message.
        /// </summary>
        public string Message { get; set; } = "Ok";

        /// <summary>
        /// Code represents detailed result of operation:
        /// - Error classification when Success == False (Unhandled Exception, Client Version Mismatch etc.)
        /// - Status classification when Success == True (i.e. removing file did not throw exceptions but file was not found which is OK)
        /// </summary>
        public OperationCode Code { get; set; }

        public OperationResult()
        {
            Code = OperationCode.Ok;
        }
        public OperationResult(OperationCode code, string message = null)
        {
            Message = message;
            Code = code;
        }

        public static OperationResult Ok() => new OperationResult();


        public static OperationResult Error(Exception e, OperationCode code = OperationCode.UnhandledError)
        {
            return new OperationResult(code, $" Message: {e.Message} +\r\n + StackTrace: {e.StackTrace} ");
        }

        public static OperationResult Error(string message = null, OperationCode code = OperationCode.UnhandledError)
        {
            return new OperationResult(code, message ?? "Error");
        }

        public static OperationResult<TObject> Error<TObject>(string message = null, OperationCode code = OperationCode.UnhandledError) where TObject : class
        {

            return new OperationResult<TObject>(code, message ?? "Error");
        }

    }

    public class OperationResult<TObject> : OperationResult where TObject : class
    {
        public TObject Object { get; set; }
        public OperationResult(OperationCode code, string message, TObject obj)
            : base(code, message)
        {
            Object = obj;
        }

        public OperationResult(OperationCode code, string message)
    : base(code, message)
        {
             Object = null;
        }

        public static OperationResult<TObject> Ok<TObject>(TObject obj) where TObject : class
        {
            return new(OperationCode.Ok, "Ok", obj);
        }
    }
}
