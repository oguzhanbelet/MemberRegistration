using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHihabernate
{
    public class NhEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
    {
        NHibernateHelper _nHibarnateHelper;

        public NhEntityRepositoryBase(NHibernateHelper nHibarnateHelper)
        {
            _nHibarnateHelper = nHibarnateHelper;
        }

        public TEntity Add(TEntity entity)
        {
            using (var session=_nHibarnateHelper.OpenSession())
            {
                session.Save(entity);
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var session = _nHibarnateHelper.OpenSession())
            {
                session.Delete(entity);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var session = _nHibarnateHelper.OpenSession())
            {
                return session.Query<TEntity>().SingleOrDefault();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var session = _nHibarnateHelper.OpenSession())
            {
                return filter == null
                    ? session.Query<TEntity>().ToList()
                    : session.Query<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var session=_nHibarnateHelper.OpenSession())
            {
                session.Update(entity);
                return entity;
            }
        }
    }
}
