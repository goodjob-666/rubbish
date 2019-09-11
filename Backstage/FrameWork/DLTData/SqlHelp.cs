
using System;
using System.Configuration;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;

namespace DLT.Data
{
	/// <summary>
	/// 数据库交互类
	/// </summary>	
	public sealed class SqlHelp
	{
		#region private utility methods & constructors

		/// <summary>
		/// 构造函数
		/// </summary>
        private SqlHelp() { }

		/// <summary>
		/// 添减SqlParameter数组到SqlCommand		
		/// </summary>
		/// <param name="voSqlCommand">被添加的SqlCommand</param>
		/// <param name="voCommandParameters">需要添加的SqlParameter</param>
		private static void AttachParameters(SqlCommand voSqlCommand, SqlParameter[] voCommandParameters)
		{
			foreach (SqlParameter oSqlParameter in voCommandParameters)
			{
				if ((oSqlParameter.Direction == ParameterDirection.InputOutput) && (oSqlParameter.Value == null))
				{
					oSqlParameter.Value = DBNull.Value;
				}
				
				voSqlCommand.Parameters.Add(oSqlParameter);
			}
		}

		/// <summary>
		/// 将对象数组转换为SqlParameters数组.
		/// </summary>
		/// <param name="voCommandParameters">SqlParameters数组</param>
		/// <param name="voParameterValues">对象数组</param>
		public static void AssignParameterValues(SqlParameter[] voCommandParameters, object[] voParameterValues)
		{
			if ((voCommandParameters == null) || (voParameterValues == null)) 
			{				
				return;
			}
			
			if (voCommandParameters.Length != voParameterValues.Length)
			{
				throw new ArgumentException("Parameter count does not match Parameter voValue count.");
			}

			for (int i = 0, j = voCommandParameters.Length; i < j; i++)
			{
				voCommandParameters[i].Value = voParameterValues[i];
			}
		}

		/// <summary>
		/// 初始化SqlCommand对象
		/// </summary>
		/// <param name="voSqlCommand">被初始化的SqlCommand</param>
		/// <param name="voSqlConnection">SqlConnection参数</param>
		/// <param name="voSqlTransaction">SqlTransaction参数</param>
		/// <param name="voCommandType">voCommandType参数</param>
		/// <param name="vstrCommandText">存储过程名字或T-SQL命令</param>
		/// <param name="voCommandParameters">SqlParameters数组参数</param>
		private static void PrepareCommand(SqlCommand voSqlCommand, SqlConnection voSqlConnection, SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText, SqlParameter[] voCommandParameters)
		{			
			if (voSqlConnection.State != ConnectionState.Open)
			{
				voSqlConnection.Open();
			}
					
			voSqlCommand.Connection = voSqlConnection;

			voSqlCommand.CommandText = vstrCommandText;
			voSqlCommand.CommandTimeout = 600;

			if (voSqlTransaction != null)
			{
				voSqlCommand.Transaction = voSqlTransaction;
			}

			voSqlCommand.CommandType = voCommandType;

			if (voCommandParameters != null)
			{
				AttachParameters(voSqlCommand, voCommandParameters);
			}

			return;
		}

		#endregion private utility methods & constructors

		#region AddParameters

		/// <summary>
		/// 判断字符串是否为空
		/// </summary>
		/// <param name="vstrText">被判断的字符串</param>
		/// <returns>空或者字符串</returns>
		public static object CheckForNullString(string vstrText)
		{
			if(vstrText == null || vstrText.Trim().Length == 0)
			{
				return System.DBNull.Value;
			}
			else
			{
				return vstrText;
			}
		}

		/// <summary>
		/// 生成输入的SqlParameter对象
		/// </summary>
		/// <param name="vstrParamName">参数名</param>
		/// <param name="voValue">参数值</param>
		/// <returns>生成的对象</returns>
		public static SqlParameter MakeInParam(string vstrParamName, object voValue)
		{
			return new SqlParameter(vstrParamName,voValue);
		}

