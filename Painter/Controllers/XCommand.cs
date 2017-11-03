﻿using Painter.Models;
using Painter.Views;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Painter.Controllers
{
	public class XCommand : IXCommand
	{	
		private IPluginFigure _activePlugin = null;
		private PluginManager _pluginManager = null;
        private PFigure _activeFigure = null;

		public TabControl TabControl { get; set; }
		public PFigure ActiveFigure
        {
            get => _activeFigure;
            set
            {
                _activeFigure = value;
                if (_activePlugin != null)
                    _activePlugin.ActiveFigure = _activeFigure;
            }
        }
		public IPluginFigure ActiveFigurePlugin { get => _activePlugin; set { _activePlugin = value; OnFigurePluginChanged(); } }
		public List<IPluginFigure> FigurePlugins { get => _pluginManager.figurePlugins; }
		public List<IPluginFile> FilePlugins { get => _pluginManager.formatPlugins; }

		public event Action OnFigurePluginChanged;

		public PFigure PluginProcess(PFigure figure)
		{
			if (_activePlugin == null)
				return figure;
			return _activePlugin.Process(figure);
		}

		public void New()
		{
			PDraw pDraw = new PDraw(this);
			pDraw.Text = "New tab";
			TabControl.TabPages.Add(pDraw);
			TabControl.SelectedTab = pDraw;
		}

		public void FileOpen()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				var extension = Path.GetExtension(openFileDialog.FileName);
				using (Stream stream = File.Open(openFileDialog.FileName, FileMode.Open))
				{
					using (var streamReader = new StreamReader(stream))
					{
						MTab mTab = FilePlugins.Find((x) => x.Name.ToLower() == extension.Substring(1)).Deserialize(streamReader.ReadToEnd());

						PDraw pDraw = new PDraw(this);
						pDraw.SetMemento(mTab);
						TabControl.TabPages.Add(pDraw);
						TabControl.SelectedTab = pDraw;
					}
				}
			}
		}

		public void FileSave()
		{
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "";
            foreach (var plugin in FilePlugins)
            {
                //if (plugin.Enabled == true)
                saveFileDialog.Filter += plugin.Name + "|*." + plugin.Name.ToLower();
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var extension = Path.GetExtension(saveFileDialog.FileName);
                using (Stream stream = File.Open(saveFileDialog.FileName, FileMode.Create))
                {
                    using (var streamWritter = new StreamWriter(stream))
                    {
                        streamWritter.Write(
                            FilePlugins.Find((x) => x.Name.ToLower() == extension.Substring(1)).Serialize((TabControl.SelectedTab as PDraw).GetMemento())
                        );
                    }
                }
            }
        }

		public void FileSaveAs()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "";
			foreach (var plugin in FilePlugins)
			{
				//if (plugin.Enabled == true)
					saveFileDialog.Filter += plugin.Name + "|*." + plugin.Name.ToLower();
			}
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				var extension = Path.GetExtension(saveFileDialog.FileName);
				using (Stream stream = File.Open(saveFileDialog.FileName, FileMode.Create))
				{
					using (var streamWritter = new StreamWriter(stream))
					{
						streamWritter.Write(
							FilePlugins.Find((x) => x.Name.ToLower() == extension.Substring(1)).Serialize((TabControl.SelectedTab as PDraw).GetMemento())
						);
					}
				}
			}
		}

		public void CloseTab()
		{
            TabControl.TabPages.Remove(TabControl.SelectedTab);

        }

		public void RenameTab()
		{
            var showDialog = this.ShowDialog("Tab Name", "Rename the selected tab");
            TabControl.SelectedTab.Text = showDialog;
        }

        public string ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();
            return textBox.Text;
        }

        public void OpenFromCloud()
		{
			throw new NotImplementedException();
		}

		public void SaveInCloud()
		{
			throw new NotImplementedException();
		}

		public void Exit()
		{
            Application.Exit();
        }

		public void ShowAbout()
		{
			throw new NotImplementedException();
		}

		public void EmptyFigure()
		{
			throw new NotImplementedException();
		}

		public void RussianLanguage()
		{
            Localization.Locale = "ru";
		}

		public void EnglishLanguage()
		{
            Localization.Locale = "en";
        }

        public void LightSkin()
		{
            SkinController.Skin = "light";
        }

        public void DarkSkin()
		{
            SkinController.Skin = "dark";
		}

		public void ToggleVisible(Control control)
		{
			control.Visible = !control.Visible;
		}

		public void SetType(XData.FigureType type)
		{
			if (ActiveFigure == null)
                (TabControl.SelectedTab as PDraw)._xData.type = type;
			else
				ActiveFigure.Type = type;
		}

		public void SetColor(Color color)
		{
			if (ActiveFigure == null)
                (TabControl.SelectedTab as PDraw)._xData.color = color;
			else
				ActiveFigure.Color = color;
		}

		public void SetLineWidth(int width)
		{
			if (ActiveFigure == null)
                (TabControl.SelectedTab as PDraw)._xData.lineWidth = width;
			else
				ActiveFigure.LineWidth = width;
		}

		public void TogglePlugin(IPluginFigure plugin)
		{
			plugin.Enabled = !plugin.Enabled;
		}

		public void InitializePluginManager()
		{

			_pluginManager = new PluginManager();
		}

    }
}