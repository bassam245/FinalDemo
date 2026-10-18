using AutoMapper;
using FinalDemo.Dto;
using FinalDemo.Models;
using FinalDemo.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatogryController : ControllerBase
    {
        private readonly IUnitOffWork unitOffWork;
        private readonly IMapper mapper;

        public CatogryController(IUnitOffWork unitOffWork, IMapper mapper)
        {
            this.unitOffWork = unitOffWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cat = await unitOffWork.Catogryrepo.GetAll();
            var catdto = mapper.Map<List<CategoryDto>>(cat);
            return Ok(catdto);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            var cat = mapper.Map<Category>(createCategoryDto);

           await  unitOffWork.Catogryrepo.Add(cat);

            unitOffWork.savechanges();
            return Created();
        }
    }
}
