using Inlämning;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Client code.
        Originator originator = new Originator("NusmirSmajovic");
        Caretaker caretaker = new Caretaker(originator);

        caretaker.Backup();
        originator.DoSomething();

        caretaker.Backup();
        originator.DoSomething();

        caretaker.Backup();
        originator.DoSomething();

        Console.WriteLine();
        caretaker.ShowHistory();

        Console.WriteLine("\nClient: gå tillbaka!\n");
        caretaker.Undo();

        Console.WriteLine("\n\nClient: En gång till!\n");
        caretaker.Undo();

       

        Console.WriteLine();
        
    }
}
