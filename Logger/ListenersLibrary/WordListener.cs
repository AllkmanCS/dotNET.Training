using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ListenersConfigurationLibrary.Interfaces;
using ListenersConfigurationLibrary.ListenersConfigurations;

namespace ListenersLibrary
{
    public class WordListener : IListener
    {
        private string FileName { get; set; }
        public string MinLogLevel { get; set; }
        public WordListener(WordListenerConfiguration configuration)
        {
            FileName = configuration.FileName;
            MinLogLevel = configuration.MinLogLevel;
        }
        public WordListener() { }
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
