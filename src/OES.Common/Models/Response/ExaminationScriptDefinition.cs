using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// Defines an answer booklet of an examination. This does not represent any specific booklet of an candidate,
/// but contains settings for how to read candidates' answer scripts.
/// </summary>
public class ExaminationScriptDefinition
{
    /// <summary>
    /// Creates an instance for ExaminationScriptDefinition
    /// </summary>
    [JsonConstructor]
    internal ExaminationScriptDefinition(
        int                                   scriptDefinitionId,
        int                                   examinationId,
        ExaminationScriptType                 scriptType,
        ExaminationScriptSize                 scriptSize,
        int                                   scriptSheetCount,
        [JsonConverter(typeof(IntImageMarginDictJsonConverter))]
        [JsonProperty("candidate_barcode_range")]
        IReadOnlyDictionary<int, ImageMargin> candidateBarcodesMargins,
        [JsonConverter(typeof(ImageMarginJsonConverter))]
        [JsonProperty("script_barcode_range")]
        ImageMargin scriptBarcodeMargins,
        string scriptBarcode)
    {
        DefinitionId             = scriptDefinitionId;
        ExaminationId            = examinationId;
        ScriptType               = scriptType;
        ScriptSize               = scriptSize;
        ScriptSheetCount         = scriptSheetCount;
        CandidateBarcodesMargins = candidateBarcodesMargins;
        ScriptBarcodeMargin      = scriptBarcodeMargins;
        ScriptBarcode            = scriptBarcode;
    }

    /// <summary>
    /// The ID of this definition.
    /// </summary>
    public int DefinitionId { get; }
    
    /// <summary>
    /// The ID of the exam to which this definition belongs.
    /// </summary>
    public int ExaminationId { get; }
    
    /// <summary>
    /// The type of script.
    /// </summary>
    public ExaminationScriptType ScriptType { get; }
    
    /// <summary>
    /// The size of script images.
    /// </summary>
    public ExaminationScriptSize ScriptSize { get; }
    
    /// <summary>
    /// The number of sheets of papers of the script.
    /// </summary>
    public int ScriptSheetCount { get; }
    
    /// <summary>
    /// The margins of candidate's barcodes on each page.
    /// </summary>
    [JsonProperty("candidate_barcode_range")]
    [JsonConverter(typeof(IntImageMarginDictJsonConverter))]
    public IReadOnlyDictionary<int, ImageMargin> CandidateBarcodesMargins { get; }
    
    /// <summary>
    /// The margins of the examination script's barcode. Must be on first page.
    /// </summary>
    [JsonProperty("script_barcode_range")]
    public ImageMargin ScriptBarcodeMargin { get; }
    
    /// <summary>
    /// The expected barcode value of the script barcode.
    /// </summary>
    public string ScriptBarcode { get; }

    /// <summary>
    /// Gets an object representing a Create Examination Script Definition request.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the definition belongs.</param>
    /// <param name="scriptType">The type of script.</param>
    /// <param name="scriptSize">The page (sheet) size of the script.</param>
    /// <param name="scriptSheetCount">The number of sheets of the script.</param>
    /// <param name="candidateBarcodesMargins">The image margins of all candidate barcodes on different pages.</param>
    /// <param name="scriptBarcodeMargin">The image margin of the script barcode on script cover.</param>
    /// <param name="scriptBarcode">The value of the barcode on cover of the script.</param>
    public static CreateExaminationScriptDefinition ToCreate(
        int                                   examinationId,
        ExaminationScriptType                 scriptType,
        ExaminationScriptSize                 scriptSize,
        int                                   scriptSheetCount,
        IReadOnlyDictionary<int, ImageMargin> candidateBarcodesMargins,
        ImageMargin                           scriptBarcodeMargin,
        string                                scriptBarcode)
        => new (examinationId,
                scriptType,
                scriptSize,
                scriptSheetCount,
                candidateBarcodesMargins,
                scriptBarcodeMargin,
                scriptBarcode);
}