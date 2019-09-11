/********************************************************************************
     File:																
            SqlDataProvider.cs                         
     Description:
            Sql数据库操作类
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
			2014/8/5 13:39:35
     History:
*********************************************************************************/
using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Common;
using FrameWork.Components;
using DLT.Components;

namespace DLT.Data
{
    /// <summary>
    /// Sql数据库操作类
    /// </summary>
    public partial class SqlDataProvider : DataProvider
    {   
        #region MyRegion
		    
        #region "SqlDataProvider"
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string ConnString = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SqlDataProvider()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            ConnString = ConfigurationManager.AppSettings["MSSql"];
        }

        /// <summary>
        /// 连接数据库字符串
        /// </summary>
        /// <param name="strConn"></param>
        public SqlDataProvider(string strConn)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            ConnString = strConn;
        }

        /// <summary>
        /// 获取数据连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetSqlConnection()
        {
            try
            {
                return new SqlConnection(ConnString);
            }
            catch
            {
                throw new Exception("没有提供数据庫连接字符串！");
            }
        }

        /// <summary>
        /// 获得当前数据库连接
        /// </summary>
        /// <returns></returns>
        public override DbConnection GetDdConnection()
        {
            return GetSqlConnection();
        }

        #endregion

        #region "tbAppointArbitration (tbAppointArbitration) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tbAppointArbitration (tbAppointArbitration)
        /// </summary>
        /// <param name="fam">tbAppointArbitrationEntity实体类(tbAppointArbitration)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbAppointArbitrationInsertUpdateDelete(tbAppointArbitrationEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbAppointArbitration_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fam.CustomerID;  //CustomerID
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = fam.UserID;  //UserID
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment
                cmd.Parameters.Add("@OpCustomerID", SqlDbType.Int).Value = fam.OpCustomerID;  //OpCustomerID
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbAppointArbitration (tbAppointArbitration)
        /// </summary>
        /// <param name="fam">tbAppointArbitrationEntity实体类(tbAppointArbitration)</param>
        /// <param name="tran">tbAppointArbitration事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbAppointArbitrationInsertUpdateDelete(tbAppointArbitrationEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbAppointArbitration_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fam.CustomerID;  //CustomerID
            cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = fam.UserID;  //UserID
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment
            cmd.Parameters.Add("@OpCustomerID", SqlDbType.Int).Value = fam.OpCustomerID;  //OpCustomerID

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回tbAppointArbitrationEntity实体类的List对象 (tbAppointArbitration)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbAppointArbitrationEntity实体类的List对象(tbAppointArbitration)</returns>
        public override List<tbAppointArbitrationEntity> tbAppointArbitrationList(QueryParam qp, out int RecordCount)
        {
            return tbAppointArbitrationList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tbAppointArbitrationEntity实体类的List对象 (tbAppointArbitration)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbAppointArbitration事务</param>
        /// <returns>tbAppointArbitrationEntity实体类的List对象(tbAppointArbitration)</returns>
        public override List<tbAppointArbitrationEntity> tbAppointArbitrationList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbAppointArbitrationEntity> mypd = new PopulateDelegate<tbAppointArbitrationEntity>(base.PopulatetbAppointArbitrationEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbActivityBlack (tbActivityBlack) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tbActivityBlack (tbActivityBlack)
        /// </summary>
        /// <param name="fam">tbActivityBlackEntity实体类(tbActivityBlack)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbActivityBlackInsertUpdateDelete(tbActivityBlackEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbActivityBlack_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //UserID
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fam.CustomerID;  //CustomerID
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbActivityBlack (tbActivityBlack)
        /// </summary>
        /// <param name="fam">tbActivityBlackEntity实体类(tbActivityBlack)</param>
        /// <param name="tran">tbActivityBlack事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbActivityBlackInsertUpdateDelete(tbActivityBlackEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbActivityBlack_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //UserID
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fam.CustomerID;  //CustomerID

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回tbActivityBlackEntity实体类的List对象 (tbActivityBlack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbActivityBlackEntity实体类的List对象(tbActivityBlack)</returns>
        public override List<tbActivityBlackEntity> tbActivityBlackList(QueryParam qp, out int RecordCount)
        {
            return tbActivityBlackList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tbActivityBlackEntity实体类的List对象 (tbActivityBlack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbActivityBlack事务</param>
        /// <returns>tbActivityBlackEntity实体类的List对象(tbActivityBlack)</returns>
        public override List<tbActivityBlackEntity> tbActivityBlackList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbActivityBlackEntity> mypd = new PopulateDelegate<tbActivityBlackEntity>(base.PopulatetbActivityBlackEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbActivity (tbActivity) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tbActivity (tbActivity)
        /// </summary>
        /// <param name="fam">tbActivityEntity实体类(tbActivity)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbActivityInsertUpdateDelete(tbActivityEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbActivity_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = fam.Title;  //Title
                cmd.Parameters.Add("@UserType", SqlDbType.Int).Value = fam.UserType;  //UserType
                cmd.Parameters.Add("@GameID", SqlDbType.VarChar).Value = fam.GameID;  //GameID
                if (fam.StartDate.HasValue)
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = fam.StartDate;  //StartDate
                else
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DBNull.Value;  //StartDate
                if (fam.EndDate.HasValue)
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = fam.EndDate;  //EndDate
                else
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;  //EndDate
                cmd.Parameters.Add("@Channel", SqlDbType.Int).Value = fam.Channel;  //Channel
                cmd.Parameters.Add("@Price", SqlDbType.Money).Value = fam.Price;  //Price
                cmd.Parameters.Add("@Pirce2", SqlDbType.Money).Value = fam.Pirce2;  //Pirce2
                cmd.Parameters.Add("@Price3", SqlDbType.Money).Value = fam.Price3;  //Price3
                if (fam.SendDate.HasValue)
                    cmd.Parameters.Add("@SendDate", SqlDbType.DateTime).Value = fam.SendDate;  //SendDate
                else
                    cmd.Parameters.Add("@SendDate", SqlDbType.DateTime).Value = DBNull.Value;  //SendDate
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = fam.Status;  //Status
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbActivity (tbActivity)
        /// </summary>
        /// <param name="fam">tbActivityEntity实体类(tbActivity)</param>
        /// <param name="tran">tbActivity事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbActivityInsertUpdateDelete(tbActivityEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbActivity_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = fam.Title;  //Title
            cmd.Parameters.Add("@UserType", SqlDbType.Int).Value = fam.UserType;  //UserType
            cmd.Parameters.Add("@GameID", SqlDbType.VarChar).Value = fam.GameID;  //GameID
            if (fam.StartDate.HasValue)
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = fam.StartDate;  //StartDate
            else
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DBNull.Value;  //StartDate
            if (fam.EndDate.HasValue)
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = fam.EndDate;  //EndDate
            else
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;  //EndDate
            cmd.Parameters.Add("@Channel", SqlDbType.Int).Value = fam.Channel;  //Channel
            cmd.Parameters.Add("@Price", SqlDbType.Money).Value = fam.Price;  //Price
            cmd.Parameters.Add("@Pirce2", SqlDbType.Money).Value = fam.Pirce2;  //Pirce2
            if (fam.SendDate.HasValue)
                cmd.Parameters.Add("@SendDate", SqlDbType.DateTime).Value = fam.SendDate;  //SendDate
            else
                cmd.Parameters.Add("@SendDate", SqlDbType.DateTime).Value = DBNull.Value;  //SendDate
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = fam.Status;  //Status
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回tbActivityEntity实体类的List对象 (tbActivity)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbActivityEntity实体类的List对象(tbActivity)</returns>
        public override List<tbActivityEntity> tbActivityList(QueryParam qp, out int RecordCount)
        {
            return tbActivityList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tbActivityEntity实体类的List对象 (tbActivity)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbActivity事务</param>
        /// <returns>tbActivityEntity实体类的List对象(tbActivity)</returns>
        public override List<tbActivityEntity> tbActivityList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbActivityEntity> mypd = new PopulateDelegate<tbActivityEntity>(base.PopulatetbActivityEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "sys_StatisticalGrouping (sys_StatisticalGrouping) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 sys_StatisticalGrouping (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="fam">sys_StatisticalGroupingEntity实体类(sys_StatisticalGrouping)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 sys_StatisticalGroupingInsertUpdateDelete(sys_StatisticalGroupingEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.sys_StatisticalGrouping_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@S_ID", SqlDbType.Int).Value = fam.S_ID;  //S_ID
                cmd.Parameters.Add("@S_Name", SqlDbType.VarChar).Value = fam.S_Name;  //S_Name
                cmd.Parameters.Add("@S_Remark", SqlDbType.VarChar).Value = fam.S_Remark;  //S_Remark
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 sys_StatisticalGrouping (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="fam">sys_StatisticalGroupingEntity实体类(sys_StatisticalGrouping)</param>
        /// <param name="tran">sys_StatisticalGrouping事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 sys_StatisticalGroupingInsertUpdateDelete(sys_StatisticalGroupingEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.sys_StatisticalGrouping_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@S_ID", SqlDbType.Int).Value = fam.S_ID;  //S_ID
            cmd.Parameters.Add("@S_Name", SqlDbType.VarChar).Value = fam.S_Name;  //S_Name
            cmd.Parameters.Add("@S_Remark", SqlDbType.VarChar).Value = fam.S_Remark;  //S_Remark

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回sys_StatisticalGroupingEntity实体类的List对象 (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_StatisticalGroupingEntity实体类的List对象(sys_StatisticalGrouping)</returns>
        public override List<sys_StatisticalGroupingEntity> sys_StatisticalGroupingList(QueryParam qp, out int RecordCount)
        {
            return sys_StatisticalGroupingList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回sys_StatisticalGroupingEntity实体类的List对象 (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">sys_StatisticalGrouping事务</param>
        /// <returns>sys_StatisticalGroupingEntity实体类的List对象(sys_StatisticalGrouping)</returns>
        public override List<sys_StatisticalGroupingEntity> sys_StatisticalGroupingList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<sys_StatisticalGroupingEntity> mypd = new PopulateDelegate<sys_StatisticalGroupingEntity>(base.Populatesys_StatisticalGroupingEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tsNotice (系统公告) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tsNotice (系统公告)
        /// </summary>
        /// <param name="fam">tsNoticeEntity实体类(系统公告)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsNoticeInsertUpdateDelete(tsNoticeEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsNotice_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = fam.Title;  //标题
                cmd.Parameters.Add("@Body", SqlDbType.VarChar).Value = fam.Body;  //正文
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = fam.Url;  //链接
                cmd.Parameters.Add("@PubDate", SqlDbType.DateTime).Value = fam.PubDate;  //发布日期
                if (fam.StartDate.HasValue)
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = fam.StartDate;  //开始日期
                else
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DBNull.Value;  //开始日期
                if (fam.EndDate.HasValue)
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = fam.EndDate;  //结束日期
                else
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;  //结束日期
                cmd.Parameters.Add("@Enable", SqlDbType.Bit).Value = fam.Enable;  //是否启用
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsNotice (系统公告)
        /// </summary>
        /// <param name="fam">tsNoticeEntity实体类(系统公告)</param>
        /// <param name="tran">tsNotice事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsNoticeInsertUpdateDelete(tsNoticeEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsNotice_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = fam.Title;  //标题
            cmd.Parameters.Add("@Body", SqlDbType.VarChar).Value = fam.Body;  //正文
            cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = fam.Url;  //链接
            cmd.Parameters.Add("@PubDate", SqlDbType.DateTime).Value = fam.PubDate;  //发布日期
            if (fam.StartDate.HasValue)
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = fam.StartDate;  //开始日期
            else
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DBNull.Value;  //开始日期
            if (fam.EndDate.HasValue)
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = fam.EndDate;  //结束日期
            else
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;  //结束日期
            cmd.Parameters.Add("@Enable", SqlDbType.Bit).Value = fam.Enable;  //是否启用

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回tsNoticeEntity实体类的List对象 (系统公告)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsNoticeEntity实体类的List对象(系统公告)</returns>
        public override List<tsNoticeEntity> tsNoticeList(QueryParam qp, out int RecordCount)
        {
            return tsNoticeList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tsNoticeEntity实体类的List对象 (系统公告)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsNotice事务</param>
        /// <returns>tsNoticeEntity实体类的List对象(系统公告)</returns>
        public override List<tsNoticeEntity> tsNoticeList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tsNoticeEntity> mypd = new PopulateDelegate<tsNoticeEntity>(base.PopulatetsNoticeEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tsBankBlack (tsBankBlack) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tsBankBlack (tsBankBlack)
        /// </summary>
        /// <param name="fam">tsBankBlackEntity实体类(tsBankBlack)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsBankBlackInsertUpdateDelete(tsBankBlackEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsBankBlack_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@BankID", SqlDbType.SmallInt).Value = fam.BankID;  //BankID
                cmd.Parameters.Add("@BankUser", SqlDbType.VarChar).Value = fam.BankUser;  //BankUser
                cmd.Parameters.Add("@BankAcc", SqlDbType.VarChar).Value = fam.BankAcc;  //BankAcc
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fam.CustomerID;  //CustomerID
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsBankBlack (tsBankBlack)
        /// </summary>
        /// <param name="fam">tsBankBlackEntity实体类(tsBankBlack)</param>
        /// <param name="tran">tsBankBlack事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsBankBlackInsertUpdateDelete(tsBankBlackEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsBankBlack_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@BankID", SqlDbType.SmallInt).Value = fam.BankID;  //BankID
            cmd.Parameters.Add("@BankUser", SqlDbType.VarChar).Value = fam.BankUser;  //BankUser
            cmd.Parameters.Add("@BankAcc", SqlDbType.VarChar).Value = fam.BankAcc;  //BankAcc
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fam.CustomerID;  //CustomerID
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回tsBankBlackEntity实体类的List对象 (tsBankBlack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsBankBlackEntity实体类的List对象(tsBankBlack)</returns>
        public override List<tsBankBlackEntity> tsBankBlackList(QueryParam qp, out int RecordCount)
        {
            return tsBankBlackList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tsBankBlackEntity实体类的List对象 (tsBankBlack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsBankBlack事务</param>
        /// <returns>tsBankBlackEntity实体类的List对象(tsBankBlack)</returns>
        public override List<tsBankBlackEntity> tsBankBlackList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tsBankBlackEntity> mypd = new PopulateDelegate<tsBankBlackEntity>(base.PopulatetsBankBlackEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbFeedBack (tbFeedBack) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tbFeedBack (tbFeedBack)
        /// </summary>
        /// <param name="fam">tbFeedBackEntity实体类(tbFeedBack)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbFeedBackInsertUpdateDelete(tbFeedBackEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbFeedBack_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //序号ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@Source", SqlDbType.VarChar).Value = fam.Source;  //提交来源
                cmd.Parameters.Add("@Feedback", SqlDbType.VarChar).Value = fam.Feedback;  //反馈内容
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //提交时间
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fam.CustomerID;  //CustomerID
                cmd.Parameters.Add("@Mark", SqlDbType.Int).Value = fam.Mark;  //序号ID
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbFeedBack (tbFeedBack)
        /// </summary>
        /// <param name="fam">tbFeedBackEntity实体类(tbFeedBack)</param>
        /// <param name="tran">tbFeedBack事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbFeedBackInsertUpdateDelete(tbFeedBackEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbFeedBack_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //序号ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@Source", SqlDbType.VarChar).Value = fam.Source;  //提交来源
            cmd.Parameters.Add("@Feedback", SqlDbType.VarChar).Value = fam.Feedback;  //反馈内容
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //提交时间
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fam.CustomerID;  //CustomerID
            cmd.Parameters.Add("@Mark", SqlDbType.Int).Value = fam.Mark;  //CustomerID

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回tbFeedBackEntity实体类的List对象 (tbFeedBack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbFeedBackEntity实体类的List对象(tbFeedBack)</returns>
        public override List<tbFeedBackEntity> tbFeedBackList(QueryParam qp, out int RecordCount)
        {
            return tbFeedBackList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tbFeedBackEntity实体类的List对象 (tbFeedBack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbFeedBack事务</param>
        /// <returns>tbFeedBackEntity实体类的List对象(tbFeedBack)</returns>
        public override List<tbFeedBackEntity> tbFeedBackList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbFeedBackEntity> mypd = new PopulateDelegate<tbFeedBackEntity>(base.PopulatetbFeedBackEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbPostReport (tbPostReport) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tbPostReport (tbPostReport)
        /// </summary>
        /// <param name="fam">tbPostReportEntity实体类(tbPostReport)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbPostReportInsertUpdateDelete(tbPostReportEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbPostReport_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@SerialNo", SqlDbType.VarChar).Value = fam.SerialNo;  //SerialNo
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //UserID
                cmd.Parameters.Add("@ReportCustomerID", SqlDbType.Int).Value = fam.ReportCustomerID;  //ReportCustomerID
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
                cmd.Parameters.Add("@DealCustomerID", SqlDbType.Int).Value = fam.DealCustomerID;  //DealCustomerID
                if (fam.DealDate.HasValue)
                    cmd.Parameters.Add("@DealDate", SqlDbType.DateTime).Value = fam.DealDate;  //DealDate
                else
                    cmd.Parameters.Add("@DealDate", SqlDbType.DateTime).Value = DBNull.Value;  //DealDate
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = fam.Status;  //Status
                cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = fam.Remark;  //Remark
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbPostReport (tbPostReport)
        /// </summary>
        /// <param name="fam">tbPostReportEntity实体类(tbPostReport)</param>
        /// <param name="tran">tbPostReport事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbPostReportInsertUpdateDelete(tbPostReportEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbPostReport_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@SerialNo", SqlDbType.VarChar).Value = fam.SerialNo;  //SerialNo
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //UserID
            cmd.Parameters.Add("@ReportCustomerID", SqlDbType.Int).Value = fam.ReportCustomerID;  //ReportCustomerID
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
            cmd.Parameters.Add("@DealCustomerID", SqlDbType.Int).Value = fam.DealCustomerID;  //DealCustomerID
            if (fam.DealDate.HasValue)
                cmd.Parameters.Add("@DealDate", SqlDbType.DateTime).Value = fam.DealDate;  //DealDate
            else
                cmd.Parameters.Add("@DealDate", SqlDbType.DateTime).Value = DBNull.Value;  //DealDate
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = fam.Status;  //Status
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = fam.Remark;  //Remark

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回tbPostReportEntity实体类的List对象 (tbPostReport)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbPostReportEntity实体类的List对象(tbPostReport)</returns>
        public override List<tbPostReportEntity> tbPostReportList(QueryParam qp, out int RecordCount)
        {
            return tbPostReportList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tbPostReportEntity实体类的List对象 (tbPostReport)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbPostReport事务</param>
        /// <returns>tbPostReportEntity实体类的List对象(tbPostReport)</returns>
        public override List<tbPostReportEntity> tbPostReportList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbPostReportEntity> mypd = new PopulateDelegate<tbPostReportEntity>(base.PopulatetbPostReportEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbLevelOrderReJudg (tbLevelOrderReJudg) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderReJudg (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="fam">tbLevelOrderReJudgEntity实体类(tbLevelOrderReJudg)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderReJudgInsertUpdateDelete(tbLevelOrderReJudgEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderReJudg_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //ODSerialNo
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fam.CustomerID;  //CustomerID
                cmd.Parameters.Add("@Reason", SqlDbType.VarChar).Value = fam.Reason;  //Reason
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
                cmd.Parameters.Add("@MarkColor", SqlDbType.Int).Value = fam.MarkColor;  //MarkColor
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderReJudg (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="fam">tbLevelOrderReJudgEntity实体类(tbLevelOrderReJudg)</param>
        /// <param name="tran">tbLevelOrderReJudg事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderReJudgInsertUpdateDelete(tbLevelOrderReJudgEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderReJudg_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //ODSerialNo
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fam.CustomerID;  //CustomerID
            cmd.Parameters.Add("@Reason", SqlDbType.VarChar).Value = fam.Reason;  //Reason
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
            cmd.Parameters.Add("@MarkColor", SqlDbType.Int).Value = fam.MarkColor;  //MarkColor

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回tbLevelOrderReJudgEntity实体类的List对象 (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderReJudgEntity实体类的List对象(tbLevelOrderReJudg)</returns>
        public override List<tbLevelOrderReJudgEntity> tbLevelOrderReJudgList(QueryParam qp, out int RecordCount)
        {
            return tbLevelOrderReJudgList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tbLevelOrderReJudgEntity实体类的List对象 (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderReJudg事务</param>
        /// <returns>tbLevelOrderReJudgEntity实体类的List对象(tbLevelOrderReJudg)</returns>
        public override List<tbLevelOrderReJudgEntity> tbLevelOrderReJudgList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbLevelOrderReJudgEntity> mypd = new PopulateDelegate<tbLevelOrderReJudgEntity>(base.PopulatetbLevelOrderReJudgEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbServiceHelp (tbServiceHelp) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tbServiceHelp (tbServiceHelp)
        /// </summary>
        /// <param name="fam">tbServiceHelpEntity实体类(tbServiceHelp)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbServiceHelpInsertUpdateDelete(tbServiceHelpEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbServiceHelp_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //ODSerialNo
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //UserID
                cmd.Parameters.Add("@AcceptUserID", SqlDbType.Int).Value = fam.AcceptUserID;  //AcceptUserID
                cmd.Parameters.Add("@Content", SqlDbType.VarChar).Value = fam.Content;  //Content
                cmd.Parameters.Add("@IsDeal", SqlDbType.Bit).Value = fam.IsDeal;  //IsDeal
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
                if (fam.DealDate.HasValue)
                    cmd.Parameters.Add("@DealDate", SqlDbType.DateTime).Value = fam.DealDate;  //DealDate
                else
                    cmd.Parameters.Add("@DealDate", SqlDbType.DateTime).Value = DBNull.Value;  //DealDate
                cmd.Parameters.Add("@DealCustomerID", SqlDbType.Int).Value = fam.DealCustomerID;  //DealCustomerID
                cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = fam.Remark;  //Remark
                cmd.Parameters.Add("@HelpType", SqlDbType.Bit).Value = fam.HelpType;  //HelpType
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbServiceHelp (tbServiceHelp)
        /// </summary>
        /// <param name="fam">tbServiceHelpEntity实体类(tbServiceHelp)</param>
        /// <param name="tran">tbServiceHelp事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbServiceHelpInsertUpdateDelete(tbServiceHelpEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbServiceHelp_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //ODSerialNo
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //UserID
            cmd.Parameters.Add("@AcceptUserID", SqlDbType.Int).Value = fam.AcceptUserID;  //AcceptUserID
            cmd.Parameters.Add("@Content", SqlDbType.VarChar).Value = fam.Content;  //Content
            cmd.Parameters.Add("@IsDeal", SqlDbType.Bit).Value = fam.IsDeal;  //IsDeal
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
            if (fam.DealDate.HasValue)
                cmd.Parameters.Add("@DealDate", SqlDbType.DateTime).Value = fam.DealDate;  //DealDate
            else
                cmd.Parameters.Add("@DealDate", SqlDbType.DateTime).Value = DBNull.Value;  //DealDate
            cmd.Parameters.Add("@DealCustomerID", SqlDbType.Int).Value = fam.DealCustomerID;  //DealCustomerID
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = fam.Remark;  //Remark
            cmd.Parameters.Add("@HelpType", SqlDbType.Int).Value = fam.HelpType;  //HelpType
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回tbServiceHelpEntity实体类的List对象 (tbServiceHelp)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbServiceHelpEntity实体类的List对象(tbServiceHelp)</returns>
        public override List<tbServiceHelpEntity> tbServiceHelpList(QueryParam qp, out int RecordCount)
        {
            return tbServiceHelpList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tbServiceHelpEntity实体类的List对象 (tbServiceHelp)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbServiceHelp事务</param>
        /// <returns>tbServiceHelpEntity实体类的List对象(tbServiceHelp)</returns>
        public override List<tbServiceHelpEntity> tbServiceHelpList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbServiceHelpEntity> mypd = new PopulateDelegate<tbServiceHelpEntity>(base.PopulatetbServiceHelpEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbFinancialDay (财务每日数据) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tbFinancialDay (财务每日数据)
        /// </summary>
        /// <param name="fam">tbFinancialDayEntity实体类(财务每日数据)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbFinancialDayInsertUpdateDelete(tbFinancialDayEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbFinancialDay_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@TotalBal", SqlDbType.Money).Value = fam.TotalBal;  //总资金
                cmd.Parameters.Add("@TotalFreeze", SqlDbType.Money).Value = fam.TotalFreeze;  //总冻结资金
                cmd.Parameters.Add("@TotalWithDraw", SqlDbType.Money).Value = fam.TotalWithDraw;  //总提现资金
                cmd.Parameters.Add("@TotalOperate", SqlDbType.Money).Value = fam.TotalOperate;  //总可操作资金
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbFinancialDay (财务每日数据)
        /// </summary>
        /// <param name="fam">tbFinancialDayEntity实体类(财务每日数据)</param>
        /// <param name="tran">tbFinancialDay事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbFinancialDayInsertUpdateDelete(tbFinancialDayEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbFinancialDay_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@TotalBal", SqlDbType.Money).Value = fam.TotalBal;  //总资金
            cmd.Parameters.Add("@TotalFreeze", SqlDbType.Money).Value = fam.TotalFreeze;  //总冻结资金
            cmd.Parameters.Add("@TotalWithDraw", SqlDbType.Money).Value = fam.TotalWithDraw;  //总提现资金
            cmd.Parameters.Add("@TotalOperate", SqlDbType.Money).Value = fam.TotalOperate;  //总可操作资金
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tbFinancialDayEntity实体类的List对象 (财务每日数据)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbFinancialDayEntity实体类的List对象(财务每日数据)</returns>
        public override List<tbFinancialDayEntity> tbFinancialDayList(QueryParam qp, out int RecordCount)
        {
            return tbFinancialDayList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tbFinancialDayEntity实体类的List对象 (财务每日数据)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbFinancialDay事务</param>
        /// <returns>tbFinancialDayEntity实体类的List对象(财务每日数据)</returns>
        public override List<tbFinancialDayEntity> tbFinancialDayList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tbFinancialDayEntity> mypd = new PopulateDelegate<tbFinancialDayEntity>(base.PopulatetbFinancialDayEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "sys_PendingComment (sys_PendingComment) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 sys_PendingComment (sys_PendingComment)
        /// </summary>
        /// <param name="fam">sys_PendingCommentEntity实体类(sys_PendingComment)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 sys_PendingCommentInsertUpdateDelete(sys_PendingCommentEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.sys_PendingComment_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@P_CommentID", SqlDbType.Int).Value = fam.P_CommentID;  //P_CommentID
                cmd.Parameters.Add("@P_PendingID", SqlDbType.Int).Value = fam.P_PendingID;  //P_PendingID
                cmd.Parameters.Add("@P_CommentPostID", SqlDbType.Int).Value = fam.P_CommentPostID;  //P_CommentPostID
                cmd.Parameters.Add("@P_CommentStauts", SqlDbType.Int).Value = fam.P_CommentStauts;  //P_CommentStauts
                cmd.Parameters.Add("@P_CommentContent", SqlDbType.NText).Value = fam.P_CommentContent;  //P_CommentContent
                cmd.Parameters.Add("@P_CommentRemarks", SqlDbType.NVarChar).Value = fam.P_CommentRemarks;  //P_CommentRemarks
                cmd.Parameters.Add("@P_Pre", SqlDbType.NVarChar).Value = fam.P_Pre;  //P_Pre
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 sys_PendingComment (sys_PendingComment)
        /// </summary>
        /// <param name="fam">sys_PendingCommentEntity实体类(sys_PendingComment)</param>
        /// <param name="tran">sys_PendingComment事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 sys_PendingCommentInsertUpdateDelete(sys_PendingCommentEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.sys_PendingComment_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@P_CommentID", SqlDbType.Int).Value = fam.P_CommentID;  //P_CommentID
            cmd.Parameters.Add("@P_PendingID", SqlDbType.Int).Value = fam.P_PendingID;  //P_PendingID
            cmd.Parameters.Add("@P_CommentPostID", SqlDbType.Int).Value = fam.P_CommentPostID;  //P_CommentPostID
            cmd.Parameters.Add("@P_CommentStauts", SqlDbType.Int).Value = fam.P_CommentStauts;  //P_CommentStauts
            cmd.Parameters.Add("@P_CommentContent", SqlDbType.NText).Value = fam.P_CommentContent;  //P_CommentContent
            cmd.Parameters.Add("@P_CommentRemarks", SqlDbType.NVarChar).Value = fam.P_CommentRemarks;  //P_CommentRemarks
            cmd.Parameters.Add("@P_Pre", SqlDbType.NVarChar).Value = fam.P_Pre;  //P_Pre

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回sys_PendingCommentEntity实体类的List对象 (sys_PendingComment)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_PendingCommentEntity实体类的List对象(sys_PendingComment)</returns>
        public override List<sys_PendingCommentEntity> sys_PendingCommentList(QueryParam qp, out int RecordCount)
        {
            return sys_PendingCommentList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回sys_PendingCommentEntity实体类的List对象 (sys_PendingComment)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">sys_PendingComment事务</param>
        /// <returns>sys_PendingCommentEntity实体类的List对象(sys_PendingComment)</returns>
        public override List<sys_PendingCommentEntity> sys_PendingCommentList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<sys_PendingCommentEntity> mypd = new PopulateDelegate<sys_PendingCommentEntity>(base.Populatesys_PendingCommentEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbLevelOrderCancel (代练撤销) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tbLevelOrderCancel (代练撤销)
        /// </summary>
        /// <param name="fam">tbLevelOrderCancelEntity实体类(代练撤销)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderCancelInsertUpdateDelete(tbLevelOrderCancelEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderCancel_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //订单流水号
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
                cmd.Parameters.Add("@PayLevelBal", SqlDbType.Money).Value = fam.PayLevelBal;  //支付代练费
                cmd.Parameters.Add("@RepEnsureBal", SqlDbType.Money).Value = fam.RepEnsureBal;  //赔偿保证金
                cmd.Parameters.Add("@Status", SqlDbType.SmallInt).Value = fam.Status;  //状态
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //备注
                cmd.Parameters.Add("@AcceptCount", SqlDbType.Int).Value = fam.AcceptCount;  //接单方撤销次数
                cmd.Parameters.Add("@PublishCount", SqlDbType.Int).Value = fam.PublishCount;  //发单方撤销次数
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderCancel (代练撤销)
        /// </summary>
        /// <param name="fam">tbLevelOrderCancelEntity实体类(代练撤销)</param>
        /// <param name="tran">tbLevelOrderCancel事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderCancelInsertUpdateDelete(tbLevelOrderCancelEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderCancel_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //订单流水号
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
            cmd.Parameters.Add("@PayLevelBal", SqlDbType.Money).Value = fam.PayLevelBal;  //支付代练费
            cmd.Parameters.Add("@RepEnsureBal", SqlDbType.Money).Value = fam.RepEnsureBal;  //赔偿保证金
            cmd.Parameters.Add("@Status", SqlDbType.SmallInt).Value = fam.Status;  //状态
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //备注
            cmd.Parameters.Add("@AcceptCount", SqlDbType.Int).Value = fam.AcceptCount;  //接单方撤销次数
            cmd.Parameters.Add("@PublishCount", SqlDbType.Int).Value = fam.PublishCount;  //发单方撤销次数
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tbLevelOrderCancelEntity实体类的List对象 (代练撤销)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderCancelEntity实体类的List对象(代练撤销)</returns>
        public override List<tbLevelOrderCancelEntity> tbLevelOrderCancelList(QueryParam qp, out int RecordCount)
        {
            return tbLevelOrderCancelList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tbLevelOrderCancelEntity实体类的List对象 (代练撤销)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderCancel事务</param>
        /// <returns>tbLevelOrderCancelEntity实体类的List对象(代练撤销)</returns>
        public override List<tbLevelOrderCancelEntity> tbLevelOrderCancelList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tbLevelOrderCancelEntity> mypd = new PopulateDelegate<tbLevelOrderCancelEntity>(base.PopulatetbLevelOrderCancelEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region 用户列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qp"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public override List<tsUser1Entity> UserList1(QueryParam qp, out int RecordCount)
        {
            return UserList1(qp, out RecordCount, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qp"></param>
        /// <param name="RecordCount"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public override List<tsUser1Entity> UserList1(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tsUser1Entity> mypd = new PopulateDelegate<tsUser1Entity>(base.UserList1Entity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            } 
        } 
        #endregion


        #region "tbLevelOrderFee (订单费用) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tbLevelOrderFee (订单费用)
        /// </summary>
        /// <param name="fam">tbLevelOrderFeeEntity实体类(订单费用)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderFeeInsertUpdateDelete(tbLevelOrderFeeEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderFee_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //订单流水号
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@Bal", SqlDbType.Money).Value = fam.Bal;  //金额
                cmd.Parameters.Add("@Fee", SqlDbType.Money).Value = fam.Fee;  //手续费
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderFee (订单费用)
        /// </summary>
        /// <param name="fam">tbLevelOrderFeeEntity实体类(订单费用)</param>
        /// <param name="tran">tbLevelOrderFee事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderFeeInsertUpdateDelete(tbLevelOrderFeeEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderFee_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //订单流水号
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@Bal", SqlDbType.Money).Value = fam.Bal;  //金额
            cmd.Parameters.Add("@Fee", SqlDbType.Money).Value = fam.Fee;  //手续费
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tbLevelOrderFeeEntity实体类的List对象 (订单费用)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderFeeEntity实体类的List对象(订单费用)</returns>
        public override List<tbLevelOrderFeeEntity> tbLevelOrderFeeList(QueryParam qp, out int RecordCount)
        {
            return tbLevelOrderFeeList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tbLevelOrderFeeEntity实体类的List对象 (订单费用)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderFee事务</param>
        /// <returns>tbLevelOrderFeeEntity实体类的List对象(订单费用)</returns>
        public override List<tbLevelOrderFeeEntity> tbLevelOrderFeeList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tbLevelOrderFeeEntity> mypd = new PopulateDelegate<tbLevelOrderFeeEntity>(base.PopulatetbLevelOrderFeeEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tbLevelOrderInfo (代练订单角色资料) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tbLevelOrderInfo (代练订单角色资料)
        /// </summary>
        /// <param name="fam">tbLevelOrderInfoEntity实体类(代练订单角色资料)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderInfoInsertUpdateDelete(tbLevelOrderInfoEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderInfo_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //订单流水号
                cmd.Parameters.Add("@GameAcc", SqlDbType.VarChar).Value = fam.GameAcc;  //帐号
                cmd.Parameters.Add("@GamePass", SqlDbType.VarChar).Value = fam.GamePass;  //密码
                cmd.Parameters.Add("@Actor", SqlDbType.VarChar).Value = fam.Actor;  //角色
                cmd.Parameters.Add("@CurrInfo", SqlDbType.VarChar).Value = fam.CurrInfo;  //代练前角色信息
                cmd.Parameters.Add("@Require", SqlDbType.VarChar).Value = fam.Require;  //代练最终要求
                cmd.Parameters.Add("@SecPic", SqlDbType.Image).Value = fam.SecPic;  //密保图片
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
                cmd.Parameters.Add("@ChangePassCount", SqlDbType.Int).Value = fam.ChangePassCount;  //改密次数
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderInfo (代练订单角色资料)
        /// </summary>
        /// <param name="fam">tbLevelOrderInfoEntity实体类(代练订单角色资料)</param>
        /// <param name="tran">tbLevelOrderInfo事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderInfoInsertUpdateDelete(tbLevelOrderInfoEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderInfo_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //订单流水号
            cmd.Parameters.Add("@GameAcc", SqlDbType.VarChar).Value = fam.GameAcc;  //帐号
            cmd.Parameters.Add("@GamePass", SqlDbType.VarChar).Value = fam.GamePass;  //密码
            cmd.Parameters.Add("@Actor", SqlDbType.VarChar).Value = fam.Actor;  //角色
            cmd.Parameters.Add("@CurrInfo", SqlDbType.VarChar).Value = fam.CurrInfo;  //代练前角色信息
            cmd.Parameters.Add("@Require", SqlDbType.VarChar).Value = fam.Require;  //代练最终要求
            cmd.Parameters.Add("@SecPic", SqlDbType.Image).Value = fam.SecPic;  //密保图片
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
            cmd.Parameters.Add("@ChangePassCount", SqlDbType.Int).Value = fam.ChangePassCount;  //改密次数
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tbLevelOrderInfoEntity实体类的List对象 (代练订单角色资料)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderInfoEntity实体类的List对象(代练订单角色资料)</returns>
        public override List<tbLevelOrderInfoEntity> tbLevelOrderInfoList(QueryParam qp, out int RecordCount)
        {
            return tbLevelOrderInfoList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tbLevelOrderInfoEntity实体类的List对象 (代练订单角色资料)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderInfo事务</param>
        /// <returns>tbLevelOrderInfoEntity实体类的List对象(代练订单角色资料)</returns>
        public override List<tbLevelOrderInfoEntity> tbLevelOrderInfoList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tbLevelOrderInfoEntity> mypd = new PopulateDelegate<tbLevelOrderInfoEntity>(base.PopulatetbLevelOrderInfoEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tbLevelOrderMessage (订单交互留言) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tbLevelOrderMessage (订单交互留言)
        /// </summary>
        /// <param name="fam">tbLevelOrderMessageEntity实体类(订单交互留言)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderMessageInsertUpdateDelete(tbLevelOrderMessageEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderMessage_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //订单流水号
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@MsgType", SqlDbType.SmallInt).Value = fam.MsgType;  //留言类别
                cmd.Parameters.Add("@Msg", SqlDbType.VarChar).Value = fam.Msg;  //留言内容
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
                cmd.Parameters.Add("@IsRead", SqlDbType.Bit).Value = fam.IsRead;  //已读标记
                cmd.Parameters.Add("@IsRead2", SqlDbType.Bit).Value = fam.IsRead2;  //已读标记2
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderMessage (订单交互留言)
        /// </summary>
        /// <param name="fam">tbLevelOrderMessageEntity实体类(订单交互留言)</param>
        /// <param name="tran">tbLevelOrderMessage事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderMessageInsertUpdateDelete(tbLevelOrderMessageEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderMessage_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //订单流水号
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@MsgType", SqlDbType.SmallInt).Value = fam.MsgType;  //留言类别
            cmd.Parameters.Add("@Msg", SqlDbType.VarChar).Value = fam.Msg;  //留言内容
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
            cmd.Parameters.Add("@IsRead", SqlDbType.Bit).Value = fam.IsRead;  //已读标记
            cmd.Parameters.Add("@IsRead2", SqlDbType.Bit).Value = fam.IsRead2;  //已读标记2
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tbLevelOrderMessageEntity实体类的List对象 (订单交互留言)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderMessageEntity实体类的List对象(订单交互留言)</returns>
        public override List<tbLevelOrderMessageEntity> tbLevelOrderMessageList(QueryParam qp, out int RecordCount)
        {
            return tbLevelOrderMessageList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tbLevelOrderMessageEntity实体类的List对象 (订单交互留言)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderMessage事务</param>
        /// <returns>tbLevelOrderMessageEntity实体类的List对象(订单交互留言)</returns>
        public override List<tbLevelOrderMessageEntity> tbLevelOrderMessageList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tbLevelOrderMessageEntity> mypd = new PopulateDelegate<tbLevelOrderMessageEntity>(base.PopulatetbLevelOrderMessageEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tbLevelOrderProgress (代练进度) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tbLevelOrderProgress (代练进度)
        /// </summary>
        /// <param name="fam">tbLevelOrderProgressEntity实体类(代练进度)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderProgressInsertUpdateDelete(tbLevelOrderProgressEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderProgress_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //订单流水号
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
                cmd.Parameters.Add("@Img", SqlDbType.VarChar).Value = fam.Img;  //图片地址
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
                cmd.Parameters.Add("@Source", SqlDbType.SmallInt).Value = fam.Source;  //进度来源
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderProgress (代练进度)
        /// </summary>
        /// <param name="fam">tbLevelOrderProgressEntity实体类(代练进度)</param>
        /// <param name="tran">tbLevelOrderProgress事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderProgressInsertUpdateDelete(tbLevelOrderProgressEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderProgress_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //订单流水号
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
            cmd.Parameters.Add("@Img", SqlDbType.VarChar).Value = fam.Img;  //图片地址
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
            cmd.Parameters.Add("@Source", SqlDbType.SmallInt).Value = fam.Source;  //进度来源
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tbLevelOrderProgressEntity实体类的List对象 (代练进度)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderProgressEntity实体类的List对象(代练进度)</returns>
        public override List<tbLevelOrderProgressEntity> tbLevelOrderProgressList(QueryParam qp, out int RecordCount)
        {
            return tbLevelOrderProgressList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tbLevelOrderProgressEntity实体类的List对象 (代练进度)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderProgress事务</param>
        /// <returns>tbLevelOrderProgressEntity实体类的List对象(代练进度)</returns>
        public override List<tbLevelOrderProgressEntity> tbLevelOrderProgressList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tbLevelOrderProgressEntity> mypd = new PopulateDelegate<tbLevelOrderProgressEntity>(base.PopulatetbLevelOrderProgressEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tbLevelOrderRight (订单可查看权限) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tbLevelOrderRight (订单可查看权限)
        /// </summary>
        /// <param name="fam">tbLevelOrderRightEntity实体类(订单可查看权限)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderRightInsertUpdateDelete(tbLevelOrderRightEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderRight_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //订单流水号
                cmd.Parameters.Add("@RightType", SqlDbType.SmallInt).Value = fam.RightType;  //权限类别
                cmd.Parameters.Add("@RelaID", SqlDbType.Int).Value = fam.RelaID;  //相关ID
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderRight (订单可查看权限)
        /// </summary>
        /// <param name="fam">tbLevelOrderRightEntity实体类(订单可查看权限)</param>
        /// <param name="tran">tbLevelOrderRight事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbLevelOrderRightInsertUpdateDelete(tbLevelOrderRightEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbLevelOrderRight_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@ODSerialNo", SqlDbType.VarChar).Value = fam.ODSerialNo;  //订单流水号
            cmd.Parameters.Add("@RightType", SqlDbType.SmallInt).Value = fam.RightType;  //权限类别
            cmd.Parameters.Add("@RelaID", SqlDbType.Int).Value = fam.RelaID;  //相关ID
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tbLevelOrderRightEntity实体类的List对象 (订单可查看权限)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderRightEntity实体类的List对象(订单可查看权限)</returns>
        public override List<tbLevelOrderRightEntity> tbLevelOrderRightList(QueryParam qp, out int RecordCount)
        {
            return tbLevelOrderRightList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tbLevelOrderRightEntity实体类的List对象 (订单可查看权限)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderRight事务</param>
        /// <returns>tbLevelOrderRightEntity实体类的List对象(订单可查看权限)</returns>
        public override List<tbLevelOrderRightEntity> tbLevelOrderRightList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tbLevelOrderRightEntity> mypd = new PopulateDelegate<tbLevelOrderRightEntity>(base.PopulatetbLevelOrderRightEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tcUserStat (用户统计数据) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tcUserStat (用户统计数据)
        /// </summary>
        /// <param name="fam">tcUserStatEntity实体类(用户统计数据)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tcUserStatInsertUpdateDelete(tcUserStatEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tcUserStat_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@PubCount", SqlDbType.Int).Value = fam.PubCount;  //发单总数
                cmd.Parameters.Add("@PubCancel", SqlDbType.Int).Value = fam.PubCancel;  //发单介入撤单数
                cmd.Parameters.Add("@PubConsultCancel", SqlDbType.Int).Value = fam.PubConsultCancel;  //发单协商撤单数
                cmd.Parameters.Add("@AcceptCount", SqlDbType.Int).Value = fam.AcceptCount;  //接单介入总数
                cmd.Parameters.Add("@AcceptCancel", SqlDbType.Int).Value = fam.AcceptCancel;  //接单撤单数
                cmd.Parameters.Add("@AcceptConsultCancel", SqlDbType.Int).Value = fam.AcceptConsultCancel;  //接单协商撤单数
                cmd.Parameters.Add("@OnlineMin", SqlDbType.BigInt).Value = fam.OnlineMin;  //在线时长
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tcUserStat (用户统计数据)
        /// </summary>
        /// <param name="fam">tcUserStatEntity实体类(用户统计数据)</param>
        /// <param name="tran">tcUserStat事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tcUserStatInsertUpdateDelete(tcUserStatEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tcUserStat_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@PubCount", SqlDbType.Int).Value = fam.PubCount;  //发单总数
            cmd.Parameters.Add("@PubCancel", SqlDbType.Int).Value = fam.PubCancel;  //发单介入撤单数
            cmd.Parameters.Add("@PubConsultCancel", SqlDbType.Int).Value = fam.PubConsultCancel;  //发单协商撤单数
            cmd.Parameters.Add("@AcceptCount", SqlDbType.Int).Value = fam.AcceptCount;  //接单介入总数
            cmd.Parameters.Add("@AcceptCancel", SqlDbType.Int).Value = fam.AcceptCancel;  //接单撤单数
            cmd.Parameters.Add("@AcceptConsultCancel", SqlDbType.Int).Value = fam.AcceptConsultCancel;  //接单协商撤单数
            cmd.Parameters.Add("@OnlineMin", SqlDbType.BigInt).Value = fam.OnlineMin;  //在线时长
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tcUserStatEntity实体类的List对象 (用户统计数据)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tcUserStatEntity实体类的List对象(用户统计数据)</returns>
        public override List<tcUserStatEntity> tcUserStatList(QueryParam qp, out int RecordCount)
        {
            return tcUserStatList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tcUserStatEntity实体类的List对象 (用户统计数据)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tcUserStat事务</param>
        /// <returns>tcUserStatEntity实体类的List对象(用户统计数据)</returns>
        public override List<tcUserStatEntity> tcUserStatList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tcUserStatEntity> mypd = new PopulateDelegate<tcUserStatEntity>(base.PopulatetcUserStatEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tlLogin (登录日志) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tlLogin (登录日志)
        /// </summary>
        /// <param name="fam">tlLoginEntity实体类(登录日志)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tlLoginInsertUpdateDelete(tlLoginEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tlLogin_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@SubUserID", SqlDbType.Int).Value = fam.SubUserID;  //子帐号ID
                cmd.Parameters.Add("@LoginType", SqlDbType.Int).Value = fam.LoginType;  //登录类别
                cmd.Parameters.Add("@PCName", SqlDbType.VarChar).Value = fam.PCName;  //机器名
                cmd.Parameters.Add("@HD", SqlDbType.VarChar).Value = fam.HD;  //硬盘
                cmd.Parameters.Add("@Mac", SqlDbType.VarChar).Value = fam.Mac;  //网卡
                cmd.Parameters.Add("@IP", SqlDbType.VarChar).Value = fam.IP;  //IP地址
                cmd.Parameters.Add("@OS", SqlDbType.VarChar).Value = fam.OS;  //操作系统
                if (fam.LoginDate.HasValue)
                    cmd.Parameters.Add("@LoginDate", SqlDbType.DateTime).Value = fam.LoginDate;  //登录时间
                else
                    cmd.Parameters.Add("@LoginDate", SqlDbType.DateTime).Value = DBNull.Value;  //登录时间
                if (fam.LogoutDate.HasValue)
                    cmd.Parameters.Add("@LogoutDate", SqlDbType.DateTime).Value = fam.LogoutDate;  //登出时间
                else
                    cmd.Parameters.Add("@LogoutDate", SqlDbType.DateTime).Value = DBNull.Value;  //登出时间
                cmd.Parameters.Add("@Status", SqlDbType.SmallInt).Value = fam.Status;  //状态
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //备注
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tlLogin (登录日志)
        /// </summary>
        /// <param name="fam">tlLoginEntity实体类(登录日志)</param>
        /// <param name="tran">tlLogin事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tlLoginInsertUpdateDelete(tlLoginEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tlLogin_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@SubUserID", SqlDbType.Int).Value = fam.SubUserID;  //子帐号ID
            cmd.Parameters.Add("@LoginType", SqlDbType.Int).Value = fam.LoginType;  //登录类别
            cmd.Parameters.Add("@PCName", SqlDbType.VarChar).Value = fam.PCName;  //机器名
            cmd.Parameters.Add("@HD", SqlDbType.VarChar).Value = fam.HD;  //硬盘
            cmd.Parameters.Add("@Mac", SqlDbType.VarChar).Value = fam.Mac;  //网卡
            cmd.Parameters.Add("@IP", SqlDbType.VarChar).Value = fam.IP;  //IP地址
            cmd.Parameters.Add("@OS", SqlDbType.VarChar).Value = fam.OS;  //操作系统
            if (fam.LoginDate.HasValue)
                cmd.Parameters.Add("@LoginDate", SqlDbType.DateTime).Value = fam.LoginDate;  //登录时间
            else
                cmd.Parameters.Add("@LoginDate", SqlDbType.DateTime).Value = DBNull.Value;  //登录时间
            if (fam.LogoutDate.HasValue)
                cmd.Parameters.Add("@LogoutDate", SqlDbType.DateTime).Value = fam.LogoutDate;  //登出时间
            else
                cmd.Parameters.Add("@LogoutDate", SqlDbType.DateTime).Value = DBNull.Value;  //登出时间
            cmd.Parameters.Add("@Status", SqlDbType.SmallInt).Value = fam.Status;  //状态
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //备注
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tlLoginEntity实体类的List对象 (登录日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tlLoginEntity实体类的List对象(登录日志)</returns>
        public override List<tlLoginEntity> tlLoginList(QueryParam qp, out int RecordCount)
        {
            return tlLoginList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tlLoginEntity实体类的List对象 (登录日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tlLogin事务</param>
        /// <returns>tlLoginEntity实体类的List对象(登录日志)</returns>
        public override List<tlLoginEntity> tlLoginList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tlLoginEntity> mypd = new PopulateDelegate<tlLoginEntity>(base.PopulatetlLoginEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tlOperate (操作日志) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tlOperate (操作日志)
        /// </summary>
        /// <param name="fam">tlOperateEntity实体类(操作日志)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tlOperateInsertUpdateDelete(tlOperateEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tlOperate_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@OPType", SqlDbType.Int).Value = fam.OPType;  //操作类别
                cmd.Parameters.Add("@OPLog", SqlDbType.VarChar).Value = fam.OPLog;  //操作日志
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
                cmd.Parameters.Add("@IP", SqlDbType.VarChar).Value = fam.IP;  //IP地址
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tlOperate (操作日志)
        /// </summary>
        /// <param name="fam">tlOperateEntity实体类(操作日志)</param>
        /// <param name="tran">tlOperate事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tlOperateInsertUpdateDelete(tlOperateEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tlOperate_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@OPType", SqlDbType.Int).Value = fam.OPType;  //操作类别
            cmd.Parameters.Add("@OPLog", SqlDbType.VarChar).Value = fam.OPLog;  //操作日志
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
            cmd.Parameters.Add("@IP", SqlDbType.VarChar).Value = fam.IP;  //IP地址
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        

        /// <summary>
        /// 返回tlOperateEntity实体类的List对象 (操作日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tlOperateEntity实体类的List对象(操作日志)</returns>
        public override List<tlOperateEntity> tlOperateList(QueryParam qp, out int RecordCount)
        {
            return tlOperateList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tlOperateEntity实体类的List对象 (操作日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tlOperate事务</param>
        /// <returns>tlOperateEntity实体类的List对象(操作日志)</returns>
        public override List<tlOperateEntity> tlOperateList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tlOperateEntity> mypd = new PopulateDelegate<tlOperateEntity>(base.PopulatetlOperateEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsBank (银行账户) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsBank (银行账户)
        /// </summary>
        /// <param name="fam">tsBankEntity实体类(银行账户)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsBankInsertUpdateDelete(tsBankEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsBank_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@BankID", SqlDbType.SmallInt).Value = fam.BankID;  //银行ID
                cmd.Parameters.Add("@BankUser", SqlDbType.VarChar).Value = fam.BankUser;  //银行户名
                cmd.Parameters.Add("@BankAcc", SqlDbType.VarChar).Value = fam.BankAcc;  //银行账号
                cmd.Parameters.Add("@BankAddr", SqlDbType.VarChar).Value = fam.BankAddr;  //开户地址
                cmd.Parameters.Add("@IsDefault", SqlDbType.Bit).Value = fam.IsDefault;  //是否缺省
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //备注
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsBank (银行账户)
        /// </summary>
        /// <param name="fam">tsBankEntity实体类(银行账户)</param>
        /// <param name="tran">tsBank事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsBankInsertUpdateDelete(tsBankEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsBank_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@BankID", SqlDbType.SmallInt).Value = fam.BankID;  //银行ID
            cmd.Parameters.Add("@BankUser", SqlDbType.VarChar).Value = fam.BankUser;  //银行户名
            cmd.Parameters.Add("@BankAcc", SqlDbType.VarChar).Value = fam.BankAcc;  //银行账号
            cmd.Parameters.Add("@BankAddr", SqlDbType.VarChar).Value = fam.BankAddr;  //开户地址
            cmd.Parameters.Add("@IsDefault", SqlDbType.Bit).Value = fam.IsDefault;  //是否缺省
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //备注
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsBankEntity实体类的List对象 (银行账户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsBankEntity实体类的List对象(银行账户)</returns>
        public override List<tsBankEntity> tsBankList(QueryParam qp, out int RecordCount)
        {
            return tsBankList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsBankEntity实体类的List对象 (银行账户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsBank事务</param>
        /// <returns>tsBankEntity实体类的List对象(银行账户)</returns>
        public override List<tsBankEntity> tsBankList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsBankEntity> mypd = new PopulateDelegate<tsBankEntity>(base.PopulatetsBankEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsBlack (黑名单) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsBlack (黑名单)
        /// </summary>
        /// <param name="fam">tsBlackEntity实体类(黑名单)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsBlackInsertUpdateDelete(tsBlackEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsBlack_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@BlackUserID", SqlDbType.Int).Value = fam.BlackUserID;  //拉黑用户
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsBlack (黑名单)
        /// </summary>
        /// <param name="fam">tsBlackEntity实体类(黑名单)</param>
        /// <param name="tran">tsBlack事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsBlackInsertUpdateDelete(tsBlackEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsBlack_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@BlackUserID", SqlDbType.Int).Value = fam.BlackUserID;  //拉黑用户
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsBlackEntity实体类的List对象 (黑名单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsBlackEntity实体类的List对象(黑名单)</returns>
        public override List<tsBlackEntity> tsBlackList(QueryParam qp, out int RecordCount)
        {
            return tsBlackList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsBlackEntity实体类的List对象 (黑名单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsBlack事务</param>
        /// <returns>tsBlackEntity实体类的List对象(黑名单)</returns>
        public override List<tsBlackEntity> tsBlackList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsBlackEntity> mypd = new PopulateDelegate<tsBlackEntity>(base.PopulatetsBlackEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsCategory (商品分类) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsCategory (商品分类)
        /// </summary>
        /// <param name="fam">tsCategoryEntity实体类(商品分类)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsCategoryInsertUpdateDelete(tsCategoryEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsCategory_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = fam.Category;  //分类
                cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fam.ParentID;  //父分类
                cmd.Parameters.Add("@Depth", SqlDbType.Int).Value = fam.Depth;  //深度
                cmd.Parameters.Add("@Spell", SqlDbType.VarChar).Value = fam.Spell;  //拼音
                cmd.Parameters.Add("@Order", SqlDbType.Int).Value = fam.Order;  //排序
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsCategory (商品分类)
        /// </summary>
        /// <param name="fam">tsCategoryEntity实体类(商品分类)</param>
        /// <param name="tran">tsCategory事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsCategoryInsertUpdateDelete(tsCategoryEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsCategory_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = fam.Category;  //分类
            cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fam.ParentID;  //父分类
            cmd.Parameters.Add("@Depth", SqlDbType.Int).Value = fam.Depth;  //深度
            cmd.Parameters.Add("@Spell", SqlDbType.VarChar).Value = fam.Spell;  //拼音
            cmd.Parameters.Add("@Order", SqlDbType.Int).Value = fam.Order;  //排序
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsCategoryEntity实体类的List对象 (商品分类)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsCategoryEntity实体类的List对象(商品分类)</returns>
        public override List<tsCategoryEntity> tsCategoryList(QueryParam qp, out int RecordCount)
        {
            return tsCategoryList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsCategoryEntity实体类的List对象 (商品分类)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsCategory事务</param>
        /// <returns>tsCategoryEntity实体类的List对象(商品分类)</returns>
        public override List<tsCategoryEntity> tsCategoryList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsCategoryEntity> mypd = new PopulateDelegate<tsCategoryEntity>(base.PopulatetsCategoryEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsCompany (厂商) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsCompany (厂商)
        /// </summary>
        /// <param name="fam">tsCompanyEntity实体类(厂商)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsCompanyInsertUpdateDelete(tsCompanyEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsCompany_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@Company", SqlDbType.VarChar).Value = fam.Company;  //厂商
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsCompany (厂商)
        /// </summary>
        /// <param name="fam">tsCompanyEntity实体类(厂商)</param>
        /// <param name="tran">tsCompany事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsCompanyInsertUpdateDelete(tsCompanyEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsCompany_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@Company", SqlDbType.VarChar).Value = fam.Company;  //厂商
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsCompanyEntity实体类的List对象 (厂商)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsCompanyEntity实体类的List对象(厂商)</returns>
        public override List<tsCompanyEntity> tsCompanyList(QueryParam qp, out int RecordCount)
        {
            return tsCompanyList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsCompanyEntity实体类的List对象 (厂商)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsCompany事务</param>
        /// <returns>tsCompanyEntity实体类的List对象(厂商)</returns>
        public override List<tsCompanyEntity> tsCompanyList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsCompanyEntity> mypd = new PopulateDelegate<tsCompanyEntity>(base.PopulatetsCompanyEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsCreditEval (信用评价) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsCreditEval (信用评价)
        /// </summary>
        /// <param name="fam">tsCreditEvalEntity实体类(信用评价)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsCreditEvalInsertUpdateDelete(tsCreditEvalEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsCreditEval_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@EvalDirect", SqlDbType.SmallInt).Value = fam.EvalDirect;  //评价方向
                cmd.Parameters.Add("@Beautifully", SqlDbType.Int).Value = fam.Beautifully;  //非常满意
                cmd.Parameters.Add("@Good", SqlDbType.Int).Value = fam.Good;  //满意
                cmd.Parameters.Add("@Normal", SqlDbType.Int).Value = fam.Normal;  //一般
                cmd.Parameters.Add("@Poor", SqlDbType.Int).Value = fam.Poor;  //很差
                cmd.Parameters.Add("@Score", SqlDbType.BigInt).Value = fam.Score;  //信用总分
                cmd.Parameters.Add("@Level", SqlDbType.Int).Value = fam.Level;  //信用等级
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsCreditEval (信用评价)
        /// </summary>
        /// <param name="fam">tsCreditEvalEntity实体类(信用评价)</param>
        /// <param name="tran">tsCreditEval事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsCreditEvalInsertUpdateDelete(tsCreditEvalEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsCreditEval_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@EvalDirect", SqlDbType.SmallInt).Value = fam.EvalDirect;  //评价方向
            cmd.Parameters.Add("@Beautifully", SqlDbType.Int).Value = fam.Beautifully;  //非常满意
            cmd.Parameters.Add("@Good", SqlDbType.Int).Value = fam.Good;  //满意
            cmd.Parameters.Add("@Normal", SqlDbType.Int).Value = fam.Normal;  //一般
            cmd.Parameters.Add("@Poor", SqlDbType.Int).Value = fam.Poor;  //很差
            cmd.Parameters.Add("@Score", SqlDbType.BigInt).Value = fam.Score;  //信用总分
            cmd.Parameters.Add("@Level", SqlDbType.Int).Value = fam.Level;  //信用等级
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsCreditEvalEntity实体类的List对象 (信用评价)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsCreditEvalEntity实体类的List对象(信用评价)</returns>
        public override List<tsCreditEvalEntity> tsCreditEvalList(QueryParam qp, out int RecordCount)
        {
            return tsCreditEvalList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsCreditEvalEntity实体类的List对象 (信用评价)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsCreditEval事务</param>
        /// <returns>tsCreditEvalEntity实体类的List对象(信用评价)</returns>
        public override List<tsCreditEvalEntity> tsCreditEvalList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsCreditEvalEntity> mypd = new PopulateDelegate<tsCreditEvalEntity>(base.PopulatetsCreditEvalEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsDict (数据字典) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsDict (数据字典)
        /// </summary>
        /// <param name="fam">tsDictEntity实体类(数据字典)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsDictInsertUpdateDelete(tsDictEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsDict_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@Key", SqlDbType.Int).Value = fam.Key;  //大类
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = fam.Name;  //名称
                cmd.Parameters.Add("@Kind", SqlDbType.SmallInt).Value = fam.Kind;  //小类
                cmd.Parameters.Add("@Value", SqlDbType.VarChar).Value = fam.Value;  //值
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsDict (数据字典)
        /// </summary>
        /// <param name="fam">tsDictEntity实体类(数据字典)</param>
        /// <param name="tran">tsDict事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsDictInsertUpdateDelete(tsDictEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsDict_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@Key", SqlDbType.Int).Value = fam.Key;  //大类
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = fam.Name;  //名称
            cmd.Parameters.Add("@Kind", SqlDbType.SmallInt).Value = fam.Kind;  //小类
            cmd.Parameters.Add("@Value", SqlDbType.VarChar).Value = fam.Value;  //值
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsDictEntity实体类的List对象 (数据字典)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsDictEntity实体类的List对象(数据字典)</returns>
        public override List<tsDictEntity> tsDictList(QueryParam qp, out int RecordCount)
        {
            return tsDictList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsDictEntity实体类的List对象 (数据字典)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsDict事务</param>
        /// <returns>tsDictEntity实体类的List对象(数据字典)</returns>
        public override List<tsDictEntity> tsDictList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsDictEntity> mypd = new PopulateDelegate<tsDictEntity>(base.PopulatetsDictEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsFaction (阵营) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsFaction (阵营)
        /// </summary>
        /// <param name="fam">tsFactionEntity实体类(阵营)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsFactionInsertUpdateDelete(tsFactionEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsFaction_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@GameID", SqlDbType.Int).Value = fam.GameID;  //游戏ID
                cmd.Parameters.Add("@Faction", SqlDbType.VarChar).Value = fam.Faction;  //阵营
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsFaction (阵营)
        /// </summary>
        /// <param name="fam">tsFactionEntity实体类(阵营)</param>
        /// <param name="tran">tsFaction事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsFactionInsertUpdateDelete(tsFactionEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsFaction_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@GameID", SqlDbType.Int).Value = fam.GameID;  //游戏ID
            cmd.Parameters.Add("@Faction", SqlDbType.VarChar).Value = fam.Faction;  //阵营
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsFactionEntity实体类的List对象 (阵营)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsFactionEntity实体类的List对象(阵营)</returns>
        public override List<tsFactionEntity> tsFactionList(QueryParam qp, out int RecordCount)
        {
            return tsFactionList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsFactionEntity实体类的List对象 (阵营)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsFaction事务</param>
        /// <returns>tsFactionEntity实体类的List对象(阵营)</returns>
        public override List<tsFactionEntity> tsFactionList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsFactionEntity> mypd = new PopulateDelegate<tsFactionEntity>(base.PopulatetsFactionEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsGame (游戏) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsGame (游戏)
        /// </summary>
        /// <param name="fam">tsGameEntity实体类(游戏)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsGameInsertUpdateDelete(tsGameEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsGame_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@CompID", SqlDbType.Int).Value = fam.CompID;  //厂商ID
                cmd.Parameters.Add("@Game", SqlDbType.VarChar).Value = fam.Game;  //游戏
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
                cmd.Parameters.Add("@IsOnline", SqlDbType.Bit).Value = fam.IsOnline;  //运营状态
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fam"></param>
        /// <returns></returns>
        public override Int32 tsActivityInsertUpdateDelete(tsActivityEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsActivity_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ImageUrl", SqlDbType.VarChar).Value = fam.ImageUrl; 
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = fam.Name;  
                cmd.Parameters.Add("@reward", SqlDbType.Decimal).Value = fam.Reward;
                cmd.Parameters.Add("@GameID", SqlDbType.Int).Value = fam.GameID;  
                cmd.Parameters.Add("@TimeLimit", SqlDbType.Int).Value = fam.TimeLimit;
                cmd.Parameters.Add("@content", SqlDbType.Text).Value = fam.Content;
                cmd.Parameters.Add("@Sort", SqlDbType.Int).Value = fam.Sort;
                cmd.Parameters.Add("@enable", SqlDbType.Bit).Value = fam.Enable;
                cmd.Parameters.Add("@rule", SqlDbType.Text).Value = fam.Rule;
                cmd.Parameters.Add("@Question", SqlDbType.Text).Value = fam.Question;

                cmd.Parameters.Add("@StartPosition", SqlDbType.Int).Value = fam.StartPosition;
                cmd.Parameters.Add("@EndPosition", SqlDbType.Int).Value = fam.EndPosition;

                cmd.Parameters.Add("@num", SqlDbType.Int).Value = fam.num;
                if (fam.StartD == null)
                {
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = fam.StartD;
                }

                if (fam.EndD == null)
                {
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = fam.EndD;
                }
                cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = fam.ModuleID;
                
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fam"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public override Int32 tsActivityInsertUpdateDelete(tsActivityEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsActivityInsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            //cmd.Parameters.Add("@CompID", SqlDbType.Int).Value = fam.CompID;  //厂商ID
            //cmd.Parameters.Add("@Game", SqlDbType.VarChar).Value = fam.Game;  //游戏
            //cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
            //cmd.Parameters.Add("@IsOnline", SqlDbType.Bit).Value = fam.IsOnline;  //运营状态

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }


        public override Int32 tsModuleInsertUpdateDelete(tsModuleEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsModule_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = fam.Title;
                cmd.Parameters.Add("@Description", SqlDbType.Text).Value = fam.Description;
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;
                cmd.Parameters.Add("@Sort", SqlDbType.Int).Value = fam.Sort;
                cmd.Parameters.Add("@enable", SqlDbType.Bit).Value = fam.Enable;
               
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsGame (游戏)
        /// </summary>
        /// <param name="fam">tsGameEntity实体类(游戏)</param>
        /// <param name="tran">tsGame事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsGameInsertUpdateDelete(tsGameEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsGame_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@CompID", SqlDbType.Int).Value = fam.CompID;  //厂商ID
            cmd.Parameters.Add("@Game", SqlDbType.VarChar).Value = fam.Game;  //游戏
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
            cmd.Parameters.Add("@IsOnline", SqlDbType.Bit).Value = fam.IsOnline;  //运营状态
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qp"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public override List<tsActivityEntity> tsActivityList(QueryParam qp, out int RecordCount)
        {
            return tsActivityList(qp, out RecordCount, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qp"></param>
        /// <param name="RecordCount"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public override List<tsActivityEntity> tsActivityList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tsActivityEntity> mypd = new PopulateDelegate<tsActivityEntity>(base.PopulatetsActivityEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }

        public override List<tsModuleEntity> tsModuleList(QueryParam qp, out int RecordCount)
        {
            return tsModuleList(qp, out RecordCount, null);
        }

        public override List<tsModuleEntity> tsModuleList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tsModuleEntity> mypd = new PopulateDelegate<tsModuleEntity>(base.PopulatetsModuleEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }


        public override DataTable tbDuihuanList(QueryParam qp, out int RecordCount)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_DuihuanList", qp.PageIndex, qp.PageSize,qp.Where,qp.Orderfld,qp.OrderType);
            }

            RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0][1]);

            return ds.Tables[0];
        }


        public override DataTable tbGiveList(QueryParam qp, out int RecordCount)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GiveList", qp.PageIndex, qp.PageSize, qp.Where, qp.Orderfld, qp.OrderType);
            }

            RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0][1]);

            return ds.Tables[0];
        }


        /// <summary>
        /// 返回tsGameEntity实体类的List对象 (游戏)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsGameEntity实体类的List对象(游戏)</returns>
        public override List<tsGameEntity> tsGameList(QueryParam qp, out int RecordCount)
        {
            return tsGameList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsGameEntity实体类的List对象 (游戏)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsGame事务</param>
        /// <returns>tsGameEntity实体类的List对象(游戏)</returns>
        public override List<tsGameEntity> tsGameList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsGameEntity> mypd = new PopulateDelegate<tsGameEntity>(base.PopulatetsGameEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsGroup (用户分组) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsGroup (用户分组)
        /// </summary>
        /// <param name="fam">tsGroupEntity实体类(用户分组)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsGroupInsertUpdateDelete(tsGroupEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsGroup_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = fam.Name;  //名称
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsGroup (用户分组)
        /// </summary>
        /// <param name="fam">tsGroupEntity实体类(用户分组)</param>
        /// <param name="tran">tsGroup事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsGroupInsertUpdateDelete(tsGroupEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsGroup_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = fam.Name;  //名称
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //CreateDate
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsGroupEntity实体类的List对象 (用户分组)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsGroupEntity实体类的List对象(用户分组)</returns>
        public override List<tsGroupEntity> tsGroupList(QueryParam qp, out int RecordCount)
        {
            return tsGroupList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsGroupEntity实体类的List对象 (用户分组)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsGroup事务</param>
        /// <returns>tsGroupEntity实体类的List对象(用户分组)</returns>
        public override List<tsGroupEntity> tsGroupList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsGroupEntity> mypd = new PopulateDelegate<tsGroupEntity>(base.PopulatetsGroupEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsMember (用户成员) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsMember (用户成员)
        /// </summary>
        /// <param name="fam">tsMemberEntity实体类(用户成员)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsMemberInsertUpdateDelete(tsMemberEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsMember_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = fam.GroupID;  //用户分组ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@MemberUserID", SqlDbType.Int).Value = fam.MemberUserID;  //成员用户
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsMember (用户成员)
        /// </summary>
        /// <param name="fam">tsMemberEntity实体类(用户成员)</param>
        /// <param name="tran">tsMember事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsMemberInsertUpdateDelete(tsMemberEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsMember_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = fam.GroupID;  //用户分组ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@MemberUserID", SqlDbType.Int).Value = fam.MemberUserID;  //成员用户
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsMemberEntity实体类的List对象 (用户成员)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsMemberEntity实体类的List对象(用户成员)</returns>
        public override List<tsMemberEntity> tsMemberList(QueryParam qp, out int RecordCount)
        {
            return tsMemberList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsMemberEntity实体类的List对象 (用户成员)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsMember事务</param>
        /// <returns>tsMemberEntity实体类的List对象(用户成员)</returns>
        public override List<tsMemberEntity> tsMemberList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsMemberEntity> mypd = new PopulateDelegate<tsMemberEntity>(base.PopulatetsMemberEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsMoney (余额) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsMoney (余额)
        /// </summary>
        /// <param name="fam">tsMoneyEntity实体类(余额)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsMoneyInsertUpdateDelete(tsMoneyEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsMoney_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@SumBal", SqlDbType.Money).Value = fam.SumBal;  //总金额
                cmd.Parameters.Add("@FreezeBal", SqlDbType.Money).Value = fam.FreezeBal;  //冻结资金
                cmd.Parameters.Add("@ChangeDate", SqlDbType.DateTime).Value = fam.ChangeDate;  //变动日期
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsMoney (余额)
        /// </summary>
        /// <param name="fam">tsMoneyEntity实体类(余额)</param>
        /// <param name="tran">tsMoney事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsMoneyInsertUpdateDelete(tsMoneyEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsMoney_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@SumBal", SqlDbType.Money).Value = fam.SumBal;  //总金额
            cmd.Parameters.Add("@FreezeBal", SqlDbType.Money).Value = fam.FreezeBal;  //冻结资金
            cmd.Parameters.Add("@ChangeDate", SqlDbType.DateTime).Value = fam.ChangeDate;  //变动日期
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsMoneyEntity实体类的List对象 (余额)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsMoneyEntity实体类的List对象(余额)</returns>
        public override List<tsMoneyEntity> tsMoneyList(QueryParam qp, out int RecordCount)
        {
            return tsMoneyList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsMoneyEntity实体类的List对象 (余额)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsMoney事务</param>
        /// <returns>tsMoneyEntity实体类的List对象(余额)</returns>
        public override List<tsMoneyEntity> tsMoneyList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsMoneyEntity> mypd = new PopulateDelegate<tsMoneyEntity>(base.PopulatetsMoneyEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsRightLock (权限锁定) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsRightLock (权限锁定)
        /// </summary>
        /// <param name="fam">tsRightLockEntity实体类(权限锁定)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsRightLockInsertUpdateDelete(tsRightLockEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsRightLock_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@LockType", SqlDbType.SmallInt).Value = fam.LockType;  //锁定类别
                cmd.Parameters.Add("@IsForever", SqlDbType.Bit).Value = fam.IsForever;  //是否永久
                if (fam.StartDate.HasValue)
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = fam.StartDate;  //开始日期
                else
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DBNull.Value;  //开始日期
                if (fam.EndDate.HasValue)
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = fam.EndDate;  //结束日期
                else
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;  //结束日期
                cmd.Parameters.Add("@Notice", SqlDbType.VarChar).Value = fam.Notice;  //通知内容
                if (fam.CreateDate.HasValue)
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
                else
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsRightLock (权限锁定)
        /// </summary>
        /// <param name="fam">tsRightLockEntity实体类(权限锁定)</param>
        /// <param name="tran">tsRightLock事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsRightLockInsertUpdateDelete(tsRightLockEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsRightLock_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@LockType", SqlDbType.SmallInt).Value = fam.LockType;  //锁定类别
            cmd.Parameters.Add("@IsForever", SqlDbType.Bit).Value = fam.IsForever;  //是否永久
            if (fam.StartDate.HasValue)
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = fam.StartDate;  //开始日期
            else
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DBNull.Value;  //开始日期
            if (fam.EndDate.HasValue)
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = fam.EndDate;  //结束日期
            else
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;  //结束日期
            cmd.Parameters.Add("@Notice", SqlDbType.VarChar).Value = fam.Notice;  //通知内容
            if (fam.CreateDate.HasValue)
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
            else
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsRightLockEntity实体类的List对象 (权限锁定)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsRightLockEntity实体类的List对象(权限锁定)</returns>
        public override List<tsRightLockEntity> tsRightLockList(QueryParam qp, out int RecordCount)
        {
            return tsRightLockList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsRightLockEntity实体类的List对象 (权限锁定)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsRightLock事务</param>
        /// <returns>tsRightLockEntity实体类的List对象(权限锁定)</returns>
        public override List<tsRightLockEntity> tsRightLockList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsRightLockEntity> mypd = new PopulateDelegate<tsRightLockEntity>(base.PopulatetsRightLockEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsSerialNo (流水号) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsSerialNo (流水号)
        /// </summary>
        /// <param name="fam">tsSerialNoEntity实体类(流水号)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsSerialNoInsertUpdateDelete(tsSerialNoEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsSerialNo_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@SType", SqlDbType.VarChar).Value = fam.SType;  //类别
                cmd.Parameters.Add("@Prefix", SqlDbType.VarChar).Value = fam.Prefix;  //前缀
                cmd.Parameters.Add("@Seed", SqlDbType.Int).Value = fam.Seed;  //种子
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsSerialNo (流水号)
        /// </summary>
        /// <param name="fam">tsSerialNoEntity实体类(流水号)</param>
        /// <param name="tran">tsSerialNo事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsSerialNoInsertUpdateDelete(tsSerialNoEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsSerialNo_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@SType", SqlDbType.VarChar).Value = fam.SType;  //类别
            cmd.Parameters.Add("@Prefix", SqlDbType.VarChar).Value = fam.Prefix;  //前缀
            cmd.Parameters.Add("@Seed", SqlDbType.Int).Value = fam.Seed;  //种子
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsSerialNoEntity实体类的List对象 (流水号)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsSerialNoEntity实体类的List对象(流水号)</returns>
        public override List<tsSerialNoEntity> tsSerialNoList(QueryParam qp, out int RecordCount)
        {
            return tsSerialNoList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsSerialNoEntity实体类的List对象 (流水号)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsSerialNo事务</param>
        /// <returns>tsSerialNoEntity实体类的List对象(流水号)</returns>
        public override List<tsSerialNoEntity> tsSerialNoList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsSerialNoEntity> mypd = new PopulateDelegate<tsSerialNoEntity>(base.PopulatetsSerialNoEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsServer (服务器) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsServer (服务器)
        /// </summary>
        /// <param name="fam">tsServerEntity实体类(服务器)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsServerInsertUpdateDelete(tsServerEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.act_Server_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ZoneID", SqlDbType.Int).Value = fam.ZoneID;  //大区ID
                cmd.Parameters.Add("@Server", SqlDbType.VarChar).Value = fam.Server;  //服务器
                cmd.Parameters.Add("@Sort", SqlDbType.Int).Value = fam.Sort;  //排序
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsServer (服务器)
        /// </summary>
        /// <param name="fam">tsServerEntity实体类(服务器)</param>
        /// <param name="tran">tsServer事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsServerInsertUpdateDelete(tsServerEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsServer_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@ZoneID", SqlDbType.Int).Value = fam.ZoneID;  //大区ID
            cmd.Parameters.Add("@Server", SqlDbType.VarChar).Value = fam.Server;  //服务器
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsServerEntity实体类的List对象 (服务器)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsServerEntity实体类的List对象(服务器)</returns>
        public override List<tsServerEntity> tsServerList(QueryParam qp, out int RecordCount)
        {
            return tsServerList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsServerEntity实体类的List对象 (服务器)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsServer事务</param>
        /// <returns>tsServerEntity实体类的List对象(服务器)</returns>
        public override List<tsServerEntity> tsServerList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsServerEntity> mypd = new PopulateDelegate<tsServerEntity>(base.PopulatetsServerEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsSMSPlat (短信平台) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsSMSPlat (短信平台)
        /// </summary>
        /// <param name="fam">tsSMSPlatEntity实体类(短信平台)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsSMSPlatInsertUpdateDelete(tsSMSPlatEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsSMSPlat_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@PlatName", SqlDbType.VarChar).Value = fam.PlatName;  //平台名称
                cmd.Parameters.Add("@PostUrl", SqlDbType.VarChar).Value = fam.PostUrl;  //提交地址
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = fam.UserName;  //用户名
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = fam.Password;  //密码
                cmd.Parameters.Add("@AppID", SqlDbType.VarChar).Value = fam.AppID;  //应用ID
                cmd.Parameters.Add("@SuccessKey", SqlDbType.VarChar).Value = fam.SuccessKey;  //成功关键字
                cmd.Parameters.Add("@SmsStyle", SqlDbType.SmallInt).Value = fam.SmsStyle;  //发送方式
                cmd.Parameters.Add("@IsEnable", SqlDbType.Bit).Value = fam.IsEnable;  //是否使用
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsSMSPlat (短信平台)
        /// </summary>
        /// <param name="fam">tsSMSPlatEntity实体类(短信平台)</param>
        /// <param name="tran">tsSMSPlat事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsSMSPlatInsertUpdateDelete(tsSMSPlatEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsSMSPlat_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@PlatName", SqlDbType.VarChar).Value = fam.PlatName;  //平台名称
            cmd.Parameters.Add("@PostUrl", SqlDbType.VarChar).Value = fam.PostUrl;  //提交地址
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = fam.UserName;  //用户名
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = fam.Password;  //密码
            cmd.Parameters.Add("@AppID", SqlDbType.VarChar).Value = fam.AppID;  //应用ID
            cmd.Parameters.Add("@SuccessKey", SqlDbType.VarChar).Value = fam.SuccessKey;  //成功关键字
            cmd.Parameters.Add("@SmsStyle", SqlDbType.SmallInt).Value = fam.SmsStyle;  //发送方式
            cmd.Parameters.Add("@IsEnable", SqlDbType.Bit).Value = fam.IsEnable;  //是否使用
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsSMSPlatEntity实体类的List对象 (短信平台)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsSMSPlatEntity实体类的List对象(短信平台)</returns>
        public override List<tsSMSPlatEntity> tsSMSPlatList(QueryParam qp, out int RecordCount)
        {
            return tsSMSPlatList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsSMSPlatEntity实体类的List对象 (短信平台)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsSMSPlat事务</param>
        /// <returns>tsSMSPlatEntity实体类的List对象(短信平台)</returns>
        public override List<tsSMSPlatEntity> tsSMSPlatList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsSMSPlatEntity> mypd = new PopulateDelegate<tsSMSPlatEntity>(base.PopulatetsSMSPlatEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsSubUser (子用户) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsSubUser (子用户)
        /// </summary>
        /// <param name="fam">tsSubUserEntity实体类(子用户)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsSubUserInsertUpdateDelete(tsSubUserEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsSubUser_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@LoginID", SqlDbType.VarChar).Value = fam.LoginID;  //登录ID
                cmd.Parameters.Add("@SubUserName", SqlDbType.VarChar).Value = fam.SubUserName;  //姓名
                cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = fam.Pass;  //登录密码
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //备注
                cmd.Parameters.Add("@Token", SqlDbType.VarChar).Value = fam.Token;  //令牌
                if (fam.LiveTime.HasValue)
                    cmd.Parameters.Add("@LiveTime", SqlDbType.DateTime).Value = fam.LiveTime;  //活动时间
                else
                    cmd.Parameters.Add("@LiveTime", SqlDbType.DateTime).Value = DBNull.Value;  //活动时间
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsSubUser (子用户)
        /// </summary>
        /// <param name="fam">tsSubUserEntity实体类(子用户)</param>
        /// <param name="tran">tsSubUser事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsSubUserInsertUpdateDelete(tsSubUserEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsSubUser_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@LoginID", SqlDbType.VarChar).Value = fam.LoginID;  //登录ID
            cmd.Parameters.Add("@SubUserName", SqlDbType.VarChar).Value = fam.SubUserName;  //姓名
            cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = fam.Pass;  //登录密码
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //备注
            cmd.Parameters.Add("@Token", SqlDbType.VarChar).Value = fam.Token;  //令牌
            if (fam.LiveTime.HasValue)
                cmd.Parameters.Add("@LiveTime", SqlDbType.DateTime).Value = fam.LiveTime;  //活动时间
            else
                cmd.Parameters.Add("@LiveTime", SqlDbType.DateTime).Value = DBNull.Value;  //活动时间
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsSubUserEntity实体类的List对象 (子用户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsSubUserEntity实体类的List对象(子用户)</returns>
        public override List<tsSubUserEntity> tsSubUserList(QueryParam qp, out int RecordCount)
        {
            return tsSubUserList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsSubUserEntity实体类的List对象 (子用户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsSubUser事务</param>
        /// <returns>tsSubUserEntity实体类的List对象(子用户)</returns>
        public override List<tsSubUserEntity> tsSubUserList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsSubUserEntity> mypd = new PopulateDelegate<tsSubUserEntity>(base.PopulatetsSubUserEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsSysParam (系统参数) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsSysParam (系统参数)
        /// </summary>
        /// <param name="fam">tsSysParamEntity实体类(系统参数)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsSysParamInsertUpdateDelete(tsSysParamEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsSysParam_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = fam.Name;  //名称
                cmd.Parameters.Add("@Value", SqlDbType.VarChar).Value = fam.Value;  //值
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsSysParam (系统参数)
        /// </summary>
        /// <param name="fam">tsSysParamEntity实体类(系统参数)</param>
        /// <param name="tran">tsSysParam事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsSysParamInsertUpdateDelete(tsSysParamEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsSysParam_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = fam.Name;  //名称
            cmd.Parameters.Add("@Value", SqlDbType.VarChar).Value = fam.Value;  //值
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //描述
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsSysParamEntity实体类的List对象 (系统参数)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsSysParamEntity实体类的List对象(系统参数)</returns>
        public override List<tsSysParamEntity> tsSysParamList(QueryParam qp, out int RecordCount)
        {
            return tsSysParamList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsSysParamEntity实体类的List对象 (系统参数)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsSysParam事务</param>
        /// <returns>tsSysParamEntity实体类的List对象(系统参数)</returns>
        public override List<tsSysParamEntity> tsSysParamList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsSysParamEntity> mypd = new PopulateDelegate<tsSysParamEntity>(base.PopulatetsSysParamEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsUser (用户) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsUser (用户)
        /// </summary>
        /// <param name="fam">tsUserEntity实体类(用户)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsUserInsertUpdateDelete(tsUserEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsUser_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UID", SqlDbType.VarChar).Value = fam.UID;  //字符串ID
                cmd.Parameters.Add("@Nickname", SqlDbType.VarChar).Value = fam.Nickname;  //昵称
                cmd.Parameters.Add("@LoginID", SqlDbType.VarChar).Value = fam.LoginID;  //登录ID
                cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = fam.Pass;  //登录密码
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = fam.Email;  //邮箱
                cmd.Parameters.Add("@QQ", SqlDbType.VarChar).Value = fam.QQ;  //联系QQ
                cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = fam.Mobile;  //联系电话
                cmd.Parameters.Add("@Question", SqlDbType.VarChar).Value = fam.Question;  //安全问题
                cmd.Parameters.Add("@Answer", SqlDbType.VarChar).Value = fam.Answer;  //安全答案
                cmd.Parameters.Add("@BindMobile", SqlDbType.VarChar).Value = fam.BindMobile;  //绑定手机
                cmd.Parameters.Add("@PayPass", SqlDbType.VarChar).Value = fam.PayPass;  //支付密码
                cmd.Parameters.Add("@LoginMode", SqlDbType.SmallInt).Value = fam.LoginMode;  //登录模式
                cmd.Parameters.Add("@IsOnline", SqlDbType.SmallInt).Value = fam.IsOnline;  //在线状态
                cmd.Parameters.Add("@HaveSubUser", SqlDbType.Bit).Value = fam.HaveSubUser;  //有子帐号
                cmd.Parameters.Add("@IconIndex", SqlDbType.Int).Value = fam.IconIndex;  //图标序号
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
                if (fam.LoginDate.HasValue)
                    cmd.Parameters.Add("@LoginDate", SqlDbType.DateTime).Value = fam.LoginDate;  //登录时间
                else
                    cmd.Parameters.Add("@LoginDate", SqlDbType.DateTime).Value = DBNull.Value;  //登录时间
                cmd.Parameters.Add("@Status", SqlDbType.SmallInt).Value = fam.Status;  //状态
                cmd.Parameters.Add("@Sign", SqlDbType.VarChar).Value = fam.Sign;  //签名
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //备注
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsUser (用户)
        /// </summary>
        /// <param name="fam">tsUserEntity实体类(用户)</param>
        /// <param name="tran">tsUser事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsUserInsertUpdateDelete(tsUserEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsUser_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UID", SqlDbType.VarChar).Value = fam.UID;  //字符串ID
            cmd.Parameters.Add("@Nickname", SqlDbType.VarChar).Value = fam.Nickname;  //昵称
            cmd.Parameters.Add("@LoginID", SqlDbType.VarChar).Value = fam.LoginID;  //登录ID
            cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = fam.Pass;  //登录密码
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = fam.Email;  //邮箱
            cmd.Parameters.Add("@QQ", SqlDbType.VarChar).Value = fam.QQ;  //联系QQ
            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = fam.Mobile;  //联系电话
            cmd.Parameters.Add("@Question", SqlDbType.VarChar).Value = fam.Question;  //安全问题
            cmd.Parameters.Add("@Answer", SqlDbType.VarChar).Value = fam.Answer;  //安全答案
            cmd.Parameters.Add("@BindMobile", SqlDbType.VarChar).Value = fam.BindMobile;  //绑定手机
            cmd.Parameters.Add("@PayPass", SqlDbType.VarChar).Value = fam.PayPass;  //支付密码
            cmd.Parameters.Add("@LoginMode", SqlDbType.SmallInt).Value = fam.LoginMode;  //登录模式
            cmd.Parameters.Add("@IsOnline", SqlDbType.SmallInt).Value = fam.IsOnline;  //在线状态
            cmd.Parameters.Add("@HaveSubUser", SqlDbType.Bit).Value = fam.HaveSubUser;  //有子帐号
            cmd.Parameters.Add("@IconIndex", SqlDbType.Int).Value = fam.IconIndex;  //图标序号
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
            if (fam.LoginDate.HasValue)
                cmd.Parameters.Add("@LoginDate", SqlDbType.DateTime).Value = fam.LoginDate;  //登录时间
            else
                cmd.Parameters.Add("@LoginDate", SqlDbType.DateTime).Value = DBNull.Value;  //登录时间
            cmd.Parameters.Add("@Status", SqlDbType.SmallInt).Value = fam.Status;  //状态
            cmd.Parameters.Add("@Sign", SqlDbType.VarChar).Value = fam.Sign;  //签名
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //备注
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsUserEntity实体类的List对象 (用户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsUserEntity实体类的List对象(用户)</returns>
        public override List<tsUserEntity> tsUserList(QueryParam qp, out int RecordCount)
        {
            return tsUserList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsUserEntity实体类的List对象 (用户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsUser事务</param>
        /// <returns>tsUserEntity实体类的List对象(用户)</returns>
        public override List<tsUserEntity> tsUserList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsUserEntity> mypd = new PopulateDelegate<tsUserEntity>(base.PopulatetsUserEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsUserToken (授权令牌) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsUserToken (授权令牌)
        /// </summary>
        /// <param name="fam">tsUserTokenEntity实体类(授权令牌)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsUserTokenInsertUpdateDelete(tsUserTokenEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsUserToken_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
                cmd.Parameters.Add("@Token", SqlDbType.VarChar).Value = fam.Token;  //令牌
                if (fam.LiveTime.HasValue)
                    cmd.Parameters.Add("@LiveTime", SqlDbType.DateTime).Value = fam.LiveTime;  //活动时间
                else
                    cmd.Parameters.Add("@LiveTime", SqlDbType.DateTime).Value = DBNull.Value;  //活动时间
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsUserToken (授权令牌)
        /// </summary>
        /// <param name="fam">tsUserTokenEntity实体类(授权令牌)</param>
        /// <param name="tran">tsUserToken事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsUserTokenInsertUpdateDelete(tsUserTokenEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsUserToken_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //用户ID
            cmd.Parameters.Add("@Token", SqlDbType.VarChar).Value = fam.Token;  //令牌
            if (fam.LiveTime.HasValue)
                cmd.Parameters.Add("@LiveTime", SqlDbType.DateTime).Value = fam.LiveTime;  //活动时间
            else
                cmd.Parameters.Add("@LiveTime", SqlDbType.DateTime).Value = DBNull.Value;  //活动时间
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsUserTokenEntity实体类的List对象 (授权令牌)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsUserTokenEntity实体类的List对象(授权令牌)</returns>
        public override List<tsUserTokenEntity> tsUserTokenList(QueryParam qp, out int RecordCount)
        {
            return tsUserTokenList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsUserTokenEntity实体类的List对象 (授权令牌)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsUserToken事务</param>
        /// <returns>tsUserTokenEntity实体类的List对象(授权令牌)</returns>
        public override List<tsUserTokenEntity> tsUserTokenList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsUserTokenEntity> mypd = new PopulateDelegate<tsUserTokenEntity>(base.PopulatetsUserTokenEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsZone (大区) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsZone (大区)
        /// </summary>
        /// <param name="fam">tsZoneEntity实体类(大区)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsZoneInsertUpdateDelete(tsZoneEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.act_Zone_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@GameID", SqlDbType.Int).Value = fam.GameID;  //游戏ID
                cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = fam.Zone;  //大区
                cmd.Parameters.Add("@Sort", SqlDbType.Int).Value = fam.Sort;  //排序
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsZone (大区)
        /// </summary>
        /// <param name="fam">tsZoneEntity实体类(大区)</param>
        /// <param name="tran">tsZone事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsZoneInsertUpdateDelete(tsZoneEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsZone_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@GameID", SqlDbType.Int).Value = fam.GameID;  //游戏ID
            cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = fam.Zone;  //大区
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsZoneEntity实体类的List对象 (大区)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsZoneEntity实体类的List对象(大区)</returns>
        public override List<tsZoneEntity> tsZoneList(QueryParam qp, out int RecordCount)
        {
            return tsZoneList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsZoneEntity实体类的List对象 (大区)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsZone事务</param>
        /// <returns>tsZoneEntity实体类的List对象(大区)</returns>
        public override List<tsZoneEntity> tsZoneList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsZoneEntity> mypd = new PopulateDelegate<tsZoneEntity>(base.PopulatetsZoneEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "tsZoneServer (区服汇总) - SQLDataProvider"
 
        /// <summary>
        /// 新增/删除/修改 tsZoneServer (区服汇总)
        /// </summary>
        /// <param name="fam">tsZoneServerEntity实体类(区服汇总)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsZoneServerInsertUpdateDelete(tsZoneServerEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tsZoneServer_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = fam.Code;  //编码
                cmd.Parameters.Add("@GameID", SqlDbType.Int).Value = fam.GameID;  //游戏ID
                cmd.Parameters.Add("@Game", SqlDbType.VarChar).Value = fam.Game;  //游戏
                cmd.Parameters.Add("@ZoneID", SqlDbType.Int).Value = fam.ZoneID;  //大区ID
                cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = fam.Zone;  //大区
                cmd.Parameters.Add("@ServerID", SqlDbType.Int).Value = fam.ServerID;  //服务器ID
                cmd.Parameters.Add("@Server", SqlDbType.VarChar).Value = fam.Server;  //服务器
                cmd.Parameters.Add("@FactionID", SqlDbType.Int).Value = fam.FactionID;  //阵营ID
                cmd.Parameters.Add("@Faction", SqlDbType.VarChar).Value = fam.Faction;  //阵营
                cmd.Parameters.Add("@SpellFull", SqlDbType.VarChar).Value = fam.SpellFull;  //拼音全称
                cmd.Parameters.Add("@SpellShort", SqlDbType.VarChar).Value = fam.SpellShort;  //拼音简称
                cmd.Parameters.Add("@IsOnline", SqlDbType.Bit).Value = fam.IsOnline;  //运营状态
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsZoneServer (区服汇总)
        /// </summary>
        /// <param name="fam">tsZoneServerEntity实体类(区服汇总)</param>
        /// <param name="tran">tsZoneServer事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tsZoneServerInsertUpdateDelete(tsZoneServerEntity fam,DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tsZoneServer_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = fam.Code;  //编码
            cmd.Parameters.Add("@GameID", SqlDbType.Int).Value = fam.GameID;  //游戏ID
            cmd.Parameters.Add("@Game", SqlDbType.VarChar).Value = fam.Game;  //游戏
            cmd.Parameters.Add("@ZoneID", SqlDbType.Int).Value = fam.ZoneID;  //大区ID
            cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = fam.Zone;  //大区
            cmd.Parameters.Add("@ServerID", SqlDbType.Int).Value = fam.ServerID;  //服务器ID
            cmd.Parameters.Add("@Server", SqlDbType.VarChar).Value = fam.Server;  //服务器
            cmd.Parameters.Add("@FactionID", SqlDbType.Int).Value = fam.FactionID;  //阵营ID
            cmd.Parameters.Add("@Faction", SqlDbType.VarChar).Value = fam.Faction;  //阵营
            cmd.Parameters.Add("@SpellFull", SqlDbType.VarChar).Value = fam.SpellFull;  //拼音全称
            cmd.Parameters.Add("@SpellShort", SqlDbType.VarChar).Value = fam.SpellShort;  //拼音简称
            cmd.Parameters.Add("@IsOnline", SqlDbType.Bit).Value = fam.IsOnline;  //运营状态
            
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }        



        /// <summary>
        /// 返回tsZoneServerEntity实体类的List对象 (区服汇总)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsZoneServerEntity实体类的List对象(区服汇总)</returns>
        public override List<tsZoneServerEntity> tsZoneServerList(QueryParam qp, out int RecordCount)
        {
            return tsZoneServerList(qp, out RecordCount,null);
        }


        /// <summary>
        /// 返回tsZoneServerEntity实体类的List对象 (区服汇总)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsZoneServer事务</param>
        /// <returns>tsZoneServerEntity实体类的List对象(区服汇总)</returns>
        public override List<tsZoneServerEntity> tsZoneServerList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            PopulateDelegate<tsZoneServerEntity> mypd = new PopulateDelegate<tsZoneServerEntity>(base.PopulatetsZoneServerEntity);
            if (tran==null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount,tran);   
            }
        }
        #endregion

        #region "记录首次打开订单详情"
        /// <summary>
        /// 记录首次打开订单详情
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="IsLock"></param>
        /// <returns></returns>
        public override DataSet MarkFirstViewOrder(string SerialNo, int OPID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_MarkFirstViewOrder", SerialNo, OPID);
            }
            return ds;
        }
        #endregion


        #region "sys_Comment (sys_Comment) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 sys_Comment (sys_Comment)
        /// </summary>
        /// <param name="fam">sys_CommentEntity实体类(sys_Comment)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 sys_CommentInsertUpdateDelete(sys_CommentEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.sys_Comment_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@C_CommentID", SqlDbType.Int).Value = fam.C_CommentID;  //C_CommentID
                cmd.Parameters.Add("@C_NewsID", SqlDbType.Int).Value = fam.C_NewsID;  //C_NewsID
                cmd.Parameters.Add("@C_PostID", SqlDbType.Int).Value = fam.C_PostID;  //C_PostID
                cmd.Parameters.Add("@C_Content", SqlDbType.NText).Value = fam.C_Content;  //C_Content
                cmd.Parameters.Add("@C_Remarks", SqlDbType.NVarChar).Value = fam.C_Remarks;  //C_Remarks
                cmd.Parameters.Add("@C_CreateDate", SqlDbType.DateTime).Value = fam.C_CreateDate;  //C_CreateDate
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 sys_Comment (sys_Comment)
        /// </summary>
        /// <param name="fam">sys_CommentEntity实体类(sys_Comment)</param>
        /// <param name="tran">sys_Comment事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 sys_CommentInsertUpdateDelete(sys_CommentEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.sys_Comment_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@C_CommentID", SqlDbType.Int).Value = fam.C_CommentID;  //C_CommentID
            cmd.Parameters.Add("@C_NewsID", SqlDbType.Int).Value = fam.C_NewsID;  //C_NewsID
            cmd.Parameters.Add("@C_PostID", SqlDbType.Int).Value = fam.C_PostID;  //C_PostID
            cmd.Parameters.Add("@C_Content", SqlDbType.NText).Value = fam.C_Content;  //C_Content
            cmd.Parameters.Add("@C_Remarks", SqlDbType.NVarChar).Value = fam.C_Remarks;  //C_Remarks
            cmd.Parameters.Add("@C_CreateDate", SqlDbType.DateTime).Value = fam.C_CreateDate;  //C_CreateDate
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回sys_CommentEntity实体类的List对象 (sys_Comment)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_CommentEntity实体类的List对象(sys_Comment)</returns>
        public override List<sys_CommentEntity> sys_CommentList(QueryParam qp, out int RecordCount)
        {
            return sys_CommentList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回sys_CommentEntity实体类的List对象 (sys_Comment)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">sys_Comment事务</param>
        /// <returns>sys_CommentEntity实体类的List对象(sys_Comment)</returns>
        public override List<sys_CommentEntity> sys_CommentList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<sys_CommentEntity> mypd = new PopulateDelegate<sys_CommentEntity>(base.Populatesys_CommentEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "sys_News (sys_News) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 sys_News (sys_News)
        /// </summary>
        /// <param name="fam">sys_NewsEntity实体类(sys_News)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 sys_NewsInsertUpdateDelete(sys_NewsEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.sys_News_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@N_ID", SqlDbType.Int).Value = fam.N_ID;  //N_ID
                cmd.Parameters.Add("@N_TypeID", SqlDbType.Int).Value = fam.N_TypeID;  //N_TypeID
                cmd.Parameters.Add("@N_Title", SqlDbType.NVarChar).Value = fam.N_Title;  //N_Title
                cmd.Parameters.Add("@N_Author", SqlDbType.NVarChar).Value = fam.N_Author;  //N_Author
                if (fam.N_CreateDate.HasValue)
                    cmd.Parameters.Add("@N_CreateDate", SqlDbType.DateTime).Value = fam.N_CreateDate;  //N_CreateDate
                else
                    cmd.Parameters.Add("@N_CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //N_CreateDate
                cmd.Parameters.Add("@N_Click", SqlDbType.Int).Value = fam.N_Click;  //N_Click
                cmd.Parameters.Add("@N_Content", SqlDbType.NText).Value = fam.N_Content;  //N_Content
                cmd.Parameters.Add("@N_Remarks", SqlDbType.NVarChar).Value = fam.N_Remarks;  //N_Remarks
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 sys_News (sys_News)
        /// </summary>
        /// <param name="fam">sys_NewsEntity实体类(sys_News)</param>
        /// <param name="tran">sys_News事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 sys_NewsInsertUpdateDelete(sys_NewsEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.sys_News_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@N_ID", SqlDbType.Int).Value = fam.N_ID;  //N_ID
            cmd.Parameters.Add("@N_TypeID", SqlDbType.Int).Value = fam.N_TypeID;  //N_TypeID
            cmd.Parameters.Add("@N_Title", SqlDbType.NVarChar).Value = fam.N_Title;  //N_Title
            cmd.Parameters.Add("@N_Author", SqlDbType.NVarChar).Value = fam.N_Author;  //N_Author
            if (fam.N_CreateDate.HasValue)
                cmd.Parameters.Add("@N_CreateDate", SqlDbType.DateTime).Value = fam.N_CreateDate;  //N_CreateDate
            else
                cmd.Parameters.Add("@N_CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //N_CreateDate
            cmd.Parameters.Add("@N_Click", SqlDbType.Int).Value = fam.N_Click;  //N_Click
            cmd.Parameters.Add("@N_Content", SqlDbType.NText).Value = fam.N_Content;  //N_Content
            cmd.Parameters.Add("@N_Remarks", SqlDbType.NVarChar).Value = fam.N_Remarks;  //N_Remarks

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回sys_NewsEntity实体类的List对象 (sys_News)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_NewsEntity实体类的List对象(sys_News)</returns>
        public override List<sys_NewsEntity> sys_NewsList(QueryParam qp, out int RecordCount)
        {
            return sys_NewsList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回sys_NewsEntity实体类的List对象 (sys_News)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">sys_News事务</param>
        /// <returns>sys_NewsEntity实体类的List对象(sys_News)</returns>
        public override List<sys_NewsEntity> sys_NewsList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<sys_NewsEntity> mypd = new PopulateDelegate<sys_NewsEntity>(base.Populatesys_NewsEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "sys_PendingMatters (sys_PendingMatters) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 sys_PendingMatters (sys_PendingMatters)
        /// </summary>
        /// <param name="fam">sys_PendingMattersEntity实体类(sys_PendingMatters)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 sys_PendingMattersInsertUpdateDelete(sys_PendingMattersEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.sys_PendingMatters_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@P_ID", SqlDbType.Int).Value = fam.P_ID;  //P_ID
                cmd.Parameters.Add("@P_Type", SqlDbType.Int).Value = fam.P_Type;  //P_Type
                cmd.Parameters.Add("@P_UserID", SqlDbType.NVarChar).Value = fam.P_UserID;  //P_UserID
                cmd.Parameters.Add("@P_Contact", SqlDbType.NVarChar).Value = fam.P_Contact;  //P_Contact
                cmd.Parameters.Add("@P_OrderNum", SqlDbType.NVarChar).Value = fam.P_OrderNum;  //P_OrderNum
                cmd.Parameters.Add("@P_CreateDate", SqlDbType.DateTime).Value = fam.P_CreateDate;  //P_CreateDate
                if (fam.P_ReplyDate.HasValue)
                    cmd.Parameters.Add("@P_ReplyDate", SqlDbType.DateTime).Value = fam.P_ReplyDate;  //P_ReplyDate
                else
                    cmd.Parameters.Add("@P_ReplyDate", SqlDbType.DateTime).Value = DBNull.Value;  //P_ReplyDate
                cmd.Parameters.Add("@P_Content", SqlDbType.NText).Value = fam.P_Content;  //P_Content
                cmd.Parameters.Add("@P_PostID", SqlDbType.Int).Value = fam.P_PostID;  //P_PostID
                cmd.Parameters.Add("@P_ReplyID", SqlDbType.Int).Value = fam.P_ReplyID;  //P_ReplyID
                cmd.Parameters.Add("@P_ReContent", SqlDbType.NText).Value = fam.P_ReContent;  //P_ReContent
                cmd.Parameters.Add("@P_IsDeal", SqlDbType.Int).Value = fam.P_IsDeal;  //P_IsDeal
                cmd.Parameters.Add("@P_Pre1", SqlDbType.Int).Value = fam.P_Pre1;  //P_Pre1
                cmd.Parameters.Add("@P_Pre2", SqlDbType.NVarChar).Value = fam.P_Pre2;  //P_Pre2
                if (fam.P_Pre3.HasValue)
                    cmd.Parameters.Add("@P_Pre3", SqlDbType.DateTime).Value = fam.P_Pre3;  //P_Pre3
                else
                    cmd.Parameters.Add("@P_Pre3", SqlDbType.DateTime).Value = DBNull.Value;  //P_Pre3
                cmd.Parameters.Add("@P_Pre4", SqlDbType.NText).Value = fam.P_Pre4;  //P_Pre4
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 sys_PendingMatters (sys_PendingMatters)
        /// </summary>
        /// <param name="fam">sys_PendingMattersEntity实体类(sys_PendingMatters)</param>
        /// <param name="tran">sys_PendingMatters事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 sys_PendingMattersInsertUpdateDelete(sys_PendingMattersEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.sys_PendingMatters_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@P_ID", SqlDbType.Int).Value = fam.P_ID;  //P_ID
            cmd.Parameters.Add("@P_Type", SqlDbType.Int).Value = fam.P_Type;  //P_Type
            cmd.Parameters.Add("@P_UserID", SqlDbType.NVarChar).Value = fam.P_UserID;  //P_UserID
            cmd.Parameters.Add("@P_Contact", SqlDbType.NVarChar).Value = fam.P_Contact;  //P_Contact
            cmd.Parameters.Add("@P_OrderNum", SqlDbType.NVarChar).Value = fam.P_OrderNum;  //P_OrderNum
            cmd.Parameters.Add("@P_CreateDate", SqlDbType.DateTime).Value = fam.P_CreateDate;  //P_CreateDate
            if (fam.P_ReplyDate.HasValue)
                cmd.Parameters.Add("@P_ReplyDate", SqlDbType.DateTime).Value = fam.P_ReplyDate;  //P_ReplyDate
            else
                cmd.Parameters.Add("@P_ReplyDate", SqlDbType.DateTime).Value = DBNull.Value;  //P_ReplyDate
            cmd.Parameters.Add("@P_Content", SqlDbType.NText).Value = fam.P_Content;  //P_Content
            cmd.Parameters.Add("@P_PostID", SqlDbType.Int).Value = fam.P_PostID;  //P_PostID
            cmd.Parameters.Add("@P_ReplyID", SqlDbType.Int).Value = fam.P_ReplyID;  //P_ReplyID
            cmd.Parameters.Add("@P_ReContent", SqlDbType.NText).Value = fam.P_ReContent;  //P_ReContent
            cmd.Parameters.Add("@P_IsDeal", SqlDbType.Int).Value = fam.P_IsDeal;  //P_IsDeal
            cmd.Parameters.Add("@P_Pre1", SqlDbType.Int).Value = fam.P_Pre1;  //P_Pre1
            cmd.Parameters.Add("@P_Pre2", SqlDbType.NVarChar).Value = fam.P_Pre2;  //P_Pre2
            if (fam.P_Pre3.HasValue)
                cmd.Parameters.Add("@P_Pre3", SqlDbType.DateTime).Value = fam.P_Pre3;  //P_Pre3
            else
                cmd.Parameters.Add("@P_Pre3", SqlDbType.DateTime).Value = DBNull.Value;  //P_Pre3
            cmd.Parameters.Add("@P_Pre4", SqlDbType.NText).Value = fam.P_Pre4;  //P_Pre4

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回sys_PendingMattersEntity实体类的List对象 (sys_PendingMatters)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_PendingMattersEntity实体类的List对象(sys_PendingMatters)</returns>
        public override List<sys_PendingMattersEntity> sys_PendingMattersList(QueryParam qp, out int RecordCount)
        {
            return sys_PendingMattersList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回sys_PendingMattersEntity实体类的List对象 (sys_PendingMatters)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">sys_PendingMatters事务</param>
        /// <returns>sys_PendingMattersEntity实体类的List对象(sys_PendingMatters)</returns>
        public override List<sys_PendingMattersEntity> sys_PendingMattersList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<sys_PendingMattersEntity> mypd = new PopulateDelegate<sys_PendingMattersEntity>(base.Populatesys_PendingMattersEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbChatMessage (tbChatMessage) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tbChatMessage (tbChatMessage)
        /// </summary>
        /// <param name="fam">tbChatMessageEntity实体类(tbChatMessage)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbChatMessageInsertUpdateDelete(tbChatMessageEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbChatMessage_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //UserID
                cmd.Parameters.Add("@UID", SqlDbType.VarChar).Value = fam.UID;  //UID
                cmd.Parameters.Add("@NickName", SqlDbType.VarChar).Value = fam.NickName;  //NickName
                cmd.Parameters.Add("@IconIndex", SqlDbType.Int).Value = fam.IconIndex;  //IconIndex
                cmd.Parameters.Add("@ChatType", SqlDbType.Int).Value = fam.ChatType;  //ChatType
                cmd.Parameters.Add("@TargetID", SqlDbType.NChar).Value = fam.TargetID;  //TargetID
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
                if (fam.BeginTime.HasValue)
                    cmd.Parameters.Add("@BeginTime", SqlDbType.DateTime).Value = fam.BeginTime;  //BeginTime
                else
                    cmd.Parameters.Add("@BeginTime", SqlDbType.DateTime).Value = DBNull.Value;  //BeginTime
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbChatMessage (tbChatMessage)
        /// </summary>
        /// <param name="fam">tbChatMessageEntity实体类(tbChatMessage)</param>
        /// <param name="tran">tbChatMessage事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbChatMessageInsertUpdateDelete(tbChatMessageEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbChatMessage_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //UserID
            cmd.Parameters.Add("@UID", SqlDbType.VarChar).Value = fam.UID;  //UID
            cmd.Parameters.Add("@NickName", SqlDbType.VarChar).Value = fam.NickName;  //NickName
            cmd.Parameters.Add("@IconIndex", SqlDbType.Int).Value = fam.IconIndex;  //IconIndex
            cmd.Parameters.Add("@ChatType", SqlDbType.Int).Value = fam.ChatType;  //ChatType
            cmd.Parameters.Add("@TargetID", SqlDbType.NChar).Value = fam.TargetID;  //TargetID
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
            if (fam.BeginTime.HasValue)
                cmd.Parameters.Add("@BeginTime", SqlDbType.DateTime).Value = fam.BeginTime;  //BeginTime
            else
                cmd.Parameters.Add("@BeginTime", SqlDbType.DateTime).Value = DBNull.Value;  //BeginTime

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回tbChatMessageEntity实体类的List对象 (tbChatMessage)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbChatMessageEntity实体类的List对象(tbChatMessage)</returns>
        public override List<tbChatMessageEntity> tbChatMessageList(QueryParam qp, out int RecordCount)
        {
            return tbChatMessageList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tbChatMessageEntity实体类的List对象 (tbChatMessage)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbChatMessage事务</param>
        /// <returns>tbChatMessageEntity实体类的List对象(tbChatMessage)</returns>
        public override List<tbChatMessageEntity> tbChatMessageList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbChatMessageEntity> mypd = new PopulateDelegate<tbChatMessageEntity>(base.PopulatetbChatMessageEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbVirtualWallet (tbVirtualWallet) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tbVirtualWallet (tbVirtualWallet)
        /// </summary>
        /// <param name="fam">tbVirtualWalletEntity实体类(tbVirtualWallet)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbVirtualWalletInsertUpdateDelete(tbVirtualWalletEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbVirtualWallet_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@OPID", SqlDbType.Int).Value = fam.OPID;  //OPID
                cmd.Parameters.Add("@MONEY", SqlDbType.Money).Value = fam.MONEY;  //MONEY
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 返回tbVirtualWalletEntity实体类的List对象 (tbVirtualWallet)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbVirtualWalletEntity实体类的List对象(tbVirtualWallet)</returns>
        public override List<tbVirtualWalletEntity> tbVirtualWalletList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<tbVirtualWalletEntity> mypd = new PopulateDelegate<tbVirtualWalletEntity>(base.PopulatetbVirtualWalletEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }
        #endregion

        #region "tbMobileToken(验证码查询) - Method"
        /// <summary>
        /// 取手机令牌
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public override DataSet GetMobileToken(int PageIndex, int PageSize,string Where)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_MobileToken", PageIndex, PageSize,Where);
            }
            return ds;
        }
        #endregion

        #region "tsRightLock(权限锁定查询) - Method"
        /// <summary>
        /// 取手机令牌
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public override DataSet RightLockList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_RightLock", PageIndex, PageSize, Where);
            }
            return ds;
        }
        #endregion


        #region "tbRecharge(充值流水查询) - Method"
        /// <summary>
        /// 取手机令牌
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public override DataSet GetRecharge(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "HT_RechargeList", PageIndex, PageSize, Where);
            }
            return ds;
        }
        #endregion


        #region "WithdrawDeposit(提现汇款查询) - Method"
        /// <summary>
        /// 提现汇款查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override DataSet WithdrawDeposit(int PageIndex, int PageSize, string Where, int type,int order,int isGood)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "HT_WithdrawDeposit", PageIndex, PageSize, Where, type, order, isGood);
            }
            return ds;
        }
        #endregion


        public override DataSet LevelOrderJudgListByID(int PageIndex, int PageSize, string Where, string type)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LevelOrderJudgListByID", PageIndex, PageSize, Where, type);
            }
            return ds;
        }

        public override DataSet LevelOrderJudgList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LevelOrderJudgList", PageIndex, PageSize, Where);
            }
            return ds;
        }

        public override DataSet LevelOrderJudgCount(string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LevelOrderJudgCount", SerialNo);
            }
            return ds;
        }

        public override DataSet OrderTitle(string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_OrderTitle", SerialNo);
            }
            return ds;
        }

        public override DataSet LevelOrderMyJudgStatus(string SerialNo,int CustomerID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LevelOrderMyJudgStatus", SerialNo, CustomerID);
            }
            return ds;
        }

        #region "IsLockWithDraw(用户是否禁止提现) - Method"
        /// <summary>
        /// 提现汇款查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override DataSet IsLockWithDraw(string uid)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_IsLockWithDraw", uid);
            }
            return ds;
        }
        #endregion

        #region "WithdrawDeposit(提现汇款查询) - Method"
        /// <summary>
        /// 提现汇款查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override DataSet GetWithdrawDeposit(string SerialNo,string OPID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetWithdrawDeposit", SerialNo, OPID);
            }
            return ds;
        }
        #endregion

        #region "WithdrawDeposit(解锁) - Method"
        /// <summary>
        /// 提现汇款查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override DataSet LockWithDraw(string SerialNo, int LockType, string OPID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "Comm_LockWithDraw", SerialNo, LockType, OPID);
            }
            return ds;
        }
        #endregion


        #region "BankTransferDetailList(网银汇款查询) - Method"
        /// <summary>
        /// 提现汇款查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override DataSet BankTransferDetailList(DateTime StartDate, DateTime EndDate, string Keyword, string SearchText, string Result, int PageIndex, int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetNetBankList", StartDate, EndDate, Keyword, SearchText, Result, PageIndex, PageSize);
            }
            return ds;
        }
        #endregion

        #region "OperateList(用户操作日志) - Method"
        /// <summary>
        /// 提现汇款查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override DataSet OperateList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "HT_OperateList", PageIndex, PageSize, Where);
            }
            return ds;
        }
        #endregion

        public override DataSet ChatMessageList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_ChatMessageList", PageIndex, PageSize, Where);
            }
            return ds;
        }


        #region "UserList(用户操作日志) - Method"
        /// <summary>
        /// 提现汇款查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override DataSet UserList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserList", PageIndex, PageSize, Where);
            }
            return ds;
        }
        #endregion

        public override DataSet UserListByMAC(string ID, int PageIndex, int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserListByMAC", ID, PageIndex, PageSize);
            }
            return ds;
        }

        public override DataSet UserListByHD(string ID, int PageIndex, int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserListByHD", ID, PageIndex, PageSize);
            }
            return ds;
        }

        public override DataSet UserListByMAC1(string MAC, int PageIndex, int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserListByMAC1", MAC, PageIndex, PageSize);
            }
            return ds;
        }

        public override DataSet UserAnalysisList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserAnalysisList", PageIndex, PageSize, Where);
            }
            return ds;
        }


        #region "设置用户权限 - Method"
        /// <summary>
        /// 提现汇款查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override DataSet SetUserLock(int ID, int LockType, DateTime StartDate, DateTime EndDate, string Notice, int ActivityID, string Condition, int OnOff, int ModuleID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_SetUserLock", ID, LockType, StartDate, EndDate, Notice, ActivityID, Condition, OnOff, ModuleID);
            }
            return ds;
        }

        public override DataSet SetUserLock(int ID, int LockType, DateTime StartDate, DateTime EndDate, string Notice, int ActivityID, string Condition, int OnOff)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_SetUserLock", ID, LockType, StartDate, EndDate, Notice, ActivityID, Condition, OnOff);
            }
            return ds;
        }
        #endregion

        #region "LoginList(用户登录日志) - Method"
        /// <summary>
        /// 提现汇款查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override DataSet LoginList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LoginList", PageIndex, PageSize, Where);
            }
            return ds;
        }
        #endregion

        public override DataSet PendingMattersList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_PendingMattersList", PageIndex, PageSize, Where);
            }
            return ds;
        }

        public override int DeleteUserTrack(string SerialNo)
        {
            int result = 0;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_DeleteUserTrack", SerialNo);
            }
            return result;
        }

        public override int AddLevelOrderProgress(string UserID, string SerialNo, string Msg, string Img)
        {
            int result = 0;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_AddLevelOrderProgress", UserID, SerialNo, Msg, Img);
            }
            return result;
        }

        public override int DeleteLevelOrderProgress(int ID)
        {
            int result = 0;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_DeleteLevelOrderProgress", ID);
            }
            return result;
        }

        public override DataSet UserOrderList(DateTime Start, DateTime End, string OPID,int PageIndex,int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserOrderList", Start, End, OPID,PageIndex,PageSize);
            }
            return ds;
        }

        public override DataSet UserReport(QueryParam qp, string where1)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserReport", qp.Where, where1, qp.PageIndex, qp.PageSize, qp.Orderfld, qp.OrderType);
            }
            return ds;
        }


        public override void UserMoneyChange(int UserID, int ChangeType, decimal ChangeBal, string RelaSerialNo,string Comment)
        {
            using (SqlConnection Conn = GetSqlConnection())
            {
               SqlHelper.ExecuteScalar(Conn.ConnectionString, "Comm_UserMoneyChange", UserID, ChangeType, ChangeBal,RelaSerialNo,Comment);
            }
        }


        public override DataSet UserMoneyChangeJudge(int UserID, decimal ChangeBal)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserMoneyChangeJudge", UserID, ChangeBal);
            }
            return ds;
        }

        public override DataSet ServiceMaxPrice(string OPID, int Type, decimal ChangeBal)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_ServiceMaxPrice", OPID, Type,ChangeBal);
            }
            return ds;
        }

        #region "订单管理"
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <param name="Keyword"></param>
        /// <param name="SearchText"></param>
        /// <param name="Status"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public override DataSet OrderSelect(DateTime sDate, DateTime eDate, string Keyword, string SearchText, string Status, string CancelStatus, bool IsHisOrder, int PageIndex, int PageSize, string OrderSelect, string Game, string AppointUser,string IsPub)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_Order", sDate, eDate, Keyword, SearchText, Status, CancelStatus, IsHisOrder, PageIndex, PageSize, OrderSelect, Game, AppointUser, IsPub);
            }
            return ds;
        }
        #endregion


        public override DataSet ActivityOrderSelect(int PageIndex, int PageSize, string ActivityID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_ActivityOrderSelect", PageIndex, PageSize, ActivityID);
            }
            return ds;
        }

        public override DataSet ActivityAllOrderSelect(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_ActivityAllOrderSelect", PageIndex, PageSize, Where);
            }
            return ds;
        }

        public override DataSet ActivityOrderSelectDel(int PageIndex, int PageSize, string ActivityID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_ActivityOrderSelectDel", PageIndex, PageSize, ActivityID);
            }
            return ds;
        }

        public override DataSet OrderGroup(DateTime sDate, DateTime eDate, string FirstCustomerID, string SearchType, int PageIndex, int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_OrderGroup", sDate, eDate, FirstCustomerID, SearchType, PageIndex, PageSize);
            }
            return ds;
        }

        public override DataSet NewAcceptJRCount(int Max, DateTime StartDate, DateTime EndDate, int PageIndex, int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_NewAcceptJRCount", Max, StartDate, EndDate, PageIndex, PageSize);
            }
            return ds;
        }


        public override DataSet UserGLCount(string GameID, string Min, string Max, DateTime StartDate, DateTime EndDate, int PageIndex, int PageSize, string OrderType)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserGLCount", GameID, Min, Max, StartDate, EndDate, PageIndex, PageSize, OrderType);
            }
            return ds;
        }

        public override DataSet GetDateList(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetDateList", StartDate, EndDate);
            }
            return ds;
        }

        public override DataSet YXAcceptOrder(string UserID,DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_YXAcceptOrder", UserID,StartDate, EndDate);
            }
            return ds;
        }

        public override DataSet NewAcceptUser(DateTime StatDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_NewAcceptUser", StatDate);
            }
            return ds;
        }

        public override DataSet NewAcceptUserStat(DateTime StatDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_NewAcceptUserStat", StatDate);
            }
            return ds;
        }

        public override DataSet ActivitytUser(DateTime StatDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_ActivitytUser", StatDate);
            }
            return ds;
        }

        public override DataSet HalfActivitytUser(DateTime StatDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_HalfActivitytUser", StatDate);
            }
            return ds;
        }

        public override DataSet HalfActivitytUserStat(DateTime StatDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_HalfActivitytUserStat", StatDate);
            }
            return ds;
        }


        public override DataSet LoseUser(DateTime StatDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LoseUser", StatDate);
            }
            return ds;
        }

        public override DataSet LoseUserStat(DateTime StatDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LoseUserStat", StatDate);
            }
            return ds;
        }


        public override DataSet PercentActivitytUser(DateTime StatDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_PercentActivitytUser", StatDate);
            }
            return ds;
        }

        public override DataSet SRPriceAcceptOrder(string UserID, DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_SRPriceAcceptOrder", UserID, StartDate, EndDate);
            }
            return ds;
        }


        public override DataSet OrderEvent(DateTime sDate, DateTime eDate,string search, string Keyword, int PageIndex, int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_OrderEvent", sDate, eDate,search, Keyword, PageIndex, PageSize);
            }
            return ds;
        }

        public override DataSet PhonePwdEvent(DateTime sDate, DateTime eDate,string type, string search, string Keyword, int PageIndex, int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_PhonePwdEvent", sDate, eDate, type, search, Keyword, PageIndex, PageSize);
            }
            return ds;
        }

        #region "历史订单管理"
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <param name="Keyword"></param>
        /// <param name="SearchText"></param>
        /// <param name="Status"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public override DataSet OrderSelectHis(DateTime sDate, DateTime eDate, string Keyword, string SearchText, string Status, string CancelStatus, bool IsHisOrder, int PageIndex, int PageSize, string OrderSelect, string Game)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_OrderHis", sDate, eDate, Keyword, SearchText, Status, CancelStatus, IsHisOrder, PageIndex, PageSize, OrderSelect, Game);
            }
            return ds;
        }
        #endregion

        #region "删除订单管理"
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <param name="Keyword"></param>
        /// <param name="SearchText"></param>
        /// <param name="Status"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public override DataSet OrderSelectDel(DateTime sDate, DateTime eDate, string Keyword, string SearchText, string Status, string CancelStatus, bool IsHisOrder, int PageIndex, int PageSize, string OrderSelect,string SearchType,string Game)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_OrderDel", sDate, eDate, Keyword, SearchText, Status, CancelStatus, IsHisOrder, PageIndex, PageSize, OrderSelect,SearchType,Game);
            }
            return ds;
        }
        #endregion

        #region "后台充值"
        /// <summary>
        /// 后台充值
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Bal"></param>
        /// <param name="SerialNo"></param>
        /// <param name="OPID"></param>
        /// <returns></returns>
        public override DataSet ManualRechage(string UserID, float Bal, string SerialNo, string OPID, string Comment)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_ManualReCharge", UserID, Bal, SerialNo, OPID,Comment);
            }
            return ds;
        }
        #endregion


        #region "用户资金变动明细表"
        public override DataSet UserMoneyChangeList(int UserID, DateTime StartDate, DateTime EndDate, int Type, string RelaSerialNo, int PageIndex, int PageSize,string Search)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "HT_UserMoneyChangeList", UserID, StartDate, EndDate, Type, RelaSerialNo, PageIndex, PageSize,Search);
            }
            return ds;
        }
        #endregion

        #region "用户资金冻结明细表"
        public override DataSet UserMoneyFreezeList(int UserID, DateTime StartDate, DateTime EndDate, int Type, string RelaSerialNo, int PageIndex, int PageSize, string Search)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserMoneyFreezeList", UserID, StartDate, EndDate, Type, RelaSerialNo, PageIndex, PageSize, Search);
            }
            return ds;
        }
        #endregion

        #region "客户提现汇款管理 提现处理 撤销提现"
        /// <summary>
        /// 撤销提现
        /// </summary>
        /// <param name="WalletID"></param>
        /// <param name="Comment"></param>
        /// <returns></returns>
        public override string WithdrawCancel(string SerialNo, string Comment, int OPID)
        {
            Object result = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteScalar(Conn.ConnectionString, "BM_WithdrawCancel", SerialNo, Comment, OPID);
            }
            if (result != null)
                return result.ToString();
            else
                return "0";
        }
        #endregion

        #region "撤销单赔付查询"
        /// <summary>
        /// 撤销单赔付查询
        /// </summary>
        /// <param name="SerialNo"></param>
        public override DataSet OrderCancel(string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_OrderCancel", SerialNo);
            }
            return ds;
        }
        #endregion

        public override DataSet ArbitrationList(string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_ArbitrationList", SerialNo);
            }
            return ds;
        }

        public override DataSet LevelOrderList(string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LevelOrderList", SerialNo);
            }
            return ds;
        }

        public override DataSet UpdateIP(string IP)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UpdateIP", IP);
            }
            return ds;
        }

        #region "角色名出现频率 上家发单撤单比例"
        /// <summary>
        /// 角色名出现频率 上家发单撤单比例
        /// </summary>
        /// <param name="AType"></param>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public override DataSet OrderFreq(int Type, DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_OrderFreq", Type, StartDate, EndDate);
            }
            return ds;
        }
        #endregion

        #region "获取最近一周发单量前100的商家"
        /// <summary>
        /// 角色名出现频率 上家发单撤单比例
        /// </summary>
        /// <param name="AType"></param>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public override DataSet GetTopPostUser(string Game)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetTopPostUser", Game);
            }
            return ds;
        }
        #endregion


        #region "获取某个具体上家近一周内发单量"
        /// <summary>
        /// 角色名出现频率 上家发单撤单比例
        /// </summary>
        /// <param name="AType"></param>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public override DataSet GetUserPostByWeek(int ID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetUserPostByWeek",ID);
            }
            return ds;
        }
        #endregion

        public override DataSet GetUserLoginMACList(int ID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetUserLoginMACList", ID);
            }
            return ds;
        }

        public override DataSet GetUserLoginHDList(int ID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetUserLoginHDList", ID);
            }
            return ds;
        }

        public override DataSet GetUserCountByMAC(string MAC)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetUserCountByMAC", MAC);
            }
            return ds;
        }

        public override DataSet BM_GetUserListByMAC(string MAC)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetUserListByMAC", MAC);
            }
            return ds;
        }


        public override DataSet BM_GetMACUserListByID(string ID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetMACUserListByID", ID);
            }
            return ds;
        }

        #region "发单介入比例"
        /// <summary>
        /// 发单介入比例
        /// </summary>
        /// <param name="AType"></param>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public override DataSet JRFreq(int Type, DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_JRFreq", Type, StartDate, EndDate);
            }
            return ds;
        }
        #endregion

        #region "更多数据统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public override DataSet AllstatisticsMore(string GameID,DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_AllstatisticsMore",GameID, StartDate, EndDate);
            }
            return ds;
        }
        #endregion


        #region "用户数据统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public override DataSet UserStat(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserStat", StartDate, EndDate);
            }
            return ds;
        }
        #endregion

        #region "在线用户统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public override DataSet UserOnline()
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserOnline");
            }
            return ds;
        }
        #endregion

        #region "财务总账数据统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public override DataSet FinanceStat(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_FinanceStat", StartDate, EndDate);
            }
            return ds;
        }
        #endregion

        #region "财务总账数据统计Now"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public override DataSet FinanceTotal()
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "HT_FinanceTotal");
            }
            return ds;
        }
        #endregion

        #region "财务详细数据统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public override DataSet FinanceStatWDRC(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "HT_FinanceStatWDRC", StartDate, EndDate);
            }
            return ds;
        }
        #endregion

        #region "汇款确认数据统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public override DataSet FinanceStatConfirmWithdraw(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_ConfirmWithdraw", StartDate, EndDate);
            }
            return ds;
        }
        #endregion

        #region "汇款取消数据统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public override DataSet FinanceStatCancelWithdraw(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_CancelWithdraw", StartDate, EndDate);
            }
            return ds;
        }
        #endregion

        #region "订单处理统计"
        /// <summary>
        /// 订单处理统计
        /// </summary>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public override DataSet OrderOPStat(DateTime StartDate, DateTime EndDate, string OPName,string SearchType)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_OrderOPStat", StartDate, EndDate, OPName,SearchType);
            }
            return ds;
        }
        #endregion

        public override DataSet JROrderStat(DateTime StartDate, DateTime EndDate, string GameID, string PostUserID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_JROrderStat", StartDate, EndDate, GameID, PostUserID);
            }
            return ds;
        }

        public override DataSet PostReportCount(DateTime Start, DateTime End)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_PostReportCount", Start, End);
            }
            return ds;
        }

        public override DataSet OrderPostStat(DateTime StartDate, DateTime EndDate, string OPName, string SearchType)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_OrderPostStat", StartDate, EndDate, OPName, SearchType);
            }
            return ds;
        }

        public override DataSet OrderDelStat(DateTime StartDate, DateTime EndDate, string OPName)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_OrderDelStat", StartDate, EndDate, OPName);
            }
            return ds;
        }

        #region "强制完单"
        /// <summary>
        /// 强制完单
        /// </summary>
        /// <param name="SerialNo"></param>
        /// <param name="Payout"></param>
        /// <param name="Income"></param>
        /// <returns></returns>
        public override DataSet OrderForceOver(string SerialNo, float Payout, float Income)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LevelOrderForceOver", SerialNo, Payout, Income);
            }
            return ds;
        }
        #endregion

        public override DataSet LockCancelStatus(string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LockCancelStatus", SerialNo);
            }
            return ds;
        }

        public override DataSet GetSysUserInfo(int OPID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetSysUserInfo", OPID);
            }
            return ds;
        }

        public override DataSet GetServiceHelp(string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetServiceHelp", SerialNo);
            }
            return ds;
        }

        public override DataSet LevelOrderMarkColorList(string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LevelOrderMarkColorList", SerialNo);
            }
            return ds;
        }



        #region "删除订单"
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="SerialNo"></param>
        public override DataSet OrderDelete(string SerialNo,int OPID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LevelOrderDel", SerialNo,OPID);
            }
            return ds;
        }
        #endregion

        public override DataSet OrderActivityDelete(string ID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LevelOrderActivityDelete", ID);
            }
            return ds;
        }

        public override DataSet OrderActivityReturn(string ID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LevelOrderActivityReturn", ID);
            }
            return ds;
        }


        public override DataSet AccountRela(string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_AccountRela", SerialNo);
            }
            return ds;
        }

        public override int OrderDeleteAddRemark(string SerialNo, string Remark)
        {
            int result = 0;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_OrderDelAddRemark", SerialNo, Remark);
            }
            return result;
        }

        #region "新增留言"
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="SerialNo"></param>
        public override DataSet InsertMessage(int UserID, int MsgType, string ODSerialNo, DateTime CreateDate, string Msg)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_InsertMessage", UserID, MsgType,ODSerialNo,CreateDate,Msg);
            }
            return ds;
        }
        #endregion

        #region "删除客服留言"
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="SerialNo"></param>
        public override DataSet DeleteMessageService(int MessageID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_DeleteMessageService", MessageID);
            }
            return ds;
        }
        #endregion

        #region "删除订单"
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="SerialNo"></param>
        public override int SetUserSubAccount(string UserID, int Status)
        {
            int result = 0;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_SetUserSubAccount", UserID, Status);
            }
            return result;
        }
        #endregion


        public override int IsForbidLogin(int UserID)
        {
            int result = 0;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_IsForbidLogin", UserID);
            }
            return result;
        }

        public override int UserLog(int UserID, int OPType, string OPLog, string IP)
        {
            int result = 0;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_UserLog", UserID, OPType,OPLog,IP);
            }
            return result;
        }

        public override int DeleteNewsComment(int NewsID)
        {
            int result = 0;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_DeleteNewsComment", NewsID);
            }
            return result;
        }


        #region "区服汇总表
        /// <summary>
        /// 撤销提现
        /// </summary>
        /// <param name="WalletID"></param>
        /// <param name="Comment"></param>
        /// <returns></returns>
        public override string ZoneServer(string ZoneID, string ServerName)
        {
            Object result = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteScalar(Conn.ConnectionString, "BM_ZoneServer", ZoneID, ServerName);
            }
            if (result != null)
                return result.ToString();
            else
                return "0";
        }
        #endregion


        #region "单个订单查询[原始单]"
        /// <summary>
        /// 单个订单查询[原始单]
        /// </summary>
        /// <param name="SerialNo"></param>
        public override DataSet GetOrder(string SerialNo, int IsHisOrder)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetOrder", SerialNo, IsHisOrder);
            }
            return ds;
        }
        #endregion

        public override DataSet GetOrderHis(string SerialNo, int IsHisOrder)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetOrderHis", SerialNo, IsHisOrder);
            }
            return ds;
        }

        #region "单个删除订单查询[原始单]"
        /// <summary>
        /// 单个订单查询[原始单]
        /// </summary>
        /// <param name="SerialNo"></param>
        public override DataSet GetOrderDel(string SerialNo,string DelType)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetOrderDel", SerialNo, DelType);
            }
            return ds;
        }
        #endregion

        public override DataSet AddAppointArbitration(string CustomerID, string UserID,int OpID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_AddAppointArbitration", CustomerID, UserID, OpID);
            }
            return ds;
        }

        #region "查询发单人是否被禁止发单"
        /// <summary>
        /// 单个订单查询[原始单]
        /// </summary>
        /// <param name="SerialNo"></param>
        public override DataSet PubHaveRightLock(string id)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_PubHaveRightLock", id);
            }
            return ds;
        }
        #endregion

        #region "修改用户备注"
        /// <summary>
        /// 标记关注订单
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="IsLock"></param>
        /// <returns></returns>
        public override DataSet UpdateUserComment(string Comment, string UID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UpdateUserComment", Comment, UID);
            }
            return ds;
        }
        #endregion

        public override DataSet UpdateFeedBackComment(string Comment, string UserID, int CustomerID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UpdateFeedBackComment", Comment, UserID, CustomerID);
            }
            return ds;
        }

        public override DataSet AddBankBlack(int BankID, string BankUser, string BankAcc, int CustomerID, string Comment)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_AddBankBlack", BankID, BankUser,BankAcc,CustomerID,Comment);
            }
            return ds;
        }

        public override DataSet RightLockLastOPID(string UID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_RightLockLastOPID", UID);
            }
            return ds;
        }

        public override DataSet FTRightLock(string ID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_FTRightLock", ID);
            }
            return ds;
        }

        public override DataSet SearchAccPwd(string SerialNo,int OPID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_SearchAccPwd", SerialNo,OPID);
            }
            return ds;
        }


        public override DataSet IsGoodPost(string userID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_IsGoodPost", userID);
            }
            return ds;
        }

        public override DataSet IsGoodAccept(string userID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_IsGoodAccept", userID);
            }
            return ds;
        }


        #region "评价备注修改"
        /// <summary>
        /// 标记关注订单
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="IsLock"></param>
        /// <returns></returns>
        public override DataSet UpdateOrderEvaluate(string OrderEvaluate, string Comment, string Type,string Direct)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UpdateOrderEvaluate", OrderEvaluate, Comment, Type, Direct);
            }
            return ds;
        }
        #endregion


        #region "修改角色备注"
        /// <summary>
        /// 标记关注订单
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="IsLock"></param>
        /// <returns></returns>
        public override DataSet UpdateRoleComment(string Comment,string Actor, string Code)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UpdateRoleComment", Comment,Actor, Code);
            }
            return ds;
        }
        #endregion


        #region "修改备注"
        /// <summary>
        /// 修改备注
        /// </summary>
        /// <param name="iType"></param>
        /// <param name="Cmt2"></param>
        /// <param name="SerialNo"></param>
        /// <returns></returns>
        public override DataSet UpdateComment(string SerialNo, string Commment)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UpdateComment", SerialNo, Commment);
            }
            return ds;
        }
        #endregion

        public override DataSet UpdateActivityOrderComment(string ActivityID, string Commment)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UpdateActivityOrderComment", ActivityID, Commment);
            }
            return ds;
        }

        public override DataSet AddActivityOrder(string ActivityID, string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_AddActivityOrder", ActivityID, SerialNo);
            }
            return ds;
        }


        public override DataSet CheckActivityOrder(string ActivityID, string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_CheckActivityOrder", ActivityID, SerialNo);
            }
            return ds;
        }

        public override DataSet IsActivityBlack(string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_IsActivityBlack", SerialNo);
            }
            return ds;
        }

        public override DataSet GetLevelOrderActivityList(int PageIndex, int PageSize,string ActivityID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetLevelOrderActivityList",PageIndex,PageSize, ActivityID);
            }
            return ds;
        }

        public override DataSet ActivityOrderRela(int UserID, string ActivityID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_ActivityOrderRela", UserID, ActivityID);
            }
            return ds;
        }

        public override DataSet DeleteActivityOrder(int ActivityID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_DeleteActivityOrder", ActivityID);
            }
            return ds;
        }

        #region "修改重判分析备注"
        /// <summary>
        /// 修改备注
        /// </summary>
        /// <param name="iType"></param>
        /// <param name="Cmt2"></param>
        /// <param name="SerialNo"></param>
        /// <returns></returns>
        public override DataSet UpdateRejudgComment(string SerialNo, string Commment)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UpdateRejudgComment", SerialNo, Commment);
            }
            return ds;
        }
        #endregion

        #region "查询用户跟踪信息"
        /// <summary>
        /// 查询用户跟踪信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public override DataSet GetUserTrackInfo(string UserID, int PageIndex, int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserTrack", UserID, PageIndex, PageSize);
            }
            return ds;
        }
        #endregion

        public override DataSet GetUserTrackInfoComment(string UserID, int PageIndex, int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserTrackComment", UserID, PageIndex, PageSize);
            }
            return ds;
        }

        public override DataSet GetUserAccountProved(string UserID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_UserAccountProved", UserID);
            }
            return ds;
        }

        public override DataSet JugeReason(int PageIndex, int PageSize,string Where,string Where2)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_JugeReason", PageIndex, PageSize, Where,Where2);
            }
            return ds;
        }

        #region "添加用户跟踪信息"
        /// <summary>
        /// 添加用户跟踪信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="TrackInfo"></param>
        /// <param name="Score"></param>
        /// <returns></returns>
        public override DataSet AddUserTrackInfo(string UserID, string TrackInfo, int Score,int OPID,string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_AddUserTrackInfo", UserID, TrackInfo, Score,OPID,SerialNo);
            }
            return ds;
        }
        #endregion

        public override DataSet AddUserTrackInfoComment(string UserID, string TrackInfo, int Score, int OPID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_AddUserTrackInfoComment", UserID, TrackInfo, Score, OPID);
            }
            return ds;
        }

        public override DataSet AddUserAccountProved(string UserID, string Evidence,int IsDeal, int OPID)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_AddUserAccountProved", UserID, Evidence,IsDeal, OPID);
            }
            return ds;
        }


        public override DataSet AddOrderJudg(string ODSerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_AddOrderJudg", ODSerialNo);
            }
            return ds;
        }


        #region "用户留言订单交互查询"
        /// <summary>
        /// 撤销提现
        /// </summary>
        /// <param name="WalletID"></param>
        /// <param name="Comment"></param>
        /// <returns></returns>
        public override DataSet LevelOrderMessage(int PageIndex, int PageSize, string Where)
        {

            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LevelOrderMessage", PageIndex, PageSize, Where);
            }
            return ds;

        }
        #endregion

        #region "用户历史留言订单交互查询"
        /// <summary>
        /// 撤销提现
        /// </summary>
        /// <param name="WalletID"></param>
        /// <param name="Comment"></param>
        /// <returns></returns>
        public override DataSet LevelOrderMessageHis(int PageIndex, int PageSize, string Where)
        {

            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_LevelOrderMessageHis", PageIndex, PageSize, Where);
            }
            return ds;

        }
        #endregion


        #region "客户提现汇款管理 提现处理 成功提现"
        /// <summary>
        /// 撤销提现
        /// </summary>
        /// <param name="WalletID"></param>
        /// <param name="Comment"></param>
        /// <returns></returns>
        public override string WithdrawSuccess(string SerialNo, string BankSerialNo, string Comment, int OPID)
        {
            Object result = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteScalar(Conn.ConnectionString, "BM_WithdrawSuccess", SerialNo,BankSerialNo, Comment, OPID);
            }
            if (result != null)
                return result.ToString();
            else
                return "0";
        }
        #endregion


        #region "用户是否存在锁定记录"
        /// <summary>
        /// 撤销提现
        /// </summary>
        /// <param name="WalletID"></param>
        /// <param name="Comment"></param>
        /// <returns></returns>
        public override string UserIsLock(int UserID, int LockType)
        {
            Object result = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteScalar(Conn.ConnectionString, "BM_UserIsLock", UserID,LockType);
            }
            if (result != null)
                return result.ToString();
            else
                return "1";
        }
        #endregion


        public override void InsertServiceHelp(string ODSerialNo, int UserID,int AcceptUserID,string Content,int HelpType)
        {
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_InsertServiceHelp", ODSerialNo, UserID, AcceptUserID, Content, HelpType);
            }
        }

        public override void DeleteServiceHelp(string ODSerialNo)
        {
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_DeleteServiceHelp", ODSerialNo);
            }
        }

        public override void UpdateServiceHelp(string ODSerialNo,int IsDeal,string OPID)
        {
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_UpdateServiceHelp", ODSerialNo,IsDeal,OPID);
            }
        }

        public override void UpdatePostReport(string SerialNo, int Status, string OPID)
        {
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_UpdatePostReport", SerialNo, Status, OPID);
            }
        }

        public override void UpdateFeedBackMark(string id, int Mark)
        {
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_UpdateFeedBackMark", id, Mark);
            }
        }

        public override void FirstCheck(string id, int Mark)
        {
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_FirstCheck", id, Mark);
            }
        }

        public override void UpdateRejudgColor(string ID, int IsDeal)
        {
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_UpdateRejudgColor", ID, IsDeal);
            }
        }

        public override void LevelOrderMarkColor(string ODSerialNo, string OPID)
        {
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_LevelOrderMarkColor", ODSerialNo, OPID);
            }
        }

        public override void AddLevelOrderReJudg(string SerialNo, string Reason, int OPID)
        {
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_AddLevelOrderReJudg", SerialNo, Reason, OPID);
            }
        }

        #region "截图查询"
        /// <summary>
        /// 截图查询
        /// </summary>
        /// <param name="SerialNo"></param>
        /// <returns></returns>
        public override DataSet GetOrderProgress(string SerialNo)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GetOrderProgress", SerialNo);
            }
            return ds;
        }
        #endregion

        #region "标记关注订单"
        /// <summary>
        /// 标记关注订单
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="IsLock"></param>
        /// <returns></returns>
        public override DataSet MarkLookOrder(string SerialNo, int OPID, int iLook)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_MarkLookOrder", SerialNo, OPID, iLook);
            }
            return ds;
        }
        #endregion

        public override DataSet SetOrderCancelStatus(string SerialNo, int Status)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_SetOrderCancelStatus", SerialNo, Status);
            }
            return ds;
        }

        #region "获取表中字段值"
        /// <summary>
        /// 获取表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="table_fileds">字段</param>
        /// <param name="where_fileds">查询条件字段</param>
        /// <param name="where_value">查询值</param>
        /// <returns>返回字段值</returns>
        public override string get_table_fileds(string table_name, string table_fileds, string where_fileds, string where_value)
        {
            string rStr = "";
            using (SqlConnection Conn = GetSqlConnection())
            {
                string strSql = string.Format("select {0} from {1} where upper({2})='{3}'", table_fileds, table_name, where_fileds, where_value);
                SqlCommand cmd = new SqlCommand(strSql, Conn);
                cmd.CommandType = CommandType.Text;
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    rStr = dr[0].ToString();
                }
                dr.Close();
                dr.Dispose();
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rStr;
        }

        /// <summary>
        /// 获取表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="table_fileds">字段</param>
        /// <param name="where_fileds">查询条件字段</param>
        /// <param name="where_value">查询值</param>
        /// <param name="tran">事务</param>
        /// <returns>返回字段值</returns>
        public override string get_table_fileds(string table_name, string table_fileds, string where_fileds, string where_value,DbTransaction tran)
        {
            string rStr = "";

            string strSql = string.Format("select {0} from {1} where upper({2})='{3}'", table_fileds, table_name, where_fileds, where_value);
            SqlCommand cmd = new SqlCommand(strSql, (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                rStr = dr[0].ToString();
            }
            dr.Close();
            dr.Dispose();
            cmd.Dispose();

            return rStr;
        }
        #endregion

        #region "更新表中字段值"
        /// <summary>
        /// 更新表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="Table">表名</param>
        /// <param name="Table_FiledsValue">需要更新值(不用带Set)</param>
        /// <param name="Wheres">更新条件(不用带Where)</param>
        /// <returns>-1:失败,其它值成功</returns>
        public override int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres)
        {
            int rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                string strSql = string.Format("Update {0} Set {1}  Where {2}", Table,Table_FiledsValue,Wheres);
                SqlCommand cmd = new SqlCommand(strSql, Conn);
                cmd.CommandType = CommandType.Text;
                Conn.Open();                
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 更新表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="Table">表名</param>
        /// <param name="Table_FiledsValue">需要更新值(不用带Set)</param>
        /// <param name="Wheres">更新条件(不用带Where)</param>
        /// <param name="tran">事务</param>
        /// <returns>-1:失败,其它值成功</returns>
        public override int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres,DbTransaction tran)
        {
            int rInt = -1;

            string strSql = string.Format("Update {0} Set {1}  Where {2}", Table,Table_FiledsValue,Wheres);
            SqlCommand cmd = new SqlCommand(strSql, (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.Text;
             
            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }
        #endregion

        #region 公共查询数据函数Sql存储过程版
        /// <summary>
        /// 公共查询数据函数Sql存储过程版(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="pd">委托对象</param>
        /// <param name="pp">查询字符串</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>返回记录集List</returns>
        private List<T> GetRecordList<T>(PopulateDelegate<T> pd, QueryParam pp, out int RecordCount)
        {
            List<T> lst = new List<T>();
            RecordCount = 0;
            using (SqlConnection conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.SupesoftPage", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // 设置参数
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 500).Value = pp.TableName;
                cmd.Parameters.Add("@ReturnFields", SqlDbType.NVarChar, 500).Value = pp.ReturnFields;
                cmd.Parameters.Add("@Where", SqlDbType.NVarChar, 500).Value = pp.Where;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pp.PageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pp.PageSize;
                cmd.Parameters.Add("@Orderfld", SqlDbType.NVarChar, 200).Value = pp.Orderfld;
                cmd.Parameters.Add("@OrderType", SqlDbType.Int).Value = pp.OrderType;
                // 执行
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Dictionary<string, string> Fileds = new Dictionary<string,string>();
                foreach (DataRow var in dr.GetSchemaTable().Select())
                {
                    Fileds.Add(var[0].ToString(), var[0].ToString());
                }
                while (dr.Read())
                {
                    lst.Add(pd(dr,Fileds));
                }
                // 取记录总数 及页数
                if (dr.NextResult())
                {
                    if (dr.Read())
                    {
                        RecordCount = Convert.ToInt32(dr["RecordCount"]);
                    }
                }

                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lst;
        }

        /// <summary>
        /// 公共查询数据函数Sql存储过程版(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="pd">委托对象</param>
        /// <param name="pp">查询字符串</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">事务</param>
        /// <returns>返回记录集List</returns>
        private List<T> GetRecordList<T>(PopulateDelegate<T> pd, QueryParam pp, out int RecordCount,DbTransaction tran)
        {
            List<T> lst = new List<T>();
            RecordCount = 0;

            SqlCommand cmd = new SqlCommand("dbo.SupesoftPage", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            // 设置参数
            cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 500).Value = pp.TableName;
            cmd.Parameters.Add("@ReturnFields", SqlDbType.NVarChar, 500).Value = pp.ReturnFields;
            cmd.Parameters.Add("@Where", SqlDbType.NVarChar, 500).Value = pp.Where;
            cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pp.PageIndex;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pp.PageSize;
            cmd.Parameters.Add("@Orderfld", SqlDbType.NVarChar, 200).Value = pp.Orderfld;
            cmd.Parameters.Add("@OrderType", SqlDbType.Int).Value = pp.OrderType;
            // 执行
            SqlDataReader dr = cmd.ExecuteReader();
            Dictionary<string, string> Fileds = new Dictionary<string,string>();
            foreach (DataRow var in dr.GetSchemaTable().Select())
            {
                Fileds.Add(var[0].ToString(), var[0].ToString());
            }
            while (dr.Read())
            {
                lst.Add(pd(dr,Fileds));
            }
            // 取记录总数 及页数
            if (dr.NextResult())
            {
                if (dr.Read())
                {
                    RecordCount = Convert.ToInt32(dr["RecordCount"]);
                }
            }

            dr.Close();
            cmd.Dispose();

            return lst;
        }


        public override DataTable GetRecordList(QueryParam pp, out int RecordCount, out int PageCount)
        {
            DataTable dt = null;

            RecordCount = 0;
            PageCount = 0;
            //using (SqlConnection conn = GetSqlConnection())
            //{
            //    SqlCommand cmd = new SqlCommand("dbo.SupesoftPage", conn);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    // 设置参数
            //    cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 500).Value = pp.TableName;
            //    cmd.Parameters.Add("@ReturnFields", SqlDbType.NVarChar, 500).Value = pp.ReturnFields;
            //    cmd.Parameters.Add("@Where", SqlDbType.NVarChar, 500).Value = pp.Where;
            //    cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pp.PageIndex;
            //    cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pp.PageSize;
            //    cmd.Parameters.Add("@Orderfld", SqlDbType.NVarChar, 200).Value = pp.Orderfld;
            //    cmd.Parameters.Add("@OrderType", SqlDbType.Int).Value = pp.OrderType;
            //    // 执行
            //    conn.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    DataTable schemaTable = dr.GetSchemaTable();
            //    //动态构建表，添加列
            //    foreach (DataRow row in schemaTable.Rows)
            //    {
            //        DataColumn dc = new DataColumn();
            //        //设置列的数据类型
            //        dc.DataType = row[0].GetType();
            //        //设置列的名称
            //        dc.ColumnName = row[0].ToString();
            //        //将该列添加进构造的表中
            //        dt.Columns.Add(dc);
            //    }

            //    //读取数据添加进表中
            //    while (dr.Read())
            //    {
            //        DataRow row = dt.NewRow();
            //        //填充一行数据
            //        for (int i = 0; i < schemaTable.Rows.Count; i++)
            //        {
            //            row[i] = dr[i].ToString();

            //        }
            //        dt.Rows.Add(row);
            //        row = null;
            //    }

            //    // 取记录总数 及页数
            //    if (dr.NextResult())
            //    {
            //        if (dr.Read())
            //        {
            //            RecordCount = Convert.ToInt32(dr["RecordCount"]);
            //            PageCount = Convert.ToInt32(dr["PageCount"]);
            //        }
            //    }

            //    dr.Close();
            //    schemaTable = null;
            //    cmd.Dispose();
            //    conn.Close();
            //}
            //return dt;

            using (SqlConnection connection = this.GetSqlConnection())
            {
                 SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@TableName",pp.TableName),
                    new SqlParameter("@ReturnFields", pp.ReturnFields),
                    new SqlParameter("@Where",pp.Where),
                    new SqlParameter("@PageIndex",pp.PageIndex),
                    new SqlParameter("@PageSize",pp.PageSize),
                    new SqlParameter("@Orderfld",pp.Orderfld),
                    new SqlParameter("@OrderType",pp.OrderType)
                };
                 DataSet ds= SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.StoredProcedure, "SupesoftPage", pms);
                 if (ds != null && ds.Tables[0] != null) {
                     dt = ds.Tables[0];
                     RecordCount = Convert.ToInt32( ds.Tables[1].Rows[0]["RecordCount"]);
                     PageCount = Convert.ToInt32(ds.Tables[1].Rows[0]["PageCount"]);
                 }
                 return dt;
            }
        }
        #endregion

        #region 优质频道

        public override DataSet GoodPublishList(string UID, DateTime sDate, DateTime eDate, int Status, string Sort_Str, int PageIndex, int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GoodPublishList", UID, sDate, eDate, Status, Sort_Str, PageIndex, PageSize);
            }
            return ds;
        }

        public override int GoodPublishPast(int ID, int Flag)
        {
            int result = 0;
            using (SqlConnection Conn = GetSqlConnection())
            {
                result = SqlHelper.ExecuteNonQuery(Conn.ConnectionString, "BM_GoodPublishPast", ID, Flag);
            }
            return result;
        }

        public override DataTable GoodPublishAdd(string UID, int Del)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GoodPublishAdd", UID, Del);
            }
            return ds.Tables[0];
        }

        public override DataSet GoodAcceptList(string UID, DateTime sDate, DateTime eDate, int Status, string Sort_Str, int ApplyTier, int PageIndex, int PageSize)
        {
            DataSet ds = null;
            using (SqlConnection Conn = GetSqlConnection())
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_GoodAcceptList", UID, sDate, eDate, Status, Sort_Str, ApplyTier, PageIndex, PageSize);
            }
            return ds;
        }

        public override int GoodAcceptPast(int ID, int Flag, string Describle)
        {
            int result = 0;
            using (SqlConnection Conn = GetSqlConnection())
            {
                object oj = SqlHelper.ExecuteScalar(Conn.ConnectionString, "BM_GoodAcceptPast", ID, Flag, Describle);
                result = int.Parse(oj.ToString());
            }
            return result;
        }

        #endregion

        #region "tbVirtualBank (tbVirtualBank) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tbVirtualBank (tbVirtualBank)
        /// </summary>
        /// <param name="fam">tbVirtualBankEntity实体类(tbVirtualBank)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbVirtualBankInsertUpdateDelete(tbVirtualBankEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.tbVirtualBank_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = fam.BankName;  //BankName
                cmd.Parameters.Add("@MONEY", SqlDbType.Money).Value = fam.MONEY;  //MONEY
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tbVirtualBank (tbVirtualBank)
        /// </summary>
        /// <param name="fam">tbVirtualBankEntity实体类(tbVirtualBank)</param>
        /// <param name="tran">tbVirtualBank事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbVirtualBankInsertUpdateDelete(tbVirtualBankEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbVirtualBank_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = fam.BankName;  //BankName
            cmd.Parameters.Add("@MONEY", SqlDbType.Money).Value = fam.MONEY;  //MONEY

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回tbVirtualBankEntity实体类的List对象 (tbVirtualBank)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbVirtualBankEntity实体类的List对象(tbVirtualBank)</returns>
        public override List<tbVirtualBankEntity> tbVirtualBankList(QueryParam qp, out int RecordCount)
        {
            return tbVirtualBankList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tbVirtualBankEntity实体类的List对象 (tbVirtualBank)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbVirtualBank事务</param>
        /// <returns>tbVirtualBankEntity实体类的List对象(tbVirtualBank)</returns>
        public override List<tbVirtualBankEntity> tbVirtualBankList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbVirtualBankEntity> mypd = new PopulateDelegate<tbVirtualBankEntity>(base.PopulatetbVirtualBankEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "sys_LoginAuthorize (sys_LoginAuthorize) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 sys_LoginAuthorize (sys_LoginAuthorize)
        /// </summary>
        /// <param name="fam">sys_LoginAuthorizeEntity实体类(sys_LoginAuthorize)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 sys_LoginAuthorizeInsertUpdateDelete(sys_LoginAuthorizeEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.sys_LoginAuthorize_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@L_ID", SqlDbType.Int).Value = fam.L_ID;  //L_ID
                cmd.Parameters.Add("@L_Status", SqlDbType.Int).Value = fam.L_Status;  //L_Status
                if (fam.L_CreateDate.HasValue)
                    cmd.Parameters.Add("@L_CreateDate", SqlDbType.DateTime).Value = fam.L_CreateDate;  //L_CreateDate
                else
                    cmd.Parameters.Add("@L_CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //L_CreateDate
                if (fam.L_StartDate.HasValue)
                    cmd.Parameters.Add("@L_StartDate", SqlDbType.DateTime).Value = fam.L_StartDate;  //L_StartDate
                else
                    cmd.Parameters.Add("@L_StartDate", SqlDbType.DateTime).Value = DBNull.Value;  //L_StartDate
                if (fam.L_EndDate.HasValue)
                    cmd.Parameters.Add("@L_EndDate", SqlDbType.DateTime).Value = fam.L_EndDate;  //L_EndDate
                else
                    cmd.Parameters.Add("@L_EndDate", SqlDbType.DateTime).Value = DBNull.Value;  //L_EndDate
                cmd.Parameters.Add("@L_Remark", SqlDbType.NVarChar).Value = fam.L_Remark;  //L_Remark
                cmd.Parameters.Add("@L_IP", SqlDbType.NVarChar).Value = fam.L_IP;  //L_IP
                cmd.Parameters.Add("@L_MAC", SqlDbType.NVarChar).Value = fam.L_MAC;  //L_MAC
                cmd.Parameters.Add("@L_BC1", SqlDbType.Int).Value = fam.L_BC1;  //L_BC1
                if (fam.L_BC2.HasValue)
                    cmd.Parameters.Add("@L_BC2", SqlDbType.DateTime).Value = fam.L_BC2;  //L_BC2
                else
                    cmd.Parameters.Add("@L_BC2", SqlDbType.DateTime).Value = DBNull.Value;  //L_BC2
                cmd.Parameters.Add("@L_BC3", SqlDbType.NVarChar).Value = fam.L_BC3;  //L_BC3
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 sys_LoginAuthorize (sys_LoginAuthorize)
        /// </summary>
        /// <param name="fam">sys_LoginAuthorizeEntity实体类(sys_LoginAuthorize)</param>
        /// <param name="tran">sys_LoginAuthorize事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 sys_LoginAuthorizeInsertUpdateDelete(sys_LoginAuthorizeEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.sys_LoginAuthorize_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@L_ID", SqlDbType.Int).Value = fam.L_ID;  //L_ID
            cmd.Parameters.Add("@L_Status", SqlDbType.Int).Value = fam.L_Status;  //L_Status
            if (fam.L_CreateDate.HasValue)
                cmd.Parameters.Add("@L_CreateDate", SqlDbType.DateTime).Value = fam.L_CreateDate;  //L_CreateDate
            else
                cmd.Parameters.Add("@L_CreateDate", SqlDbType.DateTime).Value = DBNull.Value;  //L_CreateDate
            if (fam.L_StartDate.HasValue)
                cmd.Parameters.Add("@L_StartDate", SqlDbType.DateTime).Value = fam.L_StartDate;  //L_StartDate
            else
                cmd.Parameters.Add("@L_StartDate", SqlDbType.DateTime).Value = DBNull.Value;  //L_StartDate
            if (fam.L_EndDate.HasValue)
                cmd.Parameters.Add("@L_EndDate", SqlDbType.DateTime).Value = fam.L_EndDate;  //L_EndDate
            else
                cmd.Parameters.Add("@L_EndDate", SqlDbType.DateTime).Value = DBNull.Value;  //L_EndDate
            cmd.Parameters.Add("@L_Remark", SqlDbType.NVarChar).Value = fam.L_Remark;  //L_Remark
            cmd.Parameters.Add("@L_IP", SqlDbType.NVarChar).Value = fam.L_IP;  //L_IP
            cmd.Parameters.Add("@L_MAC", SqlDbType.NVarChar).Value = fam.L_MAC;  //L_MAC
            cmd.Parameters.Add("@L_BC1", SqlDbType.Int).Value = fam.L_BC1;  //L_BC1
            if (fam.L_BC2.HasValue)
                cmd.Parameters.Add("@L_BC2", SqlDbType.DateTime).Value = fam.L_BC2;  //L_BC2
            else
                cmd.Parameters.Add("@L_BC2", SqlDbType.DateTime).Value = DBNull.Value;  //L_BC2
            cmd.Parameters.Add("@L_BC3", SqlDbType.NVarChar).Value = fam.L_BC3;  //L_BC3

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回sys_LoginAuthorizeEntity实体类的List对象 (sys_LoginAuthorize)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_LoginAuthorizeEntity实体类的List对象(sys_LoginAuthorize)</returns>
        public override List<sys_LoginAuthorizeEntity> sys_LoginAuthorizeList(QueryParam qp, out int RecordCount)
        {
            return sys_LoginAuthorizeList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回sys_LoginAuthorizeEntity实体类的List对象 (sys_LoginAuthorize)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">sys_LoginAuthorize事务</param>
        /// <returns>sys_LoginAuthorizeEntity实体类的List对象(sys_LoginAuthorize)</returns>
        public override List<sys_LoginAuthorizeEntity> sys_LoginAuthorizeList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<sys_LoginAuthorizeEntity> mypd = new PopulateDelegate<sys_LoginAuthorizeEntity>(base.Populatesys_LoginAuthorizeEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion



        #region 登录页面登录操作
        public override DataSet Login(string UserName, string Password)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                return SqlHelper.ExecuteDataset(connection.ConnectionString, "ThirdPart_UserLogin", new object[] { UserName, Password });
            }
        } 
        #endregion


        #region 根据手机号码查询登录ID
        public override string GetLoginIDByMobile(string Mobile)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@BindMobile",Mobile)
                };
                string sql = "select top 1 LoginID from act_User where BindMobile=@BindMobile";

                object obj = SqlHelper.ExecuteScalar(connection.ConnectionString, CommandType.Text, sql, pms);
                if (obj != null && obj != "")
                {
                    return obj.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion

        public override DataTable GetActivityByModuleID(int moduleId)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                string sql = string.Format("select id,name,content,ImageUrl,Question,reward from dbo.act_Activity" +
                             " where [enable]=1 and ModuleID={0} order by Sort", moduleId);

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }


        public override DataSet GetZhanKengOrders(int activityId, int bet,int userId)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                return SqlHelper.ExecuteDataset(connection.ConnectionString, "BM_CheckZhanKeng", new object[] { activityId, bet, userId });
            }
        }

        public override DataSet GetZhanKengOrders(string seriaNo, int userId)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                return SqlHelper.ExecuteDataset(connection.ConnectionString, "BM_GetZhanKeng", new object[] { seriaNo, userId });
            }
        }

        public override DataTable GetActivityById(string id)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@ID",id)
                };

                string sql = "select name,reward,content,GameID,TimeLimit,[rule],Question,StartPosition,EndPosition from dbo.act_Activity where ID=@ID and [enable]=1";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

       /// <summary>
       /// 检查坑位是否被占
       /// </summary>
       /// <param name="seriaNo"></param>
       /// <param name="pits"></param>
       /// <returns></returns>
        public override bool CheckZhanKengBit(string seriaNo, string pits)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                string sql = string.Format("select count(*) from dbo.act_ZhanKeng_Orders where Z_SeriaNo='{0}' and Pit in ({1})", seriaNo, pits);

                int count = Convert.ToInt32(SqlHelper.ExecuteScalar(connection.ConnectionString, CommandType.Text, sql));
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 根据编号查找占坑数据
        /// </summary>
        /// <param name="seriaNo"></param>
        /// <returns></returns>
        public override DataTable GetZhanKengBySeriaNo(string seriaNo)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@SeriaNo",seriaNo)
                };

                string sql = "select * from dbo.act_ZhanKeng where SeriaNo=@SeriaNo";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 查询用户占的坑位
        /// </summary>
        /// <param name="seriaNo"></param>
        /// <returns></returns>
        public override DataTable GetZhanKengByOrderSeriaNo(string seriaNo)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@SeriaNo",seriaNo)
                };

                string sql = "select Z_SeriaNo,pit,Bet from dbo.act_ZhanKeng_Orders a inner join dbo.act_ZhanKeng b on a.Z_SeriaNo=b.SeriaNo where O_SeriaNo=@SeriaNo";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public override DataTable GetZhanKengByOrderSeriaNo(string seriaNo,bool isShowAll)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@SeriaNo",seriaNo)
                };

                string sql = "select Z_SeriaNo,pit,Bet, StartDate, ActivityID, Status, Period, LotteryNumber, WinPitNumber, LotteryDate, LastEndDate, UserID from dbo.act_ZhanKeng_Orders a inner join dbo.act_ZhanKeng b on a.Z_SeriaNo=b.SeriaNo where O_SeriaNo=@SeriaNo";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据期数得到占坑数量
        /// </summary>
        /// <param name="seriaNo"></param>
        /// <returns></returns>
        public override int GetZhanKengNumBySeriaNo(string seriaNo)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@SeriaNo",seriaNo)
                };

                string sql = "select COUNT(*) from dbo.act_ZhanKeng_Orders where Z_SeriaNo=@SeriaNo";

                int count = Convert.ToInt32(SqlHelper.ExecuteScalar(connection.ConnectionString, CommandType.Text, sql, pms));
                return count;
            }
        }

        /// <summary>
        /// 根据活动id和模式id查找活动
        /// </summary>
        /// <param name="id"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public override DataTable GetActivityById(string id, string moduleId)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@ID",id),
                    new SqlParameter("@ModuleID",moduleId)
                };

                string sql = "select name,reward,content,GameID,TimeLimit,[rule],Question,StartPosition,EndPosition from dbo.act_Activity where ID=@ID and ModuleID=@ModuleID and [enable]=1";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 检查报名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleName"></param>
        /// <param name="userID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public override DataSet CheckBaoMing(string id, string roleName, int userID, int status, string moduleID)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                return SqlHelper.ExecuteDataset(connection.ConnectionString, "BM_CheckBaoMing", new object[] { id, status, userID, roleName, moduleID });
            }
        }


        public override DataTable GetUserZoneServer(int userId,string gameId)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@UserID",userId),
                    new SqlParameter("@GameID",gameId)
                };

                string sql = "select top 1 ID,UserID, GameID, ZoneID, ServerID, RoleName from dbo.act_UserZoneServer where UserID=@UserID and GameID=@GameID order by ID desc";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public override double GetUserSumBal(int userId)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@ID",userId)
                };

                string sql = "select SumBal from dbo.act_User where ID=@ID";

                object obj = SqlHelper.ExecuteScalar(connection.ConnectionString, CommandType.Text, sql, pms);
                if (obj != null)
                {
                    return Convert.ToDouble(obj);
                }
                else
                {
                    return 0;
                }
            }
        }

        public override DataTable GetUserSumBal1(int userId)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@ID",userId)
                };

                string sql = "select SumBal,NickName from dbo.act_User where ID=@ID";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public override DataTable GetUserByUid(string uid)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@UID",uid)
                };

                string sql = "select ID, Figureurl, UID, Nickname, LoginID, Pass, PayPass, BindMobile, Sex, SumBal, Email, CreateDate, Status, OpenID from act_User where UID=@UID";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public override DataTable GetNickNameByUid(string uid)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@UID",uid)
                };

                string sql = "select Nickname from act_User where UID=@UID";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }


        public override int UpdateUserSumBal(int userId,double sumBal,int operate)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@SumBal",sumBal),
                    new SqlParameter("@ID",userId)
                };

                string sql = "";
                if (operate == 1)
                {
                    sql = "update act_User set SumBal =SumBal+@SumBal where ID=@ID";
                }
                else
                {
                    sql = "update act_User set SumBal =SumBal-@SumBal where ID=@ID";
                }

                int result = SqlHelper.ExecuteNonQuery(connection.ConnectionString, CommandType.Text, sql, pms);
                return result;
            }
        }

        /// <summary>
        /// 修改用户头像
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="figureurl"></param>
        /// <returns></returns>
        public override int UpdateFigureurl(int userId, string figureurl)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@UserID",userId),
                    new SqlParameter("@Figureurl",figureurl)
                };

                string sql = "update act_User set Figureurl =@Figureurl where ID=@UserID";

                int result = SqlHelper.ExecuteNonQuery(connection.ConnectionString, CommandType.Text, sql, pms);
                return result;
            }
        }

        /// <summary>
        /// 修改用户昵称
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="figureurl"></param>
        /// <returns></returns>
        public override int UpdateNickName(int userId,string nickName)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@UserID",userId),
                    new SqlParameter("@Nickname",nickName)
                   
                };

                string sql = "update act_User set Nickname =@Nickname where ID=@UserID";

                int result = SqlHelper.ExecuteNonQuery(connection.ConnectionString, CommandType.Text, sql, pms);
                return result;
            }
        }

        /// <summary>
        /// 修改用户QQ
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public override int UpdateQQ(int userId, string QQ)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@UserID",userId),
                    new SqlParameter("@QQ",QQ)
                   
                };

                string sql = "update act_User set QQ =@QQ where ID=@UserID";

                int result = SqlHelper.ExecuteNonQuery(connection.ConnectionString, CommandType.Text, sql, pms);
                return result;
            }
        }

        public override int CheckUserByMobile(string mobile)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@Mobile",mobile)
                };

                string sql = "select count(*) from act_User where BindMobile=@Mobile";

                int result = Convert.ToInt32(SqlHelper.ExecuteScalar(connection.ConnectionString, CommandType.Text, sql, pms));
                return result;
            }
        }

        



        public override int UpdateUserSumBal(int userId, double sumBal,int operate, DbTransaction tran)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@SumBal",sumBal),
                    new SqlParameter("@ID",userId)
                };

            
            string sql = "";
            if (operate == 1)
            {
                sql = "update act_User set SumBal =SumBal+@SumBal where ID=@ID";
            }
            else
            {
                sql = "update act_User set SumBal =SumBal-@SumBal where ID=@ID";
            }
            int result = SqlHelp.ExecuteNonQuery((SqlTransaction)tran, CommandType.Text, sql, pms);
            return result;
        }
      

        public override DataSet GetZoneServer(string gameId)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                return SqlHelper.ExecuteDataset(connection.ConnectionString, "BM_ZoneServer", new object[] { gameId });
            }
        }
        
        public override string act_Orders(tbOrdersEntity tbOrders)
        {
            string obj = "";
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.act_Order_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = tbOrders.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = tbOrders.ID;  //ID
                cmd.Parameters.Add("@SType", SqlDbType.VarChar).Value = "Order";
                cmd.Parameters.Add("@SeriaNo", SqlDbType.VarChar).Value = tbOrders.SeriaNo;

                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = tbOrders.Title;
                cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = tbOrders.Zone;
                cmd.Parameters.Add("@Server", SqlDbType.VarChar).Value = tbOrders.Server;
                cmd.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = tbOrders.RoleName;
                cmd.Parameters.Add("@unid", SqlDbType.VarChar).Value = tbOrders.unid;

                cmd.Parameters.Add("@ZoneID", SqlDbType.Int).Value = tbOrders.ZoneID;
                cmd.Parameters.Add("@ServerID", SqlDbType.Int).Value = tbOrders.ServerID;
                cmd.Parameters.Add("@Reward", SqlDbType.Int).Value = tbOrders.Reward;
                cmd.Parameters.Add("@TimeLimit", SqlDbType.Int).Value = tbOrders.TimeLimit;

                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = tbOrders.UserID;
                cmd.Parameters.Add("@ActivityID", SqlDbType.Int).Value = tbOrders.ActivityID;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = tbOrders.Status;
                cmd.Parameters.Add("@qf", SqlDbType.Int).Value = tbOrders.qf;

                cmd.Parameters.Add("@RegAmount", SqlDbType.Decimal).Value = tbOrders.RegAmount;
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = tbOrders.StartDate;  //CreateDate
                if (tbOrders.EndDate.HasValue)
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = tbOrders.EndDate;
                else
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;


                if (tbOrders.ResAmount!=null)
                    cmd.Parameters.Add("@ResAmount", SqlDbType.Decimal).Value = tbOrders.ResAmount;
                else
                    cmd.Parameters.Add("@ResAmount", SqlDbType.Decimal).Value = DBNull.Value;  
                Conn.Open();
                obj = cmd.ExecuteScalar().ToString();
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return obj;
        }

        /// <summary>
        /// 新增/删除/修改 tbAppointArbitration (tbAppointArbitration)
        /// </summary>
        /// <param name="fam">tbAppointArbitrationEntity实体类(tbAppointArbitration)</param>
        /// <param name="tran">tbAppointArbitration事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override string act_Orders(tbOrdersEntity tbOrders, DbTransaction tran)
        {
            string obj = "";

            SqlCommand cmd = new SqlCommand("dbo.act_Order_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = tbOrders.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = tbOrders.ID;  //ID
            cmd.Parameters.Add("@SType", SqlDbType.VarChar).Value = "Order";
            cmd.Parameters.Add("@SeriaNo", SqlDbType.VarChar).Value = tbOrders.SeriaNo;

            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = tbOrders.Title;
            cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = tbOrders.Zone;
            cmd.Parameters.Add("@Server", SqlDbType.VarChar).Value = tbOrders.Server;
            cmd.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = tbOrders.RoleName;
            cmd.Parameters.Add("@unid", SqlDbType.VarChar).Value = tbOrders.unid;

            cmd.Parameters.Add("@ZoneID", SqlDbType.Int).Value = tbOrders.ZoneID;
            cmd.Parameters.Add("@ServerID", SqlDbType.Int).Value = tbOrders.ServerID;
            cmd.Parameters.Add("@Reward", SqlDbType.Decimal).Value = tbOrders.Reward;
            cmd.Parameters.Add("@TimeLimit", SqlDbType.Int).Value = tbOrders.TimeLimit;

            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = tbOrders.UserID;
            cmd.Parameters.Add("@ActivityID", SqlDbType.Int).Value = tbOrders.ActivityID;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = tbOrders.Status;
            cmd.Parameters.Add("@qf", SqlDbType.Int).Value = tbOrders.qf;
            cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = tbOrders.ModuleID;
            cmd.Parameters.Add("@OddEven", SqlDbType.Int).Value = tbOrders.OddEven;

            cmd.Parameters.Add("@RegAmount", SqlDbType.Decimal).Value = tbOrders.RegAmount;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = tbOrders.StartDate;  //CreateDate
            if (tbOrders.EndDate.HasValue)
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = tbOrders.EndDate;
            else
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;


            if (tbOrders.ResAmount != null)
                cmd.Parameters.Add("@ResAmount", SqlDbType.Decimal).Value = tbOrders.ResAmount;
            else
                cmd.Parameters.Add("@ResAmount", SqlDbType.Decimal).Value = DBNull.Value;

            obj = cmd.ExecuteScalar().ToString();
            cmd.Dispose();
            return obj;
        }

        public override void OperateTbMoneyChange(tbMoneyChangeEntity tbMoneyChange, DbTransaction tran)
        {
            SqlCommand cmd = new SqlCommand("dbo.tbMoneyChange_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = tbMoneyChange.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = tbMoneyChange.UserID;
            cmd.Parameters.Add("@SType", SqlDbType.VarChar).Value = "UserMoneyChange";
            cmd.Parameters.Add("@SerialNo", SqlDbType.VarChar).Value = tbMoneyChange.SerialNo;
            cmd.Parameters.Add("@ChangeType", SqlDbType.Int).Value = tbMoneyChange.ChangeType;
            cmd.Parameters.Add("@PreBal", SqlDbType.Decimal).Value = tbMoneyChange.PreBal;
            cmd.Parameters.Add("@ChangeBal", SqlDbType.Decimal).Value = tbMoneyChange.ChangeBal;
            cmd.Parameters.Add("@CurBal", SqlDbType.Decimal).Value = tbMoneyChange.CurBal;
            cmd.Parameters.Add("@ChangeDate", SqlDbType.DateTime).Value = tbMoneyChange.ChangeDate;
            cmd.Parameters.Add("@RelaSerialNo", SqlDbType.VarChar).Value = tbMoneyChange.RelaSerialNo;
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = tbMoneyChange.Comment;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="tbMoneyChange"></param>
        /// <param name="tran"></param>
        public void OperateTbRecharge(tbRechargeEntity tbRecharge, DbTransaction tran)
        {
            SqlCommand cmd = new SqlCommand("dbo.tbRecharge_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = tbRecharge.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = tbRecharge.UserID;
            cmd.Parameters.Add("@SType", SqlDbType.VarChar).Value = "UserReCharge";
            cmd.Parameters.Add("@SerialNo", SqlDbType.VarChar).Value =tbRecharge.SerialNo;
            cmd.Parameters.Add("@ExChargeNo", SqlDbType.VarChar).Value = tbRecharge.ExChargeNo;
            cmd.Parameters.Add("@Bal", SqlDbType.Decimal).Value = tbRecharge.Bal;
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = tbRecharge.CreateDate;
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = tbRecharge.Comment;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public override void OperateUserZoneServer(tsUserZoneServerEntity tsUserZoneServe, DbTransaction tran)
        {
            SqlCommand cmd = new SqlCommand("dbo.act_UserZoneServer_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = tsUserZoneServe.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = tsUserZoneServe.UserID;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = tsUserZoneServe.ID;
            cmd.Parameters.Add("@GameID", SqlDbType.Int).Value = tsUserZoneServe.GameID;
            cmd.Parameters.Add("@ZoneID", SqlDbType.Int).Value = tsUserZoneServe.ZoneID;
            cmd.Parameters.Add("@ServerID", SqlDbType.Int).Value = tsUserZoneServe.ServerID;
            cmd.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = tsUserZoneServe.RoleName;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        void OperateZhanKengOrders(tbZhanKengOrders zhanKengOrders, DbTransaction tran)
        {
            SqlCommand cmd = new SqlCommand("dbo.act_ZhanKeng_Orders_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = zhanKengOrders.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = zhanKengOrders.ID;
            cmd.Parameters.Add("@Pit", SqlDbType.Int).Value = zhanKengOrders.Pit;
            cmd.Parameters.Add("@Z_SeriaNo", SqlDbType.VarChar).Value = zhanKengOrders.Z_SeriaNo;
            cmd.Parameters.Add("@O_SeriaNo", SqlDbType.VarChar).Value = zhanKengOrders.O_SeriaNo;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        /// <summary>
        /// 新增/删除/修改 tsUser (用户)  登录时注册
        /// </summary>
        /// <param name="fam">tsUserEntity实体类(用户)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override DataSet act_UserInsertUpdateDelete(tsUserEntity fam)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@DataTable_Action_",fam.DataTable_Action_.ToString()),
                    new SqlParameter("@ID", fam.ID),
                    new SqlParameter("@Figureurl",fam.Figureurl),
                    new SqlParameter("@UID",fam.UID),
                    new SqlParameter("@Nickname", fam.Nickname),
                    new SqlParameter("@LoginID",fam.LoginID),
                    new SqlParameter("@Pass",fam.Pass),
                    new SqlParameter("@Email",fam.Email),
                    new SqlParameter("@PayPass",fam.PayPass),
                    new SqlParameter("@BindMobile", fam.BindMobile),
                    new SqlParameter("@Sex",fam.Sex),
                    new SqlParameter("@SumBal",fam.SumBal),
                    new SqlParameter("@CreateDate", fam.CreateDate),
                    new SqlParameter("@Status",fam.Status),
                    new SqlParameter("@OpenID",fam.OpenID)
                  };
                return SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.StoredProcedure, "act_User_InsertUpdateDelete", pms);
            }
        }

        int act_UserInsertUpdateDelete(tsUserEntity fam, DbTransaction tran)
        {
            SqlCommand cmd = new SqlCommand("dbo.act_User_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;
            cmd.Parameters.Add("@Figureurl", SqlDbType.VarChar).Value = fam.Figureurl;
            cmd.Parameters.Add("@UID", SqlDbType.VarChar).Value = fam.UID;
            cmd.Parameters.Add("@Nickname", SqlDbType.VarChar).Value = fam.Nickname;
            cmd.Parameters.Add("@LoginID", SqlDbType.VarChar).Value = fam.LoginID;
            cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = fam.Pass;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = fam.Email;
            cmd.Parameters.Add("@PayPass", SqlDbType.VarChar).Value = fam.PayPass;
            cmd.Parameters.Add("@BindMobile", SqlDbType.VarChar).Value = fam.BindMobile;
            cmd.Parameters.Add("@Sex", SqlDbType.Bit).Value = fam.Sex;
            cmd.Parameters.Add("@SumBal", SqlDbType.Decimal).Value = fam.SumBal;
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = fam.Status;
            cmd.Parameters.Add("@OpenID", SqlDbType.VarChar).Value = fam.OpenID;
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return result;
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="errorMsg">错误信息</param>
        public override void InsertErrorLog(string type, string content)
        {
            using (SqlConnection connection = GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@type",type),
                    new SqlParameter("@ErrorMsg",content),
                    new SqlParameter("@CreateDate",DateTime.Now)
                };
                string sql = "insert into dbo.tsErrorLog(type, ErrorMsg, CreateDate) values(@type, @ErrorMsg, @CreateDate)";
                SqlHelper.ExecuteNonQuery(connection.ConnectionString, CommandType.Text, sql, pms);
            }
        }

        /// <summary>
        /// 根据订单编号查找订单详情
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public override DataTable GetOrdersById(int id,int userId)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@ID",id),
                    new SqlParameter("@UserID",userId)
                };

                string sql = "select OddEven,act_Order.ModuleID,act_Order.ID,SeriaNo,RoleName,[Server],Zone, Title,CONVERT(varchar(20), StartDate, 120) as StartDate,content,ImageUrl,RegAmount,ResAmount,act_Order.reward,CONVERT(varchar(20), EndDate, 120) as EndDate,act_Order.ActivityID,act_Order.Status,FeedBack,tsDict.Value,act_Order.TimeLimit from dbo.act_Order inner join dbo.act_Activity on act_Order.ActivityID=act_Activity.ID and act_Order.ModuleID=act_Activity.ModuleID inner join dbo.tsDict on act_Order.Status=tsDict.Kind and tsDict.[Key]=1013 where act_Order.ID=@ID and UserID=@UserID";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public override DataTable GetOrdersBySeriaNo(string seriaNo, int userId)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@SeriaNo",seriaNo),
                    new SqlParameter("@UserID",userId)
                };

                string sql = "select OddEven,act_Order.ModuleID,act_Order.ID,SeriaNo,RoleName,[Server],Zone, Title,CONVERT(varchar(20), StartDate, 120) as StartDate,content,ImageUrl,RegAmount,ResAmount,act_Order.reward,CONVERT(varchar(20), EndDate, 120) as EndDate,act_Order.ActivityID,act_Order.Status,FeedBack,tsDict.Value,act_Order.TimeLimit from dbo.act_Order inner join dbo.act_Activity on act_Order.ActivityID=act_Activity.ID and act_Order.ModuleID=act_Activity.ModuleID inner join dbo.tsDict on act_Order.Status=tsDict.Kind and tsDict.[Key]=1013 where act_Order.SeriaNo=@SeriaNo and UserID=@UserID";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public override DataTable GetOrdersBySeriaNo(string seriaNo)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@SeriaNo",seriaNo)
                };

                string sql = "select ID, SeriaNo, Title, ZoneID, Zone, ServerID, Server, RoleName, Reward, TimeLimit, RegAmount, ResAmount, StartDate, EndDate, UserID, ActivityID, Status, unid, qf,ModuleID,OddEven from dbo.act_Order" +
                " where SeriaNo=@SeriaNo";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 检查验证码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public override DataTable CheckMobileToken(string mobile)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@Mobile",mobile)
                };

                string sql = "select VerifyCode,SerialNo from dbo.tbMobileToken where Mobile=@Mobile and IsVerify=0 and SmsStyle=10 and UseType=17 order by CreateDate desc";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

       /// <summary>
       /// 得到正在进行并且时限已过的订单(定时器自动查询)
       /// </summary>
       /// <returns></returns>
        public override DataTable GetOrdersByStatus()
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                string sql = "select ID, SeriaNo, Title, ZoneID, Zone, ServerID, Server, RoleName, Reward, TimeLimit, RegAmount, ResAmount, CONVERT(varchar(20), StartDate, 120) as StartDate, EndDate, UserID, ActivityID, Status, unid, qf from act_Order where Status=16 and TimeLimit<=DATEDIFF(hh,StartDate,getdate()) ";
                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public override int baoming_zhifu(tbOrdersEntity Orders, tbMoneyChangeEntity tbMoneyChange, tsUserZoneServerEntity tsUserZoneServer,tlOperateEntity fam )
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                int result = 0;
                try
                {
                    //插入订单表
                    string seriaNo = act_Orders(Orders, tran);

                    //用户余额的修改
                    UpdateUserSumBal(Orders.UserID, Orders.RegAmount, 0, tran);

                    //流水表的记录
                    tbMoneyChange.RelaSerialNo = seriaNo;
                    OperateTbMoneyChange(tbMoneyChange, tran);

                    //用户区服的判断
                    OperateUserZoneServer(tsUserZoneServer, tran);

                    //记录操作日志
                    tlOperateInsertUpdateDelete(fam, tran);

                    result = 1;
                    tran.Commit();

                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    tran.Dispose();
                }

                return result;
            }
        }

        /// <summary>
        /// 占坑模式的报名
        /// </summary>
        /// <param name="SeriaNo1"></param>
        /// <param name="Pit"></param>
        /// <param name="Orders"></param>
        /// <param name="tbMoneyChange"></param>
        /// <param name="tsUserZoneServer"></param>
        /// <param name="fam"></param>
        /// <returns></returns>
        public override int baomingzk_zhifu(string SeriaNo1,string Pit, tbOrdersEntity Orders, tbMoneyChangeEntity tbMoneyChange, tsUserZoneServerEntity tsUserZoneServer, tlOperateEntity fam)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                int result = 0;
                try
                {
                    //插入订单表
                    string seriaNo = act_Orders(Orders, tran);

                    string[] arr = Pit.Split(',');
                    tbZhanKengOrders zhankengOrders = null;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        zhankengOrders = new tbZhanKengOrders();
                        zhankengOrders.DataTable_Action_ = FrameWork.DataTable_Action.Insert;
                        zhankengOrders.ID = 0;
                        zhankengOrders.O_SeriaNo = seriaNo;
                        zhankengOrders.Z_SeriaNo = SeriaNo1;
                        zhankengOrders.Pit = Convert.ToInt32(arr[i]);
                        OperateZhanKengOrders(zhankengOrders, tran);
                    }

                    //用户余额的修改
                    UpdateUserSumBal(Orders.UserID, Orders.RegAmount, 0, tran);

                    //流水表的记录
                    tbMoneyChange.RelaSerialNo = seriaNo;
                    OperateTbMoneyChange(tbMoneyChange, tran);

                    //用户区服的判断
                    OperateUserZoneServer(tsUserZoneServer, tran);

                    //记录操作日志
                    tlOperateInsertUpdateDelete(fam, tran);

                    result = 1;
                    tran.Commit();

                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    tran.Dispose();
                }

                return result;
            }
        }

        /// <summary>
        /// 用户充值
        /// </summary>
        /// <param name="tbMoneyChange"></param>
        /// <param name="tbRecharge"></param>
        /// <param name="fam"></param>
        /// <returns></returns>
        public override int Recharge(tbMoneyChangeEntity tbMoneyChange, tbRechargeEntity tbRecharge, tlOperateEntity fam)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                int result = 0;
                try
                {
                    //修改用户金额
                    UpdateUserSumBal(tbMoneyChange.UserID, tbMoneyChange.ChangeBal, 1, tran);
                    //流水表记录
                    OperateTbMoneyChange(tbMoneyChange, tran);
                    //充值表记录
                    OperateTbRecharge(tbRecharge, tran);
                    //操作日志记录
                    tlOperateInsertUpdateDelete(fam, tran);

                    result = 1;
                    tran.Commit();

                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    tran.Dispose();
                }

                return result;
            }
        }

        public override DataTable GetUserById(int id)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@ID",id)
                };

                string sql = "select ID, Figureurl, UID, Nickname, LoginID, Pass, PayPass, BindMobile, Sex, SumBal, Email, CreateDate,QQ from dbo.act_User where ID =@ID";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql, pms);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 最近获得的奖励
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public override DataTable GetTopOrders(int top)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                string sql = "select top " + top + " Title,ResAmount,RegAmount,UID,Nickname,b.Figureurl,CONVERT(varchar(5), StartDate, 24) as StartDate,CONVERT(varchar(5), EndDate, 24) as EndDate from dbo.act_Order a left join dbo.act_User b on a.UserID=b.ID where a.Status in(14,17) and ResAmount <> 0 order by a.ID desc";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 最近参与报名的订单
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public override DataTable GetTopOrdersByBaoMing(int top)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                string sql = "select top " + top + " Title,ResAmount,RegAmount,UID,Nickname,b.Figureurl,CONVERT(varchar(5), StartDate, 24) as StartDate,CONVERT(varchar(5), EndDate, 24) as EndDate from dbo.act_Order a left join dbo.act_User b on a.UserID=b.ID where a.Status=16 order by a.ID desc";

                DataSet set = SqlHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, sql);
                if (set != null)
                {
                    return set.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public override DataSet OrderList(QueryParam qp)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                return SqlHelper.ExecuteDataset(connection.ConnectionString, "HT_OrderList", new object[] { qp.PageIndex, qp.PageSize, qp.Where, qp.Orderfld, qp.OrderType });
            }
        }

        /// <summary>
        /// 修改订单表
        /// </summary>
        /// <param name="SeriaNo">订单编号</param>
        /// <param name="operate">1：比赛成功  0：比赛失败</param>
        /// <param name="tran"></param>
        /// <returns></returns>
        int UpdateOrders(string SeriaNo, double ResAmount, int operate,string battleTime, DateTime curTime, SqlTransaction tran)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@ResAmount",ResAmount),
                    new SqlParameter("@EndDate",curTime),
                    new SqlParameter("@SeriaNo",SeriaNo),
                    new SqlParameter("@BattleTime",battleTime)
            };
            string sql = "";
            if (operate == 1)
            {
                sql = "update dbo.act_Order set ResAmount=@ResAmount,EndDate=@EndDate,Status=17,BattleDate=@BattleTime where SeriaNo=@SeriaNo";
            }
            else
            {
                sql = "update dbo.act_Order set ResAmount=0,EndDate=@EndDate,Status=17,BattleDate=@BattleTime where SeriaNo=@SeriaNo";
            }
            int result = SqlHelp.ExecuteNonQuery(tran, CommandType.Text, sql, pms);
            return result;
        }

        /// <summary>
        /// 乱斗模式订单待结算比赛
        /// </summary>
        /// <param name="SeriaNo"></param>
        /// <param name="battleTime"></param>
        /// <param name="curTime"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        int UpdateOrders(string SeriaNo, string battleTime, DateTime curTime, SqlTransaction tran)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@EndDate",curTime),
                    new SqlParameter("@SeriaNo",SeriaNo),
                    new SqlParameter("@BattleTime",battleTime)
            };
        
            string sql = "update dbo.act_Order set EndDate=@EndDate,Status=13,BattleDate=@BattleTime where SeriaNo=@SeriaNo";
            int result = SqlHelp.ExecuteNonQuery(tran, CommandType.Text, sql, pms);
            return result;
        }

        /// <summary>
        /// 占坑模式订单待结算比赛
        /// </summary>
        /// <param name="status"></param>
        /// <param name="SeriaNo"></param>
        /// <param name="battleTime"></param>
        /// <param name="curTime"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        int UpdateOrders(int status, string SeriaNo, string battleTime, DateTime curTime, SqlTransaction tran)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@EndDate",curTime),
                    new SqlParameter("@SeriaNo",SeriaNo),
                    new SqlParameter("@BattleTime",battleTime),
                    new SqlParameter("@Status",status)
            };

            string sql = "update dbo.act_Order set EndDate=@EndDate,Status=@Status,BattleDate=@BattleTime where SeriaNo=@SeriaNo";
            int result = SqlHelp.ExecuteNonQuery(tran, CommandType.Text, sql, pms);
            return result;
        }

        /// <summary>
        /// 记录占坑订单表的输赢
        /// </summary>
        /// <param name="status"></param>
        /// <param name="SeriaNo"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        int UpdateZhanKengOrders(int status, string SeriaNo, SqlTransaction tran)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@SeriaNo",SeriaNo),
                    new SqlParameter("@Status",status)
            };

            string sql = "update dbo.act_ZhanKeng_Orders set IsWin=@Status where O_SeriaNo=@SeriaNo";
            int result = SqlHelp.ExecuteNonQuery(tran, CommandType.Text, sql, pms);
            return result;
        }

        /// <summary>
        /// 二次判决
        /// </summary>
        /// <param name="SeriaNo"></param>
        /// <param name="ResAmount"></param>
        /// <param name="operate"></param>
        /// <param name="curTime"></param>
        /// <param name="feedback"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        int UpdateOrders(string SeriaNo, double ResAmount, int operate, DateTime curTime, string feedback, SqlTransaction tran)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@ResAmount",ResAmount),
                    new SqlParameter("@EndDate",curTime),
                    new SqlParameter("@SeriaNo",SeriaNo),
                    new SqlParameter("@FeedBack",feedback)
            };
            string sql = "";
            if (operate == 1)
            {
                sql = "update dbo.act_Order set ResAmount=@ResAmount,Status=14,FeedBack=@FeedBack where SeriaNo=@SeriaNo";
            }
            else
            {
                sql = "update dbo.act_Order set ResAmount=0,Status=14,FeedBack=@FeedBack where SeriaNo=@SeriaNo";
            }
            int result = SqlHelp.ExecuteNonQuery(tran, CommandType.Text, sql, pms);
            return result;
        }

        /// <summary>
        /// 修改用户金额
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="sumBal">金额</param>
        /// <param name="operate">1：比赛成功 增加金额  0：比赛失败 减少金额</param>
        /// <param name="tran"></param>
        /// <returns></returns>
        int UpdateUserSumBal(int userId, double RegAmount, double ResAmount, int operate, SqlTransaction tran)
        {
            string sql = "";
            SqlParameter[] pms = null;
            if (operate == 1)
            {
                pms = new SqlParameter[] {
                    new SqlParameter("@SumBal",ResAmount),
                    new SqlParameter("@ID",userId)
                };
                sql = "update act_User set SumBal =SumBal+@SumBal where ID=@ID";
            }
            else
            {
                pms = new SqlParameter[] {
                    new SqlParameter("@SumBal",RegAmount),
                    new SqlParameter("@ID",userId)
                };
                sql = "update act_User set SumBal =SumBal-@SumBal where ID=@ID";
            }
            int result = SqlHelp.ExecuteNonQuery(tran, CommandType.Text, sql, pms);
            return result;
        }


        /// <summary>
        /// 修改订单状态（问题订单）
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="status"></param>
        /// <param name="seriaNo"></param>
        /// <returns></returns>
        public override int UpdateOrdersStatus(string comment, int status, string seriaNo)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@Comment",comment),
                    new SqlParameter("@Status",status),
                    new SqlParameter("@SeriaNo",seriaNo)
                };
                string sql = "update act_Order set Comment=@Comment,Status=@Status where SeriaNo=@SeriaNo";
                int result = SqlHelp.ExecuteNonQuery(connection.ConnectionString, CommandType.Text, sql, pms);
                return result;
            }
        }

        /// <summary>
        /// 修改兑换状态
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="status"></param>
        /// <param name="seriaNo"></param>
        /// <returns></returns>
        public override int UpdateExchangeStatus(string comment, int status, string seriaNo)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@Comment",comment),
                    new SqlParameter("@Status",status),
                    new SqlParameter("@SerialNo",seriaNo)
                };
                string sql = "update dbo.act_duihuan set status=@Status,Comment=@Comment where SerialNo=@SerialNo";
                int result = SqlHelp.ExecuteNonQuery(connection.ConnectionString, CommandType.Text, sql, pms);
                return result;
            }
        }

        /// <summary>
        /// 修改订单状态（问题订单）
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="status"></param>
        /// <param name="seriaNo"></param>
        /// <returns></returns>
        int UpdateOrdersStatus(string comment, int status, string seriaNo,SqlTransaction tran)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@Comment",comment),
                    new SqlParameter("@Status",status),
                    new SqlParameter("@SeriaNo",seriaNo)
                };
            string sql = "update act_Order set Comment=@Comment,Status=@Status where SeriaNo=@SeriaNo";
            int result = SqlHelp.ExecuteNonQuery(tran, CommandType.Text, sql, pms);
            return result;
        }

        public override DataTable GetUserByOpenId(string openId)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@OpenID",openId)
                };
                string sql = "select Nickname,UID,a.ID,b.ID as RightLockID from dbo.act_User a left join tsRightLock b on a.ID=b.UserID and LockType=10 and GETDATE()>=StartDate and GETDATE()<=EndDate" +
                             " where OpenID=@OpenID";
                DataTable dt = SqlHelp.ExecuteDataTable(connection.ConnectionString, CommandType.Text, sql, pms);
                return dt;
            }
        }

        int UpdateMobileTokenStatus(string seriaNo, SqlTransaction tran)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@SerialNo",seriaNo)
                };
            string sql = "update dbo.tbMobileToken set IsVerify=1 where SerialNo=@SerialNo";
            int result = SqlHelp.ExecuteNonQuery(tran, CommandType.Text, sql, pms);
            return result;
        }

        /// <summary>
        /// 赠送乐币
        /// </summary>
        /// <param name="fam"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        string GiveInsertUpdateDelete(tbGiveEntity fam, DbTransaction tran)
        {
            SqlCommand cmd = new SqlCommand("dbo.tbGive_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            cmd.Parameters.Add("@SerialNo", SqlDbType.VarChar).Value = fam.SerialNo;
            cmd.Parameters.Add("@GiveID", SqlDbType.Int).Value = fam.GiveID;  //用户ID
            cmd.Parameters.Add("@AcceptID", SqlDbType.Int).Value = fam.AcceptID;  //操作类别
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //创建时间
            cmd.Parameters.Add("@Money", SqlDbType.Decimal).Value = fam.Money;
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;
            cmd.Parameters.Add("@SType", SqlDbType.VarChar).Value = "GiveCoin";
            object obj = cmd.ExecuteScalar();
            cmd.Dispose();

            return obj.ToString();
        }

        /// <summary>
        /// 插入短信
        /// </summary>
        /// <param name="fam"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public override int MobileTokenInsertUpdateDelete(tbMobileTokenEntity fam)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                return SqlHelper.ExecuteNonQuery(connection.ConnectionString, "tbMobileToken_InsertUpdateDelete", new object[] { "MobileToken",fam.SerialNo,fam.UserID,fam.Mobile,fam.VerifyCode,fam.CreateDate,fam.IsVerify,fam.SmsStyle,fam.UseType,fam.DataTable_Action_.ToString() });
            }
        }

        public override int UserSendQuestion(string comment, int status, string seriaNo, tlOperateEntity fam) {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                int result = 0;
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    UpdateOrdersStatus(comment, status, seriaNo, tran);
                    //记录操作日志
                    tlOperateInsertUpdateDelete(fam, tran);
                    result = 1;
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    tran.Dispose();
                }
                return result;
            }
        }


        /// <summary>
        /// 比赛结果
        /// </summary>
        /// <param name="SeriaNo">订单号</param>
        /// <param name="userId">用户编号</param>
        /// <param name="sumBal">金额</param>
        /// <param name="status">状态 成功：1  失败：0</param>
        /// <param name="tbMoneyChange">流水表</param>
        /// <param name="fam">系统操作表</param>
        public override void MacthResult(string SeriaNo, int userId, double RegAmount, double ResAmount, int status,string battleTime, DateTime curTime, tbMoneyChangeEntity tbMoneyChange, tlOperateEntity fam)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    if (status == 1)
                    {
                        //修改订单表
                        UpdateOrders(SeriaNo, ResAmount, status,battleTime, curTime, tran);
                        //修改用户金额
                        UpdateUserSumBal(userId, RegAmount, ResAmount, status, tran);
                        //记录流水表
                        OperateTbMoneyChange(tbMoneyChange, tran);
                        //记录操作日志
                        tlOperateInsertUpdateDelete(fam, tran);
                    }
                    else
                    {
                        //修改订单表
                        UpdateOrders(SeriaNo, ResAmount, status,battleTime, curTime, tran);
                        //记录流水表
                        OperateTbMoneyChange(tbMoneyChange, tran);
                        //记录操作日志
                        tlOperateInsertUpdateDelete(fam, tran);
                    }
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    tran.Dispose();
                }
            }
        }

        /// <summary>
        /// 乱斗模式待结算比赛
        /// </summary>
        /// <param name="SeriaNo"></param>
        /// <param name="battleTime"></param>
        /// <param name="curTime"></param>
        /// <param name="fam"></param>
        public override void LuanDouSuccessMatch(string SeriaNo, string battleTime, DateTime curTime, tlOperateEntity fam)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    //修改订单表
                    UpdateOrders(SeriaNo, battleTime, curTime, tran);

                    //记录操作日志
                    tlOperateInsertUpdateDelete(fam, tran);
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    tran.Dispose();
                }
            }
        }

        /// <summary>
        /// 占坑模式待结算比赛
        /// </summary>
        /// <param name="status"></param>
        /// <param name="SeriaNo"></param>
        /// <param name="battleTime"></param>
        /// <param name="curTime"></param>
        /// <param name="fam"></param>
        public override void ZhanKengSuccessMatch(int status, string SeriaNo, string battleTime, DateTime curTime, tlOperateEntity fam)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    //修改占坑订单表
                    UpdateZhanKengOrders(1, SeriaNo, tran);

                    //修改订单表
                    UpdateOrders(status,SeriaNo, battleTime, curTime, tran);

                    //记录操作日志
                    tlOperateInsertUpdateDelete(fam, tran);
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    tran.Dispose();
                }
            }
        }

        /// <summary>
        /// 二次判决
        /// </summary>
        /// <param name="SeriaNo"></param>
        /// <param name="userId"></param>
        /// <param name="RegAmount"></param>
        /// <param name="ResAmount"></param>
        /// <param name="status"></param>
        /// <param name="curTime"></param>
        /// <param name="feedback"></param>
        /// <param name="tbMoneyChange"></param>
        /// <param name="fam"></param>
        public override void MacthResult(string SeriaNo, int userId, double RegAmount, double ResAmount, int status, DateTime curTime,string feedback, tbMoneyChangeEntity tbMoneyChange, tlOperateEntity fam)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    if (status == 1)
                    {
                        //修改订单表
                        UpdateOrders(SeriaNo, ResAmount, status, curTime, feedback, tran);
                        //修改用户金额
                        UpdateUserSumBal(userId, RegAmount, ResAmount, status, tran);
                        //记录流水表
                        OperateTbMoneyChange(tbMoneyChange, tran);
                        //记录操作日志
                        tlOperateInsertUpdateDelete(fam, tran);
                    }
                    else
                    {
                        //修改订单表
                        UpdateOrders(SeriaNo, ResAmount, status, curTime, feedback, tran);
                        //记录流水表
                        OperateTbMoneyChange(tbMoneyChange, tran);
                        //记录操作日志
                        tlOperateInsertUpdateDelete(fam, tran);
                    }
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    tran.Dispose();
                }
            }
        }

        /// <summary>
        /// 赠送乐币
        /// </summary>
        /// <param name="money"></param>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        /// <param name="tbMoneyChange"></param>
        /// <param name="tbMoneyChange1"></param>
        /// <param name="fam"></param>
        /// <returns></returns>
        public override int givelecoin(double money, int userId, int id,tbGiveEntity tbGive, tbMoneyChangeEntity tbMoneyChange, tbMoneyChangeEntity tbMoneyChange1, tlOperateEntity fam)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                int result = 0;
                try
                {
                    //插入赠送表
                    string serialNo= GiveInsertUpdateDelete(tbGive, tran);

                    //更新赠与用户的乐币
                    UpdateUserSumBal(userId, money, 0, tran);

                    //更新收到用户的乐币
                    UpdateUserSumBal(id, money, 1, tran);

                    //插入流水表，减少赠与用户的乐币
                    tbMoneyChange.RelaSerialNo = serialNo;
                    OperateTbMoneyChange(tbMoneyChange, tran);

                    //插入流水表，增加收到用户的乐币
                    tbMoneyChange1.RelaSerialNo = serialNo;
                    OperateTbMoneyChange(tbMoneyChange1, tran);

                    //记录操作日志
                    tlOperateInsertUpdateDelete(fam, tran);

                    result = 1;
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    tran.Dispose();
                }

                return result;
            }
        }


        public override int Gegister(tsUserEntity tsUser, tlOperateEntity tlOperate, tlLoginEntity tlLogin, string tbMobileSerialNo,out int userId) {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                int result = 0;
                try
                {
                    //插入用户表
                    int id= act_UserInsertUpdateDelete(tsUser, tran);

                    //插入操作日志表
                    tlOperate.UserID = id;
                    tlOperateInsertUpdateDelete(tlOperate, tran);

                    //插入登录日志表
                    tlLogin.UserID = id;
                    tlLoginInsertUpdateDelete(tlLogin, tran);

                    //修改验证码表，表示已使用该验证码
                    UpdateMobileTokenStatus(tbMobileSerialNo, tran);

                    result = 1;
                    userId = id;
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    tran.Dispose();
                }

                return result;
            }
        }

        public override List<tsRightLockAutoEntity> tsRightLockAutoList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<tsRightLockAutoEntity> mypd = new PopulateDelegate<tsRightLockAutoEntity>(base.Populatesys_tsRightLockAutoEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }


        public override DataSet luandou(string timeArea, string activityID)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                return SqlHelper.ExecuteDataset(connection.ConnectionString, "BM_LuanDou", new object[] { timeArea, activityID });
            }
        }

        public override DataSet luckyzk()
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                return SqlHelper.ExecuteDataset(connection.ConnectionString, "BM_Luckyzk", new object[] { });
            }
        }
 
	#endregion

        #region 小程序
        public override DataSet SendLevelOrder(int UserID, int PageIndex, int PageSize, string Where)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                return SqlHelper.ExecuteDataset(connection.ConnectionString, "BM_SendLevelOrder", new object[] { UserID, PageIndex, PageSize, Where });
            }
        }

        public override DataSet ReceiveLevelOrder(int UserID, int PageIndex, int PageSize, string Where)
        {
            using (SqlConnection connection = this.GetSqlConnection())
            {
                return SqlHelper.ExecuteDataset(connection.ConnectionString, "BM_ReceiveLevelOrder", new object[] { UserID, PageIndex, PageSize, Where });
            }
        }
      

        #region "tbQuestions (题库) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 tbQuestions (题库)
        /// </summary>
        /// <param name="fam">tsMemberEntity实体类(用户成员)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbQuestionsInsertUpdateDelete(tbQuestionsEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.sys_QuestionsInsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@Difficulty", SqlDbType.Int).Value = fam.Difficulty;
                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = fam.Title;
                cmd.Parameters.Add("@A", SqlDbType.VarChar).Value = fam.A;
                cmd.Parameters.Add("@B", SqlDbType.VarChar).Value = fam.B;
                cmd.Parameters.Add("@C", SqlDbType.VarChar).Value = fam.C;
                cmd.Parameters.Add("@D", SqlDbType.VarChar).Value = fam.D;
                cmd.Parameters.Add("@SubjectType", SqlDbType.Int).Value = fam.SubjectType;
                cmd.Parameters.Add("@Answer", SqlDbType.VarChar).Value = fam.Answer;
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 新增/删除/修改 tsMember (用户成员)
        /// </summary>
        /// <param name="fam">tsMemberEntity实体类(用户成员)</param>
        /// <param name="tran">tsMember事务</param>        
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 tbQuestionsInsertUpdateDelete(tbQuestionsEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.tbQuestions_InsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@Difficulty", SqlDbType.Int).Value = fam.Difficulty;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = fam.Title;
            cmd.Parameters.Add("@A", SqlDbType.VarChar).Value = fam.A;
            cmd.Parameters.Add("@B", SqlDbType.VarChar).Value = fam.B;
            cmd.Parameters.Add("@C", SqlDbType.VarChar).Value = fam.C;
            cmd.Parameters.Add("@D", SqlDbType.VarChar).Value = fam.D;
            cmd.Parameters.Add("@SubjectType", SqlDbType.Int).Value = fam.SubjectType;
            cmd.Parameters.Add("@Answer", SqlDbType.VarChar).Value = fam.Answer;

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }



        /// <summary>
        /// 返回tsMemberEntity实体类的List对象 (用户成员)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsMemberEntity实体类的List对象(用户成员)</returns>
        public override List<tbQuestionsEntity> tbQuestionsList(QueryParam qp, out int RecordCount)
        {
            return tbQuestionsList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tsMemberEntity实体类的List对象 (用户成员)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsMember事务</param>
        /// <returns>tsMemberEntity实体类的List对象(用户成员)</returns>
        public override List<tbQuestionsEntity> tbQuestionsList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbQuestionsEntity> mypd = new PopulateDelegate<tbQuestionsEntity>(base.PopulatetsQuestionsEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbDifficulty (困难模式) - SQLDataProvider"



        /// <summary>
        /// 返回tsGameEntity实体类的List对象 (游戏)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsGameEntity实体类的List对象(游戏)</returns>
        public override List<tbDifficultyEntity> tbDifficultyList(QueryParam qp, out int RecordCount)
        {
            return tbDifficultyList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tsGameEntity实体类的List对象 (游戏)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsGame事务</param>
        /// <returns>tsGameEntity实体类的List对象(游戏)</returns>
        public override List<tbDifficultyEntity> tbDifficultyList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbDifficultyEntity> mypd = new PopulateDelegate<tbDifficultyEntity>(base.PopulatetbDifficultyEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }
        #endregion


        #region "tbSubject (类别) - SQLDataProvider"



        /// <summary>
        /// 返回tsGameEntity实体类的List对象 (游戏)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsGameEntity实体类的List对象(游戏)</returns>
        public override List<tbSubjectEntity> tbSubjectList(QueryParam qp, out int RecordCount)
        {
            return tbSubjectList(qp, out RecordCount, null);
        }


        /// <summary>
        /// 返回tsGameEntity实体类的List对象 (游戏)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsGame事务</param>
        /// <returns>tsGameEntity实体类的List对象(游戏)</returns>
        public override List<tbSubjectEntity> tbSubjectList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbSubjectEntity> mypd = new PopulateDelegate<tbSubjectEntity>(base.PopulatetbSubjectEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }

        public override Int32 tbSubjectInsertUpdateDelete(tbSubjectEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.sys_AlbumTypeInsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = fam.Name;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = fam.OrderBy;
              
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        public override Int32 tbSubjectInsertUpdateDelete(tbSubjectEntity fam, DbTransaction tran)
        {
            Int32 rInt = -1;

            SqlCommand cmd = new SqlCommand("dbo.sys_AlbumTypeInsertUpdateDelete", (SqlConnection)tran.Connection);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.CommandType = CommandType.StoredProcedure;
            //设置参数
            cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = fam.Name;
            cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = fam.OrderBy;

            rInt = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return rInt;
        }

        public override List<tbAlbumEntity> tbAlbumList(QueryParam qp, out int RecordCount)
        {
            return tbAlbumList(qp, out RecordCount, null);
        }

        public override List<tbAlbumEntity> tbAlbumList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            PopulateDelegate<tbAlbumEntity> mypd = new PopulateDelegate<tbAlbumEntity>(base.PopulatetbAlbumEntity);
            if (tran == null)
            {
                return this.GetRecordList(mypd, qp, out RecordCount);
            }
            else
            {
                return this.GetRecordList(mypd, qp, out RecordCount, tran);
            }
        }


        public override Int32 tbAlbumInsertUpdateDelete(tbAlbumEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.sys_AlbumInsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@AlbumName", SqlDbType.VarChar).Value = fam.AlbumName;
                cmd.Parameters.Add("@AlbumUrl", SqlDbType.VarChar).Value = fam.AlbumUrl;
                cmd.Parameters.Add("@AlbumType", SqlDbType.Int).Value = fam.AlbumType;
                cmd.Parameters.Add("@Amounts", SqlDbType.Money).Value = fam.Amounts;
                cmd.Parameters.Add("@IsHot", SqlDbType.Int).Value = fam.IsHot;
                cmd.Parameters.Add("@IsNew", SqlDbType.Int).Value = fam.IsNew;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = fam.OrderBy;
                cmd.Parameters.Add("@Enable", SqlDbType.Int).Value = fam.Enable;

                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        public override List<tbImgEntity> tbImgList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<tbImgEntity> mypd = new PopulateDelegate<tbImgEntity>(base.PopulatetbImgEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }

        public override Int32 tbImgInsertUpdateDelete(tbImgEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.sys_ImgInsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ImageName", SqlDbType.VarChar).Value = fam.ImageName;
                cmd.Parameters.Add("@BgImageUrl", SqlDbType.VarChar).Value = fam.BgImageUrl;
                cmd.Parameters.Add("@ImageUrl", SqlDbType.VarChar).Value = fam.ImageUrl;
                cmd.Parameters.Add("@AlbumID", SqlDbType.Int).Value = fam.AlbumID;
                cmd.Parameters.Add("@ImageType", SqlDbType.Int).Value = fam.ImageType;
                cmd.Parameters.Add("@IsHot", SqlDbType.Int).Value = fam.IsHot;
                cmd.Parameters.Add("@Enable", SqlDbType.Int).Value = fam.Enable;
                cmd.Parameters.Add("@Delay", SqlDbType.Int).Value = fam.Delay;

                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 参数设置
        /// </summary>
        /// <param name="ImageId"></param>
        /// <returns></returns>
        public override DataTable tbFieldsList(string where)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@Where",where)
                };
            return SqlHelp.ExecuteDataTable(ConnString, CommandType.StoredProcedure, "HT_Fields", pms);
        }




        public override Int32 tbFieldsInsertUpdateDelete(tbFieldsEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.sys_FieldsInsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;
                cmd.Parameters.Add("@ImgID", SqlDbType.Int).Value = fam.ImgID;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = fam.Title;
                cmd.Parameters.Add("@PreValue", SqlDbType.NVarChar).Value = fam.PreValue;
                cmd.Parameters.Add("@Placeholder", SqlDbType.NVarChar).Value = fam.Placeholder;
                cmd.Parameters.Add("@Default", SqlDbType.NVarChar).Value = fam.Default;
                cmd.Parameters.Add("@SuffixValue", SqlDbType.NVarChar).Value = fam.SuffixValue;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = fam.Type;
                cmd.Parameters.Add("@Data", SqlDbType.NVarChar).Value = fam.Data;
                cmd.Parameters.Add("@FontSize", SqlDbType.Int).Value = fam.FontSize;
                cmd.Parameters.Add("@FontFamily", SqlDbType.NVarChar).Value = fam.FontFamily;
                cmd.Parameters.Add("@FontColor", SqlDbType.VarChar).Value = fam.FontColor;
                cmd.Parameters.Add("@FontStyle", SqlDbType.VarChar).Value = fam.FontStyle;
                cmd.Parameters.Add("@X", SqlDbType.Int).Value = fam.X;
                cmd.Parameters.Add("@Y", SqlDbType.Int).Value = fam.Y;
                cmd.Parameters.Add("@IsCircle", SqlDbType.Bit).Value = fam.IsCircle;
                cmd.Parameters.Add("@Width", SqlDbType.Int).Value = fam.Width;
                cmd.Parameters.Add("@Height", SqlDbType.Int).Value = fam.Height;
                cmd.Parameters.Add("@Rotate", SqlDbType.Int).Value = fam.Rotate;
                cmd.Parameters.Add("@IsRandom", SqlDbType.Int).Value = fam.IsRandom;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = fam.OrderBy;
                cmd.Parameters.Add("@BorderColor", SqlDbType.VarChar).Value = fam.BorderColor;
                cmd.Parameters.Add("@BorderSize", SqlDbType.Float).Value = fam.BorderSize;
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        public override List<tbFieldsEntity> tbFieldsList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<tbFieldsEntity> mypd = new PopulateDelegate<tbFieldsEntity>(base.PopulatetbFieldsEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }

        public override List<tbValuesEntity> tbValuesList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<tbValuesEntity> mypd = new PopulateDelegate<tbValuesEntity>(base.PopulatetbValuesEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }

        public override Int32 tbValuesInsertUpdateDelete(tbValuesEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.sys_ValuesInsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@FieldsID", SqlDbType.Int).Value = fam.FieldsID;
                cmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = fam.Value;
                cmd.Parameters.Add("@X", SqlDbType.Int).Value = fam.X;
                cmd.Parameters.Add("@Y", SqlDbType.Int).Value = fam.Y;
                cmd.Parameters.Add("@RelaID", SqlDbType.Int).Value = fam.RelaID;

                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        public override List<tbSubmissionEntity> tbSubmissionList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<tbSubmissionEntity> mypd = new PopulateDelegate<tbSubmissionEntity>(base.PopulatetbSubmissionEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }

        #endregion
        #endregion
    }
}
