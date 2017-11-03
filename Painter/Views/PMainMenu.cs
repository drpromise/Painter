using Painter.Controllers;
using Painter.Models;
using System.Windows.Forms;

namespace Painter.Views
{
    public class PMainMenu : MenuStrip
    {
		private IXCommand _xCommand = null;

        // MainMenu
        private ToolStripMenuItem _fileBtn;
        private ToolStripMenuItem _viewBtn;
        private ToolStripMenuItem _pluginsBtn;
        private ToolStripMenuItem _tabsBtn;
        private ToolStripMenuItem _propertiesBtn;
        private ToolStripMenuItem _preferencesBtn;
        private ToolStripMenuItem _helpBtn;

        // MainMenu: File
        private ToolStripMenuItem _newBtn;
        private ToolStripMenuItem _openBtn;
        private ToolStripMenuItem _saveBtn;
        private ToolStripMenuItem _saveAsBtn;
        private ToolStripMenuItem _closeTabBtn;
        private ToolStripMenuItem _renameTabBtn;
        private ToolStripMenuItem _openFromCloudBtn;
        private ToolStripMenuItem _saveInCloudBtn;
        private ToolStripMenuItem _exitBtn;

        // MainMenu: View
        private ToolStripMenuItem _elementsBtn;
        private ToolStripMenuItem _propertiesFileBtn;

        // MainMenu: Plug-ins
        private ToolStripMenuItem _formatsBtn;
        private ToolStripMenuItem _elementsPluginsBtn;

        // MainMenu: Plug-ins : Elements
        private ToolStripMenuItem _emptyFigure;

        // MainMenu: Tabs
        private ToolStripMenuItem _closeAllBtn;

        // MainMenu: Properties
        private ToolStripMenuItem _figureBtn;

        // MainMenu: Properties : Figure
        private ToolStripMenuItem _figureTypesBtn;
        private ToolStripMenuItem _figureLineWidthBtn;
        private ToolStripMenuItem _figureColorBtn;

        // MainMenu: Properties : Figure : Types
        private ToolStripMenuItem _lineBtn;
        private ToolStripMenuItem _rectangleBtn;
        private ToolStripMenuItem _ellipseBtn;
        private ToolStripMenuItem _roundedRectangleBtn;

        // MainMenu: Properties : Figure : Line Width
        private ToolStripMenuItem _width1Btn;
        private ToolStripMenuItem _width3Btn;
        private ToolStripMenuItem _width5Btn;
        private ToolStripMenuItem _width10Btn;
        private ToolStripMenuItem _width15Btn;
        private ToolStripMenuItem _width20Btn;


        // MainMenu: Preferences
        private ToolStripMenuItem _languageBtn;
        private ToolStripMenuItem _skinBtn;

        // MainMenu: Preferences : Language
        private ToolStripMenuItem _russianBtn;
        private ToolStripMenuItem _englishBtn;

        // MainMenu: Preferences : Skin
        private ToolStripMenuItem _lightBtn;
        private ToolStripMenuItem _darkBtn;


        // MainMenu: Help
        private ToolStripMenuItem _aboutBtn;

