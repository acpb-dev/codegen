using System.Text.Json;

namespace CodeGenerator;

public class JsonManipulator
{
    
    private int isClass = 0;

    public void ReadJson(String jsonPath, string languageType)
    {
        var generator = new ClassGen();
        var root = JsonDocument.Parse(File.ReadAllText(jsonPath)).RootElement;
        RecursiveSearch(root, generator, languageType);
        generator.printJsonText(languageType);
    }

    private void RecursiveSearch(JsonElement root, ClassGen generator, string languageType)
    {
        if (root.ValueKind == JsonValueKind.Array)
        {
            JsonElement.ArrayEnumerator elements = root.EnumerateArray();
            while (elements.MoveNext())
            {
                var element = elements.Current;
                var properties = element.EnumerateObject();
                
                while (properties.MoveNext())
                {
                    if (!elements.MoveNext()) // && isClass == 0
                    {
                        //Console.WriteLine("\nArray");
                        isClass += 2;
                    }
                    var property = properties.Current;
                    if (!element.TryGetProperty(property.Name, out var v)) continue;
                    var propertyRoot = element.GetProperty(property.Name);
                    generator.StoreStrings(element.ValueKind, property.Name, isClass, languageType);
                    RecursiveSearch(propertyRoot, generator, languageType);
                }
            }
        }
        else if (root.ValueKind == JsonValueKind.Object)
        {
            var elements = root.EnumerateObject();
            while (elements.MoveNext())
            {
                var element2 = elements.Current;
                var temp = root.GetProperty(element2.Name);
                if (temp.ValueKind == JsonValueKind.Object && isClass == 0)
                {
                    //Console.WriteLine("\nClass");
                    isClass = 1;
                }
                generator.StoreStrings(temp.ValueKind, element2.Name, isClass, languageType);
                RecursiveSearch(temp, generator, languageType);
            }
            if (!elements.MoveNext())
            {
                //Console.WriteLine("End of\n");
                isClass = 0;
                generator.Tested = 0;
            }
        }
    }
}