layui.use(['form', 'layer', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laytpl = layui.laytpl,
        table = layui.table;

    //型号列表
    var tableIns = table.render({
        elem: '#sectionBarList',
        url: '/sectionBar/LoadData/',
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        limits: [10, 15, 20, 25,50],
        limit: 20,
        id: "sectionBarListTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 50 },
           // { field: "Id", title: 'Id', width: 50, align: "center" },
            { field: 'Code', title: '型材型号', minWidth: 50, align: "center" },
            { field: 'Name', title: '型材名称', minWidth: 50, align: "center" },
            { field: 'WallThickness', title: '壁厚', minWidth: 80, align: "center" },
            { field: 'TheoryMeter', title: '理论米重', minWidth: 100, align: "center" }, 
          //  { field: 'Remark', title: '备注', align: 'center' }, 
            { title: '操作', minWidth: 80, templet: '#sectionBarListBar', fixed: "right", align: "center" }
        ]]
    });

    //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
    $(".search_btn").on("click", function () {
        if ($(".searchVal").val() !== '') {
            table.reload("sectionBarListTable", {
                page: {
                    curr: 1 //重新从第 1 页开始
                },
                where: {
                    key: $(".searchVal").val()  //搜索的关键字
                }
            });
        } else {
            layer.msg("请输入搜索的内容");
        }
    });

    //添加用户
    function addSectionBar(edit) {
        var tit = "添加型号";
        if (edit) {
            tit = "编辑型号";
        }
        var index = layui.layer.open({
            title: tit,
            type: 2,
            anim: 1,
            area: ['500px', '50%'],
            content: "/SectionBar/AddOrModify/",
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    body.find("#Id").val(edit.ID);
                    body.find(".Code").val(edit.Code);
                    body.find(".Name").val(edit.Name);
                    body.find(".WallThickness").val(edit.WallThickness);
                    body.find(".TheoryMeter").val(edit.TheoryMeter); 
                    form.render();
                }
            }
        });
    }
    $(".addSectionBar_btn").click(function () {
        addSectionBar();
    });

    //批量删除
    $(".delAll_btn").click(function () {
        var checkStatus = table.checkStatus('sectionBarListTable'),
            data = checkStatus.data,
            sectionBarId = [];
        if (data.length > 0) {
            for (var i in data) {
                sectionBarId.push(data[i].ID);
            } 
            layer.confirm('确定删除选中的型号？', { icon: 3, title: '提示信息' }, function (index) {
                //获取防伪标记
                del(sectionBarId);
            });
        } else {
            layer.msg("请选择需要删除的用户");
        }
    });

    //列表操作
    table.on('tool(sectionBarList)', function (obj) {
        var layEvent = obj.event,
            data = obj.data;

        if (layEvent === 'edit') { //编辑
            addSectionBar(data);
        } else if (layEvent === 'del') { //删除
            layer.confirm('确定删除此型号？', { icon: 3, title: '提示信息' }, function (index) {
                del(data.ID);
            });
        }
    }); 

    function del(sectionBarId) { 
        $.ajax({
            type: 'POST',
            url: '/SectionBar/Delete/',
            data: { sectionBarId: sectionBarId },
            dataType: "json",
            headers: {
                "X-CSRF-TOKEN-yilezhu": $("input[name='AntiforgeryKey_yilezhu']").val()
            },
            success: function (data) {//res为相应体,function为回调函数
                let index= layer.msg(data.ResultMsg, {
                    time: 1000 //1s后自动关闭
                }, function () {
                    tableIns.reload();
                    layer.close(index);
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.alert('操作失败！！！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            }
        });
    }
     

});
