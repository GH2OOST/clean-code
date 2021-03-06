﻿namespace Markdown
{
    public class ItalicField : ITokenType
    {
        public readonly string Marker = "_";

        public string ToHtml(string text, bool opened, bool closed)
        {
            var html = text;
            if (opened)
                html = $"<em>{html}";
            if (closed)
                html = $"{html}</em>";
            return html;
        }

        public bool CheckIfOpen(char symbol, char left, string right)
        {
            return SpecificationCheck(symbol, left, right) && !char.IsWhiteSpace(right[0]);
        }
        
        public bool CheckIfClosing(char symbol, char left, string right)
        {
            return SpecificationCheck(symbol, left, right) && !char.IsWhiteSpace(left);
        }

        private bool SpecificationCheck(char symbol, char left, string right)
        {
            if (symbol != Marker[0])
                return false;
            if (left == '\\')
                return false;
            if (char.IsDigit(left) || char.IsDigit(right[0]))
                return false;
            return right[0] != '_';
        }

        public ITokenType[] SupportedInnerTypes() => new ITokenType[0];

        public string GetMarker()
        {
            return Marker;
        }
    }
}