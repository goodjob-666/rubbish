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
using FrameWork.Components;

namespace FrameWork.web.Module.FrameWork.SystemState
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                OnlineUser.Text = FrameWorkOnline.Instance().GetOnlineUserNum.ToString();
                CacheNum.Text = FrameWorkCache.Instance().Count.ToString();
                CacheMax.Text = FrameWorkCache.Instance().Remains;
                SystemOsName.Text = Common.GetServerOS;
                SystemRunTime.Text = GetSystemRunTime;
                AppRunTime.Text = GetAppRunTime;
                OnlineUseType.Text = Common.GetOnlineCountType.ToString();

                CacheUseClass.Text = Common.GetCacheclassName;
                OnlineTimeOutMinute.Text = Common.OnlineMinute.ToString();
                sys_FrameWorkInfoTable si = FrameSystemInfo.GetSystemInfoTable.S_FrameWorkInfo;
                SystemName.Text = FrameSystemInfo.FrameWorkVerName;
                SystemName.Text = SystemName.Text + CheckUpdate.GetNewVerInfo;
                if (si.S_Licensed == string.Empty)
                {
                    Licensed_RegionUrl.NavigateUrl = si.S_RegsionUrl;
                    LinkButton1.Visible = false;
                }
                else
                {
                    Licensed_Txt.Text = string.Format("<a href='{1}?S_Licensed={0}' target=_blank>{0}</a>", si.S_Licensed, si.S_CheckLicensed);
                    NoRegsion.Visible = false;
                    if (!CheckUpdate.CheckLicensed)
                        Licensed_Txt.Text = Licensed_Txt.Text + "<font color=red>无效序列号</font>";
                }



                System.Diagnostics.Process ps = System.Diagnostics.Process.GetCurrentProcess();

                AppRunMemony.Text = string.Format("{0}M", ps.WorkingSet64 / 1024 / 1024);
                AppRunVirtualMemony.Text = string.Format("{0}M", ps.VirtualMemorySize64 / 1024 / 1024);
                    
            }
            if (!FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                TabOptionItem2.Visible = false;
        }

        private string GetAppRunTime
        {
            get
            {
                TimeSpan span = DateTime.Now - FrameWorkPermission.AppStartTime;
                string result = span.Days.ToString() + "天 ";
                result += span.Hours.ToString() + "小时 ";
                result += span.Minutes.ToString() + "分 ";
                result += span.Seconds.ToString() + "秒";
                return result;
            }
        }

        private string GetSystemRunTime
        {
            get
            {
                int t = Environment.TickCount;
                if (t < 0) t = t + int.MaxValue;
                t = t / 1000;
                TimeSpan span = TimeSpan.FromSeconds(t);
                string result = span.Days.ToString() + "天 ";
                result += span.Hours.ToString() + "小时 ";
                result += span.Minutes.ToString() + "分 ";
                result += span.Seconds.ToString() + "秒";
                return result;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPermissionVoid(PopedomType.Delete);
            FrameSystemInfo.GetSystemInfoTable.S_Licensed = "";
            FrameSystemInfo.GetSystemInfoTable.DB_Option_Action_ = "Update";
            BusinessFacade.sys_SystemInfoInsertUpdate(FrameSystemInfo.GetSystemInfoTable);
            CheckUpdate.CheckLicensed = true;
            EventMessage.MessageBox(1, "系统注册!", "移除输入序列号成功!", Icon_Type.OK, Common.GetScriptUrl);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPermissionVoid(PopedomType.Edit);
            string Licensed_Value_value = (string)Common.sink(Licensed_Value.UniqueID, MethodType.Post, 29, 29, DataType.Str);
            FrameSystemInfo.GetSystemInfoTable.S_Licensed = Licensed_Value_value;
            FrameSystemInfo.GetSystemInfoTable.DB_Option_Action_ = "Update";
            BusinessFacade.sys_SystemInfoInsertUpdate(FrameSystemInfo.GetSystemInfoTable);
            EventMessage.MessageBox(1, "系统注册!", "输入序列号成功!", Icon_Type.OK, Common.GetScriptUrl);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPermissionVoid(PopedomType.A);
            FrameWorkLogin.UserOut();
            Response.Clear();
            Response.Write("Web应用程序已经重启, 请点击此处<a href=\""+Page.ResolveClientUrl("~/")+"Manager/Default.aspx\">重新登入</a>.");
            Response.Flush();
            Response.Close();
            EventMessage.EventWriteDB(1, "重启Web应用程序成功!");
            HttpRuntime.UnloadAppDomain();            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPermissionVoid(PopedomType.A);

            IDictionaryEnumerator id = HttpRuntime.Cache.GetEnumerator();
            while (id.MoveNext())
            {
                DictionaryEntry abc = id.Entry;
                string Tempstring = (string)id.Key;
                HttpRuntime.Cache.Remove(Tempstring);
            }
            EventMessage.MessageBox(1, "清空缓存!", "成功清空所有web缓存.", Icon_Type.OK, Common.GetScriptUrl);
        }
    }
}
