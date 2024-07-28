using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryInterface _categoryInterface;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryInterface categoryInterface, IMapper mapper)
        {
            _categoryInterface = categoryInterface;
            _mapper = mapper;
        }
    }
}
