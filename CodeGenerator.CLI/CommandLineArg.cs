namespace CodeGenerator.CLI;

public class CommandLineArg
{// codegen --name Namespace.Welcome.WelcomeClass -f Text.json --code csharp -v
    public string VerifyCommand(string[] command)
    {
        string verbose = " nv";
        string nameSpace = "";
        foreach (var args in command)
        {
            if (args.Equals("-v") || args.Equals("--verbose"))
            {
                verbose = " v";
            }
        }
        if (command.Length >= 5)
        {
            if (command[0].Equals("codegen"))
            {
                if (command.Length >= 5)
                {
                    if (command[1].Equals("-n") || command[1].Equals("--name"))
                    {
                        if ((command[2].Split('.')[0].Equals("Namespace")))
                        {
                            if ((command[2].Split('.').Length == 3))
                            {
                                nameSpace = " " + command[2].Replace('.', ' ');
                                if (command[3].Equals("-f") || command[3].Equals("--file"))
                                {
                                    if (command[4].Substring(command[4].Length - 5).Equals(".json"))
                                    {
                                        if (command.Length > 6)
                                        {
                                            if (command[5].Equals("-c") || command[5].Equals("--code"))
                                            {
                                                if (command[6].Equals("sw") || command[6].Equals("swift"))
                                                {
                                                    return "sw" + verbose + nameSpace;
                                                }
                                                else if (command[6].Equals("cs") || command[6].Equals("csharp"))
                                                {
                                                    
                                                }
                                                else
                                                {
                                                    return "Error: Unknown language.";
                                                }
                                                {
                                                    return "cs" + verbose + nameSpace;
                                                }
                                            }
                                            else
                                            {
                                                return "cs" + verbose + nameSpace;
                                            }
                                        }
                                        else
                                        {
                                            return "cs" + verbose + nameSpace;
                                        }
                                    }
                                    else
                                    {
                                        return "Error: The file specified doesn't have the right extension.";
                                    }
                                }
                                else
                                {
                                    return "Error: A file was not specified.";
                                }
                            }
                            else
                            {
                                return
                                    "Error: The Namespace and Class name doesn't have the right format. See example below : \n codegen -n Namespace.Models.MyClass -f test.json";
                            }
                        }
                        else
                        {
                            return "Error: Namespace not specified.";
                        }
                    }
                    else
                    {
                        return "Error: The parameter name was not present";
                    }
                }
                else
                {
                    return "Error: Missing arguments.";
                }
            }
            else
            {
                return "Error: Unknown Command.";
            }
        }
        else
        {
            return "Error: not enough arguments.";
        }
    }
}