using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAoThung.Common
{
    [Serializable]
    public class Userlogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
        public string GroupID { set; get; }
        public string AccessName { set; get; }
    }
}