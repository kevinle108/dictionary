
using System.Text.Json;

Console.WriteLine("Hello, World!");

var incomingList = new List<Word>();

using (var client = new HttpClient())
{
    var endpoint = new Uri("https://api.dictionaryapi.dev/api/v2/entries/en/hello");
    var result = client.GetAsync(endpoint).Result;
    var json = result.Content.ReadAsStringAsync().Result;
    Console.WriteLine();
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

public record struct Word
(
    string word,
    List<Meaning> meanings,
    List<string> sourceUrls
);

public record struct Meaning
(
    string partOfSpeech,
    List<Definition> definitions
);

public record struct Definition
(
    string definition
);

//public record struct Word(
//    public string word,
//    public List<Meaning> meanings,
//    public List<string> sourceUrls
//);

//public record struct Meaning
//(
//    string partOfSpeech,
//    List<Definition> definitions
//);

//public record struct Definition
//(
//    public string definition,
//);



//public struct Word
//{
//    public string word;
//    public List<Meaning> meanings;
//    public List<string> sourceUrls;
//}

//public struct Meaning
//{
//    public string partOfSpeech;
//    public List<Definition> definitions;
//}

//public struct Definition
//{
//    public string definition;
//}


//public class Word
//{
//    public string word;
//    public List<Meaning> meanings;
//    public List<string> sourceUrls;
//}

//public class Meaning
//{
//    public string partOfSpeech;
//    public List<Definition> definitions;
//}

//public class Definition
//{
//    public string definition;
//}


