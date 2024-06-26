﻿namespace CodePulse.API.Models.Dto
{
    public class UpdateBlogPostRequestDto
    {
        public string Title { get; set; }
        public string shortDescription { get; set; }
        public string Content { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool IsVisible { get; set; }
        public List<Guid> Categories { get; set; } = new List<Guid>();
    }
}
