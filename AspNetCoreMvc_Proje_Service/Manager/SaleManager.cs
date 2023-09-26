using AspNetCoreMvc_Proje_Entity.Entities;
using AspNetCoreMvc_Proje_Entity.Services;
using AspNetCoreMvc_Proje_Entity.UnitOfWorks;
using AspNetCoreMvc_Proje_Entity.ViewModels;
using AutoMapper;
using System.Linq.Expressions;

namespace AspNetCoreMvc_Proje_Service.Manager
{
    public class SaleManager : ISaleService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public SaleManager(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Add(Sale sale)
        {
            _uow.GetSaleRepository().Add(sale);
            _uow.Commit();
        }

        public void Delete(Sale sale)
        {
            _uow.GetSaleRepository().Delete(sale);
            _uow.Commit();
        }

        public List<SaleViewModel> GetAll()
        {
            return _mapper.Map<List<SaleViewModel>>(_uow.GetSaleRepository().GetAll());
        }

        public SaleViewModel GetById(int id)
        {
            return _mapper.Map<SaleViewModel>(_uow.GetSaleRepository().GetById(id));
        }

        public IEnumerable<SaleViewModel> GetListAllByFilter(Expression<Func<Sale, bool>> filter, params Expression<Func<Sale, object>>[] includes)
        {
            var saleList = _uow.GetSaleRepository().GetListAllByFilter(filter, includes);

            return _mapper.Map<List<SaleViewModel>>(saleList);
        }

        public void Update(Sale sale)
        {
            _uow.GetSaleRepository().Update(sale);
            _uow.Commit();
        }
    }
}
