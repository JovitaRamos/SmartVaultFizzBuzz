using FizzBuzzLib;

var fizzBuzz = new FizzBuzz();

foreach (var line in fizzBuzz.GetFizzBuzzSequential(1, 100))
{
    Console.WriteLine(line);
}