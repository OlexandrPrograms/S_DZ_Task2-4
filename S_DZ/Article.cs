using System;
using System.Collections.Generic;
using System.Text;

namespace S_DZ
{
    internal class Article
    {
        public string Title { get; set; }
        public int CharacterCount { get; set; }
        public string Announcement { get; set; }

        public Article(string title, int characterCount, string announcement)
        {
            Title = title;
            CharacterCount = characterCount;
            Announcement = announcement;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Characters: {CharacterCount}, Announcement: {Announcement}";
        }
    }

    internal class Magazine
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public int PageCount { get; set; }
        public List<Article> Articles { get; set; }

        public Magazine(string title, string publisher, string releaseDate, int pageCount, List<Article> articles)
        {
            Title = title;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            PageCount = pageCount;
            Articles = articles;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Magazine: {Title}, Publisher: {Publisher}, Release Date: {ReleaseDate}, Pages: {PageCount}");
            sb.AppendLine("Articles:");
            foreach (var article in Articles)
            {
                sb.AppendLine($"  - {article}");
            }
            return sb.ToString();
        }
    }
}
