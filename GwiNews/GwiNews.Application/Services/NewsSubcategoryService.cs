using GwiNews.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwiNews.Application.Services
{
    public class NewsSubcategoryService
    {
        public class NewsSubcategoryService : INewsSubcategoryService
        {
            private readonly INewsSubcategoryRepository _newsSubcategoryRepository;

            // Construtor para injeção de dependência
            public NewsSubcategoryService(INewsSubcategoryRepository newsSubcategoryRepository)
            {
                _newsSubcategoryRepository = newsSubcategoryRepository;
            }

            // Retorna todas as subcategorias de notícias
            public async Task<IEnumerable<NewsSubcategory>> GetSubcategoriesAsync()
            {
                return await _newsSubcategoryRepository.GetAllAsync();
            }

            // Retorna uma subcategoria de notícias específica pelo ID
            public async Task<NewsSubcategory> GetByIdAsync(Guid id)
            {
                var subcategory = await _newsSubcategoryRepository.GetByIdAsync(id);
                if (subcategory == null)
                    throw new KeyNotFoundException("Subcategoria não encontrada.");
                return subcategory;
            }

            // Cria uma nova subcategoria de notícias
            public async Task<NewsSubcategory> CreateAsync(NewsSubcategory subcategory)
            {
                if (subcategory == null)
                    throw new ArgumentNullException(nameof(subcategory));

                // Validação e lógica adicional pode ser aplicada aqui

                return await _newsSubcategoryRepository.AddAsync(subcategory);
            }

            // Atualiza uma subcategoria existente
            public async Task<NewsSubcategory> UpdateAsync(NewsSubcategory subcategory)
            {
                if (subcategory == null)
                    throw new ArgumentNullException(nameof(subcategory));

                var existingSubcategory = await _newsSubcategoryRepository.GetByIdAsync(subcategory.Id);
                if (existingSubcategory == null)
                    throw new KeyNotFoundException("Subcategoria não encontrada.");

                // Lógica para atualizar os campos de "existingSubcategory" com os dados de "subcategory"
                existingSubcategory.Name = subcategory.Name;
                // Outros campos...

                return await _newsSubcategoryRepository.UpdateAsync(existingSubcategory);
            }

            // Remove uma subcategoria de notícias
            public async Task<NewsSubcategory> RemoveAsync(NewsSubcategory subcategory)
            {
                if (subcategory == null)
                    throw new ArgumentNullException(nameof(subcategory));

                var existingSubcategory = await _newsSubcategoryRepository.GetByIdAsync(subcategory.Id);
                if (existingSubcategory == null)
                    throw new KeyNotFoundException("Subcategoria não encontrada.");

                return await _newsSubcategoryRepository.RemoveAsync(existingSubcategory);
            }

            // Filtra subcategorias de notícias pelo nome
            public async Task<IEnumerable<NewsSubcategory>> GetFilteredAsync(string name)
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("O nome não pode ser vazio ou nulo.");

                return await _newsSubcategoryRepository.GetByNameAsync(name);
            }
        }
    }
}
