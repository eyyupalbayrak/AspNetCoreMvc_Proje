using AspNetCoreMvc_Proje_Entity.Entities;
using AspNetCoreMvc_Proje_Entity.Interfaces;
using AspNetCoreMvc_Proje_Entity.Services;
using AspNetCoreMvc_Proje_Entity.UnitOfWorks;
using AspNetCoreMvc_Proje_Entity.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Service.Manager
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public ProductManager(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Add(Products t)
        {
            _uow.GetProductRepository().Add(t);
            _uow.Commit();
        }

        public void Delete(Products t)
        {
            _uow.GetProductRepository().Delete(t);
            _uow.Commit();
        }

        public List<ProductViewModel> GetAll()
        {
            return _mapper.Map<List<ProductViewModel>>(_uow.GetProductRepository().GetAll());
        }

        public ProductViewModel GetById(int id)
        {
            return _mapper.Map<ProductViewModel>(_uow.GetProductRepository().GetById(id));
        }

        public IEnumerable<ProductViewModel> GetListAllByFilter(Expression<Func<Products, bool>> filter, params Expression<Func<Products, object>>[] includes)
        {
            var productsList = _uow.GetProductRepository().GetListAllByFilter(filter, includes);

            return _mapper.Map<List<ProductViewModel>>(productsList);
        }


        public void Update(Products t)
        {
            _uow.GetProductRepository().Update(t);
            _uow.Commit();
        }
    }
}
