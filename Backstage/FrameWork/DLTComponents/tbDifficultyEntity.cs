using FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLT.Components
{
    ///<summary>
    ///tbDifficultyEntity实体类(困难模式)
    ///</summary>
    [Serializable]
    public partial class tbDifficultyEntity
    {
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0;
        private String _DifficultyName = "";
        private Int32 _Sort = 0;
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
        public Int32 ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }

        public String DifficultyName
        {
            set { this._DifficultyName = value; }
            get { return this._DifficultyName; }
        }

        /// <summary>
        /// Sort
        /// </summary>
        public Int32 Sort
        {
            set { this._Sort = value; }
            get { return this._Sort; }
        }
    }
}
