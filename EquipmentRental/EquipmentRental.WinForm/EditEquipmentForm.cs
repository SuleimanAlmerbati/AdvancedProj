using System;
using System.Windows.Forms;
using EquipmentLibrary.Model;

namespace EquipmentRental.WinForm
{
    public partial class EditEquipmentForm : Form
    {
        private Equipment _equipment;

        public EditEquipmentForm(Equipment equipment)
        {
            InitializeComponent();
            _equipment = equipment;
        }

        private void EditEquipmentForm_Load(object sender, EventArgs e)
        {
            // Populate fields with existing equipment data
            txtName.Text = _equipment.Name;
            txtCategory.Text = _equipment.Category;
            txtDescription.Text = _equipment.Description;
            txtPrice.Text = _equipment.PricePerDay.ToString("F2");
            cmbStatus.Items.AddRange(new[] { "Available", "In Use", "Maintenance", "Out of Service" });
            cmbStatus.SelectedItem = _equipment.Status;
            chkAvailable.Checked = _equipment.IsAvailable;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update the equipment object
            _equipment.Name = txtName.Text.Trim();
            _equipment.Category = txtCategory.Text.Trim();
            _equipment.Description = txtDescription.Text.Trim();
            _equipment.PricePerDay = price;
            _equipment.Status = cmbStatus.SelectedItem.ToString();
            _equipment.IsAvailable = chkAvailable.Checked;

            // Save changes to database
            using (var context = new CourseDBContext())
            {
                context.Equipments.Update(_equipment);
                context.SaveChanges();
            }

            MessageBox.Show("Equipment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Optional: remove unused textChanged handlers if not needed
        private void txtCategory_TextChanged(object sender, EventArgs e) { }
        private void txtDescription_TextChanged(object sender, EventArgs e) { }

        private void EditEquipmentForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
