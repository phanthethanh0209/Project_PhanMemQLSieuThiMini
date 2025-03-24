using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class NhaCungCapBUL
    {
        NhaCungCapDAL dal;
        public NhaCungCapBUL()
        {
            dal = new NhaCungCapDAL();
        }
        public List<NhaCungCapDTO> layTatCaNhaCungCap()
        {
            return dal.layTatCaNhaCungCap();
        }

        public bool themNhaCungCap(NhaCungCapDTO ncc)
        {
            return dal.themNhaCungCap(ncc) == 1;
        }

        public bool suaNhaCungCap(NhaCungCapDTO ncc)
        {
            return dal.suaNhaCungCap(ncc) == 1;
        }

        public bool xoaNhaCungCap(string maNCC)
        {
            return dal.xoaNhaCungCap(maNCC) == 1;
        }

        public NhaCungCapDTO laySDTNhaCungCap(string sdt)
        {
            return dal.laySDTNhaCungCap(sdt);
        }

        public NhaCungCapDTO layNhaCungCapTheoMa(string maNCC)
        {
            return dal.layNhaCungCapTheoMa(maNCC);
        }

        public bool kiemTraTrungSDT(string sdt)
        {
            return dal.kiemTraSDTTonTai(sdt);
        }
    }
}
