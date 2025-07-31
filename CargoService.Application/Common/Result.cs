namespace CargoService.Application.Common
{
    public class Result<T>
    {
        public bool Success { get; private set; }
        public string? Message { get; private set; }
        public T? Value { get; private set; }
        public List<ValidationError>? Errors { get; private set; }

        public bool IsFailure => !Success;

        private Result() { }

        public static Result<T> SuccessResult(T? value)
        {
            return new Result<T>
            {
                Success = true,
                Value = value
            };
        }

        public static Result<T> FailureResult(string message, List<ValidationError>? errors = null)
        {
            return new Result<T>
            {
                Success = false,
                Message = message,
                Errors = errors
            };
        }

        public static Result<T> NotFoundResult(int? id = null)
        {
            return new Result<T>
            {
                Success = false,
                Message = $"Entry with Id {id} not found."
            };
        }

        public static Result<T> EmptyResult(string? entity = null)
        {
            return new Result<T>
            {
                Success = false,
                Message = $"The list of entity {entity} is empty."
            };
        }
    }
}
