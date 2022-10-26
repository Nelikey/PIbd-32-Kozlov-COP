using NonVisualControlLibrary.Enums;
using NonVisualControlLibrary.HelperModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1View
{
    public partial class ComponentsCheckForm : Form
    {
        public ComponentsCheckForm()
        {
            InitializeComponent();

            //customTB.SetToolTip("example@gmail.com");
            //customCB.CurrentString = "";
        }

        private void buttonCreateLongTextWord_Click(object sender, EventArgs e)
        {
            string[] array = { "Абзац 1", "Абзац 2", "Абзац 3" };
            longTextComponentWord.ParametersInput("C:\\3rd course\\COP\\docs\\LongTextWord.docx", "Название", array);
        }

        private void buttonCreateLinearDiagramWord_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<DiagramData>> data = new Dictionary<string, List<DiagramData>>();

            List<DiagramData> list1 = new List<DiagramData>();
            list1.Add(new DiagramData { name = "str0", value = 0 });
            list1.Add(new DiagramData { name = "str1", value = 1 });
            list1.Add(new DiagramData { name = "str2", value = 2 });
            list1.Add(new DiagramData { name = "str3", value = 3 });

            data.Add("Диаграмма 1", list1);

            List<DiagramData> list2 = new List<DiagramData>();
            list2.Add(new DiagramData { name = "str0", value = 4 });
            list2.Add(new DiagramData { name = "str1", value = 1 });
            list2.Add(new DiagramData { name = "str2", value = 3 });
            list2.Add(new DiagramData { name = "str3", value = 2 });

            data.Add("Диаграмма 2", list2);

            linearDiagramWord.ParametersInput("C:\\3rd course\\COP\\docs\\LinearDiagramWord.docx",
                "Линейная диаграмма", "Диаграмма 1", DiagramLegendPosition.Bottom, data);
        }

        private void buttonCreateWordWithTable_Click(object sender, EventArgs e)
        {
            List<WordTitleColumn> titleColumn = new List<WordTitleColumn>();
            List<WordMergedTitleColumn> mergedTitleColumns = new List<WordMergedTitleColumn>();
            List<Object> objects = new List<Object>();

            Worker c = new Worker { Id = 0, Name = "Иван", Surname = "Иванов", Salary = 1000};
            objects.Add(c);
            objects.Add(new Worker { Id = 1, Name = "Виктория", Surname = "Викторова", Salary = 1200});
            objects.Add(new Worker { Id = 2, Name = "Семён", Surname = "Семёнов", Salary = 900});
            objects.Add(new Worker { Id = 3, Name = "Мария", Surname = "Марьина", Salary = 1100});
            objects.Add(new Worker { Id = 4, Name = "Петров", Surname = "Петр", Salary = 2000});
            Type type = c.GetType();

            titleColumn.Add(new WordTitleColumn { Name = "Id", Width = 20, PropertyInfo = type.GetProperty("Id") });
            titleColumn.Add(new WordTitleColumn { Name = "Name", Width = 26, PropertyInfo = type.GetProperty("Name") });
            titleColumn.Add(new WordTitleColumn { Name = "Surname", Width = 40, PropertyInfo = type.GetProperty("Surname") });
            titleColumn.Add(new WordTitleColumn { Name = "Salary", Width = 23, PropertyInfo = type.GetProperty("Salary") });

            mergedTitleColumns.Add(new WordMergedTitleColumn
            {
                Columns = new int[] { 0, 1, 2 },
                Title = "Common"
            });
            tableWordFirst2Rows.ParametersInput("C:\\3rd course\\COP\\docs\\TableWord.docx", "Таблица", titleColumn, mergedTitleColumns, objects);
        }
    }
}
