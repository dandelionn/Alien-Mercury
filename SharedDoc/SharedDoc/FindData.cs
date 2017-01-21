
namespace SharedDoc
{
    public class FindData
    {
        public int StartPosition { get; set; }
        public string Text { get; set; }
        public string TextToFind { get; set; }

        public FindData(int startPosition, string text, string textToFind)
        {
            StartPosition = startPosition;
            Text = text;
            TextToFind = textToFind;
        }
    }
}
