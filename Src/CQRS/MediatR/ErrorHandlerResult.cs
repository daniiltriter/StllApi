using Stll.CQRS.Abstractions;

namespace Stll.WebAPI.Commands;

public class ErrorHandlerResult : AbstractHandlerResult
{
   public static ErrorHandlerResult Create(string error) => new()
   {
      Error = error,
      Processed = false
   };
}