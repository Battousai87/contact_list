namespace dtp6_contacts
{
    class MainClass
    {
        static List<Person> contactList = new List<Person>();
        class Person
        {
            
            private string fname;
            private string lname;
            private string[] phone;
            private string[] address;
            private string birthdate;
            public Person(){

            }

            public string Fname { get => fname; set => fname = value; }
            public string Lname { get => lname; set => lname = value; }
            public string[] Phone { get; set; }
            public string[] Address { get; set; }
            public string Birthdate { get => birthdate; set => birthdate = value; }
        }
        public static void Main(string[] args)
        {
            string lastFileName = "address.lis";
            string[] commandLine;
            Console.WriteLine("Hello and welcome to the contact list");
            PrintCommandHelp();
            do
            {
                Console.Write($"> ");
                commandLine = Console.ReadLine().Split(' ');
                if (commandLine[0] == "quit")
                {
                    // NYI!
                    Console.WriteLine("Not yet implemented: safe quit");
                }
                else if (commandLine[0] == "load")
                {
                    if (commandLine.Length < 2)
                        lastFileName = "address.lis";
                    
                    else
                        lastFileName = commandLine[1];
                    
                    LoadPersonsFromFile(lastFileName);
                }
                else if (commandLine[0] == "save")
                {
                    if (commandLine.Length < 2)
                    {
                        SaveToFile(lastFileName);
                    }
                    else
                    {
                        string newFileName = commandLine[1];
                        SaveToFile(newFileName);
                        
                    }
                }
                else if (commandLine[0] == "new")
                {
                    if (commandLine.Length < 2)
                    {
                        Console.Write("personal name: ");
                        string persname = Console.ReadLine();
                        Console.Write("surname: ");
                        string surname = Console.ReadLine();
                        Console.Write("phone: ");
                        string phone = Console.ReadLine();
                    }
                    else
                    {
                        // NYI!
                        Console.WriteLine("Not yet implemented: new /person/");
                    }
                }
                else if (commandLine[0] == "help")
                {
                    PrintCommandHelp();
                }
                else
                {
                    Console.WriteLine($"Unknown command: '{commandLine[0]}'");
                }
            } while (commandLine[0] != "quit");
        }

        private static void SaveToFile(string lastFileName)
        {
            using (StreamWriter outfile = new StreamWriter(lastFileName))
            {
                foreach (Person person in contactList)
                {
                    if (person != null)
                        outfile.WriteLine($"{person.Fname};{person.Lname};{person.Phone};{person.Address};{person.Birthdate}");
                }
            }
        }

        private static void LoadPersonsFromFile(string lastFileName)
        {
            using (StreamReader infile = new StreamReader(lastFileName))
            {
                string line;
                while ((line = infile.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string[] personProperties = line.Split('|');
                    Person person = new Person();
                    person.Fname = personProperties[0];
                    person.Lname = personProperties[1];
                    person.Phone = personProperties[2].Split(';');
                    person.Address = personProperties[3].Split(':');
                    person.Birthdate = personProperties[4];
                    contactList.Add(person);
                }
            }
        }

        private static void PrintCommandHelp()
        {
            Console.WriteLine("Avaliable commands: ");
            Console.WriteLine("  load        - load contact list data from the file address.lis");
            Console.WriteLine("  load /file/ - load contact list data from the file");
            Console.WriteLine("  new        - create new person");
            Console.WriteLine("  new /persname/ /surname/ - create new person with personal name and surname");
            Console.WriteLine("  quit        - quit the program");
            Console.WriteLine("  save         - save contact list data to the file previously loaded");
            Console.WriteLine("  save /file/ - save contact list data to the file");
            Console.WriteLine();
        }
    }
}
