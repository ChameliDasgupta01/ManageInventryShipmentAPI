using System.Windows.Forms;
using System.Xml.Linq;
using WFManageInventryShipment.APIServices;
using WFManageInventryShipment.DataModels;

namespace WFManageInventryShipment
{
    /// <summary>
    /// Inventry shipment form
    /// </summary>
    partial class ManageInventryShimpent : Form
    {
        private ProductService productService;
        private List<Product> products;
        private Product product;
        // Step 1: Declare an instance of ErrorProvider
        private ErrorProvider errorProvider = new ErrorProvider();

        public ManageInventryShimpent()
        {
            InitializeComponent();
            productService = new ProductService();
            product = new Product();
            products = new List<Product>();
        }

        /// <summary>
        /// Load all products on the gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProducts();

        }

        /// <summary>
        /// Validate all the inputs from the form
        /// </summary>
        /// <returns></returns>
        private bool ValidateInput()
        {
            // Reset errors on button click
            errorProvider.Clear();

            // Validate required fields
            bool isValid = true;

            // Example: Check if a text box is empty
            if (string.IsNullOrWhiteSpace(txtProductNm.Text))
            {
                // Show error message on the TextBox
                errorProvider.SetError(txtProductNm, "Name cannot be empty.");
                isValid = false;
            }
            else
            {
                // Clear the error message
                errorProvider.SetError(txtProductNm, "");
            }

            if (string.IsNullOrWhiteSpace(txtProductDesc.Text))
            {
                // Show error message on the TextBox
                errorProvider.SetError(txtProductDesc, "Product Description cannot be empty.");
                isValid = false;
            }
            else
            {
                // Clear the error message
                errorProvider.SetError(txtProductDesc, "");
            }

            if (string.IsNullOrWhiteSpace(txtProductInStock.Text))
            {
                // Show error message on the TextBox
                errorProvider.SetError(txtProductInStock, "Product in stock can not be empty put it 0.");
                isValid = false;

            }
            else if (!int.TryParse(txtProductInStock.Text, out int intValue))
            {
                errorProvider.SetError(txtProductInStock, "Invalid input. Please enter an integer.");
                isValid = false;
            }
            else
            {
                // Clear the error message
                errorProvider.SetError(txtProductInStock, "");

            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                // Show error message on the TextBox
                errorProvider.SetError(txtPrice, "Product price can not be empty.");
                isValid = false;
            }
            else if (!decimal.TryParse(txtPrice.Text, out decimal decValue))
            {
                // Check if the input is a valid decimal
                errorProvider.SetError(txtPrice, "Invalid input. Please enter a decimal.");
                isValid = false;
            }
            else
            {
                // Clear the error message
                errorProvider.SetError(txtPrice, "");
            }
            return isValid;
        }

        /// <summary>
        /// Async call to retrive the list of products
        /// </summary>
        private async void LoadProducts()
        {
            products = await productService.GetAllProductsAsync();
            dgProducts.DataSource = products;
        }


        /// <summary>
        /// Load product details info on the details form
        /// </summary>
        /// <param name="selectedProduct"></param>
        private void LoadIntoProductDetailForm(Product selectedProduct)
        {
            txtProductId.Text = selectedProduct.ProductId.ToString();
            txtProductNm.Text = selectedProduct.ProductName.ToString();
            txtProductDesc.Text = selectedProduct.ProductDescription.ToString();
            txtProductInStock.Text = selectedProduct.Quantityinstock.ToString();
            txtPrice.Text = selectedProduct.Price.ToString();
        }

