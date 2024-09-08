using System.Text.Json;
using TestTask.BL.Models;
using TodoTestTask.BL.Model;


public class UserController
{
    #region Свойства
    /// <summary>
    /// Название Json файла
    /// </summary>
    private const string FilePath = "users.json";
    /// <summary>
    /// Список пользователей
    /// </summary>
    public List<User> users = new List<User>();
    /// <summary>
    /// Поле для добавления ID
    /// </summary>
    private int nextId;
    #endregion

    public UserController()
    {
        LoadUsersFromFile();
    }
    /// <summary>
    /// Загрузка из Json
    /// </summary>
    public void LoadUsersFromFile()
    {
        if (File.Exists(FilePath))
        {
            string jsonString = File.ReadAllText(FilePath);
            users = JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
            Console.WriteLine("Список пользователей загружен.");
            if (users.Count > 0)
            {
                nextId = users.Max(u => u.Id) + 1;
            }
            else
            {
                nextId = 1;
            }
        }
        else
        {
            users = new List<User>();
            nextId = 1;
            Console.WriteLine("Файл не найден, создан новый список пользователей.");
        }
    }
    /// <summary>
    /// сохранение в Json
    /// </summary>
    public void SaveUsersToFile()
    {
        string jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(FilePath, jsonString);
        Console.WriteLine("Список пользователей сохранен.");
    }
    /// <summary>
    /// найти пользователя по имени
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public User FindUser(string name)
    {
        return users.FirstOrDefault(u => u.LoginName.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    /// <summary>
    /// Добавление нового пользователя
    /// </summary>
    /// <param name="user"></param>

    public void AddUser(User user)
    {
        user.Id = nextId;
        nextId++;
        users.Add(user);
        Console.WriteLine("Пользователь добавлен.");
    }
    /// <summary>
    /// возрас пользователя
    /// </summary>

    public void AddTodo(int ID, TODO todo)
    {
        var foundUser = users.SingleOrDefault(u => u.Id == ID);
        if (foundUser.Id != null)
        {
            foundUser.Tasks.Add(todo);
        }
        else
        {
            Console.WriteLine("Пользователя по такому ID не найден");
        }

    }
}