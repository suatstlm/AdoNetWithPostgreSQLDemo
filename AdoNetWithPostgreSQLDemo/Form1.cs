namespace AdoNetWithPostgreSQLDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                product_name = tbxName.Text,
                unit_price = Convert.ToDecimal(tbxUnitPrice.Text),
                stock_amount = Convert.ToInt32(tbxStockAmount.Text)
            } );

            LoadProducts();
            MessageBox.Show("Product Added.");
        }
        private void LoadProducts()
        {
            dgwProduct.DataSource = _productDal.GetAll();
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProduct.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProduct.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProduct.CurrentRow.Cells[3].Value.ToString();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                product_id = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value.ToString()),
                product_name = tbxNameUpdate.Text,
                unit_price = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                stock_amount = Convert.ToInt32(tbxStockAmountUpdate.Text)
            });

            LoadProducts();
            MessageBox.Show("Product Updated.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value.ToString()));

            LoadProducts();
            MessageBox.Show("Product Deleted");
        }
    }
}