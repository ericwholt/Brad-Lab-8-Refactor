using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        //public static string[] Names = { "Nate", "Lisa", "Brad", "Steven", "Miguel", "Calista" };
        //public static string[] FavoriteFoods = { "Burgers", "Fruits", "Sushi", "Risotto", "BBQ Ribs", "Crab Ragoon" };
        //public static string[] HomeTowns = { "Grand Rapids, MI", "Sokcho, South Korea,", "Kentwood, MI", "Ontario, CA", "Chicago, IL", "Traverse City, MI" };
        public static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            //main menu for adding people to the list or viewing what's on it.
            while (true)
            {
                Console.WriteLine("Welcome to the People list! What would you like to do?\n" +
                    "\n(A)dd: Add to list." +
                    "\n(L)ist: See the list." +
                    "\n(Q)uit: Quit program.");
                string uAnswer = Console.ReadLine().ToLower();

                if (uAnswer == "add" || uAnswer == "a")
                {
                    AddToList();
                }
                else if (uAnswer == "list" || uAnswer == "l")
                {
                    LearnMore(GetInput());
                }
                else if(uAnswer == "quit" || uAnswer == "q")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter input from the list");
                    continue;
                }
                continue;
            }
        }

        //adds new people to the list

        public static void AddToList()
        {
            
            Console.WriteLine("What is the persons name?");
            string name = Console.ReadLine();
            Console.WriteLine("Where where they born?");
            string homeTown = Console.ReadLine();
            Console.WriteLine("What's their favorite food?");
            string food = Console.ReadLine();
            AddStudent(name, food, homeTown);

            bool isTrue = true;
            while (isTrue)
            {
                Console.WriteLine("Would you like to add another? (Y/N)");
                string answer = Console.ReadLine().ToLower();

                if (answer == "y")
                {
                    AddToList();
                }
                else if (answer == "n")
                {
                    isTrue = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please type Y or N");
                    continue;
                }
                break;
            }
        }

        //creates a new array to add names and info
        public static void AddStudent(string name, string favoriteFood, string homeTown)
        {
            Student student = new Student(name, favoriteFood, homeTown);
            students.Add(student);
            //string[] addNames = new string[Names.Length + 1];
            //string[] addFavFood = new string[FavoriteFoods.Length + 1];
            //string[] addHomeTown = new string[HomeTowns.Length + 1];
            //for(int i = 0; i < addNames.Length - 1; i++)
            //{
            //    addNames[i] = Names[i];
            //    addFavFood[i] = FavoriteFoods[i];
            //    addHomeTown[i] = HomeTowns[i];
            //}
            //addNames[addNames.Length - 1] = name;
            //addFavFood[addFavFood.Length - 1] = favoriteFood;
            //addHomeTown[addHomeTown.Length - 1] = homeTown;
            //Names = addNames;
            //FavoriteFoods = addFavFood;
            //HomeTowns = addHomeTown;
        }


        //
        public static void LearnMore(int index)
        {
            try
            {
                Console.WriteLine($"\nWhat would you like to know about {students[index - 1].Name}? ((H)ome town, (F)avorite food, or (E)verything");
                string userAnswer = Console.ReadLine().ToLower();
                int listIndex = index - 1;
                if (userAnswer == "home town" || userAnswer == "h")
                {
                    Console.WriteLine($"{students[listIndex].Name} grew up in {students[listIndex].HomeTown}.");
                    Console.ReadKey();
                }
                else if (userAnswer == "favorite food" || userAnswer == "f")
                {
                    Console.WriteLine($"{students[listIndex].Name}'s favorite food is {students[listIndex].FavoriteFood}");
                    Console.ReadKey();                }
                else if (userAnswer == "everything" || userAnswer == "e")
                {
                    GetStudent(index);
                    Console.ReadKey();
                }
                else
                {
                    throw new Exception("Invalid Input");
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
                LearnMore(GetInput());
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Please enter valid number.");
                Console.ReadKey();
                LearnMore(GetInput());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                LearnMore(GetInput());
            }
            Console.WriteLine("Would you like to know more? (Y/N)");
            string uAnswer = Console.ReadLine().ToLower();
            if(uAnswer == "y")
            {
                LearnMore(index);
            }
            else if(uAnswer == "n")
            {
                return;
            }
        }

        //check if it's a positive integer
        public static int GetInput()
        {
            PrintMenu();
            Console.WriteLine("\nPlease enter an index number of the person you'd like to know more about.");
            string str = Console.ReadLine();
            try
            {
                int index = Convert.ToInt32(str);
                if(index < 0 && index > students.Count + 1)
                {
                    throw new Exception("Please enter a number from the list");
                }
                return index;
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
                return GetInput();
            }

            //catch(IndexOutOfRangeException)
            //{
            //    Console.WriteLine("Please select from the list.");
            //    return GetInput();
            //}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return GetInput();
            }
        }

        

        //checks if the number entered is within the range 
        public static void GetStudent(int index)
        {
            try
            {
                Student student = students[index - 1];
                Console.WriteLine($"{student.Name} is from {student.HomeTown} and their favorite food is {student.FavoriteFood}.");
                //Console.WriteLine($"{Names[index - 1]} is from {HomeTowns[index - 1]} and their favorite food is {FavoriteFoods[index - 1]}.");
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Student not found, try another index.");
                GetStudent(GetInput());
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("Here is the list of Names");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {students[i].Name}");
            }
        }
    }
}