        /// <summary>
        /// Event fire for add button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                AddProduct();
            }

        }

        /// <summary>
        /// Rest the form
        /// </summary>
        private void ResetForm()
        {
            txtProductNm.Text = "";
            txtProductId.Text = "0";
            txtProductDesc.Text = "";
            txtProductInStock.Text = "0";
            txtPrice.Text = "0";

        }

        /// <summary>
        /// Add product method called from button click
        /// </summary>
        private async void AddProduct()
        {

            ResetForm();
            var newProduct = new Product
            {
                ProductId = 0,
                ProductName = txtProductNm.Text,
                ProductDescription = txtProductDesc.Text,
                Quantityinstock = int.Parse(txtProductInStock.Text),
                Price = decimal.Parse(txtPrice.Text)
            };

            var addedProduct = await productService.AddProductAsync(newProduct);
            products.Add(addedProduct);
            dgProducts.DataSource = null;
            dgProducts.DataSource = products;

            // Example: If the submission is successful, show a success message.
            MessageBox.Show("Submission successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Update the product after validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            //var selectedRow = dgProducts.SelectedRows;
            //var productId = (int)selectedRow.Cells[0].Value; // Assuming the ID is in the first column

            if (ValidateInput())
            {
                UpdateProduct();
            }


        }

        /// <summary>
        /// Async method call for update
        /// </summary>
        private async void UpdateProduct()
        {
            var updatedProduct = new Product
            {
                ProductId = int.Parse(txtProductId.Text),
                ProductName = txtProductNm.Text,
                ProductDescription = txtProductDesc.Text,
                Quantityinstock = int.Parse(txtProductInStock.Text),
                Price = decimal.Parse(txtPrice.Text)
            };

            var updated = await productService.UpdateProductAsync(updatedProduct);
            // Update the product in the local list
            var product = products.FirstOrDefault(p => p.ProductId == updated.ProductId);
            if (product != null)
            {
                product.ProductName = updated.ProductName;
                product.ProductDescription = updated.ProductDescription;
                product.Quantityinstock = updated.Quantityinstock;
                product.Price = updated.Price;
            }

            dgProducts.DataSource = null;
            dgProducts.DataSource = products;
            if (product != null)
            {
                MessageBox.Show("Update successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Peform the delete activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var success = await productService.DeleteProductAsync(int.Parse(txtProductId.Text));
            if (success)
            {
                products.RemoveAll(p => p.ProductId == int.Parse(txtProductId.Text));
                dgProducts.DataSource = null;
                dgProducts.DataSource = products;
                MessageBox.Show("Delete successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void ManageInventryShimpent_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row, not the header
            if (e.RowIndex >= 0)
            {
                // Retrieve the data from the selected row
                var selectedProduct = new Product
                {
                    ProductId = Convert.ToInt32(dgProducts.Rows[e.RowIndex].Cells["ProductId"].Value),
                    ProductName = dgProducts.Rows[e.RowIndex].Cells["ProductName"].Value.ToString(),
                    ProductDescription = dgProducts.Rows[e.RowIndex].Cells["ProductDescription"].Value.ToString(),
                    Quantityinstock = Convert.ToInt32(dgProducts.Rows[e.RowIndex].Cells["Quantityinstock"].Value),
                    Price = Convert.ToDecimal(dgProducts.Rows[e.RowIndex].Cells["Price"].Value)
                };

                LoadIntoProductDetailForm(selectedProduct);
            }
        }

        private void dgProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row, not the header
            if (e.RowIndex >= 0)
            {
                // Retrieve the data from the selected row
                var selectedProduct = new Product
                {
                    ProductId = Convert.ToInt32(dgProducts.Rows[e.RowIndex].Cells["ProductId"].Value),
                    ProductName = dgProducts.Rows[e.RowIndex].Cells["ProductName"].Value.ToString(),
                    ProductDescription = dgProducts.Rows[e.RowIndex].Cells["ProductDescription"].Value.ToString(),
                    Quantityinstock = Convert.ToInt32(dgProducts.Rows[e.RowIndex].Cells["Quantityinstock"].Value),
                    Price = Convert.ToDecimal(dgProducts.Rows[e.RowIndex].Cells["Price"].Value)
                };

                LoadIntoProductDetailForm(selectedProduct);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
