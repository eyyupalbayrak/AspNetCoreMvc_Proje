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
    public class SaleDetailsManager : ISaleDetailsService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public SaleDetailsManager(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Add(SaleDetails saleDetails)
        {
            //Gelen veriyi önce ara katmana sonra veri tabanına kayıt edilme işlemi.
            _uow.GetSaleDetailsRepository().Add(saleDetails);
            _uow.Commit();  //SaveChanges() işlemi.
        }

        public void Delete(SaleDetails saleDetails)
        {
            //Gelen veriyi silme işlemi.
            _uow.GetSaleDetailsRepository().Delete(saleDetails);
            _uow.Commit();  //SaveChanges() işlemi.
        }

        public List<SaleDetailsViewModel> GetAll()
        {
            //SaleDetails olarak gelen veriyi SaleDetailsViewModel'e mapping yaparak UI katmanına gönderme işlemi.
            return _mapper.Map<List<SaleDetailsViewModel>>(_uow.GetSaleDetailsRepository().GetAll());
        }

        public SaleDetailsViewModel GetById(int id)
        {
            //İdye göre gelen veriyi SaleDetailsViewModele mapledikten sonra gönderiyoruz.
            return _mapper.Map<SaleDetailsViewModel>(_uow.GetSaleDetailsRepository().GetById(id));
        }

        public IEnumerable<SaleDetailsViewModel> GetListAllByFilter(Expression<Func<SaleDetails, bool>> filter, params Expression<Func<SaleDetails, object>>[] includes)
        {
            var saleDetailsList = _uow.GetSaleDetailsRepository().GetListAllByFilter(filter, includes);

            return _mapper.Map<List<SaleDetailsViewModel>>(saleDetailsList);
        }

        public void Update(SaleDetails saleDetails)
        {
            //Gelen veriyi veri tabanında güncelleme işlemi.
            _uow.GetSaleDetailsRepository().Update(saleDetails);
            _uow.Commit();  //SaveChanges() işlemi.
        }
    }
}
