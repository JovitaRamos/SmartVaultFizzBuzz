using FizzBuzzLib;

var fizzBuzz = new FizzBuzz();

foreach (var line in fizzBuzz.GetFizzBuzzNonSequential(new int[] { -5, 6, 300, 12, 15 }))
{
    Console.WriteLine(line);
}

Console.ReadLine();