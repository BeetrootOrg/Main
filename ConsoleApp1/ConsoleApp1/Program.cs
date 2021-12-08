namespace Console
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    class Program
    {
        public static string[,] phoneBook;
        public const string file = "PhoneDB.CSV";
        public const string header = "PhoneNo;FirstName;LastName";
       
        static void Main()
        {           
            
            MainMenu();
  
        }

        public static void Update(string firstName, string lastName)
        {
            for(int i = 0; i < phoneBook.GetLength(0); i++)
            {
                if(phoneBook[i,1] == firstName && phoneBook[i,2] == lastName)
                {
                    Update(i);
                    Console.WriteLine("Updated succesfully");
                    Console.ReadKey();
                    break;
                }
                
            }
            Console.WriteLine("Not found");

        }
        static void Update(int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine("Input phone number in format '+38***'");
            phoneBook[id, 0] = Console.ReadLine();
            DbProcess(true);
        }

        public static void MainMenu()
        {
            bool p = true;
            while (p)
            {
                DbProcess();
                Sort(ref phoneBook);
                Console.Clear();
                Console.WriteLine("Welcome to phone book");
                Console.WriteLine("Choose your option");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Find contact");
                Console.WriteLine("2. Create contact");
                Console.WriteLine("3. Show all");
                Console.WriteLine("4. Update contact");
                Console.WriteLine("5. Exit");
                Console.WriteLine("-------------------");
                var key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case '1':
                        SearchMenu();
                        break;
                    case '2':
                        CreateMenu();
                        break;
                    case '3':
                        if(phoneBook != null|| phoneBook.Length != 0)
                        {
                            Console.WriteLine(header);
                            for (int i = 0; i < phoneBook.Length / 3; i++)
                            {
                                OutRow(i);
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        break;
                    case '4':
                        Console.WriteLine("Input first name");
                        string first = Console.ReadLine();
                        Console.WriteLine("Input last name");
                        string last = Console.ReadLine();
                        Update(first, last);
                        break;
                    case '5':
                        p=false;
                        break;
                }
            }


        }

        public static void SearchMenu()
        {
            bool p = true;
            while (p)
            {
                Console.Clear();
                Console.WriteLine("Choose your option");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Find by phone");
                Console.WriteLine("2. Find by Name");
                Console.WriteLine("3. Find by Last name");
                Console.WriteLine("4. Exit");
                Console.WriteLine("-------------------");
                try
                {
                    if (phoneBook.Length > 0)
                    {
                        string searchString;
                        var key = Console.ReadKey();
                        switch (key.KeyChar)
                        {
                            case '1':
                                Console.WriteLine("Input phone number in format '+38***'");
                                searchString = Console.ReadLine();
                                for (int i = 0; i < phoneBook.Length / 3; i++)
                                {
                                    if (phoneBook[i, 0] == searchString)
                                    {
                                        OutRow(i);
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                                break;
                            case '2':
                                Console.WriteLine("Input first name");
                                searchString = Console.ReadLine();
                                for (int i = 0; i < phoneBook.Length / 3; i++)
                                {
                                    if (phoneBook[i, 1] == searchString)
                                    {
                                        OutRow(i);
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                                break;
                            case '3':
                                Console.WriteLine("Input last name");
                                searchString = Console.ReadLine();
                                for (int i = 0; i < phoneBook.Length / 3; i++)
                                {
                                    if (phoneBook[i, 2] == searchString)
                                    {
                                        OutRow(i);
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                                break;
                            case '4':
                                p = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Phone book is empty, press any key to continue");
                        Console.ReadKey();
                        p = false;
                    }
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("Phone book is empty, press any key to continue");
                    Console.ReadKey();
                    p = false;
                }

            }
        }

        public static void OutRow(int index)
        {
            Console.WriteLine($"{phoneBook[index, 0]}, {phoneBook[index, 1]}, {phoneBook[index, 2]}");
        }

        public static void CreateMenu()
        {
            while (true)
            {
                StringBuilder stringBuilder = new StringBuilder();
                Console.WriteLine("Input phone number in format '+38***'");
                stringBuilder.Append(Console.ReadLine()+";");
                Console.WriteLine("Input first name");
                stringBuilder.Append(Console.ReadLine() + ";");
                Console.WriteLine("Input last name");
                stringBuilder.Append(Console.ReadLine());
                if (SaveRow(stringBuilder.ToString())) break;
                Console.WriteLine("Re input? y/n");
                var key = Console.ReadKey();
                if (key.KeyChar == 'n' || key.KeyChar == 'N') break;
                Console.Clear();
                DbProcess();
            }
        }

        /// <summary>
        /// Open and save DB, from all cashed array
        /// </summary>
        /// <param name="update">if true , rewrite all data(not implemented)</param>
        public static void DbProcess(bool update = false)
        {
            if (update)
            {
                string[] values = new string[phoneBook.Length / 3];
                for(int i = 0;i < phoneBook.Length / 3; i++)
                {
                    StringBuilder stringBuilder2 = new StringBuilder();
                    stringBuilder2.Append(phoneBook[i,0]);
                    stringBuilder2.Append(';');
                    stringBuilder2.Append(phoneBook[i, 1]);
                    stringBuilder2.Append(';');
                    stringBuilder2.Append(phoneBook[i, 2]);
                    values[i] = stringBuilder2.ToString();
                }
                File.WriteAllLines(file, values);
                
            }
            string[] open;
            try
            {
                open = File.ReadAllLines(file);
            }
            catch (IOException)
            {
                Console.WriteLine("File not exists");
                try
                {
                    File.Create(file).Close();
                    GenDB();
                }
                catch { Console.WriteLine("Unacessible Destination"); }
                open = new string[0];
            }
            catch
            {
                Console.WriteLine("Unacessible Destination");
                open = new string[0];
            }
            if(open.Length > 0)
            {
                phoneBook = new string[open.Length,3];
                int indexer = 0;
                foreach(string line in open)
                {
                    try
                    {
                        var trimed = line.Split(';');
                        phoneBook[indexer, 0] = trimed[0];
                        phoneBook[indexer, 1] = trimed[1];
                        phoneBook[indexer, 2] = trimed[2];
                        indexer++;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Wrong line format");
                    }

                }
            }
            else
            {
                phoneBook = new string[0,0];
            }
            
        }

        public static bool Sort(ref string[,] list)
        {
            var p = true;
            for (int i = 0; i < list.Length / 3; i++)
            {
                try
                {                
                if(list[i,2][0] > list[i + 1, 2][0])
                {
                    string[] val = new string[3];
                    val[0] = list[i + 1, 0];
                    val[1] = list[i + 1, 1];
                    val[2] = list[i + 1, 2];
                    list[i + 1, 0] = list[i, 0];
                    list[i + 1, 1] = list[i, 1];
                    list[i + 1, 2] = list[i, 2];
                    list[i, 0] = val[0];
                    list[i,1] = val[1];
                    list[i,2] = val[2];
                    if(p) p=false;
                }
                }
                catch
                {

                }
            }
            if(!p) Sort(ref list);
            return p;
        }

        /// <summary>
        /// Save row to DB file, after check. Returns true if save successfull
        /// </summary>
        /// <param name="row">input row, splitted by ;</param>
        /// <returns></returns>
        public static bool SaveRow(string row)
        {
            int error;
            string descr;
            if(ValidateRow(row, out error, out descr))
            {
                string[] toFile = new string[1];
                toFile[0] = row;
                File.AppendAllLines(file, toFile);
                return true;
            }
            else
            {
                Console.WriteLine($"Unable to save data in case of {descr}");
                return false;
            }
        }
        /// <summary>
        /// Check row correctness due to phoneBook format
        /// </summary>
        /// <param name="row">input row, splitted by ;</param>
        /// <param name="errorCode">returns 0, if correct</param>
        /// <param name="errorDescr">return empty string if coorect, error description if somth wrong</param>
        /// <returns></returns>
        public static bool ValidateRow(string row, out int errorCode, out string errorDescr)
        {
            string[] parse;
            try
            {
                parse = row.Split(';');
            }
            catch (ArgumentException)
            {
                parse = new string[0];
                Console.WriteLine("Cannot proccess empty row");
            }
            
            if(parse.Length > 4)
            {
                errorCode = 1;
                errorDescr = "Wrong row format";
                return false;
            }
            if(parse[0].Length > 14 && parse[0][0] != '+')
            {
                errorCode = 2;
                errorDescr = "Wrong phone number format";
                return false;
            }
            if (parse[1].Length > 14 && Char.IsUpper(parse[0][0]))
            {
                errorCode = 2;
                errorDescr = "Wrong First name format";
                return false;
            }
            if (parse[2].Length > 14 && Char.IsUpper(parse[0][0]))
            {
                errorCode = 2;
                errorDescr = "Wrong Last name format";
                return false;
            }
            errorCode = 0;
            errorDescr = "";
            return true;
        }

        /// <summary>
        /// Additional function to generate 100 contaxts for DB
        /// </summary>
        public static void GenDB()
        {
            string[,] arr = new string[100,3];

            for (int x = 0; x < 100; x++)
            {
                string phone = "+38";
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(phone);
                for (int i = 0; i < 11; i++)
                {
                    Random random = new Random();
                    int val = random.Next(9);
                    stringBuilder.Append(val);
                }
                phone = stringBuilder.ToString();
                StringBuilder name = new StringBuilder();
                for(int i = 0; i < 6; i++)
                {
                    if(i == 0)
                    {
                        Random random = new Random();
                        name.Append((char)random.Next(65, 90));
                    }
                    else
                    {
                        Random random = new Random();
                        name.Append((char)random.Next(97, 122));
                    }
                }
                StringBuilder lastName = new StringBuilder();
                for (int i = 0; i < 8; i++)
                {
                    if (i == 0)
                    {
                        Random random = new Random();
                        lastName.Append((char)random.Next(65, 90));
                    }
                    else
                    {
                        Random random = new Random();
                        lastName.Append((char)random.Next(97, 122));
                    }
                }

                StringBuilder row = new StringBuilder();
                row.Append(phone);
                row.Append(';');
                row.Append(name);
                row.Append(';');
                row.Append(lastName);
                row.Append(';');
                SaveRow(row.ToString());
            }

        }
  


    }
    }
 
