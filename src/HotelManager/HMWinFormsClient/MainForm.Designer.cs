namespace HMWinFormsClient
{
	partial class MainForm
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
			this.gbRequests = new System.Windows.Forms.GroupBox();
			this.btnReserve = new System.Windows.Forms.Button();
			this.tbTo = new System.Windows.Forms.TextBox();
			this.lblTo = new System.Windows.Forms.Label();
			this.tbFrom = new System.Windows.Forms.TextBox();
			this.lblFrom = new System.Windows.Forms.Label();
			this.gbRequests.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbRequests
			// 
			this.gbRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbRequests.Controls.Add(this.btnReserve);
			this.gbRequests.Controls.Add(this.tbTo);
			this.gbRequests.Controls.Add(this.lblTo);
			this.gbRequests.Controls.Add(this.tbFrom);
			this.gbRequests.Controls.Add(this.lblFrom);
			this.gbRequests.Location = new System.Drawing.Point(21, 24);
			this.gbRequests.Name = "gbRequests";
			this.gbRequests.Size = new System.Drawing.Size(249, 128);
			this.gbRequests.TabIndex = 0;
			this.gbRequests.TabStop = false;
			this.gbRequests.Text = "Request";
			// 
			// btnReserve
			// 
			this.btnReserve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReserve.Location = new System.Drawing.Point(23, 89);
			this.btnReserve.Name = "btnReserve";
			this.btnReserve.Size = new System.Drawing.Size(193, 23);
			this.btnReserve.TabIndex = 4;
			this.btnReserve.Text = "Reserve";
			this.btnReserve.UseVisualStyleBackColor = true;
			this.btnReserve.Click += new System.EventHandler(this.Reserve_Click);
			// 
			// tbTo
			// 
			this.tbTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTo.Location = new System.Drawing.Point(59, 52);
			this.tbTo.Name = "tbTo";
			this.tbTo.Size = new System.Drawing.Size(157, 20);
			this.tbTo.TabIndex = 3;
			// 
			// lblTo
			// 
			this.lblTo.AutoSize = true;
			this.lblTo.Location = new System.Drawing.Point(30, 55);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(23, 13);
			this.lblTo.TabIndex = 2;
			this.lblTo.Text = "To:";
			// 
			// tbFrom
			// 
			this.tbFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFrom.Location = new System.Drawing.Point(59, 24);
			this.tbFrom.Name = "tbFrom";
			this.tbFrom.Size = new System.Drawing.Size(157, 20);
			this.tbFrom.TabIndex = 1;
			// 
			// lblFrom
			// 
			this.lblFrom.AutoSize = true;
			this.lblFrom.Location = new System.Drawing.Point(20, 27);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(33, 13);
			this.lblFrom.TabIndex = 0;
			this.lblFrom.Text = "From:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(287, 174);
			this.Controls.Add(this.gbRequests);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SAP Hotel Manager =)";
			this.gbRequests.ResumeLayout(false);
			this.gbRequests.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbRequests;
		private System.Windows.Forms.TextBox tbTo;
		private System.Windows.Forms.Label lblTo;
		private System.Windows.Forms.TextBox tbFrom;
		private System.Windows.Forms.Label lblFrom;
		private System.Windows.Forms.Button btnReserve;
	}
}

