/********************************************************************************
     File:																
            DataProvider.cs                         
     Description:
            抽象数据操作类
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
			2014/8/5 13:39:35
     History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.Common;
using FrameWork.Components;
using DLT.Components;


namespace DLT.Data
{
    /// <summary>
    /// 委托将DataReader转为实体类
    /// </summary>
    /// <param name="dr">记录集</param>
    /// <param name="Fileds">字段名列表</param>
    /// <returns></returns>
    public delegate T PopulateDelegate<T>(IDataReader dr,Dictionary<string,string> Fileds);

    /// <summary>
    /// 数据抽象类
    /// </summary>
    public abstract partial class DataProvider
    {
        #region MyRegion

        #region "DataProvider Instance"
        private static DataProvider _defaultInstance = null;
        static DataProvider()
        {
            DataProvider dataProvider;
            if (FrameWork.Common.GetDBType == "MsSql")
                dataProvider = new SqlDataProvider();
            else
                throw new ApplicationException("数据库配置不对！");
            _defaultInstance = dataProvider;
        }

        /// <summary>
        /// 数据访问抽象层实例
        /// </summary>
        /// <returns></returns>
        public static DataProvider Instance()
        {

            return _defaultInstance;
        }

        /// <summary>
        /// 获得数据库链接
        /// </summary>
        /// <returns></returns>
        public abstract DbConnection GetDdConnection();

        /// <summary>
        /// 数据访问抽象层实例
        /// </summary>
        /// <param name="strConn">数据库连接字符串</param>
        /// <returns></returns>
        public static DataProvider Instance(string strConn)
        {
            return new SqlDataProvider(strConn);
        }
        #endregion

        #region "tbAppointArbitration(tbAppointArbitration) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbAppointArbitrationEntity (tbAppointArbitration)
        /// </summary>
        /// <param name="fam">tbAppointArbitration实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbAppointArbitrationInsertUpdateDelete(tbAppointArbitrationEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbAppointArbitrationEntity (tbAppointArbitration)
        /// </summary>
        /// <param name="fam">tbAppointArbitration实体类</param>
        /// <param name="tran">tbAppointArbitration事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbAppointArbitrationInsertUpdateDelete(tbAppointArbitrationEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbAppointArbitrationEntity实体类的List对象 (tbAppointArbitration)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbAppointArbitrationEntity实体类的List对象(tbAppointArbitration)</returns>
        public abstract List<tbAppointArbitrationEntity> tbAppointArbitrationList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbAppointArbitrationEntity实体类的List对象 (tbAppointArbitration)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbAppointArbitration事务</param>
        /// <returns>tbAppointArbitrationEntity实体类的List对象(tbAppointArbitration)</returns>
        public abstract List<tbAppointArbitrationEntity> tbAppointArbitrationList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbAppointArbitrationEntity实体类 (tbAppointArbitration)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbAppointArbitrationEntity</returns>
        protected tbAppointArbitrationEntity PopulatetbAppointArbitrationEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbAppointArbitrationEntity nc = new tbAppointArbitrationEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("CustomerID") && !Convert.IsDBNull(dr["CustomerID"])) nc.CustomerID = Convert.ToInt32(dr["CustomerID"]); // CustomerID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToString(dr["UserID"]).Trim(); // UserID
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // CreateDate
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // Comment
            if (Fileds.ContainsKey("OpCustomerID") && !Convert.IsDBNull(dr["OpCustomerID"])) nc.OpCustomerID = Convert.ToInt32(dr["OpCustomerID"]); // OpCustomerID
            return nc;
        }
        #endregion

        #region "tbActivity(tbActivity) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbActivityEntity (tbActivity)
        /// </summary>
        /// <param name="fam">tbActivity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbActivityInsertUpdateDelete(tbActivityEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbActivityEntity (tbActivity)
        /// </summary>
        /// <param name="fam">tbActivity实体类</param>
        /// <param name="tran">tbActivity事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbActivityInsertUpdateDelete(tbActivityEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbActivityEntity实体类的List对象 (tbActivity)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbActivityEntity实体类的List对象(tbActivity)</returns>
        public abstract List<tbActivityEntity> tbActivityList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbActivityEntity实体类的List对象 (tbActivity)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbActivity事务</param>
        /// <returns>tbActivityEntity实体类的List对象(tbActivity)</returns>
        public abstract List<tbActivityEntity> tbActivityList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbActivityEntity实体类 (tbActivity)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbActivityEntity</returns>
        protected tbActivityEntity PopulatetbActivityEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbActivityEntity nc = new tbActivityEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("Title") && !Convert.IsDBNull(dr["Title"])) nc.Title = Convert.ToString(dr["Title"]).Trim(); // Title
            if (Fileds.ContainsKey("UserType") && !Convert.IsDBNull(dr["UserType"])) nc.UserType = Convert.ToInt32(dr["UserType"]); // UserType
            if (Fileds.ContainsKey("GameID") && !Convert.IsDBNull(dr["GameID"])) nc.GameID = Convert.ToString(dr["GameID"]); // GameID
            if (Fileds.ContainsKey("StartDate") && !Convert.IsDBNull(dr["StartDate"])) nc.StartDate = Convert.ToDateTime(dr["StartDate"]); // StartDate
            if (Fileds.ContainsKey("EndDate") && !Convert.IsDBNull(dr["EndDate"])) nc.EndDate = Convert.ToDateTime(dr["EndDate"]); // EndDate
            if (Fileds.ContainsKey("Channel") && !Convert.IsDBNull(dr["Channel"])) nc.Channel = Convert.ToInt32(dr["Channel"]); // Channel
            if (Fileds.ContainsKey("Price") && !Convert.IsDBNull(dr["Price"])) nc.Price = Convert.ToDouble(dr["Price"]); // Price
            if (Fileds.ContainsKey("Pirce2") && !Convert.IsDBNull(dr["Pirce2"])) nc.Pirce2 = Convert.ToDouble(dr["Pirce2"]); // Pirce2
            if (Fileds.ContainsKey("Price3") && !Convert.IsDBNull(dr["Price3"])) nc.Price3 = Convert.ToDouble(dr["Price3"]); // Price3
            if (Fileds.ContainsKey("SendDate") && !Convert.IsDBNull(dr["SendDate"])) nc.SendDate = Convert.ToDateTime(dr["SendDate"]); // SendDate
            if (Fileds.ContainsKey("Status") && !Convert.IsDBNull(dr["Status"])) nc.Status = Convert.ToInt32(dr["Status"]); // Status
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // Comment
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // CreateDate
            return nc;
        }
        #endregion

        #region "tbFeedBack(tbFeedBack) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbFeedBackEntity (tbFeedBack)
        /// </summary>
        /// <param name="fam">tbFeedBack实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbFeedBackInsertUpdateDelete(tbFeedBackEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbFeedBackEntity (tbFeedBack)
        /// </summary>
        /// <param name="fam">tbFeedBack实体类</param>
        /// <param name="tran">tbFeedBack事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbFeedBackInsertUpdateDelete(tbFeedBackEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbFeedBackEntity实体类的List对象 (tbFeedBack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbFeedBackEntity实体类的List对象(tbFeedBack)</returns>
        public abstract List<tbFeedBackEntity> tbFeedBackList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbFeedBackEntity实体类的List对象 (tbFeedBack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbFeedBack事务</param>
        /// <returns>tbFeedBackEntity实体类的List对象(tbFeedBack)</returns>
        public abstract List<tbFeedBackEntity> tbFeedBackList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbFeedBackEntity实体类 (tbFeedBack)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbFeedBackEntity</returns>
        protected tbFeedBackEntity PopulatetbFeedBackEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbFeedBackEntity nc = new tbFeedBackEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // 序号ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("Source") && !Convert.IsDBNull(dr["Source"])) nc.Source = Convert.ToString(dr["Source"]).Trim(); // 提交来源
            if (Fileds.ContainsKey("Feedback") && !Convert.IsDBNull(dr["Feedback"])) nc.Feedback = Convert.ToString(dr["Feedback"]).Trim(); // 反馈内容
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 提交时间
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // Comment
            if (Fileds.ContainsKey("CustomerID") && !Convert.IsDBNull(dr["CustomerID"])) nc.CustomerID = Convert.ToInt32(dr["CustomerID"]); // CustomerID
            if (Fileds.ContainsKey("Mark") && !Convert.IsDBNull(dr["Mark"])) nc.Mark = Convert.ToInt32(dr["Mark"]);
            return nc;
        }
        #endregion

        #region "sys_StatisticalGrouping(sys_StatisticalGrouping) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 sys_StatisticalGroupingEntity (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="fam">sys_StatisticalGrouping实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 sys_StatisticalGroupingInsertUpdateDelete(sys_StatisticalGroupingEntity fam);

        /// <summary>
        /// 新增/删除/修改 sys_StatisticalGroupingEntity (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="fam">sys_StatisticalGrouping实体类</param>
        /// <param name="tran">sys_StatisticalGrouping事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 sys_StatisticalGroupingInsertUpdateDelete(sys_StatisticalGroupingEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回sys_StatisticalGroupingEntity实体类的List对象 (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_StatisticalGroupingEntity实体类的List对象(sys_StatisticalGrouping)</returns>
        public abstract List<sys_StatisticalGroupingEntity> sys_StatisticalGroupingList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回sys_StatisticalGroupingEntity实体类的List对象 (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">sys_StatisticalGrouping事务</param>
        /// <returns>sys_StatisticalGroupingEntity实体类的List对象(sys_StatisticalGrouping)</returns>
        public abstract List<sys_StatisticalGroupingEntity> sys_StatisticalGroupingList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为sys_StatisticalGroupingEntity实体类 (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>sys_StatisticalGroupingEntity</returns>
        protected sys_StatisticalGroupingEntity Populatesys_StatisticalGroupingEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            sys_StatisticalGroupingEntity nc = new sys_StatisticalGroupingEntity();

            if (Fileds.ContainsKey("S_ID") && !Convert.IsDBNull(dr["S_ID"])) nc.S_ID = Convert.ToInt32(dr["S_ID"]); // S_ID
            if (Fileds.ContainsKey("S_Name") && !Convert.IsDBNull(dr["S_Name"])) nc.S_Name = Convert.ToString(dr["S_Name"]).Trim(); // S_Name
            if (Fileds.ContainsKey("S_Remark") && !Convert.IsDBNull(dr["S_Remark"])) nc.S_Remark = Convert.ToString(dr["S_Remark"]).Trim(); // S_Remark
            return nc;
        }
        #endregion

        #region "tsNotice(系统公告) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsNoticeEntity (系统公告)
        /// </summary>
        /// <param name="fam">tsNotice实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsNoticeInsertUpdateDelete(tsNoticeEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsNoticeEntity (系统公告)
        /// </summary>
        /// <param name="fam">tsNotice实体类</param>
        /// <param name="tran">tsNotice事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsNoticeInsertUpdateDelete(tsNoticeEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsNoticeEntity实体类的List对象 (系统公告)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsNoticeEntity实体类的List对象(系统公告)</returns>
        public abstract List<tsNoticeEntity> tsNoticeList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsNoticeEntity实体类的List对象 (系统公告)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsNotice事务</param>
        /// <returns>tsNoticeEntity实体类的List对象(系统公告)</returns>
        public abstract List<tsNoticeEntity> tsNoticeList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsNoticeEntity实体类 (系统公告)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsNoticeEntity</returns>
        protected tsNoticeEntity PopulatetsNoticeEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsNoticeEntity nc = new tsNoticeEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("Title") && !Convert.IsDBNull(dr["Title"])) nc.Title = Convert.ToString(dr["Title"]).Trim(); // 标题
            if (Fileds.ContainsKey("Body") && !Convert.IsDBNull(dr["Body"])) nc.Body = Convert.ToString(dr["Body"]).Trim(); // 正文
            if (Fileds.ContainsKey("Url") && !Convert.IsDBNull(dr["Url"])) nc.Url = Convert.ToString(dr["Url"]).Trim(); // 链接
            if (Fileds.ContainsKey("PubDate") && !Convert.IsDBNull(dr["PubDate"])) nc.PubDate = Convert.ToDateTime(dr["PubDate"]); // 发布日期
            if (Fileds.ContainsKey("StartDate") && !Convert.IsDBNull(dr["StartDate"])) nc.StartDate = Convert.ToDateTime(dr["StartDate"]); // 开始日期
            if (Fileds.ContainsKey("EndDate") && !Convert.IsDBNull(dr["EndDate"])) nc.EndDate = Convert.ToDateTime(dr["EndDate"]); // 结束日期
            if (Fileds.ContainsKey("Enable") && !Convert.IsDBNull(dr["Enable"])) nc.Enable = Convert.ToBoolean(dr["Enable"]); // 是否启用
            return nc;
        }
        #endregion

        #region "tbActivityBlack(tbActivityBlack) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbActivityBlackEntity (tbActivityBlack)
        /// </summary>
        /// <param name="fam">tbActivityBlack实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbActivityBlackInsertUpdateDelete(tbActivityBlackEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbActivityBlackEntity (tbActivityBlack)
        /// </summary>
        /// <param name="fam">tbActivityBlack实体类</param>
        /// <param name="tran">tbActivityBlack事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbActivityBlackInsertUpdateDelete(tbActivityBlackEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbActivityBlackEntity实体类的List对象 (tbActivityBlack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbActivityBlackEntity实体类的List对象(tbActivityBlack)</returns>
        public abstract List<tbActivityBlackEntity> tbActivityBlackList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbActivityBlackEntity实体类的List对象 (tbActivityBlack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbActivityBlack事务</param>
        /// <returns>tbActivityBlackEntity实体类的List对象(tbActivityBlack)</returns>
        public abstract List<tbActivityBlackEntity> tbActivityBlackList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbActivityBlackEntity实体类 (tbActivityBlack)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbActivityBlackEntity</returns>
        protected tbActivityBlackEntity PopulatetbActivityBlackEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbActivityBlackEntity nc = new tbActivityBlackEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // UserID
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // CreateDate
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // Comment
            if (Fileds.ContainsKey("CustomerID") && !Convert.IsDBNull(dr["CustomerID"])) nc.CustomerID = Convert.ToInt32(dr["CustomerID"]); // CustomerID
            return nc;
        }
        #endregion

        #region "tsBankBlack(tsBankBlack) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsBankBlackEntity (tsBankBlack)
        /// </summary>
        /// <param name="fam">tsBankBlack实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsBankBlackInsertUpdateDelete(tsBankBlackEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsBankBlackEntity (tsBankBlack)
        /// </summary>
        /// <param name="fam">tsBankBlack实体类</param>
        /// <param name="tran">tsBankBlack事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsBankBlackInsertUpdateDelete(tsBankBlackEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsBankBlackEntity实体类的List对象 (tsBankBlack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsBankBlackEntity实体类的List对象(tsBankBlack)</returns>
        public abstract List<tsBankBlackEntity> tsBankBlackList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsBankBlackEntity实体类的List对象 (tsBankBlack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsBankBlack事务</param>
        /// <returns>tsBankBlackEntity实体类的List对象(tsBankBlack)</returns>
        public abstract List<tsBankBlackEntity> tsBankBlackList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsBankBlackEntity实体类 (tsBankBlack)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsBankBlackEntity</returns>
        protected tsBankBlackEntity PopulatetsBankBlackEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsBankBlackEntity nc = new tsBankBlackEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("BankID") && !Convert.IsDBNull(dr["BankID"])) nc.BankID = Convert.ToInt16(dr["BankID"]); // BankID
            if (Fileds.ContainsKey("BankUser") && !Convert.IsDBNull(dr["BankUser"])) nc.BankUser = Convert.ToString(dr["BankUser"]).Trim(); // BankUser
            if (Fileds.ContainsKey("BankAcc") && !Convert.IsDBNull(dr["BankAcc"])) nc.BankAcc = Convert.ToString(dr["BankAcc"]).Trim(); // BankAcc
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // CreateDate
            if (Fileds.ContainsKey("CustomerID") && !Convert.IsDBNull(dr["CustomerID"])) nc.CustomerID = Convert.ToInt32(dr["CustomerID"]); // CustomerID
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // Comment
            return nc;
        }
        #endregion

        #region "tbPostReport(tbPostReport) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbPostReportEntity (tbPostReport)
        /// </summary>
        /// <param name="fam">tbPostReport实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbPostReportInsertUpdateDelete(tbPostReportEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbPostReportEntity (tbPostReport)
        /// </summary>
        /// <param name="fam">tbPostReport实体类</param>
        /// <param name="tran">tbPostReport事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbPostReportInsertUpdateDelete(tbPostReportEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbPostReportEntity实体类的List对象 (tbPostReport)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbPostReportEntity实体类的List对象(tbPostReport)</returns>
        public abstract List<tbPostReportEntity> tbPostReportList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbPostReportEntity实体类的List对象 (tbPostReport)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbPostReport事务</param>
        /// <returns>tbPostReportEntity实体类的List对象(tbPostReport)</returns>
        public abstract List<tbPostReportEntity> tbPostReportList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbPostReportEntity实体类 (tbPostReport)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbPostReportEntity</returns>
        protected tbPostReportEntity PopulatetbPostReportEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbPostReportEntity nc = new tbPostReportEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("SerialNo") && !Convert.IsDBNull(dr["SerialNo"])) nc.SerialNo = Convert.ToString(dr["SerialNo"]).Trim(); // SerialNo
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // UserID
            if (Fileds.ContainsKey("ReportCustomerID") && !Convert.IsDBNull(dr["ReportCustomerID"])) nc.ReportCustomerID = Convert.ToInt32(dr["ReportCustomerID"]); //ReportCustomerID
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // CreateDate
            if (Fileds.ContainsKey("DealCustomerID") && !Convert.IsDBNull(dr["DealCustomerID"])) nc.DealCustomerID = Convert.ToInt32(dr["DealCustomerID"]); // DealCustomerID
            if (Fileds.ContainsKey("DealDate") && !Convert.IsDBNull(dr["DealDate"])) nc.DealDate = Convert.ToDateTime(dr["DealDate"]); // DealDate
            if (Fileds.ContainsKey("Status") && !Convert.IsDBNull(dr["Status"])) nc.Status = Convert.ToInt32(dr["Status"]); // Status
            if (Fileds.ContainsKey("Remark") && !Convert.IsDBNull(dr["Remark"])) nc.Remark = Convert.ToString(dr["Remark"]).Trim(); // Remark
            return nc;
        }
        #endregion

        #region "tbLevelOrderReJudg(tbLevelOrderReJudg) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderReJudgEntity (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="fam">tbLevelOrderReJudg实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderReJudgInsertUpdateDelete(tbLevelOrderReJudgEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderReJudgEntity (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="fam">tbLevelOrderReJudg实体类</param>
        /// <param name="tran">tbLevelOrderReJudg事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderReJudgInsertUpdateDelete(tbLevelOrderReJudgEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbLevelOrderReJudgEntity实体类的List对象 (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderReJudgEntity实体类的List对象(tbLevelOrderReJudg)</returns>
        public abstract List<tbLevelOrderReJudgEntity> tbLevelOrderReJudgList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbLevelOrderReJudgEntity实体类的List对象 (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderReJudg事务</param>
        /// <returns>tbLevelOrderReJudgEntity实体类的List对象(tbLevelOrderReJudg)</returns>
        public abstract List<tbLevelOrderReJudgEntity> tbLevelOrderReJudgList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbLevelOrderReJudgEntity实体类 (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbLevelOrderReJudgEntity</returns>
        protected tbLevelOrderReJudgEntity PopulatetbLevelOrderReJudgEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbLevelOrderReJudgEntity nc = new tbLevelOrderReJudgEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("ODSerialNo") && !Convert.IsDBNull(dr["ODSerialNo"])) nc.ODSerialNo = Convert.ToString(dr["ODSerialNo"]).Trim(); // ODSerialNo
            if (Fileds.ContainsKey("CustomerID") && !Convert.IsDBNull(dr["CustomerID"])) nc.CustomerID = Convert.ToInt32(dr["CustomerID"]); // CustomerID
            if (Fileds.ContainsKey("Reason") && !Convert.IsDBNull(dr["Reason"])) nc.Reason = Convert.ToString(dr["Reason"]).Trim(); // CreateDate
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            if (Fileds.ContainsKey("MarkColor") && !Convert.IsDBNull(dr["MarkColor"])) nc.MarkColor = Convert.ToInt32(dr["MarkColor"]); // MarkColor
            return nc;
        }
        #endregion

        #region "tbServiceHelp(tbServiceHelp) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbServiceHelpEntity (tbServiceHelp)
        /// </summary>
        /// <param name="fam">tbServiceHelp实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbServiceHelpInsertUpdateDelete(tbServiceHelpEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbServiceHelpEntity (tbServiceHelp)
        /// </summary>
        /// <param name="fam">tbServiceHelp实体类</param>
        /// <param name="tran">tbServiceHelp事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbServiceHelpInsertUpdateDelete(tbServiceHelpEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbServiceHelpEntity实体类的List对象 (tbServiceHelp)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbServiceHelpEntity实体类的List对象(tbServiceHelp)</returns>
        public abstract List<tbServiceHelpEntity> tbServiceHelpList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbServiceHelpEntity实体类的List对象 (tbServiceHelp)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbServiceHelp事务</param>
        /// <returns>tbServiceHelpEntity实体类的List对象(tbServiceHelp)</returns>
        public abstract List<tbServiceHelpEntity> tbServiceHelpList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbServiceHelpEntity实体类 (tbServiceHelp)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbServiceHelpEntity</returns>
        protected tbServiceHelpEntity PopulatetbServiceHelpEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbServiceHelpEntity nc = new tbServiceHelpEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("ODSerialNo") && !Convert.IsDBNull(dr["ODSerialNo"])) nc.ODSerialNo = Convert.ToString(dr["ODSerialNo"]).Trim(); // ODSerialNo
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // UserID
            if (Fileds.ContainsKey("AcceptUserID") && !Convert.IsDBNull(dr["AcceptUserID"])) nc.AcceptUserID = Convert.ToInt32(dr["AcceptUserID"]); // AcceptUserID
            if (Fileds.ContainsKey("Content") && !Convert.IsDBNull(dr["Content"])) nc.Content = Convert.ToString(dr["Content"]).Trim(); // Content
            if (Fileds.ContainsKey("IsDeal") && !Convert.IsDBNull(dr["IsDeal"])) nc.IsDeal = Convert.ToBoolean(dr["IsDeal"]); // IsDeal
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // CreateDate
            if (Fileds.ContainsKey("DealDate") && !Convert.IsDBNull(dr["DealDate"])) nc.DealDate = Convert.ToDateTime(dr["DealDate"]); // DealDate
            if (Fileds.ContainsKey("DealCustomerID") && !Convert.IsDBNull(dr["DealCustomerID"])) nc.DealCustomerID = Convert.ToInt32(dr["DealCustomerID"]); // DealCustomerID
            if (Fileds.ContainsKey("Remark") && !Convert.IsDBNull(dr["Remark"])) nc.Remark = Convert.ToString(dr["Remark"]).Trim(); // Remark
            if (Fileds.ContainsKey("HelpType") && !Convert.IsDBNull(dr["HelpType"])) nc.HelpType = Convert.ToInt32(dr["HelpType"]); // HelpType
            return nc;
        }
        #endregion

        #region "tbVirtualWallet(tbVirtualWallet) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbVirtualWalletEntity (tbVirtualWallet)
        /// </summary>
        /// <param name="fam">tbVirtualWallet实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbVirtualWalletInsertUpdateDelete(tbVirtualWalletEntity fam);

        /// <summary>
        /// 返回tbVirtualWalletEntity实体类的List对象 (tbVirtualWallet)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbVirtualWalletEntity实体类的List对象(tbVirtualWallet)</returns>
        public abstract List<tbVirtualWalletEntity> tbVirtualWalletList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 将记录集转为tbVirtualWalletEntity实体类 (tbVirtualWallet)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbVirtualWalletEntity</returns>
        protected tbVirtualWalletEntity PopulatetbVirtualWalletEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbVirtualWalletEntity nc = new tbVirtualWalletEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("OPID") && !Convert.IsDBNull(dr["OPID"])) nc.OPID = Convert.ToInt32(dr["OPID"]); // OPID
            if (Fileds.ContainsKey("MONEY") && !Convert.IsDBNull(dr["MONEY"])) nc.MONEY = Convert.ToDouble(dr["MONEY"]); // MONEY
            return nc;
        }
        #endregion

        #region "tbFinancialDay(财务每日数据) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbFinancialDayEntity (财务每日数据)
        /// </summary>
        /// <param name="fam">tbFinancialDay实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbFinancialDayInsertUpdateDelete(tbFinancialDayEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbFinancialDayEntity (财务每日数据)
        /// </summary>
        /// <param name="fam">tbFinancialDay实体类</param>
        /// <param name="tran">tbFinancialDay事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbFinancialDayInsertUpdateDelete(tbFinancialDayEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbFinancialDayEntity实体类的List对象 (财务每日数据)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbFinancialDayEntity实体类的List对象(财务每日数据)</returns>
        public abstract List<tbFinancialDayEntity> tbFinancialDayList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbFinancialDayEntity实体类的List对象 (财务每日数据)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbFinancialDay事务</param>
        /// <returns>tbFinancialDayEntity实体类的List对象(财务每日数据)</returns>
        public abstract List<tbFinancialDayEntity> tbFinancialDayList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbFinancialDayEntity实体类 (财务每日数据)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbFinancialDayEntity</returns>
        protected tbFinancialDayEntity PopulatetbFinancialDayEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbFinancialDayEntity nc = new tbFinancialDayEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("TotalBal") && !Convert.IsDBNull(dr["TotalBal"])) nc.TotalBal = Convert.ToDouble(dr["TotalBal"]); // 总资金
            if (Fileds.ContainsKey("TotalFreeze") && !Convert.IsDBNull(dr["TotalFreeze"])) nc.TotalFreeze = Convert.ToDouble(dr["TotalFreeze"]); // 总冻结资金
            if (Fileds.ContainsKey("TotalWithDraw") && !Convert.IsDBNull(dr["TotalWithDraw"])) nc.TotalWithDraw = Convert.ToDouble(dr["TotalWithDraw"]); // 总提现资金
            if (Fileds.ContainsKey("TotalOperate") && !Convert.IsDBNull(dr["TotalOperate"])) nc.TotalOperate = Convert.ToDouble(dr["TotalOperate"]); // 总可操作资金
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            return nc;
        }
        #endregion

        #region "tbLevelOrderCancel(代练撤销) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderCancelEntity (代练撤销)
        /// </summary>
        /// <param name="fam">tbLevelOrderCancel实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderCancelInsertUpdateDelete(tbLevelOrderCancelEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderCancelEntity (代练撤销)
        /// </summary>
        /// <param name="fam">tbLevelOrderCancel实体类</param>
        /// <param name="tran">tbLevelOrderCancel事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderCancelInsertUpdateDelete(tbLevelOrderCancelEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbLevelOrderCancelEntity实体类的List对象 (代练撤销)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderCancelEntity实体类的List对象(代练撤销)</returns>
        public abstract List<tbLevelOrderCancelEntity> tbLevelOrderCancelList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbLevelOrderCancelEntity实体类的List对象 (代练撤销)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderCancel事务</param>
        /// <returns>tbLevelOrderCancelEntity实体类的List对象(代练撤销)</returns>
        public abstract List<tbLevelOrderCancelEntity> tbLevelOrderCancelList(QueryParam qp, out int RecordCount, DbTransaction tran);

        public abstract List<tsUser1Entity> UserList1(QueryParam qp, out int RecordCount);

        public abstract List<tsUser1Entity> UserList1(QueryParam qp, out int RecordCount, DbTransaction tran);


        protected tsUser1Entity UserList1Entity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsUser1Entity nc = new tsUser1Entity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("NickName") && !Convert.IsDBNull(dr["NickName"])) nc.NickName = Convert.ToString(dr["NickName"]).Trim(); // 昵称
            if (Fileds.ContainsKey("AvatarUrl") && !Convert.IsDBNull(dr["AvatarUrl"])) nc.AvatarUrl = Convert.ToString(dr["AvatarUrl"]).Trim(); // 头像
            if (Fileds.ContainsKey("Gender") && !Convert.IsDBNull(dr["Gender"])) nc.Gender = Convert.ToInt32(dr["Gender"]); // 性别
            if (Fileds.ContainsKey("Country") && !Convert.IsDBNull(dr["Country"])) nc.Country = Convert.ToString(dr["Country"]).Trim();
            if (Fileds.ContainsKey("Province") && !Convert.IsDBNull(dr["Province"])) nc.Province = Convert.ToString(dr["Province"]).Trim();
            if (Fileds.ContainsKey("City") && !Convert.IsDBNull(dr["City"])) nc.City = Convert.ToString(dr["City"]).Trim();
            if (Fileds.ContainsKey("SumBal") && !Convert.IsDBNull(dr["SumBal"])) nc.SumBal = Convert.ToDouble(dr["SumBal"]); // 总金额
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            if (Fileds.ContainsKey("Status") && !Convert.IsDBNull(dr["Status"])) nc.Status = Convert.ToInt16(dr["Status"]); // 状态
            if (Fileds.ContainsKey("Token") && !Convert.IsDBNull(dr["Token"])) nc.Token = Convert.ToString(dr["Token"]).Trim();
            if (Fileds.ContainsKey("OpenID") && !Convert.IsDBNull(dr["OpenID"])) nc.OpenID = Convert.ToString(dr["OpenID"]).Trim();
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim();

            if (Fileds.ContainsKey("MemberID") && !Convert.IsDBNull(dr["MemberID"])) nc.MemberID = Convert.ToInt16(dr["MemberID"]);
            if (Fileds.ContainsKey("EndDate") && !Convert.IsDBNull(dr["EndDate"])) nc.EndDate = Convert.ToDateTime(dr["EndDate"]); 
            return nc;
        }

        protected tsUserEntity UserListEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsUserEntity nc = new tsUserEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UID") && !Convert.IsDBNull(dr["UID"])) nc.UID = Convert.ToString(dr["UID"]).Trim(); // 用户编号
            if (Fileds.ContainsKey("Nickname") && !Convert.IsDBNull(dr["Nickname"])) nc.Nickname = Convert.ToString(dr["Nickname"]).Trim(); // 昵称
            if (Fileds.ContainsKey("LoginID") && !Convert.IsDBNull(dr["LoginID"])) nc.LoginID = Convert.ToString(dr["LoginID"]).Trim(); // 登录ID
            if (Fileds.ContainsKey("Pass") && !Convert.IsDBNull(dr["Pass"])) nc.Pass = Convert.ToString(dr["Pass"]).Trim(); // 密码
            if (Fileds.ContainsKey("PayPass") && !Convert.IsDBNull(dr["PayPass"])) nc.PayPass = Convert.ToString(dr["PayPass"]).Trim(); // 支付密码
            if (Fileds.ContainsKey("Status") && !Convert.IsDBNull(dr["Status"])) nc.Status = Convert.ToInt16(dr["Status"]); // 状态
            if (Fileds.ContainsKey("BindMobile") && !Convert.IsDBNull(dr["BindMobile"])) nc.BindMobile = Convert.ToString(dr["BindMobile"]).Trim(); // 绑定手机
            if (Fileds.ContainsKey("QQ") && !Convert.IsDBNull(dr["QQ"])) nc.QQ = Convert.ToString(dr["QQ"]).Trim();
            // if (Fileds.ContainsKey("Sex") && !Convert.IsDBNull(dr["Sex"])) nc.Sex = Convert.ToInt32(dr["Sex"]); // 性别
            if (Fileds.ContainsKey("SumBal") && !Convert.IsDBNull(dr["SumBal"])) nc.SumBal = Convert.ToDouble(dr["SumBal"]); // 总金额
            if (Fileds.ContainsKey("Email") && !Convert.IsDBNull(dr["Email"])) nc.Email = Convert.ToString(dr["Email"]).Trim(); // 邮箱
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            return nc;
        }

        /// <summary>
        /// 将记录集转为tbLevelOrderCancelEntity实体类 (代练撤销)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbLevelOrderCancelEntity</returns>
        protected tbLevelOrderCancelEntity PopulatetbLevelOrderCancelEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbLevelOrderCancelEntity nc = new tbLevelOrderCancelEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("ODSerialNo") && !Convert.IsDBNull(dr["ODSerialNo"])) nc.ODSerialNo = Convert.ToString(dr["ODSerialNo"]).Trim(); // 订单流水号
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            if (Fileds.ContainsKey("PayLevelBal") && !Convert.IsDBNull(dr["PayLevelBal"])) nc.PayLevelBal = Convert.ToDouble(dr["PayLevelBal"]); // 支付代练费
            if (Fileds.ContainsKey("RepEnsureBal") && !Convert.IsDBNull(dr["RepEnsureBal"])) nc.RepEnsureBal = Convert.ToDouble(dr["RepEnsureBal"]); // 赔偿保证金
            if (Fileds.ContainsKey("Status") && !Convert.IsDBNull(dr["Status"])) nc.Status = Convert.ToInt16(dr["Status"]); // 状态
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // 备注
            if (Fileds.ContainsKey("AcceptCount") && !Convert.IsDBNull(dr["AcceptCount"])) nc.AcceptCount = Convert.ToInt32(dr["AcceptCount"]); // 接单方撤销次数
            if (Fileds.ContainsKey("PublishCount") && !Convert.IsDBNull(dr["PublishCount"])) nc.PublishCount = Convert.ToInt32(dr["PublishCount"]); // 发单方撤销次数
            return nc;
        }
        #endregion

        #region "tbLevelOrderFee(订单费用) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderFeeEntity (订单费用)
        /// </summary>
        /// <param name="fam">tbLevelOrderFee实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderFeeInsertUpdateDelete(tbLevelOrderFeeEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderFeeEntity (订单费用)
        /// </summary>
        /// <param name="fam">tbLevelOrderFee实体类</param>
        /// <param name="tran">tbLevelOrderFee事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderFeeInsertUpdateDelete(tbLevelOrderFeeEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbLevelOrderFeeEntity实体类的List对象 (订单费用)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderFeeEntity实体类的List对象(订单费用)</returns>
        public abstract List<tbLevelOrderFeeEntity> tbLevelOrderFeeList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbLevelOrderFeeEntity实体类的List对象 (订单费用)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderFee事务</param>
        /// <returns>tbLevelOrderFeeEntity实体类的List对象(订单费用)</returns>
        public abstract List<tbLevelOrderFeeEntity> tbLevelOrderFeeList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbLevelOrderFeeEntity实体类 (订单费用)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbLevelOrderFeeEntity</returns>
        protected tbLevelOrderFeeEntity PopulatetbLevelOrderFeeEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbLevelOrderFeeEntity nc = new tbLevelOrderFeeEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("ODSerialNo") && !Convert.IsDBNull(dr["ODSerialNo"])) nc.ODSerialNo = Convert.ToString(dr["ODSerialNo"]).Trim(); // 订单流水号
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("Bal") && !Convert.IsDBNull(dr["Bal"])) nc.Bal = Convert.ToDouble(dr["Bal"]); // 金额
            if (Fileds.ContainsKey("Fee") && !Convert.IsDBNull(dr["Fee"])) nc.Fee = Convert.ToDouble(dr["Fee"]); // 手续费
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            return nc;
        }
        #endregion

        #region "tbLevelOrderInfo(代练订单角色资料) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderInfoEntity (代练订单角色资料)
        /// </summary>
        /// <param name="fam">tbLevelOrderInfo实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderInfoInsertUpdateDelete(tbLevelOrderInfoEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderInfoEntity (代练订单角色资料)
        /// </summary>
        /// <param name="fam">tbLevelOrderInfo实体类</param>
        /// <param name="tran">tbLevelOrderInfo事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderInfoInsertUpdateDelete(tbLevelOrderInfoEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbLevelOrderInfoEntity实体类的List对象 (代练订单角色资料)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderInfoEntity实体类的List对象(代练订单角色资料)</returns>
        public abstract List<tbLevelOrderInfoEntity> tbLevelOrderInfoList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbLevelOrderInfoEntity实体类的List对象 (代练订单角色资料)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderInfo事务</param>
        /// <returns>tbLevelOrderInfoEntity实体类的List对象(代练订单角色资料)</returns>
        public abstract List<tbLevelOrderInfoEntity> tbLevelOrderInfoList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbLevelOrderInfoEntity实体类 (代练订单角色资料)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbLevelOrderInfoEntity</returns>
        protected tbLevelOrderInfoEntity PopulatetbLevelOrderInfoEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbLevelOrderInfoEntity nc = new tbLevelOrderInfoEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("ODSerialNo") && !Convert.IsDBNull(dr["ODSerialNo"])) nc.ODSerialNo = Convert.ToString(dr["ODSerialNo"]).Trim(); // 订单流水号
            if (Fileds.ContainsKey("GameAcc") && !Convert.IsDBNull(dr["GameAcc"])) nc.GameAcc = Convert.ToString(dr["GameAcc"]).Trim(); // 帐号
            if (Fileds.ContainsKey("GamePass") && !Convert.IsDBNull(dr["GamePass"])) nc.GamePass = Convert.ToString(dr["GamePass"]).Trim(); // 密码
            if (Fileds.ContainsKey("Actor") && !Convert.IsDBNull(dr["Actor"])) nc.Actor = Convert.ToString(dr["Actor"]).Trim(); // 角色
            if (Fileds.ContainsKey("CurrInfo") && !Convert.IsDBNull(dr["CurrInfo"])) nc.CurrInfo = Convert.ToString(dr["CurrInfo"]).Trim(); // 代练前角色信息
            if (Fileds.ContainsKey("Require") && !Convert.IsDBNull(dr["Require"])) nc.Require = Convert.ToString(dr["Require"]).Trim(); // 代练最终要求
            if (Fileds.ContainsKey("SecPic") && !Convert.IsDBNull(dr["SecPic"])) nc.SecPic = (Byte[])(dr["SecPic"]); // 密保图片
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // 描述
            if (Fileds.ContainsKey("ChangePassCount") && !Convert.IsDBNull(dr["ChangePassCount"])) nc.ChangePassCount = Convert.ToInt32(dr["ChangePassCount"]); // 改密次数
            return nc;
        }
        #endregion

        #region "tbLevelOrderMessage(订单交互留言) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderMessageEntity (订单交互留言)
        /// </summary>
        /// <param name="fam">tbLevelOrderMessage实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderMessageInsertUpdateDelete(tbLevelOrderMessageEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderMessageEntity (订单交互留言)
        /// </summary>
        /// <param name="fam">tbLevelOrderMessage实体类</param>
        /// <param name="tran">tbLevelOrderMessage事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderMessageInsertUpdateDelete(tbLevelOrderMessageEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbLevelOrderMessageEntity实体类的List对象 (订单交互留言)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderMessageEntity实体类的List对象(订单交互留言)</returns>
        public abstract List<tbLevelOrderMessageEntity> tbLevelOrderMessageList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbLevelOrderMessageEntity实体类的List对象 (订单交互留言)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderMessage事务</param>
        /// <returns>tbLevelOrderMessageEntity实体类的List对象(订单交互留言)</returns>
        public abstract List<tbLevelOrderMessageEntity> tbLevelOrderMessageList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbLevelOrderMessageEntity实体类 (订单交互留言)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbLevelOrderMessageEntity</returns>
        protected tbLevelOrderMessageEntity PopulatetbLevelOrderMessageEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbLevelOrderMessageEntity nc = new tbLevelOrderMessageEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("ODSerialNo") && !Convert.IsDBNull(dr["ODSerialNo"])) nc.ODSerialNo = Convert.ToString(dr["ODSerialNo"]).Trim(); // 订单流水号
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("MsgType") && !Convert.IsDBNull(dr["MsgType"])) nc.MsgType = Convert.ToInt16(dr["MsgType"]); // 留言类别
            if (Fileds.ContainsKey("Msg") && !Convert.IsDBNull(dr["Msg"])) nc.Msg = Convert.ToString(dr["Msg"]).Trim(); // 留言内容
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            if (Fileds.ContainsKey("IsRead") && !Convert.IsDBNull(dr["IsRead"])) nc.IsRead = Convert.ToBoolean(dr["IsRead"]); // 已读标记
            if (Fileds.ContainsKey("IsRead2") && !Convert.IsDBNull(dr["IsRead2"])) nc.IsRead2 = Convert.ToBoolean(dr["IsRead2"]); // 已读标记2
            return nc;
        }
        #endregion

        #region "tbLevelOrderProgress(代练进度) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderProgressEntity (代练进度)
        /// </summary>
        /// <param name="fam">tbLevelOrderProgress实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderProgressInsertUpdateDelete(tbLevelOrderProgressEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderProgressEntity (代练进度)
        /// </summary>
        /// <param name="fam">tbLevelOrderProgress实体类</param>
        /// <param name="tran">tbLevelOrderProgress事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderProgressInsertUpdateDelete(tbLevelOrderProgressEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbLevelOrderProgressEntity实体类的List对象 (代练进度)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderProgressEntity实体类的List对象(代练进度)</returns>
        public abstract List<tbLevelOrderProgressEntity> tbLevelOrderProgressList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbLevelOrderProgressEntity实体类的List对象 (代练进度)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderProgress事务</param>
        /// <returns>tbLevelOrderProgressEntity实体类的List对象(代练进度)</returns>
        public abstract List<tbLevelOrderProgressEntity> tbLevelOrderProgressList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbLevelOrderProgressEntity实体类 (代练进度)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbLevelOrderProgressEntity</returns>
        protected tbLevelOrderProgressEntity PopulatetbLevelOrderProgressEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbLevelOrderProgressEntity nc = new tbLevelOrderProgressEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("ODSerialNo") && !Convert.IsDBNull(dr["ODSerialNo"])) nc.ODSerialNo = Convert.ToString(dr["ODSerialNo"]).Trim(); // 订单流水号
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            if (Fileds.ContainsKey("Img") && !Convert.IsDBNull(dr["Img"])) nc.Img = Convert.ToString(dr["Img"]).Trim(); // 图片地址
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // 描述
            if (Fileds.ContainsKey("Source") && !Convert.IsDBNull(dr["Source"])) nc.Source = Convert.ToInt16(dr["Source"]); // 进度来源
            return nc;
        }
        #endregion

        #region "tbLevelOrderRight(订单可查看权限) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderRightEntity (订单可查看权限)
        /// </summary>
        /// <param name="fam">tbLevelOrderRight实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderRightInsertUpdateDelete(tbLevelOrderRightEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderRightEntity (订单可查看权限)
        /// </summary>
        /// <param name="fam">tbLevelOrderRight实体类</param>
        /// <param name="tran">tbLevelOrderRight事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbLevelOrderRightInsertUpdateDelete(tbLevelOrderRightEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbLevelOrderRightEntity实体类的List对象 (订单可查看权限)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderRightEntity实体类的List对象(订单可查看权限)</returns>
        public abstract List<tbLevelOrderRightEntity> tbLevelOrderRightList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbLevelOrderRightEntity实体类的List对象 (订单可查看权限)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbLevelOrderRight事务</param>
        /// <returns>tbLevelOrderRightEntity实体类的List对象(订单可查看权限)</returns>
        public abstract List<tbLevelOrderRightEntity> tbLevelOrderRightList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbLevelOrderRightEntity实体类 (订单可查看权限)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbLevelOrderRightEntity</returns>
        protected tbLevelOrderRightEntity PopulatetbLevelOrderRightEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbLevelOrderRightEntity nc = new tbLevelOrderRightEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("ODSerialNo") && !Convert.IsDBNull(dr["ODSerialNo"])) nc.ODSerialNo = Convert.ToString(dr["ODSerialNo"]).Trim(); // 订单流水号
            if (Fileds.ContainsKey("RightType") && !Convert.IsDBNull(dr["RightType"])) nc.RightType = Convert.ToInt16(dr["RightType"]); // 权限类别
            if (Fileds.ContainsKey("RelaID") && !Convert.IsDBNull(dr["RelaID"])) nc.RelaID = Convert.ToInt32(dr["RelaID"]); // 相关ID
            return nc;
        }
        #endregion

        #region "tcUserStat(用户统计数据) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tcUserStatEntity (用户统计数据)
        /// </summary>
        /// <param name="fam">tcUserStat实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tcUserStatInsertUpdateDelete(tcUserStatEntity fam);

        /// <summary>
        /// 新增/删除/修改 tcUserStatEntity (用户统计数据)
        /// </summary>
        /// <param name="fam">tcUserStat实体类</param>
        /// <param name="tran">tcUserStat事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tcUserStatInsertUpdateDelete(tcUserStatEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tcUserStatEntity实体类的List对象 (用户统计数据)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tcUserStatEntity实体类的List对象(用户统计数据)</returns>
        public abstract List<tcUserStatEntity> tcUserStatList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tcUserStatEntity实体类的List对象 (用户统计数据)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tcUserStat事务</param>
        /// <returns>tcUserStatEntity实体类的List对象(用户统计数据)</returns>
        public abstract List<tcUserStatEntity> tcUserStatList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tcUserStatEntity实体类 (用户统计数据)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tcUserStatEntity</returns>
        protected tcUserStatEntity PopulatetcUserStatEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tcUserStatEntity nc = new tcUserStatEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("PubCount") && !Convert.IsDBNull(dr["PubCount"])) nc.PubCount = Convert.ToInt32(dr["PubCount"]); // 发单总数
            if (Fileds.ContainsKey("PubCancel") && !Convert.IsDBNull(dr["PubCancel"])) nc.PubCancel = Convert.ToInt32(dr["PubCancel"]); // 发单介入撤单数
            if (Fileds.ContainsKey("PubConsultCancel") && !Convert.IsDBNull(dr["PubConsultCancel"])) nc.PubConsultCancel = Convert.ToInt32(dr["PubConsultCancel"]); // 发单协商撤单数
            if (Fileds.ContainsKey("AcceptCount") && !Convert.IsDBNull(dr["AcceptCount"])) nc.AcceptCount = Convert.ToInt32(dr["AcceptCount"]); // 接单介入总数
            if (Fileds.ContainsKey("AcceptCancel") && !Convert.IsDBNull(dr["AcceptCancel"])) nc.AcceptCancel = Convert.ToInt32(dr["AcceptCancel"]); // 接单撤单数
            if (Fileds.ContainsKey("AcceptConsultCancel") && !Convert.IsDBNull(dr["AcceptConsultCancel"])) nc.AcceptConsultCancel = Convert.ToInt32(dr["AcceptConsultCancel"]); // 接单协商撤单数
            if (Fileds.ContainsKey("OnlineMin") && !Convert.IsDBNull(dr["OnlineMin"])) nc.OnlineMin = Convert.ToInt64(dr["OnlineMin"]); // 在线时长
            return nc;
        }
        #endregion

        #region "tlLogin(登录日志) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tlLoginEntity (登录日志)
        /// </summary>
        /// <param name="fam">tlLogin实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tlLoginInsertUpdateDelete(tlLoginEntity fam);

        /// <summary>
        /// 新增/删除/修改 tlLoginEntity (登录日志)
        /// </summary>
        /// <param name="fam">tlLogin实体类</param>
        /// <param name="tran">tlLogin事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tlLoginInsertUpdateDelete(tlLoginEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tlLoginEntity实体类的List对象 (登录日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tlLoginEntity实体类的List对象(登录日志)</returns>
        public abstract List<tlLoginEntity> tlLoginList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tlLoginEntity实体类的List对象 (登录日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tlLogin事务</param>
        /// <returns>tlLoginEntity实体类的List对象(登录日志)</returns>
        public abstract List<tlLoginEntity> tlLoginList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tlLoginEntity实体类 (登录日志)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tlLoginEntity</returns>
        protected tlLoginEntity PopulatetlLoginEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tlLoginEntity nc = new tlLoginEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("SubUserID") && !Convert.IsDBNull(dr["SubUserID"])) nc.SubUserID = Convert.ToInt32(dr["SubUserID"]); // 子帐号ID
            if (Fileds.ContainsKey("LoginType") && !Convert.IsDBNull(dr["LoginType"])) nc.LoginType = Convert.ToInt32(dr["LoginType"]); // 登录类别
            if (Fileds.ContainsKey("PCName") && !Convert.IsDBNull(dr["PCName"])) nc.PCName = Convert.ToString(dr["PCName"]).Trim(); // 机器名
            if (Fileds.ContainsKey("HD") && !Convert.IsDBNull(dr["HD"])) nc.HD = Convert.ToString(dr["HD"]).Trim(); // 硬盘
            if (Fileds.ContainsKey("Mac") && !Convert.IsDBNull(dr["Mac"])) nc.Mac = Convert.ToString(dr["Mac"]).Trim(); // 网卡
            if (Fileds.ContainsKey("IP") && !Convert.IsDBNull(dr["IP"])) nc.IP = Convert.ToString(dr["IP"]).Trim(); // IP地址
            if (Fileds.ContainsKey("OS") && !Convert.IsDBNull(dr["OS"])) nc.OS = Convert.ToString(dr["OS"]).Trim(); // 操作系统
            if (Fileds.ContainsKey("LoginDate") && !Convert.IsDBNull(dr["LoginDate"])) nc.LoginDate = Convert.ToDateTime(dr["LoginDate"]); // 登录时间
            if (Fileds.ContainsKey("LogoutDate") && !Convert.IsDBNull(dr["LogoutDate"])) nc.LogoutDate = Convert.ToDateTime(dr["LogoutDate"]); // 登出时间
            if (Fileds.ContainsKey("Status") && !Convert.IsDBNull(dr["Status"])) nc.Status = Convert.ToInt16(dr["Status"]); // 状态
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // 备注
            return nc;
        }
        #endregion

        #region "tlOperate(操作日志) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tlOperateEntity (操作日志)
        /// </summary>
        /// <param name="fam">tlOperate实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tlOperateInsertUpdateDelete(tlOperateEntity fam);

        /// <summary>
        /// 新增/删除/修改 tlOperateEntity (操作日志)
        /// </summary>
        /// <param name="fam">tlOperate实体类</param>
        /// <param name="tran">tlOperate事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tlOperateInsertUpdateDelete(tlOperateEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tlOperateEntity实体类的List对象 (操作日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tlOperateEntity实体类的List对象(操作日志)</returns>
        public abstract List<tlOperateEntity> tlOperateList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tlOperateEntity实体类的List对象 (操作日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tlOperate事务</param>
        /// <returns>tlOperateEntity实体类的List对象(操作日志)</returns>
        public abstract List<tlOperateEntity> tlOperateList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tlOperateEntity实体类 (操作日志)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tlOperateEntity</returns>
        protected tlOperateEntity PopulatetlOperateEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tlOperateEntity nc = new tlOperateEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("OPType") && !Convert.IsDBNull(dr["OPType"])) nc.OPType = Convert.ToInt32(dr["OPType"]); // 操作类别
            if (Fileds.ContainsKey("OPLog") && !Convert.IsDBNull(dr["OPLog"])) nc.OPLog = Convert.ToString(dr["OPLog"]).Trim(); // 操作日志
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            if (Fileds.ContainsKey("IP") && !Convert.IsDBNull(dr["IP"])) nc.IP = Convert.ToString(dr["IP"]).Trim(); // IP地址
            return nc;
        }
        #endregion

        #region "tsBank(银行账户) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsBankEntity (银行账户)
        /// </summary>
        /// <param name="fam">tsBank实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsBankInsertUpdateDelete(tsBankEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsBankEntity (银行账户)
        /// </summary>
        /// <param name="fam">tsBank实体类</param>
        /// <param name="tran">tsBank事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsBankInsertUpdateDelete(tsBankEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsBankEntity实体类的List对象 (银行账户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsBankEntity实体类的List对象(银行账户)</returns>
        public abstract List<tsBankEntity> tsBankList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsBankEntity实体类的List对象 (银行账户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsBank事务</param>
        /// <returns>tsBankEntity实体类的List对象(银行账户)</returns>
        public abstract List<tsBankEntity> tsBankList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsBankEntity实体类 (银行账户)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsBankEntity</returns>
        protected tsBankEntity PopulatetsBankEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsBankEntity nc = new tsBankEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("BankID") && !Convert.IsDBNull(dr["BankID"])) nc.BankID = Convert.ToInt16(dr["BankID"]); // 银行ID
            if (Fileds.ContainsKey("BankUser") && !Convert.IsDBNull(dr["BankUser"])) nc.BankUser = Convert.ToString(dr["BankUser"]).Trim(); // 银行户名
            if (Fileds.ContainsKey("BankAcc") && !Convert.IsDBNull(dr["BankAcc"])) nc.BankAcc = Convert.ToString(dr["BankAcc"]).Trim(); // 银行账号
            if (Fileds.ContainsKey("BankAddr") && !Convert.IsDBNull(dr["BankAddr"])) nc.BankAddr = Convert.ToString(dr["BankAddr"]).Trim(); // 开户地址
            if (Fileds.ContainsKey("IsDefault") && !Convert.IsDBNull(dr["IsDefault"])) nc.IsDefault = Convert.ToBoolean(dr["IsDefault"]); // 是否缺省
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // 备注
            return nc;
        }
        #endregion

        #region "tsBlack(黑名单) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsBlackEntity (黑名单)
        /// </summary>
        /// <param name="fam">tsBlack实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsBlackInsertUpdateDelete(tsBlackEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsBlackEntity (黑名单)
        /// </summary>
        /// <param name="fam">tsBlack实体类</param>
        /// <param name="tran">tsBlack事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsBlackInsertUpdateDelete(tsBlackEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsBlackEntity实体类的List对象 (黑名单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsBlackEntity实体类的List对象(黑名单)</returns>
        public abstract List<tsBlackEntity> tsBlackList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsBlackEntity实体类的List对象 (黑名单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsBlack事务</param>
        /// <returns>tsBlackEntity实体类的List对象(黑名单)</returns>
        public abstract List<tsBlackEntity> tsBlackList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsBlackEntity实体类 (黑名单)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsBlackEntity</returns>
        protected tsBlackEntity PopulatetsBlackEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsBlackEntity nc = new tsBlackEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("BlackUserID") && !Convert.IsDBNull(dr["BlackUserID"])) nc.BlackUserID = Convert.ToInt32(dr["BlackUserID"]); // 拉黑用户
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            return nc;
        }
        #endregion

        #region "tsCategory(商品分类) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsCategoryEntity (商品分类)
        /// </summary>
        /// <param name="fam">tsCategory实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsCategoryInsertUpdateDelete(tsCategoryEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsCategoryEntity (商品分类)
        /// </summary>
        /// <param name="fam">tsCategory实体类</param>
        /// <param name="tran">tsCategory事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsCategoryInsertUpdateDelete(tsCategoryEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsCategoryEntity实体类的List对象 (商品分类)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsCategoryEntity实体类的List对象(商品分类)</returns>
        public abstract List<tsCategoryEntity> tsCategoryList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsCategoryEntity实体类的List对象 (商品分类)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsCategory事务</param>
        /// <returns>tsCategoryEntity实体类的List对象(商品分类)</returns>
        public abstract List<tsCategoryEntity> tsCategoryList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsCategoryEntity实体类 (商品分类)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsCategoryEntity</returns>
        protected tsCategoryEntity PopulatetsCategoryEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsCategoryEntity nc = new tsCategoryEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("Category") && !Convert.IsDBNull(dr["Category"])) nc.Category = Convert.ToString(dr["Category"]).Trim(); // 分类
            if (Fileds.ContainsKey("ParentID") && !Convert.IsDBNull(dr["ParentID"])) nc.ParentID = Convert.ToInt32(dr["ParentID"]); // 父分类
            if (Fileds.ContainsKey("Depth") && !Convert.IsDBNull(dr["Depth"])) nc.Depth = Convert.ToInt32(dr["Depth"]); // 深度
            if (Fileds.ContainsKey("Spell") && !Convert.IsDBNull(dr["Spell"])) nc.Spell = Convert.ToString(dr["Spell"]).Trim(); // 拼音
            if (Fileds.ContainsKey("Order") && !Convert.IsDBNull(dr["Order"])) nc.Order = Convert.ToInt32(dr["Order"]); // 排序
            return nc;
        }
        #endregion

        #region "tsCompany(厂商) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsCompanyEntity (厂商)
        /// </summary>
        /// <param name="fam">tsCompany实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsCompanyInsertUpdateDelete(tsCompanyEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsCompanyEntity (厂商)
        /// </summary>
        /// <param name="fam">tsCompany实体类</param>
        /// <param name="tran">tsCompany事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsCompanyInsertUpdateDelete(tsCompanyEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsCompanyEntity实体类的List对象 (厂商)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsCompanyEntity实体类的List对象(厂商)</returns>
        public abstract List<tsCompanyEntity> tsCompanyList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsCompanyEntity实体类的List对象 (厂商)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsCompany事务</param>
        /// <returns>tsCompanyEntity实体类的List对象(厂商)</returns>
        public abstract List<tsCompanyEntity> tsCompanyList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsCompanyEntity实体类 (厂商)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsCompanyEntity</returns>
        protected tsCompanyEntity PopulatetsCompanyEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsCompanyEntity nc = new tsCompanyEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("Company") && !Convert.IsDBNull(dr["Company"])) nc.Company = Convert.ToString(dr["Company"]).Trim(); // 厂商
            return nc;
        }
        #endregion

        #region "tsCreditEval(信用评价) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsCreditEvalEntity (信用评价)
        /// </summary>
        /// <param name="fam">tsCreditEval实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsCreditEvalInsertUpdateDelete(tsCreditEvalEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsCreditEvalEntity (信用评价)
        /// </summary>
        /// <param name="fam">tsCreditEval实体类</param>
        /// <param name="tran">tsCreditEval事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsCreditEvalInsertUpdateDelete(tsCreditEvalEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsCreditEvalEntity实体类的List对象 (信用评价)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsCreditEvalEntity实体类的List对象(信用评价)</returns>
        public abstract List<tsCreditEvalEntity> tsCreditEvalList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsCreditEvalEntity实体类的List对象 (信用评价)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsCreditEval事务</param>
        /// <returns>tsCreditEvalEntity实体类的List对象(信用评价)</returns>
        public abstract List<tsCreditEvalEntity> tsCreditEvalList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsCreditEvalEntity实体类 (信用评价)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsCreditEvalEntity</returns>
        protected tsCreditEvalEntity PopulatetsCreditEvalEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsCreditEvalEntity nc = new tsCreditEvalEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("EvalDirect") && !Convert.IsDBNull(dr["EvalDirect"])) nc.EvalDirect = Convert.ToInt16(dr["EvalDirect"]); // 评价方向
            if (Fileds.ContainsKey("Beautifully") && !Convert.IsDBNull(dr["Beautifully"])) nc.Beautifully = Convert.ToInt32(dr["Beautifully"]); // 非常满意
            if (Fileds.ContainsKey("Good") && !Convert.IsDBNull(dr["Good"])) nc.Good = Convert.ToInt32(dr["Good"]); // 满意
            if (Fileds.ContainsKey("Normal") && !Convert.IsDBNull(dr["Normal"])) nc.Normal = Convert.ToInt32(dr["Normal"]); // 一般
            if (Fileds.ContainsKey("Poor") && !Convert.IsDBNull(dr["Poor"])) nc.Poor = Convert.ToInt32(dr["Poor"]); // 很差
            if (Fileds.ContainsKey("Score") && !Convert.IsDBNull(dr["Score"])) nc.Score = Convert.ToInt64(dr["Score"]); // 信用总分
            if (Fileds.ContainsKey("Level") && !Convert.IsDBNull(dr["Level"])) nc.Level = Convert.ToInt32(dr["Level"]); // 信用等级
            return nc;
        }
        #endregion

        #region "tsDict(数据字典) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsDictEntity (数据字典)
        /// </summary>
        /// <param name="fam">tsDict实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsDictInsertUpdateDelete(tsDictEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsDictEntity (数据字典)
        /// </summary>
        /// <param name="fam">tsDict实体类</param>
        /// <param name="tran">tsDict事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsDictInsertUpdateDelete(tsDictEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsDictEntity实体类的List对象 (数据字典)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsDictEntity实体类的List对象(数据字典)</returns>
        public abstract List<tsDictEntity> tsDictList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsDictEntity实体类的List对象 (数据字典)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsDict事务</param>
        /// <returns>tsDictEntity实体类的List对象(数据字典)</returns>
        public abstract List<tsDictEntity> tsDictList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsDictEntity实体类 (数据字典)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsDictEntity</returns>
        protected tsDictEntity PopulatetsDictEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsDictEntity nc = new tsDictEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("Key") && !Convert.IsDBNull(dr["Key"])) nc.Key = Convert.ToInt32(dr["Key"]); // 大类
            if (Fileds.ContainsKey("Name") && !Convert.IsDBNull(dr["Name"])) nc.Name = Convert.ToString(dr["Name"]).Trim(); // 名称
            if (Fileds.ContainsKey("Kind") && !Convert.IsDBNull(dr["Kind"])) nc.Kind = Convert.ToInt16(dr["Kind"]); // 小类
            if (Fileds.ContainsKey("Value") && !Convert.IsDBNull(dr["Value"])) nc.Value = Convert.ToString(dr["Value"]).Trim(); // 值
            return nc;
        }
        #endregion

        #region "tsFaction(阵营) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsFactionEntity (阵营)
        /// </summary>
        /// <param name="fam">tsFaction实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsFactionInsertUpdateDelete(tsFactionEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsFactionEntity (阵营)
        /// </summary>
        /// <param name="fam">tsFaction实体类</param>
        /// <param name="tran">tsFaction事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsFactionInsertUpdateDelete(tsFactionEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsFactionEntity实体类的List对象 (阵营)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsFactionEntity实体类的List对象(阵营)</returns>
        public abstract List<tsFactionEntity> tsFactionList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsFactionEntity实体类的List对象 (阵营)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsFaction事务</param>
        /// <returns>tsFactionEntity实体类的List对象(阵营)</returns>
        public abstract List<tsFactionEntity> tsFactionList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsFactionEntity实体类 (阵营)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsFactionEntity</returns>
        protected tsFactionEntity PopulatetsFactionEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsFactionEntity nc = new tsFactionEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("GameID") && !Convert.IsDBNull(dr["GameID"])) nc.GameID = Convert.ToInt32(dr["GameID"]); // 游戏ID
            if (Fileds.ContainsKey("Faction") && !Convert.IsDBNull(dr["Faction"])) nc.Faction = Convert.ToString(dr["Faction"]).Trim(); // 阵营
            return nc;
        }
        #endregion

        #region "tsGame(游戏) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsGameEntity (游戏)
        /// </summary>
        /// <param name="fam">tsGame实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsGameInsertUpdateDelete(tsGameEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsGameEntity (游戏)
        /// </summary>
        /// <param name="fam">tsGame实体类</param>
        /// <param name="tran">tsGame事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsGameInsertUpdateDelete(tsGameEntity fam, DbTransaction tran);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fam"></param>
        /// <returns></returns>
        public abstract Int32 tsActivityInsertUpdateDelete(tsActivityEntity fam);

        public abstract Int32 tsModuleInsertUpdateDelete(tsModuleEntity fam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fam"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public abstract Int32 tsActivityInsertUpdateDelete(tsActivityEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsGameEntity实体类的List对象 (游戏)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsGameEntity实体类的List对象(游戏)</returns>
        public abstract List<tsGameEntity> tsGameList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qp"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public abstract List<tsActivityEntity> tsActivityList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qp"></param>
        /// <param name="RecordCount"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public abstract List<tsActivityEntity> tsActivityList(QueryParam qp, out int RecordCount, DbTransaction tran);

        public abstract DataTable tbDuihuanList(QueryParam qp, out int RecordCount);

        public abstract DataTable tbGiveList(QueryParam qp, out int RecordCount);

        public abstract List<tsModuleEntity> tsModuleList(QueryParam qp, out int RecordCount);

        public abstract List<tsModuleEntity> tsModuleList(QueryParam qp, out int RecordCount, DbTransaction tran);



        /// <summary>
        /// 返回tsGameEntity实体类的List对象 (游戏)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsGame事务</param>
        /// <returns>tsGameEntity实体类的List对象(游戏)</returns>
        public abstract List<tsGameEntity> tsGameList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsGameEntity实体类 (游戏)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsGameEntity</returns>
        protected tsGameEntity PopulatetsGameEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsGameEntity nc = new tsGameEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("CompID") && !Convert.IsDBNull(dr["CompID"])) nc.CompID = Convert.ToInt32(dr["CompID"]); // 厂商ID
            if (Fileds.ContainsKey("Game") && !Convert.IsDBNull(dr["Game"])) nc.Game = Convert.ToString(dr["Game"]).Trim(); // 游戏
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // 描述
            if (Fileds.ContainsKey("IsOnline") && !Convert.IsDBNull(dr["IsOnline"])) nc.IsOnline = Convert.ToBoolean(dr["IsOnline"]); // 运营状态

            if (Fileds.ContainsKey("Sort") && !Convert.IsDBNull(dr["Sort"])) nc.Sort = Convert.ToInt32(dr["Sort"]); // 排序
            return nc;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsActivityEntity</returns>
        protected tsActivityEntity PopulatetsActivityEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsActivityEntity nc = new tsActivityEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("GameID") && !Convert.IsDBNull(dr["GameID"])) nc.GameID = Convert.ToInt32(dr["GameID"]); // 厂商ID
            if (Fileds.ContainsKey("ImageUrl") && !Convert.IsDBNull(dr["ImageUrl"])) nc.ImageUrl = Convert.ToString(dr["ImageUrl"]).Trim();
            if (Fileds.ContainsKey("name") && !Convert.IsDBNull(dr["name"])) nc.Name = Convert.ToString(dr["name"]).Trim();
            if (Fileds.ContainsKey("enable") && !Convert.IsDBNull(dr["enable"])) nc.Enable = Convert.ToBoolean(dr["enable"]); // 运营状态
            if (Fileds.ContainsKey("reward") && !Convert.IsDBNull(dr["reward"])) nc.Reward = Convert.ToDouble(dr["Reward"]); // MONEY
            if (Fileds.ContainsKey("content") && !Convert.IsDBNull(dr["content"])) nc.Content = Convert.ToString(dr["content"]).Trim();
            if (Fileds.ContainsKey("TimeLimit") && !Convert.IsDBNull(dr["TimeLimit"])) nc.TimeLimit = Convert.ToInt32(dr["TimeLimit"]); // 排序
            if (Fileds.ContainsKey("Sort") && !Convert.IsDBNull(dr["Sort"])) nc.Sort = Convert.ToInt32(dr["Sort"]); // 排序

            if (Fileds.ContainsKey("Game") && !Convert.IsDBNull(dr["Game"])) nc.Game = Convert.ToString(dr["Game"]).Trim();
            if (Fileds.ContainsKey("rule") && !Convert.IsDBNull(dr["rule"])) nc.Rule = Convert.ToString(dr["rule"]).Trim();
            if (Fileds.ContainsKey("Question") && !Convert.IsDBNull(dr["Question"])) nc.Question = Convert.ToString(dr["Question"]).Trim();

            if (Fileds.ContainsKey("StartPosition") && !Convert.IsDBNull(dr["StartPosition"])) nc.StartPosition = Convert.ToInt32(dr["StartPosition"]); // 排序
            if (Fileds.ContainsKey("EndPosition") && !Convert.IsDBNull(dr["EndPosition"])) nc.EndPosition = Convert.ToInt32(dr["EndPosition"]);

            if (Fileds.ContainsKey("num") && !Convert.IsDBNull(dr["num"])) nc.num = Convert.ToInt32(dr["num"]);
            if (Fileds.ContainsKey("StartD") && !Convert.IsDBNull(dr["StartD"])) nc.StartD = Convert.ToDateTime(dr["StartD"]);
            if (Fileds.ContainsKey("EndD") && !Convert.IsDBNull(dr["EndD"])) nc.EndD = Convert.ToDateTime(dr["EndD"]);

            if (Fileds.ContainsKey("ModuleID") && !Convert.IsDBNull(dr["ModuleID"])) nc.ModuleID = Convert.ToInt32(dr["ModuleID"]);
            return nc;
        }
        #endregion

        protected tsModuleEntity PopulatetsModuleEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsModuleEntity nc = new tsModuleEntity();
            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("Title") && !Convert.IsDBNull(dr["Title"])) nc.Title = Convert.ToString(dr["Title"]).Trim();
            if (Fileds.ContainsKey("Sort") && !Convert.IsDBNull(dr["Sort"])) nc.Sort = Convert.ToInt32(dr["Sort"]); // 排序
            if (Fileds.ContainsKey("Enable") && !Convert.IsDBNull(dr["Enable"])) nc.Enable = Convert.ToBoolean(dr["Enable"]); //运营状态
            if (Fileds.ContainsKey("Description") && !Convert.IsDBNull(dr["Description"])) nc.Description = Convert.ToString(dr["Description"]).Trim();
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim();
            return nc;
        }



        #region "tsGroup(用户分组) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsGroupEntity (用户分组)
        /// </summary>
        /// <param name="fam">tsGroup实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsGroupInsertUpdateDelete(tsGroupEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsGroupEntity (用户分组)
        /// </summary>
        /// <param name="fam">tsGroup实体类</param>
        /// <param name="tran">tsGroup事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsGroupInsertUpdateDelete(tsGroupEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsGroupEntity实体类的List对象 (用户分组)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsGroupEntity实体类的List对象(用户分组)</returns>
        public abstract List<tsGroupEntity> tsGroupList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsGroupEntity实体类的List对象 (用户分组)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsGroup事务</param>
        /// <returns>tsGroupEntity实体类的List对象(用户分组)</returns>
        public abstract List<tsGroupEntity> tsGroupList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsGroupEntity实体类 (用户分组)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsGroupEntity</returns>
        protected tsGroupEntity PopulatetsGroupEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsGroupEntity nc = new tsGroupEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("Name") && !Convert.IsDBNull(dr["Name"])) nc.Name = Convert.ToString(dr["Name"]).Trim(); // 名称
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // CreateDate
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // 描述
            return nc;
        }
        #endregion

        #region "tsMember(用户成员) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsMemberEntity (用户成员)
        /// </summary>
        /// <param name="fam">tsMember实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsMemberInsertUpdateDelete(tsMemberEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsMemberEntity (用户成员)
        /// </summary>
        /// <param name="fam">tsMember实体类</param>
        /// <param name="tran">tsMember事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsMemberInsertUpdateDelete(tsMemberEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsMemberEntity实体类的List对象 (用户成员)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsMemberEntity实体类的List对象(用户成员)</returns>
        public abstract List<tsMemberEntity> tsMemberList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsMemberEntity实体类的List对象 (用户成员)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsMember事务</param>
        /// <returns>tsMemberEntity实体类的List对象(用户成员)</returns>
        public abstract List<tsMemberEntity> tsMemberList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsMemberEntity实体类 (用户成员)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsMemberEntity</returns>
        protected tsMemberEntity PopulatetsMemberEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsMemberEntity nc = new tsMemberEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("GroupID") && !Convert.IsDBNull(dr["GroupID"])) nc.GroupID = Convert.ToInt32(dr["GroupID"]); // 用户分组ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("MemberUserID") && !Convert.IsDBNull(dr["MemberUserID"])) nc.MemberUserID = Convert.ToInt32(dr["MemberUserID"]); // 成员用户
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // 描述
            return nc;
        }
        #endregion

        #region "tsMoney(余额) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsMoneyEntity (余额)
        /// </summary>
        /// <param name="fam">tsMoney实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsMoneyInsertUpdateDelete(tsMoneyEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsMoneyEntity (余额)
        /// </summary>
        /// <param name="fam">tsMoney实体类</param>
        /// <param name="tran">tsMoney事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsMoneyInsertUpdateDelete(tsMoneyEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsMoneyEntity实体类的List对象 (余额)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsMoneyEntity实体类的List对象(余额)</returns>
        public abstract List<tsMoneyEntity> tsMoneyList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsMoneyEntity实体类的List对象 (余额)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsMoney事务</param>
        /// <returns>tsMoneyEntity实体类的List对象(余额)</returns>
        public abstract List<tsMoneyEntity> tsMoneyList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsMoneyEntity实体类 (余额)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsMoneyEntity</returns>
        protected tsMoneyEntity PopulatetsMoneyEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsMoneyEntity nc = new tsMoneyEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("SumBal") && !Convert.IsDBNull(dr["SumBal"])) nc.SumBal = Convert.ToDouble(dr["SumBal"]); // 总金额
            if (Fileds.ContainsKey("FreezeBal") && !Convert.IsDBNull(dr["FreezeBal"])) nc.FreezeBal = Convert.ToDouble(dr["FreezeBal"]); // 冻结资金
            if (Fileds.ContainsKey("ChangeDate") && !Convert.IsDBNull(dr["ChangeDate"])) nc.ChangeDate = Convert.ToDateTime(dr["ChangeDate"]); // 变动日期
            return nc;
        }
        #endregion

        #region "tsRightLock(权限锁定) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsRightLockEntity (权限锁定)
        /// </summary>
        /// <param name="fam">tsRightLock实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsRightLockInsertUpdateDelete(tsRightLockEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsRightLockEntity (权限锁定)
        /// </summary>
        /// <param name="fam">tsRightLock实体类</param>
        /// <param name="tran">tsRightLock事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsRightLockInsertUpdateDelete(tsRightLockEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsRightLockEntity实体类的List对象 (权限锁定)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsRightLockEntity实体类的List对象(权限锁定)</returns>
        public abstract List<tsRightLockEntity> tsRightLockList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsRightLockEntity实体类的List对象 (权限锁定)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsRightLock事务</param>
        /// <returns>tsRightLockEntity实体类的List对象(权限锁定)</returns>
        public abstract List<tsRightLockEntity> tsRightLockList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsRightLockEntity实体类 (权限锁定)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsRightLockEntity</returns>
        protected tsRightLockEntity PopulatetsRightLockEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsRightLockEntity nc = new tsRightLockEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("LockType") && !Convert.IsDBNull(dr["LockType"])) nc.LockType = Convert.ToInt16(dr["LockType"]); // 锁定类别
            if (Fileds.ContainsKey("IsForever") && !Convert.IsDBNull(dr["IsForever"])) nc.IsForever = Convert.ToBoolean(dr["IsForever"]); // 是否永久
            if (Fileds.ContainsKey("StartDate") && !Convert.IsDBNull(dr["StartDate"])) nc.StartDate = Convert.ToDateTime(dr["StartDate"]); // 开始日期
            if (Fileds.ContainsKey("EndDate") && !Convert.IsDBNull(dr["EndDate"])) nc.EndDate = Convert.ToDateTime(dr["EndDate"]); // 结束日期
            if (Fileds.ContainsKey("Notice") && !Convert.IsDBNull(dr["Notice"])) nc.Notice = Convert.ToString(dr["Notice"]).Trim(); // 通知内容
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间

            if (Fileds.ContainsKey("ActivityID") && !Convert.IsDBNull(dr["ActivityID"])) nc.ActivityID = Convert.ToInt16(dr["ActivityID"]);
            if (Fileds.ContainsKey("Condition") && !Convert.IsDBNull(dr["Condition"])) nc.Condition = Convert.ToString(dr["Condition"]).Trim();

            if (Fileds.ContainsKey("ModuleID") && !Convert.IsDBNull(dr["ModuleID"])) nc.ModuleID = Convert.ToInt16(dr["ModuleID"]);
            return nc;
        }
        #endregion

        #region "tsSerialNo(流水号) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsSerialNoEntity (流水号)
        /// </summary>
        /// <param name="fam">tsSerialNo实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsSerialNoInsertUpdateDelete(tsSerialNoEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsSerialNoEntity (流水号)
        /// </summary>
        /// <param name="fam">tsSerialNo实体类</param>
        /// <param name="tran">tsSerialNo事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsSerialNoInsertUpdateDelete(tsSerialNoEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsSerialNoEntity实体类的List对象 (流水号)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsSerialNoEntity实体类的List对象(流水号)</returns>
        public abstract List<tsSerialNoEntity> tsSerialNoList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsSerialNoEntity实体类的List对象 (流水号)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsSerialNo事务</param>
        /// <returns>tsSerialNoEntity实体类的List对象(流水号)</returns>
        public abstract List<tsSerialNoEntity> tsSerialNoList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsSerialNoEntity实体类 (流水号)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsSerialNoEntity</returns>
        protected tsSerialNoEntity PopulatetsSerialNoEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsSerialNoEntity nc = new tsSerialNoEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("SType") && !Convert.IsDBNull(dr["SType"])) nc.SType = Convert.ToString(dr["SType"]).Trim(); // 类别
            if (Fileds.ContainsKey("Prefix") && !Convert.IsDBNull(dr["Prefix"])) nc.Prefix = Convert.ToString(dr["Prefix"]).Trim(); // 前缀
            if (Fileds.ContainsKey("Seed") && !Convert.IsDBNull(dr["Seed"])) nc.Seed = Convert.ToInt32(dr["Seed"]); // 种子
            return nc;
        }
        #endregion

        #region "tsServer(服务器) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsServerEntity (服务器)
        /// </summary>
        /// <param name="fam">tsServer实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsServerInsertUpdateDelete(tsServerEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsServerEntity (服务器)
        /// </summary>
        /// <param name="fam">tsServer实体类</param>
        /// <param name="tran">tsServer事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsServerInsertUpdateDelete(tsServerEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsServerEntity实体类的List对象 (服务器)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsServerEntity实体类的List对象(服务器)</returns>
        public abstract List<tsServerEntity> tsServerList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsServerEntity实体类的List对象 (服务器)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsServer事务</param>
        /// <returns>tsServerEntity实体类的List对象(服务器)</returns>
        public abstract List<tsServerEntity> tsServerList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsServerEntity实体类 (服务器)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsServerEntity</returns>
        protected tsServerEntity PopulatetsServerEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsServerEntity nc = new tsServerEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("ZoneID") && !Convert.IsDBNull(dr["ZoneID"])) nc.ZoneID = Convert.ToInt32(dr["ZoneID"]); // 大区ID
            if (Fileds.ContainsKey("Server") && !Convert.IsDBNull(dr["Server"])) nc.Server = Convert.ToString(dr["Server"]).Trim(); // 服务器

            if (Fileds.ContainsKey("Sort") && !Convert.IsDBNull(dr["Sort"])) nc.Sort = Convert.ToInt32(dr["Sort"]); // 排序
            return nc;
        }
        #endregion

        #region "tsSMSPlat(短信平台) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsSMSPlatEntity (短信平台)
        /// </summary>
        /// <param name="fam">tsSMSPlat实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsSMSPlatInsertUpdateDelete(tsSMSPlatEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsSMSPlatEntity (短信平台)
        /// </summary>
        /// <param name="fam">tsSMSPlat实体类</param>
        /// <param name="tran">tsSMSPlat事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsSMSPlatInsertUpdateDelete(tsSMSPlatEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsSMSPlatEntity实体类的List对象 (短信平台)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsSMSPlatEntity实体类的List对象(短信平台)</returns>
        public abstract List<tsSMSPlatEntity> tsSMSPlatList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsSMSPlatEntity实体类的List对象 (短信平台)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsSMSPlat事务</param>
        /// <returns>tsSMSPlatEntity实体类的List对象(短信平台)</returns>
        public abstract List<tsSMSPlatEntity> tsSMSPlatList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsSMSPlatEntity实体类 (短信平台)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsSMSPlatEntity</returns>
        protected tsSMSPlatEntity PopulatetsSMSPlatEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsSMSPlatEntity nc = new tsSMSPlatEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("PlatName") && !Convert.IsDBNull(dr["PlatName"])) nc.PlatName = Convert.ToString(dr["PlatName"]).Trim(); // 平台名称
            if (Fileds.ContainsKey("PostUrl") && !Convert.IsDBNull(dr["PostUrl"])) nc.PostUrl = Convert.ToString(dr["PostUrl"]).Trim(); // 提交地址
            if (Fileds.ContainsKey("UserName") && !Convert.IsDBNull(dr["UserName"])) nc.UserName = Convert.ToString(dr["UserName"]).Trim(); // 用户名
            if (Fileds.ContainsKey("Password") && !Convert.IsDBNull(dr["Password"])) nc.Password = Convert.ToString(dr["Password"]).Trim(); // 密码
            if (Fileds.ContainsKey("AppID") && !Convert.IsDBNull(dr["AppID"])) nc.AppID = Convert.ToString(dr["AppID"]).Trim(); // 应用ID
            if (Fileds.ContainsKey("SuccessKey") && !Convert.IsDBNull(dr["SuccessKey"])) nc.SuccessKey = Convert.ToString(dr["SuccessKey"]).Trim(); // 成功关键字
            if (Fileds.ContainsKey("SmsStyle") && !Convert.IsDBNull(dr["SmsStyle"])) nc.SmsStyle = Convert.ToInt16(dr["SmsStyle"]); // 发送方式
            if (Fileds.ContainsKey("IsEnable") && !Convert.IsDBNull(dr["IsEnable"])) nc.IsEnable = Convert.ToBoolean(dr["IsEnable"]); // 是否使用
            return nc;
        }
        #endregion

        #region "tsSubUser(子用户) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsSubUserEntity (子用户)
        /// </summary>
        /// <param name="fam">tsSubUser实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsSubUserInsertUpdateDelete(tsSubUserEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsSubUserEntity (子用户)
        /// </summary>
        /// <param name="fam">tsSubUser实体类</param>
        /// <param name="tran">tsSubUser事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsSubUserInsertUpdateDelete(tsSubUserEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsSubUserEntity实体类的List对象 (子用户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsSubUserEntity实体类的List对象(子用户)</returns>
        public abstract List<tsSubUserEntity> tsSubUserList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsSubUserEntity实体类的List对象 (子用户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsSubUser事务</param>
        /// <returns>tsSubUserEntity实体类的List对象(子用户)</returns>
        public abstract List<tsSubUserEntity> tsSubUserList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsSubUserEntity实体类 (子用户)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsSubUserEntity</returns>
        protected tsSubUserEntity PopulatetsSubUserEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsSubUserEntity nc = new tsSubUserEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("LoginID") && !Convert.IsDBNull(dr["LoginID"])) nc.LoginID = Convert.ToString(dr["LoginID"]).Trim(); // 登录ID
            if (Fileds.ContainsKey("SubUserName") && !Convert.IsDBNull(dr["SubUserName"])) nc.SubUserName = Convert.ToString(dr["SubUserName"]).Trim(); // 姓名
            if (Fileds.ContainsKey("Pass") && !Convert.IsDBNull(dr["Pass"])) nc.Pass = Convert.ToString(dr["Pass"]).Trim(); // 登录密码
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // 备注
            if (Fileds.ContainsKey("Token") && !Convert.IsDBNull(dr["Token"])) nc.Token = Convert.ToString(dr["Token"]).Trim(); // 令牌
            if (Fileds.ContainsKey("LiveTime") && !Convert.IsDBNull(dr["LiveTime"])) nc.LiveTime = Convert.ToDateTime(dr["LiveTime"]); // 活动时间
            return nc;
        }
        #endregion

        #region "tsSysParam(系统参数) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsSysParamEntity (系统参数)
        /// </summary>
        /// <param name="fam">tsSysParam实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsSysParamInsertUpdateDelete(tsSysParamEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsSysParamEntity (系统参数)
        /// </summary>
        /// <param name="fam">tsSysParam实体类</param>
        /// <param name="tran">tsSysParam事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsSysParamInsertUpdateDelete(tsSysParamEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsSysParamEntity实体类的List对象 (系统参数)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsSysParamEntity实体类的List对象(系统参数)</returns>
        public abstract List<tsSysParamEntity> tsSysParamList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsSysParamEntity实体类的List对象 (系统参数)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsSysParam事务</param>
        /// <returns>tsSysParamEntity实体类的List对象(系统参数)</returns>
        public abstract List<tsSysParamEntity> tsSysParamList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsSysParamEntity实体类 (系统参数)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsSysParamEntity</returns>
        protected tsSysParamEntity PopulatetsSysParamEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsSysParamEntity nc = new tsSysParamEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("Name") && !Convert.IsDBNull(dr["Name"])) nc.Name = Convert.ToString(dr["Name"]).Trim(); // 名称
            if (Fileds.ContainsKey("Value") && !Convert.IsDBNull(dr["Value"])) nc.Value = Convert.ToString(dr["Value"]).Trim(); // 值
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // 描述
            return nc;
        }
        #endregion

        #region "tsUser(用户) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsUserEntity (用户)
        /// </summary>
        /// <param name="fam">tsUser实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsUserInsertUpdateDelete(tsUserEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsUserEntity (用户)
        /// </summary>
        /// <param name="fam">tsUser实体类</param>
        /// <param name="tran">tsUser事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsUserInsertUpdateDelete(tsUserEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsUserEntity实体类的List对象 (用户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsUserEntity实体类的List对象(用户)</returns>
        public abstract List<tsUserEntity> tsUserList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsUserEntity实体类的List对象 (用户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsUser事务</param>
        /// <returns>tsUserEntity实体类的List对象(用户)</returns>
        public abstract List<tsUserEntity> tsUserList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsUserEntity实体类 (用户)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsUserEntity</returns>
        protected tsUserEntity PopulatetsUserEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsUserEntity nc = new tsUserEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UID") && !Convert.IsDBNull(dr["UID"])) nc.UID = Convert.ToString(dr["UID"]).Trim(); // 字符串ID
            if (Fileds.ContainsKey("Nickname") && !Convert.IsDBNull(dr["Nickname"])) nc.Nickname = Convert.ToString(dr["Nickname"]).Trim(); // 昵称
            if (Fileds.ContainsKey("LoginID") && !Convert.IsDBNull(dr["LoginID"])) nc.LoginID = Convert.ToString(dr["LoginID"]).Trim(); // 登录ID
            if (Fileds.ContainsKey("Pass") && !Convert.IsDBNull(dr["Pass"])) nc.Pass = Convert.ToString(dr["Pass"]).Trim(); // 登录密码
            if (Fileds.ContainsKey("Email") && !Convert.IsDBNull(dr["Email"])) nc.Email = Convert.ToString(dr["Email"]).Trim(); // 邮箱
            if (Fileds.ContainsKey("QQ") && !Convert.IsDBNull(dr["QQ"])) nc.QQ = Convert.ToString(dr["QQ"]).Trim(); // 联系QQ
            if (Fileds.ContainsKey("Mobile") && !Convert.IsDBNull(dr["Mobile"])) nc.Mobile = Convert.ToString(dr["Mobile"]).Trim(); // 联系电话
            if (Fileds.ContainsKey("Question") && !Convert.IsDBNull(dr["Question"])) nc.Question = Convert.ToString(dr["Question"]).Trim(); // 安全问题
            if (Fileds.ContainsKey("Answer") && !Convert.IsDBNull(dr["Answer"])) nc.Answer = Convert.ToString(dr["Answer"]).Trim(); // 安全答案
            if (Fileds.ContainsKey("BindMobile") && !Convert.IsDBNull(dr["BindMobile"])) nc.BindMobile = Convert.ToString(dr["BindMobile"]).Trim(); // 绑定手机
            if (Fileds.ContainsKey("PayPass") && !Convert.IsDBNull(dr["PayPass"])) nc.PayPass = Convert.ToString(dr["PayPass"]).Trim(); // 支付密码
            if (Fileds.ContainsKey("LoginMode") && !Convert.IsDBNull(dr["LoginMode"])) nc.LoginMode = Convert.ToInt16(dr["LoginMode"]); // 登录模式
            if (Fileds.ContainsKey("IsOnline") && !Convert.IsDBNull(dr["IsOnline"])) nc.IsOnline = Convert.ToInt16(dr["IsOnline"]); // 在线状态
            if (Fileds.ContainsKey("HaveSubUser") && !Convert.IsDBNull(dr["HaveSubUser"])) nc.HaveSubUser = Convert.ToBoolean(dr["HaveSubUser"]); // 有子帐号
            if (Fileds.ContainsKey("IconIndex") && !Convert.IsDBNull(dr["IconIndex"])) nc.IconIndex = Convert.ToInt32(dr["IconIndex"]); // 图标序号
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // 创建时间
            if (Fileds.ContainsKey("LoginDate") && !Convert.IsDBNull(dr["LoginDate"])) nc.LoginDate = Convert.ToDateTime(dr["LoginDate"]); // 登录时间
            if (Fileds.ContainsKey("Status") && !Convert.IsDBNull(dr["Status"])) nc.Status = Convert.ToInt16(dr["Status"]); // 状态
            if (Fileds.ContainsKey("Sign") && !Convert.IsDBNull(dr["Sign"])) nc.Sign = Convert.ToString(dr["Sign"]).Trim(); // 签名
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // 备注
            return nc;
        }
        #endregion

        #region "tsUserToken(授权令牌) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsUserTokenEntity (授权令牌)
        /// </summary>
        /// <param name="fam">tsUserToken实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsUserTokenInsertUpdateDelete(tsUserTokenEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsUserTokenEntity (授权令牌)
        /// </summary>
        /// <param name="fam">tsUserToken实体类</param>
        /// <param name="tran">tsUserToken事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsUserTokenInsertUpdateDelete(tsUserTokenEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsUserTokenEntity实体类的List对象 (授权令牌)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsUserTokenEntity实体类的List对象(授权令牌)</returns>
        public abstract List<tsUserTokenEntity> tsUserTokenList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsUserTokenEntity实体类的List对象 (授权令牌)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsUserToken事务</param>
        /// <returns>tsUserTokenEntity实体类的List对象(授权令牌)</returns>
        public abstract List<tsUserTokenEntity> tsUserTokenList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsUserTokenEntity实体类 (授权令牌)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsUserTokenEntity</returns>
        protected tsUserTokenEntity PopulatetsUserTokenEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsUserTokenEntity nc = new tsUserTokenEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // 用户ID
            if (Fileds.ContainsKey("Token") && !Convert.IsDBNull(dr["Token"])) nc.Token = Convert.ToString(dr["Token"]).Trim(); // 令牌
            if (Fileds.ContainsKey("LiveTime") && !Convert.IsDBNull(dr["LiveTime"])) nc.LiveTime = Convert.ToDateTime(dr["LiveTime"]); // 活动时间
            return nc;
        }
        #endregion

        #region "tsZone(大区) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsZoneEntity (大区)
        /// </summary>
        /// <param name="fam">tsZone实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsZoneInsertUpdateDelete(tsZoneEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsZoneEntity (大区)
        /// </summary>
        /// <param name="fam">tsZone实体类</param>
        /// <param name="tran">tsZone事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsZoneInsertUpdateDelete(tsZoneEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsZoneEntity实体类的List对象 (大区)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsZoneEntity实体类的List对象(大区)</returns>
        public abstract List<tsZoneEntity> tsZoneList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsZoneEntity实体类的List对象 (大区)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsZone事务</param>
        /// <returns>tsZoneEntity实体类的List对象(大区)</returns>
        public abstract List<tsZoneEntity> tsZoneList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsZoneEntity实体类 (大区)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsZoneEntity</returns>
        protected tsZoneEntity PopulatetsZoneEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsZoneEntity nc = new tsZoneEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("GameID") && !Convert.IsDBNull(dr["GameID"])) nc.GameID = Convert.ToInt32(dr["GameID"]); // 游戏ID
            if (Fileds.ContainsKey("Zone") && !Convert.IsDBNull(dr["Zone"])) nc.Zone = Convert.ToString(dr["Zone"]).Trim(); // 大区

            if (Fileds.ContainsKey("Sort") && !Convert.IsDBNull(dr["Sort"])) nc.Sort = Convert.ToInt32(dr["Sort"]); // 排序
            return nc;
        }
        #endregion

        #region "tsZoneServer(区服汇总) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsZoneServerEntity (区服汇总)
        /// </summary>
        /// <param name="fam">tsZoneServer实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsZoneServerInsertUpdateDelete(tsZoneServerEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsZoneServerEntity (区服汇总)
        /// </summary>
        /// <param name="fam">tsZoneServer实体类</param>
        /// <param name="tran">tsZoneServer事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tsZoneServerInsertUpdateDelete(tsZoneServerEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsZoneServerEntity实体类的List对象 (区服汇总)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsZoneServerEntity实体类的List对象(区服汇总)</returns>
        public abstract List<tsZoneServerEntity> tsZoneServerList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsZoneServerEntity实体类的List对象 (区服汇总)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsZoneServer事务</param>
        /// <returns>tsZoneServerEntity实体类的List对象(区服汇总)</returns>
        public abstract List<tsZoneServerEntity> tsZoneServerList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsZoneServerEntity实体类 (区服汇总)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsZoneServerEntity</returns>
        protected tsZoneServerEntity PopulatetsZoneServerEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsZoneServerEntity nc = new tsZoneServerEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("Code") && !Convert.IsDBNull(dr["Code"])) nc.Code = Convert.ToString(dr["Code"]).Trim(); // 编码
            if (Fileds.ContainsKey("GameID") && !Convert.IsDBNull(dr["GameID"])) nc.GameID = Convert.ToInt32(dr["GameID"]); // 游戏ID
            if (Fileds.ContainsKey("Game") && !Convert.IsDBNull(dr["Game"])) nc.Game = Convert.ToString(dr["Game"]).Trim(); // 游戏
            if (Fileds.ContainsKey("ZoneID") && !Convert.IsDBNull(dr["ZoneID"])) nc.ZoneID = Convert.ToInt32(dr["ZoneID"]); // 大区ID
            if (Fileds.ContainsKey("Zone") && !Convert.IsDBNull(dr["Zone"])) nc.Zone = Convert.ToString(dr["Zone"]).Trim(); // 大区
            if (Fileds.ContainsKey("ServerID") && !Convert.IsDBNull(dr["ServerID"])) nc.ServerID = Convert.ToInt32(dr["ServerID"]); // 服务器ID
            if (Fileds.ContainsKey("Server") && !Convert.IsDBNull(dr["Server"])) nc.Server = Convert.ToString(dr["Server"]).Trim(); // 服务器
            if (Fileds.ContainsKey("FactionID") && !Convert.IsDBNull(dr["FactionID"])) nc.FactionID = Convert.ToInt32(dr["FactionID"]); // 阵营ID
            if (Fileds.ContainsKey("Faction") && !Convert.IsDBNull(dr["Faction"])) nc.Faction = Convert.ToString(dr["Faction"]).Trim(); // 阵营
            if (Fileds.ContainsKey("SpellFull") && !Convert.IsDBNull(dr["SpellFull"])) nc.SpellFull = Convert.ToString(dr["SpellFull"]).Trim(); // 拼音全称
            if (Fileds.ContainsKey("SpellShort") && !Convert.IsDBNull(dr["SpellShort"])) nc.SpellShort = Convert.ToString(dr["SpellShort"]).Trim(); // 拼音简称
            if (Fileds.ContainsKey("IsOnline") && !Convert.IsDBNull(dr["IsOnline"])) nc.IsOnline = Convert.ToBoolean(dr["IsOnline"]); // 运营状态
            return nc;
        }
        #endregion


        #region "tbMobileToken(验证码查询) - Method"
        /// <summary>
        /// 验证码查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public abstract DataSet GetMobileToken(int PageIndex, int PageSize, string Where);
        #endregion

        #region "tsRightLock(权限锁定查询) - Method"
        /// <summary>
        /// 验证码查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public abstract DataSet RightLockList(int PageIndex, int PageSize, string Where);
        #endregion


        #region "tbRecharge(充值流水查询) - Method"
        /// <summary>
        /// 充值流水查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public abstract DataSet GetRecharge(int PageIndex, int PageSize, string Where);
        #endregion

        #region "WithdrawDeposit(提现汇款查询) - Method"
        /// <summary>
        /// 充值流水查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract DataSet WithdrawDeposit(int PageIndex, int PageSize, string Where, int type, int order, int isGood);
        #endregion

        public abstract DataSet LevelOrderJudgListByID(int PageIndex, int PageSize, string Where, string type);

        public abstract DataSet LevelOrderJudgList(int PageIndex, int PageSize, string Where);

        public abstract DataSet LevelOrderJudgCount(string SerialNo);

        public abstract DataSet OrderTitle(string SerialNo);

        public abstract DataSet LevelOrderMyJudgStatus(string SerialNo, int CustomerID);

        public abstract DataSet IsLockWithDraw(string uid);

        public abstract DataSet GetWithdrawDeposit(string SerialNo, string OPID);

        public abstract DataSet LockWithDraw(string SerialNo, int LockType, string OPID);

        public abstract DataSet BankTransferDetailList(DateTime StartDate, DateTime EndDate, string Keyword, string SearchText, string Result, int PageIndex, int PageSize);

        #region "OperateList(用户操作日志) - Method"
        /// <summary>
        /// 充值流水查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract DataSet OperateList(int PageIndex, int PageSize, string Where);
        #endregion

        public abstract DataSet JugeReason(int PageIndex, int PageSize, string Where, string Where2);

        public abstract DataSet ChatMessageList(int PageIndex, int PageSize, string Where);

        #region "UserList(用户操作日志) - Method"
        /// <summary>
        /// 充值流水查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract DataSet UserList(int PageIndex, int PageSize, string Where);

        public abstract DataSet UserListByMAC(string ID, int PageIndex, int PageSize);

        public abstract DataSet UserListByHD(string ID, int PageIndex, int PageSize);

        public abstract DataSet UserListByMAC1(string MAC, int PageIndex, int PageSize);

        #endregion

        public abstract DataSet UserAnalysisList(int PageIndex, int PageSize, string Where);

        public abstract int SetUserSubAccount(string UserID, int Status);

        public abstract int UserLog(int UserID, int OPType, string OPLog, string IP);

        public abstract int DeleteNewsComment(int NewsID);

        #region "LevelOrderMessage(用户订单留言交互查询) - Method"
        /// <summary>
        /// 充值流水查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract DataSet LevelOrderMessage(int PageIndex, int PageSize, string Where);
        #endregion

        public abstract DataSet LevelOrderMessageHis(int PageIndex, int PageSize, string Where);

        public abstract void UserMoneyChange(int UserID, int ChangeType, decimal ChangeBal, string RelaSerialNo, string Comment);

        public abstract DataSet UserMoneyChangeJudge(int UserID, decimal ChangeBal);

        public abstract DataSet ServiceMaxPrice(string OPID, int Type, decimal ChangeBal);

        #region "LoginList(用户登录日志) - Method"
        /// <summary>
        /// 充值流水查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract DataSet LoginList(int PageIndex, int PageSize, string Where);
        #endregion

        public abstract DataSet PendingMattersList(int PageIndex, int PageSize, string Where);

        public abstract DataSet UserOrderList(DateTime Start, DateTime End, string OPID, int PageIndex, int PageSize);


        #region "WithdrawSuccess(确认提现汇款) - Method"
        /// <summary>
        /// 充值流水查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract string WithdrawSuccess(string SerialNo, string BankSerialNo, string Comment, int OPID);
        #endregion

        #region "ZoneServer(区服汇总) - Method"
        /// <summary>
        /// 充值流水查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract string ZoneServer(string ZoneID, string ServerName);
        #endregion

        #region "UserIsLock(用户是否存在锁定记录) - Method"
        /// <summary>
        /// 充值流水查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Where"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract string UserIsLock(int UserID, int LockType);
        #endregion


        #region "客户提现汇款管理 提现处理 撤销提现"
        /// <summary>
        /// 撤销提现
        /// </summary>
        /// <param name="WalletID"></param>
        /// <param name="Comment"></param>
        /// <returns></returns>
        public abstract string WithdrawCancel(string SerialNo, string Comment, int OPID);

        #endregion

        #region "订单查询"
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <param name="Keyword"></param>
        /// <param name="SearchText"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public abstract DataSet OrderSelect(DateTime sDate, DateTime eDate, string Keyword, string SearchText, string Status, string CancelStatus, bool IsHisOrder, int PageIndex, int PageSize, string OrderType, string Game, string AppointUser, string isPub);

        #endregion


        public abstract DataSet ActivityOrderSelect(int PageIndex, int PageSize, string ActivityID);

        public abstract DataSet ActivityAllOrderSelect(int PageIndex, int PageSize, string Where);

        public abstract DataSet ActivityOrderSelectDel(int PageIndex, int PageSize, string ActivityID);

        public abstract DataSet OrderEvent(DateTime sDate, DateTime eDate, string search, string Keyword, int PageIndex, int PageSize);

        public abstract DataSet PhonePwdEvent(DateTime sDate, DateTime eDate, string type, string search, string Keyword, int PageIndex, int PageSize);

        public abstract DataSet OrderSelectHis(DateTime sDate, DateTime eDate, string Keyword, string SearchText, string Status, string CancelStatus, bool IsHisOrder, int PageIndex, int PageSize, string OrderType, string Game);

        #region "删除订单查询"
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <param name="Keyword"></param>
        /// <param name="SearchText"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public abstract DataSet OrderSelectDel(DateTime sDate, DateTime eDate, string Keyword, string SearchText, string Status, string CancelStatus, bool IsHisOrder, int PageIndex, int PageSize, string OrderType, string SearchType, string Game);

        #endregion

        public abstract DataSet SetUserLock(int ID, int LockType, DateTime StartDate, DateTime EndDate, string Notice, int ActivityID, string Condition, int OnOff, int ModuleID);

        public abstract DataSet SetUserLock(int ID, int LockType, DateTime StartDate, DateTime EndDate, string Notice, int ActivityID, string Condition, int OnOff);

        public abstract int IsForbidLogin(int ID);

        public abstract DataSet MarkFirstViewOrder(string SerialNo, int OPID);

        public abstract DataSet GetOrderProgress(string SerialNo);

        public abstract DataSet MarkLookOrder(string SerialNo, int OPID, int Mark);

        public abstract DataSet SetOrderCancelStatus(string SerialNo, int Status);

        public abstract DataSet UpdateComment(string SerialNo, string Comment);

        public abstract DataSet UpdateActivityOrderComment(string ActivityID, string Comment);

        public abstract DataSet AddActivityOrder(string ActivityID, string SerialNo);

        public abstract DataSet CheckActivityOrder(string ActivityID, string SerialNo);

        public abstract DataSet IsActivityBlack(string SerialNo);

        public abstract DataSet GetLevelOrderActivityList(int PageIndex, int PageSize, string ActivityID);

        public abstract DataSet ActivityOrderRela(int UserID, string ActivityID);

        public abstract DataSet DeleteActivityOrder(int ActivityID);

        public abstract DataSet UpdateRejudgComment(string SerialNo, string Comment);

        public abstract DataSet GetUserTrackInfo(string UserID, int PageIndex, int PageSize);

        public abstract int DeleteUserTrack(string SerialNo);

        public abstract DataSet GetUserTrackInfoComment(string UserID, int PageIndex, int PageSize);

        public abstract DataSet GetUserAccountProved(string UserID);


        public abstract DataSet AddUserTrackInfo(string UserID, string TrackInfo, int Score, int OPID, string SerialNo);

        public abstract void InsertServiceHelp(string ODSerialNo, int UserID, int AcceptUserID, string Content, int HelpType);

        public abstract void DeleteServiceHelp(string ODSerialNo);

        public abstract void UpdateServiceHelp(string ODSerialNo, int IsDeal, string OPID);

        public abstract void UpdatePostReport(string SerialNo, int Status, string OPID);

        public abstract void UpdateFeedBackMark(string id, int Mark);

        public abstract void FirstCheck(string id, int Mark);

        public abstract DataSet PostReportCount(DateTime Start, DateTime End);

        public abstract void UpdateRejudgColor(string ID, int IsDeal);

        public abstract void LevelOrderMarkColor(string ODSerialNo, string OPID);

        public abstract void AddLevelOrderReJudg(string SerialNo, string Reason, int OPID);

        public abstract DataSet AddUserTrackInfoComment(string UserID, string TrackInfo, int Score, int OPID);

        public abstract DataSet AddUserAccountProved(string UserID, string Evidence, int IsDeal, int OPID);

        public abstract DataSet AddOrderJudg(string ODSerialNo);

        public abstract DataSet OrderOPStat(DateTime StartDate, DateTime EndDate, string OPName, string SearchType);

        public abstract DataSet JROrderStat(DateTime StartDate, DateTime EndDate, string GameID, string PostUserID);

        public abstract DataSet OrderPostStat(DateTime StartDate, DateTime EndDate, string OPName, string SearchType);

        public abstract DataSet OrderDelStat(DateTime StartDate, DateTime EndDate, string OPName);

        public abstract DataSet UpdateUserComment(string Comment, string UID);

        public abstract DataSet UpdateFeedBackComment(string Comment, string UserID, int CustomerID);

        public abstract DataSet AddBankBlack(int BankID, string BankUser, string BankAcc, int CustomerID, string Comment);

        public abstract DataSet RightLockLastOPID(string UID);

        public abstract DataSet FTRightLock(string ID);

        public abstract DataSet SearchAccPwd(string SerialNo, int OPID);

        public abstract DataSet IsGoodPost(string userID);

        public abstract DataSet IsGoodAccept(string userID);

        public abstract int AddLevelOrderProgress(string UserID, string SerialNo, string Msg, string Img);

        public abstract int DeleteLevelOrderProgress(int ID);

        public abstract DataSet UpdateOrderEvaluate(string OrderEvaluate, string Comment, string Type, string Direct);

        public abstract DataSet UpdateRoleComment(string Comment, string Actor, string Code);

        #region "强制完单"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public abstract DataSet OrderForceOver(string SerialNo, float Payout, float Income);
        #endregion

        public abstract DataSet LockCancelStatus(string SerialNo);

        public abstract DataSet GetSysUserInfo(int OPID);

        public abstract DataSet GetServiceHelp(string SerialNo);

        public abstract DataSet LevelOrderMarkColorList(string SerialNo);


        #region "删除订单"
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="SerialNo"></param>
        /// <returns></returns>
        public abstract DataSet OrderDelete(string SerialNo, int OPID);

        #endregion


        public abstract DataSet OrderActivityDelete(string ID);

        public abstract DataSet OrderActivityReturn(string ID);

        public abstract DataSet AccountRela(string SerialNo);

        public abstract int OrderDeleteAddRemark(string SerialNo, string Remark);

        #region "新增留言"
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="SerialNo"></param>
        /// <returns></returns>
        public abstract DataSet InsertMessage(int UserID, int MsgType, string ODSerialNo, DateTime CreateDate, string Msg);

        #endregion

        #region "删除客服留言"
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="SerialNo"></param>
        /// <returns></returns>
        public abstract DataSet DeleteMessageService(int MessageID);

        #endregion

        #region "角色名出现频率 上家发单撤单比例"
        /// <summary>
        /// 角色名出现频率 上家发单撤单比例
        /// </summary>
        /// <param name="AType"></param>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public abstract DataSet OrderFreq(int Type, DateTime StartDate, DateTime EndDate);

        #endregion


        public abstract DataSet GetTopPostUser(string Game);

        public abstract DataSet GetUserPostByWeek(int ID);

        public abstract DataSet GetUserLoginMACList(int ID);

        public abstract DataSet GetUserLoginHDList(int ID);

        public abstract DataSet GetUserCountByMAC(string MAC);

        public abstract DataSet BM_GetUserListByMAC(string MAC);

        public abstract DataSet BM_GetMACUserListByID(string ID);

        #region "发单介入比例"
        /// <summary>
        /// 角色名出现频率 上家发单撤单比例
        /// </summary>
        /// <param name="AType"></param>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public abstract DataSet JRFreq(int Type, DateTime StartDate, DateTime EndDate);

        #endregion



        #region "更多数据统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public abstract DataSet AllstatisticsMore(string GameID, DateTime StartDate, DateTime EndDate);
        #endregion


        #region "用户数据统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public abstract DataSet UserStat(DateTime StartDate, DateTime EndDate);
        #endregion


        #region "在线用户统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public abstract DataSet UserOnline();
        #endregion

        #region "总资金数据统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public abstract DataSet FinanceStat(DateTime StartDate, DateTime EndDate);
        #endregion

        public abstract DataSet FinanceTotal();

        #region "财务充值提现数据统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public abstract DataSet FinanceStatWDRC(DateTime StartDate, DateTime EndDate);
        #endregion

        #region "汇款确认数据统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public abstract DataSet FinanceStatConfirmWithdraw(DateTime StartDate, DateTime EndDate);
        #endregion

        #region "汇款取消数据统计"
        /// <summary>
        /// 更多数据统计
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public abstract DataSet FinanceStatCancelWithdraw(DateTime StartDate, DateTime EndDate);
        #endregion

        #region "撤销单赔付查询"
        /// <summary>
        /// 撤销单赔付查询
        /// </summary>
        /// <param name="SerialNo"></param>
        /// <returns></returns>
        public abstract DataSet OrderCancel(string SerialNo);



        #endregion

        public abstract DataSet ArbitrationList(string SerialNo);

        public abstract DataSet LevelOrderList(string SerialNo);

        public abstract DataSet UpdateIP(string IP);


        public abstract DataSet OrderGroup(DateTime sDate, DateTime eDate, string FirstCustomerID, string SearchType, int PageIndex, int PageSize);


        public abstract DataSet NewAcceptJRCount(int Max, DateTime StartDate, DateTime EndDate, int PageIndex, int PageSize);

        public abstract DataSet YXAcceptOrder(string UserID, DateTime StartDate, DateTime EndDate);

        public abstract DataSet NewAcceptUser(DateTime StatDate);

        public abstract DataSet NewAcceptUserStat(DateTime StatDate);

        public abstract DataSet ActivitytUser(DateTime StatDate);

        public abstract DataSet HalfActivitytUser(DateTime StatDate);

        public abstract DataSet HalfActivitytUserStat(DateTime StatDate);

        public abstract DataSet LoseUser(DateTime StatDate);

        public abstract DataSet LoseUserStat(DateTime StatDate);

        public abstract DataSet PercentActivitytUser(DateTime StatDate);

        public abstract DataSet SRPriceAcceptOrder(string UserID, DateTime StartDate, DateTime EndDate);

        public abstract DataSet UserGLCount(string GameID, string Min, string Max, DateTime StartDate, DateTime EndDate, int PageIndex, int PageSize, string OrderType);

        public abstract DataSet GetDateList(DateTime StartDate, DateTime EndDate);

        #region "单个订单查询[原始单]"
        /// <summary>
        /// 单个订单查询[原始单]
        /// </summary>
        /// <param name="SerialNo"></param>
        /// <returns></returns>
        public abstract DataSet GetOrder(string SerialNo, int IsHisOrder);

        #endregion

        public abstract DataSet GetOrderHis(string SerialNo, int IsHisOrder);

        #region "单个删除订单查询[原始单]"
        /// <summary>
        /// 单个订单查询[原始单]
        /// </summary>
        /// <param name="SerialNo"></param>
        /// <returns></returns>
        public abstract DataSet GetOrderDel(string SerialNo, string DelType);

        #endregion

        public abstract DataSet AddAppointArbitration(string CustomerID, string UserID, int OpID);


        #region "查询发单人是否被禁止发单"
        /// <summary>
        /// </summary>
        /// <param name="SerialNo"></param>
        /// <returns></returns>
        public abstract DataSet PubHaveRightLock(string id);

        #endregion


        #region "ManualRechage(后台手动充值) - Method"
        /// <summary>
        /// 后台手动充值
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Bal"></param>
        /// <param name="SerialNo"></param>
        /// <param name="OPID"></param>
        /// <returns></returns>
        public abstract DataSet ManualRechage(string UserID, float Bal, string SerialNo, string OPID, string Comment);

        #endregion

        public abstract DataSet UserMoneyChangeList(int UserID, DateTime StartDate, DateTime EndDate, int Type, string RelaSerialNo, int PageIndex, int PageSize, string Search);

        public abstract DataSet UserMoneyFreezeList(int UserID, DateTime StartDate, DateTime EndDate, int Type, string RelaSerialNo, int PageIndex, int PageSize, string Search);

        #region "sys_Comment(sys_Comment) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 sys_CommentEntity (sys_Comment)
        /// </summary>
        /// <param name="fam">sys_Comment实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 sys_CommentInsertUpdateDelete(sys_CommentEntity fam);

        /// <summary>
        /// 新增/删除/修改 sys_CommentEntity (sys_Comment)
        /// </summary>
        /// <param name="fam">sys_Comment实体类</param>
        /// <param name="tran">sys_Comment事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 sys_CommentInsertUpdateDelete(sys_CommentEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回sys_CommentEntity实体类的List对象 (sys_Comment)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_CommentEntity实体类的List对象(sys_Comment)</returns>
        public abstract List<sys_CommentEntity> sys_CommentList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回sys_CommentEntity实体类的List对象 (sys_Comment)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">sys_Comment事务</param>
        /// <returns>sys_CommentEntity实体类的List对象(sys_Comment)</returns>
        public abstract List<sys_CommentEntity> sys_CommentList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为sys_CommentEntity实体类 (sys_Comment)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>sys_CommentEntity</returns>
        protected sys_CommentEntity Populatesys_CommentEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            sys_CommentEntity nc = new sys_CommentEntity();

            if (Fileds.ContainsKey("C_CommentID") && !Convert.IsDBNull(dr["C_CommentID"])) nc.C_CommentID = Convert.ToInt32(dr["C_CommentID"]); // C_CommentID
            if (Fileds.ContainsKey("C_NewsID") && !Convert.IsDBNull(dr["C_NewsID"])) nc.C_NewsID = Convert.ToInt32(dr["C_NewsID"]); // C_NewsID
            if (Fileds.ContainsKey("C_PostID") && !Convert.IsDBNull(dr["C_PostID"])) nc.C_PostID = Convert.ToInt32(dr["C_PostID"]); // C_PostID
            if (Fileds.ContainsKey("C_Content") && !Convert.IsDBNull(dr["C_Content"])) nc.C_Content = Convert.ToString(dr["C_Content"]).Trim(); // C_Content
            if (Fileds.ContainsKey("C_Remarks") && !Convert.IsDBNull(dr["C_Remarks"])) nc.C_Remarks = Convert.ToString(dr["C_Remarks"]).Trim(); // C_Remarks
            if (Fileds.ContainsKey("C_CreateDate") && !Convert.IsDBNull(dr["C_CreateDate"])) nc.C_CreateDate = Convert.ToDateTime(dr["C_CreateDate"]); // C_CreateDate
            return nc;
        }
        #endregion

        #region "sys_News(sys_News) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 sys_NewsEntity (sys_News)
        /// </summary>
        /// <param name="fam">sys_News实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 sys_NewsInsertUpdateDelete(sys_NewsEntity fam);

        /// <summary>
        /// 新增/删除/修改 sys_NewsEntity (sys_News)
        /// </summary>
        /// <param name="fam">sys_News实体类</param>
        /// <param name="tran">sys_News事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 sys_NewsInsertUpdateDelete(sys_NewsEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回sys_NewsEntity实体类的List对象 (sys_News)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_NewsEntity实体类的List对象(sys_News)</returns>
        public abstract List<sys_NewsEntity> sys_NewsList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回sys_NewsEntity实体类的List对象 (sys_News)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">sys_News事务</param>
        /// <returns>sys_NewsEntity实体类的List对象(sys_News)</returns>
        public abstract List<sys_NewsEntity> sys_NewsList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为sys_NewsEntity实体类 (sys_News)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>sys_NewsEntity</returns>
        protected sys_NewsEntity Populatesys_NewsEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            sys_NewsEntity nc = new sys_NewsEntity();

            if (Fileds.ContainsKey("N_ID") && !Convert.IsDBNull(dr["N_ID"])) nc.N_ID = Convert.ToInt32(dr["N_ID"]); // N_ID
            if (Fileds.ContainsKey("N_TypeID") && !Convert.IsDBNull(dr["N_TypeID"])) nc.N_TypeID = Convert.ToInt32(dr["N_TypeID"]); // N_TypeID
            if (Fileds.ContainsKey("N_Title") && !Convert.IsDBNull(dr["N_Title"])) nc.N_Title = Convert.ToString(dr["N_Title"]).Trim(); // N_Title
            if (Fileds.ContainsKey("N_Author") && !Convert.IsDBNull(dr["N_Author"])) nc.N_Author = Convert.ToString(dr["N_Author"]).Trim(); // N_Author
            if (Fileds.ContainsKey("N_CreateDate") && !Convert.IsDBNull(dr["N_CreateDate"])) nc.N_CreateDate = Convert.ToDateTime(dr["N_CreateDate"]); // N_CreateDate
            if (Fileds.ContainsKey("N_Click") && !Convert.IsDBNull(dr["N_Click"])) nc.N_Click = Convert.ToInt32(dr["N_Click"]); // N_Click
            if (Fileds.ContainsKey("N_Content") && !Convert.IsDBNull(dr["N_Content"])) nc.N_Content = Convert.ToString(dr["N_Content"]).Trim(); // N_Content
            if (Fileds.ContainsKey("N_Remarks") && !Convert.IsDBNull(dr["N_Remarks"])) nc.N_Remarks = Convert.ToString(dr["N_Remarks"]).Trim(); // N_Remarks
            return nc;
        }
        #endregion


        #region "sys_PendingComment(sys_PendingComment) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 sys_PendingCommentEntity (sys_PendingComment)
        /// </summary>
        /// <param name="fam">sys_PendingComment实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 sys_PendingCommentInsertUpdateDelete(sys_PendingCommentEntity fam);

        /// <summary>
        /// 新增/删除/修改 sys_PendingCommentEntity (sys_PendingComment)
        /// </summary>
        /// <param name="fam">sys_PendingComment实体类</param>
        /// <param name="tran">sys_PendingComment事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 sys_PendingCommentInsertUpdateDelete(sys_PendingCommentEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回sys_PendingCommentEntity实体类的List对象 (sys_PendingComment)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_PendingCommentEntity实体类的List对象(sys_PendingComment)</returns>
        public abstract List<sys_PendingCommentEntity> sys_PendingCommentList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回sys_PendingCommentEntity实体类的List对象 (sys_PendingComment)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">sys_PendingComment事务</param>
        /// <returns>sys_PendingCommentEntity实体类的List对象(sys_PendingComment)</returns>
        public abstract List<sys_PendingCommentEntity> sys_PendingCommentList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为sys_PendingCommentEntity实体类 (sys_PendingComment)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>sys_PendingCommentEntity</returns>
        protected sys_PendingCommentEntity Populatesys_PendingCommentEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            sys_PendingCommentEntity nc = new sys_PendingCommentEntity();

            if (Fileds.ContainsKey("P_CommentID") && !Convert.IsDBNull(dr["P_CommentID"])) nc.P_CommentID = Convert.ToInt32(dr["P_CommentID"]); // P_CommentID
            if (Fileds.ContainsKey("P_PendingID") && !Convert.IsDBNull(dr["P_PendingID"])) nc.P_PendingID = Convert.ToInt32(dr["P_PendingID"]); // P_PendingID
            if (Fileds.ContainsKey("P_CommentPostID") && !Convert.IsDBNull(dr["P_CommentPostID"])) nc.P_CommentPostID = Convert.ToInt32(dr["P_CommentPostID"]); // P_CommentPostID
            if (Fileds.ContainsKey("P_CommentStauts") && !Convert.IsDBNull(dr["P_CommentStauts"])) nc.P_CommentStauts = Convert.ToInt32(dr["P_CommentStauts"]); // P_CommentStauts
            if (Fileds.ContainsKey("P_CommentContent") && !Convert.IsDBNull(dr["P_CommentContent"])) nc.P_CommentContent = Convert.ToString(dr["P_CommentContent"]).Trim(); // P_CommentContent
            if (Fileds.ContainsKey("P_CommentRemarks") && !Convert.IsDBNull(dr["P_CommentRemarks"])) nc.P_CommentRemarks = Convert.ToString(dr["P_CommentRemarks"]).Trim(); // P_CommentRemarks
            if (Fileds.ContainsKey("P_Pre") && !Convert.IsDBNull(dr["P_Pre"])) nc.P_Pre = Convert.ToString(dr["P_Pre"]).Trim(); // P_Pre
            return nc;
        }
        #endregion

        #region "sys_PendingMatters(sys_PendingMatters) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 sys_PendingMattersEntity (sys_PendingMatters)
        /// </summary>
        /// <param name="fam">sys_PendingMatters实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 sys_PendingMattersInsertUpdateDelete(sys_PendingMattersEntity fam);

        /// <summary>
        /// 新增/删除/修改 sys_PendingMattersEntity (sys_PendingMatters)
        /// </summary>
        /// <param name="fam">sys_PendingMatters实体类</param>
        /// <param name="tran">sys_PendingMatters事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 sys_PendingMattersInsertUpdateDelete(sys_PendingMattersEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回sys_PendingMattersEntity实体类的List对象 (sys_PendingMatters)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_PendingMattersEntity实体类的List对象(sys_PendingMatters)</returns>
        public abstract List<sys_PendingMattersEntity> sys_PendingMattersList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回sys_PendingMattersEntity实体类的List对象 (sys_PendingMatters)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">sys_PendingMatters事务</param>
        /// <returns>sys_PendingMattersEntity实体类的List对象(sys_PendingMatters)</returns>
        public abstract List<sys_PendingMattersEntity> sys_PendingMattersList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为sys_PendingMattersEntity实体类 (sys_PendingMatters)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>sys_PendingMattersEntity</returns>
        protected sys_PendingMattersEntity Populatesys_PendingMattersEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            sys_PendingMattersEntity nc = new sys_PendingMattersEntity();

            if (Fileds.ContainsKey("P_ID") && !Convert.IsDBNull(dr["P_ID"])) nc.P_ID = Convert.ToInt32(dr["P_ID"]); // P_ID
            if (Fileds.ContainsKey("P_Type") && !Convert.IsDBNull(dr["P_Type"])) nc.P_Type = Convert.ToInt32(dr["P_Type"]); // P_Type
            if (Fileds.ContainsKey("P_UserID") && !Convert.IsDBNull(dr["P_UserID"])) nc.P_UserID = Convert.ToString(dr["P_UserID"]).Trim(); // P_UserID
            if (Fileds.ContainsKey("P_Contact") && !Convert.IsDBNull(dr["P_Contact"])) nc.P_Contact = Convert.ToString(dr["P_Contact"]).Trim(); // P_Contact
            if (Fileds.ContainsKey("P_OrderNum") && !Convert.IsDBNull(dr["P_OrderNum"])) nc.P_OrderNum = Convert.ToString(dr["P_OrderNum"]).Trim(); // P_OrderNum
            if (Fileds.ContainsKey("P_CreateDate") && !Convert.IsDBNull(dr["P_CreateDate"])) nc.P_CreateDate = Convert.ToDateTime(dr["P_CreateDate"]); // P_CreateDate
            if (Fileds.ContainsKey("P_ReplyDate") && !Convert.IsDBNull(dr["P_ReplyDate"])) nc.P_ReplyDate = Convert.ToDateTime(dr["P_ReplyDate"]); // P_ReplyDate
            if (Fileds.ContainsKey("P_Content") && !Convert.IsDBNull(dr["P_Content"])) nc.P_Content = Convert.ToString(dr["P_Content"]).Trim(); // P_Content
            if (Fileds.ContainsKey("P_PostID") && !Convert.IsDBNull(dr["P_PostID"])) nc.P_PostID = Convert.ToInt32(dr["P_PostID"]); // P_PostID
            if (Fileds.ContainsKey("P_ReplyID") && !Convert.IsDBNull(dr["P_ReplyID"])) nc.P_ReplyID = Convert.ToInt32(dr["P_ReplyID"]); // P_ReplyID
            if (Fileds.ContainsKey("P_ReContent") && !Convert.IsDBNull(dr["P_ReContent"])) nc.P_ReContent = Convert.ToString(dr["P_ReContent"]).Trim(); // P_ReContent
            if (Fileds.ContainsKey("P_IsDeal") && !Convert.IsDBNull(dr["P_IsDeal"])) nc.P_IsDeal = Convert.ToInt32(dr["P_IsDeal"]); // P_IsDeal
            if (Fileds.ContainsKey("P_Pre1") && !Convert.IsDBNull(dr["P_Pre1"])) nc.P_Pre1 = Convert.ToInt32(dr["P_Pre1"]); // P_Pre1
            if (Fileds.ContainsKey("P_Pre2") && !Convert.IsDBNull(dr["P_Pre2"])) nc.P_Pre2 = Convert.ToString(dr["P_Pre2"]).Trim(); // P_Pre2
            if (Fileds.ContainsKey("P_Pre3") && !Convert.IsDBNull(dr["P_Pre3"])) nc.P_Pre3 = Convert.ToDateTime(dr["P_Pre3"]); // P_Pre3
            if (Fileds.ContainsKey("P_Pre4") && !Convert.IsDBNull(dr["P_Pre4"])) nc.P_Pre4 = Convert.ToString(dr["P_Pre4"]).Trim(); // P_Pre4
            return nc;
        }
        #endregion

        #region "tbVirtualBank(tbVirtualBank) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbVirtualBankEntity (tbVirtualBank)
        /// </summary>
        /// <param name="fam">tbVirtualBank实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbVirtualBankInsertUpdateDelete(tbVirtualBankEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbVirtualBankEntity (tbVirtualBank)
        /// </summary>
        /// <param name="fam">tbVirtualBank实体类</param>
        /// <param name="tran">tbVirtualBank事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbVirtualBankInsertUpdateDelete(tbVirtualBankEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbVirtualBankEntity实体类的List对象 (tbVirtualBank)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbVirtualBankEntity实体类的List对象(tbVirtualBank)</returns>
        public abstract List<tbVirtualBankEntity> tbVirtualBankList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbVirtualBankEntity实体类的List对象 (tbVirtualBank)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbVirtualBank事务</param>
        /// <returns>tbVirtualBankEntity实体类的List对象(tbVirtualBank)</returns>
        public abstract List<tbVirtualBankEntity> tbVirtualBankList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbVirtualBankEntity实体类 (tbVirtualBank)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbVirtualBankEntity</returns>
        protected tbVirtualBankEntity PopulatetbVirtualBankEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbVirtualBankEntity nc = new tbVirtualBankEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("BankName") && !Convert.IsDBNull(dr["BankName"])) nc.BankName = Convert.ToString(dr["BankName"]).Trim(); // BankName
            if (Fileds.ContainsKey("MONEY") && !Convert.IsDBNull(dr["MONEY"])) nc.MONEY = Convert.ToDouble(dr["MONEY"]); // MONEY
            return nc;
        }
        #endregion

        #region "sys_LoginAuthorize(sys_LoginAuthorize) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 sys_LoginAuthorizeEntity (sys_LoginAuthorize)
        /// </summary>
        /// <param name="fam">sys_LoginAuthorize实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 sys_LoginAuthorizeInsertUpdateDelete(sys_LoginAuthorizeEntity fam);

        /// <summary>
        /// 新增/删除/修改 sys_LoginAuthorizeEntity (sys_LoginAuthorize)
        /// </summary>
        /// <param name="fam">sys_LoginAuthorize实体类</param>
        /// <param name="tran">sys_LoginAuthorize事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 sys_LoginAuthorizeInsertUpdateDelete(sys_LoginAuthorizeEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回sys_LoginAuthorizeEntity实体类的List对象 (sys_LoginAuthorize)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_LoginAuthorizeEntity实体类的List对象(sys_LoginAuthorize)</returns>
        public abstract List<sys_LoginAuthorizeEntity> sys_LoginAuthorizeList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回sys_LoginAuthorizeEntity实体类的List对象 (sys_LoginAuthorize)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">sys_LoginAuthorize事务</param>
        /// <returns>sys_LoginAuthorizeEntity实体类的List对象(sys_LoginAuthorize)</returns>
        public abstract List<sys_LoginAuthorizeEntity> sys_LoginAuthorizeList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为sys_LoginAuthorizeEntity实体类 (sys_LoginAuthorize)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>sys_LoginAuthorizeEntity</returns>
        protected sys_LoginAuthorizeEntity Populatesys_LoginAuthorizeEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            sys_LoginAuthorizeEntity nc = new sys_LoginAuthorizeEntity();

            if (Fileds.ContainsKey("L_ID") && !Convert.IsDBNull(dr["L_ID"])) nc.L_ID = Convert.ToInt32(dr["L_ID"]); // L_ID
            if (Fileds.ContainsKey("L_Status") && !Convert.IsDBNull(dr["L_Status"])) nc.L_Status = Convert.ToInt32(dr["L_Status"]); // L_Status
            if (Fileds.ContainsKey("L_CreateDate") && !Convert.IsDBNull(dr["L_CreateDate"])) nc.L_CreateDate = Convert.ToDateTime(dr["L_CreateDate"]); // L_CreateDate
            if (Fileds.ContainsKey("L_StartDate") && !Convert.IsDBNull(dr["L_StartDate"])) nc.L_StartDate = Convert.ToDateTime(dr["L_StartDate"]); // L_StartDate
            if (Fileds.ContainsKey("L_EndDate") && !Convert.IsDBNull(dr["L_EndDate"])) nc.L_EndDate = Convert.ToDateTime(dr["L_EndDate"]); // L_EndDate
            if (Fileds.ContainsKey("L_Remark") && !Convert.IsDBNull(dr["L_Remark"])) nc.L_Remark = Convert.ToString(dr["L_Remark"]).Trim(); // L_Remark
            if (Fileds.ContainsKey("L_IP") && !Convert.IsDBNull(dr["L_IP"])) nc.L_IP = Convert.ToString(dr["L_IP"]).Trim(); // L_IP
            if (Fileds.ContainsKey("L_MAC") && !Convert.IsDBNull(dr["L_MAC"])) nc.L_MAC = Convert.ToString(dr["L_MAC"]).Trim(); // L_MAC
            if (Fileds.ContainsKey("L_BC1") && !Convert.IsDBNull(dr["L_BC1"])) nc.L_BC1 = Convert.ToInt32(dr["L_BC1"]); // L_BC1
            if (Fileds.ContainsKey("L_BC2") && !Convert.IsDBNull(dr["L_BC2"])) nc.L_BC2 = Convert.ToDateTime(dr["L_BC2"]); // L_BC2
            if (Fileds.ContainsKey("L_BC3") && !Convert.IsDBNull(dr["L_BC3"])) nc.L_BC3 = Convert.ToString(dr["L_BC3"]).Trim(); // L_BC3
            return nc;
        }
        #endregion

        #region "tbChatMessage(tbChatMessage) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tbChatMessageEntity (tbChatMessage)
        /// </summary>
        /// <param name="fam">tbChatMessage实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbChatMessageInsertUpdateDelete(tbChatMessageEntity fam);

        /// <summary>
        /// 新增/删除/修改 tbChatMessageEntity (tbChatMessage)
        /// </summary>
        /// <param name="fam">tbChatMessage实体类</param>
        /// <param name="tran">tbChatMessage事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbChatMessageInsertUpdateDelete(tbChatMessageEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tbChatMessageEntity实体类的List对象 (tbChatMessage)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbChatMessageEntity实体类的List对象(tbChatMessage)</returns>
        public abstract List<tbChatMessageEntity> tbChatMessageList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tbChatMessageEntity实体类的List对象 (tbChatMessage)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tbChatMessage事务</param>
        /// <returns>tbChatMessageEntity实体类的List对象(tbChatMessage)</returns>
        public abstract List<tbChatMessageEntity> tbChatMessageList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tbChatMessageEntity实体类 (tbChatMessage)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tbChatMessageEntity</returns>
        protected tbChatMessageEntity PopulatetbChatMessageEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbChatMessageEntity nc = new tbChatMessageEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]); // UserID
            if (Fileds.ContainsKey("UID") && !Convert.IsDBNull(dr["UID"])) nc.UID = Convert.ToString(dr["UID"]).Trim(); // UID
            if (Fileds.ContainsKey("NickName") && !Convert.IsDBNull(dr["NickName"])) nc.NickName = Convert.ToString(dr["NickName"]).Trim(); // NickName
            if (Fileds.ContainsKey("IconIndex") && !Convert.IsDBNull(dr["IconIndex"])) nc.IconIndex = Convert.ToInt32(dr["IconIndex"]); // IconIndex
            if (Fileds.ContainsKey("ChatType") && !Convert.IsDBNull(dr["ChatType"])) nc.ChatType = Convert.ToInt32(dr["ChatType"]); // ChatType
            if (Fileds.ContainsKey("TargetID") && !Convert.IsDBNull(dr["TargetID"])) nc.TargetID = Convert.ToString(dr["TargetID"]).Trim(); // TargetID
            if (Fileds.ContainsKey("Comment") && !Convert.IsDBNull(dr["Comment"])) nc.Comment = Convert.ToString(dr["Comment"]).Trim(); // Comment
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]); // CreateDate
            if (Fileds.ContainsKey("BeginTime") && !Convert.IsDBNull(dr["BeginTime"])) nc.BeginTime = Convert.ToDateTime(dr["BeginTime"]); // BeginTime
            return nc;
        }
        #endregion

        #region 优质频道
        public abstract DataSet GoodPublishList(string UID, DateTime sDate, DateTime eDate, int Status, string Sort_Str, int PageIndex, int PageSize);
        public abstract int GoodPublishPast(int ID, int Flag);
        public abstract DataTable GoodPublishAdd(string UID, int Del);
        public abstract DataSet GoodAcceptList(string UID, DateTime sDate, DateTime eDate, int Status, string Sort_Str, int ApplyTier, int PageIndex, int PageSize);
        public abstract int GoodAcceptPast(int ID, int Flag, string Describle);
        #endregion


        #region "获取表中字段值"
        /// <summary>
        /// 获取表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="table_fileds">字段</param>
        /// <param name="where_fileds">查询条件字段</param>
        /// <param name="where_value">查询值</param>
        /// <returns></returns>
        public abstract string get_table_fileds(string table_name, string table_fileds, string where_fileds, string where_value);

        /// <summary>
        /// 获取表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="table_fileds">字段</param>
        /// <param name="where_fileds">查询条件字段</param>
        /// <param name="where_value">查询值</param>
        /// <param name="tran">事务</param>        
        /// <returns></returns>
        public abstract string get_table_fileds(string table_name, string table_fileds, string where_fileds, string where_value, DbTransaction tran);
        #endregion

        #region "列新表中字段值"
        /// <summary>
        /// 更新表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="Table">表名</param>
        /// <param name="Table_FiledsValue">需要更新值(不用带Set)</param>
        /// <param name="Wheres">更新条件(不用带Where)</param>
        /// <returns></returns>
        public abstract int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres);

        /// <summary>
        /// 更新表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="Table">表名</param>
        /// <param name="Table_FiledsValue">需要更新值(不用带Set)</param>
        /// <param name="Wheres">更新条件(不用带Where)</param>
        /// <param name="tran">事务</param>  
        /// <returns></returns>
        public abstract int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres, DbTransaction tran);
        #endregion


        /// <summary>
        /// 登录页面登录操作
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public abstract DataSet Login(string UserName, string Password);

        /// <summary>
        /// 根据手机号码查询登录ID
        /// </summary>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        public abstract string GetLoginIDByMobile(string Mobile);

        public abstract DataTable GetActivityByModuleID(int moduleId);

        public abstract DataTable GetActivityById(string id);

        public abstract DataTable GetActivityById(string id, string moduleId);

        public abstract DataSet CheckBaoMing(string id, string roleName, int userID, int status, string moduleID);

        public abstract DataSet GetZhanKengOrders(int activityId, int bet, int userId);

        public abstract DataSet GetZhanKengOrders(string seriaNo, int userId);

        public abstract bool CheckZhanKengBit(string seriaNo, string pits);

        public abstract DataTable GetZhanKengBySeriaNo(string seriaNo);

        public abstract DataTable GetZhanKengByOrderSeriaNo(string seriaNo);

        public abstract DataTable GetZhanKengByOrderSeriaNo(string seriaNo, bool isShowAll);

        public abstract int GetZhanKengNumBySeriaNo(string seriaNo);

        public abstract DataSet GetZoneServer(string gameId);

        public abstract DataTable GetUserZoneServer(int userId, string gameId);

        public abstract double GetUserSumBal(int userId);

        public abstract DataTable GetUserSumBal1(int userId);

        public abstract DataTable GetUserByUid(string uid);

        public abstract DataTable GetNickNameByUid(string uid);

        public abstract int UpdateUserSumBal(int userId, double sumBal, int operate);

        public abstract int UpdateUserSumBal(int userId, double sumBal, int operate, DbTransaction tran);

        public abstract string act_Orders(tbOrdersEntity tbOrders);

        public abstract string act_Orders(tbOrdersEntity tbOrders, DbTransaction tran);

        public abstract void OperateTbMoneyChange(tbMoneyChangeEntity tbMoneyChange, DbTransaction tran);

        public abstract void OperateUserZoneServer(tsUserZoneServerEntity tsUserZoneServer, DbTransaction tran);

        public abstract DataTable GetOrdersById(int id, int userId);

        public abstract DataTable GetOrdersBySeriaNo(string seriaNo);

        public abstract DataTable GetOrdersBySeriaNo(string seriaNo, int userId);

        public abstract DataTable GetOrdersByStatus();

        public abstract DataSet act_UserInsertUpdateDelete(tsUserEntity tsUser);

        public abstract int baoming_zhifu(tbOrdersEntity tbOrders, tbMoneyChangeEntity tbMoneyChange, tsUserZoneServerEntity tsUserZoneServer, tlOperateEntity fam);

        public abstract int baomingzk_zhifu(string SeriaNo, string Pit, tbOrdersEntity tbOrders, tbMoneyChangeEntity tbMoneyChange, tsUserZoneServerEntity tsUserZoneServer, tlOperateEntity fam);

        public abstract int Recharge(tbMoneyChangeEntity tbMoneyChange, tbRechargeEntity tbRecharge, tlOperateEntity fam);

        public abstract void InsertErrorLog(string type, string content);


        public abstract DataTable GetRecordList(QueryParam pp, out int RecordCount, out int PageCount);

        public abstract DataTable GetUserById(int id);

        public abstract DataSet OrderList(QueryParam qp);

        public abstract DataSet UserReport(QueryParam qp, string where1);

        public abstract void MacthResult(string SeriaNo, int userId, double RegAmount, double ResAmount, int status, string battleTime, DateTime curTime, tbMoneyChangeEntity tbMoneyChange, tlOperateEntity fam);

        public abstract void MacthResult(string SeriaNo, int userId, double RegAmount, double ResAmount, int status, DateTime curTime, string feedback, tbMoneyChangeEntity tbMoneyChange, tlOperateEntity fam);

        public abstract void LuanDouSuccessMatch(string SeriaNo, string battleTime, DateTime curTime, tlOperateEntity fam);

        public abstract void ZhanKengSuccessMatch(int status, string SeriaNo, string battleTime, DateTime curTime, tlOperateEntity fam);

        public abstract int UpdateOrdersStatus(string comment, int status, string seriaNo);

        public abstract int UpdateExchangeStatus(string comment, int status, string seriaNo);

        public abstract int UserSendQuestion(string comment, int status, string seriaNo, tlOperateEntity fam);

        public abstract DataTable GetTopOrders(int top);

        public abstract DataTable GetTopOrdersByBaoMing(int top);

        public abstract int givelecoin(double money, int userId, int id, tbGiveEntity tbGive, tbMoneyChangeEntity tbMoneyChange, tbMoneyChangeEntity tbMoneyChange1, tlOperateEntity fam);

        public abstract int UpdateFigureurl(int userId, string figureurl);

        public abstract int UpdateNickName(int userId, string nickName);

        public abstract int UpdateQQ(int userId, string QQ);

        public abstract List<tsRightLockAutoEntity> tsRightLockAutoList(QueryParam qp, out int RecordCount);

        public abstract int MobileTokenInsertUpdateDelete(tbMobileTokenEntity fam);

        public abstract DataTable GetUserByOpenId(string openId);

        public abstract DataTable CheckMobileToken(string mobile);

        public abstract int CheckUserByMobile(string mobile);

        public abstract int Gegister(tsUserEntity tsUser, tlOperateEntity tlOperate, tlLoginEntity tlLogin, string tbMobileSerialNo, out int userId);

        protected tsRightLockAutoEntity Populatesys_tsRightLockAutoEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tsRightLockAutoEntity nc = new tsRightLockAutoEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // L_ID
            if (Fileds.ContainsKey("ActivityID") && !Convert.IsDBNull(dr["ActivityID"])) nc.ID = Convert.ToInt32(dr["ActivityID"]);
            if (Fileds.ContainsKey("Name") && !Convert.IsDBNull(dr["Name"])) nc.Name = Convert.ToString(dr["Name"]).Trim();
            if (Fileds.ContainsKey("StartDate") && !Convert.IsDBNull(dr["StartDate"])) nc.StartDate = Convert.ToDateTime(dr["StartDate"]);
            if (Fileds.ContainsKey("EndDate") && !Convert.IsDBNull(dr["EndDate"])) nc.EndDate = Convert.ToDateTime(dr["EndDate"]);
            if (Fileds.ContainsKey("Nums") && !Convert.IsDBNull(dr["Nums"])) nc.Nums = Convert.ToString(dr["Nums"]).Trim();
            if (Fileds.ContainsKey("Moneys") && !Convert.IsDBNull(dr["Moneys"])) nc.Moneys = Convert.ToString(dr["Moneys"]).Trim();
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
            return nc;
        }

        public abstract DataSet luandou(string timeArea, string activityID);

        public abstract DataSet luckyzk();

        #endregion

        public abstract DataSet SendLevelOrder(int UserID, int PageIndex, int PageSize, string Where);

        public abstract DataSet ReceiveLevelOrder(int UserID, int PageIndex, int PageSize, string Where);

        public abstract List<tbDifficultyEntity> tbDifficultyList(QueryParam qp, out int RecordCount);

        public abstract List<tbDifficultyEntity> tbDifficultyList(QueryParam qp, out int RecordCount, DbTransaction tran);

        protected tbDifficultyEntity PopulatetbDifficultyEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbDifficultyEntity nc = new tbDifficultyEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("DifficultyName") && !Convert.IsDBNull(dr["DifficultyName"])) nc.DifficultyName = Convert.ToString(dr["DifficultyName"]).Trim();
            if (Fileds.ContainsKey("Sort") && !Convert.IsDBNull(dr["Sort"])) nc.Sort = Convert.ToInt32(dr["Sort"]);
            return nc;
        }

        #region "tbQuestionsEntity(题库) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 tsMemberEntity (用户成员)
        /// </summary>
        /// <param name="fam">tsMember实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbQuestionsInsertUpdateDelete(tbQuestionsEntity fam);

        /// <summary>
        /// 新增/删除/修改 tsMemberEntity (用户成员)
        /// </summary>
        /// <param name="fam">tsMember实体类</param>
        /// <param name="tran">tsMember事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 tbQuestionsInsertUpdateDelete(tbQuestionsEntity fam, DbTransaction tran);

        /// <summary>
        /// 返回tsMemberEntity实体类的List对象 (用户成员)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsMemberEntity实体类的List对象(用户成员)</returns>
        public abstract List<tbQuestionsEntity> tbQuestionsList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 返回tsMemberEntity实体类的List对象 (用户成员)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsMember事务</param>
        /// <returns>tsMemberEntity实体类的List对象(用户成员)</returns>
        public abstract List<tbQuestionsEntity> tbQuestionsList(QueryParam qp, out int RecordCount, DbTransaction tran);

        /// <summary>
        /// 将记录集转为tsMemberEntity实体类 (用户成员)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>tsMemberEntity</returns>
        protected tbQuestionsEntity PopulatetsQuestionsEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbQuestionsEntity nc = new tbQuestionsEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("Difficulty") && !Convert.IsDBNull(dr["Difficulty"])) nc.Difficulty = Convert.ToInt32(dr["Difficulty"]);
            if (Fileds.ContainsKey("Title") && !Convert.IsDBNull(dr["Title"])) nc.Title = Convert.ToString(dr["Title"]).Trim();
            if (Fileds.ContainsKey("A") && !Convert.IsDBNull(dr["A"])) nc.A = Convert.ToString(dr["A"]).Trim();
            if (Fileds.ContainsKey("B") && !Convert.IsDBNull(dr["B"])) nc.B = Convert.ToString(dr["B"]).Trim();
            if (Fileds.ContainsKey("C") && !Convert.IsDBNull(dr["C"])) nc.C = Convert.ToString(dr["C"]).Trim();
            if (Fileds.ContainsKey("D") && !Convert.IsDBNull(dr["D"])) nc.D = Convert.ToString(dr["D"]).Trim();
            if (Fileds.ContainsKey("SubjectType") && !Convert.IsDBNull(dr["SubjectType"])) nc.SubjectType = Convert.ToInt32(dr["SubjectType"]);
            if (Fileds.ContainsKey("Answer") && !Convert.IsDBNull(dr["Answer"])) nc.Answer = Convert.ToString(dr["Answer"]).Trim();
            return nc;
        }
        #endregion


        public abstract List<tbSubjectEntity> tbSubjectList(QueryParam qp, out int RecordCount);

        public abstract List<tbSubjectEntity> tbSubjectList(QueryParam qp, out int RecordCount, DbTransaction tran);

        protected tbSubjectEntity PopulatetbSubjectEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbSubjectEntity nc = new tbSubjectEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("Name") && !Convert.IsDBNull(dr["Name"])) nc.Name = Convert.ToString(dr["Name"]).Trim();
            if (Fileds.ContainsKey("OrderBy") && !Convert.IsDBNull(dr["OrderBy"])) nc.OrderBy = Convert.ToInt32(dr["OrderBy"]);

            return nc;
        }

        public abstract Int32 tbSubjectInsertUpdateDelete(tbSubjectEntity fam);

        public abstract Int32 tbSubjectInsertUpdateDelete(tbSubjectEntity fam, DbTransaction tran);

        public abstract List<tbAlbumEntity> tbAlbumList(QueryParam qp, out int RecordCount);

        public abstract List<tbAlbumEntity> tbAlbumList(QueryParam qp, out int RecordCount, DbTransaction tran);

        protected tbAlbumEntity PopulatetbAlbumEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbAlbumEntity nc = new tbAlbumEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("AlbumName") && !Convert.IsDBNull(dr["AlbumName"])) nc.AlbumName = Convert.ToString(dr["AlbumName"]).Trim();
            if (Fileds.ContainsKey("AlbumUrl") && !Convert.IsDBNull(dr["AlbumUrl"])) nc.AlbumUrl = Convert.ToString(dr["AlbumUrl"]).Trim();
            if (Fileds.ContainsKey("AlbumType") && !Convert.IsDBNull(dr["AlbumType"])) nc.AlbumType = Convert.ToInt32(dr["AlbumType"]);
            if (Fileds.ContainsKey("Amounts") && !Convert.IsDBNull(dr["Amounts"])) nc.Amounts = Convert.ToDouble(dr["Amounts"]);
            if (Fileds.ContainsKey("IsHot") && !Convert.IsDBNull(dr["IsHot"])) nc.IsHot = Convert.ToInt32(dr["IsHot"]);
            if (Fileds.ContainsKey("IsNew") && !Convert.IsDBNull(dr["IsNew"])) nc.IsNew = Convert.ToInt32(dr["IsNew"]);
            if (Fileds.ContainsKey("OrderBy") && !Convert.IsDBNull(dr["OrderBy"])) nc.OrderBy = Convert.ToInt32(dr["OrderBy"]);
            if (Fileds.ContainsKey("Enable") && !Convert.IsDBNull(dr["Enable"])) nc.Enable = Convert.ToInt32(dr["Enable"]);

            return nc;
        }

        protected tbImgEntity PopulatetbImgEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbImgEntity nc = new tbImgEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); 
            if (Fileds.ContainsKey("ImageName") && !Convert.IsDBNull(dr["ImageName"])) nc.ImageName = Convert.ToString(dr["ImageName"]).Trim();
            if (Fileds.ContainsKey("BgImageUrl") && !Convert.IsDBNull(dr["BgImageUrl"])) nc.BgImageUrl = Convert.ToString(dr["BgImageUrl"]).Trim();
            if (Fileds.ContainsKey("ImageUrl") && !Convert.IsDBNull(dr["ImageUrl"])) nc.ImageUrl = Convert.ToString(dr["ImageUrl"]).Trim();
            if (Fileds.ContainsKey("AlbumID") && !Convert.IsDBNull(dr["AlbumID"])) nc.AlbumID = Convert.ToInt32(dr["AlbumID"]);
            if (Fileds.ContainsKey("ImageType") && !Convert.IsDBNull(dr["ImageType"])) nc.ImageType = Convert.ToInt32(dr["ImageType"]);
            if (Fileds.ContainsKey("IsHot") && !Convert.IsDBNull(dr["IsHot"])) nc.IsHot = Convert.ToInt32(dr["IsHot"]);
            if (Fileds.ContainsKey("Enable") && !Convert.IsDBNull(dr["Enable"])) nc.Enable = Convert.ToInt32(dr["Enable"]);
            if (Fileds.ContainsKey("Delay") && !Convert.IsDBNull(dr["Delay"])) nc.Delay = Convert.ToInt32(dr["Delay"]);

            return nc;
        }

        public abstract Int32 tbAlbumInsertUpdateDelete(tbAlbumEntity fam);

        public abstract List<tbImgEntity> tbImgList(QueryParam qp, out int RecordCount);

        public abstract Int32 tbImgInsertUpdateDelete(tbImgEntity fam);

        public abstract DataTable tbFieldsList(string where);

        public abstract Int32 tbFieldsInsertUpdateDelete(tbFieldsEntity fam);

        public abstract Int32 tbValuesInsertUpdateDelete(tbValuesEntity fam);

        public abstract List<tbFieldsEntity> tbFieldsList(QueryParam qp, out int RecordCount);

        protected tbFieldsEntity PopulatetbFieldsEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbFieldsEntity nc = new tbFieldsEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]);
            if (Fileds.ContainsKey("ImgID") && !Convert.IsDBNull(dr["ImgID"])) nc.ImgID = Convert.ToInt32(dr["ImgID"]);

            if (Fileds.ContainsKey("Title") && !Convert.IsDBNull(dr["Title"])) nc.Title = Convert.ToString(dr["Title"]).Trim();
            if (Fileds.ContainsKey("PreValue") && !Convert.IsDBNull(dr["PreValue"])) nc.PreValue = Convert.ToString(dr["PreValue"]).Trim();
            if (Fileds.ContainsKey("Placeholder") && !Convert.IsDBNull(dr["Placeholder"])) nc.Placeholder = Convert.ToString(dr["Placeholder"]).Trim();
            if (Fileds.ContainsKey("Default") && !Convert.IsDBNull(dr["Default"])) nc.Default = Convert.ToString(dr["Default"]).Trim();
            if (Fileds.ContainsKey("SuffixValue") && !Convert.IsDBNull(dr["SuffixValue"])) nc.SuffixValue = Convert.ToString(dr["SuffixValue"]).Trim();
            if (Fileds.ContainsKey("Type") && !Convert.IsDBNull(dr["Type"])) nc.Type = Convert.ToString(dr["Type"]).Trim();
            if (Fileds.ContainsKey("Data") && !Convert.IsDBNull(dr["Data"])) nc.Data = Convert.ToString(dr["Data"]).Trim();
            if (Fileds.ContainsKey("FontSize") && !Convert.IsDBNull(dr["FontSize"])) nc.FontSize = Convert.ToInt32(dr["FontSize"]);
            if (Fileds.ContainsKey("FontFamily") && !Convert.IsDBNull(dr["FontFamily"])) nc.FontFamily = Convert.ToString(dr["FontFamily"]).Trim();
            if (Fileds.ContainsKey("FontColor") && !Convert.IsDBNull(dr["FontColor"])) nc.FontColor = Convert.ToString(dr["FontColor"]).Trim();
            if (Fileds.ContainsKey("FontStyle") && !Convert.IsDBNull(dr["FontStyle"])) nc.FontStyle = Convert.ToString(dr["FontStyle"]).Trim();
            if (Fileds.ContainsKey("X") && !Convert.IsDBNull(dr["X"])) nc.X = Convert.ToInt32(dr["X"]);
            if (Fileds.ContainsKey("Y") && !Convert.IsDBNull(dr["Y"])) nc.Y = Convert.ToInt32(dr["Y"]);
            if (Fileds.ContainsKey("IsCircle") && !Convert.IsDBNull(dr["IsCircle"])) nc.IsCircle = Convert.ToInt32(dr["IsCircle"]);
            if (Fileds.ContainsKey("Width") && !Convert.IsDBNull(dr["Width"])) nc.Width = Convert.ToInt32(dr["Width"]);
            if (Fileds.ContainsKey("Height") && !Convert.IsDBNull(dr["Height"])) nc.Height = Convert.ToInt32(dr["Height"]);
            if (Fileds.ContainsKey("Rotate") && !Convert.IsDBNull(dr["Rotate"])) nc.Rotate = Convert.ToInt32(dr["Rotate"]);
            if (Fileds.ContainsKey("IsRandom") && !Convert.IsDBNull(dr["IsRandom"])) nc.IsRandom = Convert.ToInt32(dr["IsRandom"]);
            if (Fileds.ContainsKey("OrderBy") && !Convert.IsDBNull(dr["OrderBy"])) nc.OrderBy = Convert.ToInt32(dr["OrderBy"]);

            if (Fileds.ContainsKey("BorderSize") && !Convert.IsDBNull(dr["BorderSize"])) nc.BorderSize = Convert.ToDouble(dr["BorderSize"]);
            if (Fileds.ContainsKey("BorderColor") && !Convert.IsDBNull(dr["BorderColor"])) nc.BorderColor = Convert.ToString(dr["BorderColor"]).Trim();
         
            return nc;
        }

        public abstract List<tbValuesEntity> tbValuesList(QueryParam qp, out int RecordCount);

        protected tbValuesEntity PopulatetbValuesEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbValuesEntity nc = new tbValuesEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]);
            if (Fileds.ContainsKey("FieldsID") && !Convert.IsDBNull(dr["FieldsID"])) nc.FieldsID = Convert.ToInt32(dr["FieldsID"]);
            if (Fileds.ContainsKey("Value") && !Convert.IsDBNull(dr["Value"])) nc.Value = Convert.ToString(dr["Value"]).Trim();
            if (Fileds.ContainsKey("X") && !Convert.IsDBNull(dr["X"])) nc.X = Convert.ToInt32(dr["X"]);
            if (Fileds.ContainsKey("Y") && !Convert.IsDBNull(dr["Y"])) nc.Y = Convert.ToInt32(dr["Y"]);
            if (Fileds.ContainsKey("RelaID") && !Convert.IsDBNull(dr["RelaID"])) nc.RelaID = Convert.ToInt32(dr["RelaID"]);

            return nc;
        }

        public abstract List<tbSubmissionEntity> tbSubmissionList(QueryParam qp, out int RecordCount);

        protected tbSubmissionEntity PopulatetbSubmissionEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            tbSubmissionEntity nc = new tbSubmissionEntity();
            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]);
            if (Fileds.ContainsKey("ImgID") && !Convert.IsDBNull(dr["ImgID"])) nc.ImgID = Convert.ToInt32(dr["ImgID"]);
            if (Fileds.ContainsKey("ImageUrl") && !Convert.IsDBNull(dr["ImageUrl"])) nc.ImageUrl = Convert.ToString(dr["ImageUrl"]).Trim();
            if (Fileds.ContainsKey("FormID") && !Convert.IsDBNull(dr["FormID"])) nc.FormID = Convert.ToString(dr["FormID"]).Trim();
            if (Fileds.ContainsKey("Ip") && !Convert.IsDBNull(dr["Ip"])) nc.Ip = Convert.ToString(dr["Ip"]).Trim();
            if (Fileds.ContainsKey("UserID") && !Convert.IsDBNull(dr["UserID"])) nc.UserID = Convert.ToInt32(dr["UserID"]);
            if (Fileds.ContainsKey("CreateDate") && !Convert.IsDBNull(dr["CreateDate"])) nc.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
            
            return nc;
        }
    }
}
