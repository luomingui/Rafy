//------------------------------------------------------------------------------
// <auto-generated>
//     本文件代码自动生成。用于实现强类型接口，方便应用层使用。
//     版本号:1.5.0
//
//     请勿修改，否则在重新生成时，所有修改会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Rafy;
using Rafy.ComponentModel;
using Rafy.Data;
using Rafy.Domain;
using Rafy.Domain.ORM;

namespace Demo
{
    partial class BookAdministratorList
    {
        #region 强类型公有接口

        /// <summary>
        /// 获取或设置指定位置的实体。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public new BookAdministrator this[int index]
        {
            get
            {
                return base[index] as BookAdministrator;
            }
            set
            {
                base[index] = value;
            }
        }

        /// <summary>
        /// 获取本实体列表的迭代器。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new IEnumerator<BookAdministrator> GetEnumerator()
        {
            return new EntityListEnumerator<BookAdministrator>(this);
        }

        /// <summary>
        /// 返回子实体的强类型迭代接口，方便使用 Linq To Object 操作。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public IEnumerable<BookAdministrator> Concrete()
        {
            return this.Cast<BookAdministrator>();
        }

        /// <summary>
        /// 添加指定的实体到集合中。
        /// </summary>
        [DebuggerStepThrough]
        public void Add(BookAdministrator entity)
        {
            base.Add(entity);
        }

        /// <summary>
        /// 判断本集合是否包含指定的实体。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public bool Contains(BookAdministrator entity)
        {
            return base.Contains(entity);
        }

        /// <summary>
        /// 判断指定的实体在本集合中的索引号。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public int IndexOf(BookAdministrator entity)
        {
            return base.IndexOf(entity);
        }

        /// <summary>
        /// 在指定的位置插入实体。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public void Insert(int index, BookAdministrator entity)
        {
            base.Insert(index, entity);
        }

        /// <summary>
        /// 在集合中删除指定的实体。返回是否成功删除。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public bool Remove(BookAdministrator entity)
        {
            return base.Remove(entity);
        }

        #endregion
    }

    partial class BookAdministratorRepository
    {
        #region 私有方法，本类内部使用

        /// <summary>
        /// 在查询接口方法中，调用此方法来向服务端执行对应参数的 FetchBy 数据层方法，并返回第一个实体。
        /// </summary>
        /// <param name="parameters">可传递多个参数。</param>
        /// <returns>返回服务端返回的列表中的第一个实体。</returns>
        [DebuggerStepThrough]
        private new BookAdministrator FetchFirst(params object[] parameters)
        {
            return base.FetchFirst(parameters) as BookAdministrator;
        }

        /// <summary>
        /// 在查询接口方法中，调用此方法来向服务端执行对应参数的 FetchBy 数据层方法，并返回满足条件的实体列表。
        /// </summary>
        /// <param name="parameters">可传递多个参数。</param>
        /// <returns>返回满足条件的实体列表。</returns>
        [DebuggerStepThrough]
        private new BookAdministratorList FetchList(params object[] parameters)
        {
            return base.FetchList(parameters) as BookAdministratorList;
        }

        /// <summary>
        /// 在查询接口方法中，调用此方法来导向服务端执行指定的数据层查询方法，并返回统计的行数。
        /// </summary>
        /// <param name="dataQueryExp">调用子仓库类中定义的数据查询方法的表达式。</param>
        /// <returns>返回统计的行数。</returns>
        [DebuggerStepThrough]
        protected int FetchCount(Expression<Func<BookAdministratorRepository, EntityList>> dataQueryExp)
        {
            return this.FetchCount<BookAdministratorRepository>(dataQueryExp);
        }

        /// <summary>
        /// 在查询接口方法中，调用此方法来导向服务端执行指定的数据层查询方法，并返回第一个满足条件的实体。
        /// </summary>
        /// <param name="dataQueryExp">调用仓库类中定义的数据查询方法的表达式。</param>
        /// <returns>返回第一个满足条件的实体。</returns>
        [DebuggerStepThrough]
        private BookAdministrator FetchFirst(Expression<Func<BookAdministratorRepository, EntityList>> dataQueryExp)
        {
            return this.FetchFirst<BookAdministratorRepository>(dataQueryExp) as BookAdministrator;
        }

        /// <summary>
        /// 在查询接口方法中，调用此方法来向服务端执行指定的数据层查询方法，并返回满足条件的实体列表。
        /// </summary>
        /// <param name="dataQueryExp">调用仓库类中定义的数据查询方法的表达式。</param>
        /// <returns>返回满足条件的实体列表。</returns>
        [DebuggerStepThrough]
        private BookAdministratorList FetchList(Expression<Func<BookAdministratorRepository, EntityList>> dataQueryExp)
        {
            return this.FetchList<BookAdministratorRepository>(dataQueryExp) as BookAdministratorList;
        }

