using System;
using System.Drawing;
using System.Windows.Forms;
using NetworkSpy.Properties;

namespace NetworkSpy.Services
{
    public class NotifyIconService
    {
        public NotifyIcon NotifyIconInstance { get; set; }
        public NotifyIconService()
        {
            NotifyIconInstance = new NotifyIcon
            {
                Icon = Resources.MainPage_logo,
                Text = Resources.ProjectName,
                Visible = true
            };
        }

        public void AddMenuItem(string name, Image image = null, EventHandler eventHandler = null)
        {
            NotifyIconInstance.ContextMenuStrip ??= new ContextMenuStrip() {ShowCheckMargin = true};

            NotifyIconInstance.ContextMenuStrip.Items.Add(name, image, eventHandler);
        }
    }
}
