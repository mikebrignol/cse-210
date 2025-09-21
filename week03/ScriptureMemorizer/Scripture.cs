using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Scripture
{
    private Reference refInfo;
    private List<Word> wordList;
    private Random rng = new Random();

    public Scripture(Reference reference, string textContent)
    {
        refInfo = reference;
        wordList = textContent.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(token => new Word(token)).ToList();
    }

    public void HideRandomWords(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var visibleWords = wordList.Where(w => !w.IsHidden()).ToList();
            if (visibleWords.Count == 0) break;

            int pick = rng.Next(visibleWords.Count);
            visibleWords[pick].Hide();
        }
    }

    public string GetDisplayText()
    {
        string joined = string.Join(" ", wordList.Select(w => w.GetDisplayText()));
        return $"{refInfo.GetDisplayText()} - {joined}";
    }

    public bool AllWordsHidden()
    {
        return wordList.All(w => w.IsHidden());
    }
}