/********************************************************************************
     File:																
            BusinessFacade.cs                         
     Description:
            业务逻辑类
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
			2014/8/5 13:39:35
     History:
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using DLT.Components;
using DLT.Data;
using System.Data;
using System.Data.SqlClient;
using FrameWork.Components;

namespace DLT
{
    /// <summary>
    /// 业务逻辑类
    /// </summary>
    public partial class BusinessFacadeDLT
    {
        #region MyRegion
		
        #region "tbAppointArbitration(tbAppointArbitration) - Method"

        /// <summary>
        /// 新增/删除/修改 tbAppointArbitrationEntity (tbAppointArbitration)
        /// </summary>
        /// <param name="fam">tbAppointArbitrationEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbAppointArbitrationInsertUpdateDelete(tbAppointArbitrationEntity fam)
        {
            return DataProvider.Instance().tbAppointArbitrationInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbAppointArbitrationEntity (tbAppointArbitration)
        /// </summary>
        /// <param name="fam">tbAppointArbitrationEntity实体类</param>
        /// <param name="tran">tbAppointArbitration事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbAppointArbitrationInsertUpdateDelete(tbAppointArbitrationEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tbAppointArbitrationInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据ID返回 tbAppointArbitrationEntity实体类 单笔资料 (tbAppointArbitration)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbAppointArbitrationEntity实体类 ID为0则无记录</returns>
        public static tbAppointArbitrationEntity tbAppointArbitrationDisp(Int32 ID)
        {
            tbAppointArbitrationEntity fam = new tbAppointArbitrationEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbAppointArbitration", "ID", ID);
            int RecordCount = 0;
            List<tbAppointArbitrationEntity> lst = tbAppointArbitrationList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbAppointArbitrationEntity实体类 单笔资料 (tbAppointArbitration)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbAppointArbitration事务</param>
        /// <returns>返回 tbAppointArbitrationEntity实体类 ID为0则无记录</returns>
        public static tbAppointArbitrationEntity tbAppointArbitrationDisp(Int32 ID, DbTransaction tran)
        {
            tbAppointArbitrationEntity fam = new tbAppointArbitrationEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbAppointArbitration", "ID", ID);
            int RecordCount = 0;
            List<tbAppointArbitrationEntity> lst = tbAppointArbitrationList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbAppointArbitrationEntity实体类的List对象 (tbAppointArbitration)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbAppointArbitrationEntity实体类的List对象(tbAppointArbitration)</returns>
        public static List<tbAppointArbitrationEntity> tbAppointArbitrationList(QueryParam qp, out int RecordCount)
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
        public static List<tbAppointArbitrationEntity> tbAppointArbitrationList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbAppointArbitration";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbAppointArbitrationList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbAppointArbitrationList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbActivityBlack(tbActivityBlack) - Method"

        /// <summary>
        /// 新增/删除/修改 tbActivityBlackEntity (tbActivityBlack)
        /// </summary>
        /// <param name="fam">tbActivityBlackEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbActivityBlackInsertUpdateDelete(tbActivityBlackEntity fam)
        {
            return DataProvider.Instance().tbActivityBlackInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbActivityBlackEntity (tbActivityBlack)
        /// </summary>
        /// <param name="fam">tbActivityBlackEntity实体类</param>
        /// <param name="tran">tbActivityBlack事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbActivityBlackInsertUpdateDelete(tbActivityBlackEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tbActivityBlackInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据ID返回 tbActivityBlackEntity实体类 单笔资料 (tbActivityBlack)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbActivityBlackEntity实体类 ID为0则无记录</returns>
        public static tbActivityBlackEntity tbActivityBlackDisp(Int32 ID)
        {
            tbActivityBlackEntity fam = new tbActivityBlackEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbActivityBlack", "ID", ID);
            int RecordCount = 0;
            List<tbActivityBlackEntity> lst = tbActivityBlackList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbActivityBlackEntity实体类 单笔资料 (tbActivityBlack)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbActivityBlack事务</param>
        /// <returns>返回 tbActivityBlackEntity实体类 ID为0则无记录</returns>
        public static tbActivityBlackEntity tbActivityBlackDisp(Int32 ID, DbTransaction tran)
        {
            tbActivityBlackEntity fam = new tbActivityBlackEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbActivityBlack", "ID", ID);
            int RecordCount = 0;
            List<tbActivityBlackEntity> lst = tbActivityBlackList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbActivityBlackEntity实体类的List对象 (tbActivityBlack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbActivityBlackEntity实体类的List对象(tbActivityBlack)</returns>
        public static List<tbActivityBlackEntity> tbActivityBlackList(QueryParam qp, out int RecordCount)
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
        public static List<tbActivityBlackEntity> tbActivityBlackList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbActivityBlack";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbActivityBlackList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbActivityBlackList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbActivity(tbActivity) - Method"

        /// <summary>
        /// 新增/删除/修改 tbActivityEntity (tbActivity)
        /// </summary>
        /// <param name="fam">tbActivityEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbActivityInsertUpdateDelete(tbActivityEntity fam)
        {
            return DataProvider.Instance().tbActivityInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbActivityEntity (tbActivity)
        /// </summary>
        /// <param name="fam">tbActivityEntity实体类</param>
        /// <param name="tran">tbActivity事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbActivityInsertUpdateDelete(tbActivityEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tbActivityInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据ID返回 tbActivityEntity实体类 单笔资料 (tbActivity)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbActivityEntity实体类 ID为0则无记录</returns>
        public static tbActivityEntity tbActivityDisp(Int32 ID)
        {
            tbActivityEntity fam = new tbActivityEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbActivity", "ID", ID);
            int RecordCount = 0;
            List<tbActivityEntity> lst = tbActivityList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbActivityEntity实体类 单笔资料 (tbActivity)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbActivity事务</param>
        /// <returns>返回 tbActivityEntity实体类 ID为0则无记录</returns>
        public static tbActivityEntity tbActivityDisp(Int32 ID, DbTransaction tran)
        {
            tbActivityEntity fam = new tbActivityEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbActivity", "ID", ID);
            int RecordCount = 0;
            List<tbActivityEntity> lst = tbActivityList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbActivityEntity实体类的List对象 (tbActivity)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbActivityEntity实体类的List对象(tbActivity)</returns>
        public static List<tbActivityEntity> tbActivityList(QueryParam qp, out int RecordCount)
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
        public static List<tbActivityEntity> tbActivityList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbActivity";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbActivityList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbActivityList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tsNotice(系统公告) - Method"

        /// <summary>
        /// 新增/删除/修改 tsNoticeEntity (系统公告)
        /// </summary>
        /// <param name="fam">tsNoticeEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsNoticeInsertUpdateDelete(tsNoticeEntity fam)
        {
            return DataProvider.Instance().tsNoticeInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsNoticeEntity (系统公告)
        /// </summary>
        /// <param name="fam">tsNoticeEntity实体类</param>
        /// <param name="tran">tsNotice事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsNoticeInsertUpdateDelete(tsNoticeEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tsNoticeInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据ID返回 tsNoticeEntity实体类 单笔资料 (系统公告)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsNoticeEntity实体类 ID为0则无记录</returns>
        public static tsNoticeEntity tsNoticeDisp(Int32 ID)
        {
            tsNoticeEntity fam = new tsNoticeEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tsNotice", "ID", ID);
            int RecordCount = 0;
            List<tsNoticeEntity> lst = tsNoticeList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsNoticeEntity实体类 单笔资料 (系统公告)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsNotice事务</param>
        /// <returns>返回 tsNoticeEntity实体类 ID为0则无记录</returns>
        public static tsNoticeEntity tsNoticeDisp(Int32 ID, DbTransaction tran)
        {
            tsNoticeEntity fam = new tsNoticeEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tsNotice", "ID", ID);
            int RecordCount = 0;
            List<tsNoticeEntity> lst = tsNoticeList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsNoticeEntity实体类的List对象 (系统公告)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsNoticeEntity实体类的List对象(系统公告)</returns>
        public static List<tsNoticeEntity> tsNoticeList(QueryParam qp, out int RecordCount)
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
        public static List<tsNoticeEntity> tsNoticeList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tsNotice";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tsNoticeList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsNoticeList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbFeedBack(tbFeedBack) - Method"

        /// <summary>
        /// 新增/删除/修改 tbFeedBackEntity (tbFeedBack)
        /// </summary>
        /// <param name="fam">tbFeedBackEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbFeedBackInsertUpdateDelete(tbFeedBackEntity fam)
        {
            return DataProvider.Instance().tbFeedBackInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbFeedBackEntity (tbFeedBack)
        /// </summary>
        /// <param name="fam">tbFeedBackEntity实体类</param>
        /// <param name="tran">tbFeedBack事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbFeedBackInsertUpdateDelete(tbFeedBackEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tbFeedBackInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据ID返回 tbFeedBackEntity实体类 单笔资料 (tbFeedBack)
        /// </summary>
        /// <param name="ID">ID 序号ID</param>
        /// <returns>返回 tbFeedBackEntity实体类 ID为0则无记录</returns>
        public static tbFeedBackEntity tbFeedBackDisp(Int32 ID)
        {
            tbFeedBackEntity fam = new tbFeedBackEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbFeedBack", "ID", ID);
            int RecordCount = 0;
            List<tbFeedBackEntity> lst = tbFeedBackList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbFeedBackEntity实体类 单笔资料 (tbFeedBack)
        /// </summary>
        /// <param name="ID">ID 序号ID</param>
        /// <param name="tran">tbFeedBack事务</param>
        /// <returns>返回 tbFeedBackEntity实体类 ID为0则无记录</returns>
        public static tbFeedBackEntity tbFeedBackDisp(Int32 ID, DbTransaction tran)
        {
            tbFeedBackEntity fam = new tbFeedBackEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbFeedBack", "ID", ID);
            int RecordCount = 0;
            List<tbFeedBackEntity> lst = tbFeedBackList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbFeedBackEntity实体类的List对象 (tbFeedBack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbFeedBackEntity实体类的List对象(tbFeedBack)</returns>
        public static List<tbFeedBackEntity> tbFeedBackList(QueryParam qp, out int RecordCount)
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
        public static List<tbFeedBackEntity> tbFeedBackList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbFeedBack";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbFeedBackList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbFeedBackList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "sys_StatisticalGrouping(sys_StatisticalGrouping) - Method"

        /// <summary>
        /// 新增/删除/修改 sys_StatisticalGroupingEntity (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="fam">sys_StatisticalGroupingEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 sys_StatisticalGroupingInsertUpdateDelete(sys_StatisticalGroupingEntity fam)
        {
            return DataProvider.Instance().sys_StatisticalGroupingInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 sys_StatisticalGroupingEntity (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="fam">sys_StatisticalGroupingEntity实体类</param>
        /// <param name="tran">sys_StatisticalGrouping事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 sys_StatisticalGroupingInsertUpdateDelete(sys_StatisticalGroupingEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().sys_StatisticalGroupingInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据S_ID返回 sys_StatisticalGroupingEntity实体类 单笔资料 (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="S_ID">S_ID S_ID</param>
        /// <returns>返回 sys_StatisticalGroupingEntity实体类 S_ID为0则无记录</returns>
        public static sys_StatisticalGroupingEntity sys_StatisticalGroupingDisp(Int32 S_ID)
        {
            sys_StatisticalGroupingEntity fam = new sys_StatisticalGroupingEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "sys_StatisticalGrouping", "S_ID", S_ID);
            int RecordCount = 0;
            List<sys_StatisticalGroupingEntity> lst = sys_StatisticalGroupingList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据S_ID返回 sys_StatisticalGroupingEntity实体类 单笔资料 (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="S_ID">S_ID S_ID</param>
        /// <param name="tran">sys_StatisticalGrouping事务</param>
        /// <returns>返回 sys_StatisticalGroupingEntity实体类 S_ID为0则无记录</returns>
        public static sys_StatisticalGroupingEntity sys_StatisticalGroupingDisp(Int32 S_ID, DbTransaction tran)
        {
            sys_StatisticalGroupingEntity fam = new sys_StatisticalGroupingEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "sys_StatisticalGrouping", "S_ID", S_ID);
            int RecordCount = 0;
            List<sys_StatisticalGroupingEntity> lst = sys_StatisticalGroupingList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回sys_StatisticalGroupingEntity实体类的List对象 (sys_StatisticalGrouping)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_StatisticalGroupingEntity实体类的List对象(sys_StatisticalGrouping)</returns>
        public static List<sys_StatisticalGroupingEntity> sys_StatisticalGroupingList(QueryParam qp, out int RecordCount)
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
        public static List<sys_StatisticalGroupingEntity> sys_StatisticalGroupingList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "sys_StatisticalGrouping";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "S_ID";
            }
            else if (qp.Orderfld != "S_ID")
            {
                qp.Orderfld += ",S_ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().sys_StatisticalGroupingList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().sys_StatisticalGroupingList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbPostReport(tbPostReport) - Method"

        /// <summary>
        /// 新增/删除/修改 tbPostReportEntity (tbPostReport)
        /// </summary>
        /// <param name="fam">tbPostReportEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbPostReportInsertUpdateDelete(tbPostReportEntity fam)
        {
            return DataProvider.Instance().tbPostReportInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbPostReportEntity (tbPostReport)
        /// </summary>
        /// <param name="fam">tbPostReportEntity实体类</param>
        /// <param name="tran">tbPostReport事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbPostReportInsertUpdateDelete(tbPostReportEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tbPostReportInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据ID返回 tbPostReportEntity实体类 单笔资料 (tbPostReport)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbPostReportEntity实体类 ID为0则无记录</returns>
        public static tbPostReportEntity tbPostReportDisp(Int32 ID)
        {
            tbPostReportEntity fam = new tbPostReportEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbPostReport", "ID", ID);
            int RecordCount = 0;
            List<tbPostReportEntity> lst = tbPostReportList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbPostReportEntity实体类 单笔资料 (tbPostReport)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbPostReport事务</param>
        /// <returns>返回 tbPostReportEntity实体类 ID为0则无记录</returns>
        public static tbPostReportEntity tbPostReportDisp(Int32 ID, DbTransaction tran)
        {
            tbPostReportEntity fam = new tbPostReportEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbPostReport", "ID", ID);
            int RecordCount = 0;
            List<tbPostReportEntity> lst = tbPostReportList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbPostReportEntity实体类的List对象 (tbPostReport)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbPostReportEntity实体类的List对象(tbPostReport)</returns>
        public static List<tbPostReportEntity> tbPostReportList(QueryParam qp, out int RecordCount)
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
        public static List<tbPostReportEntity> tbPostReportList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbPostReport";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbPostReportList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbPostReportList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tsBankBlack(tsBankBlack) - Method"

        /// <summary>
        /// 新增/删除/修改 tsBankBlackEntity (tsBankBlack)
        /// </summary>
        /// <param name="fam">tsBankBlackEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsBankBlackInsertUpdateDelete(tsBankBlackEntity fam)
        {
            return DataProvider.Instance().tsBankBlackInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsBankBlackEntity (tsBankBlack)
        /// </summary>
        /// <param name="fam">tsBankBlackEntity实体类</param>
        /// <param name="tran">tsBankBlack事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsBankBlackInsertUpdateDelete(tsBankBlackEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tsBankBlackInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据ID返回 tsBankBlackEntity实体类 单笔资料 (tsBankBlack)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsBankBlackEntity实体类 ID为0则无记录</returns>
        public static tsBankBlackEntity tsBankBlackDisp(Int32 ID)
        {
            tsBankBlackEntity fam = new tsBankBlackEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tsBankBlack", "ID", ID);
            int RecordCount = 0;
            List<tsBankBlackEntity> lst = tsBankBlackList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsBankBlackEntity实体类 单笔资料 (tsBankBlack)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsBankBlack事务</param>
        /// <returns>返回 tsBankBlackEntity实体类 ID为0则无记录</returns>
        public static tsBankBlackEntity tsBankBlackDisp(Int32 ID, DbTransaction tran)
        {
            tsBankBlackEntity fam = new tsBankBlackEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tsBankBlack", "ID", ID);
            int RecordCount = 0;
            List<tsBankBlackEntity> lst = tsBankBlackList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsBankBlackEntity实体类的List对象 (tsBankBlack)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsBankBlackEntity实体类的List对象(tsBankBlack)</returns>
        public static List<tsBankBlackEntity> tsBankBlackList(QueryParam qp, out int RecordCount)
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
        public static List<tsBankBlackEntity> tsBankBlackList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tsBankBlack";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tsBankBlackList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsBankBlackList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbLevelOrderReJudg(tbLevelOrderReJudg) - Method"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderReJudgEntity (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="fam">tbLevelOrderReJudgEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderReJudgInsertUpdateDelete(tbLevelOrderReJudgEntity fam)
        {
            return DataProvider.Instance().tbLevelOrderReJudgInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderReJudgEntity (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="fam">tbLevelOrderReJudgEntity实体类</param>
        /// <param name="tran">tbLevelOrderReJudg事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderReJudgInsertUpdateDelete(tbLevelOrderReJudgEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tbLevelOrderReJudgInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据ID返回 tbLevelOrderReJudgEntity实体类 单笔资料 (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbLevelOrderReJudgEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderReJudgEntity tbLevelOrderReJudgDisp(Int32 ID)
        {
            tbLevelOrderReJudgEntity fam = new tbLevelOrderReJudgEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbLevelOrderReJudg", "ID", ID);
            int RecordCount = 0;
            List<tbLevelOrderReJudgEntity> lst = tbLevelOrderReJudgList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbLevelOrderReJudgEntity实体类 单笔资料 (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbLevelOrderReJudg事务</param>
        /// <returns>返回 tbLevelOrderReJudgEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderReJudgEntity tbLevelOrderReJudgDisp(Int32 ID, DbTransaction tran)
        {
            tbLevelOrderReJudgEntity fam = new tbLevelOrderReJudgEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbLevelOrderReJudg", "ID", ID);
            int RecordCount = 0;
            List<tbLevelOrderReJudgEntity> lst = tbLevelOrderReJudgList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbLevelOrderReJudgEntity实体类的List对象 (tbLevelOrderReJudg)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderReJudgEntity实体类的List对象(tbLevelOrderReJudg)</returns>
        public static List<tbLevelOrderReJudgEntity> tbLevelOrderReJudgList(QueryParam qp, out int RecordCount)
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
        public static List<tbLevelOrderReJudgEntity> tbLevelOrderReJudgList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbLevelOrderReJudg";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbLevelOrderReJudgList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbLevelOrderReJudgList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbServiceHelp(tbServiceHelp) - Method"

        /// <summary>
        /// 新增/删除/修改 tbServiceHelpEntity (tbServiceHelp)
        /// </summary>
        /// <param name="fam">tbServiceHelpEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbServiceHelpInsertUpdateDelete(tbServiceHelpEntity fam)
        {
            return DataProvider.Instance().tbServiceHelpInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbServiceHelpEntity (tbServiceHelp)
        /// </summary>
        /// <param name="fam">tbServiceHelpEntity实体类</param>
        /// <param name="tran">tbServiceHelp事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbServiceHelpInsertUpdateDelete(tbServiceHelpEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tbServiceHelpInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据ID返回 tbServiceHelpEntity实体类 单笔资料 (tbServiceHelp)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbServiceHelpEntity实体类 ID为0则无记录</returns>
        public static tbServiceHelpEntity tbServiceHelpDisp(Int32 ID)
        {
            tbServiceHelpEntity fam = new tbServiceHelpEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbServiceHelp", "ID", ID);
            int RecordCount = 0;
            List<tbServiceHelpEntity> lst = tbServiceHelpList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbServiceHelpEntity实体类 单笔资料 (tbServiceHelp)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbServiceHelp事务</param>
        /// <returns>返回 tbServiceHelpEntity实体类 ID为0则无记录</returns>
        public static tbServiceHelpEntity tbServiceHelpDisp(Int32 ID, DbTransaction tran)
        {
            tbServiceHelpEntity fam = new tbServiceHelpEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbServiceHelp", "ID", ID);
            int RecordCount = 0;
            List<tbServiceHelpEntity> lst = tbServiceHelpList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbServiceHelpEntity实体类的List对象 (tbServiceHelp)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbServiceHelpEntity实体类的List对象(tbServiceHelp)</returns>
        public static List<tbServiceHelpEntity> tbServiceHelpList(QueryParam qp, out int RecordCount)
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
        public static List<tbServiceHelpEntity> tbServiceHelpList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbServiceHelp";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbServiceHelpList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbServiceHelpList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbFinancialDay(财务每日数据) - Method"

        /// <summary>
        /// 新增/删除/修改 tbFinancialDayEntity (财务每日数据)
        /// </summary>
        /// <param name="fam">tbFinancialDayEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbFinancialDayInsertUpdateDelete(tbFinancialDayEntity fam)
        {
            return DataProvider.Instance().tbFinancialDayInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbFinancialDayEntity (财务每日数据)
        /// </summary>
        /// <param name="fam">tbFinancialDayEntity实体类</param>
        /// <param name="tran">tbFinancialDay事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbFinancialDayInsertUpdateDelete(tbFinancialDayEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tbFinancialDayInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tbFinancialDayEntity实体类 单笔资料 (财务每日数据)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbFinancialDayEntity实体类 ID为0则无记录</returns>
        public static tbFinancialDayEntity tbFinancialDayDisp(Int32 ID)
        {
            tbFinancialDayEntity fam = new tbFinancialDayEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbFinancialDay","ID",ID);
            int RecordCount = 0;
            List<tbFinancialDayEntity> lst = tbFinancialDayList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbFinancialDayEntity实体类 单笔资料 (财务每日数据)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbFinancialDay事务</param>
        /// <returns>返回 tbFinancialDayEntity实体类 ID为0则无记录</returns>
        public static tbFinancialDayEntity tbFinancialDayDisp(Int32 ID,DbTransaction tran)
        {
            tbFinancialDayEntity fam = new tbFinancialDayEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbFinancialDay","ID",ID);
            int RecordCount = 0;
            List<tbFinancialDayEntity> lst = tbFinancialDayList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbFinancialDayEntity实体类的List对象 (财务每日数据)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbFinancialDayEntity实体类的List对象(财务每日数据)</returns>
        public static List<tbFinancialDayEntity> tbFinancialDayList(QueryParam qp, out int RecordCount)
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
        public static List<tbFinancialDayEntity> tbFinancialDayList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tbFinancialDay";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tbFinancialDayList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbFinancialDayList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tbLevelOrderCancel(代练撤销) - Method"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderCancelEntity (代练撤销)
        /// </summary>
        /// <param name="fam">tbLevelOrderCancelEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderCancelInsertUpdateDelete(tbLevelOrderCancelEntity fam)
        {
            return DataProvider.Instance().tbLevelOrderCancelInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderCancelEntity (代练撤销)
        /// </summary>
        /// <param name="fam">tbLevelOrderCancelEntity实体类</param>
        /// <param name="tran">tbLevelOrderCancel事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderCancelInsertUpdateDelete(tbLevelOrderCancelEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tbLevelOrderCancelInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tbLevelOrderCancelEntity实体类 单笔资料 (代练撤销)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbLevelOrderCancelEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderCancelEntity tbLevelOrderCancelDisp(Int32 ID)
        {
            tbLevelOrderCancelEntity fam = new tbLevelOrderCancelEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbLevelOrderCancel","ID",ID);
            int RecordCount = 0;
            List<tbLevelOrderCancelEntity> lst = tbLevelOrderCancelList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbLevelOrderCancelEntity实体类 单笔资料 (代练撤销)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbLevelOrderCancel事务</param>
        /// <returns>返回 tbLevelOrderCancelEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderCancelEntity tbLevelOrderCancelDisp(Int32 ID,DbTransaction tran)
        {
            tbLevelOrderCancelEntity fam = new tbLevelOrderCancelEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbLevelOrderCancel","ID",ID);
            int RecordCount = 0;
            List<tbLevelOrderCancelEntity> lst = tbLevelOrderCancelList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbLevelOrderCancelEntity实体类的List对象 (代练撤销)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderCancelEntity实体类的List对象(代练撤销)</returns>
        public static List<tbLevelOrderCancelEntity> tbLevelOrderCancelList(QueryParam qp, out int RecordCount)
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
        public static List<tbLevelOrderCancelEntity> tbLevelOrderCancelList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tbLevelOrderCancel";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tbLevelOrderCancelList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbLevelOrderCancelList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tbLevelOrderFee(订单费用) - Method"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderFeeEntity (订单费用)
        /// </summary>
        /// <param name="fam">tbLevelOrderFeeEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderFeeInsertUpdateDelete(tbLevelOrderFeeEntity fam)
        {
            return DataProvider.Instance().tbLevelOrderFeeInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderFeeEntity (订单费用)
        /// </summary>
        /// <param name="fam">tbLevelOrderFeeEntity实体类</param>
        /// <param name="tran">tbLevelOrderFee事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderFeeInsertUpdateDelete(tbLevelOrderFeeEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tbLevelOrderFeeInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tbLevelOrderFeeEntity实体类 单笔资料 (订单费用)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbLevelOrderFeeEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderFeeEntity tbLevelOrderFeeDisp(Int32 ID)
        {
            tbLevelOrderFeeEntity fam = new tbLevelOrderFeeEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbLevelOrderFee","ID",ID);
            int RecordCount = 0;
            List<tbLevelOrderFeeEntity> lst = tbLevelOrderFeeList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbLevelOrderFeeEntity实体类 单笔资料 (订单费用)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbLevelOrderFee事务</param>
        /// <returns>返回 tbLevelOrderFeeEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderFeeEntity tbLevelOrderFeeDisp(Int32 ID,DbTransaction tran)
        {
            tbLevelOrderFeeEntity fam = new tbLevelOrderFeeEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbLevelOrderFee","ID",ID);
            int RecordCount = 0;
            List<tbLevelOrderFeeEntity> lst = tbLevelOrderFeeList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbLevelOrderFeeEntity实体类的List对象 (订单费用)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderFeeEntity实体类的List对象(订单费用)</returns>
        public static List<tbLevelOrderFeeEntity> tbLevelOrderFeeList(QueryParam qp, out int RecordCount)
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
        public static List<tbLevelOrderFeeEntity> tbLevelOrderFeeList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tbLevelOrderFee";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tbLevelOrderFeeList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbLevelOrderFeeList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tbLevelOrderInfo(代练订单角色资料) - Method"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderInfoEntity (代练订单角色资料)
        /// </summary>
        /// <param name="fam">tbLevelOrderInfoEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderInfoInsertUpdateDelete(tbLevelOrderInfoEntity fam)
        {
            return DataProvider.Instance().tbLevelOrderInfoInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderInfoEntity (代练订单角色资料)
        /// </summary>
        /// <param name="fam">tbLevelOrderInfoEntity实体类</param>
        /// <param name="tran">tbLevelOrderInfo事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderInfoInsertUpdateDelete(tbLevelOrderInfoEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tbLevelOrderInfoInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tbLevelOrderInfoEntity实体类 单笔资料 (代练订单角色资料)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbLevelOrderInfoEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderInfoEntity tbLevelOrderInfoDisp(Int32 ID)
        {
            tbLevelOrderInfoEntity fam = new tbLevelOrderInfoEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbLevelOrderInfo","ID",ID);
            int RecordCount = 0;
            List<tbLevelOrderInfoEntity> lst = tbLevelOrderInfoList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbLevelOrderInfoEntity实体类 单笔资料 (代练订单角色资料)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbLevelOrderInfo事务</param>
        /// <returns>返回 tbLevelOrderInfoEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderInfoEntity tbLevelOrderInfoDisp(Int32 ID,DbTransaction tran)
        {
            tbLevelOrderInfoEntity fam = new tbLevelOrderInfoEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbLevelOrderInfo","ID",ID);
            int RecordCount = 0;
            List<tbLevelOrderInfoEntity> lst = tbLevelOrderInfoList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbLevelOrderInfoEntity实体类的List对象 (代练订单角色资料)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderInfoEntity实体类的List对象(代练订单角色资料)</returns>
        public static List<tbLevelOrderInfoEntity> tbLevelOrderInfoList(QueryParam qp, out int RecordCount)
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
        public static List<tbLevelOrderInfoEntity> tbLevelOrderInfoList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tbLevelOrderInfo";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tbLevelOrderInfoList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbLevelOrderInfoList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tbLevelOrderMessage(订单交互留言) - Method"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderMessageEntity (订单交互留言)
        /// </summary>
        /// <param name="fam">tbLevelOrderMessageEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderMessageInsertUpdateDelete(tbLevelOrderMessageEntity fam)
        {
            return DataProvider.Instance().tbLevelOrderMessageInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderMessageEntity (订单交互留言)
        /// </summary>
        /// <param name="fam">tbLevelOrderMessageEntity实体类</param>
        /// <param name="tran">tbLevelOrderMessage事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderMessageInsertUpdateDelete(tbLevelOrderMessageEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tbLevelOrderMessageInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tbLevelOrderMessageEntity实体类 单笔资料 (订单交互留言)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbLevelOrderMessageEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderMessageEntity tbLevelOrderMessageDisp(Int32 ID)
        {
            tbLevelOrderMessageEntity fam = new tbLevelOrderMessageEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbLevelOrderMessage","ID",ID);
            int RecordCount = 0;
            List<tbLevelOrderMessageEntity> lst = tbLevelOrderMessageList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbLevelOrderMessageEntity实体类 单笔资料 (订单交互留言)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbLevelOrderMessage事务</param>
        /// <returns>返回 tbLevelOrderMessageEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderMessageEntity tbLevelOrderMessageDisp(Int32 ID,DbTransaction tran)
        {
            tbLevelOrderMessageEntity fam = new tbLevelOrderMessageEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbLevelOrderMessage","ID",ID);
            int RecordCount = 0;
            List<tbLevelOrderMessageEntity> lst = tbLevelOrderMessageList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbLevelOrderMessageEntity实体类的List对象 (订单交互留言)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderMessageEntity实体类的List对象(订单交互留言)</returns>
        public static List<tbLevelOrderMessageEntity> tbLevelOrderMessageList(QueryParam qp, out int RecordCount)
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
        public static List<tbLevelOrderMessageEntity> tbLevelOrderMessageList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tbLevelOrderMessage";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tbLevelOrderMessageList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbLevelOrderMessageList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tbLevelOrderProgress(代练进度) - Method"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderProgressEntity (代练进度)
        /// </summary>
        /// <param name="fam">tbLevelOrderProgressEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderProgressInsertUpdateDelete(tbLevelOrderProgressEntity fam)
        {
            return DataProvider.Instance().tbLevelOrderProgressInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderProgressEntity (代练进度)
        /// </summary>
        /// <param name="fam">tbLevelOrderProgressEntity实体类</param>
        /// <param name="tran">tbLevelOrderProgress事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderProgressInsertUpdateDelete(tbLevelOrderProgressEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tbLevelOrderProgressInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tbLevelOrderProgressEntity实体类 单笔资料 (代练进度)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbLevelOrderProgressEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderProgressEntity tbLevelOrderProgressDisp(Int32 ID)
        {
            tbLevelOrderProgressEntity fam = new tbLevelOrderProgressEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbLevelOrderProgress","ID",ID);
            int RecordCount = 0;
            List<tbLevelOrderProgressEntity> lst = tbLevelOrderProgressList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbLevelOrderProgressEntity实体类 单笔资料 (代练进度)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbLevelOrderProgress事务</param>
        /// <returns>返回 tbLevelOrderProgressEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderProgressEntity tbLevelOrderProgressDisp(Int32 ID,DbTransaction tran)
        {
            tbLevelOrderProgressEntity fam = new tbLevelOrderProgressEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbLevelOrderProgress","ID",ID);
            int RecordCount = 0;
            List<tbLevelOrderProgressEntity> lst = tbLevelOrderProgressList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbLevelOrderProgressEntity实体类的List对象 (代练进度)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderProgressEntity实体类的List对象(代练进度)</returns>
        public static List<tbLevelOrderProgressEntity> tbLevelOrderProgressList(QueryParam qp, out int RecordCount)
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
        public static List<tbLevelOrderProgressEntity> tbLevelOrderProgressList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tbLevelOrderProgress";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tbLevelOrderProgressList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbLevelOrderProgressList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tbLevelOrderRight(订单可查看权限) - Method"

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderRightEntity (订单可查看权限)
        /// </summary>
        /// <param name="fam">tbLevelOrderRightEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderRightInsertUpdateDelete(tbLevelOrderRightEntity fam)
        {
            return DataProvider.Instance().tbLevelOrderRightInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbLevelOrderRightEntity (订单可查看权限)
        /// </summary>
        /// <param name="fam">tbLevelOrderRightEntity实体类</param>
        /// <param name="tran">tbLevelOrderRight事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbLevelOrderRightInsertUpdateDelete(tbLevelOrderRightEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tbLevelOrderRightInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tbLevelOrderRightEntity实体类 单笔资料 (订单可查看权限)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbLevelOrderRightEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderRightEntity tbLevelOrderRightDisp(Int32 ID)
        {
            tbLevelOrderRightEntity fam = new tbLevelOrderRightEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbLevelOrderRight","ID",ID);
            int RecordCount = 0;
            List<tbLevelOrderRightEntity> lst = tbLevelOrderRightList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbLevelOrderRightEntity实体类 单笔资料 (订单可查看权限)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbLevelOrderRight事务</param>
        /// <returns>返回 tbLevelOrderRightEntity实体类 ID为0则无记录</returns>
        public static tbLevelOrderRightEntity tbLevelOrderRightDisp(Int32 ID,DbTransaction tran)
        {
            tbLevelOrderRightEntity fam = new tbLevelOrderRightEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tbLevelOrderRight","ID",ID);
            int RecordCount = 0;
            List<tbLevelOrderRightEntity> lst = tbLevelOrderRightList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbLevelOrderRightEntity实体类的List对象 (订单可查看权限)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbLevelOrderRightEntity实体类的List对象(订单可查看权限)</returns>
        public static List<tbLevelOrderRightEntity> tbLevelOrderRightList(QueryParam qp, out int RecordCount)
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
        public static List<tbLevelOrderRightEntity> tbLevelOrderRightList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tbLevelOrderRight";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tbLevelOrderRightList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbLevelOrderRightList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tcUserStat(用户统计数据) - Method"

        /// <summary>
        /// 新增/删除/修改 tcUserStatEntity (用户统计数据)
        /// </summary>
        /// <param name="fam">tcUserStatEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tcUserStatInsertUpdateDelete(tcUserStatEntity fam)
        {
            return DataProvider.Instance().tcUserStatInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tcUserStatEntity (用户统计数据)
        /// </summary>
        /// <param name="fam">tcUserStatEntity实体类</param>
        /// <param name="tran">tcUserStat事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tcUserStatInsertUpdateDelete(tcUserStatEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tcUserStatInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tcUserStatEntity实体类 单笔资料 (用户统计数据)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tcUserStatEntity实体类 ID为0则无记录</returns>
        public static tcUserStatEntity tcUserStatDisp(Int32 ID)
        {
            tcUserStatEntity fam = new tcUserStatEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tcUserStat","ID",ID);
            int RecordCount = 0;
            List<tcUserStatEntity> lst = tcUserStatList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tcUserStatEntity实体类 单笔资料 (用户统计数据)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tcUserStat事务</param>
        /// <returns>返回 tcUserStatEntity实体类 ID为0则无记录</returns>
        public static tcUserStatEntity tcUserStatDisp(Int32 ID,DbTransaction tran)
        {
            tcUserStatEntity fam = new tcUserStatEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tcUserStat","ID",ID);
            int RecordCount = 0;
            List<tcUserStatEntity> lst = tcUserStatList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tcUserStatEntity实体类的List对象 (用户统计数据)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tcUserStatEntity实体类的List对象(用户统计数据)</returns>
        public static List<tcUserStatEntity> tcUserStatList(QueryParam qp, out int RecordCount)
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
        public static List<tcUserStatEntity> tcUserStatList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tcUserStat";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tcUserStatList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tcUserStatList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tlLogin(登录日志) - Method"

        /// <summary>
        /// 新增/删除/修改 tlLoginEntity (登录日志)
        /// </summary>
        /// <param name="fam">tlLoginEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tlLoginInsertUpdateDelete(tlLoginEntity fam)
        {
            return DataProvider.Instance().tlLoginInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tlLoginEntity (登录日志)
        /// </summary>
        /// <param name="fam">tlLoginEntity实体类</param>
        /// <param name="tran">tlLogin事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tlLoginInsertUpdateDelete(tlLoginEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tlLoginInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tlLoginEntity实体类 单笔资料 (登录日志)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tlLoginEntity实体类 ID为0则无记录</returns>
        public static tlLoginEntity tlLoginDisp(Int32 ID)
        {
            tlLoginEntity fam = new tlLoginEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tlLogin","ID",ID);
            int RecordCount = 0;
            List<tlLoginEntity> lst = tlLoginList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tlLoginEntity实体类 单笔资料 (登录日志)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tlLogin事务</param>
        /// <returns>返回 tlLoginEntity实体类 ID为0则无记录</returns>
        public static tlLoginEntity tlLoginDisp(Int32 ID,DbTransaction tran)
        {
            tlLoginEntity fam = new tlLoginEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tlLogin","ID",ID);
            int RecordCount = 0;
            List<tlLoginEntity> lst = tlLoginList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tlLoginEntity实体类的List对象 (登录日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tlLoginEntity实体类的List对象(登录日志)</returns>
        public static List<tlLoginEntity> tlLoginList(QueryParam qp, out int RecordCount)
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
        public static List<tlLoginEntity> tlLoginList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tlLogin";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tlLoginList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tlLoginList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tlOperate(操作日志) - Method"

        /// <summary>
        /// 新增/删除/修改 tlOperateEntity (操作日志)
        /// </summary>
        /// <param name="fam">tlOperateEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tlOperateInsertUpdateDelete(tlOperateEntity fam)
        {
            return DataProvider.Instance().tlOperateInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tlOperateEntity (操作日志)
        /// </summary>
        /// <param name="fam">tlOperateEntity实体类</param>
        /// <param name="tran">tlOperate事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tlOperateInsertUpdateDelete(tlOperateEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tlOperateInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tlOperateEntity实体类 单笔资料 (操作日志)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tlOperateEntity实体类 ID为0则无记录</returns>
        public static tlOperateEntity tlOperateDisp(Int32 ID)
        {
            tlOperateEntity fam = new tlOperateEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tlOperate","ID",ID);
            int RecordCount = 0;
            List<tlOperateEntity> lst = tlOperateList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tlOperateEntity实体类 单笔资料 (操作日志)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tlOperate事务</param>
        /// <returns>返回 tlOperateEntity实体类 ID为0则无记录</returns>
        public static tlOperateEntity tlOperateDisp(Int32 ID,DbTransaction tran)
        {
            tlOperateEntity fam = new tlOperateEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tlOperate","ID",ID);
            int RecordCount = 0;
            List<tlOperateEntity> lst = tlOperateList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tlOperateEntity实体类的List对象 (操作日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tlOperateEntity实体类的List对象(操作日志)</returns>
        public static List<tlOperateEntity> tlOperateList(QueryParam qp, out int RecordCount)
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
        public static List<tlOperateEntity> tlOperateList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tlOperate";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tlOperateList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tlOperateList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsBank(银行账户) - Method"

        /// <summary>
        /// 新增/删除/修改 tsBankEntity (银行账户)
        /// </summary>
        /// <param name="fam">tsBankEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsBankInsertUpdateDelete(tsBankEntity fam)
        {
            return DataProvider.Instance().tsBankInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsBankEntity (银行账户)
        /// </summary>
        /// <param name="fam">tsBankEntity实体类</param>
        /// <param name="tran">tsBank事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsBankInsertUpdateDelete(tsBankEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsBankInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsBankEntity实体类 单笔资料 (银行账户)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsBankEntity实体类 ID为0则无记录</returns>
        public static tsBankEntity tsBankDisp(Int32 ID)
        {
            tsBankEntity fam = new tsBankEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsBank","ID",ID);
            int RecordCount = 0;
            List<tsBankEntity> lst = tsBankList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsBankEntity实体类 单笔资料 (银行账户)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsBank事务</param>
        /// <returns>返回 tsBankEntity实体类 ID为0则无记录</returns>
        public static tsBankEntity tsBankDisp(Int32 ID,DbTransaction tran)
        {
            tsBankEntity fam = new tsBankEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsBank","ID",ID);
            int RecordCount = 0;
            List<tsBankEntity> lst = tsBankList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsBankEntity实体类的List对象 (银行账户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsBankEntity实体类的List对象(银行账户)</returns>
        public static List<tsBankEntity> tsBankList(QueryParam qp, out int RecordCount)
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
        public static List<tsBankEntity> tsBankList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsBank";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsBankList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsBankList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsBlack(黑名单) - Method"

        /// <summary>
        /// 新增/删除/修改 tsBlackEntity (黑名单)
        /// </summary>
        /// <param name="fam">tsBlackEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsBlackInsertUpdateDelete(tsBlackEntity fam)
        {
            return DataProvider.Instance().tsBlackInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsBlackEntity (黑名单)
        /// </summary>
        /// <param name="fam">tsBlackEntity实体类</param>
        /// <param name="tran">tsBlack事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsBlackInsertUpdateDelete(tsBlackEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsBlackInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsBlackEntity实体类 单笔资料 (黑名单)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsBlackEntity实体类 ID为0则无记录</returns>
        public static tsBlackEntity tsBlackDisp(Int32 ID)
        {
            tsBlackEntity fam = new tsBlackEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsBlack","ID",ID);
            int RecordCount = 0;
            List<tsBlackEntity> lst = tsBlackList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsBlackEntity实体类 单笔资料 (黑名单)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsBlack事务</param>
        /// <returns>返回 tsBlackEntity实体类 ID为0则无记录</returns>
        public static tsBlackEntity tsBlackDisp(Int32 ID,DbTransaction tran)
        {
            tsBlackEntity fam = new tsBlackEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsBlack","ID",ID);
            int RecordCount = 0;
            List<tsBlackEntity> lst = tsBlackList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsBlackEntity实体类的List对象 (黑名单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsBlackEntity实体类的List对象(黑名单)</returns>
        public static List<tsBlackEntity> tsBlackList(QueryParam qp, out int RecordCount)
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
        public static List<tsBlackEntity> tsBlackList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsBlack";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsBlackList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsBlackList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsCategory(商品分类) - Method"

        /// <summary>
        /// 新增/删除/修改 tsCategoryEntity (商品分类)
        /// </summary>
        /// <param name="fam">tsCategoryEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsCategoryInsertUpdateDelete(tsCategoryEntity fam)
        {
            return DataProvider.Instance().tsCategoryInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsCategoryEntity (商品分类)
        /// </summary>
        /// <param name="fam">tsCategoryEntity实体类</param>
        /// <param name="tran">tsCategory事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsCategoryInsertUpdateDelete(tsCategoryEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsCategoryInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsCategoryEntity实体类 单笔资料 (商品分类)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsCategoryEntity实体类 ID为0则无记录</returns>
        public static tsCategoryEntity tsCategoryDisp(Int32 ID)
        {
            tsCategoryEntity fam = new tsCategoryEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsCategory","ID",ID);
            int RecordCount = 0;
            List<tsCategoryEntity> lst = tsCategoryList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsCategoryEntity实体类 单笔资料 (商品分类)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsCategory事务</param>
        /// <returns>返回 tsCategoryEntity实体类 ID为0则无记录</returns>
        public static tsCategoryEntity tsCategoryDisp(Int32 ID,DbTransaction tran)
        {
            tsCategoryEntity fam = new tsCategoryEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsCategory","ID",ID);
            int RecordCount = 0;
            List<tsCategoryEntity> lst = tsCategoryList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsCategoryEntity实体类的List对象 (商品分类)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsCategoryEntity实体类的List对象(商品分类)</returns>
        public static List<tsCategoryEntity> tsCategoryList(QueryParam qp, out int RecordCount)
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
        public static List<tsCategoryEntity> tsCategoryList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsCategory";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsCategoryList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsCategoryList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsCompany(厂商) - Method"

        /// <summary>
        /// 新增/删除/修改 tsCompanyEntity (厂商)
        /// </summary>
        /// <param name="fam">tsCompanyEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsCompanyInsertUpdateDelete(tsCompanyEntity fam)
        {
            return DataProvider.Instance().tsCompanyInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsCompanyEntity (厂商)
        /// </summary>
        /// <param name="fam">tsCompanyEntity实体类</param>
        /// <param name="tran">tsCompany事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsCompanyInsertUpdateDelete(tsCompanyEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsCompanyInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsCompanyEntity实体类 单笔资料 (厂商)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsCompanyEntity实体类 ID为0则无记录</returns>
        public static tsCompanyEntity tsCompanyDisp(Int32 ID)
        {
            tsCompanyEntity fam = new tsCompanyEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsCompany","ID",ID);
            int RecordCount = 0;
            List<tsCompanyEntity> lst = tsCompanyList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsCompanyEntity实体类 单笔资料 (厂商)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsCompany事务</param>
        /// <returns>返回 tsCompanyEntity实体类 ID为0则无记录</returns>
        public static tsCompanyEntity tsCompanyDisp(Int32 ID,DbTransaction tran)
        {
            tsCompanyEntity fam = new tsCompanyEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsCompany","ID",ID);
            int RecordCount = 0;
            List<tsCompanyEntity> lst = tsCompanyList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsCompanyEntity实体类的List对象 (厂商)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsCompanyEntity实体类的List对象(厂商)</returns>
        public static List<tsCompanyEntity> tsCompanyList(QueryParam qp, out int RecordCount)
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
        public static List<tsCompanyEntity> tsCompanyList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsCompany";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsCompanyList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsCompanyList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsCreditEval(信用评价) - Method"

        /// <summary>
        /// 新增/删除/修改 tsCreditEvalEntity (信用评价)
        /// </summary>
        /// <param name="fam">tsCreditEvalEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsCreditEvalInsertUpdateDelete(tsCreditEvalEntity fam)
        {
            return DataProvider.Instance().tsCreditEvalInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsCreditEvalEntity (信用评价)
        /// </summary>
        /// <param name="fam">tsCreditEvalEntity实体类</param>
        /// <param name="tran">tsCreditEval事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsCreditEvalInsertUpdateDelete(tsCreditEvalEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsCreditEvalInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsCreditEvalEntity实体类 单笔资料 (信用评价)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsCreditEvalEntity实体类 ID为0则无记录</returns>
        public static tsCreditEvalEntity tsCreditEvalDisp(Int32 ID)
        {
            tsCreditEvalEntity fam = new tsCreditEvalEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsCreditEval","ID",ID);
            int RecordCount = 0;
            List<tsCreditEvalEntity> lst = tsCreditEvalList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsCreditEvalEntity实体类 单笔资料 (信用评价)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsCreditEval事务</param>
        /// <returns>返回 tsCreditEvalEntity实体类 ID为0则无记录</returns>
        public static tsCreditEvalEntity tsCreditEvalDisp(Int32 ID,DbTransaction tran)
        {
            tsCreditEvalEntity fam = new tsCreditEvalEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsCreditEval","ID",ID);
            int RecordCount = 0;
            List<tsCreditEvalEntity> lst = tsCreditEvalList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsCreditEvalEntity实体类的List对象 (信用评价)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsCreditEvalEntity实体类的List对象(信用评价)</returns>
        public static List<tsCreditEvalEntity> tsCreditEvalList(QueryParam qp, out int RecordCount)
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
        public static List<tsCreditEvalEntity> tsCreditEvalList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsCreditEval";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsCreditEvalList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsCreditEvalList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsDict(数据字典) - Method"

        /// <summary>
        /// 新增/删除/修改 tsDictEntity (数据字典)
        /// </summary>
        /// <param name="fam">tsDictEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsDictInsertUpdateDelete(tsDictEntity fam)
        {
            return DataProvider.Instance().tsDictInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsDictEntity (数据字典)
        /// </summary>
        /// <param name="fam">tsDictEntity实体类</param>
        /// <param name="tran">tsDict事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsDictInsertUpdateDelete(tsDictEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsDictInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsDictEntity实体类 单笔资料 (数据字典)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsDictEntity实体类 ID为0则无记录</returns>
        public static tsDictEntity tsDictDisp(Int32 ID)
        {
            tsDictEntity fam = new tsDictEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsDict","ID",ID);
            int RecordCount = 0;
            List<tsDictEntity> lst = tsDictList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsDictEntity实体类 单笔资料 (数据字典)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsDict事务</param>
        /// <returns>返回 tsDictEntity实体类 ID为0则无记录</returns>
        public static tsDictEntity tsDictDisp(Int32 ID,DbTransaction tran)
        {
            tsDictEntity fam = new tsDictEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsDict","ID",ID);
            int RecordCount = 0;
            List<tsDictEntity> lst = tsDictList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsDictEntity实体类的List对象 (数据字典)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsDictEntity实体类的List对象(数据字典)</returns>
        public static List<tsDictEntity> tsDictList(QueryParam qp, out int RecordCount)
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
        public static List<tsDictEntity> tsDictList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsDict";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsDictList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsDictList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsFaction(阵营) - Method"

        /// <summary>
        /// 新增/删除/修改 tsFactionEntity (阵营)
        /// </summary>
        /// <param name="fam">tsFactionEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsFactionInsertUpdateDelete(tsFactionEntity fam)
        {
            return DataProvider.Instance().tsFactionInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsFactionEntity (阵营)
        /// </summary>
        /// <param name="fam">tsFactionEntity实体类</param>
        /// <param name="tran">tsFaction事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsFactionInsertUpdateDelete(tsFactionEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsFactionInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsFactionEntity实体类 单笔资料 (阵营)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsFactionEntity实体类 ID为0则无记录</returns>
        public static tsFactionEntity tsFactionDisp(Int32 ID)
        {
            tsFactionEntity fam = new tsFactionEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsFaction","ID",ID);
            int RecordCount = 0;
            List<tsFactionEntity> lst = tsFactionList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsFactionEntity实体类 单笔资料 (阵营)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsFaction事务</param>
        /// <returns>返回 tsFactionEntity实体类 ID为0则无记录</returns>
        public static tsFactionEntity tsFactionDisp(Int32 ID,DbTransaction tran)
        {
            tsFactionEntity fam = new tsFactionEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsFaction","ID",ID);
            int RecordCount = 0;
            List<tsFactionEntity> lst = tsFactionList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsFactionEntity实体类的List对象 (阵营)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsFactionEntity实体类的List对象(阵营)</returns>
        public static List<tsFactionEntity> tsFactionList(QueryParam qp, out int RecordCount)
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
        public static List<tsFactionEntity> tsFactionList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsFaction";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsFactionList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsFactionList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsGame(游戏) - Method"

        /// <summary>
        /// 新增/删除/修改 tsGameEntity (游戏)
        /// </summary>
        /// <param name="fam">tsGameEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsGameInsertUpdateDelete(tsGameEntity fam)
        {
            return DataProvider.Instance().tsGameInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsGameEntity (游戏)
        /// </summary>
        /// <param name="fam">tsGameEntity实体类</param>
        /// <param name="tran">tsGame事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsGameInsertUpdateDelete(tsGameEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsGameInsertUpdateDelete(fam,tran);
        }


        public static Int32 tsActivityInsertUpdateDelete(tsActivityEntity fam)
        {
            return DataProvider.Instance().tsActivityInsertUpdateDelete(fam);
        }

        public static Int32 tsActivityInsertUpdateDelete(tsActivityEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tsActivityInsertUpdateDelete(fam);
        }

        public static Int32 tsModuleInsertUpdateDelete(tsModuleEntity fam)
        {
            return DataProvider.Instance().tsModuleInsertUpdateDelete(fam);
        }
        
        
        /// <summary>
        /// 根据ID返回 tsGameEntity实体类 单笔资料 (游戏)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsGameEntity实体类 ID为0则无记录</returns>
        public static tsGameEntity tsGameDisp(Int32 ID)
        {
            tsGameEntity fam = new tsGameEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "act_Game", "ID", ID);
            int RecordCount = 0;
            List<tsGameEntity> lst = tsGameList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static tsActivityEntity tsActivityDisp(Int32 ID, Int32 ModuleID)
        {
            tsActivityEntity fam = new tsActivityEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2} and {0}.{3}={4}", "vw_Activity", "ID", ID, "ModuleID", ModuleID);
            int RecordCount = 0;
            List<tsActivityEntity> lst = tsActivityList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        public static tsModuleEntity tsModuleDisp(Int32 ID)
        {
            tsModuleEntity fam = new tsModuleEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "act_module", "ID", ID);
            int RecordCount = 0;
            List<tsModuleEntity> lst = tsModuleList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsGameEntity实体类 单笔资料 (游戏)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsGame事务</param>
        /// <returns>返回 tsGameEntity实体类 ID为0则无记录</returns>
        public static tsGameEntity tsGameDisp(Int32 ID,DbTransaction tran)
        {
            tsGameEntity fam = new tsGameEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsGame","ID",ID);
            int RecordCount = 0;
            List<tsGameEntity> lst = tsGameList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsGameEntity实体类的List对象 (游戏)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsGameEntity实体类的List对象(游戏)</returns>
        public static List<tsGameEntity> tsGameList(QueryParam qp, out int RecordCount)
        {
            return tsGameList(qp, out RecordCount,null);
        }

        /// <summary>
        /// 返回活动tsActivityEntity实体类的list对象
        /// </summary>
        /// <param name="qp"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public static List<tsActivityEntity> tsActivityList(QueryParam qp, out int RecordCount)
        {
            return tsActivityList(qp, out RecordCount, null);
        }

        public static List<tsModuleEntity> tsModuleList(QueryParam qp, out int RecordCount)
        {
            return tsModuleList(qp, out RecordCount, null);
        }

        public static DataTable tbDuihuanList(QueryParam qp, out int RecordCount)
        {
            return DataProvider.Instance().tbDuihuanList(qp, out RecordCount);
        }

        public static DataTable tbGiveList(QueryParam qp, out int RecordCount)
        {
            return DataProvider.Instance().tbGiveList(qp, out RecordCount);
        }
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qp"></param>
        /// <param name="RecordCount"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public static List<tsActivityEntity> tsActivityList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "vw_Activity";
            if (qp.Where != null)
            {
                qp.Where += " and 1 = 1";
            }
            else
            {
                qp.Where = " where 1 = 1 ";
            }
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tsActivityList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsActivityList(qp, out RecordCount, tran);
            }
        }

        public static List<tsModuleEntity> tsModuleList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "act_module";
            if (qp.Where != null)
            {
                qp.Where += " and 1 = 1";
            }
            else
            {
                qp.Where = " where 1 = 1 ";
            }
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tsModuleList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsModuleList(qp, out RecordCount, tran);
            }
        }

        /// <summary>
        /// 返回tsGameEntity实体类的List对象 (游戏)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsGame事务</param>        
        /// <returns>tsGameEntity实体类的List对象(游戏)</returns>
        public static List<tsGameEntity> tsGameList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "act_Game";
            if (qp.Where != null)
            {
                qp.Where += " and act_Game.IsOnline = 1";
            }
            else
            {
                qp.Where = " where act_Game.IsOnline = 1 ";
            }
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsGameList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsGameList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsGroup(用户分组) - Method"

        /// <summary>
        /// 新增/删除/修改 tsGroupEntity (用户分组)
        /// </summary>
        /// <param name="fam">tsGroupEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsGroupInsertUpdateDelete(tsGroupEntity fam)
        {
            return DataProvider.Instance().tsGroupInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsGroupEntity (用户分组)
        /// </summary>
        /// <param name="fam">tsGroupEntity实体类</param>
        /// <param name="tran">tsGroup事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsGroupInsertUpdateDelete(tsGroupEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsGroupInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsGroupEntity实体类 单笔资料 (用户分组)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsGroupEntity实体类 ID为0则无记录</returns>
        public static tsGroupEntity tsGroupDisp(Int32 ID)
        {
            tsGroupEntity fam = new tsGroupEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsGroup","ID",ID);
            int RecordCount = 0;
            List<tsGroupEntity> lst = tsGroupList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsGroupEntity实体类 单笔资料 (用户分组)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsGroup事务</param>
        /// <returns>返回 tsGroupEntity实体类 ID为0则无记录</returns>
        public static tsGroupEntity tsGroupDisp(Int32 ID,DbTransaction tran)
        {
            tsGroupEntity fam = new tsGroupEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsGroup","ID",ID);
            int RecordCount = 0;
            List<tsGroupEntity> lst = tsGroupList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsGroupEntity实体类的List对象 (用户分组)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsGroupEntity实体类的List对象(用户分组)</returns>
        public static List<tsGroupEntity> tsGroupList(QueryParam qp, out int RecordCount)
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
        public static List<tsGroupEntity> tsGroupList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsGroup";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsGroupList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsGroupList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsMember(用户成员) - Method"

        /// <summary>
        /// 新增/删除/修改 tsMemberEntity (用户成员)
        /// </summary>
        /// <param name="fam">tsMemberEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsMemberInsertUpdateDelete(tsMemberEntity fam)
        {
            return DataProvider.Instance().tsMemberInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsMemberEntity (用户成员)
        /// </summary>
        /// <param name="fam">tsMemberEntity实体类</param>
        /// <param name="tran">tsMember事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsMemberInsertUpdateDelete(tsMemberEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsMemberInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsMemberEntity实体类 单笔资料 (用户成员)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsMemberEntity实体类 ID为0则无记录</returns>
        public static tsMemberEntity tsMemberDisp(Int32 ID)
        {
            tsMemberEntity fam = new tsMemberEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsMember","ID",ID);
            int RecordCount = 0;
            List<tsMemberEntity> lst = tsMemberList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsMemberEntity实体类 单笔资料 (用户成员)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsMember事务</param>
        /// <returns>返回 tsMemberEntity实体类 ID为0则无记录</returns>
        public static tsMemberEntity tsMemberDisp(Int32 ID,DbTransaction tran)
        {
            tsMemberEntity fam = new tsMemberEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsMember","ID",ID);
            int RecordCount = 0;
            List<tsMemberEntity> lst = tsMemberList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsMemberEntity实体类的List对象 (用户成员)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsMemberEntity实体类的List对象(用户成员)</returns>
        public static List<tsMemberEntity> tsMemberList(QueryParam qp, out int RecordCount)
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
        public static List<tsMemberEntity> tsMemberList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsMember";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsMemberList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsMemberList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsMoney(余额) - Method"

        /// <summary>
        /// 新增/删除/修改 tsMoneyEntity (余额)
        /// </summary>
        /// <param name="fam">tsMoneyEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsMoneyInsertUpdateDelete(tsMoneyEntity fam)
        {
            return DataProvider.Instance().tsMoneyInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsMoneyEntity (余额)
        /// </summary>
        /// <param name="fam">tsMoneyEntity实体类</param>
        /// <param name="tran">tsMoney事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsMoneyInsertUpdateDelete(tsMoneyEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsMoneyInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsMoneyEntity实体类 单笔资料 (余额)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsMoneyEntity实体类 ID为0则无记录</returns>
        public static tsMoneyEntity tsMoneyDisp(Int32 ID)
        {
            tsMoneyEntity fam = new tsMoneyEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsMoney","ID",ID);
            int RecordCount = 0;
            List<tsMoneyEntity> lst = tsMoneyList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsMoneyEntity实体类 单笔资料 (余额)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsMoney事务</param>
        /// <returns>返回 tsMoneyEntity实体类 ID为0则无记录</returns>
        public static tsMoneyEntity tsMoneyDisp(Int32 ID,DbTransaction tran)
        {
            tsMoneyEntity fam = new tsMoneyEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsMoney","ID",ID);
            int RecordCount = 0;
            List<tsMoneyEntity> lst = tsMoneyList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsMoneyEntity实体类的List对象 (余额)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsMoneyEntity实体类的List对象(余额)</returns>
        public static List<tsMoneyEntity> tsMoneyList(QueryParam qp, out int RecordCount)
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
        public static List<tsMoneyEntity> tsMoneyList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsMoney";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsMoneyList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsMoneyList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsRightLock(权限锁定) - Method"

        /// <summary>
        /// 新增/删除/修改 tsRightLockEntity (权限锁定)
        /// </summary>
        /// <param name="fam">tsRightLockEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsRightLockInsertUpdateDelete(tsRightLockEntity fam)
        {
            return DataProvider.Instance().tsRightLockInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsRightLockEntity (权限锁定)
        /// </summary>
        /// <param name="fam">tsRightLockEntity实体类</param>
        /// <param name="tran">tsRightLock事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsRightLockInsertUpdateDelete(tsRightLockEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsRightLockInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsRightLockEntity实体类 单笔资料 (权限锁定)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsRightLockEntity实体类 ID为0则无记录</returns>
        public static tsRightLockEntity tsRightLockDisp(Int32 ID)
        {
            tsRightLockEntity fam = new tsRightLockEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsRightLock","ID",ID);
            int RecordCount = 0;
            List<tsRightLockEntity> lst = tsRightLockList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsRightLockEntity实体类 单笔资料 (权限锁定)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsRightLock事务</param>
        /// <returns>返回 tsRightLockEntity实体类 ID为0则无记录</returns>
        public static tsRightLockEntity tsRightLockDisp(Int32 ID,DbTransaction tran)
        {
            tsRightLockEntity fam = new tsRightLockEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsRightLock","ID",ID);
            int RecordCount = 0;
            List<tsRightLockEntity> lst = tsRightLockList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsRightLockEntity实体类的List对象 (权限锁定)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsRightLockEntity实体类的List对象(权限锁定)</returns>
        public static List<tsRightLockEntity> tsRightLockList(QueryParam qp, out int RecordCount)
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
        public static List<tsRightLockEntity> tsRightLockList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsRightLock";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsRightLockList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsRightLockList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsSerialNo(流水号) - Method"

        /// <summary>
        /// 新增/删除/修改 tsSerialNoEntity (流水号)
        /// </summary>
        /// <param name="fam">tsSerialNoEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsSerialNoInsertUpdateDelete(tsSerialNoEntity fam)
        {
            return DataProvider.Instance().tsSerialNoInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsSerialNoEntity (流水号)
        /// </summary>
        /// <param name="fam">tsSerialNoEntity实体类</param>
        /// <param name="tran">tsSerialNo事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsSerialNoInsertUpdateDelete(tsSerialNoEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsSerialNoInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsSerialNoEntity实体类 单笔资料 (流水号)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsSerialNoEntity实体类 ID为0则无记录</returns>
        public static tsSerialNoEntity tsSerialNoDisp(Int32 ID)
        {
            tsSerialNoEntity fam = new tsSerialNoEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsSerialNo","ID",ID);
            int RecordCount = 0;
            List<tsSerialNoEntity> lst = tsSerialNoList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsSerialNoEntity实体类 单笔资料 (流水号)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsSerialNo事务</param>
        /// <returns>返回 tsSerialNoEntity实体类 ID为0则无记录</returns>
        public static tsSerialNoEntity tsSerialNoDisp(Int32 ID,DbTransaction tran)
        {
            tsSerialNoEntity fam = new tsSerialNoEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsSerialNo","ID",ID);
            int RecordCount = 0;
            List<tsSerialNoEntity> lst = tsSerialNoList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsSerialNoEntity实体类的List对象 (流水号)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsSerialNoEntity实体类的List对象(流水号)</returns>
        public static List<tsSerialNoEntity> tsSerialNoList(QueryParam qp, out int RecordCount)
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
        public static List<tsSerialNoEntity> tsSerialNoList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsSerialNo";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsSerialNoList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsSerialNoList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsServer(服务器) - Method"

        /// <summary>
        /// 新增/删除/修改 tsServerEntity (服务器)
        /// </summary>
        /// <param name="fam">tsServerEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsServerInsertUpdateDelete(tsServerEntity fam)
        {
            return DataProvider.Instance().tsServerInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsServerEntity (服务器)
        /// </summary>
        /// <param name="fam">tsServerEntity实体类</param>
        /// <param name="tran">tsServer事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsServerInsertUpdateDelete(tsServerEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsServerInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsServerEntity实体类 单笔资料 (服务器)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsServerEntity实体类 ID为0则无记录</returns>
        public static tsServerEntity tsServerDisp(Int32 ID)
        {
            tsServerEntity fam = new tsServerEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "act_Server", "ID", ID);
            int RecordCount = 0;
            List<tsServerEntity> lst = tsServerList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsServerEntity实体类 单笔资料 (服务器)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsServer事务</param>
        /// <returns>返回 tsServerEntity实体类 ID为0则无记录</returns>
        public static tsServerEntity tsServerDisp(Int32 ID,DbTransaction tran)
        {
            tsServerEntity fam = new tsServerEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsServer","ID",ID);
            int RecordCount = 0;
            List<tsServerEntity> lst = tsServerList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsServerEntity实体类的List对象 (服务器)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsServerEntity实体类的List对象(服务器)</returns>
        public static List<tsServerEntity> tsServerList(QueryParam qp, out int RecordCount)
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
        public static List<tsServerEntity> tsServerList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "act_Server";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsServerList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsServerList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsSMSPlat(短信平台) - Method"

        /// <summary>
        /// 新增/删除/修改 tsSMSPlatEntity (短信平台)
        /// </summary>
        /// <param name="fam">tsSMSPlatEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsSMSPlatInsertUpdateDelete(tsSMSPlatEntity fam)
        {
            return DataProvider.Instance().tsSMSPlatInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsSMSPlatEntity (短信平台)
        /// </summary>
        /// <param name="fam">tsSMSPlatEntity实体类</param>
        /// <param name="tran">tsSMSPlat事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsSMSPlatInsertUpdateDelete(tsSMSPlatEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsSMSPlatInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsSMSPlatEntity实体类 单笔资料 (短信平台)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsSMSPlatEntity实体类 ID为0则无记录</returns>
        public static tsSMSPlatEntity tsSMSPlatDisp(Int32 ID)
        {
            tsSMSPlatEntity fam = new tsSMSPlatEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsSMSPlat","ID",ID);
            int RecordCount = 0;
            List<tsSMSPlatEntity> lst = tsSMSPlatList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsSMSPlatEntity实体类 单笔资料 (短信平台)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsSMSPlat事务</param>
        /// <returns>返回 tsSMSPlatEntity实体类 ID为0则无记录</returns>
        public static tsSMSPlatEntity tsSMSPlatDisp(Int32 ID,DbTransaction tran)
        {
            tsSMSPlatEntity fam = new tsSMSPlatEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsSMSPlat","ID",ID);
            int RecordCount = 0;
            List<tsSMSPlatEntity> lst = tsSMSPlatList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsSMSPlatEntity实体类的List对象 (短信平台)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsSMSPlatEntity实体类的List对象(短信平台)</returns>
        public static List<tsSMSPlatEntity> tsSMSPlatList(QueryParam qp, out int RecordCount)
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
        public static List<tsSMSPlatEntity> tsSMSPlatList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsSMSPlat";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsSMSPlatList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsSMSPlatList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsSubUser(子用户) - Method"

        /// <summary>
        /// 新增/删除/修改 tsSubUserEntity (子用户)
        /// </summary>
        /// <param name="fam">tsSubUserEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsSubUserInsertUpdateDelete(tsSubUserEntity fam)
        {
            return DataProvider.Instance().tsSubUserInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsSubUserEntity (子用户)
        /// </summary>
        /// <param name="fam">tsSubUserEntity实体类</param>
        /// <param name="tran">tsSubUser事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsSubUserInsertUpdateDelete(tsSubUserEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsSubUserInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsSubUserEntity实体类 单笔资料 (子用户)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsSubUserEntity实体类 ID为0则无记录</returns>
        public static tsSubUserEntity tsSubUserDisp(Int32 ID)
        {
            tsSubUserEntity fam = new tsSubUserEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsSubUser","ID",ID);
            int RecordCount = 0;
            List<tsSubUserEntity> lst = tsSubUserList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsSubUserEntity实体类 单笔资料 (子用户)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsSubUser事务</param>
        /// <returns>返回 tsSubUserEntity实体类 ID为0则无记录</returns>
        public static tsSubUserEntity tsSubUserDisp(Int32 ID,DbTransaction tran)
        {
            tsSubUserEntity fam = new tsSubUserEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsSubUser","ID",ID);
            int RecordCount = 0;
            List<tsSubUserEntity> lst = tsSubUserList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsSubUserEntity实体类的List对象 (子用户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsSubUserEntity实体类的List对象(子用户)</returns>
        public static List<tsSubUserEntity> tsSubUserList(QueryParam qp, out int RecordCount)
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
        public static List<tsSubUserEntity> tsSubUserList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsSubUser";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsSubUserList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsSubUserList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsSysParam(系统参数) - Method"

        /// <summary>
        /// 新增/删除/修改 tsSysParamEntity (系统参数)
        /// </summary>
        /// <param name="fam">tsSysParamEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsSysParamInsertUpdateDelete(tsSysParamEntity fam)
        {
            return DataProvider.Instance().tsSysParamInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsSysParamEntity (系统参数)
        /// </summary>
        /// <param name="fam">tsSysParamEntity实体类</param>
        /// <param name="tran">tsSysParam事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsSysParamInsertUpdateDelete(tsSysParamEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsSysParamInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsSysParamEntity实体类 单笔资料 (系统参数)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsSysParamEntity实体类 ID为0则无记录</returns>
        public static tsSysParamEntity tsSysParamDisp(Int32 ID)
        {
            tsSysParamEntity fam = new tsSysParamEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsSysParam","ID",ID);
            int RecordCount = 0;
            List<tsSysParamEntity> lst = tsSysParamList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsSysParamEntity实体类 单笔资料 (系统参数)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsSysParam事务</param>
        /// <returns>返回 tsSysParamEntity实体类 ID为0则无记录</returns>
        public static tsSysParamEntity tsSysParamDisp(Int32 ID,DbTransaction tran)
        {
            tsSysParamEntity fam = new tsSysParamEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsSysParam","ID",ID);
            int RecordCount = 0;
            List<tsSysParamEntity> lst = tsSysParamList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsSysParamEntity实体类的List对象 (系统参数)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsSysParamEntity实体类的List对象(系统参数)</returns>
        public static List<tsSysParamEntity> tsSysParamList(QueryParam qp, out int RecordCount)
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
        public static List<tsSysParamEntity> tsSysParamList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsSysParam";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsSysParamList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsSysParamList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsUser(用户) - Method"

        /// <summary>
        /// 新增/删除/修改 tsUserEntity (用户)
        /// </summary>
        /// <param name="fam">tsUserEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsUserInsertUpdateDelete(tsUserEntity fam)
        {
            return DataProvider.Instance().tsUserInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsUserEntity (用户)
        /// </summary>
        /// <param name="fam">tsUserEntity实体类</param>
        /// <param name="tran">tsUser事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsUserInsertUpdateDelete(tsUserEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsUserInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsUserEntity实体类 单笔资料 (用户)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsUserEntity实体类 ID为0则无记录</returns>
        public static tsUserEntity tsUserDisp(Int32 ID)
        {
            tsUserEntity fam = new tsUserEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "act_User", "ID", ID);
            int RecordCount = 0;
            List<tsUserEntity> lst = tsUserList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsUserEntity实体类 单笔资料 (用户)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsUser事务</param>
        /// <returns>返回 tsUserEntity实体类 ID为0则无记录</returns>
        public static tsUserEntity tsUserDisp(Int32 ID,DbTransaction tran)
        {
            tsUserEntity fam = new tsUserEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsUser","ID",ID);
            int RecordCount = 0;
            List<tsUserEntity> lst = tsUserList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsUserEntity实体类的List对象 (用户)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsUserEntity实体类的List对象(用户)</returns>
        public static List<tsUserEntity> tsUserList(QueryParam qp, out int RecordCount)
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
        public static List<tsUserEntity> tsUserList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "act_User";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsUserList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsUserList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsUserToken(授权令牌) - Method"

        /// <summary>
        /// 新增/删除/修改 tsUserTokenEntity (授权令牌)
        /// </summary>
        /// <param name="fam">tsUserTokenEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsUserTokenInsertUpdateDelete(tsUserTokenEntity fam)
        {
            return DataProvider.Instance().tsUserTokenInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsUserTokenEntity (授权令牌)
        /// </summary>
        /// <param name="fam">tsUserTokenEntity实体类</param>
        /// <param name="tran">tsUserToken事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsUserTokenInsertUpdateDelete(tsUserTokenEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsUserTokenInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsUserTokenEntity实体类 单笔资料 (授权令牌)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsUserTokenEntity实体类 ID为0则无记录</returns>
        public static tsUserTokenEntity tsUserTokenDisp(Int32 ID)
        {
            tsUserTokenEntity fam = new tsUserTokenEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsUserToken","ID",ID);
            int RecordCount = 0;
            List<tsUserTokenEntity> lst = tsUserTokenList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsUserTokenEntity实体类 单笔资料 (授权令牌)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsUserToken事务</param>
        /// <returns>返回 tsUserTokenEntity实体类 ID为0则无记录</returns>
        public static tsUserTokenEntity tsUserTokenDisp(Int32 ID,DbTransaction tran)
        {
            tsUserTokenEntity fam = new tsUserTokenEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsUserToken","ID",ID);
            int RecordCount = 0;
            List<tsUserTokenEntity> lst = tsUserTokenList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsUserTokenEntity实体类的List对象 (授权令牌)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsUserTokenEntity实体类的List对象(授权令牌)</returns>
        public static List<tsUserTokenEntity> tsUserTokenList(QueryParam qp, out int RecordCount)
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
        public static List<tsUserTokenEntity> tsUserTokenList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsUserToken";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsUserTokenList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsUserTokenList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsZone(大区) - Method"

        /// <summary>
        /// 新增/删除/修改 tsZoneEntity (大区)
        /// </summary>
        /// <param name="fam">tsZoneEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsZoneInsertUpdateDelete(tsZoneEntity fam)
        {
            return DataProvider.Instance().tsZoneInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsZoneEntity (大区)
        /// </summary>
        /// <param name="fam">tsZoneEntity实体类</param>
        /// <param name="tran">tsZone事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsZoneInsertUpdateDelete(tsZoneEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsZoneInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsZoneEntity实体类 单笔资料 (大区)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsZoneEntity实体类 ID为0则无记录</returns>
        public static tsZoneEntity tsZoneDisp(Int32 ID)
        {
            tsZoneEntity fam = new tsZoneEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "act_Zone", "ID", ID);
            int RecordCount = 0;
            List<tsZoneEntity> lst = tsZoneList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsZoneEntity实体类 单笔资料 (大区)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsZone事务</param>
        /// <returns>返回 tsZoneEntity实体类 ID为0则无记录</returns>
        public static tsZoneEntity tsZoneDisp(Int32 ID,DbTransaction tran)
        {
            tsZoneEntity fam = new tsZoneEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsZone","ID",ID);
            int RecordCount = 0;
            List<tsZoneEntity> lst = tsZoneList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsZoneEntity实体类的List对象 (大区)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsZoneEntity实体类的List对象(大区)</returns>
        public static List<tsZoneEntity> tsZoneList(QueryParam qp, out int RecordCount)
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
        public static List<tsZoneEntity> tsZoneList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "act_Zone";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsZoneList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsZoneList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tsZoneServer(区服汇总) - Method"

        /// <summary>
        /// 新增/删除/修改 tsZoneServerEntity (区服汇总)
        /// </summary>
        /// <param name="fam">tsZoneServerEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsZoneServerInsertUpdateDelete(tsZoneServerEntity fam)
        {
            return DataProvider.Instance().tsZoneServerInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tsZoneServerEntity (区服汇总)
        /// </summary>
        /// <param name="fam">tsZoneServerEntity实体类</param>
        /// <param name="tran">tsZoneServer事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tsZoneServerInsertUpdateDelete(tsZoneServerEntity fam,DbTransaction tran)
        {
            return DataProvider.Instance().tsZoneServerInsertUpdateDelete(fam,tran);
        }        
        
        /// <summary>
        /// 根据ID返回 tsZoneServerEntity实体类 单笔资料 (区服汇总)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsZoneServerEntity实体类 ID为0则无记录</returns>
        public static tsZoneServerEntity tsZoneServerDisp(Int32 ID)
        {
            tsZoneServerEntity fam = new tsZoneServerEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsZoneServer","ID",ID);
            int RecordCount = 0;
            List<tsZoneServerEntity> lst = tsZoneServerList(qp, out RecordCount,null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsZoneServerEntity实体类 单笔资料 (区服汇总)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsZoneServer事务</param>
        /// <returns>返回 tsZoneServerEntity实体类 ID为0则无记录</returns>
        public static tsZoneServerEntity tsZoneServerDisp(Int32 ID,DbTransaction tran)
        {
            tsZoneServerEntity fam = new tsZoneServerEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}","tsZoneServer","ID",ID);
            int RecordCount = 0;
            List<tsZoneServerEntity> lst = tsZoneServerList(qp, out RecordCount,tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsZoneServerEntity实体类的List对象 (区服汇总)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsZoneServerEntity实体类的List对象(区服汇总)</returns>
        public static List<tsZoneServerEntity> tsZoneServerList(QueryParam qp, out int RecordCount)
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
        public static List<tsZoneServerEntity> tsZoneServerList(QueryParam qp, out int RecordCount,DbTransaction tran)
        {
            qp.TableName = "tsZoneServer";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }
            
            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran==null)
            {
                return DataProvider.Instance().tsZoneServerList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tsZoneServerList(qp, out RecordCount,tran);            
            }
        }
        #endregion

        #region "tbMobileToken(验证码查询) - Method"
        public static DataSet GetTokenMobile(int PageIndex, int PageSize,string Where)
        {
            DataSet ds = DataProvider.Instance().GetMobileToken(PageIndex, PageSize ,Where);

            return ds;
        }
        #endregion

        #region "RightLockList(权限锁定查询) - Method"
        public static DataSet RightLockList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().RightLockList(PageIndex, PageSize, Where);

            return ds;
        }
        #endregion

        #region "tbRecharge(后台手动补充)"
        public static DataSet ManualReCharge(string UserID, float Bal, string SerialNo, string OPID, string Comment)
        {
            DataSet ds = DataProvider.Instance().ManualRechage(UserID, Bal, SerialNo, OPID,Comment);

            return ds;
        }
        #endregion

        #region "撤销单赔付查询"
        public static DataSet OrderCancel(string SerialNo)
        {
            DataSet ds = DataProvider.Instance().OrderCancel(SerialNo);

            return ds;
        }
        #endregion

        public static DataSet ArbitrationList(string SerialNo)
        {
            DataSet ds = DataProvider.Instance().ArbitrationList(SerialNo);

            return ds;
        }

        public static DataSet LevelOrderList(string SerialNo)
        {
            DataSet ds = DataProvider.Instance().LevelOrderList(SerialNo);

            return ds;
        }

        #region "更新IP"
        public static DataSet UpdateIP(string IP)
        {
            DataSet ds = DataProvider.Instance().UpdateIP(IP);

            return ds;
        }
        #endregion

        #region "客户提现汇款管理 提现处理 撤销提现"

        public static string WithdrawCancel(string SerialNo, string Comment, int OPID)
        {
            return DataProvider.Instance().WithdrawCancel(SerialNo, Comment,OPID);
        }
        #endregion

        #region "订单查询"
        public static DataSet OrderSelect(DateTime sDate, DateTime eDate, string Keyword, string SearchText, string Status, string CancelStatus, bool IsHisOrder, int PageIndex, int PageSize, string OrderType, string Game, string AppointUser, string isPub)
        {
            DataSet ds = DataProvider.Instance().OrderSelect(sDate, eDate, Keyword, SearchText, Status, CancelStatus, IsHisOrder, PageIndex, PageSize, OrderType,Game,AppointUser,isPub);

            return ds;
        }
        #endregion

        public static DataSet ActivityOrderSelect(int PageIndex, int PageSize, string ActivityID)
        {
            DataSet ds = DataProvider.Instance().ActivityOrderSelect(PageIndex, PageSize, ActivityID);

            return ds;
        }

        public static DataSet ActivityAllOrderSelect(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().ActivityAllOrderSelect(PageIndex, PageSize, Where);

            return ds;
        }

        public static DataSet ActivityOrderSelectDel(int PageIndex, int PageSize, string ActivityID)
        {
            DataSet ds = DataProvider.Instance().ActivityOrderSelectDel(PageIndex, PageSize, ActivityID);

            return ds;
        }

        public static DataSet OrderEvent(DateTime sDate, DateTime eDate,string search, string Keyword, int PageIndex, int PageSize)
        {
            DataSet ds = DataProvider.Instance().OrderEvent(sDate, eDate,search, Keyword, PageIndex, PageSize);

            return ds;
        }

        public static DataSet PhonePwdEvent(DateTime sDate, DateTime eDate,string type, string search, string Keyword, int PageIndex, int PageSize)
        {
            DataSet ds = DataProvider.Instance().PhonePwdEvent(sDate, eDate,type,search, Keyword, PageIndex, PageSize);

            return ds;
        }


        public static DataSet OrderGroup(DateTime sDate, DateTime eDate, string FirstCustomerID, string SearchType, int PageIndex, int PageSize)
        {
            DataSet ds = DataProvider.Instance().OrderGroup(sDate, eDate, FirstCustomerID, SearchType, PageIndex, PageSize);

            return ds;
        }

        

        #region "历史订单查询"
        public static DataSet OrderSelectHis(DateTime sDate, DateTime eDate, string Keyword, string SearchText, string Status, string CancelStatus, bool IsHisOrder, int PageIndex, int PageSize, string OrderType, string Game)
        {
            DataSet ds = DataProvider.Instance().OrderSelectHis(sDate, eDate, Keyword, SearchText, Status, CancelStatus, IsHisOrder, PageIndex, PageSize, OrderType, Game);

            return ds;
        }
        #endregion

        #region "删除订单查询"
        public static DataSet OrderSelectDel(DateTime sDate, DateTime eDate, string Keyword, string SearchText, string Status, string CancelStatus, bool IsHisOrder, int PageIndex, int PageSize, string OrderType, string SearchType,string Game)
        {
            DataSet ds = DataProvider.Instance().OrderSelectDel(sDate, eDate, Keyword, SearchText, Status, CancelStatus, IsHisOrder, PageIndex, PageSize, OrderType, SearchType,Game);

            return ds;
        }
        #endregion

        #region "记录首次打开订单详情"
        public static DataSet MarkFirstViewOrder(string SerialNo, int OPID)
        {
            DataSet ds = DataProvider.Instance().MarkFirstViewOrder(SerialNo, OPID);

            return ds;
        }
        #endregion

        #region "修改备注"
        public static DataSet UpdateComment(string SerialNo,string Comment)
        {
            DataSet ds = DataProvider.Instance().UpdateComment(SerialNo,Comment);

            return ds;
        }
        #endregion

        public static DataSet UpdateActivityOrderComment(string ActivityID, string Comment)
        {
            DataSet ds = DataProvider.Instance().UpdateActivityOrderComment(ActivityID, Comment);

            return ds;
        }

        public static DataSet AddActivityOrder(string ActivityID,string SerialNo)
        {
            DataSet ds = DataProvider.Instance().AddActivityOrder(ActivityID, SerialNo);

            return ds;
        }

        public static DataSet CheckActivityOrder(string ActivityID, string SerialNo)
        {
            DataSet ds = DataProvider.Instance().CheckActivityOrder(ActivityID, SerialNo);

            return ds;
        }

        

        public static DataSet IsActivityBlack(string SerialNo)
        {
            DataSet ds = DataProvider.Instance().IsActivityBlack(SerialNo);

            return ds;
        }


        public static DataSet GetLevelOrderActivityList(int PageIndex, int PageSize,string ActivityID)
        {
            DataSet ds = DataProvider.Instance().GetLevelOrderActivityList(PageIndex, PageSize, ActivityID);

            return ds;
        }

        public static DataSet ActivityOrderRela(int UserID, string ActivityID)
        {
            DataSet ds = DataProvider.Instance().ActivityOrderRela(UserID, ActivityID);

            return ds;
        }

        public static DataSet DeleteActivityOrder(int ActivityID)
        {
            DataSet ds = DataProvider.Instance().DeleteActivityOrder(ActivityID);

            return ds;
        }


        

        #region "修改重判分析备注"
        public static DataSet UpdateRejudgComment(string SerialNo, string Comment)
        {
            DataSet ds = DataProvider.Instance().UpdateRejudgComment(SerialNo, Comment);

            return ds;
        }
        #endregion

        #region "添加用户跟踪信息"
        public static DataSet AddUserTrackInfo(string UserID, string TrackInfo, int Score,int OPID,string SerialNo)
        {
            DataSet ds = DataProvider.Instance().AddUserTrackInfo(UserID, TrackInfo, Score,OPID,SerialNo);

            return ds;
        }
        #endregion

        public static void InsertServiceHelp(string ODSerialNo, int UserID, int AcceptUserID, string Content, int HelpType)
        {
            DataProvider.Instance().InsertServiceHelp(ODSerialNo, UserID, AcceptUserID, Content, HelpType);
        }


        public static void DeleteServiceHelp(string ODSerialNo)
        {
            DataProvider.Instance().DeleteServiceHelp(ODSerialNo);
        }

        public static void UpdateServiceHelp(string ODSerialNo,int IsDeal,string OPID)
        {
            DataProvider.Instance().UpdateServiceHelp(ODSerialNo, IsDeal, OPID);
        }

        public static void UpdatePostReport(string SerialNo, int Status, string OPID)
        {
            DataProvider.Instance().UpdatePostReport(SerialNo, Status, OPID);
        }

        public static void UpdateFeedBackMark(string id, int Remark)
        {
            DataProvider.Instance().UpdateFeedBackMark(id, Remark);
        }

        public static void FirstCheck(string id, int Remark)
        {
            DataProvider.Instance().FirstCheck(id, Remark);
        }

        

        public static DataSet PostReportCount(DateTime start, DateTime end)
        {
            DataSet ds = DataProvider.Instance().PostReportCount(start, end);
            return ds;
        }

        public static void UpdateRejudgColor(string ID, int IsDeal)
        {
            DataProvider.Instance().UpdateRejudgColor(ID, IsDeal);
        }

        public static void LevelOrderMarkColor(string ODSerialNo , string OPID)
        {
            DataProvider.Instance().LevelOrderMarkColor(ODSerialNo, OPID);
        }

        public static void AddLevelOrderReJudg(string SerialNo, string Reason,int OPID)
        {
            DataProvider.Instance().AddLevelOrderReJudg(SerialNo, Reason, OPID);
        }
        

        public static DataSet AddOrderJudg(string ODSerialNo)
        {
            DataSet ds = DataProvider.Instance().AddOrderJudg(ODSerialNo);
            return ds;
        }

        public static DataSet AddUserTrackInfoComment(string UserID, string TrackInfo, int Score, int OPID)
        {
            DataSet ds = DataProvider.Instance().AddUserTrackInfoComment(UserID, TrackInfo, Score, OPID);

            return ds;
        }

        public static DataSet AddUserAccountProved(string UserID, string Evidence, int IsDeal, int OPID)
        {
            DataSet ds = DataProvider.Instance().AddUserAccountProved(UserID, Evidence, IsDeal, OPID);

            return ds;
        }

        

        #region "查询用户跟踪信息"
        public static DataSet GetUserTrackInfo(string UserID, int PageIndex, int PageSize)
        {
            DataSet ds = DataProvider.Instance().GetUserTrackInfo(UserID, PageIndex, PageSize);

            return ds;
        }
        #endregion

        public static int DeleteUserTrack(string SerialNo)
        {
            int result = DataProvider.Instance().DeleteUserTrack(SerialNo);

            return result;
        }
        

        public static DataSet GetUserTrackInfoComment(string UserID, int PageIndex, int PageSize)
        {
            DataSet ds = DataProvider.Instance().GetUserTrackInfoComment(UserID, PageIndex, PageSize);

            return ds;
        }

        public static DataSet GetUserAccountProved(string UserID)
        {
            DataSet ds = DataProvider.Instance().GetUserAccountProved(UserID);

            return ds;
        }

        #region "单个订单查询[原始单]"
        public static DataSet GetOrder(string SerialNo, int IsHisOrder)
        {
            DataSet ds = DataProvider.Instance().GetOrder(SerialNo, IsHisOrder);

            return ds;
        }
        #endregion

        public static DataSet GetOrderHis(string SerialNo, int IsHisOrder)
        {
            DataSet ds = DataProvider.Instance().GetOrderHis(SerialNo, IsHisOrder);

            return ds;
        }


        #region "单个删除订单查询[原始单]"
        public static DataSet GetOrderDel(string SerialNo,string DelType)
        {
            DataSet ds = DataProvider.Instance().GetOrderDel(SerialNo,DelType);

            return ds;
        }
        #endregion

        #region "查询发单人是否被禁止发单"
        public static DataSet PubHaveRightLock(string ID)
        {
            DataSet ds = DataProvider.Instance().PubHaveRightLock(ID);

            return ds;
        }
        #endregion

        #region "tbRecharge(充值流水查询) - Method"
        public static DataSet GetRecharge(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().GetRecharge(PageIndex, PageSize, Where);

            return ds;
        }
        #endregion

        #region "WithdrawDeposit(提现汇款查询) - Method"
        public static DataSet WithdrawDeposit(int PageIndex, int PageSize, string Where, int type, int order, int isGood)
        {
            DataSet ds = DataProvider.Instance().WithdrawDeposit(PageIndex, PageSize, Where, type,order,isGood);

            return ds;
        }
        #endregion

        public static DataSet LevelOrderJudgListByID(int PageIndex, int PageSize, string Where, string type)
        {
            DataSet ds = DataProvider.Instance().LevelOrderJudgListByID(PageIndex, PageSize, Where, type);

            return ds;
        }

        public static DataSet LevelOrderJudgCount(string SerialNo)
        {
            DataSet ds = DataProvider.Instance().LevelOrderJudgCount(SerialNo);

            return ds;
        }

        public static DataSet OrderTitle(string SerialNo)
        {
            DataSet ds = DataProvider.Instance().OrderTitle(SerialNo);

            return ds;
        }

        public static DataSet LevelOrderMyJudgStatus(string SerialNo,int CustomerID)
        {
            DataSet ds = DataProvider.Instance().LevelOrderMyJudgStatus(SerialNo, CustomerID);

            return ds;
        }
        

        public static DataSet LevelOrderJudgList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().LevelOrderJudgList(PageIndex, PageSize, Where);

            return ds;
        }

        #region "IsLockWithDraw(用户是否禁止提现) - Method"
        public static DataSet IsLockWithDraw(string uid)
        {
            DataSet ds = DataProvider.Instance().IsLockWithDraw(uid);

            return ds;
        }
        #endregion

        #region "GetWithdrawDeposit(提现汇款查询) - Method"
        public static DataSet GetWithdrawDeposit(string SerialNo, string OPID)
        {
            DataSet ds = DataProvider.Instance().GetWithdrawDeposit(SerialNo, OPID);

            return ds;
        }
        #endregion

        #region "LockWithDraw(解锁) - Method"
        public static DataSet LockWithDraw(string SerialNo, int LockType, string OPID)
        {
            DataSet ds = DataProvider.Instance().LockWithDraw(SerialNo, LockType,OPID);

            return ds;
        }
        #endregion

        #region "tbRecharge(网银汇款查询) - Method"
        public static DataSet BankTransferDetailList(DateTime StartDate, DateTime EndDate,string Keyword, string SearchText, string Result,int PageIndex, int PageSize)
        {
            DataSet ds = DataProvider.Instance().BankTransferDetailList(StartDate, EndDate,Keyword, SearchText, Result,PageIndex, PageSize);

            return ds;
        }
        #endregion

        #region "tlOperate(用户操作日志查询) - Method"
        public static DataSet OperateList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().OperateList(PageIndex, PageSize, Where);

            return ds;
        }
        #endregion

        public static DataSet JugeReason(int PageIndex, int PageSize, string Where,string Where2)
        {
            DataSet ds = DataProvider.Instance().JugeReason(PageIndex, PageSize, Where,Where2);

            return ds;
        }

        public static DataSet ChatMessageList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().ChatMessageList(PageIndex, PageSize, Where);

            return ds;
        }

        #region "tsUser(用户列表) - Method"
        public static DataSet UserList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().UserList(PageIndex, PageSize, Where);

            return ds;
        }

        public static List<tsUser1Entity> UserList(QueryParam qp, out int RecordCount)
        {
            return UserList(qp, out RecordCount, null);
        }

        public static DataSet OrderList(QueryParam qp)
        {
            DataSet ds = DataProvider.Instance().OrderList(qp);
            return ds;
        }

        public static DataSet UserReport(QueryParam qp,string where1)
        {
            DataSet ds = DataProvider.Instance().UserReport(qp,where1);
            return ds;
        }


        public static List<tsUser1Entity> UserList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbUser";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().UserList1(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().UserList1(qp, out RecordCount, tran);
            }
        }
        #endregion

        public static DataSet UserListByMAC(string ID,int PageIndex, int PageSize)
        {
            DataSet ds = DataProvider.Instance().UserListByMAC(ID, PageIndex, PageSize);

            return ds;
        }

        public static DataSet UserListByHD(string ID, int PageIndex, int PageSize)
        {
            DataSet ds = DataProvider.Instance().UserListByHD(ID, PageIndex, PageSize);

            return ds;
        }

        public static DataSet UserListByMAC1(string MAC, int PageIndex, int PageSize)
        {
            DataSet ds = DataProvider.Instance().UserListByMAC1(MAC, PageIndex, PageSize);

            return ds;
        }

        public static DataSet UserAnalysisList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().UserAnalysisList(PageIndex, PageSize, Where);

            return ds;
        }

        #region "tsUser(设置子帐号) - Method"
        public static int SetUserSubAccount(string UserID,int Status)
        {
            int result = DataProvider.Instance().SetUserSubAccount(UserID, Status);

            return result;
        }
        #endregion


        public static int UserLog(int UserID, int OPType,string OPLog,string IP)
        {
            int result = DataProvider.Instance().UserLog(UserID, OPType, OPLog, IP);

            return result;
        }

        public static int DeleteNewsComment(int NewsID)
        {
            int result = DataProvider.Instance().DeleteNewsComment(NewsID);

            return result;
        }



        #region "设置用户权限 - Method"
        public static DataSet SetUserLock(int ID, int LockType, DateTime StartDate,DateTime EndDate,string Notice,int ActivityID,string Condition, int OnOff,int ModuleID)
        {
            DataSet ds = DataProvider.Instance().SetUserLock(ID, LockType, StartDate, EndDate, Notice, ActivityID, Condition, OnOff, ModuleID);

            return ds;
        }

        public static DataSet SetUserLock(int ID, int LockType, DateTime StartDate, DateTime EndDate, string Notice, int ActivityID, string Condition, int OnOff)
        {
            DataSet ds = DataProvider.Instance().SetUserLock(ID, LockType, StartDate, EndDate, Notice, ActivityID, Condition, OnOff);

            return ds;
        }
        #endregion

        public static int IsForbidLogin(int ID)
        {
            int result = DataProvider.Instance().IsForbidLogin(ID);

            return result;
        }

        

        #region "tbLevelOrderMessage(用户订单留言交互查询) - Method"
        public static DataSet LevelOrderMessage(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().LevelOrderMessage(PageIndex, PageSize, Where);

            return ds;
        }
        #endregion

        #region "thLevelOrderMessage(用户订单历史留言交互查询) - Method"
        public static DataSet LevelOrderMessageHis(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().LevelOrderMessageHis(PageIndex, PageSize, Where);

            return ds;
        }
        #endregion


        #region "UserMoneyChange(用户资金调整) - Method"
        public static void UserMoneyChange(int UserID, int ChangeType, decimal ChangeBal, string RelaSerialNo,string Comment)
        {
            DataProvider.Instance().UserMoneyChange(UserID,ChangeType,ChangeBal,RelaSerialNo,Comment);
        }
        #endregion


        public static DataSet UserMoneyChangeJudge(int UserID, decimal ChangeBal)
        {
            DataSet ds = DataProvider.Instance().UserMoneyChangeJudge(UserID, ChangeBal);

            return ds;
        }

        public static DataSet ServiceMaxPrice(string OPID, int Type, decimal ChangeBal)
        {
            DataSet ds = DataProvider.Instance().ServiceMaxPrice(OPID, Type, ChangeBal);

            return ds;
        }

        #region "tlOperate(用户登录日志查询) - Method"
        public static DataSet LoginList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().LoginList(PageIndex, PageSize, Where);

            return ds;
        }
        #endregion

        public static DataSet PendingMattersList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().PendingMattersList(PageIndex, PageSize, Where);

            return ds;
        }


        #region "UserOrderList(客服处理订单查询) - Method"
        public static DataSet UserOrderList(DateTime Start,DateTime End, string OPID,int PageIndex,int PageSize)
        {
            DataSet ds = DataProvider.Instance().UserOrderList(Start, End, OPID,PageIndex,PageSize);

            return ds;
        }
        #endregion

        #region "tsZoneServer(区服汇总表) - Method"
        public static string ZoneServer(string ZoneID, string ServerName)
        {
            return DataProvider.Instance().ZoneServer(ZoneID, ServerName);
        }
        #endregion

        #region "tbRecharge(确认提现汇款) - Method"
        public static string WithdrawSuccess(string SerialNo, string BankSerialNo, string Comment, int OPID)
        {
            return DataProvider.Instance().WithdrawSuccess(SerialNo, BankSerialNo, Comment, OPID);
        }
        #endregion

        #region "tsRightLock(用户是否存在锁定记录) - Method"
        public static string UserIsLock(int UserID, int LockType )
        {
            return DataProvider.Instance().UserIsLock(UserID, LockType);
        }
        #endregion

        #region "截图查询"
        /// <summary>
        /// 截图查询
        /// </summary>
        /// <param name="SerialNo"></param>
        /// <returns></returns>
        public static DataSet GetOrderProgress(string SerialNo)
        {
            DataSet ds = DataProvider.Instance().GetOrderProgress(SerialNo);

            return ds;
        }
        #endregion

        #region "强制完单"
        public static DataSet OrderForceOver(string SerialNo, float Payout, float Income)
        {
            DataSet ds = DataProvider.Instance().OrderForceOver(SerialNo, Payout, Income);

            return ds;
        }
        #endregion

        public static DataSet LockCancelStatus(string SerialNo)
        {
            DataSet ds = DataProvider.Instance().LockCancelStatus(SerialNo);

            return ds;
        }

        public static DataSet GetSysUserInfo(int OPID)
        {
            DataSet ds = DataProvider.Instance().GetSysUserInfo(OPID);

            return ds;
        }
        

        public static DataSet GetServiceHelp(string SerialNo)
        {
            DataSet ds = DataProvider.Instance().GetServiceHelp(SerialNo);

            return ds;
        }

        public static DataSet LevelOrderMarkColorList(string SerialNo)
        {
            DataSet ds = DataProvider.Instance().LevelOrderMarkColorList(SerialNo);

            return ds;
        }

        #region "删除订单"
        public static DataSet OrderDelete(string SerialNo,int OPID)
        {
            DataSet ds = DataProvider.Instance().OrderDelete(SerialNo,OPID);

            return ds;
        }
        #endregion

        public static DataSet OrderActivityDelete(string ID)
        {
            DataSet ds = DataProvider.Instance().OrderActivityDelete(ID);

            return ds;
        }

        public static DataSet OrderActivityReturn(string ID)
        {
            DataSet ds = DataProvider.Instance().OrderActivityReturn(ID);

            return ds;
        }

        public static DataSet AccountRela(string SerialNo)
        {
            DataSet ds = DataProvider.Instance().AccountRela(SerialNo);

            return ds;
        }

        

        public static int OrderDeleteAddRemark(string SerialNo, string Remark)
        {
            int result = DataProvider.Instance().OrderDeleteAddRemark(SerialNo, Remark);

            return result;
        }
        

        #region "新增留言"
        public static DataSet InsertMessage(int UserID, int MsgType, string ODSerialNo,DateTime CreateDate,string Msg)
        {
            DataSet ds = DataProvider.Instance().InsertMessage(UserID, MsgType,ODSerialNo,CreateDate,Msg);

            return ds;
        }
        #endregion

        #region "删除客服留言"
        public static DataSet DeleteMessageService(int MessageID)
        {
            DataSet ds = DataProvider.Instance().DeleteMessageService(MessageID);

            return ds;
        }
        #endregion


        #region "角色名出现频率 上家发单撤单比例"
        public static DataSet OrderFreq(int Type, DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = DataProvider.Instance().OrderFreq(Type, StartDate, EndDate);

            return ds;
        }
        #endregion

        public static DataSet NewAcceptJRCount(int Max, DateTime StartDate, DateTime EndDate,int PageIndex, int PageSize)
        {
            DataSet ds = DataProvider.Instance().NewAcceptJRCount(Max, StartDate,EndDate, PageIndex, PageSize);

            return ds;
        }

        public static DataSet UserGLCount(string GameID,string Min,string Max, DateTime StartDate, DateTime EndDate, int PageIndex, int PageSize,string OrderType)
        {
            DataSet ds = DataProvider.Instance().UserGLCount(GameID, Min, Max, StartDate, EndDate, PageIndex, PageSize, OrderType);

            return ds;
        }

        public static DataSet GetDateList(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = DataProvider.Instance().GetDateList(StartDate, EndDate);

            return ds;
        }

        public static DataSet YXAcceptOrder(string UserID,DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = DataProvider.Instance().YXAcceptOrder(UserID,StartDate, EndDate);

            return ds;
        }

        public static DataSet NewAcceptUser(DateTime StatDate)
        {
            DataSet ds = DataProvider.Instance().NewAcceptUser(StatDate);

            return ds;
        }

        public static DataSet NewAcceptUserStat(DateTime StatDate)
        {
            DataSet ds = DataProvider.Instance().NewAcceptUserStat(StatDate);

            return ds;
        }

        public static DataSet ActivitytUser(DateTime StatDate)
        {
            DataSet ds = DataProvider.Instance().ActivitytUser(StatDate);

            return ds;
        }

        public static DataSet HalfActivitytUser(DateTime StatDate)
        {
            DataSet ds = DataProvider.Instance().HalfActivitytUser(StatDate);

            return ds;
        }

        public static DataSet HalfActivitytUserStat(DateTime StatDate)
        {
            DataSet ds = DataProvider.Instance().HalfActivitytUserStat(StatDate);

            return ds;
        }

        public static DataSet LoseUser(DateTime StatDate)
        {
            DataSet ds = DataProvider.Instance().LoseUser(StatDate);

            return ds;
        }

        public static DataSet LoseUserStat(DateTime StatDate)
        {
            DataSet ds = DataProvider.Instance().LoseUserStat(StatDate);

            return ds;
        }

        public static DataSet PercentActivitytUser(DateTime StatDate)
        {
            DataSet ds = DataProvider.Instance().PercentActivitytUser(StatDate);

            return ds;
        }
        

        public static DataSet SRPriceAcceptOrder(string UserID, DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = DataProvider.Instance().SRPriceAcceptOrder(UserID, StartDate, EndDate);

            return ds;
        }
        

        
        

        #region "获取近一周发单量前100的商家"
        public static DataSet GetTopPostUser(string Game)
        {
            DataSet ds = DataProvider.Instance().GetTopPostUser(Game);

            return ds;
        }
        #endregion

        #region "获取某个具体商家一周内的发单量"
        public static DataSet GetUserPostByWeek(int ID)
        {
            DataSet ds = DataProvider.Instance().GetUserPostByWeek(ID);

            return ds;
        }
        #endregion


        #region "获取某用户登录MAC反向关联用户数量"
        public static DataSet GetUserLoginMACList(int ID)
        {
            DataSet ds = DataProvider.Instance().GetUserLoginMACList(ID);

            return ds;
        }
        #endregion


        public static DataSet GetUserLoginHDList(int ID)
        {
            DataSet ds = DataProvider.Instance().GetUserLoginHDList(ID);

            return ds;
        }

        public static DataSet GetUserCountByMAC(string MAC)
        {
            DataSet ds = DataProvider.Instance().GetUserCountByMAC(MAC);

            return ds;
        }

        public static DataSet BM_GetUserListByMAC(string MAC)
        {
            DataSet ds = DataProvider.Instance().BM_GetUserListByMAC(MAC);

            return ds;
        }

        public static DataSet BM_GetMACUserListByID(string ID)
        {
            DataSet ds = DataProvider.Instance().BM_GetMACUserListByID(ID);

            return ds;
        }

        #region "更新用户备注信息"
        public static DataSet UpdateUserComment(string Comment,string UID)
        {
            DataSet ds = DataProvider.Instance().UpdateUserComment(Comment, UID);

            return ds;
        }
        #endregion

        public static DataSet UpdateFeedBackComment(string Comment, string UserID, int CustomerID)
        {
            DataSet ds = DataProvider.Instance().UpdateFeedBackComment(Comment, UserID,CustomerID);

            return ds;
        }

        public static DataSet AddBankBlack(int BankID, string BankUser,string BankAcc,int CustomerID,string Comment)
        {
            DataSet ds = DataProvider.Instance().AddBankBlack(BankID, BankUser, BankAcc, CustomerID, Comment);

            return ds;
        }


        public static DataSet RightLockLastOPID(string UID)
        {
            DataSet ds = DataProvider.Instance().RightLockLastOPID(UID);

            return ds;
        }

        public static DataSet FTRightLock(string ID)
        {
            DataSet ds = DataProvider.Instance().FTRightLock(ID);

            return ds;
        }


        public static DataSet SearchAccPwd(string SerialNo,int OPID)
        {
            DataSet ds = DataProvider.Instance().SearchAccPwd(SerialNo,OPID);

            return ds;
        }

        public static DataSet IsGoodPost(string userID)
        {
            DataSet ds = DataProvider.Instance().IsGoodPost(userID);

            return ds;
        }

        public static DataSet IsGoodAccept(string userID)
        {
            DataSet ds = DataProvider.Instance().IsGoodAccept(userID);

            return ds;
        }

        public static int AddLevelOrderProgress(string UserID, string SerialNo,string Msg,string Img)
        {
            int result = DataProvider.Instance().AddLevelOrderProgress(UserID, SerialNo, Msg,Img);

            return result;
        }

        public static int DeleteLevelOrderProgress(int ID)
        {
            int result = DataProvider.Instance().DeleteLevelOrderProgress(ID);

            return result;
        }
        

        

        #region "获取评价备注信息"
        public static DataSet UpdateOrderEvaluate(string OrderEvaluate,string Comment, string Type,string Direct)
        {
            DataSet ds = DataProvider.Instance().UpdateOrderEvaluate(OrderEvaluate, Comment, Type, Direct);

            return ds;
        }
        #endregion

        #region "更新角色备注信息"
        public static DataSet UpdateRoleComment(string Comment,string Actor, string Code)
        {
            DataSet ds = DataProvider.Instance().UpdateRoleComment(Comment,Actor,Code);

            return ds;
        }
        #endregion



        #region "获取用户资金变动明细"
        public static DataSet UserMoneyChangeList(int UserID, DateTime StartDate, DateTime EndDate, int Type, string RelaSerialNo,int PageIndex, int PageSize,string Search)
        {
            DataSet ds = DataProvider.Instance().UserMoneyChangeList(UserID, StartDate, EndDate, Type,RelaSerialNo,PageIndex,PageSize,Search);

            return ds;
        }
        #endregion

        public static DataSet UserMoneyFreezeList(int UserID, DateTime StartDate, DateTime EndDate, int Type, string RelaSerialNo, int PageIndex, int PageSize, string Search)
        {
            DataSet ds = DataProvider.Instance().UserMoneyFreezeList(UserID, StartDate, EndDate, Type, RelaSerialNo, PageIndex, PageSize, Search);

            return ds;
        }

        #region "上家发单介入比例"
        public static DataSet JRFreq(int Type, DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = DataProvider.Instance().JRFreq(Type, StartDate, EndDate);

            return ds;
        }
        #endregion

        #region "订单处理统计"
        public static DataSet OrderOPStat(DateTime StartDate, DateTime EndDate, string OPName, string SearchType)
        {
            DataSet ds = DataProvider.Instance().OrderOPStat(StartDate, EndDate, OPName, SearchType);

            return ds;
        }
        #endregion

        public static DataSet JROrderStat(DateTime StartDate, DateTime EndDate,string GameID,string PostUserID)
        {
            DataSet ds = DataProvider.Instance().JROrderStat(StartDate, EndDate, GameID, PostUserID);

            return ds;
        }

        public static DataSet OrderPostStat(DateTime StartDate, DateTime EndDate, string OPName, string SearchType)
        {
            DataSet ds = DataProvider.Instance().OrderPostStat(StartDate, EndDate, OPName, SearchType);

            return ds;
        }

        public static DataSet OrderDelStat(DateTime StartDate, DateTime EndDate, string OPName)
        {
            DataSet ds = DataProvider.Instance().OrderDelStat(StartDate, EndDate, OPName);

            return ds;
        }

        #region "更多数据统计"
        public static DataSet AllstatisticsMore(string GameID,DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = DataProvider.Instance().AllstatisticsMore(GameID,StartDate, EndDate);

            return ds;
        }
        #endregion


        #region "用户数据统计"
        public static DataSet UserStat(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = DataProvider.Instance().UserStat(StartDate, EndDate);

            return ds;
        }
        #endregion

        #region "当前在线人数"
        public static DataSet UserOnline()
        {
            DataSet ds = DataProvider.Instance().UserOnline();

            return ds;
        }
        #endregion

        #region "财务总账统计"
        public static DataSet FinanceStat(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = DataProvider.Instance().FinanceStat(StartDate, EndDate);

            return ds;
        }
        #endregion

        #region "财务总账统计-NOW"
        public static DataSet FinanceTotal()
        {
            DataSet ds = DataProvider.Instance().FinanceTotal();

            return ds;
        }
        #endregion

        #region "财务详细统计"
        public static DataSet FinanceStatWDRC(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = DataProvider.Instance().FinanceStatWDRC(StartDate, EndDate);

            return ds;
        }
        #endregion

        #region "汇款确认统计"
        public static DataSet FinanceStatConfirmWithdraw(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = DataProvider.Instance().FinanceStatConfirmWithdraw(StartDate, EndDate);

            return ds;
        }
        #endregion

        #region "汇款取消统计"
        public static DataSet FinanceStatCancelWithdraw(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = DataProvider.Instance().FinanceStatCancelWithdraw(StartDate, EndDate);

            return ds;
        }
        #endregion

        #region "标记关注订单"
        public static DataSet MarkLookOrder(string SerialNo, int OPID, int Mark)
        {
            DataSet ds = DataProvider.Instance().MarkLookOrder(SerialNo, OPID, Mark);

            return ds;
        }
        #endregion

        public static DataSet SetOrderCancelStatus(string SerialNo,int Status)
        {
            DataSet ds = DataProvider.Instance().SetOrderCancelStatus(SerialNo, Status);

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
        /// <returns></returns>
        public static string get_table_fileds(string table_name, string table_fileds, string where_fileds, string where_value)
        {
            return DataProvider.Instance().get_table_fileds(table_name, table_fileds, where_fileds, where_value);
        }

        /// <summary>
        /// 获取表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="table_fileds">字段</param>
        /// <param name="where_fileds">查询条件字段</param>
        /// <param name="where_value">查询值</param>
        /// <param name="tran">事务</param>        
        /// <returns></returns>
        public static string get_table_fileds(string table_name, string table_fileds, string where_fileds, string where_value,DbTransaction tran)
        {
            return DataProvider.Instance().get_table_fileds(table_name, table_fileds, where_fileds, where_value,tran);
        }        
        #endregion

        #region "列新表中字段值"
        /// <summary>
        /// 更新表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="Table">表名</param>
        /// <param name="Table_FiledsValue">需要更新值(不用带Set)</param>
        /// <param name="Wheres">更新条件(不用带Where)</param>
        /// <returns></returns>
        public static int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres)
        {
            return DataProvider.Instance().Update_Table_Fileds(Table, Table_FiledsValue, Wheres);
        }

        /// <summary>
        /// 更新表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="Table">表名</param>
        /// <param name="Table_FiledsValue">需要更新值(不用带Set)</param>
        /// <param name="Wheres">更新条件(不用带Where)</param>
        /// <param name="tran">事务</param>          
        /// <returns></returns>
        public static int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres,DbTransaction tran)
        {
            return DataProvider.Instance().Update_Table_Fileds(Table, Table_FiledsValue, Wheres,tran);
        }       

        #endregion

        #region "获得数据库链接"
        /// 
        /// 获得数据库链接
        /// 
        /// 
        public static DbConnection GetDdConnection()
        {
            return DataProvider.Instance().GetDdConnection();
        }        
        #endregion


        #region "sys_Comment(sys_Comment) - Method"

        /// <summary>
        /// 新增/删除/修改 sys_CommentEntity (sys_Comment)
        /// </summary>
        /// <param name="fam">sys_CommentEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 sys_CommentInsertUpdateDelete(sys_CommentEntity fam)
        {
            return DataProvider.Instance().sys_CommentInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 sys_CommentEntity (sys_Comment)
        /// </summary>
        /// <param name="fam">sys_CommentEntity实体类</param>
        /// <param name="tran">sys_Comment事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 sys_CommentInsertUpdateDelete(sys_CommentEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().sys_CommentInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据C_CommentID返回 sys_CommentEntity实体类 单笔资料 (sys_Comment)
        /// </summary>
        /// <param name="C_CommentID">C_CommentID C_CommentID</param>
        /// <returns>返回 sys_CommentEntity实体类 C_CommentID为0则无记录</returns>
        public static sys_CommentEntity sys_CommentDisp(Int32 C_CommentID)
        {
            sys_CommentEntity fam = new sys_CommentEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "sys_Comment", "C_CommentID", C_CommentID);
            int RecordCount = 0;
            List<sys_CommentEntity> lst = sys_CommentList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据C_CommentID返回 sys_CommentEntity实体类 单笔资料 (sys_Comment)
        /// </summary>
        /// <param name="C_CommentID">C_CommentID C_CommentID</param>
        /// <param name="tran">sys_Comment事务</param>
        /// <returns>返回 sys_CommentEntity实体类 C_CommentID为0则无记录</returns>
        public static sys_CommentEntity sys_CommentDisp(Int32 C_CommentID, DbTransaction tran)
        {
            sys_CommentEntity fam = new sys_CommentEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "sys_Comment", "C_CommentID", C_CommentID);
            int RecordCount = 0;
            List<sys_CommentEntity> lst = sys_CommentList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回sys_CommentEntity实体类的List对象 (sys_Comment)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_CommentEntity实体类的List对象(sys_Comment)</returns>
        public static List<sys_CommentEntity> sys_CommentList(QueryParam qp, out int RecordCount)
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
        public static List<sys_CommentEntity> sys_CommentList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "sys_Comment";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "C_CommentID";
            }
            else if (qp.Orderfld != "C_CommentID")
            {
                qp.Orderfld += ",C_CommentID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().sys_CommentList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().sys_CommentList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "sys_News(sys_News) - Method"

        /// <summary>
        /// 新增/删除/修改 sys_NewsEntity (sys_News)
        /// </summary>
        /// <param name="fam">sys_NewsEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 sys_NewsInsertUpdateDelete(sys_NewsEntity fam)
        {
            return DataProvider.Instance().sys_NewsInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 sys_NewsEntity (sys_News)
        /// </summary>
        /// <param name="fam">sys_NewsEntity实体类</param>
        /// <param name="tran">sys_News事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 sys_NewsInsertUpdateDelete(sys_NewsEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().sys_NewsInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据N_ID返回 sys_NewsEntity实体类 单笔资料 (sys_News)
        /// </summary>
        /// <param name="N_ID">N_ID N_ID</param>
        /// <returns>返回 sys_NewsEntity实体类 N_ID为0则无记录</returns>
        public static sys_NewsEntity sys_NewsDisp(Int32 N_ID)
        {
            sys_NewsEntity fam = new sys_NewsEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "sys_News", "N_ID", N_ID);
            int RecordCount = 0;
            List<sys_NewsEntity> lst = sys_NewsList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据N_ID返回 sys_NewsEntity实体类 单笔资料 (sys_News)
        /// </summary>
        /// <param name="N_ID">N_ID N_ID</param>
        /// <param name="tran">sys_News事务</param>
        /// <returns>返回 sys_NewsEntity实体类 N_ID为0则无记录</returns>
        public static sys_NewsEntity sys_NewsDisp(Int32 N_ID, DbTransaction tran)
        {
            sys_NewsEntity fam = new sys_NewsEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "sys_News", "N_ID", N_ID);
            int RecordCount = 0;
            List<sys_NewsEntity> lst = sys_NewsList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回sys_NewsEntity实体类的List对象 (sys_News)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_NewsEntity实体类的List对象(sys_News)</returns>
        public static List<sys_NewsEntity> sys_NewsList(QueryParam qp, out int RecordCount)
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
        public static List<sys_NewsEntity> sys_NewsList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "sys_News";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "N_ID";
            }
            else if (qp.Orderfld != "N_ID")
            {
                qp.Orderfld += ",N_ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().sys_NewsList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().sys_NewsList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "sys_PendingComment(sys_PendingComment) - Method"

        /// <summary>
        /// 新增/删除/修改 sys_PendingCommentEntity (sys_PendingComment)
        /// </summary>
        /// <param name="fam">sys_PendingCommentEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 sys_PendingCommentInsertUpdateDelete(sys_PendingCommentEntity fam)
        {
            return DataProvider.Instance().sys_PendingCommentInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 sys_PendingCommentEntity (sys_PendingComment)
        /// </summary>
        /// <param name="fam">sys_PendingCommentEntity实体类</param>
        /// <param name="tran">sys_PendingComment事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 sys_PendingCommentInsertUpdateDelete(sys_PendingCommentEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().sys_PendingCommentInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据P_CommentID返回 sys_PendingCommentEntity实体类 单笔资料 (sys_PendingComment)
        /// </summary>
        /// <param name="P_CommentID">P_CommentID P_CommentID</param>
        /// <returns>返回 sys_PendingCommentEntity实体类 P_CommentID为0则无记录</returns>
        public static sys_PendingCommentEntity sys_PendingCommentDisp(Int32 P_CommentID)
        {
            sys_PendingCommentEntity fam = new sys_PendingCommentEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "sys_PendingComment", "P_CommentID", P_CommentID);
            int RecordCount = 0;
            List<sys_PendingCommentEntity> lst = sys_PendingCommentList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据P_CommentID返回 sys_PendingCommentEntity实体类 单笔资料 (sys_PendingComment)
        /// </summary>
        /// <param name="P_CommentID">P_CommentID P_CommentID</param>
        /// <param name="tran">sys_PendingComment事务</param>
        /// <returns>返回 sys_PendingCommentEntity实体类 P_CommentID为0则无记录</returns>
        public static sys_PendingCommentEntity sys_PendingCommentDisp(Int32 P_CommentID, DbTransaction tran)
        {
            sys_PendingCommentEntity fam = new sys_PendingCommentEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "sys_PendingComment", "P_CommentID", P_CommentID);
            int RecordCount = 0;
            List<sys_PendingCommentEntity> lst = sys_PendingCommentList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回sys_PendingCommentEntity实体类的List对象 (sys_PendingComment)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_PendingCommentEntity实体类的List对象(sys_PendingComment)</returns>
        public static List<sys_PendingCommentEntity> sys_PendingCommentList(QueryParam qp, out int RecordCount)
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
        public static List<sys_PendingCommentEntity> sys_PendingCommentList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "sys_PendingComment";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "P_CommentID";
            }
            else if (qp.Orderfld != "P_CommentID")
            {
                qp.Orderfld += ",P_CommentID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().sys_PendingCommentList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().sys_PendingCommentList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "sys_PendingMatters(sys_PendingMatters) - Method"

        /// <summary>
        /// 新增/删除/修改 sys_PendingMattersEntity (sys_PendingMatters)
        /// </summary>
        /// <param name="fam">sys_PendingMattersEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 sys_PendingMattersInsertUpdateDelete(sys_PendingMattersEntity fam)
        {
            return DataProvider.Instance().sys_PendingMattersInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 sys_PendingMattersEntity (sys_PendingMatters)
        /// </summary>
        /// <param name="fam">sys_PendingMattersEntity实体类</param>
        /// <param name="tran">sys_PendingMatters事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 sys_PendingMattersInsertUpdateDelete(sys_PendingMattersEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().sys_PendingMattersInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据P_ID返回 sys_PendingMattersEntity实体类 单笔资料 (sys_PendingMatters)
        /// </summary>
        /// <param name="P_ID">P_ID P_ID</param>
        /// <returns>返回 sys_PendingMattersEntity实体类 P_ID为0则无记录</returns>
        public static sys_PendingMattersEntity sys_PendingMattersDisp(Int32 P_ID)
        {
            sys_PendingMattersEntity fam = new sys_PendingMattersEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "sys_PendingMatters", "P_ID", P_ID);
            int RecordCount = 0;
            List<sys_PendingMattersEntity> lst = sys_PendingMattersList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据P_ID返回 sys_PendingMattersEntity实体类 单笔资料 (sys_PendingMatters)
        /// </summary>
        /// <param name="P_ID">P_ID P_ID</param>
        /// <param name="tran">sys_PendingMatters事务</param>
        /// <returns>返回 sys_PendingMattersEntity实体类 P_ID为0则无记录</returns>
        public static sys_PendingMattersEntity sys_PendingMattersDisp(Int32 P_ID, DbTransaction tran)
        {
            sys_PendingMattersEntity fam = new sys_PendingMattersEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "sys_PendingMatters", "P_ID", P_ID);
            int RecordCount = 0;
            List<sys_PendingMattersEntity> lst = sys_PendingMattersList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回sys_PendingMattersEntity实体类的List对象 (sys_PendingMatters)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_PendingMattersEntity实体类的List对象(sys_PendingMatters)</returns>
        public static List<sys_PendingMattersEntity> sys_PendingMattersList(QueryParam qp, out int RecordCount)
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
        public static List<sys_PendingMattersEntity> sys_PendingMattersList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "sys_PendingMatters";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "P_ID";
            }
            else if (qp.Orderfld != "P_ID")
            {
                qp.Orderfld += ",P_ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().sys_PendingMattersList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().sys_PendingMattersList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "tbChatMessage(tbChatMessage) - Method"

        /// <summary>
        /// 新增/删除/修改 tbChatMessageEntity (tbChatMessage)
        /// </summary>
        /// <param name="fam">tbChatMessageEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbChatMessageInsertUpdateDelete(tbChatMessageEntity fam)
        {
            return DataProvider.Instance().tbChatMessageInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbChatMessageEntity (tbChatMessage)
        /// </summary>
        /// <param name="fam">tbChatMessageEntity实体类</param>
        /// <param name="tran">tbChatMessage事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbChatMessageInsertUpdateDelete(tbChatMessageEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tbChatMessageInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据ID返回 tbChatMessageEntity实体类 单笔资料 (tbChatMessage)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbChatMessageEntity实体类 ID为0则无记录</returns>
        public static tbChatMessageEntity tbChatMessageDisp(Int32 ID)
        {
            tbChatMessageEntity fam = new tbChatMessageEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbChatMessage", "ID", ID);
            int RecordCount = 0;
            List<tbChatMessageEntity> lst = tbChatMessageList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbChatMessageEntity实体类 单笔资料 (tbChatMessage)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbChatMessage事务</param>
        /// <returns>返回 tbChatMessageEntity实体类 ID为0则无记录</returns>
        public static tbChatMessageEntity tbChatMessageDisp(Int32 ID, DbTransaction tran)
        {
            tbChatMessageEntity fam = new tbChatMessageEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbChatMessage", "ID", ID);
            int RecordCount = 0;
            List<tbChatMessageEntity> lst = tbChatMessageList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbChatMessageEntity实体类的List对象 (tbChatMessage)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbChatMessageEntity实体类的List对象(tbChatMessage)</returns>
        public static List<tbChatMessageEntity> tbChatMessageList(QueryParam qp, out int RecordCount)
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
        public static List<tbChatMessageEntity> tbChatMessageList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbChatMessage";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbChatMessageList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbChatMessageList(qp, out RecordCount, tran);
            }
        }
        #endregion


        #region "tbVirtualWallet(tbVirtualWallet) - Method"

        /// <summary>
        /// 新增/删除/修改 tbVirtualWalletEntity (tbVirtualWallet)
        /// </summary>
        /// <param name="fam">tbVirtualWalletEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbVirtualWalletInsertUpdateDelete(tbVirtualWalletEntity fam)
        {
            return DataProvider.Instance().tbVirtualWalletInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 根据ID返回 tbVirtualWalletEntity实体类 单笔资料 (tbVirtualWallet)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbVirtualWalletEntity实体类 ID为0则无记录</returns>
        public static tbVirtualWalletEntity tbVirtualWalletDisp(Int32 ID)
        {
            tbVirtualWalletEntity fam = new tbVirtualWalletEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbVirtualWallet", "ID", ID);
            int RecordCount = 0;
            List<tbVirtualWalletEntity> lst = tbVirtualWalletList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbVirtualWalletEntity实体类的List对象 (tbVirtualWallet)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbVirtualWalletEntity实体类的List对象(tbVirtualWallet)</returns>
        public static List<tbVirtualWalletEntity> tbVirtualWalletList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "tbVirtualWallet";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().tbVirtualWalletList(qp, out RecordCount);
        }
        #endregion

        #region "tbVirtualBank(tbVirtualBank) - Method"

        /// <summary>
        /// 新增/删除/修改 tbVirtualBankEntity (tbVirtualBank)
        /// </summary>
        /// <param name="fam">tbVirtualBankEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbVirtualBankInsertUpdateDelete(tbVirtualBankEntity fam)
        {
            return DataProvider.Instance().tbVirtualBankInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 tbVirtualBankEntity (tbVirtualBank)
        /// </summary>
        /// <param name="fam">tbVirtualBankEntity实体类</param>
        /// <param name="tran">tbVirtualBank事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbVirtualBankInsertUpdateDelete(tbVirtualBankEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tbVirtualBankInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据ID返回 tbVirtualBankEntity实体类 单笔资料 (tbVirtualBank)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tbVirtualBankEntity实体类 ID为0则无记录</returns>
        public static tbVirtualBankEntity tbVirtualBankDisp(Int32 ID)
        {
            tbVirtualBankEntity fam = new tbVirtualBankEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbVirtualBank", "ID", ID);
            int RecordCount = 0;
            List<tbVirtualBankEntity> lst = tbVirtualBankList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tbVirtualBankEntity实体类 单笔资料 (tbVirtualBank)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tbVirtualBank事务</param>
        /// <returns>返回 tbVirtualBankEntity实体类 ID为0则无记录</returns>
        public static tbVirtualBankEntity tbVirtualBankDisp(Int32 ID, DbTransaction tran)
        {
            tbVirtualBankEntity fam = new tbVirtualBankEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbVirtualBank", "ID", ID);
            int RecordCount = 0;
            List<tbVirtualBankEntity> lst = tbVirtualBankList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tbVirtualBankEntity实体类的List对象 (tbVirtualBank)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tbVirtualBankEntity实体类的List对象(tbVirtualBank)</returns>
        public static List<tbVirtualBankEntity> tbVirtualBankList(QueryParam qp, out int RecordCount)
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
        public static List<tbVirtualBankEntity> tbVirtualBankList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbVirtualBank";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbVirtualBankList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbVirtualBankList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region "sys_LoginAuthorize(sys_LoginAuthorize) - Method"

        /// <summary>
        /// 新增/删除/修改 sys_LoginAuthorizeEntity (sys_LoginAuthorize)
        /// </summary>
        /// <param name="fam">sys_LoginAuthorizeEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 sys_LoginAuthorizeInsertUpdateDelete(sys_LoginAuthorizeEntity fam)
        {
            return DataProvider.Instance().sys_LoginAuthorizeInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 新增/删除/修改 sys_LoginAuthorizeEntity (sys_LoginAuthorize)
        /// </summary>
        /// <param name="fam">sys_LoginAuthorizeEntity实体类</param>
        /// <param name="tran">sys_LoginAuthorize事务</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 sys_LoginAuthorizeInsertUpdateDelete(sys_LoginAuthorizeEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().sys_LoginAuthorizeInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据L_ID返回 sys_LoginAuthorizeEntity实体类 单笔资料 (sys_LoginAuthorize)
        /// </summary>
        /// <param name="L_ID">L_ID L_ID</param>
        /// <returns>返回 sys_LoginAuthorizeEntity实体类 L_ID为0则无记录</returns>
        public static sys_LoginAuthorizeEntity sys_LoginAuthorizeDisp(Int32 L_ID)
        {
            sys_LoginAuthorizeEntity fam = new sys_LoginAuthorizeEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "sys_LoginAuthorize", "L_ID", L_ID);
            int RecordCount = 0;
            List<sys_LoginAuthorizeEntity> lst = sys_LoginAuthorizeList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据L_ID返回 sys_LoginAuthorizeEntity实体类 单笔资料 (sys_LoginAuthorize)
        /// </summary>
        /// <param name="L_ID">L_ID L_ID</param>
        /// <param name="tran">sys_LoginAuthorize事务</param>
        /// <returns>返回 sys_LoginAuthorizeEntity实体类 L_ID为0则无记录</returns>
        public static sys_LoginAuthorizeEntity sys_LoginAuthorizeDisp(Int32 L_ID, DbTransaction tran)
        {
            sys_LoginAuthorizeEntity fam = new sys_LoginAuthorizeEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "sys_LoginAuthorize", "L_ID", L_ID);
            int RecordCount = 0;
            List<sys_LoginAuthorizeEntity> lst = sys_LoginAuthorizeList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回sys_LoginAuthorizeEntity实体类的List对象 (sys_LoginAuthorize)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_LoginAuthorizeEntity实体类的List对象(sys_LoginAuthorize)</returns>
        public static List<sys_LoginAuthorizeEntity> sys_LoginAuthorizeList(QueryParam qp, out int RecordCount)
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
        public static List<sys_LoginAuthorizeEntity> sys_LoginAuthorizeList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "sys_LoginAuthorize";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "L_ID";
            }
            else if (qp.Orderfld != "L_ID")
            {
                qp.Orderfld += ",L_ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().sys_LoginAuthorizeList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().sys_LoginAuthorizeList(qp, out RecordCount, tran);
            }
        }
        #endregion

        #region MyRegion

        public static DataSet AddAppointArbitration(string CustomerID, string UserID, int OpID)
        {
            DataSet ds = DataProvider.Instance().AddAppointArbitration(CustomerID, UserID, OpID);

            return ds;
        }

        public static DataSet Login(string UserName, string Password)
        {
            DataSet ds = DataProvider.Instance().Login(UserName, Password);

            return ds;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="tsUser"></param>
        /// <param name="tlOperate"></param>
        /// <param name="tlLogin"></param>
        /// <param name="tbMobileSerialNo"></param>
        /// <returns></returns>
        public static int Gegister(tsUserEntity tsUser, tlOperateEntity tlOperate, tlLoginEntity tlLogin, string tbMobileSerialNo, out int userId)
        {
            return DataProvider.Instance().Gegister(tsUser, tlOperate, tlLogin, tbMobileSerialNo, out userId);
        }

        public static string GetLoginIDByMobile(string Mobile)
        {
            string str = DataProvider.Instance().GetLoginIDByMobile(Mobile);

            return str;
        }

        public static DataTable GetActivityByModuleID(int moduleId)
        {
            DataTable dt = DataProvider.Instance().GetActivityByModuleID(moduleId);

            return dt;
        }

        public static DataSet GetZhanKengOrders(int activityId, int bet, int userId)
        {
            DataSet ds = DataProvider.Instance().GetZhanKengOrders(activityId, bet, userId);

            return ds;
        }

        public static DataSet GetZhanKengOrders(string seriaNo, int userId)
        {
            DataSet ds = DataProvider.Instance().GetZhanKengOrders(seriaNo, userId);

            return ds;
        }

        public static bool CheckZhanKengBit(string seriaNo, string pit)
        {
            return DataProvider.Instance().CheckZhanKengBit(seriaNo, pit);
        }

        public static DataTable GetZhanKengBySeriaNo(string seriaNo)
        {
            return DataProvider.Instance().GetZhanKengBySeriaNo(seriaNo);
        }

        public static DataTable GetZhanKengByOrderSeriaNo(string seriaNo)
        {
            return DataProvider.Instance().GetZhanKengByOrderSeriaNo(seriaNo);
        }

        public static DataTable GetZhanKengByOrderSeriaNo(string seriaNo, bool isShowAll)
        {
            return DataProvider.Instance().GetZhanKengByOrderSeriaNo(seriaNo, isShowAll);
        }

        public static DataTable CheckMobileToken(string mobile)
        {
            DataTable dt = DataProvider.Instance().CheckMobileToken(mobile);

            return dt;
        }

        public static int GetZhanKengNumBySeriaNo(string seriaNo)
        {
            return DataProvider.Instance().GetZhanKengNumBySeriaNo(seriaNo);
        }

        public static int CheckUserByMobile(string mobile)
        {
            return DataProvider.Instance().CheckUserByMobile(mobile);
        }

        public static DataTable GetActivityById(string id)
        {
            DataTable dt = DataProvider.Instance().GetActivityById(id);

            return dt;
        }

        public static DataTable GetActivityById(string id, string moduleId)
        {
            DataTable dt = DataProvider.Instance().GetActivityById(id, moduleId);

            return dt;
        }

        public static DataSet CheckBaoMing(string id, string roleName, int userID, int status, string moduleID)
        {
            DataSet dt = DataProvider.Instance().CheckBaoMing(id, roleName, userID, status, moduleID);

            return dt;
        }



        public static DataTable GetUserZoneServer(int userId, string gameId)
        {
            DataTable dt = DataProvider.Instance().GetUserZoneServer(userId, gameId);

            return dt;
        }

        public static DataSet GetZoneServer(string gameId)
        {
            DataSet ds = DataProvider.Instance().GetZoneServer(gameId);

            return ds;
        }

        public static double GetUserSumBal(int userId)
        {
            double d = DataProvider.Instance().GetUserSumBal(userId);

            return d;
        }

        public static DataTable GetUserSumBal1(int userId)
        {
            return DataProvider.Instance().GetUserSumBal1(userId);
        }

        public static DataTable GetUserByUid(string uid)
        {
            return DataProvider.Instance().GetUserByUid(uid);
        }

        public static DataTable GetNickNameByUid(string uid)
        {
            return DataProvider.Instance().GetNickNameByUid(uid);
        }

        public static int UpdateUserSumBal(int userId, double sumBal, int operate)
        {
            int result = DataProvider.Instance().UpdateUserSumBal(userId, sumBal, operate);

            return result;
        }

        public static int UpdateUserSumBal(int userId, double sumBal, int operate, DbTransaction tran)
        {
            int result = DataProvider.Instance().UpdateUserSumBal(userId, sumBal, operate, tran);

            return result;
        }

        public static string act_Orders(tbOrdersEntity Orders, string SType)
        {
            string str = DataProvider.Instance().act_Orders(Orders);

            return str;
        }

        public static string act_Orders(tbOrdersEntity Orders, string SType, DbTransaction tran)
        {
            string str = DataProvider.Instance().act_Orders(Orders, tran);

            return str;
        }

        public static DataSet act_UserInsertUpdateDelete(tsUserEntity tsUser)
        {
            DataSet ds = DataProvider.Instance().act_UserInsertUpdateDelete(tsUser);

            return ds;
        }

        public static DataTable GetOrdersById(int id, int userId)
        {
            DataTable dt = DataProvider.Instance().GetOrdersById(id, userId);

            return dt;
        }

        public static DataTable GetOrdersBySeriaNo(string seriaNo)
        {
            DataTable dt = DataProvider.Instance().GetOrdersBySeriaNo(seriaNo);

            return dt;
        }

        public static DataTable GetOrdersBySeriaNo(string seriaNo, int userId)
        {
            DataTable dt = DataProvider.Instance().GetOrdersBySeriaNo(seriaNo, userId);

            return dt;
        }

        public static DataTable GetOrdersByStatus()
        {
            DataTable dt = DataProvider.Instance().GetOrdersByStatus();

            return dt;
        }


        public static void InsertErrorLog(string type, string content)
        {
            DataProvider.Instance().InsertErrorLog(type, content);
        }

        public static DataTable GetRecordList(QueryParam pp, out int RecordCount, out int PageCount)
        {
            return DataProvider.Instance().GetRecordList(pp, out RecordCount, out PageCount);
        }


        public static int baoming_zhifu(tbOrdersEntity Orders, tbMoneyChangeEntity tbMoneyChange, tsUserZoneServerEntity tsUserZoneServer, tlOperateEntity fam)
        {
            int result = DataProvider.Instance().baoming_zhifu(Orders, tbMoneyChange, tsUserZoneServer, fam);

            return result;
        }

        public static int baomingzk_zhifu(string SeriaNo, string Pit, tbOrdersEntity Orders, tbMoneyChangeEntity tbMoneyChange, tsUserZoneServerEntity tsUserZoneServer, tlOperateEntity fam)
        {
            int result = DataProvider.Instance().baomingzk_zhifu(SeriaNo, Pit, Orders, tbMoneyChange, tsUserZoneServer, fam);

            return result;
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="Orders"></param>
        /// <param name="tbMoneyChange"></param>
        /// <param name="tsUserZoneServer"></param>
        /// <param name="fam"></param>
        /// <returns></returns>
        public static int Recharge(tbMoneyChangeEntity tbMoneyChange, tbRechargeEntity tbRecharge, tlOperateEntity fam)
        {
            int result = DataProvider.Instance().Recharge(tbMoneyChange, tbRecharge, fam);

            return result;
        }

        public static DataTable GetUserById(int id)
        {
            return DataProvider.Instance().GetUserById(id);
        }


        #region 优质频道
        public static DataSet GoodPublishList(string UID, DateTime sDate, DateTime eDate, int Status, string Sort_Str, int PageIndex, int PageSize)
        {
            DataSet ds = DataProvider.Instance().GoodPublishList(UID, sDate, eDate, Status, Sort_Str, PageIndex, PageSize);

            return ds;
        }

        public static int GoodPublishPast(int ID, int Flag)
        {
            int result = DataProvider.Instance().GoodPublishPast(ID, Flag);

            return result;
        }

        public static DataTable GoodPublishAdd(string UID, int Del)
        {
            DataTable dt = DataProvider.Instance().GoodPublishAdd(UID, Del);

            return dt;
        }

        public static DataSet GoodAcceptList(string UID, DateTime sDate, DateTime eDate, int Status, string Sort_Str, int ApplyTier, int PageIndex, int PageSize)
        {
            DataSet ds = DataProvider.Instance().GoodAcceptList(UID, sDate, eDate, Status, Sort_Str, ApplyTier, PageIndex, PageSize);

            return ds;
        }

        public static int GoodAcceptPast(int ID, int Flag, string Describle)
        {
            int result = DataProvider.Instance().GoodAcceptPast(ID, Flag, Describle);

            return result;
        }

        #endregion

        /// <summary>
        /// 挑战模式中结算比赛
        /// </summary>
        /// <param name="SeriaNo"></param>
        /// <param name="userId"></param>
        /// <param name="RegAmount"></param>
        /// <param name="ResAmount"></param>
        /// <param name="status"></param>
        /// <param name="battleTime"></param>
        /// <param name="curTime"></param>
        /// <param name="tbMoneyChange"></param>
        /// <param name="fam"></param>
        public static void MacthResult(string SeriaNo, int userId, double RegAmount, double ResAmount, int status, string battleTime, DateTime curTime, tbMoneyChangeEntity tbMoneyChange, tlOperateEntity fam)
        {
            DataProvider.Instance().MacthResult(SeriaNo, userId, RegAmount, ResAmount, status, battleTime, curTime, tbMoneyChange, fam);
        }

        /// <summary>
        /// 乱斗模式结算比赛
        /// </summary>
        /// <param name="SeriaNo"></param>
        /// <param name="userId"></param>
        /// <param name="RegAmount"></param>
        /// <param name="ResAmount"></param>
        /// <param name="status"></param>
        /// <param name="battleTime"></param>
        /// <param name="curTime"></param>
        /// <param name="tbMoneyChange"></param>
        /// <param name="fam"></param>
        public static void LuanDouSuccessMatch(string SeriaNo, string battleTime, DateTime curTime, tlOperateEntity fam)
        {
            DataProvider.Instance().LuanDouSuccessMatch(SeriaNo, battleTime, curTime, fam);
        }

        /// <summary>
        /// 占坑模式待结算比赛
        /// </summary>
        /// <param name="status"></param>
        /// <param name="SeriaNo"></param>
        /// <param name="battleTime"></param>
        /// <param name="curTime"></param>
        /// <param name="fam"></param>
        public static void ZhanKengSuccessMatch(int status, string SeriaNo, string battleTime, DateTime curTime, tlOperateEntity fam)
        {
            DataProvider.Instance().ZhanKengSuccessMatch(status, SeriaNo, battleTime, curTime, fam);
        }

        public static void MacthResult(string SeriaNo, int userId, double RegAmount, double ResAmount, int status, DateTime curTime, string feedback, tbMoneyChangeEntity tbMoneyChange, tlOperateEntity fam)
        {
            DataProvider.Instance().MacthResult(SeriaNo, userId, RegAmount, ResAmount, status, curTime, feedback, tbMoneyChange, fam);
        }

        public static int UpdateOrdersStatus(string comment, int status, string seriaNo)
        {
            return DataProvider.Instance().UpdateOrdersStatus(comment, status, seriaNo);
        }

        public static int UpdateExchangeStatus(string comment, int status, string seriaNo)
        {
            return DataProvider.Instance().UpdateExchangeStatus(comment, status, seriaNo);
        }

        public static int UserSendQuestion(string comment, int status, string seriaNo, tlOperateEntity fam)
        {
            return DataProvider.Instance().UserSendQuestion(comment, status, seriaNo, fam);
        }


        public static DataTable GetTopOrders(int top)
        {
            return DataProvider.Instance().GetTopOrders(top);
        }

        public static DataTable GetTopOrdersByBaoMing(int top)
        {
            return DataProvider.Instance().GetTopOrdersByBaoMing(top);
        }

        public static int givelecoin(double money, int userId, int id, tbGiveEntity tbGive, tbMoneyChangeEntity tbMoneyChange, tbMoneyChangeEntity tbMoneyChange1, tlOperateEntity fam)
        {
            int result = DataProvider.Instance().givelecoin(money, userId, id, tbGive, tbMoneyChange, tbMoneyChange1, fam);

            return result;
        }

        public static int UpdateFigureurl(int userId, string figureurl)
        {
            int result = DataProvider.Instance().UpdateFigureurl(userId, figureurl);

            return result;
        }

        public static int UpdateNickName(int userId, string nickName)
        {
            int result = DataProvider.Instance().UpdateNickName(userId, nickName);

            return result;
        }

        public static int UpdateQQ(int userId, string QQ)
        {
            int result = DataProvider.Instance().UpdateQQ(userId, QQ);

            return result;
        }

        public static DataTable GetUserByOpenId(string openId)
        {
            return DataProvider.Instance().GetUserByOpenId(openId);
        }

        public static List<tsRightLockAutoEntity> tsRightLockAutoList(QueryParam qp, out int RecordCount)
        {
            return DataProvider.Instance().tsRightLockAutoList(qp, out RecordCount);
        }

        public static int MobileTokenInsertUpdateDelete(tbMobileTokenEntity fam)
        {
            return DataProvider.Instance().MobileTokenInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 获取乱斗模式首页数据
        /// </summary>
        /// <returns></returns>
        public static DataSet luandou(string timeArea, string activityID)
        {
            return DataProvider.Instance().luandou(timeArea, activityID);
        }

        /// <summary>
        /// 查看往期
        /// </summary>
        /// <returns></returns>
        public static DataSet luckyzk()
        {
            return DataProvider.Instance().luckyzk();
        } 
        #endregion

 
	#endregion

        #region 小程序
        public static DataSet SendLevelOrder(int UserID, int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().SendLevelOrder(UserID, PageIndex, PageSize, Where);

            return ds;
        }

        public static DataSet ReceiveLevelOrder(int UserID, int PageIndex, int PageSize, string Where)
        {
            DataSet ds = DataProvider.Instance().ReceiveLevelOrder(UserID, PageIndex, PageSize, Where);

            return ds;
        }

        public static List<tbDifficultyEntity> tbDifficultytList(QueryParam qp, out int RecordCount)
        {
            return tbDifficultytList(qp, out RecordCount, null);
        }

        public static List<tbDifficultyEntity> tbDifficultytList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbDifficulty";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbDifficultyList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbDifficultyList(qp, out RecordCount, tran);
            }
        }

        #region "tbQuestions(题库) - Method"

        /// <summary>
        /// 新增/删除/修改 tsMemberEntity (用户成员)
        /// </summary>
        /// <param name="fam">tsMemberEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbQuestionsInsertUpdateDelete(tbQuestionsEntity fam)
        {
            return DataProvider.Instance().tbQuestionsInsertUpdateDelete(fam);
        }

        ///// <summary>
        ///// 新增/删除/修改 tsMemberEntity (用户成员)
        ///// </summary>
        ///// <param name="fam">tsMemberEntity实体类</param>
        ///// <param name="tran">tsMember事务</param>
        ///// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbQuestionsInsertUpdateDelete(tbQuestionsEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tbQuestionsInsertUpdateDelete(fam, tran);
        }

        /// <summary>
        /// 根据ID返回 tsMemberEntity实体类 单笔资料 (用户成员)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsMemberEntity实体类 ID为0则无记录</returns>
        public static tbQuestionsEntity tbQuestionsDisp(Int32 ID)
        {
            tbQuestionsEntity fam = new tbQuestionsEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbQuestions", "ID", ID);
            int RecordCount = 0;
            List<tbQuestionsEntity> lst = tbQuestionsList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }


        /// <summary>
        /// 根据ID返回 tsMemberEntity实体类 单笔资料 (用户成员)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsMember事务</param>
        /// <returns>返回 tsMemberEntity实体类 ID为0则无记录</returns>
        public static tbQuestionsEntity tbQuestionsDisp(Int32 ID, DbTransaction tran)
        {
            tbQuestionsEntity fam = new tbQuestionsEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbQuestions", "ID", ID);
            int RecordCount = 0;
            List<tbQuestionsEntity> lst = tbQuestionsList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsMemberEntity实体类的List对象 (用户成员)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>tsMemberEntity实体类的List对象(用户成员)</returns>
        public static List<tbQuestionsEntity> tbQuestionsList(QueryParam qp, out int RecordCount)
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
        public static List<tbQuestionsEntity> tbQuestionsList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbQuestions";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbQuestionsList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbQuestionsList(qp, out RecordCount, tran);
            }
        }
        #endregion


        #region "tbDifficulty(困难模式) - Method"

        /// <summary>
        /// 根据ID返回 tsGameEntity实体类 单笔资料 (游戏)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsGameEntity实体类 ID为0则无记录</returns>
        public static tbDifficultyEntity tbDifficultyDisp(Int32 ID)
        {
            tbDifficultyEntity fam = new tbDifficultyEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbDifficulty", "ID", ID);
            int RecordCount = 0;
            List<tbDifficultyEntity> lst = tbDifficultyList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 根据ID返回 tsGameEntity实体类 单笔资料 (游戏)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsGame事务</param>
        /// <returns>返回 tsGameEntity实体类 ID为0则无记录</returns>
        public static tbDifficultyEntity tbDifficultyDisp(Int32 ID, DbTransaction tran)
        {
            tbDifficultyEntity fam = new tbDifficultyEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbDifficulty", "ID", ID);
            int RecordCount = 0;
            List<tbDifficultyEntity> lst = tbDifficultyList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }
       
        /// <summary>
        /// 返回tsGameEntity实体类的List对象 (游戏)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsGame事务</param>        
        /// <returns>tsGameEntity实体类的List对象(游戏)</returns>
        public static List<tbDifficultyEntity> tbDifficultyList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbDifficulty";
           
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbDifficultyList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbDifficultyList(qp, out RecordCount, tran);
            }
        }
        #endregion


        #region "tbSubject(类别) - Method"

        /// <summary>
        /// 根据ID返回 tsGameEntity实体类 单笔资料 (游戏)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 tsGameEntity实体类 ID为0则无记录</returns>
        public static tbSubjectEntity tbSubjectDisp(Int32 ID)
        {
            tbSubjectEntity fam = new tbSubjectEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbAlbumType", "ID", ID);
            int RecordCount = 0;
            List<tbSubjectEntity> lst = tbSubjectList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 根据ID返回 tsGameEntity实体类 单笔资料 (游戏)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <param name="tran">tsGame事务</param>
        /// <returns>返回 tsGameEntity实体类 ID为0则无记录</returns>
        public static tbSubjectEntity tbSubjectDisp(Int32 ID, DbTransaction tran)
        {
            tbSubjectEntity fam = new tbSubjectEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbAlbumType", "ID", ID);
            int RecordCount = 0;
            List<tbSubjectEntity> lst = tbSubjectList(qp, out RecordCount, tran);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回tsGameEntity实体类的List对象 (游戏)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsGame事务</param>        
        /// <returns>tsGameEntity实体类的List对象(游戏)</returns>
        public static List<tbSubjectEntity> tbSubjectList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbAlbumType";

            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbSubjectList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbSubjectList(qp, out RecordCount, tran);
            }
        }

        public static Int32 tbSubjectInsertUpdateDelete(tbSubjectEntity fam)
        {
            return DataProvider.Instance().tbSubjectInsertUpdateDelete(fam);
        }

        ///// <summary>
        ///// 新增/删除/修改 tsMemberEntity (用户成员)
        ///// </summary>
        ///// <param name="fam">tsMemberEntity实体类</param>
        ///// <param name="tran">tsMember事务</param>
        ///// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 tbSubjectInsertUpdateDelete(tbSubjectEntity fam, DbTransaction tran)
        {
            return DataProvider.Instance().tbSubjectInsertUpdateDelete(fam, tran);
        }
        #endregion

        #region 相册

        public static List<tbAlbumEntity> tbAlbumList(QueryParam qp, out int RecordCount, DbTransaction tran)
        {
            qp.TableName = "tbAlbum";

            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            if (tran == null)
            {
                return DataProvider.Instance().tbAlbumList(qp, out RecordCount);
            }
            else
            {
                return DataProvider.Instance().tbAlbumList(qp, out RecordCount, tran);
            }
        }
   

        public static tbAlbumEntity tbAlbumDisp(Int32 ID)
        {
            tbAlbumEntity fam = new tbAlbumEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbAlbum", "ID", ID);
            int RecordCount = 0;
            List<tbAlbumEntity> lst = tbAlbumList(qp, out RecordCount, null);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        public static Int32 tbAlbumInsertUpdateDelete(tbAlbumEntity fam)
        {
            return DataProvider.Instance().tbAlbumInsertUpdateDelete(fam);
        }
        #endregion


        #region 图片
        public static List<tbImgEntity> tbImgList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "tbImg";

            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().tbImgList(qp, out RecordCount);
        }

        public static tbImgEntity tbImgDisp(Int32 ID)
        {
            tbImgEntity fam = new tbImgEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbImg", "ID", ID);
            int RecordCount = 0;
            List<tbImgEntity> lst = tbImgList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        public static Int32 tbImgInsertUpdateDelete(tbImgEntity fam)
        {
            return DataProvider.Instance().tbImgInsertUpdateDelete(fam);
        }

        public static DataTable tbFieldsList(string where)
        {
            return DataProvider.Instance().tbFieldsList(where);
        }

        public static Int32 tbFieldsInsertUpdateDelete(tbFieldsEntity fam)
        {
            return DataProvider.Instance().tbFieldsInsertUpdateDelete(fam);
        }

        public static tbFieldsEntity tbFieldsDisp(Int32 ID)
        {
            tbFieldsEntity fam = new tbFieldsEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbFields", "ID", ID);
            int RecordCount = 0;
            List<tbFieldsEntity> lst = tbFieldsList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        public static List<tbFieldsEntity> tbFieldsList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "tbFields";

            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().tbFieldsList(qp, out RecordCount);
        }


        public static List<tbValuesEntity> tbValuesList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "tbValues";

            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().tbValuesList(qp, out RecordCount);
        }

        public static tbValuesEntity tbValuesDisp(Int32 ID)
        {
            tbValuesEntity fam = new tbValuesEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "tbValues", "ID", ID);
            int RecordCount = 0;
            List<tbValuesEntity> lst = tbValuesList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        public static Int32 tbValuesInsertUpdateDelete(tbValuesEntity fam)
        {
            return DataProvider.Instance().tbValuesInsertUpdateDelete(fam);
        }
        

        /// <summary>
        /// 返回tsMemberEntity实体类的List对象 (用户成员)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <param name="tran">tsMember事务</param>        
        /// <returns>tsMemberEntity实体类的List对象(用户成员)</returns>
        public static List<tbSubmissionEntity> tbSubmissionList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "tbSynthetic";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().tbSubmissionList(qp, out RecordCount);
        }
        #endregion

        #endregion
    }
}
