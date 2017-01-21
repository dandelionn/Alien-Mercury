using System.Collections.Generic;
using System.Text;

namespace SharedDoc
{
    public class TextFinder
    {
        private List<int> _positions;
        private char[] _textToFind;
        private char[] _searchText;
        private int[] _next;
        private int m, n;

        void Prefix()
        {
            int i, k;
            k = 0;
            _next[1] = 0;
            for (i = 2; i <= m; i++)
            {
                while (k > 0 && _textToFind[k + 1] != _textToFind[i])
                    k = _next[k];
                if (_textToFind[k + 1] == _textToFind[i])
                    k = k + 1;
                _next[i] = k;
            }
        }

        void Match()
        {
            int i, k;
            k = 0;
            for (i = 1; i <= n; i++)
            {
                while (k > 0 && _textToFind[k + 1] != _searchText[i])
                    k = _next[k];
                if (_textToFind[k + 1] == _searchText[i])
                    k = k + 1;
                if (k == m)
                {
                    _positions.Add(i - m);
                    k = _next[k];
                }
            }
        }

        public void MoveText()
        {
            int i;
            for (i = m + 1; i >= 1; --i)
                _textToFind[i] = _textToFind[i - 1];
            for (i = n + 1; i >= 1; --i)
                _searchText[i] = _searchText[i - 1];
        }

        public List<int> Find(string textToFind, string searchText)
        {   
            _next = new int[searchText.Length];
            _positions = new List<int>();

            m = textToFind.Length; n = searchText.Length;

            _textToFind = (" " + textToFind).ToCharArray();
            _searchText = (" " + searchText).ToCharArray();

           

            //MoveText();
            Prefix();
            Match();

            return _positions;
        }
    }
}
