using System.Reflection;

namespace NonVisualControlLibrary.HelperModels
{
    public class WordTitleColumn
    {
        public string Name { get; set; }
        public decimal Width { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public FieldInfo FieldInfo { get; set; }
    }
}