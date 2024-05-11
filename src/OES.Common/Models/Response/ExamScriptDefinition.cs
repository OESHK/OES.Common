namespace OES;

/// <summary>
/// Defines an answer booklet of an examination. This does not represent any specific booklet of an candidate,
/// but contains settings for how to read candidates' answer scripts.
/// </summary>
public class ExamScriptDefinition
{
    /// <summary>
    /// Creates an instance for ExamScriptDefinition
    /// </summary>
    public ExamScriptDefinition(
        int id, 
        int examId,
        ExamScriptType scriptType,
        ExamScriptSize scriptSize,
        int sheetCount,
        Dictionary<int, ImageMargin> candidateBarcodesMargins,
        ImageMargin scriptBarcodeMargins, 
        string scriptBarcode
        )
    {
        DefinitionId = id;
        ExamId = examId;
        ScriptType = scriptType;
        ScriptSize = scriptSize;
        SheetCount = sheetCount;
        CandidateBarcodesMargins = candidateBarcodesMargins;
        ScriptBarcodeMargins = scriptBarcodeMargins;
        ScriptBarcode = scriptBarcode;
    }

    /// <summary>
    /// The ID of this definition.
    /// </summary>
    public int DefinitionId { get; }
    
    /// <summary>
    /// The ID of the exam to which this definition belongs.
    /// </summary>
    public int ExamId { get; }
    
    /// <summary>
    /// The type of script.
    /// </summary>
    public ExamScriptType ScriptType { get; }
    
    /// <summary>
    /// The size of script images.
    /// </summary>
    public ExamScriptSize ScriptSize { get; }
    
    /// <summary>
    /// The number of sheets of papers of the script.
    /// </summary>
    public int SheetCount { get; }
    
    /// <summary>
    /// The margins of candidate's barcodes on each page.
    /// </summary>
    public Dictionary<int, ImageMargin> CandidateBarcodesMargins { get; }
    
    /// <summary>
    /// The margins of the examination script's barcode. Must be on first page.
    /// </summary>
    public ImageMargin ScriptBarcodeMargins { get; }
    
    /// <summary>
    /// The expected barcode value of the script barcode.
    /// </summary>
    public string ScriptBarcode { get; }
}