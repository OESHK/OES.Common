using System.Net;
using OES.Internal;

namespace OES;

/// <summary>
/// A client for interacting with API endpoints for slice definitions.
/// </summary>
public class SliceDefinitionsClient : ApiClient
{
    internal SliceDefinitionsClient(ApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <summary>
    /// Creates a new <see cref="ScriptSlicingDefinition"/>.
    /// </summary>
    /// <param name="examinationId">The ID of its parent <see cref="Examination"/>.</param>
    /// <param name="scriptDefinitionId">The ID of its parent <see cref="ExaminationScriptDefinition"/>.</param>
    /// <param name="body">The request body.</param>
    /// <returns>The created <see cref="ScriptSlicingDefinition"/>.</returns>
    public Task<ScriptSlicingDefinition> Create(int examinationId, int scriptDefinitionId, CreateScriptSlicingDefinition body)
    {
        return ApiConnection.Post<ScriptSlicingDefinition>(
            ApiEndpoints.ScriptSliceDefinitions(examinationId, scriptDefinitionId), body);
    }

    /// <summary>
    /// Deletes an existing <see cref="ScriptSlicingDefinition"/> by its ID.
    /// </summary>
    /// <param name="examinationId">The ID of its parent <see cref="Examination"/>.</param>
    /// <param name="scriptDefinitionId">The ID of its parent <see cref="ExaminationScriptDefinition"/>.</param>
    /// <param name="sliceDefinitionId">The ID of the <see cref="ScriptSlicingDefinition"/>.</param>
    /// <returns></returns>
    public Task<HttpStatusCode> Delete(int examinationId, int scriptDefinitionId, int sliceDefinitionId)
    {
        return Connection.Delete(
            ApiEndpoints.ScriptSliceDefinitionById(examinationId, scriptDefinitionId, sliceDefinitionId));
    }

    /// <summary>
    /// Gets a specific <see cref="ScriptSlicingDefinition"/>
    /// </summary>
    /// <param name="examinationId">The ID of its parent <see cref="Examination"/>.</param>
    /// <param name="scriptDefinitionId">The ID of its parent <see cref="ExaminationScriptDefinition"/>.</param>
    /// <param name="sliceDefinitionId">The ID of the <see cref="ScriptSlicingDefinition"/>.</param>
    /// <returns>The requested <see cref="ScriptSlicingDefinition"/>.</returns>
    public Task<ScriptSlicingDefinition> Get(int examinationId, int scriptDefinitionId, int sliceDefinitionId)
    {
        return ApiConnection.Get<ScriptSlicingDefinition>(
            ApiEndpoints.ScriptSliceDefinitionById(examinationId, scriptDefinitionId, sliceDefinitionId));
    }

    /// <summary>
    /// Gets all <see cref="ScriptSlicingDefinition"/>s under the same <see cref="ExaminationScriptDefinition"/>.
    /// </summary>
    /// <param name="examinationId">The ID of its parent <see cref="Examination"/>.</param>
    /// <param name="scriptDefinitionId">The ID of its parent <see cref="ExaminationScriptDefinition"/>.</param>
    /// <returns>The list of required <see cref="ScriptSlicingDefinition"/>s.</returns>
    public Task<IReadOnlyCollection<ScriptSlicingDefinition>> GetAll(int examinationId, int scriptDefinitionId)
    {
        return ApiConnection.Get<IReadOnlyCollection<ScriptSlicingDefinition>>(
            ApiEndpoints.ScriptSliceDefinitions(examinationId, scriptDefinitionId));
    }
}