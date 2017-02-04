/* Archivo: frmCSharpSniffer.cs
   Fecha: Octubre 2004 
   Autor: Angel J. Hernández M
   Lenguaje: Microsoft (R) Visual C# .NET Compiler version 7.10.6001.4
   E-m@il: angeljesus14@hotmail.com
   URL: http://groups.msn.com/desarrolladoresmiranda 

   Notas: Ventana principal de la aplicación.
*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using Sniffer;
using Sniffer.Common;
using Sniffer.UI.Control;

namespace Sniffer.UI {
    public class frmCSharpSniffer : System.Windows.Forms.Form	{
        private System.Windows.Forms.ImageList imlCurrent;
        private System.Windows.Forms.StatusBar sbrSummary;
        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Splitter splBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Splitter splTop;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Splitter splCenter;
        private System.Windows.Forms.Panel pnlRight;
        private Sniffer.UI.Control.CCustomGrid grdSummary;
        private System.Windows.Forms.Panel pnlLeftUp;
        private System.Windows.Forms.Panel pnlLeftDown;
        private System.Windows.Forms.TreeView trvNetwork;
        private Sniffer.UI.Control.CCustomToolbar cCustomToolbar;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.TreeView trvNetworkCardDetails;
        private System.Windows.Forms.StatusBarPanel sbpStatus;
        private System.ComponentModel.IContainer components;
        private DataSet m_packettrace = null;
        private DataSet m_workingds = null;
		private bool m_needstobeupdated = true;
        private DataView m_customview;
        private CRawSocket m_rawsocket;
        private System.Windows.Forms.Panel pnlBottomLeft;
        private System.Windows.Forms.Panel pnlBottomRight;
        private System.Windows.Forms.TextBox txtPackageContent;
        private System.Windows.Forms.ListBox lstNetworkStats;
        private System.Windows.Forms.Timer tmrRefresh;
        private bool m_tracestate = true;

        public frmCSharpSniffer()	{
            InitializeComponent();
        }

        protected override void Dispose( bool disposing ) {
            if (disposing && components != null )
                components.Dispose();
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCSharpSniffer));
			this.imlCurrent = new System.Windows.Forms.ImageList(this.components);
			this.sbrSummary = new System.Windows.Forms.StatusBar();
			this.sbpStatus = new System.Windows.Forms.StatusBarPanel();
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.pnlBottomRight = new System.Windows.Forms.Panel();
			this.txtPackageContent = new System.Windows.Forms.TextBox();
			this.pnlBottomLeft = new System.Windows.Forms.Panel();
			this.lstNetworkStats = new System.Windows.Forms.ListBox();
			this.splBottom = new System.Windows.Forms.Splitter();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.cCustomToolbar = new Sniffer.UI.Control.CCustomToolbar();
			this.splTop = new System.Windows.Forms.Splitter();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.pnlLeftDown = new System.Windows.Forms.Panel();
			this.trvNetwork = new System.Windows.Forms.TreeView();
			this.pnlLeftUp = new System.Windows.Forms.Panel();
			this.trvNetworkCardDetails = new System.Windows.Forms.TreeView();
			this.splCenter = new System.Windows.Forms.Splitter();
			this.pnlRight = new System.Windows.Forms.Panel();
			this.grdSummary = new Sniffer.UI.Control.CCustomGrid();
			this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.sbpStatus)).BeginInit();
			this.pnlBottom.SuspendLayout();
			this.pnlBottomRight.SuspendLayout();
			this.pnlBottomLeft.SuspendLayout();
			this.pnlTop.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			this.pnlLeftDown.SuspendLayout();
			this.pnlLeftUp.SuspendLayout();
			this.pnlRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdSummary)).BeginInit();
			this.SuspendLayout();
			// 
			// imlCurrent
			// 
			this.imlCurrent.ImageSize = new System.Drawing.Size(16, 16);
			this.imlCurrent.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlCurrent.ImageStream")));
			this.imlCurrent.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// sbrSummary
			// 
			this.sbrSummary.Location = new System.Drawing.Point(0, 373);
			this.sbrSummary.Name = "sbrSummary";
			this.sbrSummary.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.sbpStatus});
			this.sbrSummary.ShowPanels = true;
			this.sbrSummary.Size = new System.Drawing.Size(696, 16);
			this.sbrSummary.TabIndex = 5;
			// 
			// sbpStatus
			// 
			this.sbpStatus.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.sbpStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.sbpStatus.Text = "Estado...";
			this.sbpStatus.Width = 680;
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuItem1,
																					this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2});
			this.menuItem1.Text = "&Archivo";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "&Salir";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem4});
			this.menuItem3.Text = "&Acerca de...";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.Text = "Windows...";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "&CSharpSniffer...";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// pnlBottom
			// 
			this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlBottom.Controls.Add(this.pnlBottomRight);
			this.pnlBottom.Controls.Add(this.pnlBottomLeft);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new System.Drawing.Point(0, 317);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(696, 56);
			this.pnlBottom.TabIndex = 4;
			// 
			// pnlBottomRight
			// 
			this.pnlBottomRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlBottomRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlBottomRight.Controls.Add(this.txtPackageContent);
			this.pnlBottomRight.Location = new System.Drawing.Point(352, 0);
			this.pnlBottomRight.Name = "pnlBottomRight";
			this.pnlBottomRight.Size = new System.Drawing.Size(340, 52);
			this.pnlBottomRight.TabIndex = 1;
			// 
			// txtPackageContent
			// 
			this.txtPackageContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPackageContent.Location = new System.Drawing.Point(0, -1);
			this.txtPackageContent.Multiline = true;
			this.txtPackageContent.Name = "txtPackageContent";
			this.txtPackageContent.ReadOnly = true;
			this.txtPackageContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtPackageContent.Size = new System.Drawing.Size(336, 49);
			this.txtPackageContent.TabIndex = 0;
			this.txtPackageContent.Text = "";
			// 
			// pnlBottomLeft
			// 
			this.pnlBottomLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlBottomLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlBottomLeft.Controls.Add(this.lstNetworkStats);
			this.pnlBottomLeft.Location = new System.Drawing.Point(0, 0);
			this.pnlBottomLeft.Name = "pnlBottomLeft";
			this.pnlBottomLeft.Size = new System.Drawing.Size(352, 52);
			this.pnlBottomLeft.TabIndex = 0;
			// 
			// lstNetworkStats
			// 
			this.lstNetworkStats.Location = new System.Drawing.Point(1, 2);
			this.lstNetworkStats.Name = "lstNetworkStats";
			this.lstNetworkStats.Size = new System.Drawing.Size(344, 43);
			this.lstNetworkStats.TabIndex = 0;
			// 
			// splBottom
			// 
			this.splBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splBottom.Location = new System.Drawing.Point(0, 314);
			this.splBottom.Name = "splBottom";
			this.splBottom.Size = new System.Drawing.Size(696, 3);
			this.splBottom.TabIndex = 0;
			this.splBottom.TabStop = false;
			this.splBottom.Visible = false;
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.cCustomToolbar);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(696, 40);
			this.pnlTop.TabIndex = 0;
			// 
			// cCustomToolbar
			// 
			this.cCustomToolbar.Location = new System.Drawing.Point(0, 8);
			this.cCustomToolbar.Name = "cCustomToolbar";
			this.cCustomToolbar.Size = new System.Drawing.Size(248, 32);
			this.cCustomToolbar.TabIndex = 0;
			// 
			// splTop
			// 
			this.splTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.splTop.Location = new System.Drawing.Point(0, 40);
			this.splTop.Name = "splTop";
			this.splTop.Size = new System.Drawing.Size(696, 3);
			this.splTop.TabIndex = 6;
			this.splTop.TabStop = false;
			this.splTop.Visible = false;
			// 
			// pnlLeft
			// 
			this.pnlLeft.Controls.Add(this.pnlLeftDown);
			this.pnlLeft.Controls.Add(this.pnlLeftUp);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeft.Location = new System.Drawing.Point(0, 43);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Size = new System.Drawing.Size(208, 271);
			this.pnlLeft.TabIndex = 7;
			// 
			// pnlLeftDown
			// 
			this.pnlLeftDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlLeftDown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlLeftDown.Controls.Add(this.trvNetwork);
			this.pnlLeftDown.Location = new System.Drawing.Point(0, 125);
			this.pnlLeftDown.Name = "pnlLeftDown";
			this.pnlLeftDown.Size = new System.Drawing.Size(208, 135);
			this.pnlLeftDown.TabIndex = 2;
			// 
			// trvNetwork
			// 
			this.trvNetwork.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.trvNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trvNetwork.ImageList = this.imlCurrent;
			this.trvNetwork.Location = new System.Drawing.Point(0, 0);
			this.trvNetwork.Name = "trvNetwork";
			this.trvNetwork.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				   new System.Windows.Forms.TreeNode("Mi PC", 0, 0, new System.Windows.Forms.TreeNode[] {
																																											new System.Windows.Forms.TreeNode("LAN", 2, 2),
																																											new System.Windows.Forms.TreeNode("Internet", 1, 1)})});
			this.trvNetwork.Size = new System.Drawing.Size(204, 131);
			this.trvNetwork.TabIndex = 0;
			// 
			// pnlLeftUp
			// 
			this.pnlLeftUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlLeftUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlLeftUp.Controls.Add(this.trvNetworkCardDetails);
			this.pnlLeftUp.Location = new System.Drawing.Point(0, 8);
			this.pnlLeftUp.Name = "pnlLeftUp";
			this.pnlLeftUp.Size = new System.Drawing.Size(208, 112);
			this.pnlLeftUp.TabIndex = 0;
			// 
			// trvNetworkCardDetails
			// 
			this.trvNetworkCardDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.trvNetworkCardDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trvNetworkCardDetails.ImageIndex = 4;
			this.trvNetworkCardDetails.ImageList = this.imlCurrent;
			this.trvNetworkCardDetails.Location = new System.Drawing.Point(0, 0);
			this.trvNetworkCardDetails.Name = "trvNetworkCardDetails";
			this.trvNetworkCardDetails.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																							  new System.Windows.Forms.TreeNode("Tarjeta de Red", 3, 3, new System.Windows.Forms.TreeNode[] {
																																																new System.Windows.Forms.TreeNode("Tipo:"),
																																																new System.Windows.Forms.TreeNode("Dirección IP:"),
																																																new System.Windows.Forms.TreeNode("Submáscara de Red:"),
																																																new System.Windows.Forms.TreeNode("MAC Address:"),
																																																new System.Windows.Forms.TreeNode("Gateway: "),
																																																new System.Windows.Forms.TreeNode("Primary Wins Server:"),
																																																new System.Windows.Forms.TreeNode("DHCP: ")})});
			this.trvNetworkCardDetails.SelectedImageIndex = 4;
			this.trvNetworkCardDetails.Size = new System.Drawing.Size(204, 108);
			this.trvNetworkCardDetails.TabIndex = 0;
			// 
			// splCenter
			// 
			this.splCenter.Location = new System.Drawing.Point(208, 43);
			this.splCenter.Name = "splCenter";
			this.splCenter.Size = new System.Drawing.Size(3, 271);
			this.splCenter.TabIndex = 8;
			this.splCenter.TabStop = false;
			this.splCenter.Visible = false;
			// 
			// pnlRight
			// 
			this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlRight.Controls.Add(this.grdSummary);
			this.pnlRight.Location = new System.Drawing.Point(216, 51);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Size = new System.Drawing.Size(480, 261);
			this.pnlRight.TabIndex = 9;
			// 
			// grdSummary
			// 
			this.grdSummary.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.grdSummary.BackColor = System.Drawing.Color.WhiteSmoke;
			this.grdSummary.BackgroundColor = System.Drawing.Color.LightGray;
			this.grdSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grdSummary.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.grdSummary.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.grdSummary.DataMember = "";
			this.grdSummary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdSummary.FlatMode = true;
			this.grdSummary.Font = new System.Drawing.Font("Tahoma", 8F);
			this.grdSummary.ForeColor = System.Drawing.Color.MidnightBlue;
			this.grdSummary.GridLineColor = System.Drawing.Color.Gainsboro;
			this.grdSummary.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.grdSummary.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.grdSummary.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.grdSummary.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.grdSummary.LinkColor = System.Drawing.Color.Teal;
			this.grdSummary.Location = new System.Drawing.Point(0, 0);
			this.grdSummary.Name = "grdSummary";
			this.grdSummary.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.grdSummary.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.grdSummary.ReadOnly = true;
			this.grdSummary.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.grdSummary.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.grdSummary.Size = new System.Drawing.Size(480, 261);
			this.grdSummary.TabIndex = 0;
			// 
			// tmrRefresh
			// 
			this.tmrRefresh.Interval = 5000;
			this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
			// 
			// frmCSharpSniffer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 389);
			this.Controls.Add(this.pnlRight);
			this.Controls.Add(this.splCenter);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.splTop);
			this.Controls.Add(this.pnlTop);
			this.Controls.Add(this.splBottom);
			this.Controls.Add(this.pnlBottom);
			this.Controls.Add(this.sbrSummary);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mnuMain;
			this.Name = "frmCSharpSniffer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CSharpSniffer 1.0";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmCSharpSniffer_Closing);
			this.Load += new System.EventHandler(this.frmCSharpSniffer_Load);
			((System.ComponentModel.ISupportInitialize)(this.sbpStatus)).EndInit();
			this.pnlBottom.ResumeLayout(false);
			this.pnlBottomRight.ResumeLayout(false);
			this.pnlBottomLeft.ResumeLayout(false);
			this.pnlTop.ResumeLayout(false);
			this.pnlLeft.ResumeLayout(false);
			this.pnlLeftDown.ResumeLayout(false);
			this.pnlLeftUp.ResumeLayout(false);
			this.pnlRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdSummary)).EndInit();
			this.ResumeLayout(false);

		}
        #endregion

        [STAThread]
        static void Main() {
            Application.Run(new frmCSharpSniffer());
        }

        private void menuItem2_Click(object sender, System.EventArgs e) {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCSharpSniffer_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (MessageBox.Show(CShare.MSGBOXTEXT1, CShare.CONFIRMMSG,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                e.Cancel = true;
            else if (m_rawsocket != null) m_rawsocket.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCSharpSniffer_Load(object sender, System.EventArgs e) {
            PrepareForm();
            ShowSplashScreen();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="protocol"></param>
        private void cCustomToolbar_OnFilterSelected(Sniffer.CCommon.Protocols protocol) {
            if (m_rawsocket != null) m_rawsocket.FilteredProtocol = protocol;
            m_customview.RowFilter =  (string)  (!protocol.Equals(CCommon.Protocols.NONE) ?
                "Protocol = '"+protocol.ToString()+"'" :  string.Empty);
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selected"></param>
        private void cCustomToolbar_OnChangeNetworkAddress(string selected) {
            RefreshNetworkAdapterTree(CCommon.ParseAdapterInfoData(selected));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem4_Click(object sender, System.EventArgs e) {
            frmAbout dialog = new frmAbout();
            dialog.ShowDialog(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem5_Click(object sender, System.EventArgs e) {
            CCommon.ShowWindowsAboutBox(Handle, Text, CShare.APPINFO, Icon.Handle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="details"></param>
        private void RefreshNetworkAdapterTree(CCommon.TreeviewDetails details) {
            trvNetworkCardDetails.Nodes[0].Text = details.AdapterName;
            trvNetworkCardDetails.Nodes[0].Nodes[0].Text = "Tipo: "+details.Type;
            trvNetworkCardDetails.Nodes[0].Nodes[1].Text = "Dirección IP:"+details.IPAddress;
            trvNetworkCardDetails.Nodes[0].Nodes[2].Text = "Submáscara de Red: "+details.NetworkSubMask;
            trvNetworkCardDetails.Nodes[0].Nodes[3].Text = "MAC Address: "+details.MAC;
            trvNetworkCardDetails.Nodes[0].Nodes[4].Text = "Gateway: "+details.Gateway;
            trvNetworkCardDetails.Nodes[0].Nodes[5].Text = "Primary WINS Server: "+details.WINS;
            trvNetworkCardDetails.Nodes[0].Nodes[6].Text = "DHCP: "+details.DHCP;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cCustomToolbar_OnExportSelected(object sender, EventArgs e) {
            if (m_packettrace.Tables[CShare.TRACETABLENAME].Rows.Count > 0) {
                SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog().Equals(DialogResult.OK) && dialog.FileName.Length > 0)
                    m_packettrace.WriteXml(dialog.FileName);
            }   else MessageBox.Show(CShare.TABLEEMPTY, CShare.EXCLAMATIONMSG,
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cCustomToolbar_OnPauseResumeSelected(object sender, EventArgs e) {
            if (cCustomToolbar.cCustomComboBox.ComboText.Length > 0) {
                ManageStateIcons();
                /* Arrancamos o pausamos la traza según sea el caso */
                if (m_tracestate) {
                    if (m_rawsocket == null) {
                        m_rawsocket = new CRawSocket(cCustomToolbar.cCustomComboBox.ComboText, 0);
                        m_rawsocket.OnPacketReceived +=new Sniffer.CRawSocket.PacketReceivedHandler(m_rawsocket_OnPacketReceived);
                        m_rawsocket.OnStartSniffing +=new Sniffer.CRawSocket.SocketHandler(m_rawsocket_OnStartSniffing);
                        m_rawsocket.OnStopSniffing +=new Sniffer.CRawSocket.SocketHandler(m_rawsocket_OnStopSniffing);
                        cCustomToolbar.cCustomComboBox.ComboEnabled = false;
						tmrRefresh.Enabled = true;
                    }
                    m_rawsocket.IsListening = true;
                } else {
                    if (m_rawsocket != null) 
                        m_rawsocket.IsListening = false;
                }
            } else MessageBox.Show(CShare.ADAPTERNOTSELECTED, CShare.EXCLAMATIONMSG, 
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCSharpSniffer_RowChanged(object sender, DataRowChangeEventArgs e) {
            if (e.Action.Equals(DataRowAction.Add))
                e.Row["TimeStamp"] = DateTime.Now.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        private void PrepareForm() {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |
                         ControlStyles.DoubleBuffer, true);

            /* Configuramos el datagrid */
            PrepareDataSets();
            m_customview = new DataView(m_packettrace.Tables[CShare.TRACETABLENAME]);
            grdSummary.DataSource = m_customview;
            grdSummary.OnPressingKey +=new Sniffer.UI.Control.CCustomGrid.CustomKeyPressHandler(grdSummary_OnPressingKey);

            /* Asociamos los eventos que nos interesan con sus respectivos manejadores */
            cCustomToolbar.OnFilterSelected +=new CShare.SetFilterHandler(cCustomToolbar_OnFilterSelected);
            cCustomToolbar.OnChangeNetworkAddress +=new CShare.SelectAddressHandler(cCustomToolbar_OnChangeNetworkAddress);
            cCustomToolbar.OnExportSelected +=new EventHandler(cCustomToolbar_OnExportSelected);
            cCustomToolbar.OnPauseResumeSelected +=new EventHandler(cCustomToolbar_OnPauseResumeSelected);
            m_packettrace.Tables[CShare.TRACETABLENAME].RowChanged +=new DataRowChangeEventHandler(frmCSharpSniffer_RowChanged);
            ManageStateIcons();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ManageStateIcons() {
            m_tracestate = !m_tracestate;
            cCustomToolbar.btnAction.ImageIndex = (int)  (m_tracestate ? 0 : 1);
            int imgindex = (int)  (m_tracestate ? 5 : 6);
            sbrSummary.Panels[0].Text =  (string)  (m_tracestate ? CShare.CONNECTED : CShare.NOTCONNECTED);
            sbrSummary.Panels[0].Icon = Icon.FromHandle(((Bitmap) imlCurrent.Images[imgindex]).GetHicon());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="packetdata"></param>
        private void m_rawsocket_OnPacketReceived(object sender, Sniffer.CCommon.PacketContent packetdata) {
			CShare.RegisterEvent(m_workingds, packetdata);

            AddNetworkConnectionToTree((CShare.ConnectionType) (CShare.IsAnIPFromMyLAN(cCustomToolbar.cCustomComboBox.ComboText, packetdata.SourceIP) ? 
                                                             CShare.ConnectionType.LAN : CShare.ConnectionType.Internet), packetdata.SourceIP);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pressed"></param>
        private void grdSummary_OnPressingKey(Keys pressed) {
            if (pressed.Equals(Keys.Up) || pressed.Equals(Keys.Down)) {
                    CurrencyManager cm = (CurrencyManager) grdSummary.BindingContext[m_customview];
                    txtPackageContent.Text = cm.Position > -1 ? 
                        ((DataRowView) cm.Current).Row["PacketContent"].ToString() : string.Empty;
             }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowSplashScreen() {
            frmSplash dialog = new frmSplash();
            dialog.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="address"></param>
        private void AddNetworkConnectionToTree(CShare.ConnectionType type, string address) {
            bool found = false;
            address = CShare.GetPartFromIP(address, CShare.IPAddressPart.Address);

            TreeNode selected = type.Equals(CShare.ConnectionType.LAN) ? 
                                     trvNetwork.Nodes[0].Nodes[0] : trvNetwork.Nodes[0].Nodes[1];

            foreach(TreeNode node in selected.Nodes)
                if (node.Text.Equals(address)) {
                    found = true;
                    break;
                }

            if (!found) {
                CShare.ControlInvokeCallback callback = new CShare.ControlInvokeCallback(selected.Nodes.Add);
                selected.TreeView.Invoke(callback, new object[] {new TreeNode(address)});
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        private void m_rawsocket_OnStartSniffing(object sender) {
            string msg = CShare.EVENTLOGENTRY;
            msg = msg.Replace("%1", CShare.STARTSNIFFING)+sender.ToString();
            System.Diagnostics.EventLog.WriteEntry(Text, msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        private void m_rawsocket_OnStopSniffing(object sender) {
            string msg = CShare.EVENTLOGENTRY;
            msg = msg.Replace("%1", CShare.STOPSNIFFING)+sender.ToString();
            System.Diagnostics.EventLog.WriteEntry(Text, msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stats"></param>
        private void ShowNetworkStats(CCommon.NetworkStats stats) {
            lock(lstNetworkStats.Items) {
                lstNetworkStats.Items.Clear();
                lstNetworkStats.Items.Add("Estadísticas de la Red");
                lstNetworkStats.Items.Add("**************************");
                lstNetworkStats.Items.Add(string.Empty);
                lstNetworkStats.Items.Add("Bytes interceptados por el Sniffer: "+m_rawsocket.BytesReceived.ToString());
                lstNetworkStats.Items.Add(string.Empty);
                lstNetworkStats.Items.Add("ICMP");
                lstNetworkStats.Items.Add("******");
                lstNetworkStats.Items.Add("Mensajes enviados/recibidos: "+ stats.dwMsgs.ToString());
                lstNetworkStats.Items.Add("Echos (enviados/recibidos): "+ stats.dwEchos.ToString());
                lstNetworkStats.Items.Add("Destinos Inalcanzables: "+ stats.dwDestUnreachs.ToString());
                lstNetworkStats.Items.Add(string.Empty);
                lstNetworkStats.Items.Add("IP");
                lstNetworkStats.Items.Add("***");
                lstNetworkStats.Items.Add("Datagramas recibidos: "+stats.dwInReceives.ToString());
                lstNetworkStats.Items.Add("Datagramas enviados: "+stats.dwInDelivers.ToString());
                lstNetworkStats.Items.Add("Datagramas descartados: "+stats.dwOutDiscards.ToString());
                lstNetworkStats.Items.Add(string.Empty);
                lstNetworkStats.Items.Add("TCP");
                lstNetworkStats.Items.Add("******");
                lstNetworkStats.Items.Add("Segmentos recibidos: "+stats.dwInSegs.ToString());
                lstNetworkStats.Items.Add("Segmentos enviados: "+stats.dwOutSegs.ToString());
                lstNetworkStats.Items.Add("Nro. Acumulado de conexiones: "+stats.dwNumConns.ToString());
                lstNetworkStats.Items.Add(string.Empty);
                lstNetworkStats.Items.Add("UDP");
                lstNetworkStats.Items.Add("******");
                lstNetworkStats.Items.Add("Datagramas recibidos: "+stats.dwInDatagrams.ToString());
                lstNetworkStats.Items.Add("Datagramas enviados: "+stats.dwOutDatagrams.ToString());
            }
        } 

        /// <summary>
        /// 
        /// </summary>
        private void PrepareDataSets() {
            string[] dsnames = {CShare.TRACEDSNAME, CShare.WORKINGDSNAME};
            DataSet[] retval = new DataSet[dsnames.Length];    
            CShare.CreateDataSetCallback[] ptrtofunc = new CShare.CreateDataSetCallback[dsnames.Length];

            for(int x = 0; x < retval.Length; x++) {
                ptrtofunc[x] = new CShare.CreateDataSetCallback(CShare.CreateTraceDataSet);
                retval[x] = ptrtofunc[x](dsnames[x]);
            }
            m_packettrace = retval[0];
            m_workingds = retval[1];
        }

		private void tmrRefresh_Tick(object sender, System.EventArgs e) {
			if (m_needstobeupdated) {
				 m_needstobeupdated = false;
				 cCustomToolbar.btnAction.Enabled = false;  
				 DataTable table = m_workingds.Tables[CShare.TRACETABLENAME].Copy();
				 foreach(DataRow row in table.Rows)
				 	m_packettrace.Tables[CShare.TRACETABLENAME].Rows.Add(row.ItemArray);
				  m_workingds.Tables[CShare.TRACETABLENAME].Rows.Clear();
				  ShowNetworkStats(m_rawsocket.GetNetworkStats());
				  m_needstobeupdated = true;
				  cCustomToolbar.btnAction.Enabled = true;  
			}
		}
    }
}