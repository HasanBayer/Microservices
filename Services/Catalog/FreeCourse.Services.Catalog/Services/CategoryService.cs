using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Settings;
using FreeCourse.Shared.Dtos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FreeCourse.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _categoryCollection = mongoDatabase.GetCollection<Category>(
                databaseSettings.Value.CategoryCollectionName);

            _mapper = mapper;
            
        }
     
        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category=>true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories),200);
        }

        public async Task<Response<CategoryDto>>CreateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category),200);
        }
        public async Task<Response<CategoryDto>>GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x=>x.Id==id).FirstOrDefaultAsync();
            if (category == null)
            {
                return Response<CategoryDto>.Fail("Category Not Found", 404);
            }
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category),200);
        }
    }
}
