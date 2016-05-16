using DevExpress.XtraBars.Localization;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraTreeList.Localization;
using Pst.DExpress.Localization.ControlLocalization;

namespace Pst.DExpress.Localization
{
    public class LocalizationHandler
    {
        public static LocalizationType RuntimeLocalizationType { get { return LocalizationConfigHandler.RuntimeLocalizationType; }

            set { LocalizationConfigHandler.RuntimeLocalizationType = value; }
        }

        public static void ControlLocalized(LocalizationType localizationType)
        {
            LocalizationConfigHandler.RuntimeLocalizationType = localizationType;
            ControlLocalized();
        }

        private static void ControlLocalized()
        {
            GridLocalizer.Active = new XtraGridLocalizer();
            
            NavBarLocalizer.Active = new XtraNavBarLocalizer();

            Localizer.Active = new XtraChEditLocalizer();

            TreeListLocalizer.Active = new XtraTreeListLocalizer();

            BarLocalizer.Active = new XtraNavBarsLocalizer();

            PreviewLocalizer.Active = new XtraPreviewLocaizer();
            
        }
    }
}
