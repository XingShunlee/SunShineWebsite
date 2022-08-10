﻿using ehaiker;
using ehaikerv202010.Filters;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaikerv202010.helpers
{
    public class NoteCounter : INoteCountInterface
    {
        private System.Timers.Timer writeTimer = new System.Timers.Timer(1000 * 60);
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        public static object locker = new object();//添加一个对象作为锁
        private static List<Dictionary<string, Int32>> accessNumMapList = new List<Dictionary<String, Int32>>();
        public static List<string> iplist = new List<string>();
        public NoteCounter(ILogger<NoteCounter> logger)
        {
            _logger = logger;
            InitData();
            StartWrite();
        }


        public void InitData()
        {
            iplist.Clear();
            //写入数据库
            foreach (Dictionary<string, Int32> dc in accessNumMapList)
            {
                dc.Clear();
            }
            accessNumMapList.Clear();
        }

        public void StartWrite()
        {
            writeTimer.Stop();
            writeTimer.Elapsed += new System.Timers.ElapsedEventHandler(WriteFunc);
            writeTimer.AutoReset = true;
            writeTimer.Enabled = true;
        }

        public void StopWrite()
        {
            writeTimer.Stop();
            writeTimer.Enabled = false;
        }
        public void timer()
        {
            lock (locker)
            {

                DateTime dt = DateTime.Now;
                if ((dt.Hour == 0 && dt.Minute == 0) ||
                    (dt.Hour == 24 && dt.Minute == 0))
                {
                    InitData();
                }
            }
        }
        public void WriteFunc(object source, System.Timers.ElapsedEventArgs e)
        {
            lock (locker)
            {

                DateTime dt = DateTime.Now;
                if ((dt.Hour == 0 && dt.Minute == 0) ||
                    (dt.Hour == 24 && dt.Minute == 0))
                {
                    InitData();
                }
            }
        }
        public void accessMethod(HttpContext request, EhaikerContext _cont)
        {
            string ipurl = request.Request.Headers["X-Real-IP"].FirstOrDefault();
            if (ipurl == null)
            {
                ipurl = request.Connection.RemoteIpAddress.ToString();
            }
            string stringId = request.Request.Query["newsID"];
            string uri = request.Request.Path + "?newsID=" + stringId;
            if (ipurl == null)
            {
                return;
            }
            bool flag = false;
            foreach (string ip in iplist)
            {
                if (ipurl == ip)
                {
                    flag = true;
                    break;
                }
            }
            //如果没有找到该IP，添加到数组中
            if (!flag)
                iplist.Add(ipurl);
            //统计
            bool containUrl = false;
            foreach (Dictionary<string, Int32> dc in accessNumMapList)
            {
                if (dc.ContainsKey(uri))
                {
                    int count = 0;
                    lock (locker)
                    {
                        //包含url，但是IP不一样
                        if (dc.TryGetValue(uri, out count) && !flag)
                        {
                            count = count + 1;
                            dc[uri] = count;
                            RaiseSaveItemCount(_cont, stringId, count);
                        }
                    }
                    containUrl = true;
                    break;
                }
            }
            if (!containUrl)
            {
                Dictionary<string, Int32> accessNumDc = new Dictionary<string, int>();
                int i = uri.LastIndexOf("=");
                int count = 1;
                if (i != -1)
                {
                    try
                    {
                        string ids = uri.Substring(i + 1);
                        count = RaiseGetItemCount(_cont, ids, count) + 1;
                        RaiseSaveItemCount(_cont, ids, count);
                    }
                    catch
                    {
                        _logger.LogInformation("\n _______logging user infomation for saving count.10110.___________\n");
                    }

                }
                //到数据库查找读者数
                accessNumDc.Add(uri, count);
                accessNumMapList.Add(accessNumDc);
            }
        }
        private void RaiseSaveItemCount(EhaikerContext _cont, string uri, int count)
        {
            // try
            ///{
            int id = Convert.ToInt32(uri);
            ehaiker.Models.IRepository<NewsModel> _noteRepository = new NewsesRepository(_cont);
            var notes = _noteRepository.GetDbSet().Where(r => r.Id == id).FirstOrDefault();
            if (notes != null)
            {
                NewsModel item = notes as NewsModel;
                item.readers = count;
                _noteRepository.Update(item);
                _noteRepository.SaveChanges();
            }
               //  }
               //  catch
               //  {
               ;
            // }
        }
        private int RaiseGetItemCount(EhaikerContext _cont, string uri, int count)
        {
            int id = Convert.ToInt32(uri);
            ehaiker.Models.IRepository<NewsModel> _noterepository = new NewsesRepository(_cont);
            var notes = _noterepository.GetDbSet().Where(r => r.Id == id).FirstOrDefault();
            if (notes != null)
            {
                NewsModel item = notes as NewsModel;
                count = item.readers;
            }
            return count;
        }
    }
    public static class Extensions
    {
        public static IServiceCollection AddNoteCountService(this IServiceCollection service)
        {
            return service.AddSingleton<INoteCountInterface, NoteCounter>();
        }
    }
}
