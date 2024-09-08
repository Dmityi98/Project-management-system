using TestTask.BL.Models;
using TodoTestTask.BL.Model;

class Program
{
    static void Main(string[] args)
    {
        User currentUser = new User();
        UserController controller = new UserController();

        controller.LoadUsersFromFile();

        Console.WriteLine("Введите имя пользователя:");
        string userName = Console.ReadLine();

        User user = controller.FindUser(userName);

        Console.WriteLine("Введите пароль пользователя");
        currentUser.UserPassword = Console.ReadLine();

        if (user != null)
        {
           

            if (user.RolesUser == "Admin")
            {
                if (currentUser.UserPassword == user.UserPassword)
                {
                    Console.WriteLine($"Добро пожаловать, {user.LoginName}!");

                    Console.WriteLine("Menu Admins");
                    Console.WriteLine("1)Создать задачу и назначить\n2)Добавить сотрудника");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Введите какому пользователю хотите назначить задачу");
                            int id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Введите задачу");
                            var textTodo = Console.ReadLine();

                            Console.WriteLine("Введите состояние задачи");
                            var condition = Console.ReadLine();
                            Console.WriteLine("Введите название проекта");
                            var project = Console.ReadLine();

                            TODO todo = new TODO(textTodo, condition, project);

                            controller.AddTodo(id, todo);
                            controller.SaveUsersToFile();
                            break;
                        case "2":
                            Console.WriteLine("Введите имя пользователя");
                            var login = Console.ReadLine();
                            Console.WriteLine("Введите пароль пользователя");
                            var password = Console.ReadLine();
                            Console.WriteLine("Введите роль пользователя\n1)Admin\n2)User");
                            var roles = Console.ReadLine();
                            User users = new User(login, password, roles);
                            controller.AddUser(users);
                            controller.SaveUsersToFile();
                            break;
                        default:
                            Console.WriteLine("Неверный выбор.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неправильный пароль");
                }
            }
            else
            {
                if (currentUser.UserPassword == user.UserPassword)
                {
                    Console.WriteLine($"Добро пожаловать, {user.LoginName}!");

                    Console.WriteLine("Menu Users");
                    Console.WriteLine("1)Просмотреть список задач\n2)изменить состояние задачи");

                    string choiceUser = Console.ReadLine();

                    switch (choiceUser)
                    {
                        case "1":
                            Console.WriteLine("просмотр списка задач");

                            foreach (var task in user.Tasks)
                            {
                                Console.WriteLine($"Название задачи: {task.NameTask}\nCостояние задачи:{task.Condition}");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Введите текст задачи которую вы хотите изменить ");

                            string text = Console.ReadLine();

                            var nametext = user.Tasks.SingleOrDefault(u => u.NameTask == text);

                            if (text == nametext.NameTask)
                            {
                                Console.WriteLine("Введите новое состояние");
                                var newCondition = Console.ReadLine();
                                nametext.Condition = newCondition;
                                Console.WriteLine("Состояние изменено");
                                controller.SaveUsersToFile();
                            }
                            else
                            {
                                Console.WriteLine("Нет такой задачи");
                            }
                            break;
                        default:
                            Console.WriteLine("Неверный выбор.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неправильный пароль");
                }
            }
        }
        else
        {
            Console.WriteLine("Пользователь не найден.");
        }
    }
}