		/// <summary>
		/// 生成输入的SqlParameter对象
		/// </summary>
		/// <param name="vstrParamName">参数名</param>
		/// <param name="voSqlDbType">参数类型</param>
		/// <param name="viSize">参数大小</param>
		/// <param name="voValue">参数值</param>
		/// <returns>生成的对象</returns>
		public static SqlParameter MakeInParam(string vstrParamName, SqlDbType voSqlDbType, int viSize, object voValue) 
		{
			return MakeParam(vstrParamName, voSqlDbType, viSize, ParameterDirection.Input, voValue);
		}		

		/// <summary>
		/// 生成输出的SqlParameter对象
		/// </summary>
		/// <param name="vstrParamName">参数名</param>
		/// <param name="voSqlDbType">参数类型</param>
		/// <param name="viSize">参数大小</param>
		/// <returns>生成的对象</returns>
		public static SqlParameter MakeOutParam(string vstrParamName, SqlDbType voSqlDbType, int viSize) 
		{
			return MakeParam(vstrParamName, voSqlDbType, viSize, ParameterDirection.Output, null);
		}		

		/// <summary>
		/// 生成SqlParameter对象
		/// </summary>
		/// <param name="vstrParamName">参数名</param>
		/// <param name="voSqlDbType">参数类型</param>
		/// <param name="viSize">参数大小</param>
		/// <param name="Direction">输出还是输入</param>
		/// <param name="voValue">参数值</param>
		/// <returns>生成的对象</returns>
		public static SqlParameter MakeParam(string vstrParamName, SqlDbType voSqlDbType, Int32 viSize, ParameterDirection Direction, object voValue) 
		{
			SqlParameter oSqlParameter;

			if(viSize > 0)
				oSqlParameter = new SqlParameter(vstrParamName, voSqlDbType, viSize);
			else
				oSqlParameter = new SqlParameter(vstrParamName, voSqlDbType);

			oSqlParameter.Direction = Direction;
			if (!(Direction == ParameterDirection.Output && voValue == null))
				oSqlParameter.Value = voValue;

			return oSqlParameter;
		}
	

		#endregion

		#region ExecuteNonQuery

