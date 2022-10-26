using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VissualControlLibrary
{
    public partial class CustomListBox : UserControl
    {
        private List<string> layoutFields;

        private bool isField;

        // Символ начала шаблона свойства
        public char startSign;

        // Символ конца шаблона свойства
        public char endSign;

        // Макетная строка
        public string layout;

        public void SetLayoutSpecifies(char startSign, char endSign, string layout)
        {
            this.startSign = startSign;
            this.endSign = endSign;
            string str = layout;

            while (str.Contains(startSign))
            {
                int startIndex = str.IndexOf(startSign) + 1;
                int endIndex = str.IndexOf(endSign);
                string field = str.Substring(startIndex, endIndex - startIndex);
                layoutFields.Add(field);
                str = str.Substring(endIndex + 1);
            }
            
            isField = true;
            this.layout = layout;
        }

        public CustomListBox()
        {
            InitializeComponent();
        }

        [Category("Спецификация"), Description("CurrentIndex")]
        public int SelectedIndex
        {
            get => listBox.SelectedIndex;
            set
            {
                if (value >= -1 && value < listBox.Items.Count)
                    listBox.Items.Clear()
                    listBox.SelectedIndex = value;
            }
        }

        public void Clear()
        {
            listBox.Items.Clear();
        }

        public T GetItem<T>() where T : new()
        {
            if (listBox.SelectedIndex != -1)
            {
                string item = listBox.SelectedItem.ToString();
                T t = new T();

                List<string> itemFields = new List<string>();
                while (item != "")
                {
                    int startIndex = item.IndexOf(startSign) + 1;
                    int endIndex = item.IndexOf(endSign);
                    string field = item.Substring(startIndex, endIndex - startIndex);
                    itemFields.Add(field);
                    item = item.Substring(endIndex + 1);
                }

                Type type = t.GetType();
                FieldInfo[] fields = type.GetFields();

                foreach (var f in fields)
                {
                    foreach (var lf in layoutFields)
                    {
                        foreach (var itemf in itemFields)
                        {
                            if (f.Name.Equals(lf))
                            {
                                Type fieldsType = type.GetField(lf).FieldType;
                                var replaceField = Convert.ChangeType(itemf, fieldsType);
                                type.GetField(lf).SetValue(t, replaceField);
                            }
                        }
                    }
                }
                return t;
            }
            return new T();
        }

        public void AddToList<T>(List<T> obj)
        {
            if (!isField)
            {
                throw new Exception("Поля не заполнены");
            }
            foreach (string field in layoutFields)
            {
                if (field.Equals(String.Empty))
                {
                    throw new Exception("Поля не заполнены");
                }
            }
            List<string> values = new List<string>();

            if (obj.Count == 0)
            {
                return;
            }

            Type type = obj[0].GetType();
            FieldInfo[] fields = type.GetFields();

            foreach (T o in obj)
            {
                values.Clear();
                foreach (var f in fields)
                {
                    foreach (var lf in layoutFields)
                    {
                        if (f.Name.Equals(lf))
                        {
                            values.Add(f.GetValue(o).ToString());
                        }
                    }
                }
                string str = layout;
                for (int i = 0; i < values.Count; i++)
                {
                    str = str.Replace(startSign + layoutFields[i] + endSign, values[i]);
                }
                listBox.Items.Add(str);
                str = layout;
            }
        }
    }
}
