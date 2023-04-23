namespace ZAEBAL.Model;

internal class AnswerRecord
{
    public AnswerRecord(int id, int recordId, int questionId, int answer)
    {
        Id = id;
        RecordId = recordId;
        QuestionId = questionId;
        Answer = answer;
    }

    public int Id { get; set; }
    public int RecordId { get; set; }
    public int QuestionId { get; set; }
    public int Answer { get; set; }
}