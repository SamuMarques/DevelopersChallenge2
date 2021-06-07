using DevelopersChallenge.Nibo.Domain;
using DevelopersChallenge.Nibo.Infra;
using DevelopersChallenge.Nibo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevelopersChallenge.Nibo.Repositories
{
    public class ExternalTransactionRepository : IExternalTransactionRepository
    {
        private readonly DataContext _dataContext;
        public ExternalTransactionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(List<ExternalTransaction> transactions)
        {
            _dataContext.BulkInsert(transactions, options => {
                options.InsertIfNotExists = true;
                options.ColumnPrimaryKeyExpression = c => c.Description;
                options.ColumnPrimaryKeyExpression = c => c.Type;
                options.ColumnPrimaryKeyExpression = c => c.Value;
                options.ColumnPrimaryKeyExpression = c => c.Date;
            });
        }

        public List<ExternalTransaction> List(DateTime startDate, DateTime finalDate, string type)
        {
            return _dataContext.Set<ExternalTransaction>()
                .Where(x => x.Date >= startDate || startDate == DateTime.MinValue)
                .Where(x => x.Date <= finalDate || finalDate == DateTime.MinValue)
                .Where(p => p.Type == type || type == null)
                .OrderBy(x => x.Date).ToList();
        }

        public void Delete(ExternalTransaction internalTransaction)
        {
            try
            {
                _dataContext.Remove(internalTransaction);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dataContext.SaveChanges();
            }
        }

        public ExternalTransaction GetById(int id)
        {
            return _dataContext.Find<ExternalTransaction>(id);
        }

        public void Update(ExternalTransaction externalTransaction)
        {
            try
            {
                _dataContext.Update(externalTransaction);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dataContext.SaveChanges();
            }
        }
    }
}
