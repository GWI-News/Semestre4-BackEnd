//using GwiNews.Application.Interfaces;
//using GwiNews.Domain.Entities;
//using GwiNews.Domain.Interfaces;

//namespace GwiNews.Application.Services
//{
//    public class FormationService : IFormationService
//    {
//        private readonly IFormationRepository _formationRepository;

//        public FormationService(IFormationRepository formationRepository)
//        {
//            _formationRepository = formationRepository;
//        }

//        public async Task<IEnumerable<Formation>> GetAllFormationsAsync()
//        {
//            return await _formationRepository.GetAllAsync();
//        }

//        public async Task<Formation> GetFormationByIdAsync(Guid id)
//        {
//            return await _formationRepository.GetByIdAsync(id);
//        }

//        public async Task<Formation> CreateFormationAsync(Formation formation)
//        {
//            if (formation == null)
//                throw new ArgumentNullException(nameof(formation));

//            return await _formationRepository.CreateAsync(formation);
//        }

//        public async Task<Formation> UpdateFormationAsync(Formation formation)
//        {
//            if (formation == null)
//                throw new ArgumentNullException(nameof(formation));

//            return await _formationRepository.UpdateAsync(formation);
//        }

//        public async Task DeleteFormationAsync(Guid id)
//        {
//            var formation = await _formationRepository.GetByIdAsync(id);

//            if (formation == null)
//                throw new KeyNotFoundException("Formation not found.");

//            await _formationRepository.DeleteAsync(id);
//        }
//    }
//}
