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
            lstFishingSpots.Location = new Point(12, 74);
            lstFishingSpots.Name = "lstFishingSpots";
            lstFishingSpots.Size = new Size(462, 292);
            lstFishingSpots.TabIndex = 0;
            lstFishingSpots.SelectedIndexChanged += lstFishingSpots_SelectedIndexChanged;
            // 
            // lstPendingFishingSpots
            // 
            lstPendingFishingSpots.FormattingEnabled = true;
            lstPendingFishingSpots.Location = new Point(12, 445);
            lstPendingFishingSpots.Name = "lstPendingFishingSpots";
            lstPendingFishingSpots.Size = new Size(462, 324);
            lstPendingFishingSpots.TabIndex = 1;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(12, 801);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(150, 46);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(168, 801);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 46);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(324, 801);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 46);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblFishingSpots
            // 
            lblFishingSpots.AutoSize = true;
            lblFishingSpots.Location = new Point(12, 39);
            lblFishingSpots.Name = "lblFishingSpots";
            lblFishingSpots.Size = new Size(227, 32);
            lblFishingSpots.TabIndex = 5;
            lblFishingSpots.Text = "Saved Fishing Spots";
            // 
            // lblPendingFishingSpots
            // 
            lblPendingFishingSpots.AutoSize = true;
            lblPendingFishingSpots.Location = new Point(12, 410);
            lblPendingFishingSpots.Name = "lblPendingFishingSpots";
            lblPendingFishingSpots.Size = new Size(250, 32);
            lblPendingFishingSpots.TabIndex = 6;
            lblPendingFishingSpots.Text = "Pending Fishing Spots";
            // 
            // txtId
            // 
            txtId.Location = new Point(1037, 74);
            txtId.Name = "txtId";
            txtId.Size = new Size(341, 39);
            txtId.TabIndex = 7;
            // 
            // txtName
            // 
            txtName.Location = new Point(1037, 119);
            txtName.Name = "txtName";
            txtName.Size = new Size(341, 39);
            txtName.TabIndex = 8;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(1037, 164);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(341, 39);
            txtAddress.TabIndex = 9;
            // 
            // txtZipCode
            // 
            txtZipCode.Location = new Point(1037, 209);
            txtZipCode.Name = "txtZipCode";
            txtZipCode.Size = new Size(341, 39);
            txtZipCode.TabIndex = 10;
            // 
            // txtLongitude
            // 
            txtLongitude.Location = new Point(1037, 254);
            txtLongitude.Name = "txtLongitude";
            txtLongitude.Size = new Size(341, 39);
            txtLongitude.TabIndex = 11;
            // 
            // txtLatitude
            // 
            txtLatitude.Location = new Point(1037, 299);
            txtLatitude.Name = "txtLatitude";
            txtLatitude.Size = new Size(341, 39);
            txtLatitude.TabIndex = 12;
            // 
            // txtCapacity
            // 
            txtCapacity.Location = new Point(1037, 344);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(341, 39);
            txtCapacity.TabIndex = 13;
            // 
            // txtFishSpecies
            // 
            txtFishSpecies.Location = new Point(1037, 389);
            txtFishSpecies.Name = "txtFishSpecies";
            txtFishSpecies.Size = new Size(341, 39);
            txtFishSpecies.TabIndex = 14;
            // 
            // chkHandicapFriendly
            // 
            chkHandicapFriendly.AutoSize = true;
            chkHandicapFriendly.Location = new Point(1073, 434);
            chkHandicapFriendly.Name = "chkHandicapFriendly";
            chkHandicapFriendly.Size = new Size(249, 36);
            chkHandicapFriendly.TabIndex = 15;
            chkHandicapFriendly.Text = "Handicap Friendly?";
            chkHandicapFriendly.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(879, 81);
            lblId.Name = "lblId";
            lblId.Size = new Size(42, 32);
            lblId.TabIndex = 16;
            lblId.Text = "ID:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(879, 126);
            lblName.Name = "lblName";
            lblName.Size = new Size(83, 32);
            lblName.TabIndex = 17;
            lblName.Text = "Name:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(879, 171);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(103, 32);
            lblAddress.TabIndex = 18;
            lblAddress.Text = "Address:";
            // 
            // lblZipCode
            // 
            lblZipCode.AutoSize = true;
            lblZipCode.Location = new Point(879, 216);
            lblZipCode.Name = "lblZipCode";
            lblZipCode.Size = new Size(109, 32);
            lblZipCode.TabIndex = 19;
            lblZipCode.Text = "ZipCode:";
            // 
            // lblLongitude
            // 
            lblLongitude.AutoSize = true;
            lblLongitude.Location = new Point(879, 261);
            lblLongitude.Name = "lblLongitude";
            lblLongitude.Size = new Size(127, 32);
            lblLongitude.TabIndex = 20;
            lblLongitude.Text = "Longitude:";
            // 
            // lblLatitude
            // 
            lblLatitude.AutoSize = true;
            lblLatitude.Location = new Point(879, 306);
            lblLatitude.Name = "lblLatitude";
            lblLatitude.Size = new Size(105, 32);
            lblLatitude.TabIndex = 21;
            lblLatitude.Text = "Latitude:";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Location = new Point(879, 351);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(109, 32);
            lblCapacity.TabIndex = 22;
            lblCapacity.Text = "Capacity:";
            // 
            // lblFishSpecies
            // 
            lblFishSpecies.AutoSize = true;
            lblFishSpecies.Location = new Point(879, 396);
            lblFishSpecies.Name = "lblFishSpecies";
            lblFishSpecies.Size = new Size(148, 32);
            lblFishSpecies.TabIndex = 23;
            lblFishSpecies.Text = "Fish Species:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1390, 859);
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
            Name = "MainForm";
            Text = "BaitM8s Administrator Panel";
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
