using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class ProfessionalSkillService
    {
        private readonly IProfessionalSkillRepository _professionalSkillRepository;

        public ProfessionalSkillService(IProfessionalSkillRepository professionalSkillRepository)
        {
            _professionalSkillRepository = professionalSkillRepository;
        }

        public async Task<IEnumerable<ProfessionalSkill>> GetAllProfessionalSkillsAsync()
        {
            return await _professionalSkillRepository.GetAllAsync();
        }

        public async Task<ProfessionalSkill> GetProfessionalSkillByIdAsync(Guid id)
        {
            return await _professionalSkillRepository.GetByIdAsync(id);
        }

        public async Task<ProfessionalSkill> CreateProfessionalSkillAsync(ProfessionalSkill skill)
        {
            ValidateSkill(skill);
            return await _professionalSkillRepository.CreateAsync(skill);
        }

        public async Task<ProfessionalSkill> UpdateProfessionalSkillAsync(ProfessionalSkill skill)
        {
            var existingSkill = await _professionalSkillRepository.GetByIdAsync(skill.Id);
            if (existingSkill == null)
            {
                throw new KeyNotFoundException("Habilidade não encontrada.");
            }

            ValidateSkill(skill);
            return await _professionalSkillRepository.UpdateAsync(skill);
        }

        public async Task DeleteProfessionalSkillAsync(Guid id)
        {
            var skill = await _professionalSkillRepository.GetByIdAsync(id);
            if (skill == null)
            {
                throw new KeyNotFoundException("Habilidade não encontrada.");
            }

            await _professionalSkillRepository.DeleteAsync(id);
        }

        private void ValidateSkill(ProfessionalSkill skill)
        {
            if (string.IsNullOrWhiteSpace(skill.Skill1))
            {
                throw new ArgumentException("A Skill1 é obrigatória.");
            }

            if (skill.Skill1.Length > 55)
            {
                throw new ArgumentException("A Skill1 não pode exceder 55 caracteres.");
            }

            if (skill.Skill2 != null && skill.Skill2.Length > 55)
            {
                throw new ArgumentException("A Skill2 não pode exceder 55 caracteres.");
            }

            if (skill.Skill3 != null && skill.Skill3.Length > 55)
            {
                throw new ArgumentException("A Skill3 não pode exceder 55 caracteres.");
            }

            if (skill.Skill4 != null && skill.Skill4.Length > 55)
            {
                throw new ArgumentException("A Skill4 não pode exceder 55 caracteres.");
            }
        }
    }
}
