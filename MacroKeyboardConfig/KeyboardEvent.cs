using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace MacroKeyboardConfig
{
	public enum KeyboardEventType
	{
		READ = 'r',
		WRITE = 'w',
		RESET = 'x',
		CLEAR = 'c'
	}

	public class KeyboardEvent
	{
		public KeyboardEventType EventType;
		public object EventArgs;

		public KeyboardEvent(KeyboardEventType eventType, object eventArgs)
		{
			EventType = eventType;
			EventArgs = eventArgs;
		}

		public byte[] ToBytes()
		{
			return Encoding.UTF8.GetBytes(ToString());
		}

		public override string ToString()
		{
			var kv = new Dictionary<string, dynamic>();
			kv["event"] = ((char)EventType).ToString();

			switch (EventType)
			{
				case KeyboardEventType.READ:
					kv["index"] = EventArgs.ToString();
					break;

				case KeyboardEventType.WRITE:
					var parsedKv = ParseWriteEventArgs();
					foreach (var kvp in parsedKv)
						kv.Add(kvp.Key, kvp.Value);
					break;

				case KeyboardEventType.CLEAR:
					kv["index"] = EventArgs.ToString();
					break;

				default:
					break;
			}

			return JsonConvert.SerializeObject(kv);
		}

		private Dictionary<string, dynamic> ParseWriteEventArgs()
		{
			Dictionary<string, dynamic> obj = new Dictionary<string, dynamic>();

			ProgrammableMacro macro = (ProgrammableMacro)EventArgs;
			obj["type"] = (int)macro.GetType();
			obj["index"] = macro.GetIndex();

			switch (macro.GetType())
			{
				case MacroType.KEY:
					KeyMacro keyMacro = macro as KeyMacro;
					obj["data"] = new List<Dictionary<string, dynamic>>();

					int index = 0;
					foreach (SequenceAction seq in keyMacro.SequenceActions)
					{
						obj["data"].Add(new Dictionary<string, dynamic>());
						obj["data"][index]["sType"] = (int)seq.Type;

						switch (seq.Type)
						{
							case SequenceActionType.KEYSTROKE:
							case SequenceActionType.CONSUMER_KEYSTROKE:
								obj["data"][index]["keycode"] = seq.Keycode;
								break;

							case SequenceActionType.DELAY:
								obj["data"][index]["delay"] = seq.Delay;
								break;

							default:
								break;
						}

						index++;
					}
					break;

				case MacroType.TEXT:
					{
						TextMacro textMacro = macro as TextMacro;
						obj["data"] = Encoding.UTF8.GetString(textMacro.Text);
						break;
					}
			}

			return obj;
		}
	}
}