		public PMainMenu(IXCommand xCommand)
		{
			_xCommand = xCommand;


			// MainMenu
			_fileBtn = new ToolStripMenuItem(Localization.GetText("file_text_id"));
			_viewBtn = new ToolStripMenuItem(Localization.GetText("view_text_id"));
			_pluginsBtn = new ToolStripMenuItem(Localization.GetText("plugins_text_id"));
			_tabsBtn = new ToolStripMenuItem(Localization.GetText("tabs_text_id"));
			_propertiesBtn = new ToolStripMenuItem(Localization.GetText("properties_text_id"));
			_preferencesBtn = new ToolStripMenuItem(Localization.GetText("preferences_text_id"));
			_helpBtn = new ToolStripMenuItem(Localization.GetText("help_text_id"));

			// MainMenu: File
			_newBtn = new ToolStripMenuItem(Localization.GetText("new_text_id"), null, delegate { _xCommand.New(); });
			_openBtn = new ToolStripMenuItem(Localization.GetText("open_text_id"), null, delegate { _xCommand.FileOpen(); });
			_saveBtn = new ToolStripMenuItem(Localization.GetText("save_text_id"), null, delegate { _xCommand.FileSave(); });
			_saveAsBtn = new ToolStripMenuItem(Localization.GetText("save_as_text_id"), null, delegate { _xCommand.FileSaveAs(); });
			_closeTabBtn = new ToolStripMenuItem(Localization.GetText("close_tab_text_id"), null, delegate { _xCommand.CloseTab(); });
			_renameTabBtn = new ToolStripMenuItem(Localization.GetText("rename_tab_text_id"), null, delegate { _xCommand.RenameTab(); });
			_openFromCloudBtn = new ToolStripMenuItem(Localization.GetText("open_from_cloud_text_id"), null, delegate { _xCommand.OpenFromCloud(); });
			_saveInCloudBtn = new ToolStripMenuItem(Localization.GetText("save_in_text_id"), null, delegate { _xCommand.SaveInCloud(); });
			_exitBtn = new ToolStripMenuItem(Localization.GetText("exit_text_id"), null, delegate { _xCommand.Exit(); });

			// MainMenu: View
			_elementsBtn = new ToolStripMenuItem(Localization.GetText("elements_text_id"), null, delegate { });
			_propertiesFileBtn = new ToolStripMenuItem(Localization.GetText("properties_text_id"), null, delegate { });

			// MainMenu: Plug-ins
			_formatsBtn = new ToolStripMenuItem(Localization.GetText("formats_text_id"));
			_elementsPluginsBtn = new ToolStripMenuItem(Localization.GetText("elements_text_id"));


			// MainMenu: Plug-ins : Formats
			//_json = new ToolStripMenuItem(Localization.GetText("json_text_id"), null, delegate { _xCommand.AddJSON(); });
			//_yaml = new ToolStripMenuItem(Localization.GetText("yaml_text_id"), null, delegate { _xCommand.AddYAML(); });
			//_xml = new ToolStripMenuItem(Localization.GetText("xml_text_id"), null, delegate { _xCommand.AddXML(); });
			//_bin = new ToolStripMenuItem(Localization.GetText("bin_text_id"), null, delegate { _xCommand.AddBIN(); });

			// MainMenu: Plug-ins : Elements
			_emptyFigure = new ToolStripMenuItem(Localization.GetText("empty_figure_text_id"), null, delegate { _xCommand.EmptyFigure(); });


			// MainMenu: Tabs
			_closeAllBtn = new ToolStripMenuItem(Localization.GetText("close_all_text_id"));

			// MainMenu: Properties
			_figureBtn = new ToolStripMenuItem(Localization.GetText("figure_text_id"));

			// MainMenu: Properties : Figure
			_figureTypesBtn = new ToolStripMenuItem(Localization.GetText("types_text_id"));
			_figureLineWidthBtn = new ToolStripMenuItem(Localization.GetText("line_width_text_id"));
			_figureColorBtn = new ToolStripMenuItem(Localization.GetText("color_text_id"), null, delegate
			{
				try
				{
					_xCommand.SetColor(Utilities.GetColor());
				}
				catch { }
			});

            // MainMenu: Properties : Figure : Types
            _lineBtn = new ToolStripMenuItem(Localization.GetText("line_text_id"), null, delegate { _xCommand.SetType(XData.FigureType.Line); });
            _rectangleBtn = new ToolStripMenuItem(Localization.GetText("rectangle_text_id"), null, delegate { _xCommand.SetType(XData.FigureType.Rectangle); });
            _ellipseBtn = new ToolStripMenuItem(Localization.GetText("ellipse_text_id"), null, delegate { _xCommand.SetType(XData.FigureType.Ellipse); });
            _roundedRectangleBtn = new ToolStripMenuItem(Localization.GetText("rounded_rectangle_text_id"), null, delegate { _xCommand.SetType(XData.FigureType.RoundRectangle); });

            // MainMenu: Properties : Figure : Line Width
            _width1Btn = new ToolStripMenuItem("1", null, delegate { _xCommand.SetLineWidth(1); });
			_width3Btn = new ToolStripMenuItem("3", null, delegate { _xCommand.SetLineWidth(3); });
			_width5Btn = new ToolStripMenuItem("5", null, delegate { _xCommand.SetLineWidth(5); });
			_width10Btn = new ToolStripMenuItem("10", null, delegate { _xCommand.SetLineWidth(10); });
			_width15Btn = new ToolStripMenuItem("15", null, delegate { _xCommand.SetLineWidth(15); });
            _width20Btn = new ToolStripMenuItem("20", null, delegate { _xCommand.SetLineWidth(20); });

            // MainMenu: Preferences
            _languageBtn = new ToolStripMenuItem(Localization.GetText("language_text_id"));
            _skinBtn = new ToolStripMenuItem(Localization.GetText("skin_text_id"));

            // MainMenu: Preferences : Language
            _russianBtn = new ToolStripMenuItem(Localization.GetText("russian_text_id"), null, delegate { _xCommand.RussianLanguage(); });
            _englishBtn = new ToolStripMenuItem(Localization.GetText("english_text_id"), null, delegate { _xCommand.EnglishLanguage(); });

            // MainMenu: Preferences : Skin
            _lightBtn = new ToolStripMenuItem(Localization.GetText("light_text_id"), null, delegate { _xCommand.LightSkin(); });
            _darkBtn = new ToolStripMenuItem(Localization.GetText("dark_text_id"), null, delegate { _xCommand.DarkSkin(); });


            // MainMenu: Help
            _aboutBtn = new ToolStripMenuItem(Localization.GetText("about_text_id"), null, delegate { _xCommand.ShowAbout(); });

			FillMenu();

			Localization.OnLocalChange += Localization_OnLocalChange;
			_xCommand.OnFigurePluginChanged += _xCommand_OnFigurePluginChanged;
            SkinController.OnSkinChange += SkinController_OnSkinChange;
        }

