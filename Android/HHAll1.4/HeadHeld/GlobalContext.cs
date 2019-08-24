using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DoHome.HandHeld.Client
{
    public class GlobalContext
    {
        public static int IndexFindType { get; set; }
        public static string FormType { get; set; }
        public static int IndexFormType { get; set; }
        public static string  HHDoc { get; set; }
        public static string  ZDoc { get; set; }
        public static string PDocNo { get; set; }
        public static bool IsDisable { get; set; }
        public static bool IsLoad { get; set; }
        public static string OldBranch { get; set; }
        public static string OldBranchName { get; set; }
        public static string OldWarehouse { get; set; }
        public static string OldWarehouseName { get; set; }
        private static string _userCode;
        private static string _userName;
        private static string _userPassword;
        private static string _branchCode;
        private static string _branchName;
        private static string _warehouseCode;
        private static string _warehouseName;
        private static bool _isShowPrice;
        private static bool _isShowSaleProfit;
        private static UseInPlaces _useInPlaces;
        private static string _shippointCode;

        public static string UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
        }

        public static string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public static string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        public static string BranchCode
        {
            get { return _branchCode; }
            set { _branchCode = value; }
        }

        public static string BranchName
        {
            get { return _branchName; }
            set { _branchName = value; }
        }

        public static string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        public static string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        public static string ShippointCode
        {
            get { return _shippointCode; }
            set { _shippointCode = value; }
        }

        public static bool IsShowPrice
        {
            get { return _isShowPrice; }
            set { _isShowPrice = value; }
        }

        public static bool IsShowSaleProfit
        {
            get { return _isShowSaleProfit; }
            set { _isShowSaleProfit = value; }
        }

        public static UseInPlaces UseInPlaces
        {
            get { return _useInPlaces; }
            set { _useInPlaces = value; }
        }

        public static string ApplicationTitle(string formTitle)
        {
            return ServiceHelper.MobileServices.ApplicationTitle(formTitle, _branchCode, _warehouseName);
        }

        public static string ServerEndpointAddress { get { return "192.168.0.37"; } }
        public static string remoteAddress { get { return "http://localhost/MobileAPI/MobileService.svc"; } } //ใช้จริง
        //public static string remoteAddress { get { return "http://localhost/MobileServiceTester/MobileService.svc"; } } //ใช้ทดสอบ

    }

    public enum UseInPlaces
    {
        WAREHOUSE,
        STORE
    }
}
