using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// ���ݷ�����:CMS_FriendLink
	/// </summary>
	public partial class CMS_FriendLink
	{
		public CMS_FriendLink()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "CMS_FriendLink"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CMS_FriendLink");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Maticsoft.Model.CMS_FriendLink model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CMS_FriendLink(");
			strSql.Append("Title,IsPic,PicUrl,SiteUrl,Sort)");
			strSql.Append(" values (");
			strSql.Append("@Title,@IsPic,@PicUrl,@SiteUrl,@Sort)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@IsPic", SqlDbType.Bit,1),
					new SqlParameter("@PicUrl", SqlDbType.VarChar,100),
					new SqlParameter("@SiteUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Sort", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.IsPic;
			parameters[2].Value = model.PicUrl;
			parameters[3].Value = model.SiteUrl;
			parameters[4].Value = model.Sort;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Maticsoft.Model.CMS_FriendLink model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CMS_FriendLink set ");
			strSql.Append("Title=@Title,");
			strSql.Append("IsPic=@IsPic,");
			strSql.Append("PicUrl=@PicUrl,");
			strSql.Append("SiteUrl=@SiteUrl,");
			strSql.Append("Sort=@Sort");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@IsPic", SqlDbType.Bit,1),
					new SqlParameter("@PicUrl", SqlDbType.VarChar,100),
					new SqlParameter("@SiteUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.IsPic;
			parameters[2].Value = model.PicUrl;
			parameters[3].Value = model.SiteUrl;
			parameters[4].Value = model.Sort;
			parameters[5].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CMS_FriendLink ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CMS_FriendLink ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Maticsoft.Model.CMS_FriendLink GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Title,IsPic,PicUrl,SiteUrl,Sort from CMS_FriendLink ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			Maticsoft.Model.CMS_FriendLink model=new Maticsoft.Model.CMS_FriendLink();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["IsPic"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsPic"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsPic"].ToString().ToLower()=="true"))
					{
						model.IsPic=true;
					}
					else
					{
						model.IsPic=false;
					}
				}
				model.PicUrl=ds.Tables[0].Rows[0]["PicUrl"].ToString();
				model.SiteUrl=ds.Tables[0].Rows[0]["SiteUrl"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,Title,IsPic,PicUrl,SiteUrl,Sort ");
			strSql.Append(" FROM CMS_FriendLink ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append("order by Sort");//�Լ��ӵ��߼�����Ϊÿ����Ҫ��Sort����
            return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,Title,IsPic,PicUrl,SiteUrl,Sort ");
			strSql.Append(" FROM CMS_FriendLink ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /*
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "CMS_FriendLink";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="IsUp">���ƻ�������</param>
        public static void SetSort(int id, bool IsUp)
        {
            SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@Id", id),
                new SqlParameter("@IsUp", IsUp ? 1 : 0)
            };
            DbHelperSQL.RunProcedure("SetFriendSort", pars);
        }
        #endregion  Method
    }
}
