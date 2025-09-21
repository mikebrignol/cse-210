using System;

public class Reference
{
    private int chapterNum;
    private int verseStart;
    private int verseEnd;
    private string bookName;

    public Reference(string book, int chapter, int verse)
    {
        bookName = book;
        chapterNum = chapter;
        verseStart = verse;
        verseEnd = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        bookName = book;
        chapterNum = chapter;
        verseStart = startVerse;
        verseEnd = endVerse;
    }

    public string GetDisplayText()
    {
        if (verseStart == verseEnd)
            return $"{bookName} {chapterNum}:{verseStart}";
        else
            return $"{bookName} {chapterNum}:{verseStart}-{verseEnd}";
    }
}