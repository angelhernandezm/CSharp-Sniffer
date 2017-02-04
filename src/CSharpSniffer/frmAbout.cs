using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Sniffer.Common;

namespace Sniffer.UI {
	public class frmAbout : System.Windows.Forms.Form {
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip tipMain;
        private System.Windows.Forms.PictureBox pbxMCSD;
        private System.Windows.Forms.PictureBox pbxDM;
        private System.ComponentModel.IContainer components;

		public frmAbout() {
			InitializeComponent();
		}

		protected override void Dispose( bool disposing ){
			if( disposing )	{
				if(components != null)	{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAbout));
            this.pbxMCSD = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.pbxDM = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // pbxMCSD
            // 
            this.pbxMCSD.BackColor = System.Drawing.Color.White;
            this.pbxMCSD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxMCSD.Image = ((System.Drawing.Image)(resources.GetObject("pbxMCSD.Image")));
            this.pbxMCSD.Location = new System.Drawing.Point(16, 16);
            this.pbxMCSD.Name = "pbxMCSD";
            this.pbxMCSD.Size = new System.Drawing.Size(112, 56);
            this.pbxMCSD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxMCSD.TabIndex = 1;
            this.pbxMCSD.TabStop = false;
            this.tipMain.SetToolTip(this.pbxMCSD, "Microsoft Certified Solution Developer For .NET");
            this.pbxMCSD.Click += new System.EventHandler(this.NavigateToTarget);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(272, 136);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&Aceptar";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(144, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "CSharpSniffer es una aplicación que muestra como crear y usar un Sniffer Socket. " +
                "Desarrollado por Angel J. Hernández M. Administrador de la comunidad \"Desarrolla" +
                "dores Miranda\"";
            // 
            // pbxDM
            // 
            this.pbxDM.BackColor = System.Drawing.Color.White;
            this.pbxDM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxDM.Image = ((System.Drawing.Image)(resources.GetObject("pbxDM.Image")));
            this.pbxDM.Location = new System.Drawing.Point(16, 88);
            this.pbxDM.Name = "pbxDM";
            this.pbxDM.Size = new System.Drawing.Size(112, 56);
            this.pbxDM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDM.TabIndex = 4;
            this.pbxDM.TabStop = false;
            this.tipMain.SetToolTip(this.pbxDM, "Desarrolladores Miranda");
            this.pbxDM.Click += new System.EventHandler(this.NavigateToTarget);
            // 
            // frmAbout
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(362, 168);
            this.Controls.Add(this.pbxDM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pbxMCSD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Acerca de CSharpSniffer...";
            this.ResumeLayout(false);

        }
		#endregion

        private void NavigateToTarget(object sender, System.EventArgs e) {
            CShare.NavigateToURL( (string) (((PictureBox) sender).Name.ToUpper().Equals(CShare.MCSDPBX) ?
                                             CShare.MCPURL : CShare.DMURL));
        }

        private void btnOK_Click(object sender, System.EventArgs e) {
            Close();
        }
	}
}
