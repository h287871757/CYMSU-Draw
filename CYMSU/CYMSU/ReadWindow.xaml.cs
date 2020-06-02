using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using System.IO;

namespace CYMSU
{
    /// <summary>
    /// ReadWindow.xaml 的交互逻辑
    /// </summary>


    public partial class ReadWindow : Window
    {

        StreamReader stuInfoReader;

        private string sFilePath;

        public ReadWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int iCounter ;
            sFilePath = address_Box.Text;
            MessageBox.Show(123+sFilePath);

            if (sFilePath == "")
                return;
            stuInfoReader = new StreamReader(sFilePath, Encoding.Default);

            string[] sInfo = new string[2]; // Item1:Name Item2:Number
            for (iCounter = 0; stuInfoReader.Peek() != -1; iCounter++)
            {
                string sTemp = stuInfoReader.ReadLine();
                sInfo = sTemp.Split('\t');
                Global.stuList[iCounter].sNumber = sInfo[0];
                Global.stuList[iCounter].sName = sInfo[1];
                Global.stuList[iCounter].bDrawed = false;
                sInfo[0] = "\0";    //clear
                sInfo[1] = "\0";    //clear
            }

            Global.iAmount = iCounter;
            MessageBox.Show("成功導入 "+ iCounter + "筆數據！！！");
            stuInfoReader.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string sFilename;
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "文本文件 | *.txt"
            };
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                sFilename = openFileDialog.FileName;
            }
        }
    }
}


