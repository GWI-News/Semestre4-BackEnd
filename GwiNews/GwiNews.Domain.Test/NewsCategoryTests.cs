using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Test
{
    public class NewsCategoryTests
    {
        [Fact]
        public void Should_Create_Valid_NewsCategory()
        {
            var validName = "Categoria de Teste";

            var newsCategory = new NewsCategory(validName);

            Assert.NotNull(newsCategory);
            Assert.Equal(validName, newsCategory.Name);
            Assert.Empty(newsCategory.News);
            //Assert.Empty(newsCategory.NewsSubcategories);
        }

        [Fact]
        public void Should_Throw_Exception_When_Name_Is_Null()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new NewsCategory(null));
            Assert.Equal("O nome da categoria não pode ser vazio.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Name_Is_Empty()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new NewsCategory(""));
            Assert.Equal("O nome da categoria não pode ser vazio.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Name_Is_Too_Long()
        {
            var longName = new string('A', 26);

            var exception = Assert.Throws<DomainExceptionValidation>(() => new NewsCategory(longName));
            Assert.Equal("O nome da categoria não pode exceder 25 caracteres.", exception.Message);
        }
    }
}
