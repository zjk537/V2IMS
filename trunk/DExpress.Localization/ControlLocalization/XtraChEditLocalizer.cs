using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraEditors.Controls;
using System.IO;

namespace Pst.DExpress.Localization.ControlLocalization
{
    public class XtraChEditLocalizer : Localizer
    {
        //static StringBuilder strb = new StringBuilder();
        Dictionary<string, string> dicGridStringIdValues = new Dictionary<string, string>();

        public XtraChEditLocalizer()
        {
            dicGridStringIdValues = LocalizationConfigHandler.ReadLocalizationConfig(ControlType.XtraChEdit);
        }

        public override string GetLocalizedString(StringId id)
        {
            if (dicGridStringIdValues.ContainsKey(id.ToString()))
            {
                return dicGridStringIdValues[id.ToString()];
            }
            else
            {
                string str = base.GetLocalizedString(id);

                File.AppendAllText("D:\\temp.txt", string.Format("  <data name='{0}' value='{1}'/>\r\n", id, str));

                return str;
            }
        }

    }
}