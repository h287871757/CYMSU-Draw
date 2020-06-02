using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CYMSU
{
    /// <summary>
    /// DrawWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    public static class DispatcherHelper
    {
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(ExitFrames), frame);
            try { Dispatcher.PushFrame(frame); }
            catch (InvalidOperationException) { }
        }
        private static object ExitFrames(object frame)
        {
            ((DispatcherFrame)frame).Continue = false;
            return null;
        }
    }

    public partial class DrawWindow : Window
    {
        private SoundPlayer winPlayer = new SoundPlayer();
        Random randObj = new Random(DateTime.Now.Millisecond 
                                    * DateTime.Now.Second
                                    / DateTime.Now.Minute);
        private int iLuckyNum = -1;
        public DrawWindow()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
       
            name_tb.DataContext = "祝您中獎！！！";
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            name_tb.DataContext = "";
            tb_8.DataContext = "";
            tb_7.DataContext = "";
            tb_6.DataContext = "";
            tb_5.DataContext = "";
            tb_4.DataContext = "";
            tb_3.DataContext = "";
            tb_2.DataContext = "";
            tb_1.DataContext = "";
            //initialize


            iLuckyNum = randObj.Next(Global.iAmount);
            while (Global.stuList[iLuckyNum].bDrawed == true)
                iLuckyNum = randObj.Next(Global.iAmount);
            Global.stuList[iLuckyNum].bDrawed = true;
            tb_8.DataContext = Global.stuList[iLuckyNum].sNumber[7];
            var t = DateTime.Now.AddMilliseconds(1000);
            while (DateTime.Now < t)
                DispatcherHelper.DoEvents();
            tb_7.DataContext = Global.stuList[iLuckyNum].sNumber[6];
            t = DateTime.Now.AddMilliseconds(1000);
            while (DateTime.Now < t)
                DispatcherHelper.DoEvents();
            tb_6.DataContext = Global.stuList[iLuckyNum].sNumber[5];
            t = DateTime.Now.AddMilliseconds(1000);
            while (DateTime.Now < t)
                DispatcherHelper.DoEvents();
            tb_5.DataContext = Global.stuList[iLuckyNum].sNumber[4];
            t = DateTime.Now.AddMilliseconds(1000);
            while (DateTime.Now < t)
                DispatcherHelper.DoEvents();
            tb_4.DataContext = Global.stuList[iLuckyNum].sNumber[3];
            t = DateTime.Now.AddMilliseconds(1000);
            while (DateTime.Now < t)
                DispatcherHelper.DoEvents();
            tb_3.DataContext = Global.stuList[iLuckyNum].sNumber[2];
            tb_2.DataContext = Global.stuList[iLuckyNum].sNumber[1];
            tb_1.DataContext = Global.stuList[iLuckyNum].sNumber[0];

            name_tb.DataContext = "恭喜" + ' ' + Global.stuList[iLuckyNum].sName + " 同學 中獎！";
        }
    }
}
