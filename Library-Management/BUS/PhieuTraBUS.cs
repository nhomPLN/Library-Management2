using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Windows.Forms;

namespace BUS
{
    public class PhieuTraBUS
    {
        List<PhieuTraDTO> ListReturnReceipt = new List<PhieuTraDTO>();
        PhieuTraDAL phieutraDAL = new PhieuTraDAL();
        QuyDinhPhieuTraBUS quydinhphieutraBUS = new QuyDinhPhieuTraBUS();
        PhieuTraDTO phieutraDTO = new PhieuTraDTO();
        PhieuMuonDAL phieumuonDAL = new PhieuMuonDAL();

        public int IDGenerator(DataGridViewRow SelectedRow = null)
        {
            if (SelectedRow != null)
            {
                return int.Parse(SelectedRow.Cells[0].Value.ToString());
            }

            return 1;
        }

        public bool ReturnItems(List<string> selectedBookIDs, string selected_Receipt_ID, string readerID, DateTime borrowdate, decimal coefficient)
        {
            List<string> listpara = new List<string>();

            foreach (string id in selectedBookIDs)
            {
                if(!CreateReturnReceipt(new PhieuTraDTO(selected_Receipt_ID, id, readerID, DateTime.Now, phieutraDTO.CalLibraryFine(int.Parse(coefficient.ToString())))))
                {
                    return false;
                }
                phieumuonDAL.DeleteReceipt(id, selected_Receipt_ID);
            }

            return true;
        }

        public bool CreateReturnReceipt(PhieuTraDTO returnreceipt)
        {
            return phieutraDAL.CreateReturnReceipt(returnreceipt);
        }

    }
}
