using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    //事件发送者
    class AlarmClock
    {
        //声明事件的委托
        public delegate void AlarmEventHandler(object sender, EventArgs e);
        //声明事件
        public event AlarmEventHandler AlarmEvent;
        //引发事件的函数
        public void Alarm()
        {
            if (this.AlarmEvent != null)
            {
                Console.WriteLine("闹钟：叮--叮--叮");
                this.AlarmEvent(this, new EventArgs());   //发出警报
            }
        }
    }
    //事件接收者
    class Host
    {
        //事件处理程序
        public void EventHandle(object sender, EventArgs e)
        {
            Console.WriteLine("用户：起床了！");
        }
        //注册事件处理程序
        public Host(AlarmClock ac)
        {
            ac.AlarmEvent += new AlarmClock.AlarmEventHandler(EventHandle);
        }
    }
    //触发事件
    class program
    {
        static void Main(string[] args)
        {
            AlarmClock alarmClock = new AlarmClock();
            Host host = new Host(alarmClock);
            int j=0;
            //当前时间
            DateTime now = DateTime.Now;

            //设置闹钟
            Console.WriteLine("设置一个闹钟(如 06:30)：");
            DateTime alarmTime = DateTime.ParseExact(Console.ReadLine(), "hh:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            //等待闹钟响
            while (now<alarmTime)
            {
                Console.Clear();
                Console.WriteLine("当前时间：" + now.ToString("hh:mm:ss"));
                System.Threading.Thread.Sleep(1000);         //程序暂停一秒
                now = now.AddSeconds(1);                     //时间增加一秒
            }

            Console.WriteLine("\n");
            alarmClock.Alarm();
            Console.ReadKey();
        }
    }
}
   