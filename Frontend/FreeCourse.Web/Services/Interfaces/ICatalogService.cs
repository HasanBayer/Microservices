using FreeCourse.Web.Models.Catalogs;

namespace FreeCourse.Web.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<List<CourseViewModel>> GetAllCourseAsync();
        Task<List<CourseViewModel>> GetAllCourseGetByUserIdAsync(string userId);
        Task<List<CourseViewModel>>GetByCourseId(string courseId);
        Task<bool>DeleteCourseAsync(string courseId);
        Task<bool>CreateCourseAsync(CourseCreateInput courseCreateInput);
        Task<bool> UpdateCourseAsync(CourseUpdateInput courseUpdateInput);


    }
}
