namespace EquipmentRental.WinForm
{
    partial class EquipmentInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cmbStatusFilter = new ComboBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnEdit = new Button();
            dgvEquipmentList = new DataGridView();
            courseDBContextBindingSource = new BindingSource(components);
            categoriesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            equipmentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            feedbacksDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rentalRequestsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rentalTransactionsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            returnRecordsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvEquipmentList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)courseDBContextBindingSource).BeginInit();
            SuspendLayout();
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new Point(25, 32);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(126, 29);
            cmbStatusFilter.TabIndex = 0;
            cmbStatusFilter.Text = "Filter by status";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(184, 32);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(307, 29);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Search...";
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(517, 28);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(115, 34);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += button1_Click;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEdit.Location = new Point(650, 28);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(109, 33);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // dgvEquipmentList
            // 
            dgvEquipmentList.AutoGenerateColumns = false;
            dgvEquipmentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipmentList.Columns.AddRange(new DataGridViewColumn[] { categoriesDataGridViewTextBoxColumn, equipmentDataGridViewTextBoxColumn, feedbacksDataGridViewTextBoxColumn, rentalRequestsDataGridViewTextBoxColumn, rentalTransactionsDataGridViewTextBoxColumn, returnRecordsDataGridViewTextBoxColumn });
            dgvEquipmentList.DataSource = courseDBContextBindingSource;
            dgvEquipmentList.Location = new Point(69, 86);
            dgvEquipmentList.Name = "dgvEquipmentList";
            dgvEquipmentList.RowTemplate.Height = 25;
            dgvEquipmentList.Size = new Size(645, 312);
            dgvEquipmentList.TabIndex = 4;
            // 
            // courseDBContextBindingSource
            // 
            courseDBContextBindingSource.DataSource = typeof(EquipmentLibrary.Model.CourseDBContext);
            // 
            // categoriesDataGridViewTextBoxColumn
            // 
            categoriesDataGridViewTextBoxColumn.DataPropertyName = "Categories";
            categoriesDataGridViewTextBoxColumn.HeaderText = "Categories";
            categoriesDataGridViewTextBoxColumn.Name = "categoriesDataGridViewTextBoxColumn";
            // 
            // equipmentDataGridViewTextBoxColumn
            // 
            equipmentDataGridViewTextBoxColumn.DataPropertyName = "Equipment";
            equipmentDataGridViewTextBoxColumn.HeaderText = "Equipment";
            equipmentDataGridViewTextBoxColumn.Name = "equipmentDataGridViewTextBoxColumn";
            // 
            // feedbacksDataGridViewTextBoxColumn
            // 
            feedbacksDataGridViewTextBoxColumn.DataPropertyName = "Feedbacks";
            feedbacksDataGridViewTextBoxColumn.HeaderText = "Feedbacks";
            feedbacksDataGridViewTextBoxColumn.Name = "feedbacksDataGridViewTextBoxColumn";
            // 
            // rentalRequestsDataGridViewTextBoxColumn
            // 
            rentalRequestsDataGridViewTextBoxColumn.DataPropertyName = "RentalRequests";
            rentalRequestsDataGridViewTextBoxColumn.HeaderText = "RentalRequests";
            rentalRequestsDataGridViewTextBoxColumn.Name = "rentalRequestsDataGridViewTextBoxColumn";
            // 
            // rentalTransactionsDataGridViewTextBoxColumn
            // 
            rentalTransactionsDataGridViewTextBoxColumn.DataPropertyName = "RentalTransactions";
            rentalTransactionsDataGridViewTextBoxColumn.HeaderText = "RentalTransactions";
            rentalTransactionsDataGridViewTextBoxColumn.Name = "rentalTransactionsDataGridViewTextBoxColumn";
            // 
            // returnRecordsDataGridViewTextBoxColumn
            // 
            returnRecordsDataGridViewTextBoxColumn.DataPropertyName = "ReturnRecords";
            returnRecordsDataGridViewTextBoxColumn.HeaderText = "ReturnRecords";
            returnRecordsDataGridViewTextBoxColumn.Name = "returnRecordsDataGridViewTextBoxColumn";
            // 
            // EquipmentInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvEquipmentList);
            Controls.Add(btnEdit);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(cmbStatusFilter);
            Name = "EquipmentInformation";
            Text = "EquipmentInformation";
            Load += EquipmentInformation_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEquipmentList).EndInit();
            ((System.ComponentModel.ISupportInitialize)courseDBContextBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbStatusFilter;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnEdit;
        private DataGridView dgvEquipmentList;
        private DataGridViewTextBoxColumn categoriesDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn equipmentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn feedbacksDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rentalRequestsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rentalTransactionsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn returnRecordsDataGridViewTextBoxColumn;
        private BindingSource courseDBContextBindingSource;
    }
}