namespace OES.Internal;

internal interface IClient
{
    public ApiConnection ApiConnection { get; }
    
    public Connection Connection { get; }
}