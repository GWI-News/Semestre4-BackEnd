/*using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Test
{
    public class NewsTests
    {
        [Fact]
        public void Should_Throw_Exception_When_Title_Is_Null()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(
                Guid.NewGuid(),  // id
                null,            // status
                "http://example.com",  // newsUrl
                null,            // título (aqui deve ser null para o teste)
                "Conteúdo de Teste", // subtitle
                "Corpo da notícia",   // newsBody
                null,             // imageUrl
                DateTime.Now,    // publicationDate
                Guid.NewGuid(),   // userId
                null));          // newsCategory

            Assert.Equal("O título da notícia não pode ser vazio.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Title_Is_Empty()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(
                Guid.NewGuid(),
                null, // status
                "http://example.com",
                "",   // título
                "Conteúdo de Teste", // subtitle
                "Corpo da notícia",   // newsBody
                null, // imageUrl
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
                null,
                "http://example.com",
                longTitle,
                null,
                "Corpo da notícia",
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
                null,
                "http://example.com",
                "Titulo de Teste",
                "Subtitulo",
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
                null,
                "http://example.com",
                "titulo",
                "subtitulo",
                "",
                null,
                DateTime.Now,
                Guid.NewGuid(),
                null));

            Assert.Equal("O conteúdo da notícia não pode ser vazio.", exception.Message);
        }

    }
} */

