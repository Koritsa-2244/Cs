using BarcodeLib;
using ShowcaseLib;
using SoundDeviceLib;
using System;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        var device1 = new SoundDevice("790920", "Гарри Поттер", 2023, "Джоан Роулинг", "Horror");
        Console.WriteLine(device1.ToString());

        Showcase shell = 5;

        shell[1] = device1;

        Console.WriteLine(shell);
        var books = new List<Product>
        {
            new SoundDevice("234757", "Nefsdf", 2024, "hsdsdf", "dfsdf"),
            new SoundDevice("89122", "ffwsffs", 2018, "hsdsdf", "dfsdf"),
            new SoundDevice("562037", "pghkkr", 1999, "hsdsdf", "dfsdf"),
        };


        foreach (var book in books)
        {
            shell.Push(book);
        }
        Console.WriteLine(shell.ToString());
        shell.ChangePosition(1, 3);
        Console.WriteLine(shell);

        shell.SortName();

        Console.WriteLine(shell.ToString());

        //shell.SortID();
        Console.WriteLine(shell);


        //shell.ChangeID();

        shell.ID++;

        Console.WriteLine(shell);
    }
}