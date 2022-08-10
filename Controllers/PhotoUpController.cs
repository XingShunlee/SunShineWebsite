using ehaiker;
using ehaiker.Models;
using ehaikerv202010.Filters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ehaikerv202010.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [LoginStateRequiredAttribute]
    public class PhotoUpController : ControllerBase
    {
        private EhaikerContext DbContext;
        private IHostingEnvironment _env;
        public PhotoUpController(EhaikerContext _cont, IHostingEnvironment env)
        {
            DbContext = _cont;
            _env = env;
        }
        [HttpPost]
        // [Description(No = 12, Name = "上传头像", isGet = false)]
        public async Task<JsonResult> UploadFile()
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            MemberShip loginUser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");

            var files = Request.Form.Files;

            string error = string.Empty;
            string res = string.Empty;
            long filelen = files[0].Length;
            //~/UploadFiles/Icon/UserName/
            string fileroot = string.Format("~/UploadFiles/Icon/{0}/", loginUser.Account);
            string filePath = _env.WebRootPath + (fileroot);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            //获取文件信息：防止改名字的文件上传
            string fileName = files[0].FileName;
            loginUser.Icon = fileroot + fileName;

            try
            {
                using (var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                    await files[0].CopyToAsync(stream);
                }
                    ;// files[0].Save(Path.Combine(filePath, fileName));
            }
            catch (Exception e)
            {
                msg.msg = "保存文件失败" + e.Message;
                return new JsonResult(msg);
            }
            FileUploadHelper.FileExtension[] fe = { FileUploadHelper.FileExtension.JPG,
                    FileUploadHelper.FileExtension.PNG,
                    FileUploadHelper.FileExtension.GIF };
            if (!FileUploadHelper.CheckTrueFileName(files[0].FileName, fe
                ))
            {
                msg.msg = "非法的文件格式";
                return new JsonResult(msg);
            }

            IRepository<MemberShip> memshipMgr = new MemberShipManager(DbContext);
            loginUser.Icon = string.Format("../UploadFiles/Icon/{0}/{1}", loginUser.Account, fileName);
            memshipMgr.Update(loginUser);
            MemUserDataManager.UpdateSessionData(HttpContext, "memshipUserInfo", loginUser);
            msg.msg = loginUser.Icon;
            msg.SuccessCode = "0";
            return new JsonResult(msg);
        }
    }

}