using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace VissualControlLibrary
{
    public partial class CustomTextBox : UserControl
    {
        [Category("Спецификация"), Description("Pattern")]
        public string Pattern { get; set; } = @"^[A-Za-z0-9]+(?:[._%+-])?[A-Za-z0-9._-]+[A-Za-z0-9]@[A-Za-z0-9]+(?:[.-])?[A-Za-z0-9._-]+\.[A-Za-z]{2,6}$";

        private event EventHandler textBoxTextChanged;

        public void SetToolTip(string emailExample)
        {
            toolTipExample.SetToolTip(textBox, emailExample);
        }
        [Category("Спецификация"), Description("Value")]
        public string Value
        {
            get
            {
                if (Regex.IsMatch(textBox.Text, Pattern)){
                    return textBox.Text;
                }
                else
                    throw new ArgumentException();
            }
            set
            {
                if (Regex.IsMatch(value, Pattern))
                {
                    textBox.Text = value;
                }
                else
                    throw new ArgumentException();
            }
        }

        public CustomTextBox()
        {
            InitializeComponent();
            textBox.TextChanged += (sender, e) => textBoxTextChanged?.Invoke(sender, e);
        }

        public event EventHandler TextBoxTextChanged
        {
            add { textBoxTextChanged += value; }
            remove { textBoxTextChanged -= value; }
        }
    }
}
