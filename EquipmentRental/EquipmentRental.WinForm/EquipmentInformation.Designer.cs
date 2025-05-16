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
            SearchLabel = new Label();
            Searchtextbox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // SearchLabel
            // 
            SearchLabel.AutoSize = true;
            SearchLabel.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            SearchLabel.Location = new Point(36, 44);
            SearchLabel.Name = "SearchLabel";
            SearchLabel.Size = new Size(68, 25);
            SearchLabel.TabIndex = 0;
            SearchLabel.Text = "Search:";
            // 
            // Searchtextbox
            // 
            Searchtextbox.Location = new Point(129, 47);
            Searchtextbox.Name = "Searchtextbox";
            Searchtextbox.Size = new Size(373, 23);
            Searchtextbox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(528, 44);
            button1.Name = "button1";
            button1.Size = new Size(83, 34);
            button1.TabIndex = 2;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            // 
            // EquipmentInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(Searchtextbox);
            Controls.Add(SearchLabel);
            Name = "EquipmentInformation";
            Text = "EquipmentInformation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SearchLabel;
        private TextBox Searchtextbox;
        private Button button1;
    }
}