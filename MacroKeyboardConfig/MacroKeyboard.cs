using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using Newtonsoft.Json;
using System.Threading;

namespace MacroKeyboardConfig
{
	public class MacroKeyboard
	{
		public SerialPort Port { get; }
		private readonly int PORT_BAUD_RATE = 115200;
		private readonly int PORT_READ_TIMEOUT_MS = 2000;
		private readonly int PORT_WRITE_TIMEOUT_MS = 2000;
		private readonly int SLEEP_BEFORE_READ_TIME_MS = 1000;

		public MacroKeyboard(string portName)
		{
			if (portName == null)
				throw new ArgumentNullException("portName must not be null");

			Port = new SerialPort()
			{
				PortName = portName,
				BaudRate = PORT_BAUD_RATE,
				DtrEnable = true,
				RtsEnable = true,
				Handshake = Handshake.None,
				ReadTimeout = PORT_READ_TIMEOUT_MS,
				WriteTimeout = PORT_WRITE_TIMEOUT_MS
			};

			Port.Open();
		}

		public void CloseConnection()
		{
			Port.Close();
		}

		public List<ProgrammableMacro> GetMacrosList()
		{
			KeyboardEvent keyboardEvent = new KeyboardEvent(KeyboardEventType.READ, null);
			SendEvent(keyboardEvent);

			string response = Port.ReadLine();

			return ParseMacroListResponse(response);
		}

		public ProgrammableMacro GetMacro(int macroIndex)
		{
			KeyboardEvent keyboardEvent = new KeyboardEvent(KeyboardEventType.READ, macroIndex);
			SendEvent(keyboardEvent);

			string response = Port.ReadLine();
			return ParseMacroResponse(response);
		}

		public ProgrammableMacro SetMacro(ProgrammableMacro macro)
		{
			KeyboardEvent keyboardEvent = new KeyboardEvent(KeyboardEventType.WRITE, macro);
			SendEvent(keyboardEvent);
			
			Thread.Sleep(SLEEP_BEFORE_READ_TIME_MS);
			string response = Port.ReadLine();

			return ParseMacroResponse(response);
		}

		public string ResetMacro(int macroIndex)
		{
			KeyboardEvent keyboardEvent = new KeyboardEvent(KeyboardEventType.CLEAR, macroIndex);
			SendEvent(keyboardEvent);
			
			Thread.Sleep(SLEEP_BEFORE_READ_TIME_MS);
			return Port.ReadLine();
		}

		public void Reset()
		{
			KeyboardEvent keyboardEvent = new KeyboardEvent(KeyboardEventType.RESET, null);
			SendEvent(keyboardEvent);
		}

		private ProgrammableMacro ParseMacroResponse(string response)
		{
			dynamic parsed = JsonConvert.DeserializeObject<dynamic>(response);

			if (parsed == null || parsed["type"] == null)
			{
				return null;
			}

			int macroIndex = (int)parsed["index"];
			switch ((MacroType)parsed["type"])
			{
				case MacroType.KEY:
					{
						KeyMacro keyMacro = new KeyMacro(macroIndex);
						foreach (dynamic macroData in parsed["data"])
						{
							SequenceAction action = new SequenceAction
							{
								Type = (SequenceActionType)macroData["sType"]
							};

							switch (action.Type)
							{
								case SequenceActionType.KEYSTROKE:
								case SequenceActionType.CONSUMER_KEYSTROKE:
									action.Keycode = (ushort)macroData["keycode"];
									break;

								case SequenceActionType.DELAY:
									action.Delay = (ushort)macroData["delay"];
									break;

								default:
									break;
							}

							keyMacro.addAction(action);
						}

						return keyMacro;
					}
				case MacroType.TEXT:
					{
						string macroText = (string)parsed["data"];
						byte[] textBytes = Encoding.UTF8.GetBytes(macroText);

						TextMacro textMacro = new TextMacro(textBytes, macroIndex);
						return textMacro;
					}
			}

			return null;
		}

		private List<ProgrammableMacro> ParseMacroListResponse(string response)
		{
			dynamic parsed = JsonConvert.DeserializeObject<dynamic>(response);
			List<ProgrammableMacro> macros = new List<ProgrammableMacro>();
			
			int index = 0;
			foreach (dynamic macro in parsed)
			{
				if (macro["type"] == null)
				{
					macros.Add(null);
					continue;
				}

				switch ((MacroType)macro["type"])
				{
					case MacroType.KEY:
						{
							KeyMacro keyMacro = new KeyMacro(index);
							foreach (dynamic macroData in macro["data"])
							{
								SequenceAction action = new SequenceAction();
								action.Type = (SequenceActionType)macroData["sType"];
								switch (action.Type)
								{
									case SequenceActionType.KEYSTROKE:
									case SequenceActionType.CONSUMER_KEYSTROKE:
										action.Keycode = (ushort)macroData["keycode"];
										break;

									case SequenceActionType.DELAY:
										action.Delay = (ushort)macroData["delay"];
										break;

									default:
										break;
								}

								keyMacro.addAction(action);
							}

							macros.Add(keyMacro);
							break;
						}

					case MacroType.TEXT:
						{
							string macroText = (string) macro["data"];
							byte[] textBytes = Encoding.UTF8.GetBytes(macroText);
							
							TextMacro textMacro = new TextMacro(textBytes, index);
							macros.Add(textMacro);
							
							break;
						}
				}

				index++;
			}

			return macros;
		}

		private void SendEvent(KeyboardEvent keyboardEvent, bool flush = true)
		{
			if (Port == null || !Port.IsOpen)
				throw new InvalidOperationException("Port " + Port.PortName + " is not open");

			byte[] bytePayload = keyboardEvent.ToBytes();
			Port.Write(bytePayload, 0, bytePayload.Length);
			
			if(flush)
				Port.BaseStream.Flush();
		}
	}
}
