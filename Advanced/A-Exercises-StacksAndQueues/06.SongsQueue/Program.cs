/*
All Over Again, Watch Me
Play
Add Watch Me
Add Love Me Harder
Add Promises
Show
Play
Play
Play
Play

 */

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> songsQueue = new Queue<string>(songs);

            while (songsQueue.Any())
            {
                string[] command = Console.ReadLine().Split(" ");

                if (command[0] == "Play")
                {
                    songsQueue.Dequeue();
                }

                else if (command[0] == "Add")
                {
                    string songName = string.Join(" ", command.Skip(1));
                    if (!songsQueue.Contains(songName))
                    {                     
                        songsQueue.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                }

                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}