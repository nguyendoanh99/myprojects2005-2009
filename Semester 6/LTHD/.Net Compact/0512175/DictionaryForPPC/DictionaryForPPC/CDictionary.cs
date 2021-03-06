using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Globalization;
using System.Collections;
public struct Infor
{
    public string szWord;
    public int iPosition;
};
#region Định nghĩa các hàm so sánh
// Định nghĩa lại hàm so sánh 2 chuỗi (trong file eng-ita, chuỗi -in-law nằm ở giữa do ký tự Unicode khác với ký tự có mã là 46)
public class CompareString: IComparer<string>
{
    #region IComparer<string> Members

    public int Compare(string szX, string szY)
    {
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
// So sánh 2 chuỗi giống nhau
public class CompareInfor : IComparer<Infor>
{
    public int Compare(Infor x, Infor y)
    {
        string szX = x.szWord.TrimEnd(new char[] { ' ' });
        string szY = y.szWord.TrimEnd(new char[] { ' ' });
        return new CompareString().Compare(szX, szY);
    }
}
// So sánh chuỗi x có phải là phần đầu của chuỗi y ko
public class CompareInforWithoutExact : IComparer<Infor>
{
    // y là chuỗi cần so sánh
    public int Compare(Infor x, Infor y)
    {
        string szX = x.szWord.TrimEnd(new char[] { ' ' });
        string szY = y.szWord.TrimEnd(new char[] { ' ' });

        szY = szY.ToUpper();
        szX = szX.ToUpper();

        if (szX.Length > szY.Length)
            szX = szX.Substring(0, szY.Length);

        int t = new CompareString().Compare(szX, szY);
        return t;
    }
}
#endregion
public class CDictionary
{
    #region Static Variable
    // Qui định số byte để mô tả thông tin file Index
    static private int _iSizeCountIndex = 4;
    static private int _iSizeKeywordIndex = 1;
    static private int _iSizePositionIndex = 1;
    static private int _iPositionIndex; // Số byte dành để lưu vị trí bắt đầu của Meaning trong file Content (được mô tả trong file Index)
    // Qui định số byte để mô tả thông tin file Hash
    static private int _iSizeCountHash = 2;
    static private int _iSizeKeywordHash = 1;
    static private int _iSizePositionHash = 1;
    #endregion
    #region Attributes
    private List<int> _Index = new List<int>();
    private List<Infor> _Hash = new List<Infor>();
    private FileStream _fsContent = null;
    private FileStream _fsIndex = null;
    #endregion 
    #region Properties
    // Lấy word và meaning của từ thứ index
    public CRecord this[int index]
    {
        get 
        {
            Infor word1 = GetInfoFromIndex(index);
            Infor word2 = GetInfoFromIndex(index + 1);

            int pos = word1.iPosition;
            int len = word2.iPosition - pos;

            _fsContent.Position = pos;
            byte[] temp = new byte[len];
            _fsContent.Read(temp, 0, len);

            CRecord result = new CRecord(word1.szWord, Encoding.UTF8.GetString(temp, 0, temp.Length));
            return result;
        }
    }
    
    // Số từ có trong từ điển 
    public int Count
    {
        get { return _Index.Count - 2; } // Bỏ 2 phần tử thừa cuối cùng
    }
    
    // Danh sách các từ
    public List<string> ListWord
    {
        get
        {
            List<string> result = new List<string>();
            _fsIndex.Position = _Index[0];
            // Bỏ phần tử cầm canh            
            for (int i = 0; i < Count; ++i)
            {
                byte[] arrtemp = new byte[_Index[i + 1] - _Index[i]];
                _fsIndex.Read(arrtemp, 0, arrtemp.Length);
                string key = Encoding.UTF8.GetString(arrtemp, 0, arrtemp.Length - _iPositionIndex);
                result.Add(key);
            }

            return result;
        }
    }
    #endregion
    #region Public Methods
    // Đọc file từ điển (*.con, *.ind, *.has) để lấy những thông tin cần thiết
    public void ReadFile(string szFileName)
    {
        _fsIndex = new FileStream(szFileName + ".ind", FileMode.Open, FileAccess.Read);
        FileStream fsHash = new FileStream(szFileName + ".has", FileMode.Open, FileAccess.Read);
        _fsContent = new FileStream(szFileName + ".con", FileMode.Open, FileAccess.Read);

        _Index.Clear();
        _Hash.Clear();
        FileToIndex(_fsIndex, _Index, _iSizeCountIndex, _iSizeKeywordIndex, _iSizePositionIndex);
        FileToHash(fsHash, _Hash, _iSizeCountHash, _iSizeKeywordHash, _iSizePositionHash);
                
        /*
        for (int i = 0; i < count; ++i)
        {
            arrtemp = new byte[indexOfindex[i + 1] - indexOfindex[i]];
            fsIndex.Read(arrtemp, 0, arrtemp.Length);
            string key = Encoding.UTF8.GetString(arrtemp, 0, arrtemp.Length - iPosition);
            int pos = CFunctions.GetInt(arrtemp, arrtemp.Length - iPosition, iPosition);

            Infor ele = new Infor();
            ele.szWord = key.TrimEnd(new char[] { ' ' });
            ele.iPosition = pos;
            _Index.Add(ele);
        }
        */
        // Phần tử cầm canh của file _Hash
        Infor temp = new Infor();
        temp.iPosition = _Index.Count - 1; // - 1: không tính phần tử cầm canh của _Index
        _Hash.Add(temp);

        fsHash.Close();
    }
    public int FindWord(string szWord)
    {
        if (_Index.Count == 0)
            return -1;
        if (szWord.Length == 0)
            return -1;

        int result = -1;
        // Tìm vị trí của word có ký tự đầu trùng với ký tự đầu của szWord
        Infor temp = new Infor();
        temp.szWord = szWord[0].ToString();
        int index = _Hash.BinarySearch(0, _Hash.Count - 1, temp, new CompareInfor());
        result = index;

        if (index >= 0)
        {
            int begin = _Hash[index].iPosition;
            int count = _Hash[index + 1].iPosition - begin;
            int indexTemp = -1;
            temp.szWord = szWord;
            index = BinarySearchForIndex(begin, count, temp, new CompareInforWithoutExact());
            while (index >= 0)
            {
                indexTemp = index; 
                count = index - begin;
                index = BinarySearchForIndex(begin, count, temp, new CompareInforWithoutExact());
            }
            index = indexTemp;

            result = index;
        }
        return result;
    }
    #endregion
    #region Private Methods
    // Lấy thông tin của Record (word, pos) thứ index trong file Index
    private Infor GetInfoFromIndex(int index)
    {
        Infor kq = new Infor();

        int posWord = _Index[index];
        int lenRecordWord = _Index[index + 1] - _Index[index];

        _fsIndex.Position = posWord;
        byte[] temp = new byte[lenRecordWord];
        _fsIndex.Read(temp, 0, temp.Length);

        kq.szWord = Encoding.UTF8.GetString(temp, 0, lenRecordWord - _iPositionIndex);
        kq.iPosition = CFunctions.GetInt(temp, lenRecordWord - _iPositionIndex, _iPositionIndex);

        return kq;
    }

    public int BinarySearchForIndex(int iBegin, int iCount, Infor item, IComparer<Infor> comparer)
    {
        int kq = -1;
        if (iBegin >= 0 && iCount > 0)
        {
            int begin = iBegin;
            int end = begin + iCount - 1;
            int mid;
            while (begin <= end)
            {
                mid = (begin + end) / 2;
                Infor ItemMid = GetInfoFromIndex(mid);
                int temp = comparer.Compare(ItemMid, item);

                if (temp > 0)
                    end = mid - 1;
                else
                    if (temp < 0)
                        begin = mid + 1;
                    else
                    {
                        kq = mid;
                        break;
                    }
            }
        }
        return kq;
    }

    // Đưa vị trí các word của file Index vào List<int>
    // iSizeCount: số byte qui định về Số lượng kí tự
    // iSizeKeyword: số byte qui định về Keyword
    // iSizePosition: số byte qui định về Position
    // iSizeCount + iSizeKeyword + iSizePosition: tổng số byte dùng để mô tả thông tin của file
    private void FileToIndex(FileStream fs, List<int> lst, int iSizeCount, int iSizeKeyword, int iSizePosition)
    {
        int iCount, iKeyword, iPosition;
        LayThongTinMoTa(fs, iSizeCount, iSizeKeyword, iSizePosition, out iCount, out iKeyword, out iPosition);

        byte[] arrtemp = new byte[(iCount + 1) * iKeyword];
        fs.Read(arrtemp, 0, arrtemp.Length);
        for (int i = 0; i < arrtemp.Length; i += iKeyword)
        {
            lst.Add(CFunctions.GetInt(arrtemp, i, iKeyword));
        }
        _iPositionIndex = iPosition;
    }

    // Đưa nội dung của file Hash vào List<Infor>
    // iSizeCount: số byte qui định về Số lượng kí tự
    // iSizeKeyword: số byte qui định về Keyword
    // iSizePosition: số byte qui định về Position
    // iSizeCount + iSizeKeyword + iSizePosition: tổng số byte dùng để mô tả thông tin của file
    private void FileToHash(FileStream fs, List<Infor> lst, int iSizeCount, int iSizeKeyword, int iSizePosition)
    {
        int iCount;
        int iKeyword;
        int iPosition;
        LayThongTinMoTa(fs, iSizeCount, iSizeKeyword, iSizePosition, out iCount, out iKeyword, out iPosition);

        byte[] temp = new byte[iKeyword + iPosition];
        while (fs.Read(temp, 0, temp.Length) != 0)
        {
            string key = Encoding.UTF8.GetString(temp, 0, iKeyword);
            int pos = CFunctions.GetInt(temp, iKeyword, iPosition);

            Infor ele = new Infor();
            ele.szWord = key.TrimEnd(new char[] { ' ' });
            ele.iPosition = pos;
            lst.Add(ele);
        }
    }

    // Lấy thông tin mô tả của file
    private void LayThongTinMoTa(FileStream fs, int iSizeCount, int iSizeKeyword, int iSizePosition,
        out int iCount, out int iKeyword, out int iPosition)
    {
        byte[] temp = new byte[iSizeCount + iSizeKeyword + iSizePosition];
        fs.Read(temp, 0, temp.Length);
        iCount = CFunctions.GetInt(temp, 0, iSizeCount);
        iKeyword = CFunctions.GetInt(temp, iSizeCount, iSizeKeyword);
        iPosition = CFunctions.GetInt(temp, iSizeCount + iSizeKeyword, iSizePosition);
    }
    #endregion
}
