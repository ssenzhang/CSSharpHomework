using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleFactory
{
    class Program
    {
        //抽象图表接口：抽象产品类
        interface Chart
        {
            void display();
        }
        //柱状图类：具体产品类
        class HistogramChart : Chart
        {
            public HistogramChart()
            {
                Console.WriteLine("创建柱状图！");
            }
            public void display()
            {
                Console.WriteLine("显示柱状图！");
            }
        }

        //饼状图类：具体产品类
        class PieChart : Chart
        {
            public PieChart()
            {
                Console.WriteLine("创建饼状图！");
            }
            public void display()
            {
                Console.WriteLine("显示饼状图！");
            }
        }
        //折线图类：具体产品类
        class LineChart : Chart
        {
            public LineChart()
            {
                Console.WriteLine("创建折线图！");
            }
            public void display()
            {
                Console.WriteLine("显示折线图！");
            }
        }
        //图表工厂类：工厂类
        class ChartFactory
        {
            //静态工厂方法
            public static Chart getChart(String type)
            {
                Chart chart = null;
                if (type == "histogram")
                {
                    chart = new HistogramChart();
                    Console.WriteLine("初始化设置柱状图！");
                }
                else if (type == "pie")
                {
                    chart = new PieChart();
                    Console.WriteLine("初始化设置饼状图！");
                }
                else if (type == "line")
                {
                    chart = new LineChart();
                    Console.WriteLine("初始化设置折线图！");
                }
                return chart;
            }
        }
        //测试代码
        class Client
        {
            public static void Main(String [] args)
            {
                Chart chart;
                chart = ChartFactory.getChart("histogram");    //通过静态工厂方法创建产品
                chart.display();

                Console.ReadKey();
            }
        }
    }
}