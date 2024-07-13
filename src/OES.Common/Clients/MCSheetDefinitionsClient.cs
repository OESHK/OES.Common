using System.Net;
using OES.Internal;

namespace OES;

/// <summary>
/// A client for interacting with API endpoints for MC sheet definitions.
/// </summary>
public class MCSheetDefinitionsClient : ApiClient
{
    internal MCSheetDefinitionsClient(ApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <summary>
    /// Creates a new <see cref="MCSheetDefinition"/>.
    /// </summary>
    /// <param name="body">The request body.</param>
    /// <returns>The created <see cref="MCSheetDefinition"/>.</returns>
    public Task<MCSheetDefinition> Create(CreateMCSheetDefinition body)
    {
        return ApiConnection.Post<MCSheetDefinition>(ApiEndpoints.MCSheetDefinition(body.ScriptDefinitionId), body);
    }

    /// <summary>
    /// Deletes an existing <see cref="MCSheetDefinition"/>.
    /// </summary>
    /// <param name="delObj">The request body.</param>
    /// <returns>The status of the request.</returns>
    public Task<HttpStatusCode> Delete(DeleteObject delObj)
    {
        return Connection.Delete(ApiEndpoints.MCSheetDefinition(int.Parse(delObj.Id)));
    }

    /// <summary>
    /// Gets an <see cref="MCSheetDefinition"/>.
    /// </summary>
    /// <param name="scriptDefinitionId">The ID of the <see cref="ExaminationScriptDefinition"/>. Must be
    /// of type <see cref="ExaminationScriptType.MCSheet"/>.</param>
    /// <returns>The requested <see cref="MCSheetDefinition"/>.</returns>
    public Task<MCSheetDefinition> Get(int scriptDefinitionId)
    {
        return ApiConnection.Get<MCSheetDefinition>(ApiEndpoints.MCSheetDefinition(scriptDefinitionId));
    }
}