		private void _xCommand_OnFigurePluginChanged()
		{
			_propertiesBtn.DropDownItems.Clear();

			if (_xCommand.ActiveFigurePlugin != null)
				_propertiesBtn.DropDownItems.Add(_xCommand.ActiveFigurePlugin.GetMenuStrip());

			_propertiesBtn.DropDownItems.Add(_figureBtn);
		}

		private void FillMenu()
		{
			Items.Clear();

			// MainMenu
			Items.Add(_fileBtn);
			Items.Add(_viewBtn);
			Items.Add(_pluginsBtn);
			Items.Add(_tabsBtn);
			Items.Add(_propertiesBtn);
			Items.Add(_preferencesBtn);
			Items.Add(_helpBtn);

			// MainMenu: FileItems
			_fileBtn.DropDownItems.Add(_newBtn);
			_fileBtn.DropDownItems.Add(_openBtn);
			_fileBtn.DropDownItems.Add(_saveBtn);
			_fileBtn.DropDownItems.Add(_saveAsBtn);
			_fileBtn.DropDownItems.Add(_closeTabBtn);
			_fileBtn.DropDownItems.Add(_renameTabBtn);
			_fileBtn.DropDownItems.Add(new ToolStripSeparator());
			_fileBtn.DropDownItems.Add(_openFromCloudBtn);
			_fileBtn.DropDownItems.Add(_saveInCloudBtn);
			_fileBtn.DropDownItems.Add(new ToolStripSeparator());
			_fileBtn.DropDownItems.Add(_exitBtn);

			// MainMenu: ViewItems
			_viewBtn.DropDownItems.Add(_elementsBtn);
			_viewBtn.DropDownItems.Add(_propertiesFileBtn);

			// MainMenu: Plug-insItems
			_pluginsBtn.DropDownItems.Add(_formatsBtn);
			_pluginsBtn.DropDownItems.Add(_elementsPluginsBtn);

			// MainMenu: Plug-ins : FormatsItems
			foreach (IPluginFile plugin in _xCommand.FilePlugins)
			{
				_formatsBtn.DropDownItems.Add(plugin.Name);
			}

			// MainMenu: Plug-ins : ElementsItems
			_elementsPluginsBtn.DropDownItems.Add(_emptyFigure);
			_emptyFigure.Checked = true;

			foreach (IPluginFigure plugin in _xCommand.FigurePlugins)
			{
				var toolStripMenuItem = new ToolStripMenuItem(plugin.Name, null, delegate { _xCommand.TogglePlugin(plugin); });
				toolStripMenuItem.CheckOnClick = true;
				_elementsPluginsBtn.DropDownItems.Add(toolStripMenuItem);
			}

			// MainMenu: Tabs
			_tabsBtn.DropDownItems.Add(new ToolStripSeparator());
			_tabsBtn.DropDownItems.Add(_closeAllBtn);

			// MainMenu: Properties
			_propertiesBtn.DropDownItems.Add(_figureBtn);

			// MainMenu: Properties : Figure
			_figureBtn.DropDownItems.Add(_figureTypesBtn);
			_figureBtn.DropDownItems.Add(_figureLineWidthBtn);
			_figureBtn.DropDownItems.Add(_figureColorBtn);

			// MainMenu: Properties : Figure : Types
			_figureTypesBtn.DropDownItems.Add(_lineBtn);
			_figureTypesBtn.DropDownItems.Add(_rectangleBtn);
			_figureTypesBtn.DropDownItems.Add(_ellipseBtn);
			_figureTypesBtn.DropDownItems.Add(_roundedRectangleBtn);
			_lineBtn.Checked = true;

			// MainMenu: Properties : Figure : Line Width
			_figureLineWidthBtn.DropDownItems.Add(_width1Btn);
			_figureLineWidthBtn.DropDownItems.Add(_width3Btn);
			_figureLineWidthBtn.DropDownItems.Add(_width5Btn);
			_figureLineWidthBtn.DropDownItems.Add(_width10Btn);
			_figureLineWidthBtn.DropDownItems.Add(_width15Btn);
			_figureLineWidthBtn.DropDownItems.Add(_width20Btn);
			_width1Btn.Checked = true;

			// MainMenu: PreferencesItems
			_preferencesBtn.DropDownItems.Add(_languageBtn);
			_preferencesBtn.DropDownItems.Add(_skinBtn);

			// MainMenu: Preferences : Language
			_languageBtn.DropDownItems.Add(_russianBtn);
			_languageBtn.DropDownItems.Add(_englishBtn);
			_englishBtn.Checked = true;

			// MainMenu: Preferences : Skin
			_skinBtn.DropDownItems.Add(_lightBtn);
			_skinBtn.DropDownItems.Add(_darkBtn);
			_lightBtn.Checked = true;

			// MainMenu: HelpItems
			_helpBtn.DropDownItems.Add(_aboutBtn);
		}

