using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using Helpers;


namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().Select(ormrole => new DalRole()
            {
                Id = ormrole.Id,
                Name = ormrole.Name                
            });
        }

        public DalRole GetById(int key)
        {
            var ormrole = context.Set<Role>().FirstOrDefault(user => user.Id == key);
            return ConvertToDalRoleFromOrmRole(ormrole);
        }

        public IEnumerable<DalRole> GetByPredicate(Expression<Func<DalRole, bool>> f)
        {
            return context.Set<Role>().Where(ExpressionTransformer<DalRole, Role>.Transform(f)).Select(ormrole => new DalRole()
            {
                Id = ormrole.Id,
                Name = ormrole.Name            
            });
        }

        public void Create(DalRole e)
        {
            var role = new Role()
            {
                Name = e.Name
            };
            context.Set<Role>().Add(role);
        }

        public void Delete(DalRole e)
        {
            context.Set<Role>().Remove(context.Set<Role>().Where(m => m.Id == e.Id).FirstOrDefault());
        }

        public void Update(DalRole e)
        {
            var role = context.Set<Role>().Where(m => m.Id == e.Id).FirstOrDefault();
            role.Name = e.Name;
        }

        private DalRole ConvertToDalRoleFromOrmRole(Role ormrole)
        {
            return new DalRole()
            {
                Id = ormrole.Id,
                Name = ormrole.Name
            };
        }

    }
}
