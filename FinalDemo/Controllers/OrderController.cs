using AutoMapper;
using FinalDemo.Dto;
using FinalDemo.Models;
using FinalDemo.Repos.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOffWork unitOffWork;
        private readonly IMapper mapper;

        public OrderController(IUnitOffWork unitOffWork, IMapper mapper)
        {
            this.unitOffWork = unitOffWork;
            this.mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyID(int id)
        {
            var order = await unitOffWork.orderrepo.GetwithItemsTotallAmount(id);
            var orderdto = mapper.Map<OrderDto>(order);
            return Ok(orderdto);
        }
        [HttpGet("Tottalrenue")]
        public async Task<IActionResult> GetTottalRenue()
        {
            var order = await unitOffWork.orderrepo.TottallRenue();
            return Ok(order);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit(int id, UpdateOrderStatusDto updateOrderStatusDto)
        {
            var order = await unitOffWork.orderrepo.GetbyId(id);
            if (order == null) return NotFound();

            var mapp = mapper.Map(updateOrderStatusDto, order);

            unitOffWork.orderrepo.Update(order);
            unitOffWork.savechanges();
            return NoContent();

        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult>Add(CreateOrderDto createOrderDto)
        {
            var mapp = mapper.Map<Order>(createOrderDto);
            await unitOffWork.orderrepo.Add(mapp);
            unitOffWork.savechanges();
            return Created();

        }

    }
}
