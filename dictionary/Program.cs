using System.Text.Json;





Console.WriteLine("Hello, World!");
await FetchWordAsync();


async Task FetchWordAsync()
{

    var incomingList = new List<Word>();

    using (var client = new HttpClient())
    {
        var endpoint = new Uri("https://api.dictionaryapi.dev/api/v2/entries/en/hello");
        var result = client.GetAsync(endpoint).Result;
        var json = await result.Content.ReadAsStringAsync();

        Console.WriteLine(json);






        incomingList = JsonSerializer.Deserialize<List<Word>>(json);
        Word word = incomingList[0];

        Console.WriteLine($"Word: {word.word}");
        Console.WriteLine();
        List<Meaning> meanings = incomingList[0].meanings;

        int n = 1;
        foreach (var meaning in meanings)
        {
            string partOfSpeech = char.ToUpper(meaning.partOfSpeech.First()) + meaning.partOfSpeech.Substring(1).ToLower();
            var meaningString = $"{n}. {partOfSpeech}: ";
            Console.WriteLine(meaningString);
            foreach (var definition in meaning.definitions)
            {
                Console.WriteLine($"\t-> {definition.definition}");
            }
            Console.WriteLine();
            n++;
        }
    }    
}