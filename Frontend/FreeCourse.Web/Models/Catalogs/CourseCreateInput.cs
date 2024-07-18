using System.ComponentModel.DataAnnotations;

namespace FreeCourse.Web.Models.Catalogs
{
    public class CourseCreateInput
    {
        [Display(Name="Kurs Adı")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Kurs Açıklaması")]
        [Required]
        public string? Description { get; set; }
        [Display(Name = "Kurs Fiyat")]
        [Required]
        public decimal? Price { get; set; }
        public string? Picture { get; set; }
        public string? UserId { get; set; }
        public FeatureViewModel? Feature { get; set; }
        [Display(Name = "Kurs Kategori")]
        [Required]
        public string? CategoryId { get; set; }
        [Display(Name ="Kurs Görsel")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
