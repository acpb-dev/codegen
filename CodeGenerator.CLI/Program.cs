namespace CodeGenerator.CLI;

class CodeGeneratorCLI
{ 
    // codegen --name Namespace.Welcome.WelcomeClass -f Text.json --code csharp -v
    // codegen -n Namespace.Some.RandomClass --file Text.json -c cs --verbose
    // codegen --name Namespace.Welcome.WelcomeClass -f Text.json --code swift -v
    // codegen -n Namespace.Other.RandomClass --file Text.json -c sw --verbose
    static void Main(string[] argss)
    {
        var commandLineArg = new CommandLineArg();
        var jsonManipulator = new JsonManipulator();
        var done = false;
        while (!done)
        {
            // Console.WriteLine("Please enter a command line :");
            // string command = Console.ReadLine();
            // string[] splittedString = command.Split(' ');
            string args = commandLineArg.VerifyCommand(argss);
            if (!args.Substring(0, 5).Equals("Error"))
            {
                Console.WriteLine("\\" + argss[4]);
                if (!File.Exists("\\" + argss[4]))
                {
                    jsonManipulator.ReadJson(argss[4], args);
                    done = true;
                }
                else
                {
                    Console.WriteLine("Error: The file was not found.");
                }
                done = true;
            }
            else
            {
                Console.WriteLine(args);
                // Console.Write("Do you want to try another command? y/n : ");
                // string yesNo = Console.ReadLine();
                // if (yesNo.Equals("n"))
                // {
                //     done = true;
                // }
                // else
                // {
                //     done = false;
                // }
                done = true;
            }
        }
    }
}