using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// A request to create a new examination script definition.
/// </summary>
public class CreateExaminationScriptDefinition
{
    /// <summary>
    /// Create a new examination script definition request.
    /// </summary>
    public CreateExaminationScriptDefinition(
        int                                   examinationId,
        ExaminationScriptType                 examinationScriptType,
        ExaminationScriptSize                 examinationScriptSize,
        int                                   scriptSheetCount,
        IReadOnlyDictionary<int, ImageMargin> candidateBarcodesMargins,
        ImageMargin                           scriptBarcodeMargin,
        string                                scriptBarcode
        )
    {
        ExaminationId            = examinationId;
        ExaminationScriptType    = examinationScriptType;
        ExaminationScriptSize    = examinationScriptSize;
        ScriptSheetCount         = scriptSheetCount;
        CandidateBarcodesMargins = candidateBarcodesMargins;
        ScriptBarcodeMargin      = scriptBarcodeMargin;
        ScriptBarcode            = scriptBarcode;
    }

    /// <summary>
    /// Create a new examination script definition request with an existing examination.
    /// </summary>
    /// <param name="examination">The examination to which the script definition belongs.</param>
    /// <param name="examinationScriptType"></param>
    /// <param name="examinationScriptSize"></param>
    /// <param name="scriptSheetCount"></param>
    /// <param name="candidateBarcodesMargins"></param>
    /// <param name="scriptBarcodeMargin"></param>
    /// <param name="scriptBarcode"></param>
    public CreateExaminationScriptDefinition(
        Examination                           examination,
        ExaminationScriptType                 examinationScriptType,
        ExaminationScriptSize                 examinationScriptSize,
        int                                   scriptSheetCount,
        IReadOnlyDictionary<int, ImageMargin> candidateBarcodesMargins,
        ImageMargin                           scriptBarcodeMargin,
        string                                scriptBarcode)
        : this(
            examination.ExaminationId,
            examinationScriptType,
            examinationScriptSize,
            scriptSheetCount,
            candidateBarcodesMargins,
            scriptBarcodeMargin,
            scriptBarcode
        )
    {
    }

    /// <inheritdoc cref="ExaminationScriptDefinition.ExaminationId"/>
    [JsonIgnore]
    public int ExaminationId { get; set; }
    
    /// <inheritdoc cref="ExaminationScriptDefinition.ScriptType"/>
    public ExaminationScriptType ExaminationScriptType { get; set; }
    
    /// <inheritdoc cref="ExaminationScriptDefinition.ScriptSize"/>
    public ExaminationScriptSize ExaminationScriptSize { get; set; }
    
    /// <inheritdoc cref="ExaminationScriptDefinition.ScriptSheetCount"/>
    public int ScriptSheetCount { get; set; }
    
    /// <inheritdoc cref="ExaminationScriptDefinition.CandidateBarcodesMargins"/>
    [JsonConverter(typeof(IntImageMarginDictJsonConverter))]
    [JsonProperty("candidate_barcode_range")]
    public IReadOnlyDictionary<int, ImageMargin> CandidateBarcodesMargins { get; set; }
    
    /// <inheritdoc cref="ExaminationScriptDefinition.ScriptBarcodeMargin"/>
    [JsonProperty("script_barcode_range")]
    public ImageMargin ScriptBarcodeMargin { get; set; }
    
    /// <inheritdoc cref="ExaminationScriptDefinition.ScriptBarcode"/>
    public string ScriptBarcode { get; set; }
}