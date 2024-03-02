using System;
using System.Dynamic;

namespace Telephony;

public class Smartphone : ICallable, IBrowsable
{
    public void Call(string number)
    {
        Console.WriteLine($"Calling... {number}");
    }

    public void Browse(string website)
    {
        Console.WriteLine($"Browsing: {website}!");
    }
}
