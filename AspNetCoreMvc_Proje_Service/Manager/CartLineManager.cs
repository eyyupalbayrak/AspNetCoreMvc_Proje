using AspNetCoreMvc_Proje_Entity.Entities;
using AspNetCoreMvc_Proje_Entity.Interfaces;
using AspNetCoreMvc_Proje_Entity.Services;
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
    public class CartLineManager : ICartLineService
    {
        private readonly ICartLineDal _cartLineDal;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CartLineManager(ICartLineDal cartLineDal, IProductService productService, IMapper mapper)
        {
            _cartLineDal = cartLineDal;
            _productService = productService;
            _mapper = mapper;
        }

        public void Add(CartLine t)
        {
            _cartLineDal.Add(t);
        }

        public List<CartLineViewModel> AddCart(List<CartLineViewModel> cartline,int id,int quantity)
        {
            var product = _productService.GetById(id);
            CartLineViewModel newcartLine = new CartLineViewModel();
            newcartLine.Quantity = quantity;
            newcartLine.Product = _mapper.Map<Products>(product);
            newcartLine.ProductId = product.Id;
            newcartLine.TotalPrince = TotalPrince(cartline);

            if (cartline.Any(cl => cl.ProductId == newcartLine.ProductId))
            {
                foreach (CartLineViewModel item in cartline)
                {
                    if (item.ProductId == newcartLine.ProductId)
                    {
                        item.Quantity += newcartLine.Quantity;
                    }
                }
            }
            else
            {
                cartline.Add(newcartLine);
            }
            return cartline;

        }

        public void Delete(CartLine t)
        {
            _cartLineDal.Delete(t);
        }

        public List<CartLine> GetAll()
        {
            return _cartLineDal.GetAll();
        }

        public CartLine GetById(int id)
        {
            return _cartLineDal.GetById(id);
        }

        public IEnumerable<CartLine> GetListAllByFilter(Expression<Func<CartLine, bool>> filter, params Expression<Func<CartLine, object>>[] includes)
        {
            return _cartLineDal.GetListAllByFilter(filter, includes);
        }

        public List<CartLineViewModel> RemoveCart(List<CartLineViewModel> cartline, int id)
        {
            cartline.RemoveAll(cl => cl.ProductId == id);
            return cartline;
        }

        public decimal TotalPrince(List<CartLineViewModel> cartline)
        {
            decimal total = 0;
            if (cartline.Count != null)
            {
                foreach (var item in cartline)
                {
                    total += item.Quantity * item.Product.Price;
                }
            }

            return total;
        }

        public void Update(CartLine t)
        {
            _cartLineDal.Update(t);
        }
    }
}
