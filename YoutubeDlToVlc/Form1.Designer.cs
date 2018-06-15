namespace YoutubeDlToVlc
{
	partial class Form1
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.btnStartStream = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbStream = new System.Windows.Forms.TextBox();
			this.fcVlc = new EveChatNotifier.HelperControls.FileChooser();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.fcVlc, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbStream, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 6);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(761, 58);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 29);
			this.label1.TabIndex = 2;
			this.label1.Text = "vlc.exe path";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnStartStream
			// 
			this.btnStartStream.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnStartStream.Location = new System.Drawing.Point(349, 70);
			this.btnStartStream.Name = "btnStartStream";
			this.btnStartStream.Size = new System.Drawing.Size(75, 23);
			this.btnStartStream.TabIndex = 1;
			this.btnStartStream.Text = "Stream";
			this.btnStartStream.UseVisualStyleBackColor = true;
			this.btnStartStream.Click += new System.EventHandler(this.btnStartStream_Click);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(3, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 29);
			this.label2.TabIndex = 3;
			this.label2.Text = "vlc.exe path";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbStream
			// 
			this.tbStream.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbStream.Location = new System.Drawing.Point(103, 32);
			this.tbStream.Name = "tbStream";
			this.tbStream.Size = new System.Drawing.Size(655, 20);
			this.tbStream.TabIndex = 4;
			// 
			// fcVlc
			// 
			this.fcVlc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fcVlc.BackColor = System.Drawing.SystemColors.Window;
			this.fcVlc.Location = new System.Drawing.Point(103, 3);
			this.fcVlc.Name = "fcVlc";
			this.fcVlc.SelectedFile = "";
			this.fcVlc.Size = new System.Drawing.Size(655, 23);
			this.fcVlc.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(768, 98);
			this.Controls.Add(this.btnStartStream);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Enabled = false;
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private EveChatNotifier.HelperControls.FileChooser fcVlc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnStartStream;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbStream;
	}
}

