using System;
using System.Linq;
using System.Text;

namespace MacroKeyboardConfig
{
	public class TextMacro : ProgrammableMacro
	{
		// UTF-8 string
		public byte[] Text { get; set; }
		public static readonly int TEXT_LEN = 265;
		private int Index;

        public TextMacro(int index)
        {
			Index = index;
			Text = new byte[TEXT_LEN];
        }

        public TextMacro(byte[] text, int index)
        {
			Index = index;
			if (text.Length > TEXT_LEN)
			{
				Text = new ArraySegment<byte>(text, 0, TEXT_LEN).ToArray();
				return;
			}

			Text = text;
        }

		public void SetText(string text)
		{
			Text = Encoding.UTF8.GetBytes(text);
		}

		public string GetText()
		{
			return Encoding.UTF8.GetString(Text);
		}

		MacroType ProgrammableMacro.GetType()
		{
			return MacroType.TEXT;
		}

		int ProgrammableMacro.GetIndex()
		{
			return Index;
		}
	}
}
