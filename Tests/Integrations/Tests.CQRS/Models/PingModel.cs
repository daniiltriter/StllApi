using Stll.CQRS.Abstractions;

namespace Stll.Tests.CQRS.Models;

public class PingModel : IBusinessModel
{
    public string Content { get; set; }
}