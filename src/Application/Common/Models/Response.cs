using System.Collections.Generic;
using System.Net;

namespace Application.Common.Models;

public interface IResponse<TData>
{
    public TData Data { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
    public IResponse<TData> Ok(TData data);
    public IResponse<TData> Failure(string errorMessage);
}
public interface IResponse
{
    public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
    public IResponse Ok();
    public IResponse Failure(string errorMessage);
}


public class Response<TData> : IResponse<TData>
{
    public Response(HttpStatusCode httpStatusCode = HttpStatusCode.OK)
    {
        this.HttpStatusCode = httpStatusCode;

    }

    public Response(TData data, string error = default!)
    {
        Data = data;
        ErrorMessage = error;

    }
    public TData Data { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }

    public IResponse<TData> Failure(string errorMessage)
    {
        ErrorMessage = errorMessage;
        IsSuccess = false;
        return this;
    }

    public IResponse<TData> Ok(TData data)
    {
        Data = data;
        IsSuccess = true;
        return this;
    }
}
public class Response : IResponse
{
    public Response(HttpStatusCode httpStatusCode = HttpStatusCode.OK)
    {
        HttpStatusCode = httpStatusCode;

    }
    public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
    public IResponse Failure(string errorMessage)
    {
        ErrorMessage = errorMessage;
        IsSuccess = false;
        return this;
    }

    public IResponse Ok()
    {
        IsSuccess = true;
        return this;
    }
}