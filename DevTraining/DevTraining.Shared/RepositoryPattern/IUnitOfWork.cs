using DevTraining.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTraining.Shared.RepositoryPattern
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Contact> Contacts { get; }
        void Commit();
    }
}
