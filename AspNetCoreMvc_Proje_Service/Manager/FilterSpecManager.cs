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
    public class FilterSpecManager : IFilterSpecService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public FilterSpecManager(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Add(FilterSpecs filterspec)
        {
            _uow.GetFilterSpecsRepository().Add(filterspec);
            _uow.Commit();
        }

        public void Delete(FilterSpecs filterspec)
        {
            _uow.GetFilterSpecsRepository().Delete(filterspec);
            _uow.Commit();
        }

        public List<FilterSpecsViewModel> GetAll()
        {            
            return _mapper.Map<List<FilterSpecsViewModel>>(_uow.GetFilterSpecsRepository().GetAll());
        }

        public FilterSpecsViewModel GetById(int id)
        {
            return _mapper.Map<FilterSpecsViewModel>(_uow.GetFilterSpecsRepository().GetById(id));
        }

        public IEnumerable<FilterSpecsViewModel> GetListAllByFilter(Expression<Func<FilterSpecs, bool>> filter, params Expression<Func<FilterSpecs, object>>[] includes)
        {
            var filterSpecsList = _uow.GetFilterSpecsRepository().GetListAllByFilter(filter, includes);

            return _mapper.Map<List<FilterSpecsViewModel>>(filterSpecsList);
        }
        
        public void Update(FilterSpecs filterspec)
        {
            _uow.GetFilterSpecsRepository().Update(filterspec);
            _uow.Commit();
        }
    }
}
