﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Activation;
using SAP.Middleware.Connector;

namespace DoHome.MobileService
{
    public partial interface IMobileService
    {
        [OperationContract]
        List<SapDepartment> SapDepartmentGetByLocationCode(string branchCode, string warehouseCode, string locationCode);

        [OperationContract]
        string SapDepartmentTextGetByLocationCode(string branchCode, string warehouseCode, string locationCode);

        [OperationContract]
        List<SapDepartment> SapDepartmentGetByProductCode(string branchCode, string productCode);

        [OperationContract]
        string SapDepartmentTextGetByProductCode(string branchCode, string productCode);
    }

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class MobileService : IMobileService
    {
        private string SapFormatProductCode(string productCode)
        {
            return productCode.PadLeft(18, Convert.ToChar("0"));
        }

        public List<SapDepartment> SapDepartmentGetByLocationCode(string branchCode, string warehouseCode, string locationCode)
        {
            RfcDestination sapRfcDestination = SapHelper.Destination;
            RfcRepository sapRfcRepository = sapRfcDestination.Repository;

            RfcRepository repo = sapRfcRepository;
            string bapiName = "ZDD_EXPORT_SELLER_FROM_LOCATE";
            IRfcFunction exportBapi = repo.CreateFunction(bapiName);
            exportBapi.SetValue("I_BIN_CODE", locationCode);
            exportBapi.SetValue("I_LGORT", warehouseCode);
            exportBapi.SetValue("I_WERKS", branchCode);
            exportBapi.Invoke(sapRfcDestination);
            IRfcTable detail = exportBapi.GetTable("O_TLOGT");

            var sapDepartment = new List<SapDepartment>();

            foreach (var item in detail)
            {
                if (!sapDepartment.Exists(p => p.DepartmentCode == item.GetString("LOGGR")))
                {
                    sapDepartment.Add(new SapDepartment
                    {
                        DepartmentCode = item.GetString("LOGGR"),
                        DepartmentName = item.GetString("LTEXT")
                    });
                }
            }

            return sapDepartment;
        }

        public string SapDepartmentTextGetByLocationCode(string branchCode, string warehouseCode, string locationCode)
        {
            var departments = SapDepartmentGetByLocationCode(branchCode, warehouseCode, locationCode);
            var department = string.Empty;
            foreach (var item in departments)
            {
                if (!string.IsNullOrEmpty(department))
                    department += " , ";
                department += string.Format("{0}-{1}", item.DepartmentCode, item.DepartmentName);
            }
            return department;
        }
        public List<SapDepartment> SapDepartmentGetByProductCode(string branchCode, string productCode)
        {
            RfcDestination sapRfcDestination = SapHelper.Destination;
            RfcRepository sapRfcRepository = sapRfcDestination.Repository;

            RfcRepository repo = sapRfcRepository;
            string bapiName = "ZDD_EXPORT_TABLE_ZMATSELLER";
            IRfcFunction exportBapi = repo.CreateFunction(bapiName);
            exportBapi.SetValue("IN_MATNR", SapFormatProductCode(productCode));
            exportBapi.Invoke(sapRfcDestination);
            IRfcTable detail = exportBapi.GetTable("IN_ZMAT_SELLER");

            var sapDepartment = new List<SapDepartment>();

            foreach (var item in detail)
            {
                if (branchCode.Equals(item["WERKS"].GetString()))
                {
                    sapDepartment.Add(new SapDepartment
                    {
                        DepartmentCode = detail.GetString("LOGGR"),
                        DepartmentName = detail.GetString("LTEXT")
                    });
                }
            }

            return sapDepartment;
        }

        public string SapDepartmentTextGetByProductCode(string branchCode, string productCode)
        {
            var departments = SapDepartmentGetByProductCode(branchCode, productCode);
            var department = string.Empty;
            foreach (var item in departments)
            {
                if (!string.IsNullOrEmpty(department))
                    department += " , ";
                department += string.Format("{0}-{1}", item.DepartmentCode, item.DepartmentName);
            }
            return department;
        }
    }
}