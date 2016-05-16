using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Vogue2_IMS.Common;

namespace DXWindowsApplication1
{
    public partial class DemoExcel : Form
    {
        public DemoExcel()
        {
            InitializeComponent();
        }

        private void btnSelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C:\\";
            ofd.Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx";
            //ofd.RestoreDirectory = true;
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.label1.Text = ofd.FileName;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //var sheetNames = ExcelHelper.Instance.GetSheetNames(this.label1.Text);
            //DataTable dt = ExcelHelper.Instance.ExcelToDataTable(this.label1.Text, sheetNames[0]);
            //this.dataGridView1.DataSource = dt;

            var dt = ExcelBuilder.ToDataTable(this.label1.Text, 0, true);
            this.dataGridView1.DataSource = dt;

        }



    }


    public class ExcelBuilder
    {

        /// <summary>

        /// exact excel data into DataTable

        /// </summary>

        /// <param name="excel">excel file name</param>

        /// <param name="index">sheet index </param>

        /// <param name="header"> the first row in excel whether belongs the columns</param>

        /// <returns>DataTable</returns>

        public static DataTable ToDataTable(string excel, int index, bool header)
        {
            DataTable dt = new DataTable(Path.GetFileNameWithoutExtension(excel) + "_Sheet" + index);
            IWorkbook workbook;
            using (FileStream file = new FileStream(excel, FileMode.Open, FileAccess.Read))
            {
                workbook = WorkbookFactory.Create(file);
            }
            ISheet sheet = workbook.GetSheetAt(index);

            if (header)
            {
                IRow row = sheet.GetRow(sheet.FirstRowNum);
                for (var i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);
                    dt.Columns.Add(cell == null ? i.ToString() : cell.ToString());
                }
            }

            for (var i = 0; i < sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null)
                    continue;

                if (i == 0)
                {
                    for (var j = 0; j < row.LastCellNum; j++)
                    {
                        ICell cell = row.GetCell(j);
                        if (cell == null)
                            dt.Columns.Add(j.ToString());
                        else
                            dt.Columns.Add(cell.ToString());
                    }
                    continue;
                }
                DataRow dataRow = dt.NewRow();
                for (var j = 0; j < row.LastCellNum; j++)
                {
                    ICell cell = row.GetCell(j);
                    dataRow[j] = cell == null ? null : cell.ToString();
                }
                dt.Rows.Add(dataRow);
            }

            return dt;
        }
    
    }
}
