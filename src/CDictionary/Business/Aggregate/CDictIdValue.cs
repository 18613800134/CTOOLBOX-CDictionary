
namespace CDictionary.Business.Aggregate
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data.Entity.SqlServer;
    using System.Collections.Generic;

    using Model.Entity;
    using Model.Factory;
    using Model.Filter;

    using CAM.Core.Model.Entity;
    using CAM.Core.Business.Interface;
    using CAM.Core.Business.Aggregate;

    using Interface;
    using Rule;

    using CAM.Common.Data;
    using CAM.Common.Error;

    public partial class Aggregate : ICDictIdValueCommand
    {

        public long addDictIdValue(long OrganizationId, string Key, string Value)
        {
            try
            {
                IRepository<CDictIdValue> res = createRepository<CDictIdValue>();
                CDictIdValue dbObj = CDictIdValueFactory.createDict();

                dbObj.OrganizationId = OrganizationId;
                dbObj.Key = Key;
                dbObj.Value = Value;

                dbObj.addValidationRule(new DictIdValueCannotExistsSameDictRule(res, dbObj));

                dbObj.validate();
                res.add(dbObj);

                commit();

                return dbObj.Id;
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
                return 0;
            }
        }

        public void updateDictIdValue(long Id, string Value)
        {
            try
            {
                IRepository<CDictIdValue> res = createRepository<CDictIdValue>();
                CDictIdValue dbObj = res.read(m => m.Id == Id);

                dbObj.Value = Value;

                dbObj.addValidationRule(new DictIdValueCannotExistsSameDictRule(res, dbObj));

                dbObj.validate();
                res.update(dbObj);

                commit();

            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void deleteDictIdValue(long Id)
        {
            try
            {
                IRepository<CDictIdValue> res = createRepository<CDictIdValue>();

                res.delete(typeof(CDictIdValue), Id.ToString());

                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public IQueryable<CDictIdValue> readDictIdValueList(CDictIdValueFilter filter)
        {
            Expression<Func<CDictIdValue, bool>> lambda = FilterToLambdaBuilder.build<CDictIdValue, CDictIdValueFilter>(filter);

            if (!string.IsNullOrWhiteSpace(filter.Key))
            {
                lambda = lambda.And<CDictIdValue>(m => m.Key == filter.Key);
            }

            IQueryable<CDictIdValue> result = getDataByFilter<CDictIdValue, CDictIdValueFilter>(lambda, ref filter);
            return result;
        }
    }
}
