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
            //var child = AutoControl.FindHandle(hWnd, "RenderWindow", null);
            //AutoControl.BringToFront(hWnd);

            //var openGamePoint = AutoControl.GetGlobalPoint(hWnd,225, 100);
            var loginPoint = AutoControl.GetGlobalPoint(hWnd, 180, 230);
            var registerPoint = AutoControl.GetGlobalPoint(hWnd, 180, 250);
            var usernamePoint = AutoControl.GetGlobalPoint(hWnd, 180, 130);
            //var usernamePoint = AutoControl.GetGlobalPoint(child, 180, 90);
            var passwordPoint = AutoControl.GetGlobalPoint(hWnd, 180, 160);
            var emailPoint = AutoControl.GetGlobalPoint(hWnd, 180, 190);
            var registerAfterPoint = AutoControl.GetGlobalPoint(hWnd, 180, 270);
            var backPoint = AutoControl.GetGlobalPoint(hWnd, 450, 160);


  
            AutoControl.MouseClick(loginPoint, EMouseKey.LEFT);
            Thread.Sleep(7000);
            AutoControl.MouseClick(registerPoint, EMouseKey.LEFT);
            Thread.Sleep(1000);

            //send username
            AutoControl.MouseClick(usernamePoint, EMouseKey.LEFT);
            Thread.Sleep(1000);
            SendKeys.SendWait("100tr1ngay18990");

            //send password
            AutoControl.MouseClick(passwordPoint, EMouseKey.LEFT);
            Thread.Sleep(2000);
            SendKeys.SendWait("Aa@100tr");

            //send email
            AutoControl.MouseClick(emailPoint, EMouseKey.LEFT);
            Thread.Sleep(1000);
            SendKeys.SendWait("kjsadas8d0asuudasd34hyyfh@gmail.com");

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


            SendKeys.SendWait("{ENTER}");

            Thread.Sleep(1000);
            AutoControl.MouseClick(backPoint, EMouseKey.LEFT);
            Thread.Sleep(3000);
            //}


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //read file
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\20010844\Desktop\data.txt");
            int inDexOfFile = 0;
            IntPtr[] HWND = new IntPtr[2];
            string[] screens = { "LDPlayer", "LDPlayer-1" };
            IntPtr _hWnd = IntPtr.Zero;
            for (int i = 0; i < screens.Length; i++)
            {
                _hWnd = AutoControl.FindWindowHandle(null, screens[i]);
                HWND[i] = _hWnd;
            }
            for(int j = 0; j <1; j++)
            {
                for (int i = 0; i < HWND.Length; i++)
                {
                    //var hWnd = AutoControl.FindWindowHandle(null, "LDPlayer");
                    var loginPoint = AutoControl.GetGlobalPoint(HWND[i], 180, 230);
                    var usernamePoint = AutoControl.GetGlobalPoint(HWND[i], 180, 130);
                    var passwordPoint = AutoControl.GetGlobalPoint(HWND[i], 180, 160);
                    var loginNowPoint = AutoControl.GetGlobalPoint(HWND[i], 180, 210);
                    var threeDotPoint = AutoControl.GetGlobalPoint(HWND[i], 450, 55);
                    var displayRecordPoint = AutoControl.GetGlobalPoint(HWND[i], 300, 50);
                    var playRecordPoint = AutoControl.GetGlobalPoint(HWND[i], 450, 180);
                    var exitRecordPoint = AutoControl.GetGlobalPoint(HWND[i], 515, 85);
                    var championPickPoint = AutoControl.GetGlobalPoint(HWND[i], 450, 200);


                    AutoControl.MouseClick(loginPoint, EMouseKey.LEFT);
                    Thread.Sleep(5000);

                    AutoControl.MouseClick(usernamePoint, EMouseKey.LEFT);
                    Thread.Sleep(500);
                    SendKeys.SendWait(lines[inDexOfFile].Split('|')[0]);


                    //send password
                    AutoControl.MouseClick(passwordPoint, EMouseKey.LEFT);
                    Thread.Sleep(500);
                    SendKeys.SendWait(lines[inDexOfFile].Split('|')[1]);


                    //AutoControl.MouseClick(loginNowPoint, EMouseKey.LEFT);
                    //Thread.Sleep(500);



                    //Play record
                    //AutoControl.MouseClick(threeDotPoint, EMouseKey.LEFT);
                    //Thread.Sleep(2000);
                    //AutoControl.MouseClick(displayRecordPoint, EMouseKey.LEFT);
                    //Thread.Sleep(2000);

                    //AutoControl.MouseClick(playRecordPoint, EMouseKey.LEFT);
                    //Thread.Sleep(2000);

                    //AutoControl.MouseClick(exitRecordPoint, EMouseKey.LEFT);
                    //Thread.Sleep(2000);
                    inDexOfFile++;
                }

                //turnOn async
                var _threeDotPoint = AutoControl.GetGlobalPoint(HWND[0], 450, 55);
                var _displayAsyncPoint = AutoControl.GetGlobalPoint(HWND[0], 350, 70);
                var _selectAllPoint = AutoControl.GetGlobalPoint(HWND[0], 40, 430);
                var _startPoint = AutoControl.GetGlobalPoint(HWND[0], 50, 80);
                var _loginNowPoint = AutoControl.GetGlobalPoint(HWND[0], 180, 210);
                
                AutoControl.MouseClick(_threeDotPoint, EMouseKey.LEFT);
                Thread.Sleep(1000);
                AutoControl.MouseClick(_displayAsyncPoint, EMouseKey.LEFT);
                Thread.Sleep(1000);
                AutoControl.MouseClick(_selectAllPoint, EMouseKey.LEFT);
                Thread.Sleep(1000);
                AutoControl.MouseClick(_startPoint, EMouseKey.LEFT);

                AutoControl.MouseClick(_loginNowPoint, EMouseKey.LEFT);
                Thread.Sleep(500);
            }
        }
    }
}
