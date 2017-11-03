using Painter.Controllers;
using System.Drawing;
using System.Windows.Forms;

namespace Painter.Views
{
	class PFrame : Panel
	{
		public PFrame()
		{
			IXCommand xCommand = new XCommand();
			xCommand.InitializePluginManager();

            var primaryBackColor = SkinController.GetColor("primaryColor");

            TabControl tabControl = new TabControl();
			tabControl.Dock = DockStyle.Fill;
			Controls.Add(tabControl);

			xCommand.TabControl = tabControl;

			PElements pElements = new PElements(xCommand);
			pElements.Dock = DockStyle.Left;
            pElements.BackColor = primaryBackColor;
            pElements.Width = 150;
			Controls.Add(pElements);

			PToolBox pToolBox = new PToolBox(xCommand);
			pToolBox.Dock = DockStyle.Right;
            pToolBox.BackColor = primaryBackColor;
            pToolBox.Width = 200;
			Controls.Add(pToolBox);

            PToolBar pToolBar = new PToolBar(xCommand);
            pToolBar.BackColor = primaryBackColor;
            pToolBar.Dock = DockStyle.Top;
            Controls.Add(pToolBar);

            PMainMenu pMainMenu = new PMainMenu(xCommand);
			pMainMenu.Dock = DockStyle.Top;
            pMainMenu.BackColor = primaryBackColor;
            pMainMenu.Height = 50;
			Controls.Add(pMainMenu);
            
            PStatusBar pStatusBar = new PStatusBar(xCommand);
            pStatusBar.Dock = DockStyle.Bottom;
            pStatusBar.BackColor = primaryBackColor;
            Controls.Add(pStatusBar);
        }
	}
}
