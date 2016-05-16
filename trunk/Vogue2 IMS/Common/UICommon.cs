using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Vogue2_IMS.Common
{
    class UICommon
    {
        const string errCaption = "错误";
        const string infoCaption = "提示";
        const string warningCaption = "警告";

        /// <summary>
        /// show delete warning
        /// </summary>
        /// <returns></returns>
        public static bool DeleteWarning()
        {
            if (XtraMessageBox.Show("确定要删除？", infoCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return false;
            }

            return true;
        }
    }
}
