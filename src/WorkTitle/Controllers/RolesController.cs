using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkTitle.Api.Models;
using WorkTitle.Api.ResponseModels.Role;
using WorkTitle.Application.RoleService.Commands;
using WorkTitle.Application.RoleService.Queries;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Api.Controllers
{
    /// <summary>
    /// API controller for managing roles.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the RolesController class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sender">The sender for MediatR requests.</param>
        public RolesController(ILogger<RolesController> logger, IMapper mapper, ISender sender)
        {            
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Uninitialized property");
            _sender = sender ?? throw new ArgumentNullException(nameof(sender), "Uninitialized property");
        }

        /// <summary>
        /// Retrieves a list of roles.
        /// </summary>
        /// <returns>A list of roles.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<RoleResponseShort>), 200)]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(_mapper.Map<List<RoleResponseShort>>(await _sender.Send(new GetRolesAsyncQuery())));
        }

        /// <summary>
        /// Retrieves a role by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the role.</param>
        /// <returns>The role with the specified identifier.</returns>
        [HttpGet("{id:Guid}", Name = "GetRoleById")]
        [ProducesResponseType(typeof(RoleResponseShort), 200)]
        public async Task<ActionResult> GetRoleById(Guid id)
        {
            var role = await _sender.Send(new GetRoleByIdAsyncQuery(id));

            return Ok(role);
        }

        /// <summary>
        /// Adds a new role.
        /// </summary>
        /// <param name="roleModel">The role details to add.</param>
        /// <returns>The newly added role.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(RoleResponseShort), 201)]
        public async Task<ActionResult> AddRole([FromBody] RoleModel roleModel)
        {
            var addedRole = await _sender.Send(new AddRoleAsyncCommand(_mapper.Map<RoleDto>(roleModel)));

            return CreatedAtRoute("GetRoleById", new { id = addedRole.Id }, _mapper.Map<RoleResponseShort>(addedRole));
        }

        /// <summary>
        /// Updates an existing role.
        /// </summary>
        /// <param name="id">The unique identifier of the role to update.</param>
        /// <param name="roleModel">The updated role details.</param>
        /// <returns>The updated role.</returns>
        [HttpPost("{id:Guid}")]
        [ProducesResponseType(typeof(RoleResponseShort), 202)]
        public async Task<ActionResult> UpdateRole(Guid id, [FromBody] RoleModel roleModel)
        {
            var updatedRole = await _sender.Send(new UpdateRoleAsyncCommand(id, _mapper.Map<RoleDto>(roleModel)));

            return AcceptedAtRoute("GetRoleById", new { id = updatedRole.Id }, _mapper.Map<RoleResponseShort>(updatedRole));
        }

        /// <summary>
        /// Deletes a role by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the role to delete.</param>
        /// <returns>A message confirming the deletion.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            await _sender.Send(new DeleteRoleAsyncCommand(id));

            return Ok($"Role with id = {id} has been removed");
        }
    }
}
