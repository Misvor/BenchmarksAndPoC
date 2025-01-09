using System.Reflection;

namespace ConsoleApp1;

public class Marshalling
{
    private static void ReflectionPractice()
    {
        String[] assemblies =
        {
            "System blahblah{0}",
            "System blahblah{1}"
        };
        String FirstSpace = "123";
        String SecondSpace = "456";

        foreach (var assembly in assemblies)
        {
            String FullAssembly = string.Format(assembly, FirstSpace, SecondSpace);
            Console.WriteLine(FullAssembly);
        }

        Array.CreateInstance(typeof(string), 1,2);

    }
    
}