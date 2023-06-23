using AutoMapper;
using GeekShopping.ProductApi.Data.ValueObject;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Model.Context;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GeekShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlDataContext _context;
        private IMapper _mapper;

        public ProductRepository(MySqlDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
          return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            Product products = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(products);
        }
        public async Task<ProductVO> Create(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);

        }
        public async Task<ProductVO> Update(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
            
        }
   
        public async Task<bool> Delete(long id)
        {
            try
            {
                Product products = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (products == null) return false;            
                _context.Products.Remove(products);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception ) 
            {
                return false;

            }
        }


    }
}
