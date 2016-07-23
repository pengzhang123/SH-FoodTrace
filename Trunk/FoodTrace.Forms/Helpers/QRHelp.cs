using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;

namespace FoodTrace.Forms.Helpers
{
    public class QRHelp
    {
        public static Bitmap GenerateQR(string url, string background = "#ffffffff", string foreground = "#ff000000")
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            //设置编码模式
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            //设置编码测量度
            qrCodeEncoder.QRCodeScale = 3;
            
            //设置版本编码（越大包含的字符越多）
            qrCodeEncoder.QRCodeVersion = 0;
            //设置编码错误纠正
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            string rb = background.ToLower().Replace("#ff", "").Substring(0, 2);
            string gb = background.ToLower().Replace("#ff", "").Substring(2, 2);
            string bb = background.ToLower().Replace("#ff", "").Substring(4, 2);
            Color cBack = Color.FromArgb(Convert.ToInt32(rb, 16), Convert.ToInt32(gb, 16), Convert.ToInt32(bb, 16));
            string rf = foreground.ToLower().Replace("#ff", "").Substring(0, 2);
            string gf = foreground.ToLower().Replace("#ff", "").Substring(2, 2);
            string bf = foreground.ToLower().Replace("#ff", "").Substring(4, 2);
            Color cFore = Color.FromArgb(Convert.ToInt32(rf, 16), Convert.ToInt32(gf, 16), Convert.ToInt32(bf, 16));
            qrCodeEncoder.QRCodeBackgroundColor = cBack;
            qrCodeEncoder.QRCodeForegroundColor = cFore;
            Bitmap bitmap = qrCodeEncoder.Encode(url);
            return bitmap;
        }
    }
}
