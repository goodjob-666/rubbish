/********************************************************************************
    File:
          tsCreditEvalEntity.cs
    Description:
          信用评价实体类
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
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tsCreditEvalEntity实体类(信用评价)
    ///</summary>
    [Serializable]
    public partial class tsCreditEvalEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID=0; // 用户ID
        private Int16 _EvalDirect=0; // 评价方向
        private Int32 _Beautifully=0; // 非常满意
        private Int32 _Good=0; // 满意
        private Int32 _Normal=0; // 一般
        private Int32 _Poor=0; // 很差
        private Int64 _Score=0; // 信用总分
        private Int32 _Level=0; // 信用等级
        #endregion

        #region "Public Variables"
        ///<summary>
        /// 操作方法 Insert:增加 Update:修改 Delete:删除
        ///</summary>
        public DataTable_Action DataTable_Action_
        {
            set { this._DataTable_Action_ = value; }
            get { return this._DataTable_Action_; }
        }
        /// <summary>
        /// ID
        /// </summary>
        public Int32  ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }
            
        /// <summary>
        /// 用户ID
        /// </summary>
        public Int32  UserID
        {
            set { this._UserID = value; }
            get { return this._UserID; }
        }
            
        /// <summary>
        /// 评价方向
        /// </summary>
        public Int16  EvalDirect
        {
            set { this._EvalDirect = value; }
            get { return this._EvalDirect; }
        }
            
        /// <summary>
        /// 非常满意
        /// </summary>
        public Int32  Beautifully
        {
            set { this._Beautifully = value; }
            get { return this._Beautifully; }
        }
            
        /// <summary>
        /// 满意
        /// </summary>
        public Int32  Good
        {
            set { this._Good = value; }
            get { return this._Good; }
        }
            
        /// <summary>
        /// 一般
        /// </summary>
        public Int32  Normal
        {
            set { this._Normal = value; }
            get { return this._Normal; }
        }
            
        /// <summary>
        /// 很差
        /// </summary>
        public Int32  Poor
        {
            set { this._Poor = value; }
            get { return this._Poor; }
        }
            
        /// <summary>
        /// 信用总分
        /// </summary>
        public Int64  Score
        {
            set { this._Score = value; }
            get { return this._Score; }
        }
            
        /// <summary>
        /// 信用等级
        /// </summary>
        public Int32  Level
        {
            set { this._Level = value; }
            get { return this._Level; }
        }
            
        #endregion
    }
}
  