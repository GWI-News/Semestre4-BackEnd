using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;
using System;
using Xunit;

namespace GwiNews.Domain.Test
{
    public class NewsTests
    {
        [Fact]
        public void Constructor_WithValidParameters_ShouldCreateNews()
        {
            var news = new News(
                Guid.NewGuid(),
                NewsStatus.Publicada,
                "https://example.com/news",
                "Título da Notícia",
                "Subtítulo da Notícia",
                "Corpo da notícia.",
                "https://example.com/image.jpg",
                DateTime.Now
            //new NewsCategory()
            );

            Assert.NotNull(news);
            Assert.Equal(NewsStatus.Publicada, news.Status);
            Assert.Equal("Título da Notícia", news.Title);
            Assert.Equal("Subtítulo da Notícia", news.Subtitle);
            Assert.Equal("Corpo da notícia.", news.NewsBody);
            Assert.Equal("https://example.com/news", news.NewsUrl);
            Assert.Equal("https://example.com/image.jpg", news.ImageUrl);
        }

        [Fact]
        public void ValidateDomain_WithValidParameters_ShouldSetProperties()
        {
            var news = new News();
            news.ValidateDomain(
                NewsStatus.Publicada,
                "https://example.com/news",
                "Título da Notícia",
                "Subtítulo da Notícia",
                "Corpo da notícia.",
                "https://example.com/image.jpg",
                DateTime.Now
                //new NewsCategory()
            );

            Assert.Equal(NewsStatus.Publicada, news.Status);
            Assert.Equal("Título da Notícia", news.Title);
            Assert.Equal("Subtítulo da Notícia", news.Subtitle);
            Assert.Equal("Corpo da notícia.", news.NewsBody);
            Assert.Equal("https://example.com/news", news.NewsUrl);
            Assert.Equal("https://example.com/image.jpg", news.ImageUrl);
        }

        [Fact]
        public void ValidateDomain_WithEmptyNewsUrl_ShouldThrowDomainException()
        {
            var news = new News();
            Assert.Throws<DomainExceptionValidation>(() => news.ValidateDomain(
                NewsStatus.Publicada,
                "",
                "Título da Notícia",
                "Subtítulo da Notícia",
                "Corpo da notícia.",
                "https://example.com/image.jpg",
                DateTime.Now
                //new NewsCategory()
            ));
        }

        [Fact]
        public void ValidateDomain_WithLongTitle_ShouldThrowDomainException()
        {
            var news = new News();
            Assert.Throws<DomainExceptionValidation>(() => news.ValidateDomain(
                NewsStatus.Publicada,
                "https://example.com/news",
                new string('A', 76),
                "Subtítulo da Notícia",
                "Corpo da notícia.",
                "https://example.com/image.jpg",
                DateTime.Now
                //new NewsCategory()
            ));
        }

        [Fact]
        public void ValidateDomain_WithLongSubtitle_ShouldThrowDomainException()
        {
            var news = new News();
            Assert.Throws<DomainExceptionValidation>(() => news.ValidateDomain(
                NewsStatus.Publicada,
                "https://example.com/news",
                "Título da Notícia",
                new string('A', 256),
                "Corpo da notícia.",
                "https://example.com/image.jpg",
                DateTime.Now
                //new NewsCategory()
            ));
        }

        [Fact]
        public void ValidateDomain_WithEmptyTitle_ShouldThrowDomainException()
        {
            var news = new News();
            Assert.Throws<DomainExceptionValidation>(() => news.ValidateDomain(
                NewsStatus.Publicada,
                "https://example.com/news",
                "",
                "Subtítulo da Notícia",
                "Corpo da notícia.",
                "https://example.com/image.jpg",
                DateTime.Now
                //new NewsCategory()
            ));
        }

        [Fact]
        public void ValidateDomain_WithLongNewsBody_ShouldThrowDomainException()
        {
            var news = new News();
            Assert.Throws<DomainExceptionValidation>(() => news.ValidateDomain(
                NewsStatus.Publicada,
                "https://example.com/news",
                "Título da Notícia",
                "Subtítulo da Notícia",
                new string('A', 65536),
                "https://example.com/image.jpg",
                DateTime.Now
                //new NewsCategory()
            ));
        }

        [Fact]
        public void ValidateDomain_WithLongImageUrl_ShouldThrowDomainException()
        {
            var news = new News();
            Assert.Throws<DomainExceptionValidation>(() => news.ValidateDomain(
                NewsStatus.Publicada,
                "https://example.com/news",
                "Título da Notícia",
                "Subtítulo da Notícia",
                "Corpo da notícia.",
                new string('A', 556),
                DateTime.Now
                //new NewsCategory()
            ));
        }

        [Fact]
        public void ValidateDomain_WithNullCategory_ShouldThrowDomainException()
        {
            var news = new News();
            Assert.Throws<DomainExceptionValidation>(() => news.ValidateDomain(
                NewsStatus.Publicada,
                "https://example.com/news",
                "Título da Notícia",
                "Subtítulo da Notícia",
                "Corpo da notícia.",
                "https://example.com/image.jpg",
                DateTime.Now
                //null
            ));
        }
    }
}
