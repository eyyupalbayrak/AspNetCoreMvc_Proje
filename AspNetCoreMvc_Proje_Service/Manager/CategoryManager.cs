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
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Add(Categories category)
        {
            _uow.GetCategoryRepository().Add(category);
            _uow.Commit();
        }

        public void Delete(Categories category)
        {
            _uow.GetCategoryRepository().Delete(category);
            _uow.Commit();
        }

        public List<CategoryViewModel> GetAll()
        {
            return _mapper.Map<List<CategoryViewModel>>(_uow.GetCategoryRepository().GetAll());
        }

        public CategoryViewModel GetById(int id)
        {
            return _mapper.Map<CategoryViewModel>(_uow.GetCategoryRepository().GetById(id));
        }

        public IEnumerable<CategoryViewModel> GetListAllByFilter(Expression<Func<Categories, bool>> filter, params Expression<Func<Categories, object>>[] includes)
        {

            var categoryList = _uow.GetCategoryRepository().GetListAllByFilter(filter, includes);

            return _mapper.Map<List<CategoryViewModel>>(categoryList);
        }

        public void Update(Categories category)
        {
            _uow.GetCategoryRepository().Update(category);
            _uow.Commit();
        }
    }
}
