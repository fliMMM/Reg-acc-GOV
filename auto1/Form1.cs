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

        void click_to(Point point, int delay)
        {
            AutoControl.MouseClick(point, EMouseKey.LEFT);
            Thread.Sleep(delay);
        }

        void write_to(string text)
        {
            Thread.Sleep(1000);
            SendKeys.SendWait(text);
        }

        void down_to()
        {
            Thread.Sleep(500);
            AutoControl.SendKeyFocus(KeyCode.DOWN);
        }

        void turn_on_async(IntPtr HWND)
        {
            var _threeDotPoint = AutoControl.GetGlobalPoint(HWND, 450, 55);
            var _displayAsyncPoint = AutoControl.GetGlobalPoint(HWND, 350, 70);
            var _selectAllPoint = AutoControl.GetGlobalPoint(HWND, 40, 430);
            var _startPoint = AutoControl.GetGlobalPoint(HWND, 50, 80);
            var _loginNowPoint = AutoControl.GetGlobalPoint(HWND, 180, 210);

            click_to(_threeDotPoint, 500);
            click_to(_displayAsyncPoint, 500);
            click_to(_selectAllPoint, 500);
            click_to(_startPoint, 500);
            click_to(_loginNowPoint, 500);
        }

        void play_record(IntPtr HWND, int timePerGame)
        {
            var _threeDotPoint = AutoControl.GetGlobalPoint(HWND, 450, 55);
            var displayRecordPoint = AutoControl.GetGlobalPoint(HWND, 300, 50);
            var playRecordPoint = AutoControl.GetGlobalPoint(HWND, 450, 180);
            var exitRecordPoint = AutoControl.GetGlobalPoint(HWND, 515, 85);
            var _stopPoint = AutoControl.GetGlobalPoint(HWND, 330, 20);

            click_to(_threeDotPoint, 1000);
            click_to(displayRecordPoint, 1000);
            click_to(playRecordPoint,1000);
            click_to(exitRecordPoint, 1000);

            Thread.Sleep(timePerGame);
            click_to(_stopPoint, 700);
        }

        void turn_off_async(IntPtr HWND)
        {
            var _stopPoint = AutoControl.GetGlobalPoint(HWND, 330, 20);
            var _exitPoint = AutoControl.GetGlobalPoint(HWND, 515, 40);
            click_to(_stopPoint, 500);
            click_to(_exitPoint, 500);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var hWnd = AutoControl.FindWindowHandle(null, "LDPlayer");

            //var openGamePoint = AutoControl.GetGlobalPoint(hWnd,225, 100);
            var loginPoint = AutoControl.GetGlobalPoint(hWnd, 180, 230);
            var registerPoint = AutoControl.GetGlobalPoint(hWnd, 180, 250);
            var usernamePoint = AutoControl.GetGlobalPoint(hWnd, 180, 130);
            var passwordPoint = AutoControl.GetGlobalPoint(hWnd, 180, 170);
            var emailPoint = AutoControl.GetGlobalPoint(hWnd, 180, 190);
            var backPoint = AutoControl.GetGlobalPoint(hWnd, 450, 160);

            click_to(loginPoint, 5000);
            click_to(registerPoint, 1000);

            //send username
            click_to(usernamePoint, 0);
            write_to("pro032132");

            //send password
            click_to(passwordPoint, 0);
            write_to("pro032132112");

            //send email
            click_to(emailPoint, 0);
            write_to("b4hbhweiu@gmail.com");

            for(int i = 0; i < 8; i++)
            {
                down_to();
            }


            write_to("{ENTER}");
            Thread.Sleep(1000);

            click_to(backPoint, 0);
            Thread.Sleep(3000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //read file
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\20010844\Desktop\data.txt");
            int inDexOfFile = 0;
            IntPtr[] HWND = new IntPtr[1];
            string[] screens = { "LDPlayer" };
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
                    if (inDexOfFile == lines.Length) continue;
                    var loginPoint = AutoControl.GetGlobalPoint(HWND[i], 180, 230);
                    var usernamePoint = AutoControl.GetGlobalPoint(HWND[i], 180, 130);
                    var passwordPoint = AutoControl.GetGlobalPoint(HWND[i], 180, 160);

                    click_to(loginPoint, 5000);

                    //SendMessage username
                    click_to(usernamePoint, 1000);
                    write_to(lines[inDexOfFile].Split('|')[0].ToString().Trim());


                    //send password
                    click_to(passwordPoint, 1000);
                    write_to(lines[inDexOfFile].Split('|')[1].ToString().Trim());

                    inDexOfFile++;
                }

                //turnOn async
                Thread.Sleep(1000);
                turn_on_async(HWND[0]);


                //Play record
                Thread.Sleep(1000);
                play_record(HWND[0], 10000);

                //turnoff async
                turn_off_async(HWND[0]);
            }
        }
    }
}
