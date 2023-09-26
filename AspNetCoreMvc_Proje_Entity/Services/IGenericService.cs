using AspNetCoreMvc_Proje_Entity.Entities;
using AspNetCoreMvc_Proje_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Entity.Services
{
    public interface IGenericService<T> where T : class
    {
        public void Add(T t);
        public void Update(T t);
        public void Delete(T t);
    }
}
