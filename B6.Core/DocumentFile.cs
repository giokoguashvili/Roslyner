namespace B6.Core
{
    public class DocumentFile 
    {
        public string Title { get; }
        public string Content { get; }

        public DocumentFile(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}