using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;

namespace MacroKeyboardConfig
{
	public partial class Form1 : Form
	{
		public MacroKeyboard keyboard;
		public ProgrammableMacro currentMacro;

		public KeyMacro draftKeyMacro;
		public TextMacro draftTextMacro;

		public bool isTreeToggled = false;
		public int selectedSequenceIndex = -1;
		public Button lastSelectedButton = null;

		public Form1()
		{
			InitializeComponent();

			DisableButtons();
			DisableMacroTypeSelection();

			InitKeyMacroDetails();
		}

		private void InitKeyMacroDetails()
		{
			foreach (string action in Enum.GetNames(typeof(SequenceActionType)))
			{
				actionSelect.Items.Add(action);
			}
		}

		private void EnableButtons()
		{
			toggleTreeButton.Enabled = true;
			resetKeyboardButton.Enabled = true;
			resetMacroButton.Enabled = true;
			applyConfigButton.Enabled = true;

			button7.Enabled = true;
			button8.Enabled = true;
			button9.Enabled = true;
			button10.Enabled = true;
			button11.Enabled = true;
			button12.Enabled = true;
		}

		private void DisableButtons()
		{
			toggleTreeButton.Enabled = false;
			resetKeyboardButton.Enabled = false;
			resetMacroButton.Enabled = false;
			applyConfigButton.Enabled = false;

			button7.Enabled = false;
			button8.Enabled = false;
			button9.Enabled = false;
			button10.Enabled = false;
			button11.Enabled = false;
			button12.Enabled = false;
		}

		private void EnableMacroTypeSelection()
		{
			keyMacroRButton.Enabled = true;
			textMacroRButton.Enabled = true;
		}

		private void DisableMacroTypeSelection()
		{
			keyMacroRButton.Enabled = false;
			textMacroRButton.Enabled = false;
		}

		private void ResetInputs(bool disablePanels = true)
		{
			textMacroTextbox.Text = string.Empty;
			delayTextBox.Text = string.Empty;

			actionSelect.Text = string.Empty;

			keySelect.Text = string.Empty;
			keySelect.Items.Clear();

			if(disablePanels )
			{
				keyMacroDetailsPanel.Enabled = false;
				textMacroDetailsPanel.Enabled = false;
			}
		}

		private void UpdateInputs(MacroType macroType, object args)
		{
			if (macroType == MacroType.TEXT)
			{
				string text = args as string;
				textMacroTextbox.Text = text;

				return;
			}

			SequenceAction sequenceAction = (SequenceAction)args;

			actionSelect.ResetText();
			actionSelect.SelectedText = sequenceAction.Type.ToString();
			actionSelect_SelectedIndexChanged(null, null);

			switch (sequenceAction.Type)
			{
				case SequenceActionType.KEYSTROKE:
					keySelect.SelectedText = ((Keycodes)sequenceAction.Keycode).ToString();
					break;

				case SequenceActionType.CONSUMER_KEYSTROKE:
					keySelect.SelectedText = ((ConsumerKeycodes)sequenceAction.Keycode).ToString();
					break;

				case SequenceActionType.DELAY:
					delayTextBox.Text = sequenceAction.Delay.ToString();
					break;

				default:
					break;
			}
		}

		private void ListPorts()
		{
			portsSelect.Items.Clear();

			string[] availablePorts = SerialPort.GetPortNames();
			if (availablePorts.Length == 0)
			{
				portsSelect.Enabled = false;
				return;
			}

			portsSelect.Enabled = true;
			availablePorts.ToList().ForEach(port => { portsSelect.Items.Add(port); });
		}

