using Casino.Domain.Entities;
using Casino.Service.Interfaces;
using Casino.Service.Services;

namespace Casino.Presentation;

public class UserPresentation
{
    public async static Task Show()
    {
        UserService userService = new UserService();
        bool check = true;
        while (check)
        {
            try
            {
                Console.WriteLine("1 -> Add new User");
                Console.WriteLine("2 -> Get All");
                Console.WriteLine("3 -> Update User");
                Console.WriteLine("4 -> Delete User by Id ");
                Console.WriteLine("5 -> Retriev User by Id");
                Console.WriteLine("6 -> Exit");

                Console.WriteLine("Enter your choice -> ");
                int num = int.Parse(Console.ReadLine());

                User user = new User();

                switch (num)
                {
                    case 1:
                        Console.Write("Enter the firstname -> ");
                        user.FirstName = Console.ReadLine();
                        Console.Write("Enter the lastname -> ");
                        user.LastName = Console.ReadLine();
                        Console.Write("Enter the username -> ");
                        user.Username = Console.ReadLine();
                        Console.Write("Enter the password -> ");
                        user.Password = Console.ReadLine();
                        Console.Write("Enter your budget -> ");
                        user.Budget = decimal.Parse(Console.ReadLine());

                        userService.AddAsync(user);
                        break;
                    case 2:
                    
                        var userList =  await userService.SelectAllAsync();
                        foreach(var person in userList)
                        {
                            Console.WriteLine($"{person.id} {person.FirstName} {person.LastName} {person.Username} {person.Budget}");
                        }
                        break;
                    
                    case 3:
                        Console.Write("Enter the UseriD -> ");
                        int number = int.Parse(Console.ReadLine());
                        user.FirstName = Console.ReadLine();
                        user.LastName = Console.ReadLine();
                        user.Username = Console.ReadLine();
                        user.Password = Console.ReadLine();
                        user.Budget = decimal.Parse(Console.ReadLine());

                        await userService.UpdateAsync(user);
                        
                        break;
                    case 4:
                        Console.Write("Enter the id -> ");
                        int id = int.Parse(Console.ReadLine());
                        var deleteResponse = userService.DeleteAsync(id);
                        break;
                    case 5:
                        Console.Write("Enter the User id -> ");
                        int id1 = int.Parse(Console.ReadLine());
                        var human = await userService.GetByIdAsync(id1);
                        Console.WriteLine($"{human.id} {human.FirstName} {human.LastName} {human.Username} {human.Budget} {human.CreatedAt}");
                        break;
                    case 6:
                        Console.WriteLine("Welcome :)");
                        check = false;
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
