using System.Text.Json;

namespace FizzBuzzLib
{
    public class FizzBuzz
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private int[] Divisors { get; set; }
        private string[] Tokens { get; set; }

        private const string EndpointUrl = "https://rich-red-cocoon-veil.cyclic.app/random";
        public FizzBuzz()
        {
            Divisors = new int[] { 3, 5 };
            Tokens = new string[] { "Fizz", "Buzz" };
        }
        public FizzBuzz(int[] divisors, string[] tokens)
        {
            if (divisors.Length != tokens.Length)
                throw new ArgumentException("Divisors lenght needs to match tokens lenght");

            Divisors = divisors;
            Tokens = tokens;
        }
        private string GenerateLine(int number)
        {
            string line = string.Empty;
            bool notFound = true;
            for (int j = 0; j < Divisors.Length; j++)
            {
                if (number % Divisors[j] == 0)
                {
                    notFound = false;
                    line += Tokens[j];
                }
            }
            if (notFound)
                line = number.ToString();

            return line;
        }

        public IEnumerable<string> GetFizzBuzzSequential(int start, int end)
        {
            if (end < start)
                throw new ArgumentException("End has to be smaller than start");

            for (int number = start; number <= end; number++)
            {
                yield return GenerateLine(number);
            }
        }

        public IEnumerable<string> GetFizzBuzzNonSequential(params int[] numbers)
        {
            foreach (int number in numbers)
            {
                yield return GenerateLine(number);
            }
        }
        public async Task SetInputsFromEndpoint()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(EndpointUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JsonDocument jsonDocument = JsonDocument.Parse(responseBody);

                int multiple = jsonDocument.RootElement.GetProperty("multiple").GetInt32();
                string? word = jsonDocument.RootElement.GetProperty("word").GetString();

                if (string.IsNullOrEmpty(word))
                    throw new ArgumentNullException("Word cant be null"); 

               
                Divisors = new int[] { multiple };
                Tokens = new string[] { word };
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Error retrieving inputs from the endpoint: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while processing the response: {ex.Message}");
            }
        }
    }
}