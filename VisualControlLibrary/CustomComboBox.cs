using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VissualControlLibrary
{
    public partial class CustomComboBox: UserControl
    {
        private event EventHandler comboBoxSelectedIndexChanged;

        public CustomComboBox()
        {
            InitializeComponent();
            comboBox.SelectedIndexChanged += (sender, e) => comboBoxSelectedIndexChanged?.Invoke(sender, e);
        }

        public event EventHandler ComboBoxSelectedIndexChanged
        {
            add { comboBoxSelectedIndexChanged += value; }
            remove { comboBoxSelectedIndexChanged -= value; }
        }

        public void AddItems(List<string> strings)
        {
            foreach (string item in strings)
            {
                comboBox.Items.Add(item);
            }
        }

        public void ClearItems()
        {
            comboBox.Items.Clear();
            comboBox.SelectedIndex = -1;
            comboBox.Text = "";
        }

        public String CurrentString
        {
            get { if (comboBox.SelectedItem == null)
                    return "";
                  else
                    return comboBox.SelectedItem.ToString();
            }
            set { if (comboBox.Items.IndexOf(comboBox.SelectedIndex) > -1 || comboBox.SelectedItem != null)
                    comboBox.Items[comboBox.Items.IndexOf(comboBox.SelectedItem)] = value;
            }
        }
    }
}
