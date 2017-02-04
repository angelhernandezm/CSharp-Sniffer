using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Sniffer.Common;

namespace Sniffer.UI.Control {
    public class CCustomComboBox : System.Windows.Forms.UserControl	{

        #region "Miembros"
            private System.ComponentModel.Container components = null;
        protected internal System.Windows.Forms.ComboBox cboCustom;
            private ImageList m_imageList;
        #endregion

        #region "Propiedades"
            public ImageList ImageList {
                get {return m_imageList;}
                set {m_imageList = value;}
            }

            public string ComboText {
                get {return cboCustom.Text;}
            }

            public bool ComboEnabled {
                get {return cboCustom.Enabled; }
                set {cboCustom.Enabled = value;}
            }
        #endregion

        #region  "Eventos"
            internal protected event CShare.SelectAddressHandler OnChangeNetworkAddress;
        #endregion

        public CCustomComboBox()	{
            InitializeComponent();
        }

        protected override void Dispose( bool disposing ) {
            if (disposing  && components != null) 
                    components.Dispose();
            base.Dispose( disposing );
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cboCustom = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboCustom
            // 
            this.cboCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCustom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustom.Location = new System.Drawing.Point(0, 0);
            this.cboCustom.Name = "cboCustom";
            this.cboCustom.Size = new System.Drawing.Size(120, 21);
            this.cboCustom.TabIndex = 0;
            this.cboCustom.SelectedIndexChanged += new System.EventHandler(this.cboCustom_SelectedIndexChanged);
            this.cboCustom.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cboCustom_DrawItem);
            // 
            // CCustomComboBox
            // 
            this.Controls.Add(this.cboCustom);
            this.Name = "CCustomComboBox";
            this.Size = new System.Drawing.Size(120, 20);
            this.Load += new System.EventHandler(this.CCustomComboBox_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private void cboCustom_DrawItem(object sender, DrawItemEventArgs e) {
            e.DrawBackground();
            e.DrawFocusRectangle();

            CCustomComboItem item;
            Size imagesz =  (Size) (m_imageList != null ? m_imageList.ImageSize : Size.Empty);
            Rectangle bounds = e.Bounds;

            try {
                item = (CCustomComboItem) cboCustom.Items[e.Index];

                if (item.ImageIndex != -1) {
                    m_imageList.Draw(e.Graphics, bounds.Left, bounds.Top, item.ImageIndex);
                    e.Graphics.DrawString(item.Text, e.Font,  new SolidBrush(e.ForeColor), 
                                                   bounds.Left + imagesz.Width, bounds.Top);
                } else e.Graphics.DrawString(item.Text, e.Font,  new SolidBrush(e.ForeColor),
                                                        bounds.Left, bounds.Top);
            } catch {
                if (e.Index != -1)
                    e.Graphics.DrawString(cboCustom.Items[e.Index].ToString(), e.Font, 
                                                   new SolidBrush(e.ForeColor), bounds.Left, bounds.Top);
                else e.Graphics.DrawString(cboCustom.Text, e.Font, 
                                                     new SolidBrush(e.ForeColor), bounds.Left, bounds.Top);
            }
        }

        private void CCustomComboBox_Load(object sender, System.EventArgs e) {
            cboCustom.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void cboCustom_SelectedIndexChanged(object sender, System.EventArgs e) {
            ComboBox selected  = sender as ComboBox;
            if (OnChangeNetworkAddress != null) OnChangeNetworkAddress(selected.Text);
        }
    }
}