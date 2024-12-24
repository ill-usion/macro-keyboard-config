using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroKeyboardConfig
{
	public struct VirtualButton
	{
		public ushort Keycode;
		public ushort ModifiedKeycode;
		public string Label;
		public string ModifiedLabel;
		public float Width;
	}
}
