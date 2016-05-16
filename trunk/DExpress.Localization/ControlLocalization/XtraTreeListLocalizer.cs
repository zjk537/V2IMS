using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraTreeList.Localization;

namespace Pst.DExpress.Localization.ControlLocalization
{
    class XtraTreeListLocalizer : TreeListLocalizer
    {
        Dictionary<string, string> dicGridStringIdValues = new Dictionary<string, string>();

        public XtraTreeListLocalizer()
        {
            dicGridStringIdValues = LocalizationConfigHandler.ReadLocalizationConfig(ControlType.XtraTreeList);
        }

        public override string GetLocalizedString(TreeListStringId id)
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