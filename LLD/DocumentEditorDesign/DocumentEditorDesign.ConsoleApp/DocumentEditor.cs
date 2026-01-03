using System.Net.Mime;

namespace DocumentEditorDesign.ConsoleApp;

// Bad Design
// public class DocumentEditor
// {
//     private readonly List<string> _elements = new List<string>();
//     private string _renderString = String.Empty;
//
//     public void AddText(string txt)
//     {
//         _elements.Add(txt);
//     }
//
//     public void AddImage(string path)
//     {
//         _elements.Add(path);
//     }
//
//     public string RenderElements()
//     {
//         _renderString = String.Join("\n", _elements);
//         return _renderString;
//     }
// }

// --------------- Better Design ---------------

public interface IDocumentElement
{
    string Render();
}

public class TextElement : IDocumentElement
{
    private string _text = String.Empty;

    public TextElement(string text)
    {
        _text = text;
    }
    public string Render()
    {
        return _text;
    }
}

public class ImageElement : IDocumentElement
{
    private string _imagePath = String.Empty;

    public ImageElement(string imagePath)
    {
        _imagePath = imagePath;
    }
    public string Render()
    {
        return $"[Image: {_imagePath}]";
    }
}

public class NewLineElement : IDocumentElement
{
    public string Render()
    {
        return "\n";
    }
}

public class Document
{
    private readonly List<IDocumentElement> _elements = new List<IDocumentElement>();

    public void AddElement(IDocumentElement element)
    {
        _elements.Add(element);
    }

    public string Render()
    {
        string result = String.Empty;
        foreach (var element in _elements)
        {
            result += element.Render();
        }

        return result;
    }
}

public interface IPersistence
{
    void Persist(string data);
}

public class FileStorage : IPersistence
{
    public void Persist(string data)
    {
        Console.WriteLine("Document saved to file successfully");
    }
}

public class SqlDbStorage : IPersistence
{
    public void Persist(string data)
    {
        Console.WriteLine("Document saved to SQL DB successfully");
    }
}

public class DocumentEditor
{
    private readonly Document _document;
    private readonly IPersistence _storage;
    private string _renderedDocument = String.Empty;

    public DocumentEditor(Document document, IPersistence storage)
    {
        _document = document;
        _storage = storage;
    }

    public void AddText(string text)
    {
        _document.AddElement(new TextElement(text));
    }

    public void AddImage(string path)
    {
        _document.AddElement(new ImageElement(path));
    }
    
    public void AddNewLine()
    {
        _document.AddElement(new NewLineElement());
    }

    public string RenderDocument()
    {
        if (_renderedDocument == String.Empty)
        {
            _renderedDocument = _document.Render();
        }
        return _renderedDocument;
    }

    public void SaveDocument()
    {
        _storage.Persist(RenderDocument());
    }
}
