using Automarket.Domain.Enum;

namespace Automarket.Domain.Response;

public class BaseResponse<T> : IBaseResponse<T>
{
    public string Description { get; set; }
    
    public StatusCode StatusCode { get; set; }
    
    public T Data { get; set; }
    
    
}
public interface IBaseResponse<T>
{
    T Data { get; set; }
    StatusCode StatusCode { get; set; }
}