using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;

namespace ehaiker
{
    public class MyLog
    {
        //向控制台输出
        public static void ScreenOut(string format, __arglist)
        {
            ArgIterator args = new ArgIterator(__arglist);
            while (args.GetRemainingCount() > 0)
            {
                Console.WriteLine("{0}: {1}", Type.GetTypeFromHandle(args.GetNextArgType()),
                    TypedReference.ToObject(args.GetNextArg()));
            }
        }
        //向控制台输出
        public static void FileOut( string f,string format)
        {
            FileStream fs = new FileStream(f, FileMode.Append | FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs); // 创建写入流
            sw.WriteLine(format);
            sw.Flush();
            sw.Close();

        }
        public static void BinaryFileOut(string froot,string format)
        {
            FileStream fs = new FileStream(froot, FileMode.Append | FileMode.OpenOrCreate);
            BinaryWriter sw = new BinaryWriter(fs); // 创建写入流
            byte[] wer = System.Text.Encoding.Default.GetBytes(format);
            sw.Write(wer);
            sw.Flush();
            sw.Close();
            fs.Close();

        }
    }
}