using Painter.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.Views
{
    public class PToolBox : Panel
    {
        private IXCommand _xCommand;

		private GroupBox _emptyFigureGroupBox;
		private RadioButton _line;
		private RadioButton _rect;
		private RadioButton _ellipse;
		private RadioButton _roundRect;
		private Button _color;
		private Label _lineWidthLabel;
		private ComboBox _lineWidth;

		public PToolBox(IXCommand xCommand)
        {
            _xCommand = xCommand;

			// figure
			_emptyFigureGroupBox = new GroupBox();
			_emptyFigureGroupBox.Parent = this;
			_emptyFigureGroupBox.Text = Localization.GetText("figure_text_id");
			_emptyFigureGroupBox.Location = new System.Drawing.Point(0, 0);
			_emptyFigureGroupBox.Size = new System.Drawing.Size(Width - 10, 150);

			_line = new RadioButton();
			_line.Parent = _emptyFigureGroupBox;
			_line.Text = Localization.GetText("line_text_id");
			_line.Location = new System.Drawing.Point(10, 20);
			_line.CheckedChanged += delegate { if(_line.Checked) _xCommand.SetType(Models.XData.FigureType.Line); };

			_rect = new RadioButton();
			_rect.Parent = _emptyFigureGroupBox;
			_rect.Text = Localization.GetText("rectangle_text_id");
			_rect.Location = new System.Drawing.Point(10, 40);
			_rect.CheckedChanged += delegate { if (_rect.Checked) _xCommand.SetType(Models.XData.FigureType.Rectangle); };

			_ellipse = new RadioButton();
			_ellipse.Parent = _emptyFigureGroupBox;
			_ellipse.Text = Localization.GetText("ellipse_text_id");
			_ellipse.Location = new System.Drawing.Point(10, 60);
			_ellipse.CheckedChanged += delegate { if (_ellipse.Checked) _xCommand.SetType(Models.XData.FigureType.Ellipse); };

			_roundRect = new RadioButton();
			_roundRect.Parent = _emptyFigureGroupBox;
			_roundRect.Text = Localization.GetText("rounded_rectangle_text_id");
			_roundRect.Location = new System.Drawing.Point(10, 80);
			_roundRect.CheckedChanged += delegate { if (_roundRect.Checked) _xCommand.SetType(Models.XData.FigureType.RoundRectangle); };

			_color = new Button();
			_color.Parent = _emptyFigureGroupBox;
			_color.Text = Localization.GetText("color_text_id");
			_color.Location = new System.Drawing.Point(120, 20);
			_color.Size = new System.Drawing.Size(60, 25);
			_color.Click += delegate { try { _xCommand.SetColor(Utilities.GetColor()); } catch { } };

            _lineWidthLabel = new Label();
            _lineWidthLabel.Parent = _emptyFigureGroupBox;
            _lineWidthLabel.Text = Localization.GetText("line_width_text_id");
            _lineWidthLabel.Location = new System.Drawing.Point(120, 70);
            _lineWidthLabel.Size = new System.Drawing.Size(60, 25);


            _lineWidth = new ComboBox();
            _lineWidth.Parent = _emptyFigureGroupBox;
            _lineWidth.Items.Add(1);
            _lineWidth.Items.Add(3);
            _lineWidth.Items.Add(5);
            _lineWidth.Items.Add(10);
            _lineWidth.Items.Add(15);
            _lineWidth.Items.Add(20);
            _lineWidth.SelectedIndex = 0;
            _lineWidth.Text = Localization.GetText("color_text_id");
            _lineWidth.Location = new System.Drawing.Point(120, 100);
            _lineWidth.Size = new System.Drawing.Size(60, 25);
            _lineWidth.Click += delegate { try { _xCommand.SetLineWidth(Int32.Parse(_lineWidth.SelectedText)); } catch { } };

            Localization.OnLocalChange += Localization_OnLocalChange;
			_xCommand.OnFigurePluginChanged += _xCommand_OnFigurePluginChanged;
            SkinController.OnSkinChange += SkinController_OnSkinChange;
        }

		private void _xCommand_OnFigurePluginChanged()
		{
            Controls.Clear();
            Controls.Add(_emptyFigureGroupBox);

            if (_xCommand.ActiveFigurePlugin != null)
            {
                var pluginToolBox = _xCommand.ActiveFigurePlugin.GetToolBox();
                pluginToolBox.Parent = this;
                pluginToolBox.Location = new System.Drawing.Point(0, 160);
                pluginToolBox.Size = new System.Drawing.Size(Width - 10, 210);
                Controls.Add(pluginToolBox);
            }
		}

        private void Localization_OnLocalChange()
        {
            _emptyFigureGroupBox.Text = Localization.GetText("figure_text_id");
            _line.Text = Localization.GetText("line_text_id");
            _rect.Text = Localization.GetText("rectangle_text_id");
            _ellipse.Text = Localization.GetText("ellipse_text_id");
            _roundRect.Text = Localization.GetText("rounded_rectangle_text_id");
            _color.Text = Localization.GetText("color_text_id");
            _lineWidthLabel.Text = Localization.GetText("line_width_text_id");
        }

        private void SkinController_OnSkinChange()
        {
            BackColor = SkinController.GetColor("primaryColor");
            ForeColor = SkinController.GetColor("primaryTextColor");
        }
    }
}
