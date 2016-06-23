
namespace CDictionary.Business.Aggregate
{
    using CAM.Core.Business.Interface;
    using CAM.Core.Business.Aggregate;
    using DBContext;

    public partial class Aggregate : BaseAggregate, IBaseInterfaceCommand<DBContextCDictionary>
    {
        public Aggregate()
        {
            this.dbContext = new DBContextCDictionary();
        }

        public DBContextCDictionary DBContext
        {
            get { return (DBContextCDictionary)this.dbContext; }
        }
    }
}
