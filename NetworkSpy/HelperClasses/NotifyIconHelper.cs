using System.Windows.Forms;
using NetworkSpy.Properties;

namespace NetworkSpy.HelperClasses
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
    }
}
