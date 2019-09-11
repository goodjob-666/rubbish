using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FrameWork;
using FrameWork.Components;

namespace FrameWork.web.Manager.Module.FrameWork.SystemApp.AppManager
{
    public partial class Orderby : System.Web.UI.Page
    {
        public string OrderByListItems_UniqueID;
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderByListItems_UniqueID = OrderByListItems.UniqueID.Replace("$", "_");
            Button2.OnClientClick = string.Format("selectAll({0})", OrderByListItems_UniqueID);
            if (!Page.IsPostBack)
            {
                OnStart();
            }
        }

        private void OnStart()
        {
            int RecordCount = 0;
            QueryParam qp = new QueryParam();
            qp.Orderfld = "A_Order";
            qp.OrderType = 0;
            ArrayList lst = BusinessFacade.sys_ApplicationsList(qp, out RecordCount);
            OrderByListItems.DataSource = lst;
            OrderByListItems.DataTextField = "A_AppName";
            OrderByListItems.DataValueField = "ApplicationID";
            OrderByListItems.DataBind();
            if (lst.Count > 0)
                OrderByListItems.Rows = lst.Count;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPermissionVoid(PopedomType.Orderby);
            string ItemsList = (string)Common.sink(OrderByListItems.UniqueID, MethodType.Post, 100000, 1, DataType.Str);
            if (ItemsList.Length > 0)
            {
                string[] ItemsLists = ItemsList.Split(',');
                for (int i = 0; i < ItemsLists.Length; i++)
                {

                    BusinessFacade.Update_Table_Fileds("sys_Applications", string.Format("A_Order={0}", i + 1), string.Format("ApplicationID={0}", ItemsLists[i]));
                }
            }

            //重启加载树型菜单缓存
            sys_Module_Cache.ReLoadCache();

            EventMessage.MessageBox(1, "操作成功", string.Format("排序应用成功!"), Icon_Type.OK, Common.GetHomeBaseUrl("List.aspx"), Common.BuildJs);

        }
    }
}
