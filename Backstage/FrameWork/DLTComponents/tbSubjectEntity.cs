using FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLT.Components
{
    ///<summary>
    ///tbSubjectEntity实体类(类别)
    ///</summary>
    [Serializable]
    public partial class tbSubjectEntity
    {
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0;
        private String _Name = "";
        private Int32 _OrderBy = 0;

        ///<summary>
        /// 操作方法 Insert:增加 Update:修改 Delete:删除
        ///</summary>
        public DataTable_Action DataTable_Action_
        {
            set { this._DataTable_Action_ = value; }
            get { return this._DataTable_Action_; }
        }

        public Int32 ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }

        public String Name
        {
            set { this._Name = value; }
            get { return this._Name; }
        }

        public Int32 OrderBy
        {
            set { this._OrderBy = value; }
            get { return this._OrderBy; }
        }
    }
}
