using DevelopersChallenge.Nibo.Domain;
using DevelopersChallenge.Nibo.Infra;
using DevelopersChallenge.Nibo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Repositories
{
    public class InternalTransactionRepository : IInternalTransactionRepository
    {
        private readonly DataContext _dataContext;
        public InternalTransactionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<InternalTransaction> List(DateTime startDate, DateTime finalDate, string type)
        {
            return _dataContext.Set<InternalTransaction>()
                .Where(x => x.Date >= startDate || startDate == DateTime.MinValue)
                .Where(x => x.Date <= finalDate || finalDate == DateTime.MinValue)
                .Where(p => p.Type == type || type == null)
                .ToList();
        }

        public void Create(InternalTransaction internalTransaction)
        {
            try
            {
                _dataContext.Add(internalTransaction);
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

        public void Delete(InternalTransaction internalTransaction)
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

        public InternalTransaction GetById(int id)
        {
            return _dataContext.Find<InternalTransaction>(id);
        }

        public void Update(InternalTransaction internalTransaction)
        {
            try
            {
                _dataContext.Update(internalTransaction);
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
