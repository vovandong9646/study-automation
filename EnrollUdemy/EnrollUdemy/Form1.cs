using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Threading;
using KAutoHelper;

namespace EnrollUdemy
{
    public partial class Form1 : Form
    {
        Bitmap BTN_ENROLL;
        Bitmap BTN_ENROLL_NO_FEE;
        Bitmap SCREEN_SUCCESS;
        Bitmap BTN_CHECKOUT_SCREEN;
        public Form1()
        {
            InitializeComponent();
            BTN_ENROLL = (Bitmap)Bitmap.FromFile("Data\\btnEnroll.png");
            SCREEN_SUCCESS = (Bitmap)Bitmap.FromFile("Data\\success.png");
            BTN_ENROLL_NO_FEE = (Bitmap)Bitmap.FromFile("Data\\btnEnroll_noFee.png");
            BTN_CHECKOUT_SCREEN = (Bitmap)Bitmap.FromFile("Data\\btnCheckOutEnroll.png");
        }

        bool isStop = false;
        List<string> linkCourseList = new List<string>();

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string filename = txtFileName.Text;
            if(filename == "")
            {
                filename = "Discudemy.xlsx";
            }
            readFileExcel(filename);
            execute();
        }

        void execute()
        {
            Task task = new Task(() =>
            {
                isStop = false;
                xulyAuto();
            });
            task.Start();   
        }

        void xulyAuto()
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
                    Task t = new Task(() =>
                    {
                        foreach(string link in linkCourseList)
                        {
                            if (isStop)
                                return;
                            // mở trình duyệt trên màn hình
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 32.75, 33.75);
                            Delay(3);

                            // click vao address tren browser
                            if (isStop)
                                return;
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 91.8, 21);
                            Delay(2);

                            if (isStop)
                                return;
                            // gõ link vào trình duyệt sau đó ấn enter
                            KAutoHelper.ADBHelper.InputText(deviceID, link);
                            Delay(2);

                            if (isStop)
                                return;
                            // ấn enter
                            KAutoHelper.ADBHelper.Key(deviceID, ADBKeyEvent.KEYCODE_ENTER);
                            // Đợi 10s để hoàn thành load trang course
                            Delay(10);

                            if (isStop) return;
                            // scroll chuột xuống xí để nó thấy được cái button enroll
                            KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 48.25, 46.75, 48.25, 30);
                            Delay(2);

                            if (isStop)
                                return;
                            // click vào biểu tượng enroll
                            var mainScreen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                            mainScreen.Save("mainScreen.png");
                            //var imgCrop = KAutoHelper.CaptureHelper.CropImage(mainScreen, new Rectangle(447, 164, 300, 200));
                            //imgCrop.Save("imgCrop.png");
                            var pointBtnEnroll = KAutoHelper.ImageScanOpenCV.FindOutPoint(mainScreen, BTN_ENROLL);
                            if (pointBtnEnroll != null)
                            {
                                //KAutoHelper.ADBHelper.Tap(deviceID, pointBtnEnroll.Value.X + 447, pointBtnEnroll.Value.Y + 164);
                                KAutoHelper.ADBHelper.Tap(deviceID, pointBtnEnroll.Value.X, pointBtnEnroll.Value.Y);
                                Delay(10);

                                if (isStop)
                                    return;
                                // check xem thử có ra màn hình success hay chưa
                                var mainSuccess = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                                mainSuccess.Save("successScreen.png");
                                //var imgCropSuccess = KAutoHelper.CaptureHelper.CropImage(mainSuccess, new Rectangle(69, 177, 300, 100));
                                var pointSuccess = KAutoHelper.ImageScanOpenCV.FindOutPoint(mainSuccess, SCREEN_SUCCESS);
                                
                                if (pointSuccess == null)
                                {
                                    // nếu chưa ra màn hình sucess thì tiếp tục xử lý
                                    // scroll chuột xuống xí để nó thấy được cái button enroll
                                    KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 48.25, 46.75, 48.25, 30);
                                    Delay(1);
                                    // scroll chuột xuống xí để nó thấy được cái button enroll
                                    KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 48.25, 46.75, 48.25, 30);
                                    Delay(1);
                                    // scroll chuột xuống xí để nó thấy được cái button enroll
                                    KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 48.25, 46.75, 48.25, 30);
                                    Delay(2);
                                    var checkoutScreen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                                    checkoutScreen.Save("checkoutScreen.png");
                                    var pointBtnCheckOut = KAutoHelper.ImageScanOpenCV.FindOutPoint(checkoutScreen, BTN_CHECKOUT_SCREEN);
                                    if(pointBtnCheckOut != null)
                                    {
                                        KAutoHelper.ADBHelper.Tap(deviceID, pointBtnCheckOut.Value.X, pointBtnCheckOut.Value.Y);
                                    }
                                }
                                Delay(2);
                            } else
                            {
                                // nếu khoá học không trả tiền
                                // bỏ vào else để nếu như vào if rồi thì nó không cần phải check cái phần else này
                                // còn nếu như bỏ ra ngoài thì nó sẽ find image 2 lần
                                if (isStop) return;
                                var mainNoFee = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                                mainNoFee.Save("freeEnroll.png");
                                // var imgCropNoFee = KAutoHelper.CaptureHelper.CropImage(mainNoFee, new Rectangle(447, 164, 400, 400));
                                var pointBtnEnrollNoFee = KAutoHelper.ImageScanOpenCV.FindOutPoint(mainNoFee, BTN_ENROLL_NO_FEE);
                                if (pointBtnEnrollNoFee != null)
                                {
                                    KAutoHelper.ADBHelper.Tap(deviceID, pointBtnEnrollNoFee.Value.X, pointBtnEnrollNoFee.Value.Y);
                                    //KAutoHelper.ADBHelper.Tap(deviceID, pointBtnEnrollNoFee.Value.X + 447, pointBtnEnrollNoFee.Value.Y + 164);
                                    Delay(2);
                                }
                            }

                            // nếu ở mành hình success hay đã enroll trước đó rồi, thì nhấn button thoát để chạy lại cái enroll tiếp theo
                            if (isStop)
                            return;
                            KAutoHelper.ADBHelper.TapByPercent(deviceID, 22.9, 10.3);
                            Delay(2);
                        }
                    });
                    t.Start();
                }
            }
        }

        void Delay(int second)
        {
            while(second > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                second--;
                if (isStop)
                    break;
            }
        }

        void readFileExcel(String fileName)
        {
            Excel.Application excelApp = new Excel.Application();
            if (excelApp != null)
            {
                //Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(@"C:\Users\DongVV2\Desktop\" + fileName, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(@"C:\Users\DongVV2\Desktop\" + fileName);
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

                Excel.Range excelRange = excelWorksheet.UsedRange;
                int rowCount = excelRange.Rows.Count;
                int colCount = excelRange.Columns.Count;

                for (int i = 1; i <= rowCount; i++)
                {
                    Excel.Range range = (excelWorksheet.Cells[i, 1] as Excel.Range);
                    string linkName = range.Value.ToString();

                    // save data in list
                    linkCourseList.Add(linkName);
                }

                excelWorkbook.Close();
                excelApp.Quit();
            }
        }

        private void btnStopProcess_Click(object sender, EventArgs e)
        {
            isStop = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
