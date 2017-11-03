using Painter.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.Views
{
    public class PToolBar : ToolStrip
    {
        private IXCommand _xCommand;

        ToolStripButton newBtn;
        ToolStripButton openBtn;
        ToolStripButton saveBtn;
        ToolStripButton loadCloudBtn;
        ToolStripButton saveCloudBtn;

        ToolStripComboBox typeCb;
        ToolStripComboBox widthCb;

        ToolStripButton colorBtn;

        public PToolBar(IXCommand xCommand)
        {
            _xCommand = xCommand;

            newBtn = new ToolStripButton(Localization.GetText("new_text_id"), null);
            openBtn = new ToolStripButton(Localization.GetText("open_text_id"), null);
            saveBtn = new ToolStripButton(Localization.GetText("save_text_id"), null);
            loadCloudBtn = new ToolStripButton(Localization.GetText("open_from_cloud_text_id"), null);
            saveCloudBtn = new ToolStripButton(Localization.GetText("save_in_text_id"), null);

            typeCb = new ToolStripComboBox();
            widthCb = new ToolStripComboBox();

            colorBtn = new ToolStripButton(Localization.GetText("color_text_id"), null);


            Items.Add(newBtn);
            Items.Add(openBtn);
            Items.Add(saveBtn);
            Items.Add(loadCloudBtn);
            Items.Add(saveCloudBtn);
            Items.Add(typeCb);
            Items.Add(widthCb);
            Items.Add(colorBtn);

            Localization.OnLocalChange += Localization_OnLocalChange;
            SkinController.OnSkinChange += SkinController_OnSkinChange;
        }

        private void Localization_OnLocalChange()
        {
            newBtn.Text = Localization.GetText("new_text_id");
            openBtn.Text = Localization.GetText("open_text_id");
            saveBtn.Text = Localization.GetText("save_text_id");
            loadCloudBtn.Text = Localization.GetText("open_from_cloud_text_id");
            saveCloudBtn.Text = Localization.GetText("save_in_text_id");
            colorBtn.Text = Localization.GetText("color_text_id");
        }

        private void SkinController_OnSkinChange()
        {
            BackColor = SkinController.GetColor("primaryColor");
            ForeColor = SkinController.GetColor("primaryTextColor");
        }
    }
}
