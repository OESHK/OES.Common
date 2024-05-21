namespace OES;

/// <summary>
/// Represents a request to delete an object from the server.
/// </summary>
public class DeleteObject
{
    internal DeleteObject(string id)
    {
        Id = id;
    }
    
    /// <summary>
    /// The ID of the object to be deleted.
    /// </summary>
    public string Id { get; }
}