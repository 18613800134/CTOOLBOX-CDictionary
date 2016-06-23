using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CAM.Common.DataProtocol;

using CDictionary.Model.Entity;
using CDictionary.Model.Filter;
using CDictionary.Business.Interface;
using CDictionary.Business.Aggregate;


using CAM.Common.Merge;
using CAM.Common.QueryMaker;

using CDictionary.Model.Mixin;
using COrganization.Model.Mixin;
using CMapping.Model.Mixin;

namespace UnitTestForCDictionary
{
    /// <summary>
    /// TestForCDictIdValue 的摘要说明
    /// </summary>
    [TestClass]
    public class TestForCDictIdValue
    {
        public TestForCDictIdValue()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TryAddDictIdValue()
        {
            try
            {
                ICDictIdValueCommand ic = new CDictionary.Business.Aggregate.Aggregate();
                long newId = ic.addDictIdValue(1, "Scale", "中型企业");

                Console.WriteLine("ok, newid={0}", newId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DataPackager.packError(ex));
            }
        }


        [TestMethod]
        public void TryReadOrganizationInfoWithIndustry()
        {
            try
            {
                Type ViewMode = null;
                ViewMode = ViewMode.Merge(typeof(COrganizationMixin))
                                   .Merge(typeof(CDictIdValueMixin));

                QueryMakerObjectQueue qm = new QueryMakerObjectQueue();
                qm = qm.select(typeof(COrganization.Model.Entity.COrgOrganization), typeof(COrganizationMixin), "org")
                       .leftjoin(typeof(CDictIdValue), typeof(CDictIdValueMixin), "industry", "org.IndustryId=industry.Id and industry.OrganizationId=1")
                       .where("where org.Id=1");

                COrganization.Model.Filter.COrgOrganizationFilter filter = new COrganization.Model.Filter.COrgOrganizationFilter();
                filter.OrderName[0] = "COrganizationMixin_Id";
                
                ICDictIdValueCommand ic = new CDictionary.Business.Aggregate.Aggregate();

                object o = qmHelper.readMixinList(ic, ViewMode, qm, typeof(COrganization.Model.Filter.COrgOrganizationFilter), filter);

                string sss = DataPackager.packIt(o, filter.PageInfo);
                Console.WriteLine(sss);
                Console.WriteLine(DataPackager.packIt(o, filter.PageInfo));
            }
            catch (Exception ex)
            {
                Console.WriteLine(DataPackager.packError(ex));
            }
        }

    }
}