		private void SelectPort()
		{
			if (portsSelect.SelectedItem == null)
				return;

			string portName = portsSelect.SelectedItem.ToString();

			try
			{
				keyboard?.CloseConnection();

				keyboard = new MacroKeyboard(portName);
				portNameLabel.Text = $"Connected to keyboard on {portName}";
				MessageBox.Show($"Connected to {portName} successfully");

				EnableButtons();
			}
			catch (UnauthorizedAccessException e)
			{
				portNameLabel.Text = "Not connected";
				MessageBox.Show("Error connecting to keyboard. " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				DisableButtons();
			}
		}

		private void SelectMacro(int macroIndex, object sender)
		{
			if (keyboard == null)
				return;

			ProgrammableMacro macro = keyboard.GetMacro(macroIndex);

			if (sender != null)
			{
				if (lastSelectedButton != null)
				{
					lastSelectedButton.BackColor = Color.White;
				}

				Button selectedButton = (Button)sender;
				selectedButton.BackColor = Color.Lime;

				lastSelectedButton = selectedButton;
			}

			if (macro == null)
			{
				currentMacro = new KeyMacro(macroIndex);
			}
			else
			{
				currentMacro = macro;
			}

			if (currentMacro.GetType() == MacroType.KEY)
			{
				draftKeyMacro = currentMacro as KeyMacro;
				draftTextMacro = new TextMacro(macroIndex);
			}
			else
			{
				draftKeyMacro = new KeyMacro(macroIndex);
				draftTextMacro = currentMacro as TextMacro;
			}

			ResetInputs();

			keyMacroDetailsPanel.Enabled = keyMacroRButton.Checked = (currentMacro.GetType() == MacroType.KEY);
			textMacroDetailsPanel.Enabled = textMacroRButton.Checked = (currentMacro.GetType() == MacroType.TEXT);
			EnableMacroTypeSelection();
			textMacroRButton_CheckedChanged(null, null);
		}

		private void DisplayMacroTree(ProgrammableMacro macro)
		{
			ResetMacroTree();

			if (macro == null)
				return;

			macroTree.BeginUpdate();

			if (macro.GetType() == MacroType.KEY)
			{
				KeyMacro keyMacro = macro as KeyMacro;

				for (int i = 0; i < keyMacro.SequenceActions.Count; i++)
				{
					SequenceAction action = keyMacro.SequenceActions[i];
					string label = $"{action.Type}";
					TreeNode node = macroTree.Nodes.Add(label);

					switch (action.Type)
					{
						case SequenceActionType.KEYSTROKE:
							node.Nodes.Add($"Name: {(Keycodes)action.Keycode}");
							node.Nodes.Add($"Keycode: {action.Keycode}");
							break;

						case SequenceActionType.CONSUMER_KEYSTROKE:
							node.Nodes.Add($"Name: {(ConsumerKeycodes)action.Keycode}");
							node.Nodes.Add($"Keycode: {action.Keycode}");
							break;

						case SequenceActionType.DELAY:
							node.Nodes.Add($"{action.Delay}ms");
							break;

						default:
							break;
					}
				}
			}
			else
			{
				TextMacro textMacro = macro as TextMacro;
				string label = $"TEXT";

				TreeNode node = macroTree.Nodes.Add(label);
				string text = textMacro.GetText();
				node.Nodes.Add(text);
			}

			macroTree.EndUpdate();
		}

		private void ResetExpandTreeButton()
		{
			isTreeToggled = false;
			toggleTreeButton.Text = "Expand All";
		}

		private void ResetMacroTree()
		{
			macroTree.Nodes.Clear();
			ResetExpandTreeButton();
		}

		private void SendArbitraryData()
		{
			KeyMacro stepIntoMacro = new KeyMacro(0);
			stepIntoMacro.addAction(new SequenceAction { Type = SequenceActionType.KEYSTROKE, Keycode = (ushort)Keycodes.F11 });
			stepIntoMacro.addAction(new SequenceAction { Type = SequenceActionType.DELAY, Delay = 100 });
			stepIntoMacro.addAction(new SequenceAction { Type = SequenceActionType.RELEASE_ALL });
			DisableButtons();
			keyboard.SetMacro(stepIntoMacro);
			EnableButtons();

			KeyMacro stepOverMacro = new KeyMacro(1);
			stepOverMacro.addAction(new SequenceAction { Type = SequenceActionType.KEYSTROKE, Keycode = (ushort)Keycodes.F10 });
			stepOverMacro.addAction(new SequenceAction { Type = SequenceActionType.DELAY, Delay = 100 });
			stepOverMacro.addAction(new SequenceAction { Type = SequenceActionType.RELEASE_ALL });
			DisableButtons();
			keyboard.SetMacro(stepOverMacro);
			EnableButtons();

			KeyMacro stepOutMacro = new KeyMacro(2);
			stepOutMacro.addAction(new SequenceAction { Type = SequenceActionType.KEYSTROKE, Keycode = (ushort)Keycodes.LEFT_SHIFT });
			stepOutMacro.addAction(new SequenceAction { Type = SequenceActionType.DELAY, Delay = 10 });
			stepOutMacro.addAction(new SequenceAction { Type = SequenceActionType.KEYSTROKE, Keycode = (ushort)Keycodes.F11 });
			stepOutMacro.addAction(new SequenceAction { Type = SequenceActionType.DELAY, Delay = 100 });
			stepOutMacro.addAction(new SequenceAction { Type = SequenceActionType.RELEASE_ALL });
			DisableButtons();
			keyboard.SetMacro(stepOutMacro);
			EnableButtons();


			KeyMacro mediaPrevMacro = new KeyMacro(3);
			mediaPrevMacro.addAction(new SequenceAction { Type = SequenceActionType.CONSUMER_KEYSTROKE, Keycode = (ushort)ConsumerKeycodes.MEDIA_PREV });
			mediaPrevMacro.addAction(new SequenceAction { Type = SequenceActionType.DELAY, Delay = 100 });
			mediaPrevMacro.addAction(new SequenceAction { Type = SequenceActionType.RELEASE_ALL });
			DisableButtons();
			keyboard.SetMacro(mediaPrevMacro);
			EnableButtons();

			KeyMacro playPauseMacro = new KeyMacro(4);
			playPauseMacro.addAction(new SequenceAction { Type = SequenceActionType.CONSUMER_KEYSTROKE, Keycode = (ushort)ConsumerKeycodes.MEDIA_PLAY_PAUSE });
			playPauseMacro.addAction(new SequenceAction { Type = SequenceActionType.DELAY, Delay = 100 });
			playPauseMacro.addAction(new SequenceAction { Type = SequenceActionType.RELEASE_ALL });
			DisableButtons();
			keyboard.SetMacro(playPauseMacro);
			EnableButtons();

			KeyMacro mediaNextMacro = new KeyMacro(5);
			mediaNextMacro.addAction(new SequenceAction { Type = SequenceActionType.CONSUMER_KEYSTROKE, Keycode = (ushort)ConsumerKeycodes.MEDIA_NEXT });
			mediaNextMacro.addAction(new SequenceAction { Type = SequenceActionType.DELAY, Delay = 100 });
			mediaNextMacro.addAction(new SequenceAction { Type = SequenceActionType.RELEASE_ALL });
			DisableButtons();
			keyboard.SetMacro(mediaNextMacro);
			EnableButtons();

			TextMacro tm = new TextMacro(0);
			tm.SetText("Hello, World!");
			// MessageBox.Show(keyboard.SetMacro(tm));
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			ListPorts();
		}

		private void listPortsButton_Click(object sender, EventArgs e)
		{
			ListPorts();
		}

		private void selectButton_Click(object sender, EventArgs e)
		{
			SelectPort();
		}


		private void toggleTreeButton_Click(object sender, EventArgs e)
		{
			if (isTreeToggled)
			{
				macroTree.CollapseAll();
				toggleTreeButton.Text = "Expand All";
			}
			else
			{
				macroTree.ExpandAll();
				toggleTreeButton.Text = "Collapse All";
			}

			isTreeToggled = !isTreeToggled;
		}

		private void testButton_Click(object sender, EventArgs e)
		{
			SendArbitraryData();
		}

		private void resetMacroButton_Click(object sender, EventArgs e)
		{
			if (keyboard == null || currentMacro == null)
				return;

			DialogResult result = MessageBox.Show("Are you sure you want to reset this macro?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
			if (result != DialogResult.OK)
				return;

			DisableButtons();
			int macroIndex = currentMacro.GetIndex();
			MessageBox.Show(keyboard.ResetMacro(macroIndex));
			EnableButtons();

			ResetMacroTree();
		}

		private void resetKeyboardButton_Click(object sender, EventArgs e)
		{
			if (keyboard == null)
				return;

			DialogResult result = MessageBox.Show("Are you sure you want to reset the keyboard? This will erase all saved macros.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (result != DialogResult.Yes)
				return;

			DisableButtons();
			keyboard.Reset();
			EnableButtons();

			ResetMacroTree();

			MessageBox.Show("Keyboard reset successfully");
		}

		private void macroTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			// Only handle parent nodes
			if (e.Node.Parent != null || currentMacro == null)
				return;

			MacroType currentMacroType = currentMacro.GetType();
			if (currentMacroType == MacroType.KEY)
			{
				KeyMacro keyMacro = currentMacro as KeyMacro;
				selectedSequenceIndex = e.Node.Index;

				SequenceAction action = keyMacro.SequenceActions[selectedSequenceIndex];
				UpdateInputs(currentMacroType, action);
			}
			else
			{
				if (e.Node.Text != "TEXT")
					return;

				TextMacro textMacro = currentMacro as TextMacro;
				UpdateInputs(currentMacroType, textMacro.GetText());

				keyMacroDetailsPanel.Visible = true;
				textMacroDetailsPanel.Visible = true;
			}
		}

		private void actionSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (selectedSequenceIndex == -1) return;

			keySelect.Items.Clear();
			keySelect.Text = string.Empty;

			SequenceActionType selectedAction = (SequenceActionType)Enum.Parse(typeof(SequenceActionType), actionSelect.Text);
			switch (selectedAction)
			{
				case SequenceActionType.KEYSTROKE:
					keySelect.Enabled = true;
					delayTextBox.Enabled = false;
					foreach (string key in Enum.GetNames(typeof(Keycodes)))
					{
						keySelect.Items.Add(key);
					}
					delayTextBox.Text = string.Empty;
					break;

				case SequenceActionType.CONSUMER_KEYSTROKE:
					keySelect.Enabled = true;
					delayTextBox.Enabled = false;
					foreach (string key in Enum.GetNames(typeof(ConsumerKeycodes)))
					{
						keySelect.Items.Add(key);
					}
					delayTextBox.Text = string.Empty;
					break;

				case SequenceActionType.DELAY:
					keySelect.Enabled = false;
					delayTextBox.Enabled = true;
					break;

				default:
					keySelect.Enabled = false;
					delayTextBox.Enabled = false;
					delayTextBox.Text = string.Empty;
					break;
			}

			// code-triggered event
			if (sender == null)
				return;

			SequenceAction newSequenceAction = new SequenceAction();
			newSequenceAction.Type = selectedAction;
			if (currentMacro.GetType() != MacroType.KEY)
				return;

			KeyMacro keyMacro = (KeyMacro)currentMacro;
			keyMacro.SequenceActions[selectedSequenceIndex] = newSequenceAction;
			currentMacro = keyMacro;
			DisplayMacroTree(currentMacro);
		}

		private void textMacroRButton_CheckedChanged(object sender, EventArgs e)
		{
			bool isTextMacro = textMacroRButton.Checked;
			keyMacroDetailsPanel.Enabled = !isTextMacro;
			textMacroDetailsPanel.Enabled = isTextMacro;

			if (currentMacro == null)
				return;

			if (isTextMacro)
			{
				if (currentMacro.GetType() == MacroType.KEY)
				{
					draftKeyMacro = (KeyMacro)currentMacro;
				}

				currentMacro = draftTextMacro;
			}
			else
			{
				if (currentMacro.GetType() == MacroType.TEXT)
				{
					draftTextMacro = (TextMacro)currentMacro;
				}

				currentMacro = draftKeyMacro;
			}

			DisplayMacroTree(currentMacro);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			SelectMacro(0, sender);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			SelectMacro(1, sender);
		}

		private void button9_Click(object sender, EventArgs e)
		{
			SelectMacro(2, sender);
		}

		private void button10_Click(object sender, EventArgs e)
		{
			SelectMacro(3, sender);
		}

		private void button11_Click(object sender, EventArgs e)
		{
			SelectMacro(4, sender);
		}

		private void button12_Click(object sender, EventArgs e)
		{
			SelectMacro(5, sender);
		}

		private void applyConfigButton_Click(object sender, EventArgs e)
		{
			if (keyboard == null || currentMacro == null)
			{
				MessageBox.Show("Select a macro first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DisableButtons();
			currentMacro = keyboard.SetMacro(currentMacro);
			EnableButtons();

			DisplayMacroTree(currentMacro);
		}

		private void keySelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (selectedSequenceIndex == -1)
				return;

			KeyMacro keyMacro = (KeyMacro)currentMacro;
			SequenceAction selectedSequence = keyMacro.SequenceActions[selectedSequenceIndex];

			string selectedText = (string)keySelect.Items[keySelect.SelectedIndex];
			if (selectedSequence.Type == SequenceActionType.KEYSTROKE)
			{
				selectedSequence.Keycode = (ushort)(Keycodes)Enum.Parse(typeof(Keycodes), selectedText);
			}
			else if (selectedSequence.Type == SequenceActionType.CONSUMER_KEYSTROKE)
			{
				selectedSequence.Keycode = (ushort)(ConsumerKeycodes)Enum.Parse(typeof(ConsumerKeycodes), selectedText);
			}

			keyMacro.SequenceActions[selectedSequenceIndex] = selectedSequence;
			currentMacro = keyMacro;

			DisplayMacroTree(currentMacro);
		}

		private void delayTextBox_TextChanged(object sender, EventArgs e)
		{
			if (selectedSequenceIndex == -1)
				return;

			if (string.IsNullOrWhiteSpace(delayTextBox.Text))
				delayTextBox.Text = 0.ToString();

			if (!(currentMacro is KeyMacro keyMacro))
				return;

			SequenceAction selectedSequence = keyMacro.SequenceActions[selectedSequenceIndex];
			if (selectedSequence.Type != SequenceActionType.DELAY)
				return;

			if (!ushort.TryParse(delayTextBox.Text, out ushort newValue))
			{
				delayTextBox.Text = selectedSequence.Delay.ToString();
				return;
			}

			selectedSequence.Delay = newValue;
			keyMacro.SequenceActions[selectedSequenceIndex] = selectedSequence;
			currentMacro = keyMacro;

			DisplayMacroTree(currentMacro);
		}

		private void newActionButton_Click(object sender, EventArgs e)
		{
			if (currentMacro == null || currentMacro.GetType() != MacroType.KEY)
				return;

			KeyMacro keyMacro = (KeyMacro)currentMacro;
			if (keyMacro.SequenceActions.Count >= KeyMacro.SEQ_LEN)
				return;

			SequenceAction newSequenceAction = new SequenceAction { Type = SequenceActionType.RELEASE_ALL };
			keyMacro.SequenceActions.Add(newSequenceAction);
			currentMacro = keyMacro;

			DisplayMacroTree(currentMacro);
		}

		private void clearTextButton_Click(object sender, EventArgs e)
		{
			textMacroTextbox.Text = string.Empty;
			textMacroTextbox.Focus();
		}

		private void textMacroTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!(currentMacro is TextMacro textMacro))
				return;

			textMacro.SetText(textMacroTextbox.Text);
		}

		private void deleteCurActButton_Click(object sender, EventArgs e)
		{
			if (!(currentMacro is KeyMacro keyMacro) || selectedSequenceIndex == -1 || (keyMacro.SequenceActions.Count - 1) < selectedSequenceIndex)
				return;

			keyMacro.removeAction(selectedSequenceIndex);
			DisplayMacroTree(currentMacro);
			selectedSequenceIndex = -1;
			ResetInputs(false);
		}
	}
}
