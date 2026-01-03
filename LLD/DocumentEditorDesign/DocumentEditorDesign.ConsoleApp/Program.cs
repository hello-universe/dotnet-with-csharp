namespace DocumentEditorDesign.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        // -------- Bad approach implementation ----------
        // DocumentEditor editor = new DocumentEditor();
        // editor.AddText("Hi! This is Amit Verma");
        // editor.AddImage("/home/desktop");
        // editor.AddText("This is a document editor");
        // Console.WriteLine(editor.RenderElements());
        
        // ---------------- Better approach implementation -------------

        Document document = new Document();
        IPersistence persistence = new FileStorage();
        DocumentEditor documentEditor = new DocumentEditor(document, persistence);
        
        documentEditor.AddText("Hello ");
        documentEditor.AddText("World");
        documentEditor.AddNewLine();
        documentEditor.AddImage("/home/desktop/flower.jpg");
        Console.WriteLine(documentEditor.RenderDocument());
        documentEditor.SaveDocument();
    }
}