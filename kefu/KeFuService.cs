using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ehaiker.Models;
using ehaiker.Managers;
using Microsoft.EntityFrameworkCore;

namespace ehaiker.kefu
{
    //客服类
    public class KeFuService
    {
        private EhaikerContext DbContext;
        public KeFuService(EhaikerContext _cont)
        {
            DbContext = _cont;
        }
        public void saveCustomerChatRecord(ChatRecord csChatRecord)
        {
            KeFuChatRecordRepository rds = new KeFuChatRecordRepository(DbContext);
            rds.Add(csChatRecord);
        }
        public int SaveChangeInChatRecord()
        {
            KeFuChatRecordRepository kefu_chat = new KeFuChatRecordRepository(DbContext);
            return kefu_chat.SaveChanges();
        }
        public int SaveChangeInCustomer()
        {
            KeFuCustomerRepository kefu_cs = new KeFuCustomerRepository(DbContext);
            return kefu_cs.SaveChanges();
        }
        public int SaveChangeInKefu()
        {
            KeFuRepository kefu_cs = new KeFuRepository(DbContext);
            return kefu_cs.SaveChanges();
        }
        public List<KefuServiceStatus> getAllUserState()
        {
            KeFuRepository kefu = new KeFuRepository(DbContext);
            return kefu.GetDbSet().Where(r => r.isOnline>=1).ToList(); ;

        }
        public void updateCurrentPeople(KefuServiceStatus user)
        {
            KeFuRepository kefu = new KeFuRepository(DbContext);
            kefu.Update(user);
        }
        //id 為當前的客服ID也就是自己
        public KefuServiceStatus GetService(int excludeId=0)
        {
            KeFuRepository kefu = new KeFuRepository(DbContext);
            //获取所有在线客服每个人正在接待的用户人数
            List<KefuServiceStatus> userList = kefu.GetDbSet().Where(r => r.isOnline >= 1 ).ToList();
            if (userList==null||
                userList.Count<1)
            {
                return null;
            }
            //只有一個客服的情況，直接返回
            if(userList.Count==1)
            {
                return userList[0];
            }
            KefuServiceStatus userTemp = userList[0];
            //確保第一個不是自己
            if (excludeId == userTemp.kfUserId)
            {
                userTemp = userList[1];
            }
            int temp = userTemp.CurrentPeople;
            //获取一个接待人数最少的客服，並排除自己
            foreach (KefuServiceStatus user in userList)
            {
                //跳過自己 2020-9-6
                if (excludeId == user.kfUserId)
                    continue;
                if (user.CurrentPeople < temp )
                {
                    temp = user.CurrentPeople;
                    userTemp = user;
                }
            }
            if(userTemp != null)
            {
                userTemp.CurrentPeople += 1;
                kefu.Update(userTemp);
                kefu.SaveChanges();
            }
            return userTemp;
        }
        public KefuServiceStatus GetServiceUser(int id)
        {
             KeFuRepository kefu = new KeFuRepository(DbContext);
             return kefu.GetById(id); 
        }
        //登录
        public bool LoginService(KefuServiceStatus kefu)
        {
            KeFuRepository kefuSer = new KeFuRepository(DbContext);
            KefuServiceStatus user = kefuSer.GetDbSet().AsNoTracking().FirstOrDefault(r => r.kfUserId == kefu.kfUserId);
            if (user == null)
            {
                kefuSer.Add(kefu);
                return true;
            }
            else
            {
                kefu.kfUserIndex = user.kfUserIndex;
                kefuSer.Update(kefu);
            }
            return false;
        }
        public bool LoginOutService(KefuServiceStatus kefu)
        {
            KeFuRepository kefuSer = new KeFuRepository(DbContext);
            KefuServiceStatus user = kefuSer.GetDbSet().AsNoTracking().FirstOrDefault(r => r.kfUserId == kefu.kfUserId);
            if (user == null)
            {
                return true;
            }
            else
            {
                
                kefuSer.Update(kefu);
            }
            return false;
        }
    }
}