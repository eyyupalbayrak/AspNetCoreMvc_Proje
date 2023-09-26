using AspNetCoreMvc_Proje_Entity.Entities;
using AspNetCoreMvc_Proje_Entity.Interfaces;
using AspNetCoreMvc_Proje_Entity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Service.Manager
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void Add(Cart t)
        {
            _cartDal.Add(t);
        }

        public void Delete(Cart t)
        {
            _cartDal.Delete(t);
        }

        public List<Cart> GetAll()
        {
            return _cartDal.GetAll();   
        }

        public Cart GetById(int id)
        {
            return _cartDal.GetById(id);
        }

        public IEnumerable<Cart> GetListAllByFilter(Expression<Func<Cart, bool>> filter, params Expression<Func<Cart, object>>[] includes)
        {
            return _cartDal.GetListAllByFilter(filter, includes);   
        }

        public void Update(Cart t)
        {
            _cartDal.Update(t);
        }
    }
}
