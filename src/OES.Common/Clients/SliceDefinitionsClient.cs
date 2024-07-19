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
}