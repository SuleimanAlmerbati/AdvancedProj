namespace EquipmentRental.WinForm
{
    partial class EquipmentCheckin
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
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            courseDBContextBindingSource = new BindingSource(components);
            categoriesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            documentsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            equipmentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            feedbacksDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            logsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            notificationsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rentalRequestsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rentalTransactionsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            returnRecordsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usersDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            databaseDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            changeTrackerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            modelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            contextIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            NewReturnButton = new Button();
            EditSelectedButton = new Button();
            RefreshListButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)courseDBContextBindingSource).BeginInit();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(130, 33);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(375, 23);
            textBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(38, 33);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 3;
            label1.Text = "Search";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(38, 74);
            label2.Name = "label2";
            label2.Size = new Size(79, 25);
            label2.TabIndex = 4;
            label2.Text = "Filter by:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(130, 77);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(190, 23);
            comboBox1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(534, 30);
            button1.Name = "button1";
            button1.Size = new Size(104, 28);
            button1.TabIndex = 6;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { categoriesDataGridViewTextBoxColumn, documentsDataGridViewTextBoxColumn, equipmentDataGridViewTextBoxColumn, feedbacksDataGridViewTextBoxColumn, logsDataGridViewTextBoxColumn, notificationsDataGridViewTextBoxColumn, rentalRequestsDataGridViewTextBoxColumn, rentalTransactionsDataGridViewTextBoxColumn, returnRecordsDataGridViewTextBoxColumn, usersDataGridViewTextBoxColumn, databaseDataGridViewTextBoxColumn, changeTrackerDataGridViewTextBoxColumn, modelDataGridViewTextBoxColumn, contextIdDataGridViewTextBoxColumn });
            dataGridView1.DataSource = courseDBContextBindingSource;
            dataGridView1.Location = new Point(38, 128);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(575, 198);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
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
            // documentsDataGridViewTextBoxColumn
            // 
            documentsDataGridViewTextBoxColumn.DataPropertyName = "Documents";
            documentsDataGridViewTextBoxColumn.HeaderText = "Documents";
            documentsDataGridViewTextBoxColumn.Name = "documentsDataGridViewTextBoxColumn";
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
            // logsDataGridViewTextBoxColumn
            // 
            logsDataGridViewTextBoxColumn.DataPropertyName = "Logs";
            logsDataGridViewTextBoxColumn.HeaderText = "Logs";
            logsDataGridViewTextBoxColumn.Name = "logsDataGridViewTextBoxColumn";
            // 
            // notificationsDataGridViewTextBoxColumn
            // 
            notificationsDataGridViewTextBoxColumn.DataPropertyName = "Notifications";
            notificationsDataGridViewTextBoxColumn.HeaderText = "Notifications";
            notificationsDataGridViewTextBoxColumn.Name = "notificationsDataGridViewTextBoxColumn";
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
            // usersDataGridViewTextBoxColumn
            // 
            usersDataGridViewTextBoxColumn.DataPropertyName = "Users";
            usersDataGridViewTextBoxColumn.HeaderText = "Users";
            usersDataGridViewTextBoxColumn.Name = "usersDataGridViewTextBoxColumn";
            // 
            // databaseDataGridViewTextBoxColumn
            // 
            databaseDataGridViewTextBoxColumn.DataPropertyName = "Database";
            databaseDataGridViewTextBoxColumn.HeaderText = "Database";
            databaseDataGridViewTextBoxColumn.Name = "databaseDataGridViewTextBoxColumn";
            databaseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // changeTrackerDataGridViewTextBoxColumn
            // 
            changeTrackerDataGridViewTextBoxColumn.DataPropertyName = "ChangeTracker";
            changeTrackerDataGridViewTextBoxColumn.HeaderText = "ChangeTracker";
            changeTrackerDataGridViewTextBoxColumn.Name = "changeTrackerDataGridViewTextBoxColumn";
            changeTrackerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            modelDataGridViewTextBoxColumn.HeaderText = "Model";
            modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            modelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contextIdDataGridViewTextBoxColumn
            // 
            contextIdDataGridViewTextBoxColumn.DataPropertyName = "ContextId";
            contextIdDataGridViewTextBoxColumn.HeaderText = "ContextId";
            contextIdDataGridViewTextBoxColumn.Name = "contextIdDataGridViewTextBoxColumn";
            contextIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // NewReturnButton
            // 
            NewReturnButton.Location = new Point(42, 357);
            NewReturnButton.Name = "NewReturnButton";
            NewReturnButton.Size = new Size(114, 32);
            NewReturnButton.TabIndex = 8;
            NewReturnButton.Text = "New Return";
            NewReturnButton.UseVisualStyleBackColor = true;
            NewReturnButton.Click += button2_Click;
            // 
            // EditSelectedButton
            // 
            EditSelectedButton.Location = new Point(247, 357);
            EditSelectedButton.Name = "EditSelectedButton";
            EditSelectedButton.Size = new Size(133, 32);
            EditSelectedButton.TabIndex = 9;
            EditSelectedButton.Text = "Edit Selected";
            EditSelectedButton.UseVisualStyleBackColor = true;
            EditSelectedButton.Click += button3_Click;
            // 
            // RefreshListButton
            // 
            RefreshListButton.Location = new Point(458, 360);
            RefreshListButton.Name = "RefreshListButton";
            RefreshListButton.Size = new Size(128, 27);
            RefreshListButton.TabIndex = 10;
            RefreshListButton.Text = "Refresh List";
            RefreshListButton.UseVisualStyleBackColor = true;
            // 
            // EquipmentCheckin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 430);
            Controls.Add(RefreshListButton);
            Controls.Add(EditSelectedButton);
            Controls.Add(NewReturnButton);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            MinimumSize = new Size(10, 10);
            Name = "EquipmentCheckin";
            Text = "EquipmentCheckin";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)courseDBContextBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn categoriesDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn documentsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn equipmentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn feedbacksDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn logsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notificationsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rentalRequestsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rentalTransactionsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn returnRecordsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usersDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn databaseDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn changeTrackerDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn contextIdDataGridViewTextBoxColumn;
        private BindingSource courseDBContextBindingSource;
        private Button NewReturnButton;
        private Button EditSelectedButton;
        private Button RefreshListButton;
    }
}