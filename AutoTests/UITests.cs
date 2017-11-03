using System;
using NUnit.Framework;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.ListViewItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using System.Collections.Generic;
//using System.Windows.Forms;
using System.Diagnostics;

namespace AutoTests
{
	[TestFixture]
    public class UITests
    {
        private Application _application;
		private Window _mainWindow;

		[OneTimeTearDown]
        public void TestTearDown()
        {
			_mainWindow.Close();
            _application.Close();
        }

        [OneTimeSetUp]
        public void SetUp()
        {
			var psi = new ProcessStartInfo(@"C:\Users\Student\Desktop\11.10\Painter\plugins\Painter.exe");
			_application = Application.AttachOrLaunch(psi);
			_mainWindow = _application.GetWindows()[0];
		}

        //[TestCase("File", "New tab")]
        [TestCase("File", "Open")]
        [TestCase("File", "Save")]
        [TestCase("File", "Save as...")]
        [TestCase("File", "Close tab")]
        [TestCase("File", "Rename tab")]
        [TestCase("File", "Open from cloud")]
        [TestCase("File", "Save in cluod")]
        [TestCase("File", "Exit")]
		[TestCase("View", "Elements")]
		[TestCase("View", "Properties")]
		//[TestCase("Plug-ins", "")]
		public void TestMenu(string firstIndex, string secondIndex)
        {
			_mainWindow.Get(SearchCriteria.ByText(firstIndex)).Click();
			_mainWindow.Get(SearchCriteria.ByText(secondIndex)).Click();
			var a = _mainWindow.ModalWindows()[0].Get(SearchCriteria.ByText(secondIndex));
			Assert.IsNotNull(a);
			_mainWindow.ModalWindows()[0].Close();
		}
    }
}
