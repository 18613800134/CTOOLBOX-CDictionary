
namespace CDictionary.Business.DBContext
{
    using System.Data.Entity;
    using CAM.Common.Data;
    using Model.Entity;

    public class DBContextCDictionary : BaseDBContext<DBContextCDictionary>
    {
        public IDbSet<CDictIdValue> CDictIdValue { get; set; }
        
    }

    
}
