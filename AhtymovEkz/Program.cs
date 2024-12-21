using System.Security.Cryptography;
using System.Text.Json;
using AhtymovEkz;
using AhtymovEkz.Models;
using Newtonsoft.Json;

string inputPath = @"C:\Users\senchaaa\Downloads\Card.json";
string outputPath = @"C:\Users\senchaaa\Downloads\CardResult.json";


var contentJson = File.ReadAllText(inputPath);
var modelContentCards = JsonConvert.DeserializeObject<ListCard>(contentJson);

var aesEncryptor = new AESEncryptor();
var blake2Hasher = new BLAKE2Hasher();
foreach (var card in modelContentCards.Cards)
{
    EncryptCardFields(card);
}

void EncryptCardFields(Card card)
{
    card.Year = aesEncryptor.Encrypt(card.Year);
    card.Month = aesEncryptor.Encrypt(card.Month);
    card.Number = aesEncryptor.Encrypt(card.Number);
    card.Family = aesEncryptor.Encrypt(card.Family);
    card.Name = aesEncryptor.Encrypt(card.Name);
    card.Cvc = blake2Hasher.Hash(card.Cvc);
}


File.WriteAllText(outputPath, JsonConvert.SerializeObject(modelContentCards));
Console.WriteLine($"Данные записаны в файл по пути \n{outputPath}");