		private void Localization_OnLocalChange()
		{
            // MainMenu
            _fileBtn.Text = Localization.GetText("file_text_id");
            _viewBtn.Text = Localization.GetText("view_text_id");
            _pluginsBtn.Text = Localization.GetText("plugins_text_id");
            _tabsBtn.Text = Localization.GetText("tabs_text_id");
            _propertiesBtn.Text = Localization.GetText("properties_text_id");
            _preferencesBtn.Text = Localization.GetText("preferences_text_id");
            _helpBtn.Text = Localization.GetText("help_text_id");

            // MainMenu: FileItems
            _newBtn.Text = Localization.GetText("new_text_id");
            _openBtn.Text = Localization.GetText("open_text_id");
            _saveBtn.Text = Localization.GetText("save_text_id");
            _saveAsBtn.Text = Localization.GetText("save_as_text_id");
            _closeTabBtn.Text = Localization.GetText("close_tab_text_id");
            _renameTabBtn.Text = Localization.GetText("rename_tab_text_id");
            _openFromCloudBtn.Text = Localization.GetText("open_from_cloud_text_id");
            _saveInCloudBtn.Text = Localization.GetText("save_in_text_id");
            _exitBtn.Text = Localization.GetText("exit_text_id");

            // MainMenu: View
            _elementsBtn.Text = Localization.GetText("elements_text_id");
            _propertiesFileBtn.Text = Localization.GetText("properties_text_id");

            // MainMenu: Plug-insItems
            _formatsBtn.Text = Localization.GetText("formats_text_id");
            _elementsPluginsBtn.Text = Localization.GetText("elements_text_id");

            // MainMenu: Plug-ins : ElementsItems
            _emptyFigure.Text = Localization.GetText("empty_figure_text_id");


            // MainMenu: Tabs
            _closeAllBtn.Text = Localization.GetText("close_all_text_id");

            // MainMenu: Properties
            _figureBtn.Text = Localization.GetText("figure_text_id");

            // MainMenu: Properties : Figure
            _figureTypesBtn.Text = Localization.GetText("types_text_id");
            _figureLineWidthBtn.Text = Localization.GetText("line_width_text_id");
            _figureColorBtn.Text = Localization.GetText("color_text_id");

            // MainMenu: Properties : Figure : Types
            _lineBtn.Text = Localization.GetText("line_text_id");
            _rectangleBtn.Text = Localization.GetText("rectangle_text_id");
            _ellipseBtn.Text = Localization.GetText("ellipse_text_id");
            _roundedRectangleBtn.Text = Localization.GetText("rounded_rectangle_text_id");

            // MainMenu: PreferencesItems
            _languageBtn.Text = Localization.GetText("language_text_id");
            _skinBtn.Text = Localization.GetText("skin_text_id");


            // MainMenu: Preferences : Language
            _russianBtn.Text = Localization.GetText("russian_text_id");
            _englishBtn.Text = Localization.GetText("english_text_id");

            // MainMenu: Preferences : Skin
            _lightBtn.Text = Localization.GetText("light_text_id");
            _darkBtn.Text = Localization.GetText("dark_text_id");


            // MainMenu: HelpItems
            _aboutBtn.Text = Localization.GetText("about_text_id");
        }
        private void SkinController_OnSkinChange()
        {
            BackColor = SkinController.GetColor("primaryColor");
            ForeColor = SkinController.GetColor("primaryTextColor");
            foreach(ToolStripMenuItem item in this.Items)
            {
                //item.DropDown.BackColor = SkinController.GetColor("primaryTextColor");
                //item.BackColor = SkinController.GetColor("primaryTextColor");
            }
        }
    }
}
