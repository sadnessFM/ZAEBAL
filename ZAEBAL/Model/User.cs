namespace ZAEBAL.Model;

internal class User
{
    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string About { get; set; }
}