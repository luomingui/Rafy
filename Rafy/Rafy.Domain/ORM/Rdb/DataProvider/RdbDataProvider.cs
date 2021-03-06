﻿/*******************************************************
 * 
 * 作者：胡庆访
 * 创建日期：20150313
 * 运行环境：.NET 4.5
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20150313 23:20
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rafy.Data;
using Rafy.ManagedProperty;

namespace Rafy.Domain.ORM
{
    /// <summary>
    /// 本类是为关系型数据库设计的数据提供器。
    /// IRepositoryDataProvider 则是更通用的接口。
    /// </summary>
    public class RdbDataProvider : RepositoryDataProvider, IDbConnector
    {
        public RdbDataProvider()
        {
            this.DataSaver = new RdbDataSaver();
            this.DataQueryer = new RdbDataQueryer();
        }

        /// <summary>
        /// 数据的保存器。
        /// </summary>
        public new RdbDataSaver DataSaver
        {
            get { return base.DataSaver as RdbDataSaver; }
            set { base.DataSaver = value; }
        }

        /// <summary>
        /// 数据的查询器。
        /// </summary>
        public new RdbDataQueryer DataQueryer
        {
            get { return base.DataQueryer as RdbDataQueryer; }
            set { base.DataQueryer = value; }
        }

        #region 数据库配置

        private DbSetting _dbSetting;
        /// <summary>
        /// 这个字段用于存储运行时解析出来的 ORM 信息。
        /// </summary>
        private RdbTable _ormTable;

        /// <summary>
        /// 创建数据库操作对象
        /// </summary>
        /// <returns></returns>
        public IDbAccesser CreateDbAccesser()
        {
            return DbAccesserFactory.Create(this.DbSetting);
        }

        /// <summary>
        /// 数据库配置（每个库有一个唯一的配置名）
        /// </summary>
        public DbSetting DbSetting
        {
            get
            {
                if (this._dbSetting == null)
                {
                    var conSetting = this.ConnectionStringSettingName;
                    if (conSetting == null) throw new InvalidProgramException("数据库配置属性重写有误，不能返回 null。");
                    this._dbSetting = DbSetting.FindOrCreate(conSetting);
                }
                return this._dbSetting;
            }
        }

        ///// <summary>
        ///// 获取该实体对应的 ORM 运行时对象。
        ///// 
        ///// 如果该实体没有对应的实体元数据或者该实体没有被配置为映射数据库，
        ///// 则本方法则无法创建对应的 ORM 运行时，此时会返回 null。
        ///// </summary>
        ///// <returns></returns>
        //public ITable GetDbTable()
        //{
        //    return this.DbTable;
        //}

        internal RdbTable DbTable
        {
            get
            {
                if (_ormTable == null && this.Repository.EntityMeta != null)
                {
                    _ormTable = RdbTableFactory.CreateORMTable(this.Repository);
                }

                return _ormTable;
            }
        }

        #endregion

        #region 查询

        /// <summary>
        /// 子类重写此方法，来实现自己的 GetEntityValue 方法的数据层代码。
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public override LiteDataTable GetEntityValue(object entityId, string property)
        {
            var table = this.DbTable;
            var idColumn = table.PKColumn.Name;
            var column = table.Translate(property);

            var sql = new StringWriter();
            sql.Write("SELECT ");
            sql.AppendQuote(table, column);
            sql.Write(" FROM ");
            sql.AppendQuoteName(table);
            sql.Write(" WHERE ");
            sql.AppendQuote(table, idColumn);
            sql.Write(" = {0}");

            return this.QueryTable(new TableQueryArgs
            {
                FormattedSql = sql.ToString(),
                Parameters = new object[] { entityId },
            });
        }

        /// <summary>
        /// QueryTable 方法完成后调用。
        /// 
        /// 子类可重写此方法来实现查询完成后的数据修整工具。
        /// </summary>
        /// <param name="args"></param>
        internal protected virtual void OnTableQueryed(TableQueryArgs args)
        {
            this.DataQueryer.OnTableQueryed(args);
        }

        #endregion

        #region 提供给子类的查询接口

        /// <summary>
        /// 使用 sql 语句来查询实体。
        /// </summary>
        /// <param name="sql">sql 语句，返回的结果集的字段，需要保证与属性映射的字段名相同。</param>
        /// <param name="paging">分页信息。</param>
        /// <param name="eagerLoad">需要贪婪加载的属性。</param>
        /// <returns></returns>
        protected EntityList QueryList(FormattedSql sql, PagingInfo paging = null, EagerLoadOptions eagerLoad = null)
        {
            return this.DataQueryer.QueryList(sql, paging, eagerLoad);
        }

        /// <summary>
        /// 使用 sql 语句来查询实体。
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException">使用内存过滤器的同时，不支持提供分页参数。</exception>
        protected EntityList QueryList(SqlQueryArgs args)
        {
            return this.DataQueryer.QueryList(args);
        }

        /// <summary>
        /// 使用 sql 语句来查询数据表。
        /// </summary>
        /// <param name="sql">Sql 语句.</param>
        /// <param name="paging">分页信息。</param>
        /// <returns></returns>
        protected LiteDataTable QueryTable(FormattedSql sql, PagingInfo paging = null)
        {
            return this.DataQueryer.QueryTable(sql, paging);
        }

        /// <summary>
        /// 使用 sql 语句查询数据表。
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected LiteDataTable QueryTable(TableQueryArgs args)
        {
            return this.DataQueryer.QueryTable(args);
        }

        #endregion

        #region 其它

        private SQLColumnsGenerator _sqlColumnsGenerator;

        internal SQLColumnsGenerator SQLColumnsGenerator
        {
            get
            {
                if (_sqlColumnsGenerator == null)
                {
                    _sqlColumnsGenerator = new SQLColumnsGenerator(this.Repository);
                }
                return _sqlColumnsGenerator;
            }
        }

        /// <summary>
        /// 强制转换指定仓库的数据提供程序为关系数据库的数据提供程。
        /// 如果该仓库的 <see cref="IRepository.DataProvider"/> 不是此类型的子类，则会抛出异常。
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static RdbDataProvider Get(IRepository repository)
        {
            var dp = repository.DataProvider as RdbDataProvider;
            if (dp == null)
            {
                throw new InvalidProgramException(string.Format(
                    "{0} 仓库类型使用的数据提供程序类型是 {1}，该类型不能转换为关系数据库的数据提供程序。",
                    repository.GetType(),
                    repository.DataProvider.GetType()
                    ));
            }
            return dp;
        }

        #endregion
    }
}