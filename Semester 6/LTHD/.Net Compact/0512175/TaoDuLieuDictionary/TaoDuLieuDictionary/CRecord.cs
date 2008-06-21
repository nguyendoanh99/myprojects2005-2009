using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
namespace TaoDuLieuDictionary
{
    public class CRecord:IComparable<CRecord>
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
        public static CRecord CreateNode(XmlNode node)
        {            
            string szWord = node.ChildNodes[0].InnerText; // word
            string szMeaning = node.ChildNodes[1].InnerText; // meaning

            CRecord result = new CRecord(szWord, szMeaning);
            return result;
        }
        public override string ToString()
        {
            string result = "";
            result += Word + "\t\t" + Meaning;
            return result;
        }

        #region IComparable<CRecord> Members

        public int CompareTo(CRecord other)
        {
            string szX = this.Word.TrimEnd(new char[] { ' ' }).ToUpper();
            string szY = other.Word.TrimEnd(new char[] { ' ' }).ToUpper();
            return szX.CompareTo(szY);
        }

        #endregion
    }
    public class Com:IComparer<CRecord>
    {
        #region IComparer<CRecord> Members

        public int Compare(CRecord x, CRecord y)
        {
            string szX = x.Word.TrimEnd(new char[] { ' ' });
            string szY = y.Word.TrimEnd(new char[] { ' ' });
            // "in" < "-in"
            int i = 0;
            while (i < szX.Length && i < szY.Length)
            {
                int t = char.ToUpper(szX[i]) - char.ToUpper(szY[i]);
                if (t == 0)
                    ++i;
                else
                    return t;
            }
            return szX.Length - szY.Length;
        }
        #endregion
    }
    
}
