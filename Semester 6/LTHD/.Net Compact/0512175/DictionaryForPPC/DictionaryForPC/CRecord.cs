using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
public class CRecord
{
    private string _meaning;
    private string _word;
    public String Meaning
    {
        get { return _meaning; }
        set { _meaning = value; }
    }
    public string Word
    {
        get { return _word; }
        set { _word = value; }
    }

    public CRecord()
    {
        Word = "";
        Meaning = "";
    }
    public CRecord(string szWord, string szMeaning)
    {
        Word = szWord;
        Meaning = szMeaning;
    }
    public override string ToString()
    {
        string result = "";
        result += Word + "\t\t" + Meaning;
        return result;
    }
}