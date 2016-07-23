using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace FoodTrace.Forms.UserControls
{
    public class MaskTextBox : TextBox
    {
        #region MaskText
        /// <summary>
        /// view sort style, desc arrow
        /// </summary>
        public static readonly DependencyProperty MaskTextProperty =
                   DependencyProperty.Register("MaskText", typeof(string), typeof(MaskTextBox));

        public string MaskText
        {
            get { return (string)GetValue(MaskTextProperty); }
            set { SetValue(MaskTextProperty, value); }
        }
        #endregion

        public MaskTextBox()
        {
            Loaded += (sender, args) =>
            {
                if (string.IsNullOrEmpty(base.Text))
                {
                    base.Text = MaskText;
                }
            };

            base.GotFocus += (sender, args) =>
            {
                if (base.Text == MaskText)
                    base.Text = string.Empty;
            };
            base.LostFocus += (sender, args) =>
            {
                if (!string.IsNullOrEmpty(base.Text))
                    return;

                base.Text = MaskText;
            };
        }

        public new string Text
        {
            get
            {
                if (base.Text == MaskText)
                    return string.Empty;
                else
                    return base.Text;
            }
            set { base.Text = value; }
        }
    }
}
