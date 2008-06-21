// YaoDurant.Drawing.ChooseColor.cs - Wrapper for calling Win32
// color picker common dialog box
//
// Code from _.NET Compact Framework Programming with C#_
// and _.NET Compact Framework Programming with Visual Basic .NET_
// Authored by 2004 Paul Yao and David Durant.
//

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SimplePainBrush
{
    /// <summary>
    /// Summary description for YaoDurant
    /// </summary>
    public class ChooseColorDlg
    {
        public ChooseColorDlg()
        {
        }

        // Private data -- the Win32 CHOOSECOLOR structure
        private CHOOSECOLOR m_cc;

        // Class initialization function
        public bool Init(Control ctrlParent)
        {
            // Allocate the array for initial colors.
            int cbColorData = 16 * 4;
            IntPtr ipColors = LocalAlloc(LMEM_FIXED, cbColorData);
            if (ipColors == IntPtr.Zero)
                return false;

            m_cc = new CHOOSECOLOR();
            m_cc.lStructSize = Marshal.SizeOf(m_cc);
            m_cc.hwndOwner = GetHwndFromControl(ctrlParent);
            m_cc.hInstance = IntPtr.Zero;
            m_cc.rgbResult = 0;
            m_cc.lpCustColors = ipColors;
            m_cc.Flags = CC_RGBINIT;
            m_cc.lCustData = 0;
            m_cc.lpfnHook = IntPtr.Zero;
            m_cc.lpTemplateName = IntPtr.Zero;

            return true;
        }

        public bool ShowDialog(ref Color clrValue)
        {
            int iRet = 0;
            byte Red = clrValue.R;
            byte Green = clrValue.G;
            byte Blue = clrValue.B;

            m_cc.rgbResult = (Blue << 16) + (Green << 8) + Red;

            iRet = ChooseColor(ref m_cc);
            if (iRet != 0)
            {
                Red = (byte)(m_cc.rgbResult & 0xff);
                Green = (byte)((m_cc.rgbResult & 0xff00) >> 8);
                Blue = (byte)((m_cc.rgbResult & 0xff0000) >> 16);
                clrValue = Color.FromArgb(Red, Green, Blue);
                return true;
            }
            else
                return false;
        }

        //
        // Memory allocation functions and values
        //
        public const int LMEM_FIXED = 0x0000;
        [DllImport("coredll.dll")]
        public static extern
        IntPtr LocalAlloc(int uFlags, int uBytes);
        [DllImport("coredll.dll")]
        public static extern IntPtr LocalFree(IntPtr hMem);

        public static int INVALID_HANDLE_VALUE = -1;

        //
        // Color dialog function & values.
        //
        [DllImport("commdlg.dll")]
        public static extern int ChooseColor(ref CHOOSECOLOR lpcc);
        public struct CHOOSECOLOR
        {
            public int lStructSize;
            public IntPtr hwndOwner;
            public IntPtr hInstance;
            public int rgbResult;
            public IntPtr lpCustColors;
            public int Flags;
            public int lCustData;
            public IntPtr lpfnHook;
            public IntPtr lpTemplateName;
        };
        public const int CC_RGBINIT = 0x00000001;
        public const int CC_FULLOPEN = 0x00000002;
        public const int CC_PREVENTFULLOPEN = 0x00000004;
        public const int CC_ENABLEHOOK = 0x00000010;
        public const int CC_ENABLETEMPLATE = 0x00000020;
        public const int CC_ENABLETEMPLATEHANDLE = 0x00000040;
        public const int CC_SOLIDCOLOR = 0x00000080;
        public const int CC_ANYCOLOR = 0x00000100;

        //
        // Focus functions
        //
        [DllImport("coredll.dll")]
        public static extern IntPtr GetFocus();
        [DllImport("coredll.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        public IntPtr GetHwndFromControl(Control ctrl)
        {
            IntPtr hwndControl;

            // Check whether the control has focus.
            if (ctrl.Focused)
            {
                hwndControl = GetFocus();
            }
            else
            {
                IntPtr ipFocus = GetFocus();
                ctrl.Focus();
                hwndControl = GetFocus();
                SetFocus(ipFocus);
            }

            return hwndControl;
        }

    } // class
} // namespace