        /// <summary>
        /// 在查询接口方法中，调用此方法来向服务端执行指定的数据层查询方法，并返回满足条件的数据表格。
        /// </summary>
        /// <param name="dataQueryExp">调用仓库类中定义的数据查询方法的表达式。</param>
        /// <returns>返回满足条件的数据表格。</returns>
        [DebuggerStepThrough]
        private LiteDataTable FetchTable(Expression<Func<BookAdministratorRepository, LiteDataTable>> dataQueryExp)
        {
            return this.FetchTable<BookAdministratorRepository>(dataQueryExp);
        }

        /// <summary>
        /// 创建一个实体类的 Linq 查询器
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        private IQueryable<BookAdministrator> CreateLinqQuery()
        {
            return base.CreateLinqQuery<BookAdministrator>();
        }

        #endregion

        #region 强类型公有接口

        /// <summary>
        /// 创建一个新的实体。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministrator New()
        {
            return base.New() as BookAdministrator;
        }

        /// <summary>
        /// 创建一个全新的列表
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministratorList NewList()
        {
            return base.NewList() as BookAdministratorList;
        }

        /// <summary>
        /// 优先使用缓存中的数据来通过 Id 获取指定的实体对象
        /// 
        /// 如果该实体的缓存没有打开，则本方法会直接调用 GetById 并返回结果。
        /// 如果缓存中没有这些数据，则本方法同时会把数据缓存起来。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministrator CacheById(object id)
        {
            return base.CacheById(id) as BookAdministrator;
        }

        /// <summary>
        /// 优先使用缓存中的数据来查询所有的实体类
        /// 
        /// 如果该实体的缓存没有打开，则本方法会直接调用 GetAll 并返回结果。
        /// 如果缓存中没有这些数据，则本方法同时会把数据缓存起来。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministratorList CacheAll()
        {
            return base.CacheAll() as BookAdministratorList;
        }

        /// <summary>
        /// 通过Id在数据层中查询指定的对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eagerLoad">需要贪婪加载的属性。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministrator GetById(object id, EagerLoadOptions eagerLoad = null)
        {
            return base.GetById(id, eagerLoad) as BookAdministrator;
        }

        /// <summary>
        /// 查询第一个实体类
        /// </summary>
        /// <param name="eagerLoad">需要贪婪加载的属性。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministrator GetFirst(EagerLoadOptions eagerLoad = null)
        {
            return base.GetFirst(eagerLoad) as BookAdministrator;
        }

        /// <summary>
        /// 分页查询所有的实体类
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="eagerLoad">需要贪婪加载的属性。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministratorList GetAll(PagingInfo paging= null, EagerLoadOptions eagerLoad = null)
        {
            return base.GetAll(paging, eagerLoad) as BookAdministratorList;
        }

        /// <summary>
        /// 获取指定 id 集合的实体列表。
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="eagerLoad">需要贪婪加载的属性。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministratorList GetByIdList(object[] idList, EagerLoadOptions eagerLoad = null)
        {
            return base.GetByIdList(idList, eagerLoad) as BookAdministratorList;
        }

        /// <summary>
        /// 通过组合父对象的 Id 列表，查找所有的组合子对象的集合。
        /// </summary>
        /// <param name="parentIdList"></param>
        /// <param name="paging">分页信息。</param>
        /// <param name="eagerLoad">需要贪婪加载的属性。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministratorList GetByParentIdList(object[] parentIdList, PagingInfo paging = null, EagerLoadOptions eagerLoad = null)
        {
            return base.GetByParentIdList(parentIdList, paging, eagerLoad) as BookAdministratorList;
        }

        /// <summary>
        /// 通过父对象 Id 分页查询子对象的集合。
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="paging">分页信息。</param>
        /// <param name="eagerLoad">需要贪婪加载的属性。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministratorList GetByParentId(object parentId, PagingInfo paging = null, EagerLoadOptions eagerLoad = null)
        {
            return base.GetByParentId(parentId, paging, eagerLoad) as BookAdministratorList;
        }
    
        /// <summary>
        /// 通过 CommonQueryCriteria 来查询实体列表。
        /// </summary>
        /// <param name="criteria">常用查询条件。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministratorList GetBy(CommonQueryCriteria criteria)
        {
            return base.GetBy(criteria) as BookAdministratorList;
        }

        /// <summary>
        /// 递归查找所有树型子
        /// </summary>
        /// <param name="treeIndex"></param>
        /// <param name="eagerLoad">需要贪婪加载的属性。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministratorList GetByTreeParentIndex(string treeIndex, EagerLoadOptions eagerLoad = null)
        {
            return base.GetByTreeParentIndex(treeIndex, eagerLoad) as BookAdministratorList;
        }

        /// <summary>
        /// 查找指定树节点的直接子节点。
        /// </summary>
        /// <param name="treePId">需要查找的树节点的Id.</param>
        /// <param name="eagerLoad">需要贪婪加载的属性。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new BookAdministratorList GetByTreePId(object treePId, EagerLoadOptions eagerLoad = null)
        {
            return base.GetByTreePId(treePId, eagerLoad) as BookAdministratorList;
        }

        #endregion
    }
}