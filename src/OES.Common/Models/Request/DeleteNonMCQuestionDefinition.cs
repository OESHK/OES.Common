namespace OES;

/// <summary>
/// An object representing a request to delete an existing <see cref="QuestionDefinition"/>.
/// </summary>
public class DeleteQuestionDefinition : DeleteObject
{
    internal DeleteQuestionDefinition(int scriptDefinitionId, string id) : base(id)
    {
        ScriptDefinitionId = scriptDefinitionId;
    }
    
    public int ScriptDefinitionId { get; }
}