using System.Text.Json;
using Generics;

namespace CodeGenerator;

public class ClassGen
{
    
    public int Tested = 0;
    CsPrint csPrint = new ();
    SwiftPrint swiftPrint = new();


    public void printJsonText(string languageType)
    {
        string[] argsList = languageType.Split(' ');
        var printer = new Printer();
        Console.WriteLine(argsList[0]);
        if (argsList[0].Equals("cs"))
        {
            printer.PrintDocument("cs", argsList[1] ,csPrint.SubClasses + csPrint.LowerClass);
        } 
        else
        {
            printer.PrintDocument("swift", argsList[1] ,swiftPrint.SubClasses + swiftPrint.LowerClass);
        }
    }
    
    
    public void StoreStrings(JsonValueKind valueKind, string value, int isNotClass, string langugeType)
    {
        List<string> listy = new List<string>();
        if (isNotClass > 1)
        {
            if (isNotClass == 2)
            {
                listy.Add(value);
                listy.Add(valueKind.ToString());
                listy.Add("NO");
                listy.Add("YES");
            }
            else
            {
                listy.Add(value);
                listy.Add(valueKind.ToString());
                listy.Add("NO");
                listy.Add("YES");
            }
        }
        else if (isNotClass == 1)
        {
            if (Tested == 0)
            {
                listy.Add(value);
                listy.Add(valueKind.ToString());
                listy.Add("YES");
                listy.Add("NO");
                Tested++;
            }
            else
            {
                listy.Add(value);
                listy.Add(valueKind.ToString());
                listy.Add("NO");
                listy.Add("YES");
            }
        }
        else
        {
            if (valueKind == JsonValueKind.Array)
            {
                listy.Add(value);
                listy.Add(valueKind.ToString());
                listy.Add("YES");
                listy.Add("NO");
            }
            else
            {
                listy.Add(value);
                listy.Add(valueKind.ToString());
                listy.Add("NO");
                listy.Add("NO");
            }
        }
        int i = 0;
        List<string> listed = new List<string>();
        foreach (var listItem in listy)
        {
            i++;
            if (i % 4 != 0)
            {
                listed.Add(listItem);
            }
            else
            {
                listed.Add(listItem);
                if (langugeType.Substring(0, 2).Equals("cs"))
                {
                    csPrint.NewPrinter(listed, langugeType);
                }
                else
                {
                    swiftPrint.NewPrinter(listed);
                }
                listed.Clear();
            }
        }
    }

    private string languageChooser(string lang)
    {
        return "";
    }
}