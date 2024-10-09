using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;
using System;
using Xunit;

namespace GwiNews.Domain.Test
{
    public class NewsTests
    {

        [Fact]
        public void Should_Throw_Exception_When_Title_Is_Null()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(null, "Conteúdo de Teste"));
            Assert.Equal("O título da notícia não pode ser vazio.", exception.Message);
        }

        [Fact]

        public void Should_Throw_Exception_When_Title_Is_Empty()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News("", "Conteúdo de Teste"));
            Assert.Equal("O título da notícia não pode ser vazio.", exception.Message);
        }

        [Fact]

        public void Should_Throw_Exception_When_Title_Is_Too_Long()
        {
            var longTitle = new string('A', 76);

            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(longTitle, "Conteúdo de Teste"));
            Assert.Equal("O título da notícia não pode exceder 75 caracteres.", exception.Message);
        }

        [Fact]

        public void Should_Throw_Exception_When_Content_Is_Null()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News("Título de Teste", null));
            Assert.Equal("O conteúdo da notícia não pode ser vazio.", exception.Message);
        }

        [Fact]

        public void Should_Throw_Exception_When_Content_Is_Empty()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News("Título de Teste", ""));
            Assert.Equal("O conteúdo da notícia não pode ser vazio.", exception.Message);
        }

    }
}
