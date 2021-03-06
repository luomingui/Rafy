﻿/*******************************************************
 * 
 * 作者：胡庆访
 * 创建日期：20131210
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20131210 09:51
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rafy.Domain.ORM.SqlTree
{
    /// <summary>
    /// 表示一个文本
    /// 
    /// SqlLiteral 需要从 SqlConstraint 上继承，否则将不可用于 Where 语句。
    /// </summary>
    class SqlLiteral : SqlConstraint
    {
        //private static object[] EmptyParameters = new object[0];

        //public SqlLiteral()
        //{
        //    this.Parameters = EmptyParameters;
        //}

        public override SqlNodeType NodeType
        {
            get { return SqlNodeType.SqlLiteral; }
        }

        /// <summary>
        /// Sql 文本。
        /// </summary>
        public string FormattedSql { get; set; }

        /// <summary>
        /// 对应的参数值列表
        /// </summary>
        public object[] Parameters { get; set; }
    }
}
