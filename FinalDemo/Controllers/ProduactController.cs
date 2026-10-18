using AutoMapper;
using FinalDemo.Dto;
using FinalDemo.Models;
using FinalDemo.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinalDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduactController : ControllerBase
    {
        private readonly IUnitOffWork unitOffWork;
        private readonly IMapper mapper;

        public ProduactController(IUnitOffWork unitOffWork, IMapper mapper)
        {
            this.unitOffWork = unitOffWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> pignation(int? Id, int page, int pagesize, string Sortby)
        {
            var sorting = await unitOffWork.proudactRepo.pignation(Id, page, pagesize, Sortby);

            var prodactdto = mapper.Map<List<ProductDto>>(sorting);

            return Ok(prodactdto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sorting = await unitOffWork.proudactRepo.GetbyId(id);
            var prodactdto = mapper.Map<ProductDto>(sorting);
            return Ok(prodactdto);
        }
        [HttpGet("socend/most/expencive/{id}")]
        public async Task<IActionResult> Mostexpensive(int id)
        {
            var sorting = await unitOffWork.proudactRepo.SocendMostexpensivproudact(id);
            var prodactdto = mapper.Map<ProductDto>(sorting);
            return Ok(prodactdto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDto createProductDto)
        {
            var product = mapper.Map<Product>(createProductDto);
            await unitOffWork.proudactRepo.Add(product);
            unitOffWork.savechanges();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditeinAll(int id,UpdateProductDto updateProductDto )
        {
            var product = await unitOffWork.proudactRepo.GetbyId(id);
            if (product == null) return NotFound();
            var productt = mapper.Map(updateProductDto, product);
            unitOffWork.proudactRepo.Update(product);
            unitOffWork.savechanges();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Edite(int id, UpdateStockDto  updateStockDto)
        {
            var product = await unitOffWork.proudactRepo.GetbyId(id);
            if (product == null) return NotFound();
            var productt = mapper.Map(updateStockDto, product);
            unitOffWork.proudactRepo.Update(product);
            unitOffWork.savechanges();
            return NoContent();
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string name )
        {
            var product = await unitOffWork.proudactRepo.SerachByName(name);
            var prodactdto = mapper.Map<List<ProductDto>>(product);
            return Ok(prodactdto);
        }

    }
}
