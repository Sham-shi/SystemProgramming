using System.Reflection;

Assembly asm = Assembly.Load(AssemblyName.GetAssemblyName("C:\\Users\\Shalim\\source\\repos\\SystemProgramming\\ModulesInAction\\bin\\Debug\\net9.0\\SmpleLibrary.dll"));

Console.WriteLine("Объявленные типы данных:");

Module mod = asm.GetModule("SmpleLibrary.dll");

foreach (Type t in mod.GetTypes())
    Console.WriteLine(t.FullName);

Type Person = mod.GetType("SmpleLibrary.Person") as Type;

object person = Activator.CreateInstance(Person, ["Иван", "Иванов", 30]);

Person.GetMethod("Print").Invoke(person, null);