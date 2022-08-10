using System.ComponentModel.DataAnnotations;
/*
 * 
 * 游戏攻略类
 * */
namespace ehaiker
{


    /// <summary>
    /// 登录模型
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// 帐号
        /// </summary>
        [Required(ErrorMessage = "必须输入{0}")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "{0}长度为{2}-{1}个字符")]
        [Display(Name = "帐号")]
        public string Accounts { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "必须输入{0}")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0}长度{2}-{1}个字符")]
        [Display(Name = "密码")]
        public string Password { get; set; }
    }
    public class GameType
    {
        [Key]
        public int GameId { set; get; }
        public string Name { set; get; }
    }
    public class PostResult
    {
        public int ErrorCode { set; get; }
        public string SuccessCode { set; get; }
        public int iSuccessCode { set; get; }
        public string msg { set; get; }
        public string errMessage { set; get; }
    }
    //状态服务器表
    public class KefuServiceStatus
    {
        [Key]
        public int kfUserIndex { get; set; }
        //用户的adminID
        public int kfUserId { get; set; }
        /// <summary>
        /// 帐号
        /// </summary>
        [Required(ErrorMessage = "必须输入{0}")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "{0}长度为{2}-{1}个字符")]
        [Display(Name = "帐号")]
        public string Account { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [Display(Name = "显示昵称")]
        public string UserName { set; get; }
        //
        public int isOnline { get; set; }
        public int CurrentPeople { get; set; }
        [Display(Name = "组ID")]
        public int GroupId { set; get; }
    }
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public int customerId { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [Display(Name = "显示昵称")]
        public string UserName { set; get; }
        //
        public int isOnline { get; set; }
        public string headImg { get; set; }
        public int kfUserId { get; set; }
    }
    public class ChatRecord
    {
        [Key]
        public int RecordId { get; set; }
        public int kfUserId { get; set; }
        public int customerId { get; set; }
        /// <summary>
        /// 帐号
        /// </summary>
        public string customerContent { get; set; }
        public string kfContent { get; set; }
        [Display(Name = "创建时间")]
        public string Time { get; set; }
    }
}
