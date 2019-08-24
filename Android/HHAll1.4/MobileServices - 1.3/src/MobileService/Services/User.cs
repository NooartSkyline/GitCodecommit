using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System.Text;
using DoHome.MobileService.Services;
using EnDeCode;

namespace DoHome.MobileService
{
    [DataContract]
    [TableName("TBUSER")]
    public class User
    {
        string userCode;
        string name;
        string password;

        [DataMember]
        [MapField("CODE")]
        public string Code
        {
            get { return userCode; }
            set { userCode = value; }
        }

        [DataMember]
        [MapField("MYNAME")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        [MapField("PWD")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [DataMember]
        public bool IsShowPrice { get; set; }

        [DataMember]
        public bool IsShowSaleProfit { get; set; }

        [DataMember]
        public string PasswordDecrypt { get; set; }
    }

    public partial interface IMobileService
    {

        [OperationContract]
        User UserCheckLogin(string branchCode, string userName, string password);

        [OperationContract]
        List<User> UserGetAll(string branchCode);

        [OperationContract]
        List<User> GetUserByBranch(string branchCode);

        [OperationContract]
        User GetUserByCode(string branchCode, string userCode);

        [OperationContract]
        List<MenuPermission> GetMenuPermission(string branchCode, string userCode);

        //[OperationContract]
        //List<User> GetUserByUserCode(string userCode);
    }

    public partial class MobileService : IMobileService
    {
        private bool GetPermissionByMenu(string branchCode, string userCode, string menuName)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT Code ");
                sql.Append("FROM TBUser u ");
                sql.Append("INNER JOIN TBPermission p ON u.UserGroup = p.GroupID ");
                sql.Append("INNER JOIN TBMenu m ON p.MenuID = m.MenuID ");
                sql.Append("WHERE Menu_Sel = 1 ");
                sql.Append("AND u.Code=@UserCode ");
                sql.Append("AND m.MenuID=@MenuName ");

                var code = db
                    .SetCommand(sql.ToString(),
                        db.Parameter("@UserCode", userCode),
                        db.Parameter("@MenuName", menuName))
                    .ExecuteScalar<string>();

                return !string.IsNullOrEmpty(code);
            }
        }

        public User UserCheckLogin(string branchCode, string userCode, string password)
        {
            User user;

            EnDeCode.ClsEnDeCode encrypt = new EnDeCode.ClsEnDeCode();
            password = encrypt.Encrypt(password, "UW");

            using (DbManager db = new DbManager(branchCode))
            {
                        user = db
                        .SetCommand("SELECT * FROM TBUSER WHERE CODE = @UserCode AND PWD = @Password",
                        db.Parameter("@UserCode", userCode),
                        db.Parameter("@Password", password))
                        .ExecuteObject<User>();
            }

            if (user != null)
            {
                user.IsShowPrice = GetPermissionByMenu(branchCode, user.Code, "HANDHELD - PRICE");
                user.IsShowSaleProfit = GetPermissionByMenu(branchCode, user.Code, "HANDHELD - PROFIT");
            }

            return user;
        }

        public List<User> UserGetAll(string branchCode)
        {
            List<User> users;
            using (DbManager db = new DbManager(branchCode))
            {
                users = db
                    //.SetCommand(GetSql(9))
                    .SetCommand(GetSql(9), db.Parameter("@BranchCode", branchCode))//*EDIT 26-01-56
                    .ExecuteList<User>();
            }

            ClsEnDeCode deCrypt = new ClsEnDeCode();
            foreach (var item in users)
            {
                if (string.IsNullOrEmpty(item.Password))
                    item.PasswordDecrypt = string.Empty;
                else
                    item.PasswordDecrypt = deCrypt.Decrypt(item.Password, "UW");
            }


            return users;
        }

        public List<User> GetUserByBranch(string branchCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand(GetSql(10), db.Parameter("@BranchCode", branchCode))
                    .ExecuteList<User>();
            }
        }

        public User GetUserByCode(string branchCode, string userCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand(GetSql(50), db.Parameter("@UserCode", userCode))
                    .ExecuteObject<User>();
            }
        }

        public List<MenuPermission> GetMenuPermission(string branchCode, string userCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand(GetSql(44), db.Parameter("@UserCode", userCode))
                    .ExecuteList<MenuPermission>();
            }

        }

    }

}


