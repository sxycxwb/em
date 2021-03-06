﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using System;

namespace EM.EntityFramework.Repositories
{
    public abstract class EMRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<EMDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected EMRepositoryBase(IDbContextProvider<EMDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories

    
    }

    public abstract class EMRepositoryBase<TEntity> : EMRepositoryBase<TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        protected EMRepositoryBase(IDbContextProvider<EMDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
