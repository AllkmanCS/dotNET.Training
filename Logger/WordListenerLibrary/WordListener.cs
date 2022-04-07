using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ListenersConfigurationLibrary.ListenersConfigurations;
using ListenersRepository;
using Microsoft.Extensions.Configuration;

namespace WordListenerLibrary
{
    public class WordListener : IListener
    {
        public string FileName { get; set; }
        public string MinLogLevel { get; set; }
        public WordListener()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                   .AddJsonFile(@"C:\Users\AlgirdasCernevicius\source\repos\dotNET.Training\Logger\WordListenerLibrary\wordListenerSettings.json");
            var config = builder.Build();
            var wordListenerConfig = config.GetSection(WordListenerConfiguration.SectionName)
                .Get<WordListenerConfiguration>();
            FileName = wordListenerConfig.FileName;
            MinLogLevel = wordListenerConfig.MinLogLevel;
        }
        public void Write(string message)
        {
            // Create a document by supplying the filepath. 
            using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Create(FileName, WordprocessingDocumentType.Document))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                // Create the document structure and add some text.
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                run.AppendChild(new Text(message));
            }
        }
    }
}