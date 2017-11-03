using System.Windows.Forms;
using Painter.Controllers;
using System.Drawing;

namespace Painter.Views
{
	public class PElements : Panel
	{
		private IXCommand _xCommand;



		public PElements(IXCommand xCommand)
		{
			_xCommand = xCommand;

			int y = 50;
			RadioButton r = new RadioButton();
			r.Text = "Empty Figure";
            r.Location = new Point(10, y);
			r.Checked = true;
			y += 20;
			r.CheckedChanged += delegate
			{
				if (r.Checked)
					_xCommand.ActiveFigurePlugin = null;
			};
			Controls.Add(r);

			foreach (var plugin in xCommand.FigurePlugins)
			{
				RadioButton rb = plugin.GetElements();
				rb.Location = new Point(10, y);
				rb.CheckedChanged += delegate
				{
					if (rb.Checked)
						_xCommand.ActiveFigurePlugin = plugin;
				};
				y += 20;
				Controls.Add(rb);
			}

            SkinController.OnSkinChange += SkinController_OnSkinChange;
		}

        private void SkinController_OnSkinChange()
        {
            BackColor = SkinController.GetColor("primaryColor");
            ForeColor = SkinController.GetColor("primaryTextColor");
        }
    }
}
