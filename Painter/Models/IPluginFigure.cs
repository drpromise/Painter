using Painter.Views;
using System.Windows.Forms;

namespace Painter.Models
{
    public interface IPluginFigure : IPlugin
    {
		ToolStrip GetToolStrip();
		ToolStripMenuItem GetMenuStrip();
		GroupBox GetToolBox();
		RadioButton GetElements();

		PFigure ActiveFigure { set; }
		PFigure Process(PFigure figure);
	}
}
