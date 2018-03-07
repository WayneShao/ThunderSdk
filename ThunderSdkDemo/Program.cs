using System;
using ThunderSdk;

namespace ThunderSdkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new DownloadManager(1, @"D:\");
            manager.CreateNewTask("https://ss2.baidu.com/6ONYsjip0QIZ8tyhnq/it/u=770549720,375505130&fm=173&s=612A66F94AA394CE4A84E71B030050D7&w=218&h=146&img.JPEG",
                "2018-1-30-5ZD6R0BZZ.rar");

            manager.TaskDownload += (s, e) =>
            {
                if (!(s is DownFileInfo info)) return;

                Console.WriteLine(info.TaskInfo.Percent);
            };

            manager.TaskCompleted += (s, e) =>
              {
                  if (!(s is DownFileInfo info)) return;

                  Console.WriteLine(info.FileName + "下载完成");
              };

            manager.StartAllTask();

            Console.ReadKey();
        }
    }
}
