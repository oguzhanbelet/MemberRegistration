using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHihabernate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        NHibernateHelper _nHibarnateHelper;
        IQueryable<T> _entities;

        public NhQueryableRepository(NHibernateHelper nHibarnateHelper)
        {
            _nHibarnateHelper = nHibarnateHelper;
        }

        public IQueryable<T> Table 
        { 
            get  { return this.Entities; } 
        }

        public virtual IQueryable<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _nHibarnateHelper.OpenSession().Query<T>();
                }
                return _entities;
            }
        }
    }
}
