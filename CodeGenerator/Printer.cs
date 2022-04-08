namespace CodeGenerator;

public class Printer
{
    public void PrintDocument(string language, string verbose, string testToPrint)
    {
        var generator = new ClassGen();
        string filepath = @"OutputFile." + language;
        
        if (File.Exists(filepath))
        {
            File.Delete(filepath);
        }
        using (StreamWriter sw = File.CreateText(filepath))
        {
            sw.WriteLine(testToPrint + "}");
            if (verbose.Equals("v"))
            {
                Console.WriteLine(testToPrint + "}");
            }
        }
    }
}