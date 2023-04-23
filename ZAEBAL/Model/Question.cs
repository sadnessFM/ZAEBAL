namespace ZAEBAL.Model;

internal class Question
{
    public Question(int id, int qiuz, string text)
    {
        Id = id;
        QuizId= qiuz;
        Text = text;
    }

    public int Id { get; set; }
    public int QuizId { get; set; }
    public string Text { get; set; }
}