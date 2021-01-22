using DevTraining.Infrastructure.Data;

namespace DevTraining.Shared.RepositoryPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private DevTrainingContext _dbContext;
        private Repository<Core.Models.Contact> _contacts;

        public UnitOfWork(DevTrainingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Core.Models.Contact> Contacts
        {
            get
            {
                return _contacts ??= new Repository<Core.Models.Contact>(_dbContext);
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
