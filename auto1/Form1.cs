using KAutoHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            Thread.Sleep(300);
            AutoControl.SendKeyFocus(KeyCode.DOWN);
        }

        void play_record(IntPtr HWND, int timePerGame)
        {
            AutoControl.BringToFront(HWND);
            var _threeDotPoint = AutoControl.GetGlobalPoint(HWND, 458, 113);
            var displayRecordPoint = AutoControl.GetGlobalPoint(HWND, 335, 180);
            var playRecordPoint = AutoControl.GetGlobalPoint(HWND, 560, 175);
            var exitRecordPoint = AutoControl.GetGlobalPoint(HWND, 625, 25);
            var _stopPoint = AutoControl.GetGlobalPoint(HWND, 200, 15);

            click_to(_threeDotPoint, 800);
            click_to(displayRecordPoint, 800);
            click_to(playRecordPoint, 800);

            //Thread.Sleep(timePerGame);
            click_to(_stopPoint, 800);
            click_to(exitRecordPoint, 800);
        }

        void toggle_async(IntPtr HWND)
        {
            var togglePoint = AutoControl.GetGlobalPoint(HWND, 257, 15);
            //var _exitPoint = AutoControl.GetGlobalPoint(HWND, 515, 40);
            click_to(togglePoint, 500);
            //click_to(_exitPoint, 500);
        }

        void reg_acc(string[] lines)
        {
            if (lines.Length == 0)
            {
                MessageBox.Show("File khong co j ca");
                return;
            }

            var hWnd = AutoControl.FindWindowHandle(null, "play1");
            AutoControl.BringToFront(hWnd);

            //var openGamePoint = AutoControl.GetGlobalPoint(hWnd,225, 100);
            var loginPoint = AutoControl.GetGlobalPoint(hWnd, 160, 237);
            var registerPoint = AutoControl.GetGlobalPoint(hWnd, 216, 208);
            var usernamePoint = AutoControl.GetGlobalPoint(hWnd, 153, 114);
            var passwordPoint = AutoControl.GetGlobalPoint(hWnd, 151, 139);
            var emailPoint = AutoControl.GetGlobalPoint(hWnd, 147, 163);
            var backPoint = AutoControl.GetGlobalPoint(hWnd, 455, 210);
            var registerNowPoint = AutoControl.GetGlobalPoint(hWnd, 222, 270);

            for (int i = 0; i < lines.Length; i++)
            {
                click_to(loginPoint, 4000);
                click_to(registerPoint, 1000);

                //send username
                click_to(usernamePoint, 500);
                write_to(lines[i].Split('|')[0].ToString().Trim());
                Thread.Sleep(500);

                //send password
                click_to(passwordPoint, 0);
                write_to(lines[i].Split('|')[1].ToString().Trim());
                Thread.Sleep(500);

                //send email
                click_to(emailPoint, 0);
                write_to(lines[i].Split('|')[2].ToString().Trim());
                Thread.Sleep(500);

                
                down_to();
                down_to();
                down_to();
                down_to();
                down_to();


                Thread.Sleep(500);
                click_to(registerNowPoint, 1000);

                click_to(backPoint, 0);
                Thread.Sleep(2000);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines;
            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\work\genAcc";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            lines = File.ReadAllLines(theDialog.FileName);
                            reg_acc(lines);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }

        void pick_ad(IntPtr[] HWND)
        {
            var subBitmap = ImageScanOpenCV.GetImage("ad.PNG");
            int countX = 0;
            int countY = 0;

            for (int i = 0; i < HWND.Length; i++)
            {
                
                var screen = (Bitmap)CaptureHelper.CaptureWindow(HWND[i]);

                screen = CaptureHelper.CropImage(screen, new System.Drawing.Rectangle(24, 53, 135, 197));
                screen.Save("linhtinh.PNG");
                var resPoint1 = ImageScanOpenCV.FindOutPoint(screen, subBitmap);
                Point point = new Point();
                if (resPoint1 != null)
                {
                    point.X = resPoint1.Value.X + countX + 30 ;
                    point.Y = resPoint1.Value.Y  + countY + 60;
                    click_to(point, 400);

                }
                countX += 490;
                if (i % 4 == 3) 
                {
                    countX = 0;
                }

                Thread.Sleep(500);
            }
        }

        void play_game(string[] lines)
        {
            int inDexOfFile = 0;
            
            int number_of_screen = (int)numericUpDown1.Value;
            IntPtr[] HWND = new IntPtr[number_of_screen];
            if (number_of_screen == 0)
            {
                MessageBox.Show("Chua nhap so luong man hinh!!");
                return;
            }

            string[] screens = new String[number_of_screen];
            for (int k = 0; k < number_of_screen; k++)
            {
                screens[k] = "play" + (k + 1).ToString();
            }

            IntPtr _hWnd = IntPtr.Zero;
            for (int i = 0; i < screens.Length; i++)
            {
                _hWnd = AutoControl.FindWindowHandle(null, screens[i]);
                HWND[i] = _hWnd;
            }

            //turnOn async
            toggle_async(HWND[0]);


            var loginPoint = AutoControl.GetGlobalPoint(HWND[0], 160, 237);
            //click_to(loginPoint, 6000);

            //turnoff async
            toggle_async(HWND[0]);


            for (int j = 0; j < lines.Length / number_of_screen; j++)
            {

                for (int i = 0; i < screens.Length; i++)
                {
                    if (inDexOfFile == lines.Length) continue;
                    AutoControl.BringToFront(HWND[i]);
                    var usernamePoint = AutoControl.GetGlobalPoint(HWND[i], 163, 114);
                    var passwordPoint = AutoControl.GetGlobalPoint(HWND[i], 154, 140);

                    //click_to(loginPoint, 5000);

                    //SendMessage username
                    click_to(usernamePoint, 500);
                    write_to(lines[inDexOfFile].Split('|')[0].ToString().Trim());
                    Thread.Sleep(1000);


                    //send password
                    click_to(passwordPoint, 500);
                    write_to(lines[inDexOfFile].Split('|')[1].ToString().Trim());
                    Thread.Sleep(1000);

                    inDexOfFile++;
                }

                //turnOn async
                Thread.Sleep(1000);
                toggle_async(HWND[0]);

                Thread.Sleep(800);
                var _loginNowPoint = AutoControl.GetGlobalPoint(HWND[0], 220, 173);
                click_to(_loginNowPoint, 800);

                //turnoff async
                toggle_async(HWND[0]);

                Thread.Sleep(13000);
                pick_ad(HWND);

                //turnOn async
                Thread.Sleep(1000);
                toggle_async(HWND[0]);

                //Play record
                Thread.Sleep(1000);
                play_record(HWND[0], 900000);

                //turnoff async
                toggle_async(HWND[0]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines;
            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\work\genAcc";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            lines = File.ReadAllLines(theDialog.FileName);
                            play_game(lines);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
