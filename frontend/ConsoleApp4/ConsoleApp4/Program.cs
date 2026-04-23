
namespace ConsoleApp4
{
    internal class Program
    {
        static ServerConnection connection = new ServerConnection("http://127.1.1.1:3000");
        static List<Airplanes> allPlanes = new();
        static async Task Main(string[] args)
        {
            string command = "loggedOut";
            Console.WriteLine("Hello, World!");
            Console.WriteLine(" ez egy dolgozat");
            while (command != "exit")
            {
                int number;
                if(command == "loggedOut")
                {
                    number = loggedOutMenu();
                    command = await doFunctions(command, number);
                }
                else
                {
                    number = loggedInMenu();
                    command = await doFunctions(command, number);

                }
            }
            Console.ReadKey();
        }
        static int loggedOutMenu()
        {
            Console.WriteLine("1. Repülőgépek listázása");
            Console.WriteLine("2. Szűrés megadott férőhelytől");
            Console.WriteLine("3. Név szerinti keresés részillesztéssel");
            Console.WriteLine("4. Repülőgépek csoportosítása férőhely alapján");
            Console.WriteLine("5. Bejelentkezés /login");
            Console.WriteLine("6. Kilépés");
            return GetNumber(1, 6);
        }
        static int loggedInMenu()
        {

            Console.WriteLine("1. Saját repülőgépek listázása /myplanes");
            Console.WriteLine("2. Új repülőgép felvétele /planes");
            Console.WriteLine("3. Kijelentkezés");
            return GetNumber(1, 3);
        }
        static async Task<string> doFunctions(string command, int number)
        {
            if (command == "loggedOut")
            {
                switch (number)
                {
                    case 1:
                        await ListAllPlanes();
                        break;
                    case 2:
                        await FilterPlanes();
                        break;
                    case 3:
                        await SearchPlanes();
                        break;
                    case 4:
                        await GroupPlanes();
                        break;
                    case 5:
                        await Login();
                        break;
                    case 6:
                        return "exit";
                    default:
                        break;
                }
            }
            else
            {
                switch (number)
                {
                    case 1:
                        await getMyPlanes();
                        break;
                    case 2:
                        await createPlanes();
                        break;
                    case 3:
                        await Logout();
                        return "loggedOut";
                    default:
                        break;
                }
            }
            return command;
        }

        private static async Task createPlanes()
        {
            throw new NotImplementedException();
        }

        private static async Task getMyPlanes()
        {
            List<Airplanes> myPlane = await connection.getMyPlanes();
            myPlane.ForEach(Airplanes => Console.WriteLine(Airplanes));
        }

        private static async Task GroupPlanes()
        {
            throw new NotImplementedException();
        }


        private static async Task SearchPlanes()
        {
            string input = Console.ReadLine().Trim();
            allPlanes.Where(planes => planes.name.Contains(input)).ToList().ForEach(Airplanes => Console.WriteLine(Airplanes));
        }
        private static async Task FilterPlanes()
        {
            throw new NotImplementedException();
        }

        private static async Task ListAllPlanes()
        {
            allPlanes.ForEach(Airplanes => Console.WriteLine(Airplanes));
        }

        private static async Task Logout()
        {
            connection.Logout();
        }
        static int GetNumber(int min, int max)
        {
            Console.WriteLine($"Adj meg egy számot {min} és {max} között");
            string input = Console.ReadLine().Trim();
            if (int.TryParse(input, out int number))
            {
                if (number >= min && number <= max)
                {
                    return number;
                }
                Console.WriteLine("A szám a határokon kívűlre esett");
            }
            else
            {
                Console.WriteLine("Számot Adj meg");
            }
            return GetNumber(min, max);
        }

        private static async Task<bool> Login()
        {
            Console.WriteLine("Felhasználóneved");
            string username = Console.ReadLine().Trim();
            Console.WriteLine("Jelszavad");
            string password = Console.ReadLine().Trim();
            return await connection.Login(username, password);
        }
    }
}
