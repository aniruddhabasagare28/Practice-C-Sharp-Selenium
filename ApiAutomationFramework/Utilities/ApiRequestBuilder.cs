using RestSharp;
using System.Collections.Generic;

public class RequestBuilder
{
    private RestRequest _request;

    public RequestBuilder(string resource, Method method)
    {
        _request = new RestRequest(resource, method);
    }

    public RequestBuilder AddHeader(string name, string value)
    {
        _request.AddHeader(name, value);
        return this;
    }

    public RequestBuilder AddParameter(string name, object value, ParameterType type = ParameterType.QueryString)
    {
        _request.AddParameter(name, value, type);
        return this;
    }

    public RequestBuilder AddJsonBody(object body)
    {
        _request.AddJsonBody(body);
        return this;
    }

    public RestRequest Build()
    {
        return _request;
    }
}
