namespace BaitM8s.WinForms
{
    partial class MainForm
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
            lstFishingSpots = new ListBox();
            lstPendingFishingSpots = new ListBox();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblFishingSpots = new Label();
            lblPendingFishingSpots = new Label();
            txtId = new TextBox();
            txtName = new TextBox();
            txtAddress = new TextBox();
            txtZipCode = new TextBox();
            txtLongitude = new TextBox();
            txtLatitude = new TextBox();
            txtCapacity = new TextBox();
            txtFishSpecies = new TextBox();
            chkHandicapFriendly = new CheckBox();
            lblId = new Label();
            lblName = new Label();
            lblAddress = new Label();
            lblZipCode = new Label();
            lblLongitude = new Label();
            lblLatitude = new Label();
            lblCapacity = new Label();
            lblFishSpecies = new Label();
            SuspendLayout();
            // 
            // lstFishingSpots
            // 
            lstFishingSpots.FormattingEnabled = true;
            lstFishingSpots.Location = new Point(7, 46);
            lstFishingSpots.Margin = new Padding(2, 2, 2, 2);
            lstFishingSpots.Name = "lstFishingSpots";
            lstFishingSpots.Size = new Size(286, 184);
            lstFishingSpots.TabIndex = 0;
            lstFishingSpots.SelectedIndexChanged += lstFishingSpots_SelectedIndexChanged;
            // 
            // lstPendingFishingSpots
            // 
            lstPendingFishingSpots.FormattingEnabled = true;
            lstPendingFishingSpots.Location = new Point(7, 278);
            lstPendingFishingSpots.Margin = new Padding(2, 2, 2, 2);
            lstPendingFishingSpots.Name = "lstPendingFishingSpots";
            lstPendingFishingSpots.Size = new Size(286, 204);
            lstPendingFishingSpots.TabIndex = 1;
            //TODO: Kig lige på det her
            //lstPendingFishingSpots.SelectedIndexChanged = lstFishingSpots_SelectedIndexChanged;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(7, 501);
            btnCreate.Margin = new Padding(2, 2, 2, 2);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(92, 29);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(103, 501);
            btnUpdate.Margin = new Padding(2, 2, 2, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(92, 29);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(199, 501);
            btnDelete.Margin = new Padding(2, 2, 2, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(92, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblFishingSpots
            // 
            lblFishingSpots.AutoSize = true;
            lblFishingSpots.Location = new Point(7, 24);
            lblFishingSpots.Margin = new Padding(2, 0, 2, 0);
            lblFishingSpots.Name = "lblFishingSpots";
            lblFishingSpots.Size = new Size(140, 20);
            lblFishingSpots.TabIndex = 5;
            lblFishingSpots.Text = "Saved Fishing Spots";
            // 
            // lblPendingFishingSpots
            // 
            lblPendingFishingSpots.AutoSize = true;
            lblPendingFishingSpots.Location = new Point(7, 256);
            lblPendingFishingSpots.Margin = new Padding(2, 0, 2, 0);
            lblPendingFishingSpots.Name = "lblPendingFishingSpots";
            lblPendingFishingSpots.Size = new Size(153, 20);
            lblPendingFishingSpots.TabIndex = 6;
            lblPendingFishingSpots.Text = "Pending Fishing Spots";
            // 
            // txtId
            // 
            txtId.Location = new Point(638, 46);
            txtId.Margin = new Padding(2, 2, 2, 2);
            txtId.Name = "txtId";
            txtId.Size = new Size(211, 27);
            txtId.TabIndex = 7;
            // 
            // txtName
            // 
            txtName.Location = new Point(638, 74);
            txtName.Margin = new Padding(2, 2, 2, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(211, 27);
            txtName.TabIndex = 8;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(638, 102);
            txtAddress.Margin = new Padding(2, 2, 2, 2);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(211, 27);
            txtAddress.TabIndex = 9;
            // 
            // txtZipCode
            // 
            txtZipCode.Location = new Point(638, 131);
            txtZipCode.Margin = new Padding(2, 2, 2, 2);
            txtZipCode.Name = "txtZipCode";
            txtZipCode.Size = new Size(211, 27);
            txtZipCode.TabIndex = 10;
            // 
            // txtLongitude
            // 
            txtLongitude.Location = new Point(638, 159);
            txtLongitude.Margin = new Padding(2, 2, 2, 2);
            txtLongitude.Name = "txtLongitude";
            txtLongitude.Size = new Size(211, 27);
            txtLongitude.TabIndex = 11;
            // 
            // txtLatitude
            // 
            txtLatitude.Location = new Point(638, 187);
            txtLatitude.Margin = new Padding(2, 2, 2, 2);
            txtLatitude.Name = "txtLatitude";
            txtLatitude.Size = new Size(211, 27);
            txtLatitude.TabIndex = 12;
            // 
            // txtCapacity
            // 
            txtCapacity.Location = new Point(638, 215);
            txtCapacity.Margin = new Padding(2, 2, 2, 2);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(211, 27);
            txtCapacity.TabIndex = 13;
            // 
            // txtFishSpecies
            // 
            txtFishSpecies.Location = new Point(638, 243);
            txtFishSpecies.Margin = new Padding(2, 2, 2, 2);
            txtFishSpecies.Name = "txtFishSpecies";
            txtFishSpecies.Size = new Size(211, 27);
            txtFishSpecies.TabIndex = 14;
            // 
            // chkHandicapFriendly
            // 
            chkHandicapFriendly.AutoSize = true;
            chkHandicapFriendly.Location = new Point(660, 271);
            chkHandicapFriendly.Margin = new Padding(2, 2, 2, 2);
            chkHandicapFriendly.Name = "chkHandicapFriendly";
            chkHandicapFriendly.Size = new Size(158, 24);
            chkHandicapFriendly.TabIndex = 15;
            chkHandicapFriendly.Text = "Handicap Friendly?";
            chkHandicapFriendly.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(541, 51);
            lblId.Margin = new Padding(2, 0, 2, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(27, 20);
            lblId.TabIndex = 16;
            lblId.Text = "ID:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(541, 79);
            lblName.Margin = new Padding(2, 0, 2, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 17;
            lblName.Text = "Name:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(541, 107);
            lblAddress.Margin = new Padding(2, 0, 2, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(65, 20);
            lblAddress.TabIndex = 18;
            lblAddress.Text = "Address:";
            // 
            // lblZipCode
            // 
            lblZipCode.AutoSize = true;
            lblZipCode.Location = new Point(541, 135);
            lblZipCode.Margin = new Padding(2, 0, 2, 0);
            lblZipCode.Name = "lblZipCode";
            lblZipCode.Size = new Size(69, 20);
            lblZipCode.TabIndex = 19;
            lblZipCode.Text = "ZipCode:";
            // 
            // lblLongitude
            // 
            lblLongitude.AutoSize = true;
            lblLongitude.Location = new Point(541, 163);
            lblLongitude.Margin = new Padding(2, 0, 2, 0);
            lblLongitude.Name = "lblLongitude";
            lblLongitude.Size = new Size(79, 20);
            lblLongitude.TabIndex = 20;
            lblLongitude.Text = "Longitude:";
            // 
            // lblLatitude
            // 
            lblLatitude.AutoSize = true;
            lblLatitude.Location = new Point(541, 191);
            lblLatitude.Margin = new Padding(2, 0, 2, 0);
            lblLatitude.Name = "lblLatitude";
            lblLatitude.Size = new Size(66, 20);
            lblLatitude.TabIndex = 21;
            lblLatitude.Text = "Latitude:";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Location = new Point(541, 219);
            lblCapacity.Margin = new Padding(2, 0, 2, 0);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(69, 20);
            lblCapacity.TabIndex = 22;
            lblCapacity.Text = "Capacity:";
            // 
            // lblFishSpecies
            // 
            lblFishSpecies.AutoSize = true;
            lblFishSpecies.Location = new Point(541, 248);
            lblFishSpecies.Margin = new Padding(2, 0, 2, 0);
            lblFishSpecies.Name = "lblFishSpecies";
            lblFishSpecies.Size = new Size(91, 20);
            lblFishSpecies.TabIndex = 23;
            lblFishSpecies.Text = "Fish Species:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 537);
            Controls.Add(lblFishSpecies);
            Controls.Add(lblCapacity);
            Controls.Add(lblLatitude);
            Controls.Add(lblLongitude);
            Controls.Add(lblZipCode);
            Controls.Add(lblAddress);
            Controls.Add(lblName);
            Controls.Add(lblId);
            Controls.Add(chkHandicapFriendly);
            Controls.Add(txtFishSpecies);
            Controls.Add(txtCapacity);
            Controls.Add(txtLatitude);
            Controls.Add(txtLongitude);
            Controls.Add(txtZipCode);
            Controls.Add(txtAddress);
            Controls.Add(txtName);
            Controls.Add(txtId);
            Controls.Add(lblPendingFishingSpots);
            Controls.Add(lblFishingSpots);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(lstPendingFishingSpots);
            Controls.Add(lstFishingSpots);
            Margin = new Padding(2, 2, 2, 2);
            Name = "MainForm";
            Text = "BaitM8s Administrator Panel";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private ListBox lstFishingSpots;
        private ListBox lstPendingFishingSpots;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Label lblFishingSpots;
        private Label lblPendingFishingSpots;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtZipCode;
        private TextBox txtLongitude;
        private TextBox txtLatitude;
        private TextBox txtCapacity;
        private TextBox txtFishSpecies;
        private CheckBox chkHandicapFriendly;
        private Label lblId;
        private Label lblName;
        private Label lblAddress;
        private Label lblZipCode;
        private Label lblLongitude;
        private Label lblLatitude;
        private Label lblCapacity;
        private Label lblFishSpecies;
    }
}
