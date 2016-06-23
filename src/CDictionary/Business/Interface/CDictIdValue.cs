
namespace CDictionary.Business.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CAM.Core.Business.Interface;
    using Model.Entity;
    using Model.Filter;
    using DBContext;

    public interface ICDictIdValueCommand : IBaseInterfaceCommand<DBContextCDictionary>
    {
        long addDictIdValue(long OrganizationId, string Key, string Value);
        void updateDictIdValue(long Id, string Value);
        void deleteDictIdValue(long Id);

        IQueryable<CDictIdValue> readDictIdValueList(CDictIdValueFilter filter);
    }
}
