/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            用户管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2014/8/5 13:39:35
     History:
*********************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Runtime.InteropServices;

using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;
using FrameWork.WebControls;

namespace DLT.Web.Module.DLT.tsUser
{
    public partial class SetUserInfo : System.Web.UI.Page
    {
        [PopedomTypeAttaible(PopedomType.A)]
        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "OR")]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["ID"] != null)
                {
                    OnStart();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            tsUserEntity ut = BusinessFacadeDLT.tsUserDisp(int.Parse(Request["ID"].ToString()));
            OnStartData(ut);
        }


        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(tsUserEntity ut)
        {
            //tsUser_Pass_Input.Text =  ut.Pass.ToString();
            tsUser_Question_Input.Text = hdQuestion.Value = ut.Question.ToString();
            tsUser_Answer_Input.Text = hdAnswer.Value = ut.Answer.ToString();
            tsUser_BindMobile_Input.Text = hdBindMobile.Value = ut.BindMobile.ToString();
            tsUser_UID_Input.Text =  ut.UID.ToString();
            tsUser_LoginID_Input.Text =  ut.LoginID.ToString();



            DisplayInfo();

       }


        private void DisplayInfo()
        {
            //获取当前备注

            DataSet ds = BusinessFacadeDLT.GetUserTrackInfoComment(Request["ID"].ToString(), 1, 1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCurComment.Text = BusinessFacadeDLT.GetUserTrackInfoComment(Request["ID"].ToString(), 1, 1).Tables[0].Rows[0]["TrackInfo"].ToString();
            }
            else
            {
                txtCurComment.Text = "";
            }


            //获取当前证明材料

            DataSet ds1 = BusinessFacadeDLT.GetUserAccountProved(Request["ID"].ToString());

            DataTable dt = ds1.Tables[0];
            DataTable dt1 = ds1.Tables[1];

            if (dt.Rows.Count > 0)
            {
                aEdit.Attributes.CssStyle["display"] = "none";
                divdivAccountProvedEdit.Attributes.CssStyle["display"] = "";
                txtAccountProved.Text = dt.Rows[0]["Evidence"].ToString();
            }
            else
            {
                aEdit.Attributes.CssStyle["display"] = "";
                divdivAccountProvedEdit.Attributes.CssStyle["display"] = "none";
            }

            if (dt1.Rows.Count > 0)
            {
                string str = "";
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    str += "<div style='border:1px solid #000; margin:10px 0;padding:20px;'>";
                    str += "<div>【处理时间：" + dt1.Rows[i]["DealDate"].ToString() + "】</div>";
                    str += "<div>" + dt1.Rows[i]["Evidence"].ToString() + "</div></div>";
                }
                divAccountProvedContent.InnerHtml = str;
                aHisDeal.Attributes.CssStyle["display"] = "";
            }
        }

        public void UpdateTrackInfoComment()
        {
            BusinessFacadeDLT.AddUserTrackInfoComment(Request["ID"].ToString(), txtCurComment.Text, 0, Common.Get_UserID);
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string tsUser_BindMobile_Value = (string)Common.sink(tsUser_BindMobile_Input.UniqueID, MethodType.Post, 128, 0, DataType.Str);
            tsUserEntity ut = BusinessFacadeDLT.tsUserDisp(int.Parse(Request["ID"].ToString()));
            ut.BindMobile = tsUser_BindMobile_Value;
            if (tsUser_BindMobile_Value == "")
            {
                if (ut.LoginMode == 12)
                {
                    ut.LoginMode = 10;
                }
            }
            ut.DataTable_Action_ = DataTable_Action.Update;
            Int32 rInt = BusinessFacadeDLT.tsUserInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                BusinessFacadeDLT.UserLog(int.Parse(Request["ID"].ToString()), 22, "后台置空手机号码，原手机号码：" + hdBindMobile.Value, "");
                string titleMessage = "手密修改-置空手机-" + tsUser_UID_Input.Text;
                EventMessage.EventWriteDB(1, titleMessage);
                Response.Write("<script language='javascript'>alert('手机号码修改成功！');</script>");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            tsUserEntity ut = BusinessFacadeDLT.tsUserDisp(int.Parse(Request["ID"].ToString()));
            string tsUser_Question_Value = (string)Common.sink(tsUser_Question_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            string tsUser_Answer_Value = (string)Common.sink(tsUser_Answer_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);

            ut.Question = tsUser_Question_Value;
            ut.Answer = tsUser_Answer_Value;
            ut.DataTable_Action_ = DataTable_Action.Update;
            Int32 rInt = BusinessFacadeDLT.tsUserInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                BusinessFacadeDLT.UserLog(int.Parse(Request["ID"].ToString()), 14, "修改密码保护.老密码保护（问题：" + hdQuestion.Value + " 答案：" + hdAnswer.Value + "）", "");
                string titleMessage = "手密修改-修改密保-" + tsUser_UID_Input.Text;
                EventMessage.EventWriteDB(1, titleMessage);
                Response.Write("<script language='javascript'>alert('密码保护修改成功！');</script>");
            }
        
        }


        [DllImport(@"d:/website/manager_V2/bin/DelphiMD5.dll", EntryPoint = "DMD5Str")]
        //[DllImport(@"c:/Windows/System32/DelphiMD5.dll", EntryPoint = "DMD5Str")]
        //[DllImport(@"d:/DelphiMD5.dll", EntryPoint = "DMD5Str")]
        private static extern IntPtr DMD5Str(string M, string K);

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (tsUser_Pass_Input.Text == "")
            {
                Response.Write("<script language='javascript'>alert('用户密码不能为空！');</script>");
                return;
            }
            tsUserEntity ut = BusinessFacadeDLT.tsUserDisp(int.Parse(Request["ID"].ToString()));
            string tsUser_Pass_Value = (string)Common.sink(tsUser_Pass_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            //ut.Pass = MD5(tsUser_Pass_Value);
            ut.Pass = Marshal.PtrToStringAnsi(DMD5Str(tsUser_Pass_Value, tsUser_LoginID_Input.Text));
            ut.DataTable_Action_ = DataTable_Action.Update;
            Int32 rInt = BusinessFacadeDLT.tsUserInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                BusinessFacadeDLT.UserLog(int.Parse(Request["ID"].ToString()), 13, "后台修改密码", "");
                string titleMessage = "手密修改-登录密码-" + tsUser_UID_Input.Text;
                EventMessage.EventWriteDB(1, titleMessage);
                Response.Write("<script language='javascript'>alert('密码修改成功！');</script>");
            }
        }

        protected string MD5(string password)
        {
            string md5pass = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5").ToLower();
            md5pass += tsUser_LoginID_Input.Text;
            return FormsAuthentication.HashPasswordForStoringInConfigFile(md5pass, "MD5").ToLower();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateTrackInfoComment();
            Response.Write("<script language='javascript'>alert('备注保存成功！');</script>");
        }

        protected void btnAccountProved_Click(object sender, EventArgs e)
        {
            int isDeal = 0;
            if (cbDeal.Checked)
            {
                isDeal = 1;
            }

            BusinessFacadeDLT.AddUserAccountProved(Request["ID"].ToString(), txtAccountProved.Text, isDeal ,Common.Get_UserID);
            string titleMessage = "手密修改-证明资料-" + tsUser_UID_Input.Text;
            EventMessage.EventWriteDB(1, titleMessage);

            DisplayInfo();

            if (isDeal == 1)
            {
                txtAccountProved.Text = "";
                cbDeal.Checked = false;
            }



            Response.Write("<script language='javascript'>alert('账户材料及备注保存成功！');</script>");

        }
    }
}
