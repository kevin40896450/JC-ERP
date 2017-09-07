/**
 * @author horken wong <horken.wong@gmail.com>
 * @version: v1.0.0
 * https://github.com/horkenw/bootstrap-table
 * Click to edit row for bootstrap-table
 */

(function ($) {
    'use strict';

    $.extend($.fn.bootstrapTable.defaults, {
        clickEdit: false
    });

    function setDivision(node, options){
        var $option = $('<option />');
        if(options){
            $(options).each(function(i, v){
                $option.clone().text(v.idxNum + ' ' +v.name).val(v.idxNum).appendTo(node);
            })
        }
        else{
            console.log('Please setup options first!!')
        }
    }

    function clikcToEdit(evt, tarNode){
        var txt = [], table = evt,
            submit = '<button type="button" class="btn btn-primary btn-sm editable-submit"><i class="glyphicon glyphicon-ok"></i></button>',
            cancel = '<button type="button" class="btn btn-default btn-sm editable-cancel"><i class="glyphicon glyphicon-remove"></i></button>';

        var replaceData = function(){
            txt = [];
            tarNode.find('td').find('input[type="text"]').each(function(i, td){
                txt.push($(td).eq(0).val());
            });            
            $('#' + table.options.tableID).bootstrapTable('updateRow', {
                index: table.$data.idx,
                row: {
                    name: txt[0],
                    path: txt[1]
                }
            });
            $('#tooling').remove();
            table.editing = true;
            if (table.options.EditSubmit)
            {
                table.options.EditSubmit(table.$data.idx, table.$data.uid, {
                    name: txt[0],
                    path: txt[1]
                }, recoveryData, recoveryData);
            }
            return false;
        };

        var recoveryData = function(){
            $('#' + table.options.tableID).bootstrapTable('updateRow', {
                index: table.$data.thId,
                row: {},
            });
          $('#tooling').remove();
          table.editing = true;
          return false;
        };

        if(table.editing){
            var  rootid = 0;
            table.editing = false;
            var startIndex = table.options.startfieldIndex;//设置可编辑相起始索引号
            table.columns.forEach(function(column, i){
                if (!column.editable) return;

                switch(column.editable){
                    case 'input':
                        var div = $('<div class="editable-input col-md-12 col-sm-12 col-xs-12" style="position: relative;"/>');
                        var tempTxt = tarNode.find('td').eq(startIndex + column.fieldIndex).text();
                        if (tempTxt == "点击该行进行编辑")
                        {
                            txt.push(""); 
                        }
                        else txt.push(tempTxt);
                        div.append($('<input type="text" class="form-control input-sm"/>'));
                        div.append($('<span class="clear"><i class="fa fa-times-circle-o" aria-hidden="true"></i></span>'));
                        tarNode.find('td').eq(startIndex + column.fieldIndex).text('').append(div);
                        break;
                    case 'select':
                        var select=$('<select id="'+column.field+'">'), options = $.selectArray[column.field];
                        tarNode.find('td').eq(column.fieldIndex).text('').append(select);
                        setDivision($('#'+column.field), options);
                        break;
                    case 'textarea':
                        break;
                    default:
                        console.log(column.fieldIndex+' '+column.editable);
                }

            }, evt);
            for(var i=0, l=txt.length; i<l; i++){
                tarNode.find('input[type="text"]').eq(i).val(txt[i]);
            }
            tarNode.find('td').last().append('<div id="tooling" class="editable-buttons"/>');
            $('.clear').on('click', function(){ $(this).parent().find('input').val('');});
            $(submit).on('click', replaceData).appendTo('#tooling');
            $(cancel).on('click', recoveryData).appendTo('#tooling');
            $.each(table.options.Btns, function (idx, item) {
                $(item.btnHtml).on('click',null, evt.$data, item.click).appendTo('#tooling');
            });
        }
    }

    //function updateToServerSide(item, data){
    //    var itemid = $(item).find('a').attr('href').match(/\d+/g)[0];
    //    var datas = {'treeId': itemid, 'oldTreeSerialNo': data[0], 'adminDivision': data[2], 'adminUnit': data[3], 'treeAddr': data[1]}; //傳送至伺服器端的Data產生處，需手動修改對應表格
    //    store( 'data/update', datas)
    //}

    var BootstrapTable = $.fn.bootstrapTable.Constructor,
        _initTable = BootstrapTable.prototype.initTable,
        _initBody = BootstrapTable.prototype.initBody;

    BootstrapTable.prototype.initTable = function(){
        var that = this;
        this.$data = {};
        _initTable.apply(this, Array.prototype.slice.apply(arguments));

        if (!this.options.clickEdit) {
            return;
        }

    };

    BootstrapTable.prototype.initBody = function () {
        var that = this;
        _initBody.apply(this, Array.prototype.slice.apply(arguments));

        if (!this.options.clickEdit) {
            return;
        }

        var table = this.$tableBody.find('table');
        that.editing=true;

        table.on('click-row.bs.table', function (e, row, $element, field) {
            if(field ==='no') return; //|| field ==='noOld'
            this.$data.idx = $element.data().index;
            this.$data.uid = $element.data().uniqueid;
            this.$data.tableObj = $('#' + this.options.tableID);
            clikcToEdit(this, $element);
        }.bind(this));
    };
})(jQuery);