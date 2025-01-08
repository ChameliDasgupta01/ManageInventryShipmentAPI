using WFManageInventryShipment.APIServices;
using WFManageInventryShipment.DataModels;

namespace WFManageInventryShipment
{
    public partial class ManageInventryShimpent :Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgProducts = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtPrice = new TextBox();
            txtProductInStock = new TextBox();
            txtProductDesc = new TextBox();
            txtProductNm = new TextBox();
            txtProductId = new TextBox();
            btnLoad = new Button();
            btnAddProduct = new Button();
            btnUpdateProduct = new Button();
            btnDelete = new Button();
            errorProvider1 = new ErrorProvider(components);
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dgProducts).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // dgProducts
            // 
            dgProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgProducts.Location = new Point(28, 269);
            dgProducts.Name = "dgProducts";
            dgProducts.RowTemplate.Height = 25;
            dgProducts.Size = new Size(692, 183);
            dgProducts.TabIndex = 0;
            dgProducts.CellContentClick += dgProducts_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 1);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 1;
            label1.Text = "Product ID :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 143);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Price  :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 110);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 3;
            label3.Text = "Quantity in stock :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 73);
            label4.Name = "label4";
            label4.Size = new Size(118, 15);
            label4.TabIndex = 4;
            label4.Text = "Product Description :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 34);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 5;
            label5.Text = "Product Name :";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.2391319F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.76087F));
            tableLayoutPanel1.Controls.Add(txtPrice, 1, 4);
            tableLayoutPanel1.Controls.Add(txtProductInStock, 1, 3);
            tableLayoutPanel1.Controls.Add(txtProductDesc, 1, 2);
            tableLayoutPanel1.Controls.Add(txtProductNm, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 4);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(label5, 0, 1);
            tableLayoutPanel1.Controls.Add(txtProductId, 1, 0);
            tableLayoutPanel1.Location = new Point(28, 27);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45.8333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 54.1666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.Size = new Size(369, 178);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(130, 146);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(214, 23);
            txtPrice.TabIndex = 5;
            // 
            // txtProductInStock
            // 
            txtProductInStock.Location = new Point(130, 113);
            txtProductInStock.Name = "txtProductInStock";
            txtProductInStock.Size = new Size(214, 23);
            txtProductInStock.TabIndex = 4;
            // 
            // txtProductDesc
            // 
            txtProductDesc.Location = new Point(130, 76);
            txtProductDesc.Name = "txtProductDesc";
            txtProductDesc.Size = new Size(214, 23);
            txtProductDesc.TabIndex = 3;
            // 
            // txtProductNm
            // 
            txtProductNm.Location = new Point(130, 37);
            txtProductNm.Name = "txtProductNm";
            txtProductNm.Size = new Size(214, 23);
            txtProductNm.TabIndex = 2;
            // 
            // txtProductId
            // 
            txtProductId.AcceptsTab = true;
            txtProductId.Enabled = false;
            txtProductId.Location = new Point(130, 4);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(96, 23);
            txtProductId.TabIndex = 1;
            txtProductId.Text = "0";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(386, 212);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(113, 31);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "Load Products";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(47, 211);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(103, 32);
            btnAddProduct.TabIndex = 8;
            btnAddProduct.Text = "Add Product";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnUpdateProduct
            // 
            btnUpdateProduct.Location = new Point(158, 211);
            btnUpdateProduct.Name = "btnUpdateProduct";
            btnUpdateProduct.Size = new Size(103, 32);
            btnUpdateProduct.TabIndex = 9;
            btnUpdateProduct.Text = "Update Product";
            btnUpdateProduct.UseVisualStyleBackColor = true;
            btnUpdateProduct.Click += btnUpdateProduct_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(267, 212);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(113, 31);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete Product";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(505, 212);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(103, 32);
            btnReset.TabIndex = 11;
            btnReset.Text = "Reset Form";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // ManageInventryShimpent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReset);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdateProduct);
            Controls.Add(btnAddProduct);
            Controls.Add(btnLoad);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(dgProducts);
            Name = "ManageInventryShimpent";
            Text = "Form1";
            Load += ManageInventryShimpent_Load;
            ((System.ComponentModel.ISupportInitialize)dgProducts).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgProducts;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtPrice;
        private TextBox txtProductInStock;
        private TextBox txtProductDesc;
        private TextBox txtProductNm;
        private TextBox txtProductId;
        private Button btnLoad;
        private Button btnAddProduct;
        private Button btnUpdateProduct;
        private Button btnDelete;
        private ErrorProvider errorProvider1;
        private Button btnReset;
    }
}
