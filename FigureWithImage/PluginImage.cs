using Painter.Models;
using Painter.Views;
using System;
using System.Windows.Forms;

namespace FigureWithImage
{
    class PluginImage : IPluginFigure
    {
        XCommand _xCommand = new XCommand();

        public PFigure ActiveFigure { set => _xCommand.ActiveFigure = value; }
        public string Name => "Figure with image";
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
            ToolStripMenuItem menu = new ToolStripMenuItem("Image plugin");
            

            return menu;
        }

        public GroupBox GetToolBox()
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Text = "Image";

            Button openImage = new Button();
            openImage.Text = "Open Image";
            openImage.Location = new System.Drawing.Point(10, 20);
            openImage.Size = new System.Drawing.Size(100, 25);
            openImage.Click += delegate { _xCommand.OpenImage(); };
            groupBox.Controls.Add(openImage);
            
            return groupBox;
        }

        public ToolStrip GetToolStrip()
        {
            throw new NotImplementedException();
        }

        public PFigure Process(PFigure figure)
        {
            return new FigureWithImage(figure, _xCommand.xImage);
        }
    }
}
