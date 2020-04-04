using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoVoLamMobile
{
    /// <summary>
    /// chiều dài và chiều rộng của giả lập là: 800 x 500
    /// </summary>
    public partial class MainWindow : Window
    {
        Bitmap RUNG_CAY_TIEN;
        Bitmap CHE_TAO;
        Bitmap BUTTON_USE;
        public MainWindow()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            RUNG_CAY_TIEN = (Bitmap)Bitmap.FromFile("Data//rungcaytien.png");
            CHE_TAO = (Bitmap)Bitmap.FromFile("Data//chetao.png");
            BUTTON_USE = (Bitmap)Bitmap.FromFile("Data//button_use.png");
        }

        bool isStop = false;
        

        #region end programing
        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;
                if (isStop)
                    break;
            }
        }

        // stop
        private void Button_Click_Stop(object sender, RoutedEventArgs e)
        {
            isStop = true;
        }

        #endregion
      
        #region cuonghoa

        // cường hoá vũ khí
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                AutoCuongHoa(52, 17.6);
            });
            t.Start();
        }

        // cường hoá dây chuyền
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                AutoCuongHoa(51.7, 30.4);
            });
            t.Start();
        }

        // cường hoá nhẫn
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                AutoCuongHoa(52.2, 43.2);
            });
            t.Start();
        }

        // cường hoá ngọc bội
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                AutoCuongHoa(52, 55.4);
            });
            t.Start();
        }

        // cường hoá phù
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                AutoCuongHoa(52, 68);
            });
            t.Start();
        }

        // cường hoá nón
        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                AutoCuongHoa(44.8, 17.4);
            });
            t.Start();
        }

        // cường hoá hộ uyển
        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                AutoCuongHoa(44.8, 30.1);
            });
            t.Start();
        }

        // cường hoá áo
        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                AutoCuongHoa(44.8, 43.75);
            });
            t.Start();
        }

        // cường hoá đai
        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                AutoCuongHoa(44.8, 56);
            });
            t.Start();
        }

        // cường hoá giày
        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                AutoCuongHoa(44.8, 69);
            });
            t.Start();
        }

        void AutoCuongHoa(double x, double y)
        {
            // lấy ra danh sách devices id để dùng
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();

            // chạy từng device để điều khiển theo kịch bản bên trong
            foreach (var deviceID in devices)
            {
                if (deviceID != "")
                {
                    // tạo ra một luồng xử lý riêng biệt để xử lý cho device này
                    Task t = new Task(() => {
                        // click vào hành trang
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 83, 4.9);
                        Delay(1);
                        // click vào chọn đồ muốn cường hoá
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, x, y);
                        Delay(1);
                        // click vào chọn cường hoá
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 74.3, 69);
                        Delay(1);
                        // click vào để cường hoá
                        while (true)
                        {
                            // nếu nhấn button stop -> dừng chương trình
                            if (isStop)
                            {
                                // click vào nút (X) để nó ra lại màn hình chính
                                KAutoHelper.ADBHelper.TapByPercent(deviceID, 96.4, 5.2);
                                // click vào nút (X) để nó ra lại màn hình chính
                                KAutoHelper.ADBHelper.TapByPercent(deviceID, 95.8, 4.6);
                                // dừng chương trình luôn
                                return;
                            }
                            // click vào để cường hoá
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 81.7, 85.3);
                            Delay(1);
                        }
                    });
                    t.Start();
                }
            }
        }
        #endregion

        #region rungcaytien
        private void Button_RungCayTien(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;

                // lấy ra danh sách devices id để dùng
                List<string> devices = new List<string>();
                devices = KAutoHelper.ADBHelper.GetDevices();

                // chạy từng device để điều khiển theo kịch bản bên trong
                foreach (var deviceID in devices)
                {
                    if (deviceID != "")
                    {
                        // tạo ra một luồng xử lý riêng biệt để xử lý cho device này
                        Task t1 = new Task(() => {

                            // click vào cái lợi tức ở trang bắt đầu
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 70.6, 6.5);
                            Delay(1);

                            // chọn menu là rung cây tiền
                            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                            var rungCayTienPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, RUNG_CAY_TIEN);

                            if (rungCayTienPoint != null)
                            {
                                KAutoHelper.ADBHelper.Tap(deviceID, rungCayTienPoint.Value.X, rungCayTienPoint.Value.Y);
                            }
                            // click tìm chữ rung cây tiền trên menu bằng % (cố định)
                            //KAutoHelper.ADBHelper.TapByPercent(deviceID, 17, 71.7);
                            
                            Delay(1);

                            // click lần đầu thì nó hiển thị cái muốn dùng 200 rung 10 lần khong?
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 46.7, 83.7);
                            Delay(1);
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 56.5, 70.6);
                            Delay(1);
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 60.6, 63);
                            Delay(1);
                            // end 
                            // các lần sau thì không hỏi nữa

                            while (true)
                            {
                                if (isStop)
                                {
                                    // trở về màn hình chính
                                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 96.7, 6);
                                    return;
                                }
                                    

                                // click vao rung
                                KAutoHelper.ADBHelper.TapByPercent(deviceID, 46.7, 83.7);
                            }
                        });
                        t1.Start();
                    }
                }
            });
            t.Start();
        }

        #endregion

        #region click button che tao
        private void Button_AutoCheTao(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;

                // lấy ra danh sách devices id để dùng
                List<string> devices = new List<string>();
                devices = KAutoHelper.ADBHelper.GetDevices();

                // chạy từng device để điều khiển theo kịch bản bên trong
                foreach (var deviceID in devices)
                {
                    if (deviceID != "")
                    {
                        // tạo ra một luồng xử lý riêng biệt để xử lý cho device này
                        Task t1 = new Task(() => {
                            while(true)
                            {
                                if (isStop)
                                    return;

                                // chọn menu là rung cây tiền
                                var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                                var cheTaoPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, CHE_TAO);

                                if (cheTaoPoint != null)
                                {
                                    KAutoHelper.ADBHelper.Tap(deviceID, cheTaoPoint.Value.X, cheTaoPoint.Value.Y);
                                } else
                                {
                                    return;
                                }
                            }
                        });
                        t1.Start();
                    }
                }
            });
            t.Start();
        }

        #endregion

        #region click vào những item khi sử dụng hiện lên chữ dùng
        private void Button_Item_Use(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;

                // lấy ra danh sách devices id để dùng
                List<string> devices = new List<string>();
                devices = KAutoHelper.ADBHelper.GetDevices();
                System.Drawing.Point? cheTaoPoint = new System.Drawing.Point?();
                // chạy từng device để điều khiển theo kịch bản bên trong
                foreach (var deviceID in devices)
                {
                    if (deviceID != "")
                    {
                        // tạo ra một luồng xử lý riêng biệt để xử lý cho device này
                        Task t1 = new Task(() => {
                            while (true)
                            {
                                if (isStop)
                                    return;

                                if(cheTaoPoint == null)
                                {
                                    var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                                    cheTaoPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BUTTON_USE);
                                }

                                KAutoHelper.ADBHelper.Tap(deviceID, cheTaoPoint.Value.X, cheTaoPoint.Value.Y);
                            }
                        });
                        t1.Start();
                    }
                }
            });
            t.Start();
        }
        #endregion


    }
}
