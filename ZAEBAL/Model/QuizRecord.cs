namespace ZAEBAL.Model;

internal class QuizRecord
{
    public QuizRecord(int id, int quizId, int userId, int value)
    {
        Id = id;
        QuizId = quizId;
        UserId = userId;
        Value = value;
    }

    public int Id { get; set; }
    public int QuizId { get; set; }
    public int UserId { get; set; }
    public int Value { get; set; }
}