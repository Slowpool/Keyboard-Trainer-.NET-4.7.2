using System.Windows.Forms;

namespace Keyboard_Trainer
{
    public class FullScreen
    {
        private readonly Form form;

        public bool IsFullScreenNow { get; set; }

        public FullScreen(Form form)
        {
            this.form = form;
            IsFullScreenNow = false;
        }

        public void Enable()
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;
            IsFullScreenNow = true;
        }

        public void Disable()
        {
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.WindowState = FormWindowState.Normal;
            IsFullScreenNow = false;
        }
    }
}