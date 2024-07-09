using OES.Internal;

namespace OES;

/// <summary>
/// A client for interacting with API endpoints for examination script definitions.
/// </summary>
public class ExaminationScriptDefinitionsClient : ApiClient
{
    public ExaminationScriptDefinitionsClient(ApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <summary>
    /// Creates a new <see cref="ExaminationScriptDefinition"/>.
    /// </summary>
    /// <param name="body">The request body.</param>
    /// <returns>The created <see cref="ExaminationScriptDefinition"/>.</returns>
    public Task<ExaminationScriptDefinition> Create(CreateExaminationScriptDefinition body)
    {
        return ApiConnection.Post<ExaminationScriptDefinition>(ApiEndpoints.ExamScriptDefinitions(), body);
    }
}