using System;
using System.Collections.Generic;
using System.Linq;

public class CreditCardValidator
{
    public static string GetCardBrand(string cardNumber)
    {
        // Remove any non-digit characters
        cardNumber = new string(cardNumber.Where(char.IsDigit).ToArray());

        // Define card brand rules
        var cardBrands = new Dictionary<string, (List<string> Prefixes, List<int> Lengths)>
        {
            { "Visa", (new List<string> { "4" }, new List<int> { 13, 16, 19 }) },
            { "Aura", (new List<string> { "50" }, new List<int> { 16 }) },
            { "enRoute", (new List<string> { "2014", "2149" }, new List<int> { 15 }) },
            { "Voyager", (new List<string> { "8699" }, new List<int> { 15 }) },
            { "Mastercard", (new List<string> { "51", "52", "53", "54", "55", "2221", "2222", "2223", "2224", "2225", "2226", "2227", "2228", "2229", "223", "224", "225", "226", "227", "228", "229", "23", "24", "25", "26", "270", "271", "2720" }, new List<int> { 16 }) },
            { "American Express", (new List<string> { "34", "37" }, new List<int> { 15 }) },
            { "Elo", (new List<string> { "4011", "4312", "4389", "4514", "4573", "4576", "5041", "5066", "5067", "5090", "6277", "6362", "6363" }, new List<int> { 16 }) },
            { "Diners Club", (new List<string> { "300", "301", "302", "303", "304", "305", "309", "36", "38", "39" }, new List<int> { 14, 16 }) },
            { "Discover", (new List<string> { "6011", "622126", "622127", "622128", "622129", "62213", "62214", "62215", "62216", "62217", "62218", "62219", "6222", "6223", "6224", "6225", "6226", "6227", "6228", "62290", "62291", "62292", "62293", "62294", "622925", "644", "645", "646", "647", "648", "649", "65" }, new List<int> { 16 }) },
            { "Hipercard", (new List<string> { "6062", "3841" }, new List<int> { 16 }) },
            { "JCB", (new List<string> { "3528", "3529", "353", "354", "355", "356", "357", "358" }, new List<int> { 16 }) },
            { "Maestro", (new List<string> { "5018", "5020", "5038", "5893", "6304", "6759", "6761", "6762", "6763" }, new List<int> { 12, 13, 14, 15, 16, 17, 18, 19 }) }
        };

        // Check card number against each brand
        foreach (var brand in cardBrands)
        {
            if (brand.Value.Prefixes.Any(prefix => cardNumber.StartsWith(prefix)) && brand.Value.Lengths.Contains(cardNumber.Length))
            {
                return brand.Key;
            }
        }

        return "Unknown";
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a credit card number:");
        string cardNumber = Console.ReadLine();

        string cardBrand = GetCardBrand(cardNumber);
        Console.WriteLine($"The card brand is: {cardBrand}");
    }
}