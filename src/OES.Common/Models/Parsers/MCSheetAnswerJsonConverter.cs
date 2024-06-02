using Newtonsoft.Json;
using OES.Internal;

namespace OES;

internal class MCSheetAnswerJsonConverter : JsonConverter<ICollection<MCSheetQuestionDefinition>>
{
    public override void WriteJson(
        JsonWriter                              writer,
        ICollection<MCSheetQuestionDefinition>? value,
        JsonSerializer                          serializer)
    {
        Ensure.ArgumentNotNull(value, nameof(value));
        
        var list = value!.OrderBy(x => x.QuestionNumber).ToList();
        var ans = list.Aggregate("", (current, question) => current + question.Answer switch
        {
            MCSheetAnswer.A => "A",
            MCSheetAnswer.B => "B",
            MCSheetAnswer.C => "C",
            MCSheetAnswer.D => "D",
            MCSheetAnswer.Skip => ".",
            _ => "."
        });
        writer.WriteValue(ans);
    }

    public override ICollection<MCSheetQuestionDefinition>? ReadJson(
        JsonReader                              reader,
        Type                                    objectType,
        ICollection<MCSheetQuestionDefinition>? existingValue,
        bool                                    hasExistingValue,
        JsonSerializer                          serializer)
    {
        Ensure.ArgumentNotNullOrEmpty((string?) reader.Value, nameof(reader.Value));

        var s = ((string)reader.Value!).ToUpperInvariant();
        if (s.Length != 100)
            throw new ArgumentException("Invalid MCSheet answers string. Must be 100 characters in length.");

        var value = new MCSheetQuestionDefinition[100];
        for (var i = 0; i < 100; i++)
            value[i] = new MCSheetQuestionDefinition(i + 1, s[i] switch
            {
                'A' => MCSheetAnswer.A,
                'B' => MCSheetAnswer.B,
                'C' => MCSheetAnswer.C,
                'D' => MCSheetAnswer.D,
                '.' => MCSheetAnswer.Skip,
                _ => MCSheetAnswer.Skip
            });

        return value;
    }
}