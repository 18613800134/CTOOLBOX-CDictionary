
namespace CDictionary.Model.Factory
{
    using CAM.Core.Model.Entity;
    using Entity;
    using System;

    public class CDictIdValueFactory
    {
        public static CDictIdValue createDict()
        {
            CDictIdValue dict = EntityBuilder.build<CDictIdValue>();
            dict.OrganizationId = 0;
            dict.Key = "";
            dict.Value = "";
            return dict;
        }
    }
}
