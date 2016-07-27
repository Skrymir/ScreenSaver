using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ScreenSaver
{
    public partial class ScreenSaverForm : Form
    {
        private bool IsPreviewMode;

        public ScreenSaverForm(Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;
        }

        public ScreenSaverForm(IntPtr PreviewHandle)
        {
            InitializeComponent();

            SetParent(this.Handle, PreviewHandle);

            SetWindowLong(this.Handle, -16,
                new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            Rectangle ParentRect;
            GetClientRect(PreviewHandle, out ParentRect);
            this.Size = ParentRect.Size;

            this.Location = new Point(0, 0);

            IsPreviewMode = true;

        }

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;


        }

        #region Preview API's

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        #endregion

        #region User Input
        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }


        #endregion

        Point OriginalLocation = new Point(int.MaxValue, int.MaxValue);
        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            //see if originallocation has been set
            if (OriginalLocation.X == int.MaxValue &
                OriginalLocation.Y == int.MaxValue)
            {
                OriginalLocation = e.Location;
            }
            //see if the mouse has moved more than 20 pixels 
            //in any direction. If it has, close the application.
            if (Math.Abs(e.X - OriginalLocation.X) > 20 |
                Math.Abs(e.Y - OriginalLocation.Y) > 20)
            {
                Application.Exit();
            }
        }
    }
}
