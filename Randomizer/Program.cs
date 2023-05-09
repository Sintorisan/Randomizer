namespace Randomizer
{
    internal class Program
    {
        static List<People> persons = new List<People>();
        static void Main(string[] args)
        {
            Console.Write("Hello, how may are you?: ");
            int howMany = IntCheck(Console.ReadLine());
            string addToDo;

            for (int i = 1; i <= howMany; i++) //Askes for the names of those who are particapating
            {
                Console.Write($"Name of person nr {i}: ");
                AddPerson(Console.ReadLine());
            }            
            Console.Clear();

            do //Askes the user to type in what to do and adds it to a random person
            {
                Console.WriteLine("Type in what needs to be done. Type stop when finished.\n");
                addToDo = Console.ReadLine();

                if (addToDo.ToLower().Equals("stop"))
                    break;

                AddRandom(addToDo, howMany);

                Console.Clear();
            } while (true);

            

            for (int i = 0; i < howMany; i++) //Prints out the taskes for each user
            {
                Console.WriteLine("\n" + persons[i].Name + "\n");
                foreach (string item in persons[i].ToDoList)
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadKey();
        }

        static void AddRandom(string toDo, int howMany) //Adds randomly tasks between users
        {
            Random random = new Random();
            bool youShalPass = false;

            do
            {
                int personID = random.Next(0, howMany);
                if (CanAdd(personID, howMany))
                {
                    persons[personID].ToDoList.Add(toDo);
                    persons[personID].Counter++;
                    youShalPass= true;
                }
            } while (!youShalPass);
            
        }

        static bool CanAdd(int persNumber, int howMany) //Checks so it adds tasks evenly between users
        {
            bool canAddToList = true;
            for (int i = 0; i < howMany; i++)
            {
                if (persons[persNumber].Counter > persons[i].Counter)
                {
                    canAddToList= false;
                }
            }
            return canAddToList;
        }

        static void AddPerson(string name) //Creates new person and adds it to the list of persons
        {
            People newPerson = new People(name);
            persons.Add(newPerson);
        }

        static int IntCheck(string s) //Takes in a string and checks it if it's a valid int and returns the int
        {

            int value = 0;
            bool youShallPass = false;

            do
            {
                if (int.TryParse(s, out value))
                {
                    youShallPass = true;
                }
                else
                {
                    Console.Write("Invalid input. Try again: ");
                    s = Console.ReadLine();
                }
            } while (!youShallPass);

            return value;
        }
    }
}