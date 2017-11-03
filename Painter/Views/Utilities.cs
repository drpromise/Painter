using System;
using System.Drawing;
using System.Windows.Forms;

namespace Painter.Views
{
    class Utilities
    {
        public static Color GetColor()
        {
            ColorDialog dlgColor = new ColorDialog();
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                return dlgColor.Color;
            }
            throw new Exception();
        }
    }
}