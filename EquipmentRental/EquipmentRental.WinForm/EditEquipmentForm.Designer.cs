namespace EquipmentRental.WinForm
{
    partial class EditEquipmentForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtName = new TextBox();
            txtCategory = new TextBox();
            txtDescription = new TextBox();
            txtPrice = new TextBox();
            cmbStatus = new ComboBox();
            chkAvailable = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(78, 33);
            label1.Name = "label1";
            label1.Size = new Size(68, 28);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(71, 83);
            label2.Name = "label2";
            label2.Size = new Size(96, 28);
            label2.TabIndex = 1;
            label2.Text = "Category:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(71, 138);
            label3.Name = "label3";
            label3.Size = new Size(116, 28);
            label3.TabIndex = 2;
            label3.Text = "Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(78, 206);
            label4.Name = "label4";
            label4.Size = new Size(58, 28);
            label4.TabIndex = 3;
            label4.Text = "Price:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(78, 265);
            label5.Name = "label5";
            label5.Size = new Size(69, 28);
            label5.TabIndex = 4;
            label5.Text = "Status:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(78, 324);
            label6.Name = "label6";
            label6.Size = new Size(113, 28);
            label6.TabIndex = 5;
            label6.Text = "Availability:";
            // 
            // txtName
            // 
            txtName.Location = new Point(173, 40);
            txtName.Name = "txtName";
            txtName.Size = new Size(374, 23);
            txtName.TabIndex = 6;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(181, 93);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(366, 23);
            txtCategory.TabIndex = 7;
            txtCategory.TextChanged += txtCategory_TextChanged;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(197, 146);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(350, 23);
            txtDescription.TabIndex = 8;
            txtDescription.TextChanged += txtDescription_TextChanged;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(147, 215);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(217, 23);
            txtPrice.TabIndex = 9;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(164, 270);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(121, 23);
            cmbStatus.TabIndex = 10;
            // 
            // chkAvailable
            // 
            chkAvailable.AutoSize = true;
            chkAvailable.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkAvailable.Location = new Point(206, 329);
            chkAvailable.Name = "chkAvailable";
            chkAvailable.Size = new Size(99, 25);
            chkAvailable.TabIndex = 11;
            chkAvailable.Text = "Available?";
            chkAvailable.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(495, 381);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(111, 26);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(628, 381);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 26);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // EditEquipmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkAvailable);
            Controls.Add(cmbStatus);
            Controls.Add(txtPrice);
            Controls.Add(txtDescription);
            Controls.Add(txtCategory);
            Controls.Add(txtName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditEquipmentForm";
            Text = "EditEquipmentForm";
            Load += EditEquipmentForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtName;
        private TextBox txtCategory;
        private TextBox txtDescription;
        private TextBox txtPrice;
        private ComboBox cmbStatus;
        private CheckBox chkAvailable;
        private Button btnSave;
        private Button btnCancel;
    }
}