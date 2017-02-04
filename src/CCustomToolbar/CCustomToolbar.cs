using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Sniffer;
using Sniffer.Common;


namespace Sniffer.UI.Control {
	public class CCustomToolbar : System.Windows.Forms.UserControl  {
        #region "Miembros"
            private System.Windows.Forms.ContextMenu mnuProtocols;
            private System.Windows.Forms.ImageList imlCurrent;
            private System.Windows.Forms.Panel pnlBorder;
            private System.Windows.Forms.Button btnFilter;
        public System.Windows.Forms.Button btnAction;
            private CCommon.Protocols m_currentfilter = CCommon.Protocols.NONE;
        public Sniffer.UI.Control.CCustomComboBox cCustomComboBox;
            private System.Windows.Forms.MenuItem itm3;
            private System.Windows.Forms.MenuItem itm4;
            private System.Windows.Forms.MenuItem itm1;
            private System.Windows.Forms.MenuItem itm0;
        private System.Windows.Forms.ToolTip tipMain;
        private System.Windows.Forms.Button btnExportTrace;
            private System.ComponentModel.IContainer components;
        #endregion

        #region "Eventos"
            public event CShare.SetFilterHandler OnFilterSelected;
            public event CShare.SelectAddressHandler OnChangeNetworkAddress;
            public event EventHandler OnExportSelected;
            public event EventHandler OnPauseResumeSelected;
        #endregion

		public CCustomToolbar()	{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing ) {
			if( disposing && components != null )
					components.Dispose();
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CCustomToolbar));
            this.mnuProtocols = new System.Windows.Forms.ContextMenu();
            this.itm0 = new System.Windows.Forms.MenuItem();
            this.itm1 = new System.Windows.Forms.MenuItem();
            this.itm3 = new System.Windows.Forms.MenuItem();
            this.itm4 = new System.Windows.Forms.MenuItem();
            this.imlCurrent = new System.Windows.Forms.ImageList(this.components);
            this.pnlBorder = new System.Windows.Forms.Panel();
            this.btnExportTrace = new System.Windows.Forms.Button();
            this.cCustomComboBox = new Sniffer.UI.Control.CCustomComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuProtocols
            // 
            this.mnuProtocols.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                         this.itm0,
                                                                                         this.itm1,
                                                                                         this.itm3,
                                                                                         this.itm4});
            // 
            // itm0
            // 
            this.itm0.Index = 0;
            this.itm0.Text = "&NONE";
            this.itm0.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // itm1
            // 
            this.itm1.Index = 1;
            this.itm1.Text = "&ICMP";
            this.itm1.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // itm3
            // 
            this.itm3.Index = 2;
            this.itm3.Text = "&TCP";
            this.itm3.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // itm4
            // 
            this.itm4.Index = 3;
            this.itm4.Text = "&UDP";
            this.itm4.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // imlCurrent
            // 
            this.imlCurrent.ImageSize = new System.Drawing.Size(16, 16);
            this.imlCurrent.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlCurrent.ImageStream")));
            this.imlCurrent.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlBorder
            // 
            this.pnlBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBorder.Controls.Add(this.btnExportTrace);
            this.pnlBorder.Controls.Add(this.cCustomComboBox);
            this.pnlBorder.Controls.Add(this.btnFilter);
            this.pnlBorder.Controls.Add(this.btnAction);
            this.pnlBorder.Location = new System.Drawing.Point(0, 0);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Size = new System.Drawing.Size(248, 30);
            this.pnlBorder.TabIndex = 0;
            // 
            // btnExportTrace
            // 
            this.btnExportTrace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExportTrace.ImageIndex = 4;
            this.btnExportTrace.ImageList = this.imlCurrent;
            this.btnExportTrace.Location = new System.Drawing.Point(216, 2);
            this.btnExportTrace.Name = "btnExportTrace";
            this.btnExportTrace.Size = new System.Drawing.Size(24, 23);
            this.btnExportTrace.TabIndex = 3;
            this.tipMain.SetToolTip(this.btnExportTrace, "Exportar Traza...");
            this.btnExportTrace.Click += new System.EventHandler(this.btnExportTrace_Click);
            // 
            // cCustomComboBox
            // 
            this.cCustomComboBox.ImageList = null;
            this.cCustomComboBox.Location = new System.Drawing.Point(42, 3);
            this.cCustomComboBox.Name = "cCustomComboBox";
            this.cCustomComboBox.Size = new System.Drawing.Size(129, 20);
            this.cCustomComboBox.TabIndex = 1;
            this.tipMain.SetToolTip(this.cCustomComboBox, "Tarjetas de red disponibles");
            // 
            // btnFilter
            // 
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.Location = new System.Drawing.Point(183, 2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(24, 23);
            this.btnFilter.TabIndex = 2;
            this.tipMain.SetToolTip(this.btnFilter, "Filtro de paquetes");
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnAction
            // 
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAction.ImageIndex = 0;
            this.btnAction.ImageList = this.imlCurrent;
            this.btnAction.Location = new System.Drawing.Point(7, 2);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(24, 23);
            this.btnAction.TabIndex = 0;
            this.tipMain.SetToolTip(this.btnAction, "Activa / Desactiva la traza");
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // CCustomToolbar
            // 
            this.Controls.Add(this.pnlBorder);
            this.Name = "CCustomToolbar";
            this.Size = new System.Drawing.Size(250, 32);
            this.Load += new System.EventHandler(this.CCustomToolbar_Load);
            this.pnlBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        private void btnFilter_Click(object sender, System.EventArgs e) {
            mnuProtocols.Show(btnFilter, new Point(btnFilter.Location.X - 160, btnFilter.Location.Y - 2));
        }

        private void CCustomToolbar_Load(object sender, System.EventArgs e) {
            cCustomComboBox.ImageList = imlCurrent;
            String[] addresses = CCommon.GetNetworkAdapterAddresses();

            foreach(string addr in addresses) 
                cCustomComboBox.cboCustom.Items.Add(new CCustomComboItem(addr, 2));

            cCustomComboBox.OnChangeNetworkAddress += 
                  new Sniffer.Common.CShare.SelectAddressHandler(cCustomComboBox_OnChangeNetworkAddress);
        }

        private void MenuItemClicked(object sender, System.EventArgs e) {
            MenuItem selected = sender as MenuItem;

            foreach(MenuItem item in selected.Parent.MenuItems)
                item.Checked = false; 
            selected.Checked = true; 

            m_currentfilter =  (CCommon.Protocols)  (selected.Index.Equals(0) ? CCommon.Protocols.NONE :
                                                                      selected.Index.Equals(1) ? CCommon.Protocols.ICMP :
                                                                      selected.Index.Equals(2) ? CCommon.Protocols.TCP :
                                                                      CCommon.Protocols.UDP);

            if (OnFilterSelected != null) OnFilterSelected(m_currentfilter);
        }

        private void cCustomComboBox_OnChangeNetworkAddress(string selected) {
            if (OnChangeNetworkAddress != null) OnChangeNetworkAddress(selected);
        }

        private void btnExportTrace_Click(object sender, System.EventArgs e) {
            if (OnExportSelected != null) OnExportSelected(sender, e);
        }

        private void btnAction_Click(object sender, System.EventArgs e) {
            if (OnPauseResumeSelected != null) OnPauseResumeSelected(sender, e);
        }
    }
}