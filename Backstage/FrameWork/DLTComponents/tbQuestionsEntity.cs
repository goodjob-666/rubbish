/********************************************************************************
    File:
          tsMemberEntity.cs
    Description:
          用户成员实体类
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
    ///tbQuestionsEntity实体类(用户成员)
    ///</summary>
    [Serializable]
    public partial class tbQuestionsEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _Difficulty = 0;
        private String _Title = "";
        private String _A = "";
        private String _B = "";
        private String _C = "";
        private String _D = "";
        private Int32 _SubjectType = 0;
        private String _Answer = ""; 
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

        public Int32 Difficulty
        {
            set { this._Difficulty = value; }
            get { return this._Difficulty; }
        }

        public String Title
        {
            set { this._Title = value; }
            get { return this._Title; }
        }

        public String A
        {
            set { this._A = value; }
            get { return this._A; }
        }

        public String B
        {
            set { this._B = value; }
            get { return this._B; }
        }

        public String C
        {
            set { this._C = value; }
            get { return this._C; }
        }

        public String D
        {
            set { this._D = value; }
            get { return this._D; }
        }

        public Int32 SubjectType
        {
            set { this._SubjectType = value; }
            get { return this._SubjectType; }
        }

        public String Answer
        {
            set { this._Answer = value; }
            get { return this._Answer; }
        }

        #endregion
    }
}
  