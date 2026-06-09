using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class AdministradorUserControl : UserControl
    {
        private Form1 _form;
        public void SetForm(Form1 form)
        {
            _form = form;
        }
        public AdministradorUserControl()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _form.MostrarUserControl(new MenuUserControl());
        }

        private void btnVolver_MouseEnter(object sender, EventArgs e)
        {
            btnVolver.ForeColor = Color.Yellow;
        }

        private void btnVolver_MouseLeave(object sender, EventArgs e)
        {
            btnVolver.ForeColor = Color.White;
        }
    }
}
