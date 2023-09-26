using System.Globalization;
//Import this in order to use the built in method TextInfo.ToTitleCase();

namespace Group2
{
    class Program
    {
        //Lable constants to make code more readable
        private const double prelimWeight = 0.3;
        private const double midtermWeight = 0.3;
        private const double finalWeight = 0.4;
        public static void Main(string[] args)
        {
            //Create a text info based on en-US culture
            Console.WriteLine("============================== Welcome To LSPU Student Management System ============================= \n");
            Console.Write("Enter the number of students: ");

            //Make sure that the user inputs a number
            int numberOfStudents;
            while (!int.TryParse(Console.ReadLine(), out numberOfStudents) || numberOfStudents <= 0)
            {
                Console.Write("Invalid input. Please enter a positive integer: ");
            }

            int prelimIndex = 0, midtermIndex = 0, finalIndex = 0;

            //Create different arrays for different variables. 
            //We use array to store multiple items since the number of students may vary
            string[] studentName = new string[numberOfStudents];
            double[] prelimGrades= new double[numberOfStudents];
            double[] midtermGrades = new double[numberOfStudents];
            double[] finalGrades = new double[numberOfStudents];
            double[] prelimper = new double[numberOfStudents];
            double[] midtermper = new double[numberOfStudents];
            double[] finalper = new double[numberOfStudents];
            double[] totalGrade = new double[numberOfStudents];
            double[] rating = new double[numberOfStudents];

            //Create a condition to make statement grammatically correct.
            Console.WriteLine(numberOfStudents == 1
                ? "This will compute for the grade of 1 student in Programming 101"
                : $"This will compute for the grade of {numberOfStudents} students in Programming 101");
            
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            //Loop that ask the name of student in the numberOfStudents array
            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.Write($"Enter the name of Student {i + 1}: ");

            //Since we are dealing with person names, we want it to be in the proper case
                studentName[i] = myTI.ToTitleCase((Console.ReadLine()));
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------");

            //Here, We want to validate the input that will be given by the user
            //Given that there are other ways to approach this (functional programming), we prevent it as the code will soon become
            //More complex. instead we just repeat ourselves to make it beginner friendly.
            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine("Enter grades for {0}", studentName[i]);
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("Prelim\t: ");
                        while (!double.TryParse(Console.ReadLine(), out prelimGrades[prelimIndex]) || prelimGrades[prelimIndex] < 0 || prelimGrades[prelimIndex] > 100)
                        {
                            Console.Write("Invalid input. Please enter a valid grade (0-100): ");
                        }
                        prelimIndex++;
                    }
                    else if (j == 1)
                    {
                        Console.Write("Midterm\t: ");
                        while (!double.TryParse(Console.ReadLine(), out midtermGrades[midtermIndex]) || midtermGrades[midtermIndex] < 0 || midtermGrades[midtermIndex] > 100)
                        {
                            Console.Write("Invalid input. Please enter a valid grade (0-100): ");
                        }
                        midtermIndex++;
                    }
                    else if (j == 2)
                    {
                        Console.Write("Final\t: ");
                        while (!double.TryParse(Console.ReadLine(), out finalGrades[finalIndex]) || finalGrades[finalIndex] < 0 || finalGrades[finalIndex] > 100)
                        {
                            Console.Write("Invalid input. Please enter a valid grade (0-100): ");
                        }
                        finalIndex++;
                    }
                }
            }

            //Same goes here, We chose not to modify the code as we want to make it beginner friendly.
            for (int i = 0; i < prelimGrades.Length; i++)
            {
                prelimper[i] = prelimGrades[i] * prelimWeight;
            }
            for (int i = 0; i < midtermGrades.Length; i++)
            {
                midtermper[i] = midtermGrades[i] * midtermWeight;
            }
            for (int i = 0; i < finalGrades.Length; i++)
            {
                finalper[i] = finalGrades[i] * finalWeight;
            }

            for (int i = 0; i < numberOfStudents; i++)
            {
                totalGrade[i] = prelimper[i] + midtermper[i] + finalper[i];
                if (totalGrade[i] >= 99) { rating[i] = 1.0; }
                else if (totalGrade[i] >= 96) { rating[i] = 1.25; }
                else if (totalGrade[i] >= 93) { rating[i] = 1.5; }
                else if (totalGrade[i] >= 90) { rating[i] = 1.75; }
                else if (totalGrade[i] >= 87) { rating[i] = 2.0; }
                else if (totalGrade[i] >= 84) { rating[i] = 2.25; }
                else if (totalGrade[i] >= 81) { rating[i] = 2.5; }
                else if (totalGrade[i] >= 78) { rating[i] = 2.75; }
                else if (totalGrade[i] >= 75) { rating[i] = 3.0; }
                else if (totalGrade[i] <= 74) { rating[i] = 5.0; }

            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\n======================================  Course: Programming 101 ======================================");
            Console.WriteLine("\nList of Students\tPrelim\t\tMidterm\t\tFinal\t\tGrade\t\tRating");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine($"{studentName[i]}\t\t| {prelimGrades[i]} |\t\t| {midtermGrades[i]} |\t\t| {finalGrades[i]} |\t\t|{totalGrade[i]:F2}|\t\t|{rating[i]}|");
                Console.WriteLine("------------------------------------------------------------------------------------------------------");
            }
            Console.ReadKey(true);
        }
    }
}
