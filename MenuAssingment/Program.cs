namespace MenuAssingment {
    internal class Program {
        static void Main(string[] args) {
            bool displayMenu = true;

            while (displayMenu) {
                displayMenu = MainMenu();
            }
        }

        private static bool MainMenu() {
            Console.WriteLine("Detta är huvudmenyn. Välj ett alternativ genom att knappa in rätt siffra nedanför:");
            Console.WriteLine("");

            Console.WriteLine("0) Avsluta");
            Console.WriteLine("1) Filmbiljett För En Person");
            Console.WriteLine("2) Filmbiljetter För En Grupp");
            Console.WriteLine("3) Something");
            Console.WriteLine("3) Something");



            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : 999;

            switch (parsedResult) {

                case 0:
                    return false;
                case 1:
                    MovieTicket();
                    return true;
                case 2:
                    GroupMovieTickets();
                    return true;
                case 3:
                    return true;
                case 4:
                    return true;
                default:
                    Console.WriteLine("Endast siffrorna 0-4 acceptaras som val.");
                    return true;
            }

        }

        private static void MovieTicket() {
            Console.WriteLine("Välkommen till Rymdbio. Knappa in din ålder nedanför:");
            int parsedResultAge = int.TryParse(Console.ReadLine(), out parsedResultAge) ? parsedResultAge : -1;

            if (parsedResultAge != -1) {

                if (parsedResultAge < 20) {
                    Console.WriteLine("Ungdomspris: 80kr");
                }
                else if (parsedResultAge > 64) {
                    Console.WriteLine("Pensionärspris: 90kr");
                }
                else {
                    Console.WriteLine("Standardpris: 120kr");
                }
            }
            else {
                Console.WriteLine("Ingen ålder inskriven, återvänder till huvudmenyn.");
            }
        }

        private static void GroupMovieTickets() {
            Console.WriteLine("Välkommen till Rymdbio. Knappa in antalet personer i sällskapet:");

            int parsedResultGroupCount = int.TryParse(Console.ReadLine(), out parsedResultGroupCount) ? parsedResultGroupCount : -1;

            if (parsedResultGroupCount > 0) {

                int youngCustomers = 0;
                int oldCustomers = 0;
                int standardCustomers = 0;


                for (int i = 0; i < parsedResultGroupCount; i++) {
                    Console.WriteLine("Ange ålder på person {0}:", i+1);

                    int parsedResultAge = int.TryParse(Console.ReadLine(), out parsedResultAge) ? parsedResultAge : -1;

                    if (parsedResultAge != -1) {

                        if (parsedResultAge < 20) {
                            youngCustomers++;
                        }
                        else if (parsedResultAge > 64) {
                            oldCustomers++;
                        }
                        else {
                            standardCustomers++;
                        }
                    }
                    else {
                        Console.WriteLine("Ingen ålder inskriven, återvänder till huvudmenyn.");
                        return;
                    }

                }

                Console.WriteLine("Totalkostnad för hela sällskapet på {0} personer: {1}kr", parsedResultGroupCount, (youngCustomers*80 + oldCustomers*90 + standardCustomers*120));


            }
            else {
                Console.WriteLine("Inget antal över 0 inskrivet, återvänder till huvudmenyn.");
            }


        }
    }
}
