using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Entity.Interfaces
{
    public interface IGenericDal<T> where T : class, new()
    {
        public void Add(T t);
        public void Update(T t);
        public void Delete(T t);
        public List<T> GetAll();
        IEnumerable<T> GetListAllByFilter(Expression<Func<T, bool>> filter,params Expression<Func<T, object>>[] includes);
        public T GetById(int id);

    }
}
