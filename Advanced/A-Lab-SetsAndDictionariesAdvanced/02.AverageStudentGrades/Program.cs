/*
7
John 5.20
Maria 5.50
John 3.20
Maria 2.50
Sam 2.00
Maria 3.46
Sam 3.00

 */

namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = names[0];
                decimal grade = decimal.Parse(names[1]);

                if (grades.ContainsKey(name))
                {
                    grades[name].Add(grade);
                }
                else
                {
                    grades.Add(name, new List<decimal> {grade});
                }
            }

            foreach (var student in grades)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x=>$"{x:F2}"))} (avg: {student.Value.Average():F2})");
            }
        }
    }
}