using ChoETL;
using System.Text;

namespace DocumentConverter.DocumentConversion
{
    internal class CsvToXmlConverter : IDocumentConverter
    {
        public string Convert(string document)
        {
            var sb = new StringBuilder();

            using (var csvReader = ChoCSVReader.LoadText(document).WithFirstLineHeader())
            using (var jsonWriter = new ChoXmlWriter(sb))
            {
                jsonWriter.Write(csvReader.Select(i => i.ConvertToNestedObject('_')));
            }

            return sb.ToString();
        }
    }
}
