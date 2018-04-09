
   import {option} from '../Module/Echart/histogram'     
    var zujian = {
        props: {
            'width': {
                type: String,//必须是数字
                default: "width:400px;height:600px",//默认值
            },
        },
        //template: '<div id="main" style="width:"{{ width }}";height:"{{ height }}></div>'
        template: '<div id="main" style="width:400px;height:600px"></div>'
    };
    //局部注册
    new Vue({
        el: '#show',
        // ...
        components: {
            // <my-component> 将只在父组件模板中可用
            'myqw-component': zujian//myqw：组件标签名，可以按规则任意命名
        },
        mounted() {
            this.drawLine();
        },
        methods: {
            drawLine: function () {
                //alert("haha");
                // 基于准备好的dom，初始化echarts实例
                var myChart = echarts.init(document.getElementById('main'));
                // 指定图表的配置项和数据
                //var option = {
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
                // 使用刚指定的配置项和数据显示图表。
                myChart.setOption(histogram_option);
            }
        }
    });