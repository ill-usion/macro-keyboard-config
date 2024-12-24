using System;
using System.Collections.Generic;
using System.Linq;

namespace MacroKeyboardConfig
{
	public enum SequenceActionType : byte
	{
		RELEASE_ALL = 0x00,
		KEYSTROKE = 0x01,
		CONSUMER_KEYSTROKE = 0x02,
		CHARACTER_KEYSTROKE = 0x03,
		DELAY = 0x04
	}

	public struct SequenceAction
	{
		public SequenceActionType Type;
		private ushort _value;

		public ushort Delay
		{
			get => _value;
			set
			{
				_value = value;
			}
		}

		public ushort Keycode
		{
			get => _value;
			set
			{
				_value = value;
			}
		}
	}

	public class KeyMacro : ProgrammableMacro
	{
		public static readonly int SEQ_LEN = 16;
		public List<SequenceAction> SequenceActions { get; }
		private int Index;

        public KeyMacro(int index)
        {
			Index = index;
            SequenceActions = new List<SequenceAction>();
        }

        public KeyMacro(SequenceAction[] sequenceActions, int index)
        {
			if (sequenceActions.Length > SEQ_LEN)
				throw new ArgumentException("sequenceActions length should not be greater than " + SEQ_LEN.ToString());

			Index = index;
			SequenceActions = sequenceActions.ToList();
		}

		public void addAction(SequenceAction action)
		{
			if (SequenceActions.Count >= SEQ_LEN)
				throw new Exception("SequenceActions is full");
			
			SequenceActions.Add(action);
		}

		public void removeAction(int index)
		{
			SequenceActions.RemoveAt(index);
		}

        MacroType ProgrammableMacro.GetType()
		{
			return MacroType.KEY;
		}

		int ProgrammableMacro.GetIndex() { return Index; }
	}
}
