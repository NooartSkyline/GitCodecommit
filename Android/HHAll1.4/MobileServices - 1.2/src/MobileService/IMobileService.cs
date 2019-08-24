﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace DoHome.MobileService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMobileService" in both code and config file together.
    [ServiceContract]
    public partial interface IMobileService
    {
   

        [OperationContract]
        string ApplicationTitle(string fromTitle,string branchCode, string wareHouseName);

        [OperationContract]
        string ApplicationSAPClient();

        [OperationContract]
        string ApplicationSAPServer();

        [OperationContract]
        string AccountingYear();

        [OperationContract]
        DateTime GetServerTime();

        [OperationContract]
        String GetServerTimeString();
    }


    
    
}
