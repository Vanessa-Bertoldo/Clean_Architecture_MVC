using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        //Configuração para acesso ao context
        AplicationDbContext _categoryContext;
        public CategoryRepository(AplicationDbContext context) 
        {
            _categoryContext = context;
        } 
        public async Task<Category> Create(Category category)
        {
            _categoryContext.Add(category); //Salva os dados em memoria
            await _categoryContext.SaveChangesAsync(); //persiste os dados para o banco
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryContext.Categories.ToListAsync(); //Retorna a lista das categorias
        }

        public async Task<Category> GetCategoryById(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<Category> Remove(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync(); //persiste os dados para o banco
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync(); //persiste os dados para o banco
            return category;
        }
    }
}
