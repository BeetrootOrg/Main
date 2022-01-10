using System;
using System.Reflection;


namespace ConsoleApp
{
    class ConsoleApp
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\r\n a.tkachenko/homework/20-Reflections \r\n");

            var assemblyName = "ConsoleApp";
            var classname = "Vote";

            Console.WriteLine("Enter class name you want to create:");
            Console.WriteLine(classname);

            var typeToCreate = Type.GetType($"{assemblyName}.{classname}, {assemblyName}", true);
            var obj = Activator.CreateInstance(typeToCreate);


            var propertyInfo = typeToCreate.GetProperty("Question");
            SetProperty(obj, "Question", "test question", propertyInfo);

            propertyInfo = typeToCreate.GetProperty("Answer");
            SetProperty(obj, "Answer", "Fine", propertyInfo, 0);
            SetProperty(obj, "Answer", "Not Fine", propertyInfo, 1);

            GetListMethods(typeToCreate);

            TestShowQuestionMethod(typeToCreate, obj, "ShowQuestion");
            TestSetQuestionMethod(typeToCreate, obj, "SetQuestion", new string[] { "How are you?" });
            TestShowQuestionMethod(typeToCreate, obj, "ShowQuestion");

            TestShowVoteResultMethod(typeToCreate, obj, "ShowVoteResult");

            TestAddNewVotedPersonMethod(typeToCreate, obj, "AddNewVotedPerson", new string[] { "Petya", "Fine" });
            TestAddNewVotedPersonMethod(typeToCreate, obj, "AddNewVotedPerson", new string[] { "Victor", "Fine" });
            TestAddNewVotedPersonMethod(typeToCreate, obj, "AddNewVotedPerson", new string[] { "Misha", "Not Fine" });

            TestShowVoteResultMethod(typeToCreate, obj, "ShowVoteResult");
        }

        private static void TestSetQuestionMethod(Type typeToCreate, object obj, string method, string[] setArgs)
        {
            InvokeMethod(typeToCreate, obj, method, setArgs);
        }
        private static void TestShowQuestionMethod(Type typeToCreate, object obj, string method)
        {
            InvokeMethod(typeToCreate, obj, method);
        }
        private static void TestShowVoteResultMethod(Type typeToCreate, object obj, string method)
        {
            InvokeMethod(typeToCreate, obj, method);
        }
        private static void TestAddNewVotedPersonMethod(Type typeToCreate, object obj, string method, string[] setArgs)
        {
            InvokeMethod(typeToCreate, obj, method, setArgs);
        }
        private static void InvokeMethod(Type typeToCreate, object obj, string method)
        {
            Console.WriteLine("\r\nInvoke \"{0}\" method: ", method);
            var methodInfo = typeToCreate.GetMethod(method);
            var paramsMethodInfo = methodInfo.GetParameters();
            if (paramsMethodInfo.Length == 0)
            {
                methodInfo.Invoke(obj, null);
            }
        }
        private static void InvokeMethod(Type typeToCreate, object obj, string method, string [] setArgs)
        {
            Console.WriteLine("\r\nInvoke \"{0}\" method: ", method);
            var methodInfo = typeToCreate.GetMethod(method);
            var paramsMethodInfo = methodInfo.GetParameters();
            if (paramsMethodInfo.Length > 0)
            {
                var args = new object[paramsMethodInfo.Length];
                for (int i = 0; i < paramsMethodInfo.Length; i++)
                {
                    Console.WriteLine($"argument {i + 1}: {setArgs[i]}");
                    var arg = setArgs[i];                              //  var arg = Console.ReadLine();
                    args[i] = ConvertTo(arg, paramsMethodInfo[i].ParameterType);
                }
                methodInfo.Invoke(obj, args);
            }
        }

        static void GetListMethods(Type t)
        {
            Console.WriteLine("\r\nAll Methods in \"{0}\" type:", t.Name);
            
            MethodInfo[] methodInfos = t.GetMethods();

            int i = 0;
            foreach (MethodInfo mi in methodInfos)
            {
                Console.WriteLine("{0}: {1}", i++, mi.Name);
            }
        }
        private static object ConvertTo(string value, Type type)
        {
            if (type == typeof(string))
            {
                return value;
            }

            if (type == typeof(int) && int.TryParse(value, out var intVal))
            {
                return intVal;
            }

            if (type == typeof(DateTime) && DateTime.TryParse(value, out var dateTime))
            {
                return dateTime;
            }

            throw new ArgumentException($"Cannot convert value to type {type}");
        }
        
        private static void SetProperty(object obj, string propertyName, string propertyValue, PropertyInfo propertyInfo, int index)
        {
            if (propertyInfo == null)
            {
                Console.WriteLine($"Missing property info {propertyName}");
            }
            else
            {
                if (propertyInfo.PropertyType == typeof(String[]))
                {
                    object[] value = (object[])propertyInfo.GetValue(obj, null);
                    value[index] = propertyValue;
                }
                else
                {
                    Console.WriteLine($"Cannot convert value to type {propertyInfo.PropertyType}");
                }
            }
        }
        private static void SetProperty(object obj, string propertyName, string propertyValue, System.Reflection.PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                Console.WriteLine($"Missing property info {propertyName}");
            }
            else
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    propertyInfo.SetValue(obj, propertyValue);
                }
                else if (propertyInfo.PropertyType == typeof(String[]))
                {
                    propertyInfo.SetValue(obj, propertyValue, new object[] { 0 });
                }
                else if (propertyInfo.PropertyType == typeof(int) && int.TryParse(propertyValue, out var intVal))
                {
                    propertyInfo.SetValue(obj, intVal);
                }
                else
                {
                    Console.WriteLine($"Cannot convert value to type {propertyInfo.PropertyType}");
                }
            }
        }
    }
}
