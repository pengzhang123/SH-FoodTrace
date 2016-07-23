using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace FoodTrace.Forms.UserControls
{
    public class SJTextBox : TextBox
    {
        static SJTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SJTextBox), new FrameworkPropertyMetadata(typeof(SJTextBox)));
        }

        public static DependencyProperty WaterRemarkProperty =
            DependencyProperty.Register("WaterRemark", typeof(string), typeof(SJTextBox));

        /// <summary>
        /// 水印文字
        /// </summary>
        public string WaterRemark
        {
            get { return GetValue(WaterRemarkProperty).ToString(); }
            set { SetValue(WaterRemarkProperty, value); }
        }

        public static DependencyProperty BorderCornerRadiusProperty =
            DependencyProperty.Register("BorderCornerRadius", typeof(CornerRadius), typeof(SJTextBox));

        /// <summary>
        /// 边框角度
        /// </summary>
        public CornerRadius BorderCornerRadius
        {
            get { return (CornerRadius)GetValue(BorderCornerRadiusProperty); }
            set { SetValue(BorderCornerRadiusProperty, value); }
        }

        public SJTextBox()
        {
            this.Loaded += SJTextBox_Loaded;
        }

        public static DependencyProperty IsPasswordBoxProperty =
            DependencyProperty.Register("IsPasswordBox", typeof(bool), typeof(SJTextBox), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnIsPasswordBoxChnage)));

        /// <summary>
        /// 是否为密码框
        /// </summary>
        public bool IsPasswordBox
        {
            get { return (bool)GetValue(IsPasswordBoxProperty); }
            set { SetValue(IsPasswordBoxProperty, value); }
        }

        public static DependencyProperty PasswordCharProperty =
            DependencyProperty.Register("PasswordChar", typeof(char), typeof(SJTextBox), new FrameworkPropertyMetadata('●'));

        /// <summary>
        /// 替换明文的单个密码字符
        /// </summary>
        public char PasswordChar
        {
            get { return (char)GetValue(PasswordCharProperty); }
            set { SetValue(PasswordCharProperty, value); }
        }

        public static DependencyProperty PasswordStrProperty =
            DependencyProperty.Register("PasswordStr", typeof(string), typeof(SJTextBox), new FrameworkPropertyMetadata(string.Empty));
        /// <summary>
        /// 密码字符串
        /// </summary>
        public string PasswordStr
        {
            get { return GetValue(PasswordStrProperty).ToString(); }
            set { SetValue(PasswordStrProperty, value); }
        }

        private static void OnIsPasswordBoxChnage(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as SJTextBox).SetEvent();
        }

        /// <summary>
        /// 定义TextChange事件
        /// </summary>
        private void SetEvent()
        {
            if (IsPasswordBox)
                this.TextChanged += SJTextBox_TextChanged;
            else
                this.TextChanged -= SJTextBox_TextChanged;
        }

        private void SJTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsResponseChange) //响应事件标识，替换字符时，不处理后续逻辑
                return;
            Console.WriteLine(string.Format("------{0}------", e.Changes.Count));
            foreach (TextChange c in e.Changes)
            {
                Console.WriteLine(string.Format("addLength:{0} removeLenth:{1} offSet:{2}", c.AddedLength, c.RemovedLength, c.Offset));
                PasswordStr = PasswordStr.Remove(c.Offset, c.RemovedLength); //从密码文中根据本次Change对象的索引和长度删除对应个数的字符
                PasswordStr = PasswordStr.Insert(c.Offset, Text.Substring(c.Offset, c.AddedLength));   //将Text新增的部分记录给密码文
                lastOffset = c.Offset;
            }
            Console.WriteLine(PasswordStr);
            /*将文本转换为密码字符*/
            IsResponseChange = false;  //设置响应标识为不响应
            this.Text = ConvertToPasswordChar(Text.Length);  //将输入的字符替换为密码字符
            IsResponseChange = true;   //回复响应标识
            this.SelectionStart = lastOffset + 1; //设置光标索引
            Console.WriteLine(string.Format("SelectionStar:{0}", this.SelectionStart));
        }
        StringBuilder PasswordBuilder = null;
        bool IsResponseChange = true;
        int lastOffset = 0;
        /// <summary>
        /// 按照指定的长度生成密码字符
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string ConvertToPasswordChar(int length)
        {
            if (PasswordBuilder != null)
                PasswordBuilder.Clear();
            else
                PasswordBuilder = new StringBuilder();
            for (var i = 0; i < length; i++)
                PasswordBuilder.Append(PasswordChar);
            return PasswordBuilder.ToString();
        }

        private void SJTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsPasswordBox)
            {
                IsResponseChange = false;
                this.Text = ConvertToPasswordChar(PasswordStr.Length);
                IsResponseChange = true;
            }
        }
    }
}
