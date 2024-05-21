namespace MenuAssingment {
    internal class Program {
        static void Main(string[] args) {
            bool displayMenu = true;

            while (displayMenu) {
                displayMenu = MainMenu();
            }
        }

        private static bool MainMenu() {
            Console.WriteLine("Welcome to the main menu. Please select an option by typing in the appropriate number:");
            Console.WriteLine("");

            Console.WriteLine("0) Exit");
            Console.WriteLine("1) Something");
            Console.WriteLine("2) Something");
            Console.WriteLine("3) Something");
            Console.WriteLine("4) Something");


            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : 999;

            switch (parsedResult) {

                case 0:
                    return false;

                case 1:
                    return true;

                case 2:
                    return true;

                case 3:
                    return true;

                case 4:
                    return false;

                default:
                    Console.WriteLine("Only numbers 0-4 are valid");
                    return true;
            }

        }
    }
}
