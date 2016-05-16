using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraBars.Localization;

namespace Pst.DExpress.Localization.ControlLocalization
{
    class XtraNavBarsLocalizer : BarLocalizer
    {
        Dictionary<string, string> dicStringIdValues = new Dictionary<string, string>();

        public XtraNavBarsLocalizer()
        {
            dicStringIdValues = LocalizationConfigHandler.ReadLocalizationConfig(ControlType.XtraNavBars);
        }

        public override string GetLocalizedString(BarString id)
        {
            if (dicStringIdValues.ContainsKey(id.ToString()))
            {
                if(id.ToString().Equals("RibbonToolbarMinimizeRibbon"))
                {
                    string STR=string.Empty;
                }

                return dicStringIdValues[id.ToString()];
            }
            else
            {
                string str = base.GetLocalizedString(id);
                return str;
            }
        }
    }
}