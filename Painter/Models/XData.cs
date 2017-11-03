using System.Drawing;

namespace Painter.Models
{
	public class XData
	{
		public enum FigureType { Rectangle, Ellipse, RoundRectangle, Line };

		public Color color = Color.Black;
		public int lineWidth = 1;
		public FigureType type = FigureType.Rectangle;
	}
}
