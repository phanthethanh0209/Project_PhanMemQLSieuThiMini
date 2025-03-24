using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class LabelTextbox_UC : UserControl
    {
        public LabelTextbox_UC()
        {
            InitializeComponent();
        }

        //Viết các property
        public string Label
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public string Textbox
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
    }
}
