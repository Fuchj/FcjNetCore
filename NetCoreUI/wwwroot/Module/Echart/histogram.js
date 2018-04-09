/** @fcj
 *柱形图配置项
 */
//export const option = {
//    title: {
//        text: 'ECharts示例'
//    },
//    tooltip: {},
//    legend: {
//        data: ['销量']
//    },
//    xAxis: {
//        data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"]
//    },
//    yAxis: {},
//    series: [{
//        name: '销量',
//        type: 'bar',
//        data: [5, 20, 36, 10, 10, 20]
//    }]
//};
export const option = {
    itemStyle: {
        normal: {
            shadowBlur: 200, // 阴影的大小
            shadowOffsetX: 0,// 阴影水平方向上的偏移
            shadowOffsetY: 0,// 阴影垂直方向上的偏移
            shadowColor: 'rgba(0, 0, 0, 0.5)'// 阴影颜色
        }
    },
    backgroundColor: '#2c343c', //设置图标的背景色,
    label: {
        normal: {
            fontStyle: 'italic' //文字字体的风格
        }
    },
    labelLine: {
        normal: {
            lineStyle: {
                color: 'rgba(255, 255, 255, 0.3)' //设置标签的视觉引导线
            }
        }
    },
    series: [
        {
            name: '访问来源', //系列名称, 用于toolitp的显示
            type: 'pie', //图形的类型
            radius: '150', //饼图的半径
            roseType: 'angle',  //通过roseType绘制南丁格尔图
            data: [ //数据
                { value: 235, name: '视频广告' },
                { value: 274, name: '联盟广告' },
                { value: 310, name: '邮件营销' },
                { value: 335, name: '直接访问' },
                { value: 400, name: '搜索引擎' }
            ],
            itemStyle: {  //设置每个item的颜色
                normal: {
                    color: function (params) { //params是一个对象, 传入的是seriesIndex, dataIndex, data, value 等各个参数。
                        var colorList = [
                            '#C1232B', '#B5C334', '#FCCE10', '#E87C25', '#27727B',
                            '#FE8463', '#9BCA63', '#FAD860', '#F3A43B', '#60C0DD',
                            '#D7504B', '#C6E579', '#F4E001', '#F0805A', '#26C0C0'
                        ];
                        return colorList[params.dataIndex]
                    },
                    shadowBlur: 100,
                    shadowColor: 'rgba(0, 0, 0, 0.5)'
                }
            }
        }
    ]
}
