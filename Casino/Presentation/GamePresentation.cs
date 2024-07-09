using Casino.Domain.Entities;
using Casino.Service.Services;
using System.ComponentModel;

namespace Casino.Presentation;

public class GamePresentation
{
    public async static Task ShowGame()
    {
        User person = new User();
        UserService service = new UserService();
        GameService gameService = new GameService();
        
        bool check = true;
        while (check)
        {
            try
            {
                Console.WriteLine("Play Game -> 1");
                Console.WriteLine("Get User Balance -> 2");
                Console.WriteLine("Check User is available -> 3");
                Console.WriteLine("Exit -> 4");
                Console.Write("Your option is -> ");
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        Console.Write("Please enter the user's id -> ");
                        int id = int.Parse(Console.ReadLine());
                        var IsAvailable = await gameService.PlayerIsAvailable(id);
                        var human = await service.GetByIdAsync(id);
                        Console.WriteLine(human.FirstName);
                        Console.WriteLine(human.LastName);

                        if (IsAvailable)
                        {
                           
                            Console.Write("How much do you want to bet? -> ");
                            decimal bet = decimal.Parse(Console.ReadLine());
                            await gameService.PlayBetAsync(bet, human);
                            Console.WriteLine("Enter your guess number (1...10) -> ");
                            int playerGuess = int.Parse(Console.ReadLine());
                            var result = await gameService.PlayGameAsync(playerGuess);
                            if (result)
                            {
                               Console.WriteLine("Congratulation!!!  You win! ");
                               await gameService.CalculateWinnigsAsync(bet, person);
                            }
                            else
                            {
                                Console.WriteLine("Unfortunately you failed, Evertyhing will be okay, try again and win!");
                            }
                            
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the user id -> ");
                        int userId = int.Parse(Console.ReadLine());
                        var getBalance = await gameService.GetBalance(userId);
                        Console.WriteLine($"Your balance is : {getBalance}");
                        break;
                    case 3:
                        Console.WriteLine("Please Enter the user id  -> ");
                        int UserId = int.Parse(Console.ReadLine());
                        var finalResult = await gameService.PlayerIsAvailable(UserId);
                        if (finalResult)
                            Console.WriteLine("Yes user is available");
                        else
                            Console.WriteLine("User not found , you can add it");
                        break;
                    case 4:
                        Console.WriteLine("Good luck for you)");
                        check = false;
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
    

}