		/// <summary>
		/// 执行没有查询的SQL语句
		/// </summary>		
		/// <remarks>
		/// 例如：
		///  int result = ExecuteNonQuery(connString, voCommandType.StoredProcedure, "PublishOrders")
		///  </remarks>
		/// <param name="vstrConnectionString">数据库链接字符串</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>SQL语句影响的数据行数</returns>
		public static int ExecuteNonQuery(string vstrConnectionString, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteNonQuery(vstrConnectionString, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行没有查询的SQL语句
		/// </summary>
		/// <remarks>
		/// 例如：
		///  int result = ExecuteNonQuery(connString, voCommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="vstrConnectionString">数据库链接字符串</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>SQL语句影响的数据行数</returns>
		public static int ExecuteNonQuery(string vstrConnectionString, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			using (SqlConnection oSqlConnection = new SqlConnection(vstrConnectionString))
			{
				oSqlConnection.Open();
		
				return ExecuteNonQuery(oSqlConnection, voCommandType, vstrCommandText, voCommandParameters);
			}
		}

		/// <summary>
		/// 执行没有查询的SQL语句
		/// </summary>
		/// <remarks>
		/// 例如：
		///  int result = ExecuteNonQuery(conn, voCommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>SQL语句影响的数据行数</returns>
		public static int ExecuteNonQuery(SqlConnection voSqlConnection, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteNonQuery(voSqlConnection, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行没有查询的SQL语句
		/// </summary>
		/// <remarks>
		/// 例如：
		///  int result = ExecuteNonQuery(conn, voCommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>SQL语句影响的数据行数</returns>
		public static int ExecuteNonQuery(SqlConnection voSqlConnection, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{				
			SqlCommand oSqlCommand = new SqlCommand();
			PrepareCommand(oSqlCommand, voSqlConnection, (SqlTransaction)null, voCommandType, vstrCommandText, voCommandParameters);
						
			int iRetval = oSqlCommand.ExecuteNonQuery();
						
			oSqlCommand.Parameters.Clear();
			return iRetval;
		}

	
		/// <summary>
		/// 执行没有查询的SQL语句
		/// </summary>
		/// <remarks>
		/// 例如：
		///  int result = ExecuteNonQuery(trans, voCommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>SQL语句影响的数据行数</returns>
		public static int ExecuteNonQuery(SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteNonQuery(voSqlTransaction, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行没有查询的SQL语句
		/// </summary>
		/// <remarks>
		/// 例如：
		///  int result = ExecuteNonQuery(trans, voCommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>SQL语句影响的数据行数</returns>
		public static int ExecuteNonQuery(SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			SqlCommand oSqlCommand = new SqlCommand();
			PrepareCommand(oSqlCommand, voSqlTransaction.Connection, voSqlTransaction, voCommandType, vstrCommandText, voCommandParameters);
					
			int iRetval = oSqlCommand.ExecuteNonQuery();
						
			oSqlCommand.Parameters.Clear();
			return iRetval;
		}

	


		#endregion ExecuteNonQuery

		#region ExecuteDataSet

		/// <summary>
		/// 执行查询的SQL语句返回DataSet
		/// </summary>
		/// <remarks>
		/// 例如：
		///  DataSet oDataSet = ExecuteDataset(connString, voCommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="vstrConnectionString">数据库链接字符串</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static DataSet ExecuteDataset(string vstrConnectionString, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteDataset(vstrConnectionString, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行查询的SQL语句返回DataSet
		/// </summary>
		/// <remarks>
		/// 例如：
		///  DataSet oDataSet = ExecuteDataset(connString, voCommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="vstrConnectionString">数据库链接字符串</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static DataSet ExecuteDataset(string vstrConnectionString, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			using (SqlConnection oSqlConnection = new SqlConnection(vstrConnectionString))
			{
				return ExecuteDataset(oSqlConnection, voCommandType, vstrCommandText, voCommandParameters);
			}
		}



		/// <summary>
		/// 执行查询的SQL语句返回DataSet
		/// </summary>
		/// <remarks>
		/// 例如：
		///  DataSet oDataSet = ExecuteDataset(conn, voCommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static DataSet ExecuteDataset(SqlConnection voSqlConnection, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteDataset(voSqlConnection, voCommandType, vstrCommandText, (SqlParameter[])null);
		}
		
		/// <summary>
		/// 执行查询的SQL语句返回DataSet
		/// </summary>
		/// <remarks>
		/// 例如：
		///  DataSet oDataSet = ExecuteDataset(conn, voCommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static DataSet ExecuteDataset(SqlConnection voSqlConnection, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			SqlCommand oSqlCommand = new SqlCommand();
			PrepareCommand(oSqlCommand, voSqlConnection, (SqlTransaction)null, voCommandType, vstrCommandText, voCommandParameters);
					
			SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
			DataSet oDataSet = new DataSet();
			
			oSqlDataAdapter.Fill(oDataSet);
			
			oSqlCommand.Parameters.Clear();
						
			return oDataSet;						
		}
		

		/// <summary>
		/// 执行查询的SQL语句返回DataSet
		/// </summary>
		/// <remarks>
		/// 例如：
		///  DataSet oDataSet = ExecuteDataset(trans, voCommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static DataSet ExecuteDataset(SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteDataset(voSqlTransaction, voCommandType, vstrCommandText, (SqlParameter[])null);
		}
		
		/// <summary>
		/// 执行查询的SQL语句返回DataSet
		/// </summary>
		/// <remarks>
		/// 例如：
		///  DataSet oDataSet = ExecuteDataset(trans, voCommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static DataSet ExecuteDataset(SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			SqlCommand oSqlCommand = new SqlCommand();
			PrepareCommand(oSqlCommand, voSqlTransaction.Connection, voSqlTransaction, voCommandType, vstrCommandText, voCommandParameters);
		
			SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
			DataSet oDataSet = new DataSet();
	
			oSqlDataAdapter.Fill(oDataSet);
			
			oSqlCommand.Parameters.Clear();
						
			return oDataSet;
		}
		


		#endregion ExecuteDataSet

		#region ExecuteDataTable

		/// <summary>
		/// 执行查询的SQL语句返回DataTable
		/// </summary>
		/// <remarks>
		/// 例如：
		///  DataTable oDataTable = ExecuteDataTable(connString, voCommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="vstrConnectionString">数据库链接字符串</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static DataTable ExecuteDataTable(string vstrConnectionString, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteDataTable(vstrConnectionString, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行查询的SQL语句返回DataTable
		/// </summary>
		/// <remarks>
		/// 例如：
		///  DataTable oDataTable = ExecuteDataTable(connString, voCommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="vstrConnectionString">数据库链接字符串</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static DataTable ExecuteDataTable(string vstrConnectionString, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			using (SqlConnection oSqlConnection = new SqlConnection(vstrConnectionString))
			{
				oSqlConnection.Open();
		
				return ExecuteDataTable(oSqlConnection, voCommandType, vstrCommandText, voCommandParameters);
			}
		}

		/// <summary>
		/// 执行查询的SQL语句返回DataTable
		/// </summary>
		/// <remarks>
		/// 例如：
		///  DataTable oDataTable = ExecuteDataTable(conn, voCommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static DataTable ExecuteDataTable(SqlConnection voSqlConnection, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteDataTable(voSqlConnection, voCommandType, vstrCommandText, (SqlParameter[])null);
		}
		
