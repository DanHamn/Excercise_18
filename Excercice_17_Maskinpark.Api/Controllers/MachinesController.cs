using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Excercice_17_Maskinpark.Core.Entities;
using Excercice_17_Maskinpark.Data.Data;
using Excercice_17_Maskinpark.Core.Repositories;
using AutoMapper;
using Excercice_17_Maskinpark.Core.Dto;

namespace Excercice_17_Maskinpark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MachinesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;
        }


        // GET: api/Machines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineDto>>> GetMachine()
        {
            var machinesList = (List<Machine>)await _unitOfWork.MachineRepository.GetAllCoursesAsync();
            var machinesDto = Ok(_mapper.Map<List<Machine>>(machinesList));
            return machinesDto;
        }


        // GET: api/Machines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MachineDto>> GetMachine(Guid id)
        {
            var machine = await _unitOfWork.MachineRepository.FindAsync(id);

            if (machine == null)
            {
                return NotFound();
            }
            var machineDto = Ok(_mapper.Map<Machine>(machine));
            return machineDto;
        }


        // PUT: api/Machines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachine(string id, [FromBody] Machine machine)
        {
            Guid machineid = Guid.Parse(id);
            if (machine == null)
                return BadRequest();

            if (string.IsNullOrEmpty(machine.Name))
                ModelState.AddModelError("Name", "The Name of the machine shouldn't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (machineid != machine.Id)
                return BadRequest();


            _unitOfWork.MachineRepository.Update(machine);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MachineExists(machineid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Machines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MachineDto>> PostMachine([FromBody] Machine machine)
        {
            if (machine == null)
                return BadRequest();

            if (string.IsNullOrEmpty(machine.Name))
                ModelState.AddModelError("Name", "The Name of the machine shouldn't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            _unitOfWork.MachineRepository.Add(machine);
            await _unitOfWork.CompleteAsync();

            var machineDto = Ok(_mapper.Map<Machine>(machine));

            return CreatedAtAction("GetMachine", new { id = machine.Id }, machineDto);
        }


        // DELETE: api/Machines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine(Guid? id)
        {
            if (id == null)
                return BadRequest();

            var machineToBeDeleted = await _unitOfWork.MachineRepository.FindAsync(id);
            if (machineToBeDeleted == null)
                return NotFound();


            _unitOfWork.MachineRepository.Remove(machineToBeDeleted);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        private async Task<bool> MachineExists(Guid id)
        {
            return await _unitOfWork.MachineRepository.AnyAsync(id);
        }
    }
}
