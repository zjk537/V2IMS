using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Localization;

namespace Pst.DExpress.Localization.ControlLocalization
{
    class XtraGridLocalizer : GridLocalizer
    {
        Dictionary<string, string> dicGridStringIdValues = new Dictionary<string, string>();

        public XtraGridLocalizer()
        {
            dicGridStringIdValues = LocalizationConfigHandler.ReadLocalizationConfig(ControlType.XtraGrid);
        }

        public override string GetLocalizedString(GridStringId id)
        {
            if (dicGridStringIdValues.ContainsKey(id.ToString()))
            {
                return dicGridStringIdValues[id.ToString()];
            }
            else
            {
                string str = base.GetLocalizedString(id);
                return str;
            }
        }
    }
}