using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.LookAndFeel;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using Pst.DExpress.Localization;

namespace Vogue2_IMS.Common.FormBase
{
    public partial class RibbonFormSimpleDialogBase : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Language languageDefault = Language.Chinese;

        public RibbonFormSimpleDialogBase()
        {
            LocalizationCHS();
            //LanguageManager(languageDefault);

            InitializeComponent();            
            //LocalizationHandler.ControlLocalized(LocalizationType.CHS);//ExpressControl本地化
            //ribbonViewSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            SkinHelper.InitSkinGallery(ribbonViewSkins, true);
            UserLookAndFeel.Default.SetSkinStyle(DefaultSkinStyle);

            LanguageManager();
        }

        private void LocalizationCHS()
        {
            LocalizationHandler.ControlLocalized(LocalizationType.CHS);//ExpressControl本地化

            DevExpress.Accessibility.AccLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressUtilsLocalizationCHS();
            DevExpress.XtraBars.Localization.BarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraBarsLocalizationCHS();
            DevExpress.XtraCharts.Localization.ChartLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraChartsLocalizationCHS();
            //DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraEditorsLocalizationCHS();
            //DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraGridLocalizationCHS();
            DevExpress.XtraLayout.Localization.LayoutLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraLayoutLocalizationCHS();
            DevExpress.XtraNavBar.NavBarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraNavBarLocalizationCHS();
            DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPivotGridLocalizationCHS();
            DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPrintingLocalizationCHS();
            DevExpress.XtraReports.Localization.ReportLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraReportsLocalizationCHS();
            DevExpress.XtraRichEdit.Localization.XtraRichEditLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraRichEditLocalizationCHS();
            DevExpress.XtraRichEdit.Localization.RichEditExtensionsLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraRichEditExtensionsLocalizationCHS();
            DevExpress.XtraScheduler.Localization.SchedulerLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSchedulerLocalizationCHS();
            DevExpress.XtraScheduler.Localization.SchedulerExtensionsLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSchedulerExtensionsLocalizationCHS();
            //DevExpress.XtraSpellChecker.Localization.SpellCheckerLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSpellCheckerLocalizationCHS();
            DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraTreeListLocalizationCHS();
            DevExpress.XtraVerticalGrid.Localization.VGridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraVerticalGridLocalizationCHS();
            DevExpress.XtraWizard.Localization.WizardLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraWizardLocalizationCHS();

        }

        public RibbonFormSimpleDialogBase(Language language = Language.Chinese)
        {           
            LocalizationCHS();
            //LanguageManager(language);

            InitializeComponent();

            SkinHelper.InitSkinGallery(ribbonViewSkins, true);
            //LocalizationHandler.ControlLocalized(LocalizationType.CHS);//ExpressControl本地化

            UserLookAndFeel.Default.SetSkinStyle(DefaultSkinStyle);

            LanguageManager();
        }

        public RibbonControl MainRibbonControl { get { return this.ribbon; } set { this.ribbon = value; } }

        public RibbonPage MainPage { get { return this.IndividualizationRibbonPage; } set { this.IndividualizationRibbonPage = value; } }

        public RibbonPageGroup MainThemePageGroup { get { return this.themePageMain; } set { this.themePageMain = value; } }

        private void LanguageManager(Language language=Language.Chinese)
        {
            if (language.Equals(Language.Chinese))
            {
                //var items = ribbonViewSkins.Gallery.GetAllItems();
                //ribbonViewSkins.Gallery.GetAllItems().ForEach(item =>
                //{
                //    string defaultCaption = item.Tag as string;
                //    item.Caption = SkinLocalization.SkinLocalizationCHS[defaultCaption];
                //    item.Hint = item.Caption;
                //});

                IndividualizationRibbonPage.Text = "显示";
                themePageMain.Text = "主题";
                barBtnAbout.Caption = "关于我们";               
            }
            else
            {
                IndividualizationRibbonPage.Text = "System Config";
                themePageMain.Text = "Theme";
                barBtnAbout.Caption = "About";
            }
        }
        static bool isFristLoad = true;
        private void ribbonViewSkins_GalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            if (!isFristLoad)
            {
                DefaultSkinStyle = e.Item.Tag.ToString();
            }
            {
                isFristLoad = false;
            }
        }

        private string DefaultSkinStyle
        {
            get
            {
                if (!ConfigurationManager.AppSettings.AllKeys.Contains("Default.SkinSytle"))
                {
                    UpdateAppsetting("Default.SkinSytle", SkinCaptions.DevExpressStyle);
                }

                return ConfigurationManager.AppSettings["Default.SkinSytle"];
            }
            set
            {
                UpdateAppsetting("Default.SkinSytle", value); 
            }
        }

        private static void UpdateAppsetting(string key,string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings.AllKeys.Contains(key))
            {
                config.AppSettings.Settings.Remove(key);
            }

            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public ImageCollection ImageList32
        {
            get { return this.image32; }
        }

        public ImageCollection ImageList16
        {
            get { return this.image16; }
        }
        
    }
}