		/// <summary>
		/// 执行查询的SQL语句返回DataTable
		/// </summary>
		/// <remarks>
		/// 例如：
		///  DataTable oDataTable = ExecuteDataTable(conn, voCommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static DataTable ExecuteDataTable(SqlConnection voSqlConnection, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			SqlCommand oSqlCommand = new SqlCommand();
			PrepareCommand(oSqlCommand, voSqlConnection, (SqlTransaction)null, voCommandType, vstrCommandText, voCommandParameters);
					
			SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                 //Ver 1.0.0 UPDATE START ZhangWenXue 2011/7/1*/
			DataTable oDataTable = new DataTable("dt"); 
		
			oSqlDataAdapter.Fill(oDataTable);
			
			oSqlCommand.Parameters.Clear();
						
			return oDataTable;						
		}
		
		/// <summary>
		/// 执行查询的SQL语句返回DataTable
		/// </summary>
		/// <remarks>
		/// 例如：
		///  DataTable oDataTable = ExecuteDataTable(trans, voCommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static DataTable ExecuteDataTable(SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteDataTable(voSqlTransaction, voCommandType, vstrCommandText, (SqlParameter[])null);
		}
		
		/// <summary>
		/// 执行查询的SQL语句返回DataTable
		/// </summary>
		/// <remarks>
		/// 例如：
		///  DataTable oDataTable = ExecuteDataTable(trans, voCommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static DataTable ExecuteDataTable(SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			SqlCommand oSqlCommand = new SqlCommand();
			PrepareCommand(oSqlCommand, voSqlTransaction.Connection, voSqlTransaction, voCommandType, vstrCommandText, voCommandParameters);
					
			SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
			DataTable oDataTable = new DataTable();
			
			oSqlDataAdapter.Fill(oDataTable);
			
			oSqlCommand.Parameters.Clear();
						
			return oDataTable;
		}
		


		#endregion ExecuteDataTable
		
		#region ExecuteReader

		/// <summary>
		/// voSqlConnection提供类型
		/// </summary>
		private enum SqlConnectionOwnership	
		{
			/// <summary>SqlHelper提供</summary>
			Internal, 
			/// <summary>调用者提供</summary>
			External
		}

		/// <summary>
		/// 执行查询的SQL语句返回SqlDataReader
		/// </summary>		
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <param name="connectionOwnership">提供类型</param>
		/// <returns>查询结果</returns>
		private static SqlDataReader ExecuteReader(SqlConnection voSqlConnection, SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText, SqlParameter[] voCommandParameters, SqlConnectionOwnership connectionOwnership)
		{				
			SqlCommand oSqlCommand = new SqlCommand();
			PrepareCommand(oSqlCommand, voSqlConnection, voSqlTransaction, voCommandType, vstrCommandText, voCommandParameters);
						
			SqlDataReader oSqlDataReader;
			
			if (connectionOwnership == SqlConnectionOwnership.External)
			{
				oSqlDataReader = oSqlCommand.ExecuteReader();
			}
			else
			{
				oSqlDataReader = oSqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			}
			
			oSqlCommand.Parameters.Clear();
			
			return oSqlDataReader;
		}

		/// <summary>
		/// 执行查询的SQL语句返回SqlDataReader
		/// </summary>
		/// <remarks>
		/// 例如：
		///  SqlDataReader oSqlDataReader = ExecuteReader(connString, voCommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="vstrConnectionString">数据库链接字符串</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static SqlDataReader ExecuteReader(string vstrConnectionString, CommandType voCommandType, string vstrCommandText)
		{		
			return ExecuteReader(vstrConnectionString, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行查询的SQL语句返回SqlDataReader
		/// </summary>
		/// <remarks>
		/// 例如：
		///  SqlDataReader oSqlDataReader = ExecuteReader(connString, voCommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="vstrConnectionString">数据库链接字符串</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static SqlDataReader ExecuteReader(string vstrConnectionString, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			SqlConnection oSqlConnection = new SqlConnection(vstrConnectionString);
			oSqlConnection.Open();

			try
			{		
				return ExecuteReader(oSqlConnection, null, voCommandType, vstrCommandText, voCommandParameters,SqlConnectionOwnership.Internal);
			}
			catch
			{			
				oSqlConnection.Close();
				throw;
			}
		}

		/// <summary>
		/// 执行查询的SQL语句返回SqlDataReader
		/// </summary>
		/// <remarks>
		/// 例如：
		///  SqlDataReader oSqlDataReader = ExecuteReader(conn, voCommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static SqlDataReader ExecuteReader(SqlConnection voSqlConnection, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteReader(voSqlConnection, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行查询的SQL语句返回SqlDataReader
		/// </summary>
		/// <remarks>
		/// 例如：
		///  SqlDataReader oSqlDataReader = ExecuteReader(conn, voCommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static SqlDataReader ExecuteReader(SqlConnection voSqlConnection, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			return ExecuteReader(voSqlConnection, (SqlTransaction)null, voCommandType, vstrCommandText, voCommandParameters, SqlConnectionOwnership.External);
		}

	
		/// <summary>
		/// 执行查询的SQL语句返回SqlDataReader
		/// </summary>
		/// <remarks>
		/// 例如：
		///  SqlDataReader oSqlDataReader = ExecuteReader(trans, voCommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static SqlDataReader ExecuteReader(SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteReader(voSqlTransaction, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行查询的SQL语句返回SqlDataReader
		/// </summary>
		/// <remarks>
		/// 例如：
		///   SqlDataReader oSqlDataReader = ExecuteReader(trans, voCommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static SqlDataReader ExecuteReader(SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			return ExecuteReader(voSqlTransaction.Connection, voSqlTransaction, voCommandType, vstrCommandText, voCommandParameters, SqlConnectionOwnership.External);
		}

		#endregion ExecuteReader

		#region ExecuteScalar
		
		/// <summary>
		/// 执行查询的SQL语句返回object
		/// </summary>
		/// <remarks>
		/// 例如：
		///  int orderCount = (int)ExecuteScalar(connString, voCommandType.StoredProcedure, "GetOrderCount");
		/// </remarks>
		/// <param name="vstrConnectionString">数据库链接字符串</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static object ExecuteScalar(string vstrConnectionString, CommandType voCommandType, string vstrCommandText)
		{
			return ExecuteScalar(vstrConnectionString, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行查询的SQL语句返回object
		/// </summary>
		/// <remarks>
		/// 例如：
		///  int orderCount = (int)ExecuteScalar(connString, voCommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="vstrConnectionString">数据库链接字符串</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static object ExecuteScalar(string vstrConnectionString, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{		
			using (SqlConnection oSqlConnection = new SqlConnection(vstrConnectionString))
			{
				oSqlConnection.Open();
		
				return ExecuteScalar(oSqlConnection, voCommandType, vstrCommandText, voCommandParameters);
			}
		}

		/// <summary>
		/// 执行查询的SQL语句返回object
		/// </summary>
		/// <remarks>
		/// 例如：
		///  int orderCount = (int)ExecuteScalar(conn, voCommandType.StoredProcedure, "GetOrderCount");
		/// </remarks>
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static object ExecuteScalar(SqlConnection voSqlConnection, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteScalar(voSqlConnection, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行查询的SQL语句返回object
		/// </summary>
		/// <remarks>
		/// 例如：
		///  int orderCount = (int)ExecuteScalar(conn, voCommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static object ExecuteScalar(SqlConnection voSqlConnection, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			SqlCommand oSqlCommand = new SqlCommand();
			PrepareCommand(oSqlCommand, voSqlConnection, (SqlTransaction)null, voCommandType, vstrCommandText, voCommandParameters);
					
			object oRetval = oSqlCommand.ExecuteScalar();
						
			oSqlCommand.Parameters.Clear();
			return oRetval;
			
		}

		/// <summary>
		/// 执行查询的SQL语句返回object
		/// </summary>
		/// <remarks>
		/// 例如：
		///  int orderCount = (int)ExecuteScalar(trans, voCommandType.StoredProcedure, "GetOrderCount");
		/// </remarks>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static object ExecuteScalar(SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteScalar(voSqlTransaction, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行查询的SQL语句返回object
		/// </summary>
		/// <remarks>
		/// 例如：
		///  int orderCount = (int)ExecuteScalar(trans, voCommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static object ExecuteScalar(SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			SqlCommand oSqlCommand = new SqlCommand();
			PrepareCommand(oSqlCommand, voSqlTransaction.Connection, voSqlTransaction, voCommandType, vstrCommandText, voCommandParameters);
						
			object oRetval = oSqlCommand.ExecuteScalar();
						
			oSqlCommand.Parameters.Clear();
			return oRetval;
		}

	
		#endregion ExecuteScalar	

		#region ExecuteXmlReader

		/// <summary>
		/// 执行查询的SQL语句返回XmlReader
		/// </summary>
		/// <remarks>
		/// 例如：
		///  XmlReader r = ExecuteXmlReader(conn, voCommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static XmlReader ExecuteXmlReader(SqlConnection voSqlConnection, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteXmlReader(voSqlConnection, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行查询的SQL语句返回XmlReader
		/// </summary>
		/// <remarks>
		/// 例如：
		///  XmlReader r = ExecuteXmlReader(conn, voCommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="voSqlConnection">数据库链接</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static XmlReader ExecuteXmlReader(SqlConnection voSqlConnection, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			SqlCommand oSqlCommand = new SqlCommand();
			PrepareCommand(oSqlCommand, voSqlConnection, (SqlTransaction)null, voCommandType, vstrCommandText, voCommandParameters);
						
			XmlReader oXmlReader = oSqlCommand.ExecuteXmlReader();
						
			oSqlCommand.Parameters.Clear();
			return oXmlReader;
			
		}

	
		/// <summary>
		/// 执行查询的SQL语句返回XmlReader
		/// </summary>
		/// <remarks>
		/// 例如：
		///  XmlReader r = ExecuteXmlReader(trans, voCommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <returns>查询结果</returns>
		public static XmlReader ExecuteXmlReader(SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText)
		{			
			return ExecuteXmlReader(voSqlTransaction, voCommandType, vstrCommandText, (SqlParameter[])null);
		}

		/// <summary>
		/// 执行查询的SQL语句返回XmlReader
		/// </summary>
		/// <remarks>
		/// 例如：
		///  XmlReader r = ExecuteXmlReader(trans, voCommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="voSqlTransaction">事务</param>
		/// <param name="voCommandType">命令类型</param>
		/// <param name="vstrCommandText">存储过程名或T-SQL命令</param>
		/// <param name="voCommandParameters">参数</param>
		/// <returns>查询结果</returns>
		public static XmlReader ExecuteXmlReader(SqlTransaction voSqlTransaction, CommandType voCommandType, string vstrCommandText, params SqlParameter[] voCommandParameters)
		{			
			SqlCommand oSqlCommand = new SqlCommand();
			PrepareCommand(oSqlCommand, voSqlTransaction.Connection, voSqlTransaction, voCommandType, vstrCommandText, voCommandParameters);
					
			XmlReader oXmlReader = oSqlCommand.ExecuteXmlReader();
						
			oSqlCommand.Parameters.Clear();
			return oXmlReader;			
		}

	
		#endregion ExecuteXmlReader
	}
}
