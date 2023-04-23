using ZAEBAL.Model;

namespace ZAEBAL;

internal class Database
{
    private string _con =
        "Data Source = 46.39.232.190; Initial Catalog = Neo_Mei_Database;User Id = Sharp228; Password = root; Encrypt=False;";

    private static Service _bebra = new();

    public List<User> Users = _bebra.GetUsers();
    public List<Question> Questions = _bebra.GetQuestions();
    public List<QuizRecord> Records = new();
    public List<Answer> Answers = _bebra.GetAnswers();
    public List<QuizRecord> QuizRecords = _bebra.GetQuizRecords();
    public List<AnswerRecord> AnswerRecords = _bebra.GetAnswerRecords();
}