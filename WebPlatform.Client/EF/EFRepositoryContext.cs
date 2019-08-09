using DBEFModel;
using Platform.Core.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPlatform.Client.EF
{
    public class EFRepositoryContext : RepositoryContext
    {
        private static readonly object lockObj = new object();
        private static readonly string ContextKey = "EFContext";
        
        protected override System.Data.Entity.DbContext GetContext()
        {
            lock (lockObj)
            {
                if (!HasContext())
                {
                    WebDesignEntities entityDBContenxt = new WebDesignEntities();
                    HttpContext.Current.Items[ContextKey] = entityDBContenxt;
                }

                return HttpContext.Current.Items[ContextKey] as System.Data.Entity.DbContext;
            }
        }
        public override void Dispose()
        {
            if (HasContext())
            {
                base.Dispose();
                HttpContext.Current.Items[ContextKey] = null;
                HttpContext.Current.Items.Remove(ContextKey);
            }
        }
        private static bool HasContext()
        {
            return HttpContext.Current.Items.Contains("EFContext") && HttpContext.Current.Items["EFContext"] != null;
        }
    }
}