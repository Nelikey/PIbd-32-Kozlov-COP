using NonVisualControlLibrary.Enums;
using NonVisualControlLibrary.HelperModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace NonVisualControlLibrary
{
    public partial class LinearDiagramWord : Component
    {
        public LinearDiagramWord()
        {
            InitializeComponent();
        }

        public LinearDiagramWord(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        // Метод ввода парметров
        public void ParametersInput(string filePath, string title, string nameDiagram,
            DiagramLegendPosition diagramLegendPosition, Dictionary<string, List<DiagramData>> data)
        {
            if (String.IsNullOrEmpty(filePath) || String.IsNullOrEmpty(title) || String.IsNullOrEmpty(nameDiagram) || data.Count == 0)
            {
                throw new Exception("Поля не заполнены");
            }
            CreateDoc(filePath, title, nameDiagram, diagramLegendPosition, data);

        }

        // Создание документа
        private void CreateDoc(string fileName, string title, string nameDiagram, DiagramLegendPosition diagramLegendPosition, Dictionary<string, List<DiagramData>> data)
        {
            try
            {
                DocX document = DocX.Create(fileName);
                document.InsertParagraph(title);
                document.Paragraphs[0].Direction = Direction.RightToLeft;
                document.Paragraphs[0].Alignment = Alignment.center;
                document.Paragraphs[0].FontSize(20);
                document.Paragraphs[0].Bold();
                document.InsertChart(CreateLineChart((ChartLegendPosition)diagramLegendPosition, nameDiagram, data));
                document.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Метод создания диаграммы
        private Chart CreateLineChart(ChartLegendPosition chartLegendPosition, string nameDiagram, Dictionary<string, List<DiagramData>> data)
        {
            // создаём линейную диаграмму
            LineChart lineChart = new LineChart();
            // добавляем легенду 
            lineChart.AddLegend(chartLegendPosition, false);
            //Series seriesFirst = new Series(nameDiagram);
            // заполняем данными
            //seriesFirst.Bind(data, "name", "value");
            // создаём набор данных и добавляем на диаграмму
            //lineChart.AddSeries(seriesFirst);

            foreach(var dd in data)
            {
                Series series = new Series(dd.Key);
                series.Bind(dd.Value, "name", "value");
                lineChart.AddSeries(series);
            }

            return lineChart;
        }
    }
}
