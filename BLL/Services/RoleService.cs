using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using System;
using Helpers;
using DAL.Interface.DTO;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {        
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }

        public void Create(RoleEntity entity)
        {
            roleRepository.Create(entity.ToDalRole());
            uow.Commit();
        }

        public void Edit(RoleEntity entity)
        {
            roleRepository.Update(entity.ToDalRole());
            uow.Commit();
        }

        public void Delete(RoleEntity entity)
        {
            roleRepository.Delete(entity.ToDalRole());
            uow.Commit();
        }
        
        public IEnumerable<RoleEntity> GetAllEntities()
        {
            return roleRepository.GetAll().Select(role => role.ToBllRole());
        }

        public RoleEntity GetById(int id)
        {
            return roleRepository.GetById(id).ToBllRole();
        }

        public IEnumerable<RoleEntity> GetByPredicate(Expression<Func<RoleEntity, bool>> p)
        {
            var transpormer = new ExpressionTransformer<RoleEntity, DalRole>(Expression.Parameter(typeof(DalRole), p.Parameters[0].Name));
            var expression = Expression.Lambda<Func<DalRole, bool>>(transpormer.Visit(p.Body), transpormer.NewParamExpr);
            return roleRepository.GetByPredicate(expression).Select(role => role.ToBllRole());
        }        
    }
}
