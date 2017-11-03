using System;
using System.Collections.Generic;
using Painter.Models;
using Painter.Views;
using System.Windows.Forms;
using System.Drawing;

namespace Painter.Controllers
{
	class FakeXCommand : IXCommand
	{
		private PDraw _activePDraw = null;
		private IPluginFigure _activePlugin = null;
		private PluginManager _pluginManager = null;
		public PDraw ActivePDraw
		{
			set
			{
				_activePDraw = value;
				_activePlugin.ActiveFigure = _activePDraw.ActiveFigure;
			}
		}
		public IPluginFigure ActiveFigurePlugin { get => _activePlugin; set { _activePlugin = value; OnFigurePluginChanged(); } }
		public List<IPluginFigure> FigurePlugins { get => _pluginManager.figurePlugins; }
		public List<IPluginFile> FilePlugins { get => _pluginManager.formatPlugins; }

		public TabControl TabControl { get; set; }
        public PFigure ActiveFigure { get; set; }

        public event Action OnFigurePluginChanged;

		public void ChangeLineWidth1()
		{
			MessageBox.Show("ChangeLineWidth1");
		}

		public void ChangeLineWidth10()
		{
			throw new NotImplementedException();
		}

		public void ChangeLineWidth15()
		{
			throw new NotImplementedException();
		}

		public void ChangeLineWidth20()
		{
			throw new NotImplementedException();
		}

		public void ChangeLineWidth3()
		{
			throw new NotImplementedException();
		}

		public void ChangeLineWidth5()
		{
			throw new NotImplementedException();
		}

		public void CloseTab()
		{
			throw new NotImplementedException();
		}

		public void DarkSkin()
		{
			throw new NotImplementedException();
		}

		public void Debug()
		{
			throw new NotImplementedException();
		}

		public void EllipseType()
		{
			throw new NotImplementedException();
		}

		public void EmptyFigure()
		{
			throw new NotImplementedException();
		}

		public void EnglishLanguage()
		{
			throw new NotImplementedException();
		}

		public void Exit()
		{
			throw new NotImplementedException();
		}

		public void FigureColor()
		{
			throw new NotImplementedException();
		}

		public void FileOpen()
		{
			MessageBox.Show("File open");
		}

		public void FileSave()
		{
			throw new NotImplementedException();
		}

		public void FileSaveAs()
		{
			throw new NotImplementedException();
		}

		public void InitializePluginManager()
		{
			_pluginManager = new PluginManager();
		}

		public void LightSkin()
		{
			throw new NotImplementedException();
		}

		public void LineType()
		{
			throw new NotImplementedException();
		}

		public void New()
		{
			MessageBox.Show("New");
		}

		public void OpenFromCloud()
		{
			throw new NotImplementedException();
		}

		public PFigure PluginProcess(PFigure figure)
		{
			throw new NotImplementedException();
		}

		public void RectangleType()
		{
			throw new NotImplementedException();
		}

		public void RenameTab()
		{
			throw new NotImplementedException();
		}

		public void RoundedRectangleType()
		{
			throw new NotImplementedException();
		}

		public void RussianLanguage()
		{
			throw new NotImplementedException();
		}

		public void SaveInCloud()
		{
			throw new NotImplementedException();
		}

		public void SetColor(Color color)
		{
			throw new NotImplementedException();
		}

        public void SetColor(object v)
        {
            throw new NotImplementedException();
        }

        public void SetLineWidth(int width)
		{
			throw new NotImplementedException();
		}

		public void SetType(XData.FigureType type)
		{
			throw new NotImplementedException();
		}

		public void ShowAbout()
		{
			throw new NotImplementedException();
		}

		public void ShowElements()
		{
			throw new NotImplementedException();
		}

		public void ShowProperties()
		{
			throw new NotImplementedException();
		}

		public void TogglePlugin(IPluginFigure plugin)
		{
			throw new NotImplementedException();
		}

		public void ToggleVisible(Control control)
		{
			throw new NotImplementedException();
		}
	}
}
