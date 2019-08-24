using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;

namespace SapServices
{
    public class Service
    {
        
        public List<SapDepartment> SapDepartmentGetByLocationCode(string branchCode, string warehouseCode, string locationCode)
        {
            RfcDestination sapRfcDestination = SapHelper.Destination;
            RfcRepository sapRfcRepository = sapRfcDestination.Repository;

            RfcRepository repo = sapRfcRepository;
            string bapiName = "ZDD_EXPORT_SELLER_FROM_LOCATE";
            IRfcFunction companyBapi = repo.CreateFunction(bapiName);
            companyBapi.SetValue("I_BIN_CODE", locationCode);
            companyBapi.SetValue("I_LGORT", warehouseCode);
            companyBapi.SetValue("I_WERKS", branchCode);
            companyBapi.Invoke(sapRfcDestination);
            IRfcTable detail = companyBapi.GetTable("O_TLOGT");

            var sapDepartment = new List<SapDepartment>();

            foreach (var item in detail)
            {
                sapDepartment.Add(new SapDepartment
                {
                    DepartmentCode = detail.GetString("LOGGR"),
                    DepartmentName = detail.GetString("LTEXT")
                });
            }

            return sapDepartment;
        }
    }
}
