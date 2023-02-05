using System.Collections.Generic;

namespace Application.Common.Models;

public interface IServiceResult<TData>
{
    public TData Data { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }

    public IServiceResult<TData> Ok(TData data);
    public IServiceResult<TData> Failure(string errorMessage);
}
public interface IServiceResult
{
    public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }

    public IServiceResult Ok();
    public IServiceResult Failure(string errorMessage);
}


public class ServiceResult<TData> : IServiceResult<TData>
{
    public ServiceResult()
    {
    }

    public ServiceResult(TData data,string error =default!)
    {
        Data = data;
        ErrorMessage = error;

    }
    public TData Data { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }

    public IServiceResult<TData> Failure(string errorMessage)
    {
        ErrorMessage = errorMessage;
        IsSuccess = false;
        return this;
    }

    public IServiceResult<TData> Ok(TData data)
    {
        Data = data;
        IsSuccess = true;
        return this;
    }
}
public class ServiceResult : IServiceResult
{
    public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }

    public IServiceResult Failure(string errorMessage)
    {
        ErrorMessage = errorMessage;
        IsSuccess = false;
        return this;
    }

    public IServiceResult Ok()
    {
        IsSuccess = true;
        return this;
    }
}