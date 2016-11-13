using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learn.Web.Helper
{
    public class EnumHelper
    {
        public static  class RequestType 
        {
            public static int GET = 1;
            public static int POST = 2;
            public static int BOTH = 3;
            /// <summary>
            /// 下拉框数据
            /// </summary>
            public static List<SelectListItem> DDLData
            {
                get
                {
                    return new List<SelectListItem>()
                {
                    new SelectListItem() { Value = "1",Text = "GET"},
                    new SelectListItem() { Value = "2",Text = "POST"},
                    new SelectListItem() { Value = "3", Text = "BOTH"}
                };
                }
            }
        }

        public static class OperationType
        {
            public static int MENU = 1;
            public static int BUTTON = 2;
            public static int AJAX = 3;

            /// <summary>
            /// 权限的类型
            /// </summary>
            public static List<SelectListItem> DDLData
            {
                get
                {
                    return new List<SelectListItem>()
                {
                    new SelectListItem() { Value = "1",Text = "MENU"},
                    new SelectListItem() { Value = "2",Text = "BUTTON"},
                    new SelectListItem() { Value = "3",Text = "AJAX"},
                };
                }
            }
        }

    }
}