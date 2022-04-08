namespace CodeGenerator;

public class CsPrint
{
    public string SubClasses { get; set; }
    public string LowerClass { get; set; }
    private string threeTabs = "\t\t\t";
    private string twoTabs = "\t\t";
    private string oneTab = "\t";
    
    public void NewPrinter(List<string> listed, string args)
    {
        string[] argsList = args.Split(" ");
        if (string.IsNullOrEmpty(SubClasses))
        {
            SubClasses = "\n\nusing System.Text.Json;\n\nnamespace " + argsList[3] + "\n{\n\tpublic class " + argsList[4] + "\n\t{\n";
                
        }
        KnockOnWood(listed[0], listed[1].ToLower(), listed[2], listed[3]);
    }

    private void KnockOnWood(string name, string type, string isClass, string isInClass)
    {
        if (isClass.Equals("NO") && isInClass.Equals("NO"))
        {
            NoNo(name, type);
        }
        else if (isClass.Equals("YES") && isInClass.Equals("NO"))
        {
            YesNo(name, type);
        }
        else if (isClass.Equals("NO") && isInClass.Equals("YES"))
        {
            NoYes(name, type);
        }
    }

    private void NoYes(string name, string type)
    {
        if (type.Equals("string"))
        {
            LowerClass += (twoTabs + "public string " + name + " { get; set; }\n");
        }
        else if (type.Equals("true") || type.Equals("false"))
        {
            LowerClass += (twoTabs + "public bool " + name + " { get; set; }\n");
        }
        else if (type.Equals("number"))
        {
            LowerClass += (twoTabs + "public int " + name + " { get; set; }\n");
        }
        else
        {
            LowerClass += (twoTabs + "public string " + name + " { get; set; }\n");
        }
    }

    private void YesNo(string name, string type)
    {
        if (type.Equals("object"))
        {
            SubClasses += (twoTabs + "public Dictionary<string, " + CapitalizeFirstLetter(name) + ">? " + name +  " { get; set; }\n");
            
            LowerClass += (oneTab + "}\n\n" + oneTab + "public class " + CapitalizeFirstLetter(name) + "\n\t{\n");
        }
        else if (type.Equals("array"))
        {
            SubClasses += (twoTabs + "public IList<" + CapitalizeFirstLetter(name) + ">? " + name +  " { get; set; }\n");
            LowerClass += (oneTab + "}\n\n" + oneTab + "public class " + CapitalizeFirstLetter(name) + "\n\t{\n");
        }
    }
    
    

    private void NoNo(string name, string type)
    {
        if (type.Equals("string"))
        {
            SubClasses += (twoTabs + "public string? " + name + " { get; set; }\n");
        }
        else if (type.Equals("true") || type.Equals("false"))
        {
            SubClasses += (twoTabs + "public bool " + name + " { get; set; }\n");
        }
        else if (type.Equals("number"))
        {
            SubClasses += (twoTabs + "public int " + name + " { get; set; }\n");
        }
        else
        {
            SubClasses += (threeTabs + "twoTabs + public " + type + " " + name + " { get; set; }\n");
        }
    }

    private string CapitalizeFirstLetter(string word)
    {
        if (word.Length == 0)
            return "";
        else if (word.Length == 1)
            return char.ToUpper(word[0]).ToString();
        else
            return char.ToUpper(word[0]) + word.Substring(1);
    }
}