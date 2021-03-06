using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace ThongKeTanSuat
{
    public partial class Form1 : Form
    {
        static String strA = "AÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶ";
        static String strE = "EÉÈẺẼẸÊẾỀỂỄỆ";
        static String strI = "IÍÌỈĨỊ";
        static String strO = "OÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢ";
        static String strU = "UÚÙỦŨỤƯỨỪỬỮỰ";
        static String strY = "YÝỲỶỸỴ";
        static String strD = "DĐ";
        static String[] arrStrNguyenAm = new String[] 
            { strA, strE, strI, strO, strU, strY, strD };

        public Form1()
        {
            InitializeComponent();
        }
        /*
         * Chuyen van ban tieng Viet thanh van ban khong dau
         * str : van ban can chuyen
         */ 
        public String BoDau(String str)
        {
            StringBuilder sb = new StringBuilder();

            Boolean flag;
            for (int i = 0; i < str.Length; ++i)
            {
                if ((str[i] >= 'A' && str[i] <= 'Z') || str[i] == ' ')
                    sb.Append(str[i]);
                else
                {
                    flag = false;
                    // Kiem tra xem s[i] co thuoc tap nguyen am co dau ko
                    foreach (String s1 in arrStrNguyenAm)
                    {
                        if (s1.IndexOf(str[i]) != -1)
                        {
                            sb.Append(s1[0]);
                            flag = true;
                            break;
                        }
                    }
                    // Cac ky tu con lai --> ' '
                    if (flag == false)
                    {
                        sb.Append(' ');
                    }
                }
            }
            return sb.ToString();
        }
        /*
         * Bo cac dau thanh cua van ban tieng Viet
         * str : van ban can chuyen
         */
        public String BoDauThanh(String str)
        {
            StringBuilder sb = new StringBuilder();

            Boolean flag;
            for (int i = 0; i < str.Length; ++i)
            {
                if ((str[i] >= 'A' && str[i] <= 'Z') || str[i] == ' ')
                    sb.Append(str[i]);
                else
                {
                    flag = false;
                    // Kiem tra xem s[i] co thuoc tap nguyen am co dau ko
                    for (int j = 0; j < arrStrNguyenAm.Length; ++j)
                    {
                        String s1 = arrStrNguyenAm[j];                        
                        int index = s1.IndexOf(str[i]);

                        if (index != -1)
                        {
                            if (j < arrStrNguyenAm.Length - 1)
                                sb.Append(s1[(index / 6) * 6]);
                            else // chu Đ
                                sb.Append(str[i]);
                            
                            flag = true;
                            break;
                        }
                    }
                    // Cac ky tu con lai --> ' '
                    if (flag == false)
                    {
                        sb.Append(' ');
                    }
                }
            }
            return sb.ToString();
        }
        /*
         * Thong ke so lan xuat hien cua tung bo 1 (2, 3) ky tu
         * Bo[i] : luu so lan xuat hien cua nhung bo i ky tu
         * TongSoLanXuatHien : tong so lan xuat hien cua bo i ky tu
         * str : van ban dang xet
         */
        public void ThongKeBoKyTu(String str, out List<SoLanXuatHienBoKyTu>[] Bo, out int[] TongSoLanXuatHien)
        {
            Bo = new List<SoLanXuatHienBoKyTu>[3];
            Bo[0] = new List<SoLanXuatHienBoKyTu>();
            Bo[1] = new List<SoLanXuatHienBoKyTu>();
            Bo[2] = new List<SoLanXuatHienBoKyTu>();

            int[] SoLanXuatHien = new int[26];
            int[,] SoLanXuatHien2 = new int[26, 26];
            int[, ,] SoLanXuatHien3 = new int[26, 26, 26];
            int[] count = new int[3] { 0, 0, 0 };

            String s = str + "  "; // Them 2 khoang trang vao cuoi chuoi de xet truong hop 3 ky tu nam o cuoi chuoi
            for (int i = 0; i < s.Length - 2; ++i)
            {
                // So lan xuat hien cua 1 ky tu
                if (s[i] == ' ')
                    continue;

                int t1 = s[i] - 'A';
                SoLanXuatHien[t1]++;
                count[0]++;

                // So lan xuat hien cua 2 ky tu
                if (s[i + 1] == ' ')
                    continue;

                int t2 = s[i + 1] - 'A';
                SoLanXuatHien2[t1, t2]++;
                count[1]++;

                // So lan xuat hien cua 3 ky tu
                if (s[i + 2] == ' ')
                    continue;

                int t3 = s[i + 2] - 'A';
                SoLanXuatHien3[t1, t2, t3]++;
                count[2]++;
            }            
            
            for (int i = 0; i < 26; ++i)
            {
                Bo[0].Add(new SoLanXuatHienBoKyTu(new int[] { i + 'A' }, SoLanXuatHien[i]));

                for (int j = 0; j < 26; ++j)
                {
                    Bo[1].Add(new SoLanXuatHienBoKyTu(new int[] { i + 'A', j + 'A' }, SoLanXuatHien2[i, j]));
                    
                    for (int k = 0; k < 26; ++k)
                    {
                        Bo[2].Add(new SoLanXuatHienBoKyTu(new int[] { i + 'A', j + 'A', k + 'A' }, SoLanXuatHien3[i, j, k]));
                    }
                }
            }

            Bo[0].Sort();
            Bo[1].Sort();
            Bo[2].Sort();

            TongSoLanXuatHien = count;
        }
        /*
         * Thong ke so lan xuat hien cua tung bo 1 (2, 3) ky tu doi voi van ban tieng Viet (da bo dau thanh)
         * Bo[i] : luu so lan xuat hien cua nhung bo i ky tu
         * TongSoLanXuatHien : tong so lan xuat hien cua bo i ky tu
         * str : van ban dang xet
         */
        public void ThongKeBoKyTuTiengViet(String str, out List<SoLanXuatHienBoKyTu>[] Bo, out int[] TongSoLanXuatHien)
        {
            string strCoDau = "ĂÂĐÊÔƠƯ"; 
            Bo = new List<SoLanXuatHienBoKyTu>[3];
            Bo[0] = new List<SoLanXuatHienBoKyTu>();
            Bo[1] = new List<SoLanXuatHienBoKyTu>();
            Bo[2] = new List<SoLanXuatHienBoKyTu>();

            int[] SoLanXuatHien = new int[33];
            int[,] SoLanXuatHien2 = new int[33, 33];
            int[, ,] SoLanXuatHien3 = new int[33, 33, 33];
            int[] count = new int[3] { 0, 0, 0 };
            
            String s = str + "  "; // Them 2 khoang trang vao cuoi chuoi de xet truong hop 3 ky tu nam o cuoi chuoi
            for (int i = 0; i < s.Length - 2; ++i)
            {
                // So lan xuat hien cua 1 ky tu
                if (s[i] == ' ')
                    continue;

                int t1 = s[i] - 'A';
                if (t1 >= 26) // s[i] nam trong "ĂÂĐÊÔƠƯ"
                    t1 = 26 + strCoDau.IndexOf(s[i]);
                SoLanXuatHien[t1]++;
                count[0]++;

                // So lan xuat hien cua 2 ky tu
                if (s[i + 1] == ' ')
                    continue;

                int t2 = s[i + 1] - 'A';
                if (t2 >= 26) // s[i + 1] nam trong "ĂÂĐÊÔƠƯ"
                    t2 = 26 + strCoDau.IndexOf(s[i + 1]);
                SoLanXuatHien2[t1, t2]++;
                count[1]++;

                // So lan xuat hien cua 3 ky tu
                if (s[i + 2] == ' ')
                    continue;

                int t3 = s[i + 2] - 'A';
                if (t3 >= 26) // s[i + 2] nam trong "ĂÂĐÊÔƠƯ"
                    t3 = 26 + strCoDau.IndexOf(s[i + 2]);
                SoLanXuatHien3[t1, t2, t3]++;
                count[2]++;
            }

            string BoKyTuCoDau = "ABCDEFGHIJKLMNOPQRSTUVWXYZĂÂĐÊÔƠƯ";
            for (int i = 0; i < 33; ++i)
            {
                Bo[0].Add(new SoLanXuatHienBoKyTu(new int[] { BoKyTuCoDau[i] }, SoLanXuatHien[i]));

                for (int j = 0; j < 33; ++j)
                {
                    Bo[1].Add(new SoLanXuatHienBoKyTu(new int[] { BoKyTuCoDau[i], BoKyTuCoDau[j] }, SoLanXuatHien2[i, j]));

                    for (int k = 0; k < 33; ++k)
                    {
                        Bo[2].Add(new SoLanXuatHienBoKyTu(new int[] { BoKyTuCoDau[i], BoKyTuCoDau[j], BoKyTuCoDau[k] }, SoLanXuatHien3[i, j, k]));
                    }
                }
            }

            Bo[0].Sort();
            Bo[1].Sort();
            Bo[2].Sort();

            TongSoLanXuatHien = count;
        }
        /*
         * Xuat so lan xuat hien va tan xuat cua bo 1, 2, 3 ky tu ra dang chuoi
         * flag = true : van ban tieng Viet
         * flag = false: van ban bo dau tieng Viet
         * Bo : thong tin cua bo 1, 2, 3 ky tu
         * TongSoLanXuatHien : tong so lan xuat hien bo 1, 2, 3 ky tu trong van ban
         */ 
        private void XuatChuoi(Boolean flag, List<SoLanXuatHienBoKyTu>[] Bo, int[] TongSoLanXuatHien, out String[] Chuoi)
        {
            StringBuilder[] temp = new StringBuilder[3];
            temp[0] = new StringBuilder();
            temp[1] = new StringBuilder();
            temp[2] = new StringBuilder();            

            for (int i = 0; i < 100; ++i)
            {
                SoLanXuatHienBoKyTu[] slxh = new SoLanXuatHienBoKyTu[3];

                for (int j = 1; j < 3; ++j)
                    slxh[j] = Bo[j][Bo[j].Count - 1 - i];

                String[] str = new String[3];
                str[1] = "";
                str[2] = "";

                // Lay bo ky tu tuong ung
                for (int j = 0; j < 2; ++j)
                {
                    str[1] += ((char)slxh[1][j]).ToString();
                    str[2] += ((char)slxh[2][j]).ToString();
                }
                str[2] += ((char)slxh[2][2]).ToString();

                str[1] += " " + slxh[1].SoLanXuatHien + " " + (slxh[1].SoLanXuatHien / (double)TongSoLanXuatHien[1]).ToString("n5");
                str[2] += " " + slxh[2].SoLanXuatHien + " " + (slxh[2].SoLanXuatHien / (double)TongSoLanXuatHien[2]).ToString("n5");

                temp[1].Append(str[1] + "\r\n");
                temp[2].Append(str[2] + "\r\n");
            }
            int max = (flag == true ? 33 : 26);
            for (int i = 0; i < max; ++i)
            {
                SoLanXuatHienBoKyTu slxh = Bo[0][Bo[0].Count - 1 - i];
                String str = "";
                str += ((char)slxh[0]).ToString();

                str += " " + slxh.SoLanXuatHien + " " + (slxh.SoLanXuatHien / (double)TongSoLanXuatHien[0]).ToString("n5");

                temp[0].Append(str + "\r\n");
            }

            Chuoi = new string[3];
            Chuoi[0] = temp[0].ToString();
            Chuoi[1] = temp[1].ToString();
            Chuoi[2] = temp[2].ToString();
        }

        private void butDocFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Unicode);
            String s = sr.ReadToEnd();
            fs.Close();
            sr.Close();

            CultureInfo ci = new CultureInfo("vi");
            String strChuHoa = s.ToUpper();
            String strBoDauTV = BoDau(strChuHoa);
            String strBoDauThanh = BoDauThanh(strChuHoa);

            txtVBGoc.Text = s;
            txtVBBoDau.Text = strBoDauTV;
            txtVBBoDauThanh.Text = strBoDauThanh;

            List<SoLanXuatHienBoKyTu>[] Bo1, Bo2;
            int[] TongSoLanXuatHien1, TongSoLanXuatHien2;
            ThongKeBoKyTuTiengViet(strBoDauTV, out Bo1, out TongSoLanXuatHien1);
            ThongKeBoKyTuTiengViet(strBoDauThanh, out Bo2, out TongSoLanXuatHien2);
            // Xuat chuoi

            string[] ChuoiBoDau;
            string[] ChuoiBoDauThanh;
            XuatChuoi(false, Bo1, TongSoLanXuatHien1, out ChuoiBoDau);
            XuatChuoi(true, Bo2, TongSoLanXuatHien2, out ChuoiBoDauThanh);
            txtBo1KyTuBoTV.Text = ChuoiBoDau[0];
            txtBo2KyTuBoTV.Text = ChuoiBoDau[1];
            txtBo3KyTuBoTV.Text = ChuoiBoDau[2];
            txtBo1KyTuBoDauThanh.Text = ChuoiBoDauThanh[0];
            txtBo2KyTuBoDauThanh.Text = ChuoiBoDauThanh[1];
            txtBo3KyTuBoDauThanh.Text = ChuoiBoDauThanh[2];
        }
    }
    public class SoLanXuatHienBoKyTu : IComparable
    {
        int m_SoLanXuatHien = 0;
        List<int> m_BoKyTu;

        public int SoLanXuatHien
        {
            get { return m_SoLanXuatHien; }
            set { m_SoLanXuatHien = value; }
        }     
        public int this[int index]
        {
            get{return m_BoKyTu[index];}
            set{m_BoKyTu[index] = value;}
        }
        public SoLanXuatHienBoKyTu(int[] arr, int solanxuathien)
        {
            SoLanXuatHien = solanxuathien;
            m_BoKyTu = new List<int>(arr);
        }
        #region IComparable Members

        public int CompareTo(object obj)
        {
            return SoLanXuatHien - ((SoLanXuatHienBoKyTu)obj).SoLanXuatHien;
        }

        #endregion
    }
}