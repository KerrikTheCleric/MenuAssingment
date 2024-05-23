using System;
using System.Text.RegularExpressions;

namespace MenuAssingment {
    internal class Program {

        public const int YoungCustomerMovieTicketPrice = 80;
        public const int OldCustomerMovieTicketPrice = 90;
        public const int StandardCustomerMovieTicketPrice = 120;

        static void Main(string[] args) {
            bool displayMenu = true;

            while (displayMenu) {
                displayMenu = MainMenu();
            }
        }

        /// <summary>
        /// Container for the main menu of the program that calls all other functionality.
        /// </summary>
        /// <returns>
        /// False, if the program should stop after user input, true otherwise.
        /// </returns>
        /// <remarks>
        /// Can be extended with new cases, but that requires the addition of new lines in PrintMainMenu.
        /// </remarks>

        private static bool MainMenu() {

            PrintMainMenu();

            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

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
                    RepeatTenTimes();
                    return true;
                case 4:
                    TheThirdWord();
                    return true;
                default:
                    Console.WriteLine("Endast siffrorna 0-4 acceptaras som val.");
                    return true;
            }
        }

        /// <summary>
        /// Print method for the main menu.
        /// </summary>

        private static void PrintMainMenu() {
            Console.WriteLine("Detta är huvudmenyn. Välj ett alternativ genom att knappa in rätt siffra nedanför:\n");
            Console.WriteLine("0) Avsluta");
            Console.WriteLine("1) Filmbiljett För En Person");
            Console.WriteLine("2) Filmbiljetter För En Grupp");
            Console.WriteLine("3) Repetera 10 Gånger");
            Console.WriteLine("4) Det Tredje Ordet");
        }

        /// <summary>
        /// Functionality for telling the user movie ticket prices depending on their age.
        /// </summary>

