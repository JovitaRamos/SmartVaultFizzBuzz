using FizzBuzzLib;

var fizzBuzz = new FizzBuzz(new[] { 5, 9, 27 }, new[] { "Fizz", "Buzz", "Bar" });

foreach (var line in fizzBuzz.GetFizzBuzzSequential(-20, 127))
{
    Console.WriteLine(line);
}

Console.ReadLine();