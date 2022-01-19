using DocumentConverter;
using DocumentConverter.Constants;
using DocumentConverter.DocumentConversion;
using FileSystem;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddFileSystem();
services.AddDocumentConversion();

var serviceProvider = services.BuildServiceProvider();
var documentConverterService = serviceProvider
    .GetRequiredService<IDocumentConverterService>();

// currently we only support reading from the file system and csvs to xml or json, however in the future we could change
// the console to support reading from different locations and different file types
Console.WriteLine("Enter file name: ");
var fileIdentifier = Console.ReadLine();

Console.WriteLine("What are you converting to?");
var toString = Console.ReadLine();
var to = (DocumentType)Enum.Parse(typeof(DocumentType), toString, true);

try
{
    var convertedDocument = await documentConverterService.ConvertAsync(fileIdentifier, DocumentType.Csv, to);
    Console.WriteLine(convertedDocument);
} catch(DocumentConversionException e) {
    Console.WriteLine(e.Message);
}

Console.ReadLine();
