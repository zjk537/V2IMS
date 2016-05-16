using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vogue2_IMS.Business.BusinessModel
{
   public class GoodsPaidInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
