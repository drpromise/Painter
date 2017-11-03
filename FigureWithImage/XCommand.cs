using Painter.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigureWithImage
{
    class XCommand
    {
        public PFigure ActiveFigure { get; set; }
        public XImage xImage = new XImage();


        public void SetImage(string img)
        {
            if (ActiveFigure == null)
            {
                xImage.img = img;
            }
            else
            {
                (ActiveFigure as FigureWithImage).XImage.img = img;
                ActiveFigure.Invalidate();
            }
        }

        internal void OpenImage()
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    SetImage(open.FileName);
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        }
    }
}
