using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // lưu ý đây là click chiếm chuột
        private void btnClickTheoToaDo_Click(object sender, EventArgs e)
        {
            // get toạ độ X và toạ độ Y
            int x = int.Parse(txtX.Text);
            int y = int.Parse(txtY.Text);

            if(chkMouse.Checked)
            {
                // click chuot phai
                KAutoHelper.AutoControl.MouseClick(x, y, KAutoHelper.EMouseKey.RIGHT);
            } else
            {
                // click chuot trai
                // default click chuột trái rồi, nên không cần truyền param thứ 3 vào cũng đc (nhưng thích thì truyền cũng chẳng sao)
                KAutoHelper.AutoControl.MouseClick(x, y);
            }      

        }

        private void btnClickTheoViTriHandle_Click(object sender, EventArgs e)
        {
            // get toạ độ X và toạ độ Y -> toạ độ của cái nút cần click ở bên trong ứng dụng
            int x = int.Parse(txtX.Text);
            int y = int.Parse(txtY.Text);

            // tìm ra cái ứng dụng của mình
            IntPtr hwnd = KAutoHelper.AutoControl.FindWindowHandle(null, "Remote Desktop Connection");

            // tìm vị trí của phần tử con muốn click
            IntPtr childHwnd = KAutoHelper.AutoControl.FindHandle(hwnd, "ToolbarWindow32", null);

            // tìm vị trí của cái nút bên trong ứng dụng đó
            var pointToClick = KAutoHelper.AutoControl.GetGlobalPoint(childHwnd, x, y);

            // nếu như toạ độ muốn click  bị che bởi phần mềm khác thì ta cho nó lên top (để nó nhìn thấy được)
            KAutoHelper.AutoControl.BringToFront(childHwnd);

            if (chkMouse.Checked)
            {
                // click chuot phai
                KAutoHelper.AutoControl.MouseClick(pointToClick, KAutoHelper.EMouseKey.RIGHT);
            }
            else
            {
                // click chuot trai
                // default click chuột trái rồi, nên không cần truyền param thứ 3 vào cũng đc (nhưng thích thì truyền cũng chẳng sao)
                KAutoHelper.AutoControl.MouseClick(pointToClick);
            }
        }

        // click không chiếm chuột
        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr hwnd = KAutoHelper.AutoControl.FindWindowHandle(null, "Remote Desktop Connection");
            // tìm vị trí của phần tử con muốn click
            IntPtr childHwnd = KAutoHelper.AutoControl.FindHandle(hwnd, "ToolbarWindow32", null);
            KAutoHelper.AutoControl.SendClickOnControlByHandle(childHwnd);
        }
    }
}
