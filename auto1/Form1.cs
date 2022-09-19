using KAutoHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace auto1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        private void button1_Click(object sender, EventArgs e)
        {
            //Process.Start("C:\\LDPlayer\\LDPlayer9\\dnplayer.exe");
            //AutoControl.MouseClick(200, 300);

            var hWnd = AutoControl.FindWindowHandle(null, "LDPlayer");
            AutoControl.BringToFront(hWnd);

            //var openGamePoint = AutoControl.GetGlobalPoint(hWnd,225, 100);
            var loginPoint = AutoControl.GetGlobalPoint(hWnd, 180, 230);
            var registerPoint = AutoControl.GetGlobalPoint(hWnd, 180, 250);
            var usernamePoint = AutoControl.GetGlobalPoint(hWnd, 180, 130);
            var passwordPoint = AutoControl.GetGlobalPoint(hWnd, 180, 160);
            var emailPoint = AutoControl.GetGlobalPoint(hWnd, 180, 190);
            var registerAfterPoint = AutoControl.GetGlobalPoint(hWnd, 180, 270);
            var backPoint = AutoControl.GetGlobalPoint(hWnd, 450, 160);


            for(int i = 36; i <= 38; i++){
                //AutoControl.MouseClick(openGamePoint, EMouseKey.LEFT);
                AutoControl.MouseClick(loginPoint, EMouseKey.LEFT);
                Thread.Sleep(4000);
                AutoControl.MouseClick(registerPoint, EMouseKey.LEFT);
                Thread.Sleep(1000);

                //send username
                AutoControl.MouseClick(usernamePoint, EMouseKey.LEFT);
                Thread.Sleep(1000);
                SendKeys.SendWait("100tr1ngay18" + i.ToString());

                //send password
                AutoControl.MouseClick(passwordPoint, EMouseKey.LEFT);
                Thread.Sleep(2000);
                SendKeys.SendWait("Aa@100tr");

                //send email
                AutoControl.MouseClick(emailPoint, EMouseKey.LEFT);
                Thread.Sleep(1000);
                SendKeys.SendWait("kjsadas8dasuudasd34hyyf" + i.ToString() +  "@gmail.com");

                Thread.Sleep(500);
                AutoControl.SendKeyFocus(KeyCode.DOWN);
                Thread.Sleep(500);
                AutoControl.SendKeyFocus(KeyCode.DOWN);
                Thread.Sleep(500);
                AutoControl.SendKeyFocus(KeyCode.DOWN);
                Thread.Sleep(500);
                AutoControl.SendKeyFocus(KeyCode.DOWN);
                Thread.Sleep(500);
                AutoControl.SendKeyFocus(KeyCode.DOWN);
                Thread.Sleep(500);
                AutoControl.SendKeyFocus(KeyCode.DOWN);
                Thread.Sleep(500);
                AutoControl.SendKeyFocus(KeyCode.DOWN);
                Thread.Sleep(500);
                AutoControl.SendKeyFocus(KeyCode.DOWN);

                Thread.Sleep(1000);
                //AutoControl.MouseClick(registerAfterPoint, EMouseKey.LEFT);

                //dangki


                SendKeys.SendWait("{ENTER}");

                Thread.Sleep(1000);
                AutoControl.MouseClick(backPoint, EMouseKey.LEFT);
                Thread.Sleep(3000);
            }


        }

    
    }
}
