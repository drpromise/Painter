using Painter.Models;
using Painter.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Painter.Controllers
{
	public interface IXCommand
	{
        PFigure ActiveFigure { get; set; }
		IPluginFigure ActiveFigurePlugin { get; set; }
		List<IPluginFigure> FigurePlugins { get; }
		List<IPluginFile> FilePlugins { get; }
		TabControl TabControl { get;  set; }

		event Action OnFigurePluginChanged;

		void InitializePluginManager();
		PFigure PluginProcess(PFigure figure);
		void New();
		void FileOpen();
		void FileSave();
		void FileSaveAs();
		void CloseTab();
		void RenameTab();
		void OpenFromCloud();
		void SaveInCloud();
		void Exit();
		void ShowAbout();
		void EmptyFigure();
		void RussianLanguage();
		void EnglishLanguage();
		void LightSkin();
		void DarkSkin();
		void ToggleVisible(Control control);
		void SetType(XData.FigureType type);
		void SetColor(Color color);
		void SetLineWidth(int width);
		void TogglePlugin(IPluginFigure plugin);
    }
}