        private static void MovieTicket() {
            Console.WriteLine("\nVälkommen till Rymdbio. Knappa in din ålder nedanför:");
            int parsedResultAge = int.TryParse(Console.ReadLine(), out parsedResultAge) ? parsedResultAge : -1;

            if (parsedResultAge != -1) {

                if (parsedResultAge < 5) {
                    Console.WriteLine("Barn under 5 år går gratis");
                } else if (parsedResultAge < 20) {
                    Console.WriteLine("Ungdomspris: {0}kr", YoungCustomerMovieTicketPrice);
                } else if (parsedResultAge > 100) {
                    Console.WriteLine("Pensionärer över 100 går gratis");
                } else if (parsedResultAge > 64) {
                    Console.WriteLine("Pensionärspris: {0}kr", OldCustomerMovieTicketPrice);
                } else {
                    Console.WriteLine("Standardpris: {0}kr", StandardCustomerMovieTicketPrice);
                }
            } else {
                Console.WriteLine("Ingen ålder inskriven, återvänder till huvudmenyn.");
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Functionality for telling the user movie ticket prices for an entire group of people of varying age.
        /// </summary>

        private static void GroupMovieTickets() {
            Console.WriteLine("\nVälkommen till Rymdbio. Knappa in antalet personer i sällskapet:");

            int parsedResultGroupCount = int.TryParse(Console.ReadLine(), out parsedResultGroupCount) ? parsedResultGroupCount : -1;

            if (parsedResultGroupCount > 0) {

                int youngCustomers = 0;
                int oldCustomers = 0;
                int standardCustomers = 0;
                int freebieCustomers = 0;

                for (int i = 0; i < parsedResultGroupCount; i++) {
                    Console.WriteLine("Ange ålder på person {0}:", i + 1);

                    int parsedResultAge = int.TryParse(Console.ReadLine(), out parsedResultAge) ? parsedResultAge : -1;

                    if (parsedResultAge != -1) {

                        if (parsedResultAge < 5 || parsedResultAge > 100) {
                            freebieCustomers++;
                        } else if (parsedResultAge < 20) {
                            youngCustomers++;
                        } else if (parsedResultAge > 64) {
                            oldCustomers++;
                        } else {
                            standardCustomers++;
                        }
                    } else {
                        Console.WriteLine("Ingen ålder inmatad, återvänder till huvudmenyn.\n");
                        return;
                    }
                }

                if (freebieCustomers > 0) {
                    Console.WriteLine("Totalkostnad för hela sällskapet på {0} personer: {1}kr", parsedResultGroupCount, CalculateGroupPrice(youngCustomers, oldCustomers, standardCustomers));
                    Console.WriteLine("Där {0} får gå gratis", freebieCustomers);

                } else {
                    Console.WriteLine("Totalkostnad för hela sällskapet på {0} personer: {1}kr", parsedResultGroupCount, CalculateGroupPrice(youngCustomers, oldCustomers, standardCustomers));
                }

            } else {
                Console.WriteLine("Inget antal över 0 inskrivet, återvänder till huvudmenyn.");
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Helper method for GroupMovieTickets which calculates the group ticket price.
        /// </summary>
        /// <param name="youngCustomers">Amount of young customers.</param>
        /// <param name="oldCustomers">Amount of old customers.</param>
        /// <param name="standardCustomers">Amount of standard customers.</param>
        /// <returns>
        /// The total ticket price for the group.
        /// </returns>

        private static int CalculateGroupPrice(int youngCustomers, int oldCustomers, int standardCustomers) {
            return youngCustomers * YoungCustomerMovieTicketPrice + oldCustomers * OldCustomerMovieTicketPrice + standardCustomers * StandardCustomerMovieTicketPrice;
        }

        /// <summary>
        /// Repeatedly prints out the given user input ten times on the same line.
        /// </summary>

        private static void RepeatTenTimes() {
            Console.WriteLine("\nSkriv in vad du vill repetera: ");
            string? readLine = Console.ReadLine();

            if (!string.IsNullOrEmpty(readLine)) {

                for (int i = 0; i < 10; i++) {
                    Console.Write("{0}. ", i + 1);
                    Console.Write(readLine + " ");
                }
                Console.WriteLine("");
            } else {
                Console.WriteLine("Du skrev inte in något att repetera, återvänder till huvudmenyn.");
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Asks the user for a sentence containing at least 3 words and then prints out the third word.
        /// </summary>

        private static void TheThirdWord() {
            Console.WriteLine("\nSkriv in en mening med minst tre ord: ");
            string? readLine = Console.ReadLine();

            if (!string.IsNullOrEmpty(readLine)) {
                
                readLine = RemoveExtraSpaces(readLine);
                var sentenceList = readLine.Split(" ");

                if (sentenceList.Length < 3) {
                    Console.WriteLine("Meningen innehåller färre än tre ord, återvänder till huvudmenyn.\n");
                    return;
                } else {
                    Console.WriteLine("Tredje ordet är: " + sentenceList[2]);
                }
            } else {
                Console.WriteLine("Ogiltig inmatning, återvänder till huvudmenyn.");
            }
            Console.WriteLine("");
        }


        /// <summary>
        /// Removes extra spaces before and between other characters in a string. 
        /// </summary>
        /// <param name="inputString">The string to clean up.</param>
        /// <returns>The cleaned up string.</returns>
        /// <remarks>
        /// Does NOT handle tabs or newlines.
        /// </remarks>

        private static string RemoveExtraSpaces(string inputString) {
            inputString = inputString.Trim();
            int nextIndex;

            for (int i = 0; i < inputString.Length; i++) {

                nextIndex = i + 1;

                if (nextIndex != inputString.Length) {
                    if (inputString[i].Equals(' ') && inputString[nextIndex].Equals(' ')) {
                        inputString = inputString.Remove(i, 1);
                        i--;
                    }
                }
            }
            return inputString;
        }
    }
}
