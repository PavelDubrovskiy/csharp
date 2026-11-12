using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Common.Excel
{
   public static class DataTableExtentions
    {
        public static MemoryStream ToMemoryStream(this XLWorkbook xlWorkBook)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                xlWorkBook.SaveAs(stream);
                return stream;

            }
        }
    }
}
