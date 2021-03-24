using System;
using System.Drawing;
using System.Windows.Forms;
using NetworkSpy.Properties;

namespace NetworkSpy.Services
{
    public static class NotifyIconHelper
    {
        public static NotifyIcon CreateNotifyIcon()
        {
            return new()
            {
                Icon = Resources.MainPage_logo,
                Text = Resources.ProjectName,
                Visible = true
            };
        }

        public static void AddMenuItem(NotifyIcon icon, string name, Image image = null, EventHandler eventHandler = null)
        {
            icon.ContextMenuStrip ??= new() {ShowCheckMargin = true};

            icon.ContextMenuStrip.Items.Add(name, image, eventHandler);
        }
    }
}
