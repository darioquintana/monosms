using System;
using System.Windows.Forms;

namespace Mono.Sms.Core.UI
{
    public class TextBoxOnlyNumbers : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            char backspace = '\b';

            if (Char.IsNumber(e.KeyChar) != true && e.KeyChar != backspace)
            {
                e.Handled = true;
            }
        }
    }
}