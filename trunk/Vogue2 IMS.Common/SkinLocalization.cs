using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vogue2_IMS.Common
{
    class SkinLocalization
    {
        private static Dictionary<string, string> skinLocalizationCHS = null;

        public static Dictionary<string, string> SkinLocalizationCHS
        {
            get
            {
                if (skinLocalizationCHS == null)
                {
                    skinLocalizationCHS = new Dictionary<string, string>();

                    skinLocalizationCHS.Add("Black", "时尚黑");
                    skinLocalizationCHS.Add("Blue", "时尚蓝");
                    skinLocalizationCHS.Add("Caramel", "时尚褐");
                    skinLocalizationCHS.Add("DevExpress Dark Style", "时尚灰");
                    skinLocalizationCHS.Add("DevExpress Style", "经典");
                    skinLocalizationCHS.Add("iMaginary", "平淡蓝1");
                    skinLocalizationCHS.Add("Lilian", "平淡蓝2");
                    skinLocalizationCHS.Add("Money Twins", "经典格式");
                    skinLocalizationCHS.Add("Office 2007 Black", "Office 2007 黑色");
                    skinLocalizationCHS.Add("Office 2007 Blue", "Office 2007 蓝色");
                    skinLocalizationCHS.Add("Office 2007 Green", "Office 2007 绿色");
                    skinLocalizationCHS.Add("Office 2007 Pink", "Office 2007 粉色");
                    skinLocalizationCHS.Add("Office 2007 Silver", "Office 2007 银色");
                    skinLocalizationCHS.Add("Office 2010 Black", "Office 2010 黑色");
                    skinLocalizationCHS.Add("Office 2010 Blue", "Office 2010 蓝色");
                    skinLocalizationCHS.Add("Office 2010 Silver", "Office 2010 银色");
                    skinLocalizationCHS.Add("Blueprint", "格式蓝图");
                    skinLocalizationCHS.Add("Coffee", "咖啡色");
                    skinLocalizationCHS.Add("Dark Side", "黑色外型");
                    skinLocalizationCHS.Add("Darkroom", "黑色装饰");
                    skinLocalizationCHS.Add("Foggy", "平淡灰");
                    skinLocalizationCHS.Add("Glass Oceans", "玻璃海");
                    skinLocalizationCHS.Add("High Contrast", "经典高亮");
                    skinLocalizationCHS.Add("Liquid Sky", "蓝色天空");
                    skinLocalizationCHS.Add("London Liquid Sky", "伦敦之夜");
                    skinLocalizationCHS.Add("McSkin", "经典蓝");
                    skinLocalizationCHS.Add("Pumpkin", "万圣节");
                    skinLocalizationCHS.Add("Seven", "平淡1");
                    skinLocalizationCHS.Add("Seven Classic", "平淡2");
                    skinLocalizationCHS.Add("Sharp", "锐利");
                    skinLocalizationCHS.Add("Sharp Plus", "深层锐利");
                    skinLocalizationCHS.Add("Springtime", "春天时光");
                    skinLocalizationCHS.Add("Stardust", "星尘");
                    skinLocalizationCHS.Add("Summer 2008", "夏日时光");
                    skinLocalizationCHS.Add("The Asphalt World", "沥青");
                    skinLocalizationCHS.Add("Valentine", "七月七");
                    skinLocalizationCHS.Add("VS2010", "VS经典");
                    skinLocalizationCHS.Add("Whiteprint", "白色条纹");
                    skinLocalizationCHS.Add("Xmas 2008 Blue", "蓝色圣诞");
                }

                return skinLocalizationCHS;
            }
        }

    }
}
