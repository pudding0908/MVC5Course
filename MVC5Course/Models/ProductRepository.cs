using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
         {
             return base.All().Where(p => p.IsDelete == false);
         }
    public Product Find (int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }
        public IQueryable<Product> Get���o�Ҧ��|���R�����ӫ~���()
        {
            //return this.All().Where(p => p.IsDelete == false);
            return this.All();
        }
        public IQueryable<Product> Get���o�Ҧ��|���R�����ӫ~���Top10()
        {
            return this.All().Where(p => p.IsDelete == false).Take(10);
            //return this.All();
        }
    }
    


    public  interface IProductRepository : IRepository<Product>
	{

	}
}