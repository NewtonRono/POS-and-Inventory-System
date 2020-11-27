using System.Windows.Forms;

namespace POS_and_Inventory_System
{
    class Util
    {
        public static bool canShow = true;
        public static void ShowFormInPanel(Form _frm, Panel _pnl)
        {
            if (canShow)
            {
                _frm.TopLevel = false;
                _pnl.Controls.Add(_frm);
                _frm.BringToFront();
                _frm.Show();
                canShow = false;
            }
        }

        public static void CloseForm(Form _frm)
        {
            _frm.Dispose();
            canShow = true;
        }
    }
}
