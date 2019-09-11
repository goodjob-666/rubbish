using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;
using System.Collections;


namespace FrameWork.web.Manager.Module.DLT.Service.tbActivity
{
    public partial class BatchAddOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ClosePop()
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.parent.hidePopWin(true);</script>");
        }

        protected void BtClose_Click(object sender, EventArgs e)
        {
            ClosePop();
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtOrderList.Text != "")
            {
                string strNoValidate = "";
                string strValidate = "";
                try
                {
                    string[] strAllOrderList = txtOrderList.Text.Split("\n".ToCharArray());

                    for (int x = 0; x < strAllOrderList.Length; x++)
                    {
                        strAllOrderList[x] = strAllOrderList[x].Replace("\r","");
                    }

                    ArrayList al = new ArrayList();

                    ArrayList a2 = new ArrayList();

                    for (int i = 0; i < strAllOrderList.Length; i++)
                    {
                        //判断数组值是否已经存在 
                        if (al.Contains(strAllOrderList[i]) == false)
                        {
                            if (a2.Contains(strAllOrderList[i]) == false)
                            {
                                al.Add(strAllOrderList[i]);
                            }
                        }
                        else
                        {
                            if (a2.Contains(strAllOrderList[i]) == false)
                            {
                                al.Remove(strAllOrderList[i]);
                                a2.Add(strAllOrderList[i]);
                            }
                        }
                    }

                    string[] strOrderList = new string[al.Count]; 
                    strOrderList = (string[])al.ToArray(typeof(string));

                    for (int j = 0; j < a2.Count; j++)
                    {
                        strNoValidate += a2[j].ToString().Trim() + "(有重复订单)<br/>";
                    }


                    if (Request.QueryString[""] == null || Request.QueryString["ID"].ToString() == "")
                    {
                        for (int i = 0; i < strOrderList.Length; i++)
                        {

                            if (strOrderList[i].ToString().Trim() == "")
                            {
                                continue;
                            }
                            else
                            {

                                DataSet ds1 = BusinessFacadeDLT.IsActivityBlack(strOrderList[i].ToString().Trim());

                                if (ds1.Tables[0].Rows[0][0].ToString() == "1")
                                {

                                    DataSet ds = BusinessFacadeDLT.CheckActivityOrder(Request.QueryString["ID"].ToString(), strOrderList[i].ToString().Trim());

                                    string result = ds.Tables[0].Rows[0][0].ToString();
                                    if (result == "-1")
                                    {
                                        strNoValidate += strOrderList[i].ToString().Trim() + "(订单已添加!)<br/>";
                                        continue;
                                    }
                                    else if (result == "1")
                                    {
                                        strValidate += strOrderList[i].ToString().Trim() + "\n";
                                    }
                                    else if (result == "-2")
                                    {
                                        strNoValidate += strOrderList[i].ToString().Trim() + "(游戏不匹配)<br/>";
                                        continue;
                                    }
                                    else if (result == "-3")
                                    {
                                        strNoValidate += strOrderList[i].ToString().Trim() + "(已在已删除)<br/>";
                                        continue;
                                    }
                                    else if (result == "-4")
                                    {
                                        strNoValidate += strOrderList[i].ToString().Trim() + "(在其它活动)<br/>";
                                        continue;
                                    }
                                    else
                                    {
                                        strNoValidate += strOrderList[i].ToString().Trim() + "(订单号错误)<br/>";
                                        continue;

                                    }
                                }
                                else
                                {
                                    strNoValidate += strOrderList[i].ToString().Trim() + "(存在黑名单)<br/>";
                                    continue;
                                }
                            }

                        }
                        btnAdd.Enabled = true;
                        txtOrderList.Text = strValidate;
                        lblNoValidate.Text = strNoValidate;
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('请先选择一个具体活动！');</script>");
                        return;
                    }



                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('订单录入格式有误，请保证一行一个订单号，不要有任何其它杂乱字符！');</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请输入需要批量加入的订单列表！');</script>");
                return;
            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtOrderList.Text != "")
            {
                string errStr = "";

                try
                {
                    string[] strOrderList = txtOrderList.Text.Split("\n".ToCharArray());

                    if (Request.QueryString[""] == null || Request.QueryString["ID"].ToString() == "")
                    {
                        for (int i = 0; i < strOrderList.Length; i++)
                        {

                            if (strOrderList[i].ToString().Trim() == "")
                            {
                                continue;
                            }
                            else
                            {

                                DataSet ds1 = BusinessFacadeDLT.IsActivityBlack(strOrderList[i].ToString().Trim());

                                if (ds1.Tables[0].Rows[0][0].ToString() == "1")
                                {

                                    DataSet ds = BusinessFacadeDLT.AddActivityOrder(Request.QueryString["ID"].ToString(), strOrderList[i].ToString().Trim());

                                    string result = ds.Tables[0].Rows[0][0].ToString();
                                    if (result == "-1")
                                    {
                                        errStr += strOrderList[i].ToString().Trim() + ",";
                                    }
                                    else if (result == "1")
                                    {
                                        errStr += "";
                                    }
                                    else if (result == "-2")
                                    {
                                        errStr += strOrderList[i].ToString().Trim() + ",";
                                    }
                                    else if (result == "-3")
                                    {
                                        errStr += strOrderList[i].ToString().Trim() + ",";
                                    }
                                    else if (result == "-4")
                                    {
                                        errStr += strOrderList[i].ToString().Trim() + ",";
                                    }
                                    else
                                    {
                                        errStr += strOrderList[i].ToString().Trim() + ",";
                                    }
                                }
                                else
                                {
                                    errStr += strOrderList[i].ToString().Trim() + ",";
                                }
                            }

                        }
                        txtOrderList.Text = "";

                        if (errStr != "")
                        {
                            Response.Write("<script language='javascript'>alert('批量添加订单添加成功，但以下订单添加失败，请手动处理！失败订单："+errStr+"');</script>");
                            return;
                        }
                        else 
                        {
                            Response.Write("<script language='javascript'>alert('批量添加订单添加成功！');</script>");
                            return;
                        }
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('请先选择一个具体活动！');</script>");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('订单录入格式有误，请保证一行一个订单号，不要有任何其它杂乱字符！');</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请输入需要批量加入的订单列表！');</script>");
                return;
            }
        }
    }
}
