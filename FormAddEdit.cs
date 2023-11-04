using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Product_Entry
{
    public partial class FormAddEdit : Form
    {
        private FormProductView frmProductView;
        private List<Product> products;
        private Boolean clickAdd;
        public FormAddEdit(FormProductView frmProductView, List<Product> products, Boolean clickAdd)
        {
            InitializeComponent();
            this.frmProductView = frmProductView;
            this.products = products;
            this.clickAdd = clickAdd;
        }

        private void FormAddEdit_Load(object sender, EventArgs e)
        {
            if (clickAdd)
            {
                this.Text = "Add Products";
            }
            else
            {
                this.Text = "Edit Product";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            try
            {
                if (clickAdd)
                {
                    AddProduct();
                }
                else
                {
                    EditProduct();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToDataGridView()
        {
            BindingSource bs = new BindingSource(products, null);
            frmProductView.dgvProductView.DataSource = bs;
            frmProductView.lblInfo.DataBindings.Clear();
            frmProductView.lblInfo.DataBindings.Add("Text", bs, "Info");
        }

        private Boolean IsUniqueId(string Id)
        {
            foreach(Product product in products) { 
                if(product.Id == Id) return false;
            }
            return true;

        }

        private void AddProduct()
        {
            Product product = new Product();
            product.Add(txtId.Text, txtName.Text, Double.Parse(txtPrice.Text));
            if (product.ValidData)
            {
                if (IsUniqueId(product.Id))
                {
                    products.Add(product);
                    AddToDataGridView();
                    MessageBox.Show("A new row has been added!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Id is already taken!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditProduct()
        {
            Boolean hasChanged = false;
            Boolean hasFound = false;
            foreach (Product product in products)
            {
                //check each item id in the list to see if it's equal to input id
                if (product.Id == txtId.Text)
                {
                    //only change if current value is not equal to previous value
                    if (product.Name != txtName.Text || product.Price != double.Parse(txtPrice.Text))
                    {
                        product.Edit(txtName.Text, double.Parse(txtPrice.Text));
                        hasChanged = true;
                    }
                    hasFound = true;
                }

            }
            //if changed ,add all changed data and unchanged data back to datagridview
            if (hasChanged)
            {
                AddToDataGridView();
                MessageBox.Show("Data has been updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (!hasFound)
            {
                MessageBox.Show("Item not found!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
