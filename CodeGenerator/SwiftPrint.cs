namespace CodeGenerator;

public class SwiftPrint
{
    public string SubClasses { get; set; }
    public string LowerClass { get; set; }
    private string threeTabs = "\t\t\t";
    private string twoTabs = "\t\t";
    private string oneTab = "\t";

    public void NewPrinter(List<string> listed)
    {
        if (string.IsNullOrEmpty(SubClasses))
        {
            SubClasses =
                "import Fondation\n\nstruct Welcome {\n";

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
            LowerClass += (oneTab + "let " + name +  ": String\n");
        }
        else if (type.Equals("true") || type.Equals("false"))
        {
            LowerClass += (oneTab + "let " + name +  ": Bool\n");
        }
        else if (type.Equals("number"))
        {
            LowerClass += (oneTab + "let " + name +  ": Int\n");
        }
        else
        {
            LowerClass += (oneTab + "let " + name +  ": String\n");
        }
    }

    private void YesNo(string name, string type)
    {
        if (type.Equals("object"))
        {
            SubClasses += (oneTab + "let " + name + ": " + CapitalizeFirstLetter(name) + "\n");

            LowerClass += ("}\n\n" + "struct " + CapitalizeFirstLetter(name) + " {\n");
        }
        else if (type.Equals("array"))
        {
            SubClasses += (oneTab + "let " + name + ": [" + CapitalizeFirstLetter(name) + "]\n");
            LowerClass += ("}\n\n" + "struct " + CapitalizeFirstLetter(name) + " {\n");
        }
    }



    private void NoNo(string name, string type)
    {
        if (type.Equals("string"))
        {
            SubClasses += (oneTab + "let " + name + ": String\n");
        }
        else if (type.Equals("true") || type.Equals("false"))
        {
            SubClasses += (oneTab + "let " + name + ": Bool\n");
        }
        else if (type.Equals("number"))
        {
            SubClasses += (oneTab + "let " + name + ": Int\n");
        }
        else
        {
            SubClasses += (oneTab + "let " + name + ": " + type + "\n");
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