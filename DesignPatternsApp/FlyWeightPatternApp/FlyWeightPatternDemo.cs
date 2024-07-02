using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeightPatternApp
{
    // Flyweight: CharacterStyle holds the shared properties
    public class CharacterStyle
    {
        public string Font { get; }
        public int Size { get; }
        public bool IsBold { get; }
        public bool IsItalic { get; }
        public CharacterStyle(string font, int size, bool isBold, bool isItalic)
        {
            Font = font;
            Size = size;
            IsBold = isBold;
            IsItalic = isItalic;
        }
        public void DisplayStyle()
        {
            Console.WriteLine($"Font: {Font}, Size: {Size}, Bold: {IsBold}, Italic: {IsItalic}");
        }
    }
    // Flyweight Factory
    public class StyleFactory
    {
        private readonly Dictionary<string, CharacterStyle> _styles = new Dictionary<string, CharacterStyle>();
        public CharacterStyle GetStyle(string font, int size, bool isBold, bool isItalic)
        {
            var key = $"{font}_{size}_{isBold}_{isItalic}";
            if (!_styles.ContainsKey(key))
            {
                _styles[key] = new CharacterStyle(font, size, isBold, isItalic);
            }
            return _styles[key];
        }
    }
    // The ConcreteFlyweight class with external states.
    public class Character
    {
        private readonly CharacterStyle _style;
        public char Symbol { get; }
        public int Position { get; }
        public Character(char symbol, int position, CharacterStyle style)
        {
            Symbol = symbol;
            Position = position;
            _style = style;
        }
        public void Display()
        {
            Console.Write(Symbol);
            _style.DisplayStyle();
        }
    }
    // Client
    class TextEditor
    {
        private readonly List<Character> _document = new List<Character>();
        private readonly StyleFactory _styleFactory = new StyleFactory();
        public void InsertCharacter(char symbol, int position, string font, int size, bool isBold, bool isItalic)
        {
            var style = _styleFactory.GetStyle(font, size, isBold, isItalic);
            _document.Add(new Character(symbol, position, style));
        }
        public void DisplayDocument()
        {
            foreach (var character in _document)
            {
                character.Display();
                Console.WriteLine("-----");
            }
        }
    }

    // Client Usage
    //Testing the Flyweight Design Pattern 
    public class Program
    {
        public static void Main()
        {
            var editor = new TextEditor();
            editor.InsertCharacter('A', 0, "Arial", 12, true, false);
            editor.InsertCharacter('B', 1, "Arial", 12, true, false);
            editor.InsertCharacter('C', 2, "Times New Roman", 14, false, true);
            editor.DisplayDocument();
            Console.ReadKey();
        }
    }
}
