using DBEFModel;
using Platform.Core.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.UnitTest.EFRepositoryContext
{
    public class EFUnitTestRepositoryContext :RepositoryContext
    {
        private static object LockObj = new object();

        protected override System.Data.Entity.DbContext GetContext()
        {
            return new WebDesignEntities() as DbContext;
        }

        public override void Dispose()
        {
            if (HasContext())
            {
                base.Dispose();
            }
        }

        private bool HasContext()
        {
            return true;
        }
    }
}
