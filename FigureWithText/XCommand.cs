using Painter.Views;
using System.Drawing;
using System.Windows.Forms;

namespace FigureWithText
{
	class XCommand
	{
		public PFigure ActiveFigure { get; set; }
		public XText xText = new XText();

		public void SetText(string text)
		{
			if (ActiveFigure == null)
			{
				xText.text = text;
			}
			else
			{
				(ActiveFigure as FigureWithText).XText.text = text;
				ActiveFigure.Invalidate();
			}
		}

        public void PickFont()
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;

            if(fd.ShowDialog() == DialogResult.Yes)
            {
                SetFont(fd.Font);
            }
        }

        public void PickTextColor()
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.Yes)
            {
                SetFont(cd.Color);
            }
        }

        public void SetFont(Font font)
		{
			if (ActiveFigure == null)
			{
				xText.font = font;
			}
			else
			{
				(ActiveFigure as FigureWithText).XText.font = font;
				ActiveFigure.Invalidate();
			}
		}

		public void SetFont(Color color)
		{
			if (ActiveFigure == null)
			{
				xText.color = color;
			}
			else
			{
				(ActiveFigure as FigureWithText).XText.color = color;
				ActiveFigure.Invalidate();
			}
		}
	}
}
