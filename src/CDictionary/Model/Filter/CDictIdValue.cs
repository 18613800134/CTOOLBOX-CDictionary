
namespace CDictionary.Model.Filter
{
    using System;
    using CAM.Core.Model.Entity;
    using CAM.Core.Model.Filter;

    public class CDictIdValueFilter : BaseFilter
    {
        public string Key { get; set; }
        public long OrganizationId { get; set; }
    }
}
