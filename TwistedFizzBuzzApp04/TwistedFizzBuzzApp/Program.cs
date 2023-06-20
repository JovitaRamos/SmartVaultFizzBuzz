using FizzBuzzLib;

var fizzBuzz = new FizzBuzz();

await fizzBuzz.SetInputsFromEndpoint();

foreach (var line in fizzBuzz.GetFizzBuzzSequential(1,100))
{
    Console.WriteLine(line);
}

Console.ReadLine();