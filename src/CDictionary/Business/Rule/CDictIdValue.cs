
namespace CDictionary.Business.Rule
{
    using System.ComponentModel.DataAnnotations;
    using CAM.Core.Business.Rule;
    using CAM.Core.Model.Validation;
    using CAM.Common.Data;
    using Model.Entity;

    public class DictIdValueCannotExistsSameDictRule : BaseRule<CDictIdValue>
    {
        public DictIdValueCannotExistsSameDictRule(IRepository<CDictIdValue> res, CDictIdValue checkObj)
            : base(res, checkObj)
        {

        }

        public override ValidationResult validate()
        {
            ValidationResult result = ValidationResult.Success;
            if (_res.exists(m => m.Id != _checkObj.Id && m.System.DeleteFlag == false && m.Key == _checkObj.Key && m.Value == _checkObj.Value && (m.OrganizationId == _checkObj.OrganizationId || m.OrganizationId == 0)))
            {
                result = createValidationResult("Value", string.Format("【{0}】这个字典项已经存在！", _checkObj.Value));
            }
            return result;
        }
    }

   


}
