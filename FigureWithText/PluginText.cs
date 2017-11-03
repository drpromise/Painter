using Painter.Models;
using System;
using System.Windows.Forms;
using Painter.Views;

namespace FigureWithText
{
	class PluginText : IPluginFigure
	{
		XCommand _xCommand = new XCommand();

		public PFigure ActiveFigure { set => _xCommand.ActiveFigure = value; }
		public string Name => "Figure with text";
		public bool Enabled { get; set; }

		public RadioButton GetElements()
		{
			RadioButton radioButton = new RadioButton();
			radioButton.Text = Name;
			radioButton.Name = Name;
			return radioButton;
		}

		public ToolStripMenuItem GetMenuStrip()
		{
			ToolStripMenuItem menu = new ToolStripMenuItem("Text plugin");
			menu.DropDownItems.Add(new ToolStripMenuItem("qwerty", null, delegate
			{
				_xCommand.SetText("qwerty");
			}));

			menu.DropDownItems.Add(new ToolStripMenuItem("QWERTY", null, delegate
			{
				_xCommand.SetText("QWERTY");
			}));

			return menu;
		}

		public GroupBox GetToolBox()
		{
            GroupBox groupBox = new GroupBox();
            groupBox.Text = "Text";

            Label lblHorAli = new Label();
            lblHorAli.Text = "Horizontal align:";
            lblHorAli.Location = new System.Drawing.Point(10, 20);
            lblHorAli.Size = new System.Drawing.Size(90, 20);
            groupBox.Controls.Add(lblHorAli);

            ComboBox cbHorAli = new ComboBox();
            cbHorAli.Items.Add("Left");
            cbHorAli.Items.Add("Center");
            cbHorAli.Items.Add("Right");
            cbHorAli.SelectedItem = "Center";
            cbHorAli.Location = new System.Drawing.Point(10, 40);
            cbHorAli.Size = new System.Drawing.Size(80, 25);
            groupBox.Controls.Add(cbHorAli);

            Button fontPicker = new Button();
            fontPicker.Text = "Font";
            fontPicker.Location = new System.Drawing.Point(10, 70);
            fontPicker.Size = new System.Drawing.Size(80, 25);
            fontPicker.Click += delegate { _xCommand.PickFont(); };
            groupBox.Controls.Add(fontPicker);

            Label lblVerAli = new Label();
            lblVerAli.Text = "Vetriczl align:";
            lblVerAli.Location = new System.Drawing.Point(100, 20);
            lblVerAli.Size = new System.Drawing.Size(80, 20);
            groupBox.Controls.Add(lblVerAli);

            ComboBox cbVerAli = new ComboBox();
            cbVerAli.Items.Add("Left");
            cbVerAli.Items.Add("Center");
            cbVerAli.Items.Add("Right");
            cbVerAli.SelectedItem = "Center";
            cbVerAli.Location = new System.Drawing.Point(100, 40);
            cbVerAli.Size = new System.Drawing.Size(80, 25);
            groupBox.Controls.Add(cbVerAli);

            Button fontColorPicker = new Button();
            fontColorPicker.Text = "Color";
            fontColorPicker.Location = new System.Drawing.Point(100, 70);
            fontColorPicker.Size = new System.Drawing.Size(80, 25);
            fontColorPicker.Click += delegate { _xCommand.PickTextColor(); };
            groupBox.Controls.Add(fontColorPicker);

            Label lblText = new Label();
            lblText.Text = "Text string:";
            lblText.Location = new System.Drawing.Point(10, 105);
            lblText.Size = new System.Drawing.Size(60, 20);
            groupBox.Controls.Add(lblText);

            TextBox textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(70, 105);
            textBox.Size = new System.Drawing.Size(110,25);
            groupBox.Controls.Add(textBox);
            
            Label lblTextRot = new Label();
            lblTextRot.Text = "Text rotate angle:";
            lblTextRot.Location = new System.Drawing.Point(10, 135);
            lblTextRot.Size = new System.Drawing.Size(100, 20);
            groupBox.Controls.Add(lblTextRot);

            TrackBar tbRot = new TrackBar();
            tbRot.Value = 0;
            tbRot.Minimum = 0;
            tbRot.Maximum = 360;
            tbRot.Location = new System.Drawing.Point(10, 160);
            tbRot.Size = new System.Drawing.Size(175, 20);
            groupBox.Controls.Add(tbRot);
            
            return groupBox;
		}

		public ToolStrip GetToolStrip()
		{
			throw new NotImplementedException();
		}

		public PFigure Process(PFigure figure)
		{
			return new FigureWithText(figure, _xCommand.xText);
		}
	}
}
