using AspNetCoreMvc_Proje_Entity.Entities;
using AspNetCoreMvc_Proje_Entity.Services;
using AspNetCoreMvc_Proje_Entity.UnitOfWorks;
using AspNetCoreMvc_Proje_Entity.ViewModels;
using AutoMapper;
using System.Linq.Expressions;


namespace AspNetCoreMvc_Proje_Service.Manager
{
    public class ProductSpecsManager : IProductSpecsService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public ProductSpecsManager(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Add(ProductSpecs productSpecs)
        {
            _uow.GetProductSpecsRepository().Add(productSpecs);
            _uow.Commit();
        }

        public void Delete(ProductSpecs productSpecs)
        {
            _uow.GetProductSpecsRepository().Delete(productSpecs);
            _uow.Commit();
        }

        public List<ProductSpecsViewModel> GetAll()
        {
            return _mapper.Map<List<ProductSpecsViewModel>>(_uow.GetProductSpecsRepository().GetAll());
        }

        public ProductSpecsViewModel GetById(int id)
        {
            return _mapper.Map<ProductSpecsViewModel>(_uow.GetProductSpecsRepository().GetById(id));
        }

        public IEnumerable<ProductSpecsViewModel> GetListAllByFilter(Expression<Func<ProductSpecs, bool>> filter, params Expression<Func<ProductSpecs, object>>[] includes)
        {
            var productSpecsList = _uow.GetProductSpecsRepository().GetListAllByFilter(filter, includes);    

            return _mapper.Map<List<ProductSpecsViewModel>>(productSpecsList);
        }

        public void Update(ProductSpecs productSpecs)
        {
            _uow.GetProductSpecsRepository().Update(productSpecs);
            _uow.Commit();
        }
    }
}
