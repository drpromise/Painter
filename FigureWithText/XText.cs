using System.Drawing;

namespace FigureWithText
{
	class XText : System.IDisposable
	{
		public string text = "Text";
		public Font font = new Font("Arial", 14);
		public Color color = Color.Black;

		public void Dispose()
		{
			font.Dispose();
		}
	}
}
