/*
 * Modify Log
 * 2017/10/25 Loop music 
 * 2017/10/26 Check input format, prevent crash
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CYMSU
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        StreamReader stuInfoReader;
        SoundPlayer player = new SoundPlayer();
        public MainWindow()
        {
            InitializeComponent();
            //播放音樂
            player.Stream = MusicRsc.bgm;
            player.PlayLooping();

            this.WindowState = System.Windows.WindowState.Normal;
        }

        private void draw_Click(object sender, RoutedEventArgs e)
        {
            if (Global.iAmount == 0)
                MessageBox.Show("沒有數據");
            else
            {
                DrawWindow dw = new DrawWindow();
                dw.ShowDialog();
            }
        }


        private int iAtoI(string _sInfoColumnOne)
        {
            try
            {
                int iStudentID = Convert.ToInt32(_sInfoColumnOne);
                return iStudentID;
            }
            catch
            {
                return -1;
            }
        }

        private bool bCheckFormat(string[] _sInfo)
        {
            if (_sInfo.Length < 2)
                return false;
            int iStudentID = iAtoI(_sInfo[1]);
            if (iStudentID < 10000000 || iStudentID > 20000000)
                return false;
            else
                return true;
        }

        private void read_Click(object sender, RoutedEventArgs e)
        {
            string sFilePath = "";
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "文本文件 | *.txt"
            };
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                sFilePath = openFileDialog.FileName;
            }

            if (sFilePath != "")
            {
                int iCounter;
                stuInfoReader = new StreamReader(sFilePath, Encoding.Default);

                string[] sInfo = new string[2]; // Item1:Name Item2:Number
                for (iCounter = 0; stuInfoReader.Peek() != -1; iCounter++)
                {
                    string sTemp = stuInfoReader.ReadLine();
                    sInfo = sTemp.Split('\t');
                    if (!bCheckFormat(sInfo))
                    {
                        MessageBox.Show("格式错误\n" +
                            "格式应为：姓名+Tab+学号 每笔资料一行\n" +
                            "学号范围：10000000~20000000");
                        return;
                    };
                    Global.stuList[iCounter].sName = sInfo[0];
                    Global.stuList[iCounter].sNumber = sInfo[1];
                    Global.stuList[iCounter].bDrawed = false;
                    sInfo[0] = "\0";    //clear
                    sInfo[1] = "\0";    //clear
                }

                Global.iAmount = iCounter;
                MessageBox.Show("成功導入 " + iCounter + "筆數據！！！");
                stuInfoReader.Close();
            } // if file path not empty.
            
        }
        private void theme_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("敬請期待");

        }
    }
}
