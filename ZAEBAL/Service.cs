using System.Data.SqlClient;
using ZAEBAL.Model;

namespace ZAEBAL;

internal class Service
{
    private string _con =
        "Data Source = 46.39.232.190; Initial Catalog = Neo_Mei_Database;User Id = Sharp228; Password = root; Encrypt=False;";

    public List<User> GetUsers()
    {
        var users = new List<User>();
        using (var connection = new SqlConnection(_con))
        {
            var getUser = new SqlCommand("select id_user, username from Neo_Mei_Database.dbo.users", connection);
            connection.Open();

            SqlDataReader reader = getUser.ExecuteReader();
            while (reader.Read())
            {
                var user = new User(reader.GetInt32(0), reader.GetString(1));
                users.Add(user);
            }
            reader.Close();
            connection.Close();
        }
        return users;
    }

    public List<Answer> GetAnswers()
    {
        var users = new List<Answer>();
        using (var connection = new SqlConnection(_con))
        {
            var getUser = new SqlCommand("select id_answer, answer_text, answer_question_id, answer_cost from Neo_Mei_Database.dbo.answers", connection);
            connection.Open();

            SqlDataReader reader = getUser.ExecuteReader();
            while (reader.Read())
            {
                var user = new Answer(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                users.Add(user);
            }
            reader.Close();
            connection.Close();
        }
        return users;
    }

    public List<Question> GetQuestions()
    {
        var users = new List<Question>();
        using (var connection = new SqlConnection(_con))
        {
            var getUser = new SqlCommand("select id_question, question_quiz_id, question_text from Neo_Mei_Database.dbo.questions", connection);
            connection.Open();

            SqlDataReader reader = getUser.ExecuteReader();
            while (reader.Read())
            {
                var user = new Question(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                users.Add(user);
            }
            reader.Close();
            connection.Close();
        }
        return users;
    }

    public List<QuizRecord> GetQuizRecords()
    {
        var users = new List<QuizRecord>();
        using (var connection = new SqlConnection(_con))
        {
            var getUser = new SqlCommand("select * from Neo_Mei_Database.dbo.quiz_records", connection);
            connection.Open();

            SqlDataReader reader = getUser.ExecuteReader();
            while (reader.Read())
            {
                var user = new QuizRecord(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                users.Add(user);
            }
            reader.Close();
            connection.Close();
        }
        return users;
    }

    public List<AnswerRecord> GetAnswerRecords()
    {
        var users = new List<AnswerRecord>();
        using (var connection = new SqlConnection(_con))
        {
            var getUser = new SqlCommand("select * from Neo_Mei_Database.dbo.record_answers", connection);
            connection.Open();

            SqlDataReader reader = getUser.ExecuteReader();
            while (reader.Read())
            {
                var user = new AnswerRecord(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                users.Add(user);
            }
            reader.Close();
            connection.Close();
        }
        return users;
    }
}