using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Загрузка текстового файла
        string textFilePath = "Text1.txt";
        string text = File.ReadAllText(textFilePath);

        // Удаление знаков пунктуации
        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        // Разделение текста на слова
        string[] words = noPunctuationText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Подсчет количества повторений каждого слова
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
            }
            else
            {
                wordCount[word] = 1;
            }
        }

        // Нахождение 10 самых часто встречающихся слов
        var topWords = wordCount.OrderByDescending(pair => pair.Value).Take(10);

        // Вывод результатов
        Console.WriteLine("Топ 10 слов, которые чаще всего встречаются в тексте:");
        foreach (var pair in topWords)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value} раз");
        }
    }
}
