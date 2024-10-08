﻿using Dotnetstore.Intranet.Utility.Entities;

namespace Dotnetstore.Intranet.Utility.Repositories;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;

    Task SaveChangesAsync(CancellationToken cancellationToken);

    void Rollback();
}