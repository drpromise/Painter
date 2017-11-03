using System;
using NUnit.Framework;
using Painter.Controllers;
using System.Drawing;
using System.Windows.Forms;
using Painter.Views;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
		XCommand xCommand;

		[SetUp]
		public void SetUp()
		{
			xCommand = new XCommand();
			xCommand.TabControl = new TabControl();
			xCommand.TabControl.TabPages.Add(new PDraw(xCommand));
			xCommand.TabControl.SelectedIndex = 0;
		}

        [Test]
        public void TestSetLineWidth()
        {
			xCommand.SetLineWidth(5);
			Assert.AreEqual(5, (xCommand.TabControl.TabPages[0] as PDraw)._xData.lineWidth);
        }

		[Test]
		public void TestSetColor()
		{
			xCommand.SetColor(Color.Red);
			Assert.AreEqual(Color.Red, (xCommand.TabControl.TabPages[0] as PDraw)._xData.color);
		}

		[Test]
		public void TestSetType()
		{
			xCommand.SetType(Painter.Models.XData.FigureType.Ellipse);
			Assert.AreEqual(Painter.Models.XData.FigureType.Ellipse, (xCommand.TabControl.TabPages[0] as PDraw)._xData.type);
		}
	}
}
