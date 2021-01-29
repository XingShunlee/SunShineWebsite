using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ehaiker.Models;
using ehaiker.Managers;
using ehaikerv202010.helpers;

namespace ehaiker.kefu
{
    //客户类
    public class CSService
    {
        private List<Customer> cslist = new List<Customer>();
        private EhaikerContext DbContext;
        public CSService(EhaikerContext _cont)
        {
            DbContext = _cont;
        }
        public void saveCustomerChatRecord(ChatRecord csChatRecord){
            KeFuChatRecordRepository rds = new KeFuChatRecordRepository(DbContext);
            rds.Add(csChatRecord);
        }
        public void saveUserChatRecord(ChatRecord csChatRecord)
        {
            KeFuChatRecordRepository rds = new KeFuChatRecordRepository(DbContext);
            rds.Add(csChatRecord);
        }
        public void clearChatrecords(int customerId)
        {
            KeFuChatRecordRepository kefu_cs = new KeFuChatRecordRepository(DbContext);
            kefu_cs.Deletebat(customerId);
        }
        public int SaveChangeInChatRecord()
        {
            KeFuChatRecordRepository kefu_chat = new KeFuChatRecordRepository(DbContext);
            return kefu_chat.SaveChanges();
        }
        public void updateHeadImgState(Customer customer) {
            
            KeFuCustomerRepository kefu_cs = new KeFuCustomerRepository(DbContext);
            var custom = kefu_cs.GetById(customer.customerId);
            if(custom != null)
            {
                custom.headImg = customer.headImg;
                kefu_cs.Update(custom);
            }
           
        }
       public void  clearCustomers(int customerId)
        {
             KeFuCustomerRepository kefu_cs = new KeFuCustomerRepository(DbContext);
             kefu_cs.Deletebat(customerId);
        }
        public int SaveChangeInCustomer()
        {
            KeFuCustomerRepository kefu_cs = new KeFuCustomerRepository(DbContext);
            return kefu_cs.SaveChanges();
        }
        public List<ChatRecord> getAllChatRecord(ChatRecord csChatRecord)
        {
            KeFuChatRecordRepository rds = new KeFuChatRecordRepository(DbContext);
            var a  =  rds.GetDbSet().Where(r => r.kfUserId == csChatRecord.kfUserId && r.customerId==csChatRecord.customerId && r.RecordId> csChatRecord.RecordId).ToList();
           
            return a;
        }
        public List<ChatRecord> CgetAllChatRecord(ChatRecord csChatRecord)
        {
            KeFuChatRecordRepository rds = new KeFuChatRecordRepository(DbContext);
            var a = rds.GetDbSet().Where(r => r.customerId == csChatRecord.customerId && r.RecordId > csChatRecord.RecordId).ToList();

            return a;
        }
        //解密信息
        private string uncapMessage(string sContent)
        {
            // var replstring = Microsoft.JScript.GlobalObject.unescape(sContent);
            var replstring = JSCoderHelper.unescape(sContent);
            return replstring;
        }
        //插入一個客戶
        public void insertCustomer(Customer customer)
        {
            KeFuCustomerRepository kefu_cs = new KeFuCustomerRepository(DbContext);
            var custom = kefu_cs.GetById(customer.customerId);
            if (custom != null)
            {
                custom.isOnline = customer.isOnline;
                kefu_cs.Update(custom);
                return;
            }
            kefu_cs.Add(customer);
        }
        public void updateCustomerOnline(Customer customer)
        {
            KeFuCustomerRepository kefu_cs = new KeFuCustomerRepository(DbContext);
            var custom = kefu_cs.GetById(customer.customerId);
            if(custom !=null)
            {
                custom.isOnline = customer.isOnline;
                kefu_cs.Update(custom);
            }
           
        }
        //获得所有与客服id有关的记录
        public List<Customer>  getCustomerList(int kefuId)
        {
            KeFuCustomerRepository kefu_cs = new KeFuCustomerRepository(DbContext);
            return kefu_cs.GetDbSet().Where(r => r.kfUserId == kefuId).ToList(); ;
           // return cms;
        }
        public void updateKefu(Customer customer)
        {
            KeFuCustomerRepository kefu_cs = new KeFuCustomerRepository(DbContext);
            kefu_cs.Update(customer);
        }
    }
}