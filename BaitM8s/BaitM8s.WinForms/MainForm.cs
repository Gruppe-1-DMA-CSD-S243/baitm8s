using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using Microsoft.Data.SqlClient;

namespace BaitM8s.WinForms
{
    public partial class MainForm : Form
    {
        private readonly IFishingSpotAPIClient _fishingSpotAPIClient = new FishingSpotAPIClient("https://localhost:8888/api/");

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e) => await LoadFishingSpotsAsync();
        private void lstFishingSpots_SelectedIndexChanged(object sender, EventArgs e) => UpdateUi();
        async void btnCreate_Click(object sender, EventArgs e) => await CreateFishingSpotAsync();
        async void btnUpdate_Click(object sender, EventArgs e) => await UpdateFishingSpotAsync();
        async void btnDelete_Click(object sender, EventArgs e) => await DeleteFishingSpotAsync();

        public async Task LoadFishingSpotsAsync()
        {
            lstFishingSpots.Items.Clear();
            var fishingSpots = await _fishingSpotAPIClient.GetAllFishingSpotsAsync();
            foreach (var spot in fishingSpots)
            {
                lstFishingSpots.Items.Add(spot);
            }
            UpdateUi();
        }
        public void UpdateUi()
        {
            bool hasSelected = lstFishingSpots.SelectedItem != null;
            btnUpdate.Enabled = hasSelected;
            btnDelete.Enabled = hasSelected;
            if (!hasSelected)
            {
                ClearFields();
                return;
            }
            var selectedSpot = (FishingSpotDTO)lstFishingSpots.SelectedItem;
            txtId.Text = selectedSpot.Id.ToString();
            txtName.Text = selectedSpot.Name;
            txtAddress.Text = selectedSpot.Address;
            txtZipCode.Text = selectedSpot.ZipCode;
            txtLongitude.Text = selectedSpot.Longitude.ToString();
            txtLatitude.Text = selectedSpot.Latitude.ToString();
            txtCapacity.Text = selectedSpot.Capacity.ToString();
            txtFishSpecies.Text = string.Join(", ", selectedSpot.FishSpecies);
            chkHandicapFriendly.Checked = selectedSpot.HandicapFriendly;
            txtPondOwnerId.Text = selectedSpot.FK_PondOwnerId.ToString();
            txtStartAvailableHours.Text = selectedSpot.StartAvailableHours.ToString();
            txtEndAvailableHours.Text= selectedSpot.EndAvailableHours.ToString();
            chkIsAwaitingApproval.Checked = selectedSpot.IsAwaitingApproval;
        }
        public void ClearFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtZipCode.Clear();
            txtLongitude.Clear();
            txtLatitude.Clear();
            txtCapacity.Clear();
            txtFishSpecies.Clear();
            chkHandicapFriendly.Checked = false;
            txtPondOwnerId.Clear();
            txtStartAvailableHours.Clear();
            txtEndAvailableHours.Clear();
            chkIsAwaitingApproval.Checked = false;
        }
        //public async Task CreateFishingSpotAsync()
        //{
        //    try
        //    {
        //        var fishSpecies = txtFishSpecies.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        //                            .Select(s => s.Trim())
        //                            .ToList();
        //        var newSpot = new FishingSpot
        //        {
        //            Name = txtName.Text,
        //            Address = txtAddress.Text,
        //            ZipCode = txtZipCode.Text,
        //            Longitude = float.Parse(txtLongitude.Text),
        //            Latitude = float.Parse(txtLatitude.Text),
        //            Capacity = int.Parse(txtCapacity.Text),
        //            FishSpecies = fishSpecies,
        //            HandicapFriendly = chkHandicapFriendly.Checked
        //        };
        //        int pondOwnerId = 1; // Example pond owner ID
        //        var newId = await _fishingSpotAPIClient.CreateFishingSpotAsync(newSpot, pondOwnerId);
        //        MessageBox.Show($"Fishing Spot created with ID: {newId}");
        //        await LoadFishingSpotsAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error creating Fishing Spot: {ex.Message}");
        //    }
        //}

        public async Task CreateFishingSpotAsync()
        {
            btnCreate.Enabled = false;

            try
            {

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Name is required.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Address is required.");
                    return;
                }

                if (!float.TryParse(txtLongitude.Text.Trim(), out float longitude))
                {
                    MessageBox.Show("Longitude must be a valid number.");
                    return;
                }

                if (!float.TryParse(txtLatitude.Text.Trim(), out float latitude))
                {
                    MessageBox.Show("Latitude must be a valid number.");
                    return;
                }

                if (!int.TryParse(txtCapacity.Text.Trim(), out int capacity))
                {
                    MessageBox.Show("Capacity must be a valid integer.");
                    return;
                }

                if (!int.TryParse(txtPondOwnerId.Text.Trim(), out int pondOwnerId))
                {
                    MessageBox.Show("Pond Owner ID must be a valid integer.");
                    return;
                }

                if (!int.TryParse(txtStartAvailableHours.Text.Trim(), out int startAvailableHours))
                {
                    MessageBox.Show("StartAvailableHours must be a valid integer.");
                    return;
                }

                if (!int.TryParse(txtEndAvailableHours.Text, out int endAvailableHours))
                {
                    MessageBox.Show("EndAvailableHours must be a valid integer.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtZipCode.Text.Trim()))
                {
                    MessageBox.Show("Zip Code is required.");
                    return;
                }

                var fishSpecies = txtFishSpecies.Text
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToList();

                var newSpot = new FishingSpotDTO
                {
                    Name = txtName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    ZipCode = txtZipCode.Text.Trim(),
                    Longitude = longitude,
                    Latitude = latitude,
                    Capacity = capacity,
                    HandicapFriendly = chkHandicapFriendly.Checked,
                    FishSpecies = fishSpecies,
                    FK_PondOwnerId = pondOwnerId,
                    StartAvailableHours = startAvailableHours,
                    EndAvailableHours = endAvailableHours,
                    IsAwaitingApproval = chkIsAwaitingApproval.Checked
                };

                var newId = await _fishingSpotAPIClient.CreateFishingSpotAsync(newSpot);

                MessageBox.Show(
                    $"Fishing Spot created with ID: {newId}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadFishingSpotsAsync();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
            finally
            {
                btnCreate.Enabled = true;
            }
        }

        

        public async Task UpdateFishingSpotAsync()
        {
            btnUpdate.Enabled = false;

            try
            {
                if (!int.TryParse(txtId.Text, out int id))
                {
                    MessageBox.Show("Invalid ID");
                    return;
                }

                if (!int.TryParse(txtCapacity.Text, out int capacity))
                {
                    MessageBox.Show("Invalid Capacity");
                    return;
                }

                if (!int.TryParse(txtPondOwnerId.Text, out int pondOwnerId))
                {
                    MessageBox.Show("Invalid Pond Owner ID");
                    return;
                }

                if (!int.TryParse(txtStartAvailableHours.Text.Trim(), out int startAvailableHours))
                {
                    MessageBox.Show("StartAvailableHours must be a valid integer.");
                    return;
                }

                if (!int.TryParse(txtEndAvailableHours.Text, out int endAvailableHours))
                {
                    MessageBox.Show("EndAvailableHours must be a valid integer.");
                    return;
                }

                float.TryParse(txtLongitude.Text, out float longitude);
                float.TryParse(txtLatitude.Text, out float latitude);

                var species = txtFishSpecies.Text
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToList();

                var spot = new FishingSpotDTO
                {
                    Id = id,
                    Name = txtName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    ZipCode = txtZipCode.Text.Trim(),
                    Longitude = longitude,
                    Latitude = latitude,
                    Capacity = capacity,
                    HandicapFriendly = chkHandicapFriendly.Checked,
                    FK_PondOwnerId = pondOwnerId,
                    FishSpecies = species,
                    StartAvailableHours = startAvailableHours,
                    EndAvailableHours = endAvailableHours,
                    IsAwaitingApproval = chkIsAwaitingApproval.Checked
                };

                await _fishingSpotAPIClient.UpdateFishingSpotAsync(spot);

                MessageBox.Show("Fishing spot updated successfully.");
                await LoadFishingSpotsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating spot: {ex.Message}");
            }
            finally
            {
                btnUpdate.Enabled = true;
            }
        }

        public async Task DeleteFishingSpotAsync()
        {
            if (lstFishingSpots.SelectedItem == null)
            {
                MessageBox.Show("No Fishing Spot selected for deletion.");
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete the selected Fishing Spot?", "Confirm Deletion", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                var selectedSpot = (FishingSpotDTO)lstFishingSpots.SelectedItem;
                await _fishingSpotAPIClient.DeleteFishingSpotAsync(selectedSpot.Id);
                MessageBox.Show($"Fishing Spot with ID: {selectedSpot.Id} deleted.");
                await LoadFishingSpotsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting Fishing Spot: {ex.Message}");
            }
        }

    }
}
