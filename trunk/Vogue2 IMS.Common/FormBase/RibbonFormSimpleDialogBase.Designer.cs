namespace Vogue2_IMS.Common.FormBase
{
    partial class RibbonFormSimpleDialogBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonFormSimpleDialogBase));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.image16 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonViewSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.barBtnAbout = new DevExpress.XtraBars.BarButtonItem();
            this.image32 = new DevExpress.Utils.ImageCollection(this.components);
            this.IndividualizationRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.themePageMain = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image32)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            resources.ApplyResources(this.ribbon, "ribbon");
            // 
            // 
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Images = this.image16;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbonViewSkins,
            this.barBtnAbout});
            this.ribbon.LargeImages = this.image32;
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageHeaderItemLinks.Add(this.barBtnAbout);
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.IndividualizationRibbonPage});
            this.ribbon.SelectedPage = this.IndividualizationRibbonPage;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // image16
            // 
            this.image16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("image16.ImageStream")));
            this.image16.Images.SetKeyName(0, "Calendar_16x16.png");
            this.image16.Images.SetKeyName(1, "Drafts_16x16.png");
            this.image16.Images.SetKeyName(2, "Inbox_16x16.png");
            this.image16.Images.SetKeyName(3, "Mail_16x16.png");
            this.image16.Images.SetKeyName(4, "Organizer_16x16.png");
            this.image16.Images.SetKeyName(5, "Outbox_16x16.png");
            this.image16.Images.SetKeyName(6, "Tasks_16x16.png");
            this.image16.Images.SetKeyName(7, "Trash_16x16.png");
            this.image16.Images.SetKeyName(8, "Close_16x16.png");
            this.image16.Images.SetKeyName(9, "Save_16x16.png");
            this.image16.Images.SetKeyName(10, "SaveAs_16x16.png");
            this.image16.Images.SetKeyName(11, "Find_16x16.png");
            this.image16.Images.SetKeyName(12, "QueryDetail_16.png");
            this.image16.Images.SetKeyName(13, "Report_Day_16.png");
            this.image16.Images.SetKeyName(14, "Report_Month_16.png");
            this.image16.Images.SetKeyName(15, "Report_Preset_16.png");
            this.image16.Images.SetKeyName(16, "Report_Spread_16.png");
            this.image16.Images.SetKeyName(17, "Report_Week_16.png");
            this.image16.Images.SetKeyName(18, "Reprot_Performance_16.png");
            this.image16.Images.SetKeyName(19, "SpreadTime_16.png");
            this.image16.Images.SetKeyName(20, "ViewFormat_Card_16.png");
            this.image16.Images.SetKeyName(21, "ViewFormat_Format_16.png");
            this.image16.Images.SetKeyName(22, "20131123113355130_easyicon_net_16.png");
            this.image16.Images.SetKeyName(23, "Simple_Add_16.png");
            this.image16.Images.SetKeyName(24, "Simple_Add1_16.png");
            this.image16.Images.SetKeyName(25, "Simple_Edit_16.png");
            this.image16.Images.SetKeyName(26, "Simple_Remove_16.png");
            this.image16.Images.SetKeyName(27, "Shopping_16.png");
            this.image16.Images.SetKeyName(28, "Simple_Copy_16.png");
            this.image16.Images.SetKeyName(29, "Simple_Copy1_16.png");
            this.image16.Images.SetKeyName(30, "Pic_16.png");
            this.image16.Images.SetKeyName(31, "Simple_Pic_16.png");
            this.image16.Images.SetKeyName(32, "Simple_Pic1_16.png");
            this.image16.Images.SetKeyName(33, "Simple_Pic2_16.png");
            this.image16.Images.SetKeyName(34, "add_user.png");
            this.image16.Images.SetKeyName(35, "chat.png");
            this.image16.Images.SetKeyName(36, "edit_user.png");
            this.image16.Images.SetKeyName(37, "offline_user.png");
            this.image16.Images.SetKeyName(38, "remove_user.png");
            this.image16.Images.SetKeyName(39, "send.png");
            this.image16.Images.SetKeyName(40, "upload.png");
            this.image16.Images.SetKeyName(41, "user.png");
            this.image16.Images.SetKeyName(42, "user_group.png");
            this.image16.Images.SetKeyName(43, "video_chat.png");
            this.image16.Images.SetKeyName(44, "voice_chat.png");
            this.image16.Images.SetKeyName(46, "back.png");
            this.image16.Images.SetKeyName(47, "basket_back.png");
            this.image16.Images.SetKeyName(48, "left.png");
            this.image16.Images.SetKeyName(49, "ooopic_1505739023.png");
            this.image16.Images.SetKeyName(50, "Bar_code_24.446215139442px_1156986_easyicon.net.png");
            this.image16.Images.SetKeyName(51, "Bar_code_24.446215139442px_1156986_easyicon.net.png");
            // 
            // ribbonViewSkins
            // 
            resources.ApplyResources(this.ribbonViewSkins, "ribbonViewSkins");
            this.ribbonViewSkins.Id = 1;
            this.ribbonViewSkins.Name = "ribbonViewSkins";
            this.ribbonViewSkins.GalleryItemCheckedChanged += new DevExpress.XtraBars.Ribbon.GalleryItemEventHandler(this.ribbonViewSkins_GalleryItemCheckedChanged);
            // 
            // barBtnAbout
            // 
            resources.ApplyResources(this.barBtnAbout, "barBtnAbout");
            this.barBtnAbout.Id = 2;
            this.barBtnAbout.Name = "barBtnAbout";
            // 
            // image32
            // 
            resources.ApplyResources(this.image32, "image32");
            this.image32.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("image32.ImageStream")));
            this.image32.Images.SetKeyName(0, "Sale_32.png");
            this.image32.Images.SetKeyName(1, "Consignment_Add_32.png");
            this.image32.Images.SetKeyName(2, "Find_Good_32.png");
            this.image32.Images.SetKeyName(3, "Update_32.png");
            this.image32.Images.SetKeyName(4, "Buy_Add_32.png");
            this.image32.Images.SetKeyName(5, "Close_32x32.png");
            this.image32.Images.SetKeyName(6, "Save_32x32.png");
            this.image32.Images.SetKeyName(7, "SaveAs_32x32.png");
            this.image32.Images.SetKeyName(8, "Find_32x32.png");
            this.image32.Images.SetKeyName(9, "QueryDetail_32.png");
            this.image32.Images.SetKeyName(10, "Repor_Weekt_32.png");
            this.image32.Images.SetKeyName(11, "Report_Day_32.png");
            this.image32.Images.SetKeyName(12, "Report_Month_32.png");
            this.image32.Images.SetKeyName(13, "Report_Preset_32.png");
            this.image32.Images.SetKeyName(14, "Report_Spread_32.png");
            this.image32.Images.SetKeyName(15, "Reprot_Performance_32.png");
            this.image32.Images.SetKeyName(16, "SpreadTime_32.png");
            this.image32.Images.SetKeyName(17, "Export_32.png");
            this.image32.Images.SetKeyName(18, "Layout_32.png");
            this.image32.Images.SetKeyName(19, "Map_32.png");
            this.image32.Images.SetKeyName(20, "Print_32.png");
            this.image32.Images.SetKeyName(21, "Refresh_32.png");
            this.image32.Images.SetKeyName(22, "delete_32.png");
            this.image32.Images.SetKeyName(23, "20131123110736631_easyicon_net_32.png");
            this.image32.Images.SetKeyName(24, "2013112311125269_easyicon_net_32.png");
            this.image32.Images.SetKeyName(25, "20131123105308230_easyicon_net_32.png");
            this.image32.Images.SetKeyName(26, "20131123111337630_easyicon_net_32.png");
            this.image32.Images.SetKeyName(27, "20131123111600321_easyicon_net_32.png");
            this.image32.Images.SetKeyName(28, "20131123112545440_easyicon_net_32.png");
            this.image32.Images.SetKeyName(29, "Simple_Add_32.png");
            this.image32.Images.SetKeyName(30, "Simple_Add1_32.png");
            this.image32.Images.SetKeyName(31, "Simple_Edit_32.png");
            this.image32.Images.SetKeyName(32, "Simple_Remove_32.png");
            this.image32.Images.SetKeyName(33, "Shopping_32.png");
            this.image32.Images.SetKeyName(34, "Simple_Copy_32.png");
            this.image32.Images.SetKeyName(35, "Simple_Copy1_32.png");
            this.image32.Images.SetKeyName(36, "Pic_32.png");
            this.image32.Images.SetKeyName(37, "Simple_Pic_32.png");
            this.image32.Images.SetKeyName(38, "Simple_Pic1_32.png");
            this.image32.Images.SetKeyName(39, "Simple_Pic2_32.png");
            this.image32.Images.SetKeyName(40, "add_user.png");
            this.image32.Images.SetKeyName(41, "chat.png");
            this.image32.Images.SetKeyName(42, "edit_user.png");
            this.image32.Images.SetKeyName(43, "offline_user.png");
            this.image32.Images.SetKeyName(44, "remove_user.png");
            this.image32.Images.SetKeyName(45, "send.png");
            this.image32.Images.SetKeyName(46, "upload.png");
            this.image32.Images.SetKeyName(47, "user.png");
            this.image32.Images.SetKeyName(48, "user_group.png");
            this.image32.Images.SetKeyName(49, "video_chat.png");
            this.image32.Images.SetKeyName(50, "voice_chat.png");
            this.image32.Images.SetKeyName(51, "Simple_Payment_32.png");
            this.image32.Images.SetKeyName(53, "back.png");
            this.image32.Images.SetKeyName(54, "basket_back.png");
            this.image32.Images.SetKeyName(55, "left.png");
            this.image32.Images.SetKeyName(64, "ooopic_1505739023.png");
            this.image32.Images.SetKeyName(65, "Bar_code_48.892430278884px_1156986_easyicon.net.png");
            this.image32.Images.SetKeyName(66, "Bar_code_48.892430278884px_1156986_easyicon.net.png");
            // 
            // IndividualizationRibbonPage
            // 
            this.IndividualizationRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.themePageMain});
            this.IndividualizationRibbonPage.Name = "IndividualizationRibbonPage";
            resources.ApplyResources(this.IndividualizationRibbonPage, "IndividualizationRibbonPage");
            // 
            // themePageMain
            // 
            this.themePageMain.ItemLinks.Add(this.ribbonViewSkins);
            this.themePageMain.Name = "themePageMain";
            this.themePageMain.ShowCaptionButton = false;
            resources.ApplyResources(this.themePageMain, "themePageMain");
            // 
            // RibbonFormSimpleDialogBase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbon);
            this.Name = "RibbonFormSimpleDialogBase";
            this.Ribbon = this.ribbon;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image32)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage IndividualizationRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup themePageMain;
        private DevExpress.XtraBars.RibbonGalleryBarItem ribbonViewSkins;
        private DevExpress.XtraBars.BarButtonItem barBtnAbout;
        private DevExpress.Utils.ImageCollection image32;
        private DevExpress.Utils.ImageCollection image16;
    }
}