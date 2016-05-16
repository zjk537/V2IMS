using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraNavBar;

namespace Pst.DExpress.Localization.ControlLocalization
{
    class XtraNavBarLocalizer : NavBarLocalizer
    {
        Dictionary<string, string> dicGridStringIdValues = new Dictionary<string, string>();

        public XtraNavBarLocalizer()
        {
            dicGridStringIdValues = LocalizationConfigHandler.ReadLocalizationConfig(ControlType.XtraNavBar);
        }

        public override string GetLocalizedString(NavBarStringId id)
        {
            if (dicGridStringIdValues.ContainsKey(id.ToString()))
            {
                return dicGridStringIdValues[id.ToString()];
            }
            else
            {
                return base.GetLocalizedString(id);
            }
        }

    }
}