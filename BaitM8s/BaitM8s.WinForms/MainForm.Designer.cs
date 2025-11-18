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
            lstPonds = new ListBox();
            lblPutAndTakePonds = new Label();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblSpotNumber = new Label();
            lblName = new Label();
            Address = new Label();
            lblZipCode = new Label();
            lblEmail = new Label();
            lblPhoneNumber = new Label();
            lblSize = new Label();
            lblWebsite = new Label();
            txtSpotNumber = new TextBox();
            txtName = new TextBox();
            txtAddress = new TextBox();
            txtZipCode = new TextBox();
            txtEmail = new TextBox();
            txtPhoneNumber = new TextBox();
            txtSize = new TextBox();
            txtCoordinates = new TextBox();
            txtFishSpecies = new TextBox();
            lblCoordinates = new Label();
            lblFishSpecies = new Label();
            lblFishingLicense = new Label();
            txtWebsite = new TextBox();
            chkFishingLicense = new CheckBox();
            chkToilet = new CheckBox();
            chkCleanTable = new CheckBox();
            chkHandicap = new CheckBox();
            chkFamily = new CheckBox();
            txtSpotType = new TextBox();
            lblSpotType = new Label();
            SuspendLayout();
            // 
            // lstPonds
            // 
            lstPonds.FormattingEnabled = true;
            lstPonds.Location = new Point(12, 94);
            lstPonds.Name = "lstPonds";
            lstPonds.Size = new Size(415, 484);
            lstPonds.TabIndex = 0;
            lstPonds.SelectedIndexChanged += lstPonds_SelectedIndexChanged;
            // 
            // lblPutAndTakePonds
            // 
            lblPutAndTakePonds.AutoSize = true;
            lblPutAndTakePonds.Location = new Point(19, 38);
            lblPutAndTakePonds.Name = "lblPutAndTakePonds";
            lblPutAndTakePonds.Size = new Size(221, 32);
            lblPutAndTakePonds.TabIndex = 1;
            lblPutAndTakePonds.Text = "Put and Take Ponds";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(12, 594);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(209, 46);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(227, 594);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(200, 46);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 657);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(209, 46);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblSpotNumber
            // 
            lblSpotNumber.AutoSize = true;
            lblSpotNumber.Location = new Point(460, 38);
            lblSpotNumber.Name = "lblSpotNumber";
            lblSpotNumber.Size = new Size(158, 32);
            lblSpotNumber.TabIndex = 5;
            lblSpotNumber.Text = "Spot Number";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(460, 85);
            lblName.Name = "lblName";
            lblName.Size = new Size(78, 32);
            lblName.TabIndex = 6;
            lblName.Text = "Name";
            // 
            // Address
            // 
            Address.AutoSize = true;
            Address.Location = new Point(460, 130);
            Address.Name = "Address";
            Address.Size = new Size(98, 32);
            Address.TabIndex = 7;
            Address.Text = "Address";
            // 
            // lblZipCode
            // 
            lblZipCode.AutoSize = true;
            lblZipCode.Location = new Point(460, 175);
            lblZipCode.Name = "lblZipCode";
            lblZipCode.Size = new Size(111, 32);
            lblZipCode.TabIndex = 8;
            lblZipCode.Text = "Zip Code";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(460, 220);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(71, 32);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(460, 265);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(177, 32);
            lblPhoneNumber.TabIndex = 10;
            lblPhoneNumber.Text = "Phone Number";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(460, 310);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(128, 32);
            lblSize.TabIndex = 11;
            lblSize.Text = "Size (m^2)";
            // 
            // lblWebsite
            // 
            lblWebsite.AutoSize = true;
            lblWebsite.Location = new Point(460, 671);
            lblWebsite.Name = "lblWebsite";
            lblWebsite.Size = new Size(178, 32);
            lblWebsite.TabIndex = 16;
            lblWebsite.Text = "Link to Website";
            // 
            // txtSpotNumber
            // 
            txtSpotNumber.Location = new Point(721, 35);
            txtSpotNumber.Name = "txtSpotNumber";
            txtSpotNumber.Size = new Size(315, 39);
            txtSpotNumber.TabIndex = 17;
            // 
            // txtName
            // 
            txtName.Location = new Point(721, 78);
            txtName.Name = "txtName";
            txtName.Size = new Size(315, 39);
            txtName.TabIndex = 18;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(721, 123);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(315, 39);
            txtAddress.TabIndex = 19;
            // 
            // txtZipCode
            // 
            txtZipCode.Location = new Point(721, 168);
            txtZipCode.Name = "txtZipCode";
            txtZipCode.Size = new Size(315, 39);
            txtZipCode.TabIndex = 20;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(721, 213);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(315, 39);
            txtEmail.TabIndex = 21;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(721, 258);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(315, 39);
            txtPhoneNumber.TabIndex = 22;
            // 
            // txtSize
            // 
            txtSize.Location = new Point(721, 303);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(315, 39);
            txtSize.TabIndex = 23;
            // 
            // txtCoordinates
            // 
            txtCoordinates.Location = new Point(721, 348);
            txtCoordinates.Name = "txtCoordinates";
            txtCoordinates.Size = new Size(315, 39);
            txtCoordinates.TabIndex = 24;
            // 
            // txtFishSpecies
            // 
            txtFishSpecies.Location = new Point(721, 393);
            txtFishSpecies.Name = "txtFishSpecies";
            txtFishSpecies.Size = new Size(315, 39);
            txtFishSpecies.TabIndex = 25;
            // 
            // lblCoordinates
            // 
            lblCoordinates.AutoSize = true;
            lblCoordinates.Location = new Point(460, 355);
            lblCoordinates.Name = "lblCoordinates";
            lblCoordinates.Size = new Size(142, 32);
            lblCoordinates.TabIndex = 29;
            lblCoordinates.Text = "Coordinates";
            // 
            // lblFishSpecies
            // 
            lblFishSpecies.AutoSize = true;
            lblFishSpecies.Location = new Point(460, 400);
            lblFishSpecies.Name = "lblFishSpecies";
            lblFishSpecies.Size = new Size(143, 32);
            lblFishSpecies.TabIndex = 30;
            lblFishSpecies.Text = "Fish Species";
            // 
            // lblFishingLicense
            // 
            lblFishingLicense.AutoSize = true;
            lblFishingLicense.Location = new Point(460, 446);
            lblFishingLicense.Name = "lblFishingLicense";
            lblFishingLicense.Size = new Size(0, 32);
            lblFishingLicense.TabIndex = 31;
            // 
            // txtWebsite
            // 
            txtWebsite.Location = new Point(721, 664);
            txtWebsite.Name = "txtWebsite";
            txtWebsite.Size = new Size(315, 39);
            txtWebsite.TabIndex = 34;
            // 
            // chkFishingLicense
            // 
            chkFishingLicense.AutoSize = true;
            chkFishingLicense.Location = new Point(483, 500);
            chkFishingLicense.Name = "chkFishingLicense";
            chkFishingLicense.Size = new Size(207, 36);
            chkFishingLicense.TabIndex = 35;
            chkFishingLicense.Text = "Fishing License";
            chkFishingLicense.UseVisualStyleBackColor = true;
            // 
            // chkToilet
            // 
            chkToilet.AutoSize = true;
            chkToilet.Location = new Point(721, 500);
            chkToilet.Name = "chkToilet";
            chkToilet.Size = new Size(104, 36);
            chkToilet.TabIndex = 36;
            chkToilet.Text = "Toilet";
            chkToilet.UseVisualStyleBackColor = true;
            // 
            // chkCleanTable
            // 
            chkCleanTable.AutoSize = true;
            chkCleanTable.Location = new Point(483, 553);
            chkCleanTable.Name = "chkCleanTable";
            chkCleanTable.Size = new Size(168, 36);
            chkCleanTable.TabIndex = 37;
            chkCleanTable.Text = "Clean Table";
            chkCleanTable.UseVisualStyleBackColor = true;
            // 
            // chkHandicap
            // 
            chkHandicap.AutoSize = true;
            chkHandicap.Location = new Point(721, 553);
            chkHandicap.Name = "chkHandicap";
            chkHandicap.Size = new Size(238, 36);
            chkHandicap.TabIndex = 38;
            chkHandicap.Text = "Handicap Friendly";
            chkHandicap.UseVisualStyleBackColor = true;
            // 
            // chkFamily
            // 
            chkFamily.AutoSize = true;
            chkFamily.Location = new Point(721, 604);
            chkFamily.Name = "chkFamily";
            chkFamily.Size = new Size(206, 36);
            chkFamily.TabIndex = 39;
            chkFamily.Text = "Family Friendly";
            chkFamily.UseVisualStyleBackColor = true;
            // 
            // txtSpotType
            // 
            txtSpotType.Location = new Point(721, 438);
            txtSpotType.Name = "txtSpotType";
            txtSpotType.Size = new Size(315, 39);
            txtSpotType.TabIndex = 40;
            // 
            // lblSpotType
            // 
            lblSpotType.AutoSize = true;
            lblSpotType.Location = new Point(460, 445);
            lblSpotType.Name = "lblSpotType";
            lblSpotType.Size = new Size(121, 32);
            lblSpotType.TabIndex = 41;
            lblSpotType.Text = "Spot Type";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 732);
            Controls.Add(lblSpotType);
            Controls.Add(txtSpotType);
            Controls.Add(chkFamily);
            Controls.Add(chkHandicap);
            Controls.Add(chkCleanTable);
            Controls.Add(chkToilet);
            Controls.Add(chkFishingLicense);
            Controls.Add(txtWebsite);
            Controls.Add(lblFishingLicense);
            Controls.Add(lblFishSpecies);
            Controls.Add(lblCoordinates);
            Controls.Add(txtFishSpecies);
            Controls.Add(txtCoordinates);
            Controls.Add(txtSize);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtEmail);
            Controls.Add(txtZipCode);
            Controls.Add(txtAddress);
            Controls.Add(txtName);
            Controls.Add(txtSpotNumber);
            Controls.Add(lblWebsite);
            Controls.Add(lblSize);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblEmail);
            Controls.Add(lblZipCode);
            Controls.Add(Address);
            Controls.Add(lblName);
            Controls.Add(lblSpotNumber);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(lblPutAndTakePonds);
            Controls.Add(lstPonds);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstPonds;
        private Label lblPutAndTakePonds;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Label lblSpotNumber;
        private Label lblName;
        private Label Address;
        private Label lblZipCode;
        private Label lblEmail;
        private Label lblPhoneNumber;
        private Label lblSize;
        private Label lblWebsite;
        private TextBox txtSpotNumber;
        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtZipCode;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private TextBox txtSize;
        private TextBox txtCoordinates;
        private TextBox txtFishSpecies;
        private Label lblCoordinates;
        private Label lblFishSpecies;
        private Label lblFishingLicense;
        private TextBox txtWebsite;
        private CheckBox chkFishingLicense;
        private CheckBox chkToilet;
        private CheckBox chkCleanTable;
        private CheckBox chkHandicap;
        private CheckBox chkFamily;
        private TextBox txtSpotType;
        private Label lblSpotType;
    }
}
