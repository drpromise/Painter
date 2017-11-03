using Painter.Views;
using System.Windows.Forms;
using System.Drawing;

namespace FigureWithText
{
	class FigureWithText : PFigure
	{
		public XText XText { get; }

		public FigureWithText(PFigure pFigure, XText xText)
			: base(pFigure)
		{
			XText = xText;
		}

		protected override void PFigure_Paint(object sender, PaintEventArgs e)
		{
			base.PFigure_Paint(sender, e);
			Graphics g = CreateGraphics();
			g.DrawString(XText.text, DefaultFont, Brushes.Red, new Point(0,0));
		}
	}
}