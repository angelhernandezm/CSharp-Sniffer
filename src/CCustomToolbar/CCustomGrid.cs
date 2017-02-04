using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Sniffer.UI.Control {
	public class CCustomGrid : System.Windows.Forms.DataGrid {
		private System.ComponentModel.Container components = null;
        private const int WM_KEYDOWN  = 100;
        private const int WM_SYSKEYDOWN  = 104;
        private const int KEYSINTERESTEDIN = 256;

        public delegate void CustomKeyPressHandler(Keys pressed);
        public event CustomKeyPressHandler OnPressingKey;

		public CCustomGrid() {
			InitializeComponent();
		}

		protected override void Dispose( bool disposing ) {
			if( disposing && components != null)
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
			components = new System.ComponentModel.Container();
		}
		#endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if ( (msg.Msg.Equals(WM_KEYDOWN) || msg.Msg.Equals(WM_SYSKEYDOWN) ||
                msg.Msg.Equals(KEYSINTERESTEDIN)) &&  OnPressingKey != null) 
              OnPressingKey(keyData);
        
            return base.ProcessCmdKey (ref msg, keyData);
        }
	}
}
