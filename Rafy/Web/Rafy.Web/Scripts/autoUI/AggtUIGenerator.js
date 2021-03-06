﻿/*******************************************************
 * 
 * 作者：胡庆访
 * 创建时间：201201
 * 说明：
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 201201
 * 
*******************************************************/

Ext.define('Rafy.autoUI.AggtUIGenerator', {
    _vf: null,
    constructor: function (viewFactory) {
        this._vf = viewFactory;
    },
    generateControl: function (aggtMeta) {
        /// <summary>创建一个聚合控件</summary>
        /// <param name="aggtMeta" type="Rafy.Web.ClientMetaModel.AggtMeta">服务端生成的元数据对象</param>
        /// <returns type="Rafy.autoUI.ControlResult" />
        var mainView = null;
        var mk = aggtMeta.mainBlock;
        if (mk.gridConfig) {
            mainView = this._vf.createListView(mk);
        }
        else {
            mainView = this._vf.createDetailView(mk);
        }

        return this._generateAggt(aggtMeta, mainView, true);
    },
    _generateAggt: function (aggtMeta, mainView, isRoot) {
        //regions
        var main = new Rafy.autoUI.ControlResult(mainView, mainView.getControl());
        var regions = new Rafy.autoUI.Regions(main);
        regions.isRoot = isRoot;

        if (aggtMeta.children) {
            this._generateChildren(aggtMeta.children, regions);
        }

        if (aggtMeta.surrounders) {
            this._generateSurrounders(aggtMeta.surrounders, regions);
        }

        var control = this._layout(aggtMeta, regions);

        return new Rafy.autoUI.ControlResult(mainView, control);
    },
    _generateChildren: function (childrenAggt, regions) {
        /// <returns type="Rafy.autoUI.ControlResult[]" />
        var mainView = regions.main.getView();

        for (var i = 0; i < childrenAggt.length; i++) {
            var childAggt = childrenAggt[i];

            var childView = this._vf.createListView(childAggt.mainBlock);
            childView._propertyNameInParent = childAggt.childProperty;

            var childResult = this._generateAggt(childAggt, childView, false);
            regions.children.push(childResult);

            childView._setParent(mainView);
        }
    },
    _generateSurrounders: function (surroundersAggt, regions) {
        var me = this;
        var mainView = regions.main.getView();

        for (var i = 0; i < surroundersAggt.length; i++) {
            var surrounderAggt = surroundersAggt[i];

            var surrounderView = this._generateSurrounder(mainView, surrounderAggt);

            var surrounderResult = this._generateAggt(surrounderAggt, surrounderView, false);

            regions.surrounders.push({
                type: surrounderAggt.surrounderType,
                result: surrounderResult
            });
        }
    },
    _generateSurrounder: function (mainView, surrounderAggt) {
        /// <returns type="Rafy.view.View" />
        var vf = this._vf;
        var cr = Rafy.view.RelationView; //common realtion

        var surrounderType = surrounderAggt.surrounderType;
        var surrounderBlock = surrounderAggt.mainBlock;

        var surrounderView = null;
        var relation = null;
        var reverseRelation = null; //相反的关系类型

        if (surrounderType == cr.condition) {
            var surrounderView = vf.createConditionView(surrounderBlock);
            reverseRelation = new Rafy.view.RelationView(cr.result, mainView);
        }
        else if (surrounderType == cr.navigation) {
            var surrounderView = vf.createNavigationView(surrounderBlock);
            reverseRelation = new Rafy.view.RelationView(cr.result, mainView);
        }
        else {
            Rafy.notSupport();
        }

        relation = new Rafy.view.RelationView(surrounderType, surrounderView);

        //直接使用 surrounderType 作为关系的类型，把 surrounderView 添加到 mainView 的关系。
        mainView._setRelation(relation);

        //相反的关系设置
        surrounderView._setRelation(reverseRelation);

        return surrounderView;
    },
    _layout: function (aggtMeta, regions) {
        /// <summary>
        /// 对所有区域进行布局。
        /// </summary>
        /// <param name="aggtMeta" type="Rafy.Web.ClientMetaModel.ClientAggtMeta"></param>
        /// <param name="regions" type="Rafy.autoUI.Regions"></param>
        /// <returns type="Ext.Component" />
        var layout = null;
        if (aggtMeta.layoutClass) {
            layout = Ext.create(aggtMeta.layoutClass);
        }
        else {
            layout = new Rafy.autoUI.layouts.Common();
        }

        var res = layout.layout(regions);

        return res;
    }
});