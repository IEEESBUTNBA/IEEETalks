//using FluentValidation.Results;

//namespace IEEETalks.CQS.Infrastructure.CommandProcessor
//{
//    public class CommandResult : ICommandResult
//    {
//        public ValidationResult ValidationResult { get; }

//        public bool Success { get; protected set; }

//        public CommandResult(ValidationResult result)
//        {
//            this.Success = result.IsValid;
//            this.ValidationResult = result;
//        }

//        public CommandResult(bool success)
//        {
//            this.Success = success;
//        }
//    }
//}