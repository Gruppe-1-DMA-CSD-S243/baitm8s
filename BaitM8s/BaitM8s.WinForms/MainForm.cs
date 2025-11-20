using BaitM8s.APIClient.Clients;
using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;

namespace BaitM8s.WinForms
{
    public partial class MainForm : Form
    {
        IPutAndTakePondDao _putAndTakePondApiClient = new PutAndTakePondApiClient("https://localhost:8888/api/");
        public MainForm()
        {
            InitializeComponent();
            LoadPondsAsync();
        }

        private async void MainForm_Load(object sender, EventArgs e) => await LoadPondsAsync();
        private void lstPonds_SelectedIndexChanged(object sender, EventArgs e) => UpdateUI();
        private async void btnCreate_Click(object sender, EventArgs e) => await CreatePondAsync();
        private async void btnUpdate_Click(object sender, EventArgs e) => await UpdatePondAsync();
        private async void btnDelete_Click(object sender, EventArgs e) => await DeletePondAsync();

        public async Task LoadPondsAsync()
        {
            lstPonds.Items.Clear();
            var ponds = await _putAndTakePondApiClient.GetAllPutAndTakePondsAsync();
            foreach (var pond in ponds)
            {
                lstPonds.Items.Add(pond);
            }
            UpdateUI();
        }


        public void UpdateUI()
        {
            bool hasSelected = lstPonds.SelectedIndex != -1;
            btnUpdate.Enabled = hasSelected;
            btnDelete.Enabled = hasSelected;

            if (!hasSelected)
            {
                ClearFields();
                return;
            }
            var selectedPond = (PutAndTakePond)lstPonds.SelectedItem;
            txtSpotNumber.Text = selectedPond.FishingSpotNumber.ToString();
            txtName.Text = selectedPond.Name;
            txtCoordinates.Text = selectedPond.Coordinates;
            txtFishSpecies.Text = selectedPond.FishSpecies;
            txtAddress.Text = selectedPond.Address;
            txtEmail.Text = selectedPond.Email;
            txtPhoneNumber.Text = selectedPond.PhoneNumber;
            txtSize.Text = selectedPond.SizeInSquareMeters.ToString();
            txtSpotType.Text = selectedPond.SpotType;
            txtWebsite.Text = selectedPond.LinkToWebsite;
            txtZipCode.Text = selectedPond.ZipCode;
            chkCleanTable.Checked = selectedPond.CleanTable;
            chkFamily.Checked = selectedPond.FamilyFriendly;
            chkFishingLicense.Checked = selectedPond.FishingLicenseRequired;
            chkHandicap.Checked = selectedPond.HandicapFriendly;
            chkToilet.Checked = selectedPond.Toilet;

        }

        public void ClearFields()
        {
            txtSpotNumber.Clear();
            txtName.Clear();
            txtCoordinates.Clear();
            txtFishSpecies.Clear();
            txtSpotType.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtSize.Clear();
            txtWebsite.Clear();
            txtZipCode.Clear();
            chkCleanTable.Checked = false;
            chkFamily.Checked = false;
            chkFishingLicense.Checked = false;
            chkHandicap.Checked = false;
            chkToilet.Checked = false;
        }

        public async Task CreatePondAsync()
        {
            try
            {
                var newPond = new PutAndTakePond
                {
                    FishingSpotNumber = int.Parse(txtSpotNumber.Text),
                    Name = txtName.Text,
                    Coordinates = txtCoordinates.Text,
                    FishSpecies = txtFishSpecies.Text,
                    SpotType = txtSpotType.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    SizeInSquareMeters = int.Parse(txtSize.Text),
                    LinkToWebsite = txtWebsite.Text,
                    ZipCode = txtZipCode.Text,
                    CleanTable = chkCleanTable.Checked,
                    FamilyFriendly = chkFamily.Checked,
                    FishingLicenseRequired = chkFishingLicense.Checked,
                    HandicapFriendly = chkHandicap.Checked,
                    Toilet = chkToilet.Checked
                };
                await _putAndTakePondApiClient.CreatePutAndTakePondAsync(newPond);
                MessageBox.Show("Pond created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadPondsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating pond: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public async Task UpdatePondAsync()
        {
            if (lstPonds.SelectedItem == null)
            {
                return;
            }
            try
            {
                var selectedPond = (PutAndTakePond)lstPonds.SelectedItem;
                selectedPond.FishingSpotNumber = int.Parse(txtSpotNumber.Text);
                selectedPond.Name = txtName.Text;
                selectedPond.Coordinates = txtCoordinates.Text;
                selectedPond.FishSpecies = txtFishSpecies.Text;
                selectedPond.Address = txtAddress.Text;
                selectedPond.Email = txtEmail.Text;
                selectedPond.PhoneNumber = txtPhoneNumber.Text;
                selectedPond.SizeInSquareMeters = int.Parse(txtSize.Text);
                selectedPond.LinkToWebsite = txtWebsite.Text;
                selectedPond.ZipCode = txtZipCode.Text;
                selectedPond.SpotType = txtSpotType.Text;
                selectedPond.CleanTable = chkCleanTable.Checked;
                selectedPond.FamilyFriendly = chkFamily.Checked;
                selectedPond.FishingLicenseRequired = chkFishingLicense.Checked;
                selectedPond.HandicapFriendly = chkHandicap.Checked;
                selectedPond.Toilet = chkToilet.Checked;
                await _putAndTakePondApiClient.UpdatePutAndTakePondAsync(selectedPond);
                MessageBox.Show("Pond updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadPondsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating pond: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public async Task DeletePondAsync()
        {
            if (lstPonds.SelectedItem == null)
            {
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this pond?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            try
            {
                var selectedPond = (PutAndTakePond)lstPonds.SelectedItem;
                await _putAndTakePondApiClient.DeletePutAndTakePondAsync(selectedPond.FishingSpotNumber);
                MessageBox.Show("Pond deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadPondsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting pond: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
