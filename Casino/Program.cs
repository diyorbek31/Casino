using Casino.Presentation;


namespace Casino;

public class Program
{
    static async Task Main(string[] args)
    {
        //UserPresentation userPresentation = new UserPresentation();
        //GamePresentation gamePresentation = new GamePresentation();
        bool check = true;
        while (check)
        {
            try
            { 
                Console.WriteLine("User -> 1");
                Console.WriteLine("Game -> 2");
                Console.WriteLine("Exit -> 3");
                Console.WriteLine("Enter your option -> ");
                int num = int.Parse(Console.ReadLine());
                if (num == 1)
                {
                    await UserPresentation.Show();
                }
                else if (num == 2)
                {
                    await GamePresentation.ShowGame();
                }
                else if (num == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        

    }
}
