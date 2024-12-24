using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroKeyboardConfig
{
	public class VirtualKeyboardForm : Form
	{
		private Button button1;
		private Button button2;
		private Button button3;
		private Button button4;
		private Button button5;
		private Button button6;
		private Button button7;
		private Button button8;
		private Button button9;
		private Button button10;
		private Button button11;
		private Button button12;
		private Button button13;
		private Button button14;
		private Button button15;
		private Button button16;
		private Button button17;
		private Button button18;
		private Button button19;
		private Button button20;
		private Button button21;
		private Button button22;
		private Button button23;
		private Button button24;
		private Button button25;
		private Button button26;
		private Button button27;
		private Button button28;
		private Button button29;
		private Button button30;
		private Button button31;
		private Button button32;
		private Button button33;
		private Button button34;
		private Button button35;
		private Button button36;
		private Button button37;
		private Button button38;
		private Button button39;
		private Button button40;
		private Button button41;
		private Button button42;
		private Button button43;
		private Button button44;
		private Button button45;
		private Button button46;
		private Button button47;
		private Button button48;
		private Button button49;
		private Button button50;
		private Button button51;
		private Button button52;
		private Button button53;
		private Button button54;
		private Button button55;
		private Button button56;
		private Button button57;
		private Button button58;
		private Button button59;
		private Button button60;
		private Button button61;
		private ComboBox additionalKeysBox;
		private Button selectButton;
		private Button button62;
		private Button button63;
		private Button button64;
		private Button button65;
		private Button button66;
		private Button button67;
		private Button button68;
		private Button button69;
		private Button button70;
		private Button button71;
		private Button button72;
		private Button button73;
		private Button button74;
		private Button button75;
		private Button button76;
		private Button button77;
		private Button button79;
		private Button button78;
		private Button button80;
		private Button button82;
		private Button button81;
		private Button button84;
		private Button button83;
		private Button button85;

		private Button[] modifiableButtons;
		private Button modifyKeysButton;
		private List<(char, char)> modifiableLabels;
		private bool isModifyingKeys = false;
		private ushort selectedKeycode;
		private SequenceActionType sequenceActionType;

		public VirtualKeyboardForm()
		{
			InitializeComponent();

			modifiableButtons = new Button[] { button1, button2, button3, button4, button5, button6,
												button7, button8, button9, button10, button11, button12,
												button13, button14, button15, button16, button17, button18,
												button19, button20, button21, button22, button23, button24,
												button25, button26, button27, button28, button29, button30,
												button31, button32, button33, button34, button35, button36,
												button37, button38, button39, button40, button41, button42,
												button43, button44, button45, button46, button47, button48,
												button49, button50, button51, button52, button53, button54,
												button55, button56, button57, button58, button59, button60,
												button61, button62, button63, button64, button65, button66,
												button67, button68, button69, button70, button71, button72,
												button73, button74, button75, button76, button77, button79,
												button78, button80, button82, button81, button84, button83,
												button85 };


			modifiableLabels = new List<(char, char)>();
			foreach (Button button in modifiableButtons)
			{
				button.Click += handleButtonSelect;
				string label = button.Text;

				char c = '\0';
				char modifiedC = '\0';

				// alphabet
				if (label.Length == 1)
				{
					c = label[0];
					modifiedC = char.ToUpper(label[0]);
				}
				else if (label.Contains('/'))
				{
					int separatorIdx = label.IndexOf('/');
					if (separatorIdx == -1)
						continue;

					c = label[0];
					modifiedC = label[2];
				}

				modifiableLabels.Add((c, modifiedC));

				if (c != '\0' && modifiedC != '\0')
				{
					button.Text = c.ToString();
				}
			}

		}

		private void InitializeComponent()
		{
			System.Windows.Forms.Label addKeysLabel;
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.button16 = new System.Windows.Forms.Button();
			this.button17 = new System.Windows.Forms.Button();
			this.button18 = new System.Windows.Forms.Button();
			this.button19 = new System.Windows.Forms.Button();
			this.button20 = new System.Windows.Forms.Button();
			this.button21 = new System.Windows.Forms.Button();
			this.button22 = new System.Windows.Forms.Button();
			this.button23 = new System.Windows.Forms.Button();
			this.button24 = new System.Windows.Forms.Button();
			this.button25 = new System.Windows.Forms.Button();
			this.button26 = new System.Windows.Forms.Button();
			this.button27 = new System.Windows.Forms.Button();
			this.button28 = new System.Windows.Forms.Button();
			this.button29 = new System.Windows.Forms.Button();
			this.button30 = new System.Windows.Forms.Button();
			this.button31 = new System.Windows.Forms.Button();
			this.button32 = new System.Windows.Forms.Button();
			this.button33 = new System.Windows.Forms.Button();
			this.button34 = new System.Windows.Forms.Button();
			this.button35 = new System.Windows.Forms.Button();
			this.button36 = new System.Windows.Forms.Button();
			this.button37 = new System.Windows.Forms.Button();
			this.button38 = new System.Windows.Forms.Button();
			this.button39 = new System.Windows.Forms.Button();
			this.button40 = new System.Windows.Forms.Button();
			this.button41 = new System.Windows.Forms.Button();
			this.button42 = new System.Windows.Forms.Button();
			this.button43 = new System.Windows.Forms.Button();
			this.button44 = new System.Windows.Forms.Button();
			this.button45 = new System.Windows.Forms.Button();
			this.button46 = new System.Windows.Forms.Button();
			this.button47 = new System.Windows.Forms.Button();
			this.button48 = new System.Windows.Forms.Button();
			this.button49 = new System.Windows.Forms.Button();
			this.button50 = new System.Windows.Forms.Button();
			this.button51 = new System.Windows.Forms.Button();
			this.button52 = new System.Windows.Forms.Button();
			this.button53 = new System.Windows.Forms.Button();
			this.button54 = new System.Windows.Forms.Button();
			this.button55 = new System.Windows.Forms.Button();
			this.button56 = new System.Windows.Forms.Button();
			this.button57 = new System.Windows.Forms.Button();
			this.button58 = new System.Windows.Forms.Button();
			this.button59 = new System.Windows.Forms.Button();
			this.button60 = new System.Windows.Forms.Button();
			this.button61 = new System.Windows.Forms.Button();
			this.additionalKeysBox = new System.Windows.Forms.ComboBox();
			this.selectButton = new System.Windows.Forms.Button();
			this.modifyKeysButton = new System.Windows.Forms.Button();
			this.button62 = new System.Windows.Forms.Button();
			this.button63 = new System.Windows.Forms.Button();
			this.button64 = new System.Windows.Forms.Button();
			this.button65 = new System.Windows.Forms.Button();
			this.button66 = new System.Windows.Forms.Button();
			this.button67 = new System.Windows.Forms.Button();
			this.button68 = new System.Windows.Forms.Button();
			this.button69 = new System.Windows.Forms.Button();
			this.button70 = new System.Windows.Forms.Button();
			this.button71 = new System.Windows.Forms.Button();
			this.button72 = new System.Windows.Forms.Button();
			this.button73 = new System.Windows.Forms.Button();
			this.button74 = new System.Windows.Forms.Button();
			this.button75 = new System.Windows.Forms.Button();
			this.button76 = new System.Windows.Forms.Button();
			this.button77 = new System.Windows.Forms.Button();
			this.button79 = new System.Windows.Forms.Button();
			this.button78 = new System.Windows.Forms.Button();
			this.button80 = new System.Windows.Forms.Button();
			this.button82 = new System.Windows.Forms.Button();
			this.button81 = new System.Windows.Forms.Button();
			this.button84 = new System.Windows.Forms.Button();
			this.button83 = new System.Windows.Forms.Button();
			this.button85 = new System.Windows.Forms.Button();
			addKeysLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// addKeysLabel
			// 
			addKeysLabel.AutoSize = true;
			addKeysLabel.Location = new System.Drawing.Point(13, 380);
			addKeysLabel.Name = "addKeysLabel";
			addKeysLabel.Size = new System.Drawing.Size(79, 13);
			addKeysLabel.TabIndex = 61;
			addKeysLabel.Text = "Additional Keys";
			addKeysLabel.Visible = false;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(13, 114);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(45, 45);
			this.button1.TabIndex = 0;
			this.button1.Text = "`/~";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(64, 114);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(45, 45);
			this.button2.TabIndex = 1;
			this.button2.Text = "1/!";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.Location = new System.Drawing.Point(115, 114);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(45, 45);
			this.button3.TabIndex = 2;
			this.button3.Text = "2/@";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button4.Location = new System.Drawing.Point(166, 114);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(45, 45);
			this.button4.TabIndex = 3;
			this.button4.Text = "3/#";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button5.Location = new System.Drawing.Point(217, 114);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(45, 45);
			this.button5.TabIndex = 4;
			this.button5.Text = "4/$";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button6.Location = new System.Drawing.Point(268, 114);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(45, 45);
			this.button6.TabIndex = 5;
			this.button6.Text = "5/%";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// button7
			// 
			this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button7.Location = new System.Drawing.Point(319, 114);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(45, 45);
			this.button7.TabIndex = 6;
			this.button7.Text = "6/^";
			this.button7.UseVisualStyleBackColor = true;
			// 
			// button8
			// 
			this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button8.Location = new System.Drawing.Point(370, 114);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(45, 45);
			this.button8.TabIndex = 7;
			this.button8.Text = "7/&";
			this.button8.UseMnemonic = false;
			this.button8.UseVisualStyleBackColor = true;
			// 
			// button9
			// 
			this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button9.Location = new System.Drawing.Point(421, 114);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(45, 45);
			this.button9.TabIndex = 8;
			this.button9.Text = "8/*";
			this.button9.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button10.Location = new System.Drawing.Point(472, 114);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(45, 45);
			this.button10.TabIndex = 9;
			this.button10.Text = "9/(";
			this.button10.UseVisualStyleBackColor = true;
			// 
			// button11
			// 
			this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button11.Location = new System.Drawing.Point(523, 114);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(45, 45);
			this.button11.TabIndex = 10;
			this.button11.Text = "0/)";
			this.button11.UseVisualStyleBackColor = true;
			// 
			// button12
			// 
			this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button12.Location = new System.Drawing.Point(574, 114);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(45, 45);
			this.button12.TabIndex = 11;
			this.button12.Text = "-/_";
			this.button12.UseVisualStyleBackColor = true;
			// 
			// button13
			// 
			this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button13.Location = new System.Drawing.Point(625, 114);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(45, 45);
			this.button13.TabIndex = 12;
			this.button13.Text = "=/+";
			this.button13.UseVisualStyleBackColor = true;
			// 
			// button14
			// 
			this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button14.Location = new System.Drawing.Point(676, 114);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(90, 45);
			this.button14.TabIndex = 13;
			this.button14.Text = "Backspace";
			this.button14.UseVisualStyleBackColor = true;
			// 
			// button15
			// 
			this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button15.Location = new System.Drawing.Point(13, 165);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(67, 45);
			this.button15.TabIndex = 14;
			this.button15.Text = "Tab";
			this.button15.UseVisualStyleBackColor = true;
			// 
			// button16
			// 
			this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button16.Location = new System.Drawing.Point(86, 165);
			this.button16.Name = "button16";
			this.button16.Size = new System.Drawing.Size(45, 45);
			this.button16.TabIndex = 15;
			this.button16.Text = "q";
			this.button16.UseVisualStyleBackColor = true;
			// 
			// button17
			// 
			this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button17.Location = new System.Drawing.Point(137, 165);
			this.button17.Name = "button17";
			this.button17.Size = new System.Drawing.Size(45, 45);
			this.button17.TabIndex = 16;
			this.button17.Text = "w";
			this.button17.UseVisualStyleBackColor = true;
			// 
			// button18
			// 
			this.button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button18.Location = new System.Drawing.Point(188, 165);
			this.button18.Name = "button18";
			this.button18.Size = new System.Drawing.Size(45, 45);
			this.button18.TabIndex = 17;
			this.button18.Text = "e";
			this.button18.UseVisualStyleBackColor = true;
			// 
			// button19
			// 
			this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button19.Location = new System.Drawing.Point(239, 165);
			this.button19.Name = "button19";
			this.button19.Size = new System.Drawing.Size(45, 45);
			this.button19.TabIndex = 18;
			this.button19.Text = "r";
			this.button19.UseVisualStyleBackColor = true;
			// 
			// button20
			// 
			this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button20.Location = new System.Drawing.Point(290, 165);
			this.button20.Name = "button20";
			this.button20.Size = new System.Drawing.Size(45, 45);
			this.button20.TabIndex = 19;
			this.button20.Text = "t";
			this.button20.UseVisualStyleBackColor = true;
			// 
			// button21
			// 
			this.button21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button21.Location = new System.Drawing.Point(341, 165);
			this.button21.Name = "button21";
			this.button21.Size = new System.Drawing.Size(45, 45);
			this.button21.TabIndex = 20;
			this.button21.Text = "y";
			this.button21.UseVisualStyleBackColor = true;
			// 
			// button22
			// 
			this.button22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button22.Location = new System.Drawing.Point(392, 165);
			this.button22.Name = "button22";
			this.button22.Size = new System.Drawing.Size(45, 45);
			this.button22.TabIndex = 21;
			this.button22.Text = "u";
			this.button22.UseVisualStyleBackColor = true;
			// 
			// button23
			// 
			this.button23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button23.Location = new System.Drawing.Point(443, 165);
			this.button23.Name = "button23";
			this.button23.Size = new System.Drawing.Size(45, 45);
			this.button23.TabIndex = 22;
			this.button23.Text = "i";
			this.button23.UseVisualStyleBackColor = true;
			// 
			// button24
			// 
			this.button24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button24.Location = new System.Drawing.Point(494, 165);
			this.button24.Name = "button24";
			this.button24.Size = new System.Drawing.Size(45, 45);
			this.button24.TabIndex = 23;
			this.button24.Text = "o";
			this.button24.UseVisualStyleBackColor = true;
			// 
			// button25
			// 
			this.button25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button25.Location = new System.Drawing.Point(545, 165);
			this.button25.Name = "button25";
			this.button25.Size = new System.Drawing.Size(45, 45);
			this.button25.TabIndex = 24;
			this.button25.Text = "p";
			this.button25.UseVisualStyleBackColor = true;
			// 
			// button26
			// 
			this.button26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button26.Location = new System.Drawing.Point(596, 165);
			this.button26.Name = "button26";
			this.button26.Size = new System.Drawing.Size(45, 45);
			this.button26.TabIndex = 25;
			this.button26.Text = "[/{";
			this.button26.UseVisualStyleBackColor = true;
			// 
			// button27
			// 
			this.button27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button27.Location = new System.Drawing.Point(647, 165);
			this.button27.Name = "button27";
			this.button27.Size = new System.Drawing.Size(45, 45);
			this.button27.TabIndex = 26;
			this.button27.Text = "]/}";
			this.button27.UseVisualStyleBackColor = true;
			// 
			// button28
			// 
			this.button28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button28.Location = new System.Drawing.Point(698, 165);
			this.button28.Name = "button28";
			this.button28.Size = new System.Drawing.Size(68, 45);
			this.button28.TabIndex = 27;
			this.button28.Text = "\\/|";
			this.button28.UseVisualStyleBackColor = true;
			// 
			// button29
			// 
			this.button29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button29.Location = new System.Drawing.Point(13, 216);
			this.button29.Name = "button29";
			this.button29.Size = new System.Drawing.Size(79, 45);
			this.button29.TabIndex = 28;
			this.button29.Text = "Caps Lock";
			this.button29.UseVisualStyleBackColor = true;
			// 
			// button30
			// 
			this.button30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button30.Location = new System.Drawing.Point(98, 216);
			this.button30.Name = "button30";
			this.button30.Size = new System.Drawing.Size(45, 45);
			this.button30.TabIndex = 29;
			this.button30.Text = "a";
			this.button30.UseVisualStyleBackColor = true;
			// 
			// button31
			// 
			this.button31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button31.Location = new System.Drawing.Point(149, 216);
			this.button31.Name = "button31";
			this.button31.Size = new System.Drawing.Size(45, 45);
			this.button31.TabIndex = 30;
			this.button31.Text = "s";
			this.button31.UseVisualStyleBackColor = true;
			// 
			// button32
			// 
			this.button32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button32.Location = new System.Drawing.Point(200, 216);
			this.button32.Name = "button32";
			this.button32.Size = new System.Drawing.Size(45, 45);
			this.button32.TabIndex = 31;
			this.button32.Text = "d";
			this.button32.UseVisualStyleBackColor = true;
			// 
			// button33
			// 
			this.button33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button33.Location = new System.Drawing.Point(251, 216);
			this.button33.Name = "button33";
			this.button33.Size = new System.Drawing.Size(45, 45);
			this.button33.TabIndex = 32;
			this.button33.Text = "f";
			this.button33.UseVisualStyleBackColor = true;
			// 
			// button34
			// 
			this.button34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button34.Location = new System.Drawing.Point(302, 216);
			this.button34.Name = "button34";
			this.button34.Size = new System.Drawing.Size(45, 45);
			this.button34.TabIndex = 33;
			this.button34.Text = "g";
			this.button34.UseVisualStyleBackColor = true;
			// 
			// button35
			// 
			this.button35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button35.Location = new System.Drawing.Point(353, 216);
			this.button35.Name = "button35";
			this.button35.Size = new System.Drawing.Size(45, 45);
			this.button35.TabIndex = 34;
			this.button35.Text = "h";
			this.button35.UseVisualStyleBackColor = true;
			// 
			// button36
			// 
			this.button36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button36.Location = new System.Drawing.Point(404, 216);
			this.button36.Name = "button36";
			this.button36.Size = new System.Drawing.Size(45, 45);
			this.button36.TabIndex = 35;
			this.button36.Text = "j";
			this.button36.UseVisualStyleBackColor = true;
			// 
			// button37
			// 
			this.button37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button37.Location = new System.Drawing.Point(455, 216);
			this.button37.Name = "button37";
			this.button37.Size = new System.Drawing.Size(45, 45);
			this.button37.TabIndex = 36;
			this.button37.Text = "k";
			this.button37.UseVisualStyleBackColor = true;
			// 
			// button38
			// 
			this.button38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button38.Location = new System.Drawing.Point(506, 216);
			this.button38.Name = "button38";
			this.button38.Size = new System.Drawing.Size(45, 45);
			this.button38.TabIndex = 37;
			this.button38.Text = "l";
			this.button38.UseVisualStyleBackColor = true;
			// 
			// button39
			// 
			this.button39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button39.Location = new System.Drawing.Point(557, 216);
			this.button39.Name = "button39";
			this.button39.Size = new System.Drawing.Size(45, 45);
			this.button39.TabIndex = 38;
			this.button39.Text = ";/:";
			this.button39.UseVisualStyleBackColor = true;
			// 
			// button40
			// 
			this.button40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button40.Location = new System.Drawing.Point(608, 216);
			this.button40.Name = "button40";
			this.button40.Size = new System.Drawing.Size(45, 45);
			this.button40.TabIndex = 39;
			this.button40.Text = "\'/\"";
			this.button40.UseVisualStyleBackColor = true;
			// 
			// button41
			// 
			this.button41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button41.Location = new System.Drawing.Point(659, 216);
			this.button41.Name = "button41";
			this.button41.Size = new System.Drawing.Size(107, 45);
			this.button41.TabIndex = 40;
			this.button41.Text = "Enter";
			this.button41.UseVisualStyleBackColor = true;
			// 
			// button42
			// 
			this.button42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button42.Location = new System.Drawing.Point(13, 267);
			this.button42.Name = "button42";
			this.button42.Size = new System.Drawing.Size(104, 45);
			this.button42.TabIndex = 41;
			this.button42.Text = "LShift";
			this.button42.UseVisualStyleBackColor = true;
			// 
			// button43
			// 
			this.button43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button43.Location = new System.Drawing.Point(123, 267);
			this.button43.Name = "button43";
			this.button43.Size = new System.Drawing.Size(45, 45);
			this.button43.TabIndex = 42;
			this.button43.Text = "z";
			this.button43.UseVisualStyleBackColor = true;
			// 
			// button44
			// 
			this.button44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button44.Location = new System.Drawing.Point(174, 267);
			this.button44.Name = "button44";
			this.button44.Size = new System.Drawing.Size(45, 45);
			this.button44.TabIndex = 43;
			this.button44.Text = "x";
			this.button44.UseVisualStyleBackColor = true;
			// 
			// button45
			// 
			this.button45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button45.Location = new System.Drawing.Point(225, 267);
			this.button45.Name = "button45";
			this.button45.Size = new System.Drawing.Size(45, 45);
			this.button45.TabIndex = 44;
			this.button45.Text = "c";
			this.button45.UseVisualStyleBackColor = true;
			// 
			// button46
			// 
			this.button46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button46.Location = new System.Drawing.Point(276, 267);
			this.button46.Name = "button46";
			this.button46.Size = new System.Drawing.Size(45, 45);
			this.button46.TabIndex = 45;
			this.button46.Text = "v";
			this.button46.UseVisualStyleBackColor = true;
			// 
			// button47
			// 
			this.button47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button47.Location = new System.Drawing.Point(327, 267);
			this.button47.Name = "button47";
			this.button47.Size = new System.Drawing.Size(45, 45);
			this.button47.TabIndex = 46;
			this.button47.Text = "b";
			this.button47.UseVisualStyleBackColor = true;
			// 
			// button48
			// 
			this.button48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button48.Location = new System.Drawing.Point(378, 267);
			this.button48.Name = "button48";
			this.button48.Size = new System.Drawing.Size(45, 45);
			this.button48.TabIndex = 47;
			this.button48.Text = "n";
			this.button48.UseVisualStyleBackColor = true;
			// 
			// button49
			// 
			this.button49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button49.Location = new System.Drawing.Point(429, 267);
			this.button49.Name = "button49";
			this.button49.Size = new System.Drawing.Size(45, 45);
			this.button49.TabIndex = 48;
			this.button49.Text = "m";
			this.button49.UseVisualStyleBackColor = true;
			// 
			// button50
			// 
			this.button50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button50.Location = new System.Drawing.Point(480, 267);
			this.button50.Name = "button50";
			this.button50.Size = new System.Drawing.Size(45, 45);
			this.button50.TabIndex = 49;
			this.button50.Text = ",/<";
			this.button50.UseVisualStyleBackColor = true;
			// 
			// button51
			// 
			this.button51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button51.Location = new System.Drawing.Point(531, 267);
			this.button51.Name = "button51";
			this.button51.Size = new System.Drawing.Size(45, 45);
			this.button51.TabIndex = 50;
			this.button51.Text = "./>";
			this.button51.UseVisualStyleBackColor = true;
			// 
			// button52
			// 
			this.button52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button52.Location = new System.Drawing.Point(582, 267);
			this.button52.Name = "button52";
			this.button52.Size = new System.Drawing.Size(45, 45);
			this.button52.TabIndex = 51;
			this.button52.Text = "//?";
			this.button52.UseVisualStyleBackColor = true;
			// 
			// button53
			// 
			this.button53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button53.Location = new System.Drawing.Point(633, 267);
			this.button53.Name = "button53";
			this.button53.Size = new System.Drawing.Size(133, 45);
			this.button53.TabIndex = 52;
			this.button53.Text = "RShift";
			this.button53.UseVisualStyleBackColor = true;
			// 
			// button54
			// 
			this.button54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button54.Location = new System.Drawing.Point(13, 318);
			this.button54.Name = "button54";
			this.button54.Size = new System.Drawing.Size(56, 45);
			this.button54.TabIndex = 53;
			this.button54.Text = "LControl";
			this.button54.UseVisualStyleBackColor = true;
			// 
			// button55
			// 
			this.button55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button55.Location = new System.Drawing.Point(75, 318);
			this.button55.Name = "button55";
			this.button55.Size = new System.Drawing.Size(56, 45);
			this.button55.TabIndex = 54;
			this.button55.Text = "System";
			this.button55.UseVisualStyleBackColor = true;
			// 
			// button56
			// 
			this.button56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button56.Location = new System.Drawing.Point(137, 318);
			this.button56.Name = "button56";
			this.button56.Size = new System.Drawing.Size(56, 45);
			this.button56.TabIndex = 55;
			this.button56.Text = "LAlt";
			this.button56.UseVisualStyleBackColor = true;
			// 
			// button57
			// 
			this.button57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button57.Location = new System.Drawing.Point(199, 318);
			this.button57.Name = "button57";
			this.button57.Size = new System.Drawing.Size(315, 45);
			this.button57.TabIndex = 56;
			this.button57.Text = " ";
			this.button57.UseVisualStyleBackColor = true;
			// 
			// button58
			// 
			this.button58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button58.Location = new System.Drawing.Point(523, 318);
			this.button58.Name = "button58";
			this.button58.Size = new System.Drawing.Size(56, 45);
			this.button58.TabIndex = 57;
			this.button58.Text = "RAlt";
			this.button58.UseVisualStyleBackColor = true;
			// 
			// button59
			// 
			this.button59.Enabled = false;
			this.button59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button59.Location = new System.Drawing.Point(585, 318);
			this.button59.Name = "button59";
			this.button59.Size = new System.Drawing.Size(56, 45);
			this.button59.TabIndex = 58;
			this.button59.UseVisualStyleBackColor = true;
			// 
			// button60
			// 
			this.button60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button60.Location = new System.Drawing.Point(648, 318);
			this.button60.Name = "button60";
			this.button60.Size = new System.Drawing.Size(56, 45);
			this.button60.TabIndex = 59;
			this.button60.Text = "Menu";
			this.button60.UseVisualStyleBackColor = true;
			// 
			// button61
			// 
			this.button61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button61.Location = new System.Drawing.Point(710, 318);
			this.button61.Name = "button61";
			this.button61.Size = new System.Drawing.Size(56, 45);
			this.button61.TabIndex = 60;
			this.button61.Text = "RControl";
			this.button61.UseVisualStyleBackColor = true;
			// 
			// additionalKeysBox
			// 
			this.additionalKeysBox.FormattingEnabled = true;
			this.additionalKeysBox.Location = new System.Drawing.Point(13, 396);
			this.additionalKeysBox.Name = "additionalKeysBox";
			this.additionalKeysBox.Size = new System.Drawing.Size(180, 21);
			this.additionalKeysBox.TabIndex = 62;
			this.additionalKeysBox.Visible = false;
			// 
			// selectButton
			// 
			this.selectButton.Location = new System.Drawing.Point(200, 396);
			this.selectButton.Name = "selectButton";
			this.selectButton.Size = new System.Drawing.Size(75, 23);
			this.selectButton.TabIndex = 63;
			this.selectButton.Text = "SELECT";
			this.selectButton.UseVisualStyleBackColor = true;
			this.selectButton.Visible = false;
			// 
			// modifyKeysButton
			// 
			this.modifyKeysButton.Location = new System.Drawing.Point(670, 23);
			this.modifyKeysButton.Name = "modifyKeysButton";
			this.modifyKeysButton.Size = new System.Drawing.Size(96, 23);
			this.modifyKeysButton.TabIndex = 64;
			this.modifyKeysButton.Text = "Toggle Shift";
			this.modifyKeysButton.UseVisualStyleBackColor = true;
			this.modifyKeysButton.Click += new System.EventHandler(this.modifyKeysButton_Click);
			// 
			// button62
			// 
			this.button62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button62.Location = new System.Drawing.Point(13, 63);
			this.button62.Name = "button62";
			this.button62.Size = new System.Drawing.Size(45, 45);
			this.button62.TabIndex = 65;
			this.button62.Text = "Esc";
			this.button62.UseVisualStyleBackColor = true;
			// 
			// button63
			// 
			this.button63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button63.Location = new System.Drawing.Point(98, 63);
			this.button63.Name = "button63";
			this.button63.Size = new System.Drawing.Size(45, 45);
			this.button63.TabIndex = 66;
			this.button63.Text = "F1";
			this.button63.UseVisualStyleBackColor = true;
			// 
			// button64
			// 
			this.button64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button64.Location = new System.Drawing.Point(149, 63);
			this.button64.Name = "button64";
			this.button64.Size = new System.Drawing.Size(45, 45);
			this.button64.TabIndex = 67;
			this.button64.Text = "F2";
			this.button64.UseVisualStyleBackColor = true;
			// 
			// button65
			// 
			this.button65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button65.Location = new System.Drawing.Point(200, 63);
			this.button65.Name = "button65";
			this.button65.Size = new System.Drawing.Size(45, 45);
			this.button65.TabIndex = 68;
			this.button65.Text = "F3";
			this.button65.UseVisualStyleBackColor = true;
			// 
			// button66
			// 
			this.button66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button66.Location = new System.Drawing.Point(251, 63);
			this.button66.Name = "button66";
			this.button66.Size = new System.Drawing.Size(45, 45);
			this.button66.TabIndex = 69;
			this.button66.Text = "F4";
			this.button66.UseVisualStyleBackColor = true;
			// 
			// button67
			// 
			this.button67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button67.Location = new System.Drawing.Point(341, 63);
			this.button67.Name = "button67";
			this.button67.Size = new System.Drawing.Size(45, 45);
			this.button67.TabIndex = 70;
			this.button67.Text = "F5";
			this.button67.UseVisualStyleBackColor = true;
			// 
			// button68
			// 
			this.button68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button68.Location = new System.Drawing.Point(392, 63);
			this.button68.Name = "button68";
			this.button68.Size = new System.Drawing.Size(45, 45);
			this.button68.TabIndex = 71;
			this.button68.Text = "F6";
			this.button68.UseVisualStyleBackColor = true;
			// 
			// button69
			// 
			this.button69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button69.Location = new System.Drawing.Point(443, 63);
			this.button69.Name = "button69";
			this.button69.Size = new System.Drawing.Size(45, 45);
			this.button69.TabIndex = 72;
			this.button69.Text = "F7";
			this.button69.UseVisualStyleBackColor = true;
			// 
			// button70
			// 
			this.button70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button70.Location = new System.Drawing.Point(494, 63);
			this.button70.Name = "button70";
			this.button70.Size = new System.Drawing.Size(45, 45);
			this.button70.TabIndex = 73;
			this.button70.Text = "F8";
			this.button70.UseVisualStyleBackColor = true;
			// 
			// button71
			// 
			this.button71.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button71.Location = new System.Drawing.Point(568, 63);
			this.button71.Name = "button71";
			this.button71.Size = new System.Drawing.Size(45, 45);
			this.button71.TabIndex = 74;
			this.button71.Text = "F9";
			this.button71.UseVisualStyleBackColor = true;
			// 
			// button72
			// 
			this.button72.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button72.Location = new System.Drawing.Point(619, 63);
			this.button72.Name = "button72";
			this.button72.Size = new System.Drawing.Size(45, 45);
			this.button72.TabIndex = 75;
			this.button72.Text = "F10";
			this.button72.UseVisualStyleBackColor = true;
			// 
			// button73
			// 
			this.button73.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button73.Location = new System.Drawing.Point(670, 63);
			this.button73.Name = "button73";
			this.button73.Size = new System.Drawing.Size(45, 45);
			this.button73.TabIndex = 76;
			this.button73.Text = "F11";
			this.button73.UseVisualStyleBackColor = true;
			// 
			// button74
			// 
			this.button74.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button74.Location = new System.Drawing.Point(721, 63);
			this.button74.Name = "button74";
			this.button74.Size = new System.Drawing.Size(45, 45);
			this.button74.TabIndex = 77;
			this.button74.Text = "F12";
			this.button74.UseVisualStyleBackColor = true;
			// 
			// button75
			// 
			this.button75.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button75.Location = new System.Drawing.Point(114, 12);
			this.button75.Name = "button75";
			this.button75.Size = new System.Drawing.Size(45, 45);
			this.button75.TabIndex = 78;
			this.button75.Text = "🔊";
			this.button75.UseVisualStyleBackColor = true;
			// 
			// button76
			// 
			this.button76.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button76.Location = new System.Drawing.Point(12, 12);
			this.button76.Name = "button76";
			this.button76.Size = new System.Drawing.Size(45, 45);
			this.button76.TabIndex = 79;
			this.button76.Text = "🔉";
			this.button76.UseVisualStyleBackColor = true;
			// 
			// button77
			// 
			this.button77.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button77.Location = new System.Drawing.Point(63, 12);
			this.button77.Name = "button77";
			this.button77.Size = new System.Drawing.Size(45, 45);
			this.button77.TabIndex = 80;
			this.button77.Text = "🔇";
			this.button77.UseVisualStyleBackColor = true;
			// 
			// button79
			// 
			this.button79.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button79.Location = new System.Drawing.Point(188, 12);
			this.button79.Name = "button79";
			this.button79.Size = new System.Drawing.Size(45, 45);
			this.button79.TabIndex = 82;
			this.button79.Text = "⏮️";
			this.button79.UseVisualStyleBackColor = true;
			// 
			// button78
			// 
			this.button78.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button78.Location = new System.Drawing.Point(239, 12);
			this.button78.Name = "button78";
			this.button78.Size = new System.Drawing.Size(45, 45);
			this.button78.TabIndex = 83;
			this.button78.Text = "⏯️";
			this.button78.UseVisualStyleBackColor = true;
			// 
			// button80
			// 
			this.button80.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button80.Location = new System.Drawing.Point(290, 12);
			this.button80.Name = "button80";
			this.button80.Size = new System.Drawing.Size(45, 45);
			this.button80.TabIndex = 84;
			this.button80.Text = "⏭️";
			this.button80.UseVisualStyleBackColor = true;
			// 
			// button82
			// 
			this.button82.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button82.Location = new System.Drawing.Point(370, 12);
			this.button82.Name = "button82";
			this.button82.Size = new System.Drawing.Size(45, 45);
			this.button82.TabIndex = 86;
			this.button82.Text = "🔅";
			this.button82.UseVisualStyleBackColor = true;
			// 
			// button81
			// 
			this.button81.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button81.Location = new System.Drawing.Point(421, 12);
			this.button81.Name = "button81";
			this.button81.Size = new System.Drawing.Size(45, 45);
			this.button81.TabIndex = 87;
			this.button81.Text = "🔆";
			this.button81.UseVisualStyleBackColor = true;
			// 
			// button84
			// 
			this.button84.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button84.Location = new System.Drawing.Point(494, 12);
			this.button84.Name = "button84";
			this.button84.Size = new System.Drawing.Size(45, 45);
			this.button84.TabIndex = 89;
			this.button84.Text = "✉️";
			this.button84.UseVisualStyleBackColor = true;
			// 
			// button83
			// 
			this.button83.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button83.Location = new System.Drawing.Point(545, 12);
			this.button83.Name = "button83";
			this.button83.Size = new System.Drawing.Size(45, 45);
			this.button83.TabIndex = 90;
			this.button83.Text = "➗";
			this.button83.UseVisualStyleBackColor = true;
			// 
			// button85
			// 
			this.button85.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button85.Location = new System.Drawing.Point(596, 12);
			this.button85.Name = "button85";
			this.button85.Size = new System.Drawing.Size(45, 45);
			this.button85.TabIndex = 91;
			this.button85.Text = "🌐";
			this.button85.UseVisualStyleBackColor = true;
			// 
			// VirtualKeyboardForm
			// 
			this.ClientSize = new System.Drawing.Size(784, 376);
			this.Controls.Add(this.button85);
			this.Controls.Add(this.button83);
			this.Controls.Add(this.button84);
			this.Controls.Add(this.button81);
			this.Controls.Add(this.button82);
			this.Controls.Add(this.button80);
			this.Controls.Add(this.button78);
			this.Controls.Add(this.button79);
			this.Controls.Add(this.button77);
			this.Controls.Add(this.button76);
			this.Controls.Add(this.button75);
			this.Controls.Add(this.button74);
			this.Controls.Add(this.button73);
			this.Controls.Add(this.button72);
			this.Controls.Add(this.button71);
			this.Controls.Add(this.button70);
			this.Controls.Add(this.button69);
			this.Controls.Add(this.button68);
			this.Controls.Add(this.button67);
			this.Controls.Add(this.button66);
			this.Controls.Add(this.button65);
			this.Controls.Add(this.button64);
			this.Controls.Add(this.button63);
			this.Controls.Add(this.button62);
			this.Controls.Add(this.modifyKeysButton);
			this.Controls.Add(this.selectButton);
			this.Controls.Add(this.additionalKeysBox);
			this.Controls.Add(addKeysLabel);
			this.Controls.Add(this.button61);
			this.Controls.Add(this.button60);
			this.Controls.Add(this.button59);
			this.Controls.Add(this.button58);
			this.Controls.Add(this.button57);
			this.Controls.Add(this.button56);
			this.Controls.Add(this.button55);
			this.Controls.Add(this.button54);
			this.Controls.Add(this.button53);
			this.Controls.Add(this.button52);
			this.Controls.Add(this.button51);
			this.Controls.Add(this.button50);
			this.Controls.Add(this.button49);
			this.Controls.Add(this.button48);
			this.Controls.Add(this.button47);
			this.Controls.Add(this.button46);
			this.Controls.Add(this.button45);
			this.Controls.Add(this.button44);
			this.Controls.Add(this.button43);
			this.Controls.Add(this.button42);
			this.Controls.Add(this.button41);
			this.Controls.Add(this.button40);
			this.Controls.Add(this.button39);
			this.Controls.Add(this.button38);
			this.Controls.Add(this.button37);
			this.Controls.Add(this.button36);
			this.Controls.Add(this.button35);
			this.Controls.Add(this.button34);
			this.Controls.Add(this.button33);
			this.Controls.Add(this.button32);
			this.Controls.Add(this.button31);
			this.Controls.Add(this.button30);
			this.Controls.Add(this.button29);
			this.Controls.Add(this.button28);
			this.Controls.Add(this.button27);
			this.Controls.Add(this.button26);
			this.Controls.Add(this.button25);
			this.Controls.Add(this.button24);
			this.Controls.Add(this.button23);
			this.Controls.Add(this.button22);
			this.Controls.Add(this.button21);
			this.Controls.Add(this.button20);
			this.Controls.Add(this.button19);
			this.Controls.Add(this.button18);
			this.Controls.Add(this.button17);
			this.Controls.Add(this.button16);
			this.Controls.Add(this.button15);
			this.Controls.Add(this.button14);
			this.Controls.Add(this.button13);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(800, 415);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 415);
			this.Name = "VirtualKeyboardForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Virtual Keyboard";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VirtualKeyboardForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VirtualKeyboardForm_KeyUp);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void handleButtonSelect(object sender, EventArgs e)
		{
			Button button = sender as Button;
			Tuple<ushort, SequenceActionType> result = processKeyLabel(button.Text);
			selectedKeycode = result.Item1;
			sequenceActionType = result.Item2;
			this.Close();
		}

		private Tuple<ushort, SequenceActionType> processKeyLabel(string label)
		{
			Dictionary<string, Tuple<ushort, SequenceActionType>> keyMap = new Dictionary<string, Tuple<ushort, SequenceActionType>>
			{
				{ "backspace", Tuple.Create((ushort)Keycodes.BACKSPACE, SequenceActionType.KEYSTROKE)},
				{ "tab", Tuple.Create((ushort)Keycodes.TAB, SequenceActionType.KEYSTROKE) },
				{ "caps lock", Tuple.Create((ushort)Keycodes.CAPS_LOCK, SequenceActionType.KEYSTROKE) },
				{ "enter", Tuple.Create((ushort)Keycodes.ENTER, SequenceActionType.KEYSTROKE) },
				{ "lshift", Tuple.Create((ushort)Keycodes.LEFT_SHIFT, SequenceActionType.KEYSTROKE) },
				{ "rshift", Tuple.Create((ushort)Keycodes.RIGHT_SHIFT, SequenceActionType.KEYSTROKE) },
				{ "lcontrol", Tuple.Create((ushort)Keycodes.LEFT_CTRL, SequenceActionType.KEYSTROKE) },
				{ "rcontrol", Tuple.Create((ushort)Keycodes.RIGHT_CTRL, SequenceActionType.KEYSTROKE) },
				{ "system", Tuple.Create((ushort)Keycodes.LEFT_WINDOWS, SequenceActionType.KEYSTROKE) },
				{ "lalt", Tuple.Create((ushort)Keycodes.LEFT_ALT, SequenceActionType.KEYSTROKE) },
				{ "ralt", Tuple.Create((ushort)Keycodes.RIGHT_ALT, SequenceActionType.KEYSTROKE) },
				{ "menu", Tuple.Create((ushort)Keycodes.MENU, SequenceActionType.KEYSTROKE) },
				{ "~", Tuple.Create((ushort)Keycodes.TILDE, SequenceActionType.KEYSTROKE) },
				{ "1", Tuple.Create((ushort)Keycodes._1, SequenceActionType.KEYSTROKE) },
				{ "2", Tuple.Create((ushort)Keycodes._2, SequenceActionType.KEYSTROKE) },
				{ "3", Tuple.Create((ushort)Keycodes._3, SequenceActionType.KEYSTROKE) },
				{ "4", Tuple.Create((ushort)Keycodes._4, SequenceActionType.KEYSTROKE) },
				{ "5", Tuple.Create((ushort)Keycodes._5, SequenceActionType.KEYSTROKE) },
				{ "6", Tuple.Create((ushort)Keycodes._6, SequenceActionType.KEYSTROKE) },
				{ "7", Tuple.Create((ushort)Keycodes._7, SequenceActionType.KEYSTROKE) },
				{ "8", Tuple.Create((ushort)Keycodes._8, SequenceActionType.KEYSTROKE) },
				{ "9", Tuple.Create((ushort)Keycodes._9, SequenceActionType.KEYSTROKE) },
				{ "0", Tuple.Create((ushort)Keycodes._0, SequenceActionType.KEYSTROKE) },
				{ "=", Tuple.Create((ushort)Keycodes.EQUAL, SequenceActionType.KEYSTROKE) },
				{ "🔊", Tuple.Create((ushort)ConsumerKeycodes.MEDIA_VOL_UP, SequenceActionType.CONSUMER_KEYSTROKE) },
				{ "🔇", Tuple.Create((ushort)ConsumerKeycodes.MEDIA_VOL_MUTE, SequenceActionType.CONSUMER_KEYSTROKE) },
				{ "🔉", Tuple.Create((ushort)ConsumerKeycodes.MEDIA_VOLUME_DOWN, SequenceActionType.CONSUMER_KEYSTROKE) },
				{ "⏮️", Tuple.Create((ushort)ConsumerKeycodes.MEDIA_PREV, SequenceActionType.CONSUMER_KEYSTROKE) },
				{ "⏯️", Tuple.Create((ushort)ConsumerKeycodes.MEDIA_PLAY_PAUSE, SequenceActionType.CONSUMER_KEYSTROKE) },
				{ "⏭️", Tuple.Create((ushort)ConsumerKeycodes.MEDIA_NEXT, SequenceActionType.CONSUMER_KEYSTROKE) },
				{ "🔅", Tuple.Create((ushort)ConsumerKeycodes.BRIGHTNESS_DOWN, SequenceActionType.CONSUMER_KEYSTROKE) },
				{ "🔆", Tuple.Create((ushort)ConsumerKeycodes.BRIGHTNESS_UP, SequenceActionType.CONSUMER_KEYSTROKE) },
				{ "✉️", Tuple.Create((ushort)ConsumerKeycodes.EMAIL_READER, SequenceActionType.CONSUMER_KEYSTROKE) },
				{ "➗", Tuple.Create((ushort)ConsumerKeycodes.CALCULATOR, SequenceActionType.CONSUMER_KEYSTROKE) },
				{ "🌐", Tuple.Create((ushort)ConsumerKeycodes.EXPLORER, SequenceActionType.CONSUMER_KEYSTROKE) },
				{ "f1", Tuple.Create((ushort)Keycodes.F1, SequenceActionType.KEYSTROKE) },
				{ "f2", Tuple.Create((ushort)Keycodes.F2, SequenceActionType.KEYSTROKE) },
				{ "f3", Tuple.Create((ushort)Keycodes.F3, SequenceActionType.KEYSTROKE) },
				{ "f4", Tuple.Create((ushort)Keycodes.F4, SequenceActionType.KEYSTROKE) },
				{ "f5", Tuple.Create((ushort)Keycodes.F5, SequenceActionType.KEYSTROKE) },
				{ "f6", Tuple.Create((ushort)Keycodes.F6, SequenceActionType.KEYSTROKE) },
				{ "f7", Tuple.Create((ushort)Keycodes.F7, SequenceActionType.KEYSTROKE) },
				{ "f8", Tuple.Create((ushort)Keycodes.F8, SequenceActionType.KEYSTROKE) },
				{ "f9", Tuple.Create((ushort)Keycodes.F9, SequenceActionType.KEYSTROKE) },
				{ "f10", Tuple.Create((ushort)Keycodes.F10, SequenceActionType.KEYSTROKE) },
				{ "f11", Tuple.Create((ushort)Keycodes.F11, SequenceActionType.KEYSTROKE) },
				{ "f12", Tuple.Create((ushort)Keycodes.F12, SequenceActionType.KEYSTROKE) },
			};

			string lookupKey = label.ToLower();
			if (keyMap.ContainsKey(lookupKey))
			{
				return keyMap[lookupKey];
			}

			return Tuple.Create((ushort)label[0], SequenceActionType.CHARACTER_KEYSTROKE);
		}

		private void modifyKeysButton_Click(object sender, EventArgs e)
		{
			isModifyingKeys = !isModifyingKeys;
			for (int i = 0; i < modifiableButtons.Length; i++)
			{
				var chars = modifiableLabels[i];
				char c = chars.Item1;
				char modifiedC = chars.Item2;

				if (c == 0 && modifiedC == 0)
					continue;

				if (isModifyingKeys)
				{
					modifiableButtons[i].Text = modifiedC.ToString();
				}
				else
				{
					modifiableButtons[i].Text = c.ToString();
				}
			}
		}

		public ushort GetSelectedKey()
		{
			return selectedKeycode;
		}

		public SequenceActionType GetSequenceActionType()
		{
			return sequenceActionType;
		}

		private void VirtualKeyboardForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.ShiftKey) 
			{
				modifyKeysButton.PerformClick();
				modifyKeysButton.Enabled = false;
			}
		}

		private void VirtualKeyboardForm_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.ShiftKey)
			{
				modifyKeysButton.Enabled = true;
				modifyKeysButton.PerformClick();
			}
		}
	}
}
