using System.Runtime.CompilerServices;

namespace Types.Models
{
    public class ExecutionResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public static ExecutionResult CreateErrorResult(string errorMessage)
        {
            return new ExecutionResult()
            {
                ErrorMessage = errorMessage,
                IsSuccess = false
            };
        }
        
        public static ExecutionResult CreateSuccessResult()
        {
            return new ExecutionResult()
            {
                IsSuccess = true
            };
        }
    }
}