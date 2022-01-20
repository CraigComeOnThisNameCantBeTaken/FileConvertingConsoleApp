using ChoETL;
using CsvHelper;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Globalization;
using System.Text;

namespace DocumentConverter.DocumentConversion
{
    internal class CsvToJsonConverter : IDocumentConverter
    {
        public string Convert(string document)
        {
            var sb = new StringBuilder();

            using (var csvReader = ChoCSVReader.LoadText(document)
                .WithFirstLineHeader()
                .Configure(c => c.NestedColumnSeparator = '_')
            )
            using (var jsonWriter = new ChoJSONWriter(sb).Configure(c => c.DefaultArrayHandling = false))
            {
                jsonWriter.Write(csvReader);
            }

            return sb.ToString();
        }
    }
}
