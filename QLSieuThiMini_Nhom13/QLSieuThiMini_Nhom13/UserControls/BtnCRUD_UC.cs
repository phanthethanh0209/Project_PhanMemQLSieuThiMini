using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13.UserControls
{
    public partial class BtnCRUD_UC : UserControl
    {
        public BtnCRUD_UC()
        {
            InitializeComponent();
        }


        private void capNhatTrangThaiButton(string status)
        {
            if (status == "Edit")
            {
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;

                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else if (status == "View")
            {
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void BtnCRUD_UC_Load(object sender, EventArgs e)
        {
            capNhatTrangThaiButton("View");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            capNhatTrangThaiButton("View");
            OnHuyClickedHandler(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            capNhatTrangThaiButton("Edit");
            OnThemClickedHandler(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            capNhatTrangThaiButton("Edit");
            OnSuaClickedHandler(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            capNhatTrangThaiButton("Edit");
            OnXoaClickedHandler(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            capNhatTrangThaiButton("View");
            OnLuuClickedHandler(sender, e);
        }

        //public delegate void DeleteClickedHandler(object sender, EventArgs e);
        //public event DeleteClickedHandler DeleteClicked;

        //public virtual void OnDeleteClickedHandler(object sender, EventArgs e)
        //{
        //    if (DeleteClicked != null)
        //    {
        //        DeleteClicked(sender, e);
        //    }
        //}

        public delegate void LuuClickedHandler(object sender, EventArgs e);
        public event LuuClickedHandler LuuClicked;

        public virtual void OnLuuClickedHandler(object sender, EventArgs e)
        {
            if (LuuClicked != null)
            {
                LuuClicked(sender, e);
            }
        }

        public delegate void ThemClickedHandler(object sender, EventArgs e);
        public event ThemClickedHandler ThemClicked;

        public virtual void OnThemClickedHandler(object sender, EventArgs e)
        {
            if (ThemClicked != null)
            {
                ThemClicked(sender, e);
            }
        }

        public delegate void SuaClickedHandler(object sender, EventArgs e);
        public event SuaClickedHandler SuaClicked;

        public virtual void OnSuaClickedHandler(object sender, EventArgs e)
        {
            if (SuaClicked != null)
            {
                SuaClicked(sender, e);
            }
        }


        public delegate void XoaClickedHandler(object sender, EventArgs e);
        public event XoaClickedHandler XoaClicked;

        public virtual void OnXoaClickedHandler(object sender, EventArgs e)
        {
            if (XoaClicked != null)
            {
                XoaClicked(sender, e);
            }
        }


        public delegate void HuyClickedHandler(object sender, EventArgs e);
        public event HuyClickedHandler HuyClicked;

        public virtual void OnHuyClickedHandler(object sender, EventArgs e)
        {
            if (HuyClicked != null)
            {
                HuyClicked(sender, e);
            }
        }

        
    }
}
