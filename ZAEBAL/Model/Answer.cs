namespace ZAEBAL.Model;

internal class Answer
{
    public Answer(int id, string text, int q, int value)
    {
        Id = id;
        Text = text;
        QuestionId = q;
        Value = value;
    }

    public int Id { get; set; }
    public string Text { get; set; }
    public int QuestionId { get; set; }
    public int Value { get; set; }
}