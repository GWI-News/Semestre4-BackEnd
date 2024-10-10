using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Test
{
    public class NewsTests
    {
        [Fact]
        public void Should_Throw_Exception_When_Title_Is_Null()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(
                Guid.NewGuid(),  // Supondo que um Guid é necessário
                null,            // Título
                "Conteúdo de Teste",
                "http://example.com",  // URL de exemplo
                null,   // Status de exemplo
                null,            // Outros parâmetros opcionais
                null,
                DateTime.Now,
                Guid.NewGuid(),
                null));         // Categoria de exemplo

            Assert.Equal("O título da notícia não pode ser vazio.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Title_Is_Empty()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(
                Guid.NewGuid(),
                "",
                "Conteúdo de Teste",
                "http://example.com",
                null,
                null,
                null,
                DateTime.Now,
                Guid.NewGuid(),
                null));

            Assert.Equal("O título da notícia não pode ser vazio.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Title_Is_Too_Long()
        {
            var longTitle = new string('A', 76);

            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(
                Guid.NewGuid(),
                longTitle,
                "Conteúdo de Teste",
                "http://example.com",
                null,
                null,
                null,
                DateTime.Now,
                Guid.NewGuid(),
                null));

            Assert.Equal("O título da notícia não pode exceder 75 caracteres.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Content_Is_Null()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(
                Guid.NewGuid(),
                "Título de Teste",
                null,
                "http://example.com",
                null,
                null,
                null,
                DateTime.Now,
                Guid.NewGuid(),
                null));

            Assert.Equal("O conteúdo da notícia não pode ser vazio.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Content_Is_Empty()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(
                Guid.NewGuid(),
                "Título de Teste",
                "",
                "http://example.com",
                null,
                null,
                null,
                DateTime.Now,
                Guid.NewGuid(),
                null));

            Assert.Equal("O conteúdo da notícia não pode ser vazio.", exception.Message);
        }

    }
}
