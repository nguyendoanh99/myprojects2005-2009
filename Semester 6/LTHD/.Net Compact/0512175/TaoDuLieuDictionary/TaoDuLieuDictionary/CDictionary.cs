using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Globalization;
using System.Collections;
namespace TaoDuLieuDictionary
{
    // Mô tả thông tin của một record trong file
    struct Record
    {
        public int iKeyword;   // Số byte dành để lưu trữ phần keyword
        public int iPosition;  // Số byte dành cho lưu trữ vị trí của phần nội dung có liên quan đến Keyword
    };
    class CDictionary
    {
        private List<CRecord> _arrRecord = new List<CRecord>();
        public CRecord this[int index]
        {
            get { return _arrRecord[index]; }
            set { _arrRecord[index] = value; }
        }
        public int Count
        {
            get { return _arrRecord.Count; }
        }
        public void ReadFile(string szFileName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(szFileName);
                XmlElement root = doc.DocumentElement;
                XmlNode node = root.FirstChild;
                while (node != null)
                {
                    _arrRecord.Add(CRecord.CreateNode(node));
                    node = node.NextSibling;
                }
                _arrRecord.Sort(new Com());
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
        public void WriteFile(string szFileName)
        {
            #region Mô tả thông tin cho Record của file Index
            Record IndexRecord = new Record();
            IndexRecord.iKeyword = 4; // qui định số byte dùng để lưu vị trí bắt đầu của Word trong file Index
            IndexRecord.iPosition = 4; // qui định số byte dùng để lưu vị trí bắt đầu của Meaning trong file Content
            #endregion
            #region Mô tả thông tin cho Record của file Hash
            Record HashRecord = new Record();
            HashRecord.iKeyword = 2; // Số byte dành cho ký tự bắt đầu
            HashRecord.iPosition = 4; // Số byte dành cho lưu trữ vị trí của Word có ký tự bắt đầu là Keyword trong file Index
            #endregion
            
            #region Đặt tên file Content, Index, Hash, Khai báo biến FileStream
            string szFileContent = szFileName + ".con";
            string szFileIndex = szFileName + ".ind";
            string szFileHash = szFileName + ".has";
            FileStream fsContent = null;
            FileStream fsIndex = null;
            FileStream fsHash = null;
            #endregion

            _arrRecord.Add(new CRecord("0", "")); // Không dùng đến phần tử này
            try
            {
                int startContent = 0; // Vị trí bắt đầu của nội dung của một word trong file Content
                char CurrentChar = '\0'; // Đang xét đến những word có ký tự bắt đầu là CurrentChar
                int countHash = 0; // Số phần tử trong file hash

                #region Open File to Write
                fsContent = new FileStream(szFileContent, FileMode.Create, FileAccess.Write);
                fsIndex = new FileStream(szFileIndex, FileMode.Create, FileAccess.Write);
                fsHash = new FileStream(szFileHash, FileMode.Create, FileAccess.Write);
                #endregion
                
                #region Information of Index File
                // 6 byte đầu tiên của file Index dùng để chứa thông tin
                // 4 byte đầu: số record (số lượng từ)
                // 1 byte tiếp theo: qui định số byte dùng để lưu vị trí bắt đầu của Word trong file Index
                // 1 byte tiếp theo: qui định số byte dùng để lưu vị trí bắt đầu của Meaning trong file Content

                byte[] temp = CFunctions.GetBytes(_arrRecord.Count, 4);
                fsIndex.Write(temp, 0, temp.Length);
                temp = CFunctions.GetBytes(IndexRecord.iKeyword, 1);
                fsIndex.Write(temp, 0, temp.Length);
                temp = CFunctions.GetBytes(IndexRecord.iPosition, 1);
                fsIndex.Write(temp, 0, temp.Length);

                // (_arrRecord.Count + 1) * IndexRecord.iKeyword byte tiếp theo của file Index lưu 
                // vị trí các word trong file Index
                
                // mảng dùng để lưu vị trí các word
                byte[] arrPosOfWord = new byte[(_arrRecord.Count + 1) * IndexRecord.iKeyword]; 
                fsIndex.Write(arrPosOfWord, 0, arrPosOfWord.Length);// Ghi tạm, sẽ được cập nhật lại sau

                #endregion
             
                #region Information of Hash File
                // 4 byte đầu tiên của file Hash dùng để chứa thông tin
                // 2 byte đầu: số record
                // 1 byte tiếp theo: qui định số byte dành cho ký tự bắt đầu
                // 1 byte tiếp theo: qui định số byte dùng để lưu vị trí của Word có ký tự bắt đầu là Keyword trong file Index
                
                fsHash.Write(new byte[2], 0, 2); // Ghi tạm, sẽ cập nhật lại ở đoạn cuối của hàm
                temp = CFunctions.GetBytes(HashRecord.iKeyword, 1);
                fsHash.Write(temp, 0, temp.Length);
                temp = CFunctions.GetBytes(HashRecord.iPosition, 1);
                fsHash.Write(temp, 0, temp.Length);
                #endregion
                
                for (int i = 0; i < _arrRecord.Count; ++i)
                {
                    string word = this[i].Word;
                    string meaning = this[i].Meaning;
                    byte[] tempContent = Encoding.UTF8.GetBytes(meaning);

                    #region ContentFile
                    // Ghi nội dung lên file Content
                    fsContent.Write(tempContent, 0, tempContent.Length);
                    #endregion         

                    #region IndexFile
                    // Ghi word và vị trí bắt đầu của word lên file Index
                    // Mỗi record gồm (IndexRecord.iKeyword + IndexRecord.iPosition) byte
                    // IndexRecord.iKeyword byte đầu tiên: word ((iKeyword/2) ký tự)
                    // IndexRecord.iPosition byte cuối: vị trí bắt đầu nội dung của word trong file Content

                    byte[] tempPos = CFunctions.GetBytes((int)fsIndex.Position, IndexRecord.iKeyword);
                    Array.Copy(tempPos, 0, arrPosOfWord, i * tempPos.Length, tempPos.Length);

                    byte[] tempStart = CFunctions.GetBytes(startContent, IndexRecord.iPosition);
                    byte[] tempWord = Encoding.UTF8.GetBytes(word);

                    fsIndex.Write(tempWord, 0, tempWord.Length);
                    fsIndex.Write(tempStart, 0, tempStart.Length);
                    #endregion

                    #region HashFile
                    // Ghi nội dung của file Hash
                    // Mỗi record của file Hash gồm (HashRecord.iKeyword + HashRecord.iPosition) byte
                    // HashRecord.iKeyword byte đầu tiên chứa ký tự đầu tiên của word
                    // HashRecord.iPosition byte tiếp chứa vị trí của word đầu tiên có ký tự đầu là (HashRecord.iKeyword byte đầu tiên)

                    if (i < _arrRecord.Count - 1)
                    {
                        char c = char.ToUpper(this[i].Word[0]);
                        if (CurrentChar != c)
                        {
                            countHash++;
                            byte[] tempChar = Encoding.UTF8.GetBytes(c.ToString() + " ");
                            byte[] tempCount = CFunctions.GetBytes(i, HashRecord.iPosition);
                            fsHash.Write(tempChar, 0, HashRecord.iKeyword);
                            fsHash.Write(tempCount, 0, tempCount.Length);
                            CurrentChar = c;
                        }
                    }
                    
                    #endregion

                    startContent += tempContent.Length;
                }

                #region Cập nhật lại File Hash và Index
                // Cập nhật lại 2 byte đầu tiên của file Hash (số lượng record)                
                temp = CFunctions.GetBytes(countHash, 2);
                fsHash.Seek(0, SeekOrigin.Begin);
                fsHash.Write(temp, 0, temp.Length);
                
                // Cập nhật lại (_arrRecord.Count + 1) * IndexRecord.iKeyword byte                
                byte[] tempPos2 = CFunctions.GetBytes((int)fsIndex.Position, IndexRecord.iKeyword);
                Array.Copy(tempPos2, 0, arrPosOfWord, _arrRecord.Count * IndexRecord.iKeyword, tempPos2.Length);
                fsIndex.Seek(6, SeekOrigin.Begin);
                fsIndex.Write(arrPosOfWord, 0, arrPosOfWord.Length);
                #endregion

                fsContent.Close();
                fsHash.Close();
                fsIndex.Close();
            }
            catch (System.Exception e)
            {
                #region Xử lý lỗi
                if (fsContent != null)
                    fsContent.Close();
                if (fsHash != null)
                    fsHash.Close();
                if (fsIndex != null)
                    fsIndex.Close();
                throw;
                #endregion
            }
            
        }
    }
}
