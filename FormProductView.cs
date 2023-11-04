using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_Entry
{
    public partial class FormProductView : Form
    {
        public FormProductView()
        {
            InitializeComponent();
        }
        public static List<Product> lst = new List<Product>();
        public BindingSource bs;
        private void FormProductView_Load(object sender, EventArgs e)
        {
            lst.AddRange(new[]
            {
                new Product("P1", "Tiger Beer Cans 330ml", 16.7),
                new Product("P2", "Honda Dream 125cc", 2750),
                new Product("P3", "Cowhead Pure milk 1L", 2.5),
            });
            bs = new BindingSource(lst, null);
            dgvProductView.DataSource = bs;
            dgvProductView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvProductView.AllowUserToAddRows = false;
            dgvProductView.ReadOnly = true;
            dgvProductView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bs.ResetBindings(false);
            dgvProductView.Columns["Info"].Visible = false;
            var tempVar = dgvProductView.Columns["ValidData"];
            tempVar.DisplayIndex = 0;
            tempVar.HeaderText = "Valid?";
            dgvProductView.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductView.Columns["Price"].DefaultCellStyle.Format = "#,0.00";
            lblInfo.DataBindings.Add("Text", bs, "Info");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormAddEdit(this, lst, true).Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new FormAddEdit(this, lst, false).Show();
        }
    }
}
