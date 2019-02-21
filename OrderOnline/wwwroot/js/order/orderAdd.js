layui.use(['laydate','form', 'table', 'layer','layedit'], function () {
    var form = layui.form,
        laydate = layui.laydate,
        layedit = layui.layedit,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        table = layui.table;
     
    //日期
    laydate.render({
        elem: '.BillDate'
    });

    //订单从表列表
    var tableIns = table.render({
        elem: '#orderItemList',
        url: '/Order/LoadItemData/',
        cellMinWidth: 95,
        page: false,
        // height: "full-25",
        //limits: [10, 15, 20, 25],
        //limit: 10,
        id: "orderItemListTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 50 },
            { field: "TraceCode", title: '订单跟踪号', width: 150, align: "center" },
            { field: 'SectionBarCode', title: '型材型号', minWidth: 100, align: "center" },
            { field: 'SectionBarName', title: '型材名称', minWidth: 100, align: "center" },
            { field: 'SurfaceName', title: '表面方式', minWidth: 100, align: "center" },
            { field: 'PackingName', title: '包装方式', width: 100, align: "center" },
            { field: 'TotalQuantity', title: '订单数', minWidth: 60, align: "center" },
            { field: 'TheoryMeter', title: '理论米重', minWidth: 60, align: "center" },
            { field: 'OrderLength', title: '订单长度', minWidth: 50, align: "center" },
            { title: '操作', minWidth: 80, templet: '#orderItemListBar', fixed: "right", align: "center" }
        ]],
        where: {
            ID:$("#Id").val()
        }
    });


    form.on("submit(addManager)", function (data) {
        //获取防伪标记
        $.ajax({
            type: 'POST',
            url: '/Order/AddOrModify/',
            data: {
                Id: $("#Id").val(),  //主键
                UserName: $(".UserName").val(),
                RoleId: $(".RoleId").val(),
                NickName: $(".NickName").val(),
                Mobile: $(".Mobile").val(),
                Email: $(".Email").val(),
                IsLock: $(".IsLock").get(0).checked,
                Remark: $(".Remark").val()
            },
            dataType: "json",
            headers: {
                "X-CSRF-TOKEN-MONKEY": $("input[name='AntiforgeryKey_yilezhu']").val()
            },
            success: function (res) {//res为相应体,function为回调函数
                if (res.ResultCode === 0) {
                    var alertIndex = layer.alert(res.ResultMsg, { icon: 1 }, function () {
                        layer.closeAll("iframe");
                        //刷新父页面
                        parent.location.reload();
                        top.layer.close(alertIndex);
                    });
                    //$("#res").click();//调用重置按钮将表单数据清空
                } else if (res.ResultCode === 102) {
                    layer.alert(res.ResultMsg, { icon: 5 }, function () {
                        layer.closeAll("iframe");
                        //刷新父页面
                        parent.location.reload();
                        top.layer.close(alertIndex);
                    });
                }
                else {
                    layer.alert(res.ResultMsg, { icon: 5 });
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.alert('操作失败！！！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            }
        });
        return false;
    });
    form.verify({
        username: function (value, item) { //value：表单的值、item：表单的DOM对象
            if (!new RegExp("^[a-zA-Z0-9_\u4e00-\u9fa5\\s·]+$").test(value)) {
                return '用户名不能有特殊字符';
            }
            if (/(^\_)|(\__)|(\_+$)/.test(value)) {
                return '用户名首尾不能出现下划线\'_\'';
            }
            if (/^\d+\d+\d$/.test(value)) {
                return '用户名不能全为数字';
            }
        }

        //我们既支持上述函数式的方式，也支持下述数组的形式
        //数组的两个值分别代表：[正则匹配、匹配不符时的提示文字]
        , pass: [
            /^[\S]{6,12}$/
            , '密码必须6到12位，且不能出现空格'
        ]
    });
});