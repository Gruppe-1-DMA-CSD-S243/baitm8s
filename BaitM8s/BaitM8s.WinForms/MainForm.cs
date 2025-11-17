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
        }

        private async void MainForm_Load(object sender, EventArgs e) => await LoadPondsAsync();
        private void lstPonds_SelectecdIndexChanged(object sender, EventArgs e) => UpdateUI();
        private async void btnCreate_Click(object sender, EventArgs e) => await CreatePondAsync();
        private async void btnUpdate_Click(object sender, EventArgs e) => await UpdatePondAsync();
        private async void btnDelete_Click(object sender, EventArgs e) => await DeletePondAsync();

        private async Task LoadPondsAsync()
        {
            lstPonds.Items.Clear();
            var ponds = await _putAndTakePondApiClient.GetAllPutAndTakePondsAsync();
            foreach (var pond in ponds)
            {
                lstPonds.Items.Add(pond);
            }
            UpdateUI();
        }


        private void UpdateUI()
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
            txtWebsite.Text = selectedPond.LinkToWebsite;
            txtZipCode.Text = selectedPond.ZipCode;
            chkCleanTable.Checked = selectedPond.CleanTable;
            chkFamily.Checked = selectedPond.FamilyFriendly;
            chkFishingLicense.Checked = selectedPond.FishingLicenseRequired;
            chkHandicap.Checked = selectedPond.HandicapFriendly;
            chkToilet.Checked = selectedPond.Toilet;

        }

        private void ClearFields()
        {
            txtSpotNumber.Clear();
            txtName.Clear();
            txtCoordinates.Clear();
            txtFishSpecies.Clear();
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

        private async Task CreatePondAsync()
        {
            try
            {
                var newPond = new PutAndTakePond
                {
                    FishingSpotNumber = int.Parse(txtSpotNumber.Text),
                    Name = txtName.Text,
                    Coordinates = txtCoordinates.Text,
                    FishSpecies = txtFishSpecies.Text,
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
                await LoadPondsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating pond: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task UpdatePondAsync()
        {
            throw new NotImplementedException();
        }


        private async Task DeletePondAsync()
        {
            throw new NotImplementedException();
        }
    }
}
