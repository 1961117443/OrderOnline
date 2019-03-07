layui.use(['form', 'layer', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laytpl = layui.laytpl,
        table = layui.table;

    //订单列表
    var tableIns = table.render({
        elem: '#orderList',
        url: '/Order/LoadData/',
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        limits: [10, 15, 20, 25],
        limit: 15,
        id: "orderListTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 50 },
            { field: "BillCode", title: '订单号', width: 120, align: "center" },
            { field: 'BillDate', title: '订单日期', minWidth: 50, align: "center" },
            { field: 'CustomerCode', title: '客户编号', minWidth: 50, align: "center" },
            { field: 'CustomerName', title: '客户名称', minWidth: 80, align: "center" },
            { field: 'Remark', title: '备注', align: 'center' },
            { field: 'Maker', title: '制单人', width: 100, align: "center" },
            { field: 'MakeDate', title: '制单时间', minWidth: 80, align: "center" },
            { field: 'Audit', title: '审核人', width: 100, align: "center" },
            { field: 'AuditDate', title: '审核时间', minWidth: 80, align: "center" },
            { title: '操作', minWidth: 80, templet: '#orderListBar', fixed: "right", align: "center" }
        ]]
    });

    //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
    $(".search_btn").on("click", function () {
        if ($(".searchVal").val() !== '') {
            table.reload("orderListTable", {
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

    //添加订单
    function addOrder(edit) {
        var tit = "添加订单";
        if (edit) {
            tit = "编辑订单";
        }
        var index = layui.layer.open({
            title: tit,
            type: 2,
            anim: 1,
            area: ['80%', '90%'],
            content: "/Order/AddOrModify/",
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {  
                    body.find("#Id").val(edit.ID);
                    body.find(".BillCode").val(edit.BillCode);
                    body.find(".BillDate").val(edit.BillDate);
                    body.find(".CustomerCode").val(edit.CustomerIDCode);
                    body.find(".CustomerName").val(edit.CustomerIDName); 
                    //body.find("input:checkbox[name='IsLock']").prop("checked", edit.IsLock);
                    body.find(".Remark").text(edit.Remark);
                    form.render();
                }
            }
        });
    }
    $(".addOrder_btn").click(function () {
        addOrder();
    });

    //批量删除
    $(".delAll_btn").click(function () {
        var checkStatus = table.checkStatus('orderListTable'),
            data = checkStatus.data,
            orderId = [];
        if (data.length > 0) {
            for (var i in data) {
                orderId.push(data[i].Id);
            }
            layer.confirm('确定删除选中的用户？', { icon: 3, title: '提示信息' }, function (index) {
                //获取防伪标记
                del(orderId);
            });
        } else {
            layer.msg("请选择需要删除的用户");
        }
    });

    //列表操作
    table.on('tool(orderList)', function (obj) {
        var layEvent = obj.event,
            data = obj.data;

        if (layEvent === 'edit') { //编辑
            addOrder(data);
        } else if (layEvent === 'del') { //删除
            layer.confirm('确定删除此用户？', { icon: 3, title: '提示信息' }, function (index) {
                del(data.Id);
            });
        }
    });

    form.on('switch(IsLock)', function (data) {
        var tipText = '确定锁定当前用户吗？';
        if (!data.elem.checked) {
            tipText = '确定启用当前用户吗？';
        }
        layer.confirm(tipText, {
            icon: 3,
            title: '系统提示',
            cancel: function (index) {
                data.elem.checked = !data.elem.checked;
                form.render();
                layer.close(index);
            }
        }, function (index) {
            changeLockStatus(data.value, data.elem.checked);
            layer.close(index);
        }, function (index) {
            data.elem.checked = !data.elem.checked;
            form.render();
            layer.close(index);
        });
    });

    function del(orderId) {
        $.ajax({
            type: 'POST',
            url: '/Order/Delete/',
            data: { orderId: orderId },
            dataType: "json",
            headers: {
                "X-CSRF-TOKEN-yilezhu": $("input[name='AntiforgeryKey_yilezhu']").val()
            },
            success: function (data) {//res为相应体,function为回调函数
                layer.msg(data.ResultMsg, {
                    time: 2000 //20s后自动关闭
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

    function changeLockStatus(orderId, status) {
        $.ajax({
            type: 'POST',
            url: '/Order/ChangeLockStatus/',
            data: { Id: orderId, Status: status },
            dataType: "json",
            headers: {
                "X-CSRF-TOKEN-yilezhu": $("input[name='AntiforgeryKey_yilezhu']").val()
            },
            success: function (data) {//res为相应体,function为回调函数
                layer.msg(data.ResultMsg, {
                    time: 2000 //2s后自动关闭
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
