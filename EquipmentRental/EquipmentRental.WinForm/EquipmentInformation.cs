using EquipmentLibrary.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EquipmentRental.WinForm
{
    public partial class EquipmentInformation : Form
    {
        private CourseDBContext dbContext;

        public EquipmentInformation()
        {
            InitializeComponent();
            dbContext = new CourseDBContext();
        }

        private void EquipmentInformation_Load(object sender, EventArgs e)
        {
            cmbStatusFilter.Items.AddRange(new string[] { "All", "Active", "Inactive" });
            cmbStatusFilter.SelectedIndex = 0;

            InitializeGridColumns();
            LoadEquipment();
        }

        private void InitializeGridColumns()
        {
            dgvEquipmentList.Columns.Clear();

            dgvEquipmentList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Equipment Name",
                DataPropertyName = "Name"
            });

            dgvEquipmentList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                DataPropertyName = "Category"
            });

            dgvEquipmentList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Description",
                DataPropertyName = "Description"
            });

            dgvEquipmentList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Price",
                DataPropertyName = "Price"
            });

            dgvEquipmentList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status"
            });

            dgvEquipmentList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Availability",
                HeaderText = "Availability",
                DataPropertyName = "Availability"
            });

            dgvEquipmentList.AutoGenerateColumns = false;
        }

        private void LoadEquipment(string statusFilter = "All", string keyword = "")
        {
            var equipmentList = dbContext.Equipment
                .Where(eq =>
                    (statusFilter == "All" || eq.Status == statusFilter) &&
                    (string.IsNullOrEmpty(keyword) || eq.Name.Contains(keyword) || eq.Category.Name.Contains(keyword)))
                .Select(eq => new
                {
                    eq.Name,
                    Category = eq.Category.Name,
                    eq.Description,
                    eq.Price,
                    eq.Status,
                    Availability = eq.IsAvailable ? "Available" : "Rented"
                })
                .ToList();

            dgvEquipmentList.DataSource = equipmentList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedStatus = cmbStatusFilter.SelectedItem?.ToString() ?? "All";
            string keyword = txtSearch.Text.Trim();

            LoadEquipment(selectedStatus, keyword);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEquipmentList.SelectedRows.Count > 0)
            {
                string selectedName = dgvEquipmentList.SelectedRows[0].Cells["Name"].Value?.ToString();

                var selectedEquipment = dbContext.Equipment
                    .FirstOrDefault(e => e.Name == selectedName);

                if (selectedEquipment != null)
                {
                    var editForm = new EditEquipmentForm(selectedEquipment);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        dbContext.SaveChanges();
                        LoadEquipment();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvEquipmentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
