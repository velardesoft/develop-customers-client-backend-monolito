using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using u20211c221.Customers.Domain.Model.Commands;
using u20211c221.Customers.Domain.Model.Queries;
using u20211c221.Customers.Domain.Services;
using u20211c221.Customers.Interfaces.REST.Resources;
using u20211c221.Customers.Interfaces.REST.Transform;

namespace u20211c221.Customers.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("ClientManagement endpoints")]
public class ClientsController (IClientCommandService clientCommandService, IClientQueryService clientQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Create a car", OperationId = "CreateCar")]
    [SwaggerResponse(201, "Car created", typeof(ClientResource))]
    [SwaggerResponse(409, "Model already exists")]
    public async Task<IActionResult> CreateCar([FromBody] CreateClientCommand command)
    {
        var car = await clientCommandService.Handle(command);
        if (car == null) return Conflict();
        var resource = ClientResourceFromEntityAssembler.ToClientResourceFromEntity(car);
        return CreatedAtAction(nameof(GetCarById), new { id = resource.Id }, resource);
    }
    
    [HttpGet]
    [SwaggerOperation("Get all cars", OperationId = "GetAllCars")]
    [SwaggerResponse(200, "Cars found", typeof(IEnumerable<ClientResource>))]
    public async Task<IActionResult> GetAllCars()
    {
        var cars = await clientQueryService.Handle(new GetAllClientsQuery());
        var resources = cars.Select(ClientResourceFromEntityAssembler.ToClientResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation("Get car by Id", OperationId = "GetCarById")]
    [SwaggerResponse(200, "Car found", typeof(ClientResource))]
    [SwaggerResponse(404, "Car not found")]
    public async Task<IActionResult> GetCarById(int id)
    {
        var car = await clientQueryService.Handle(new GetClientByIdQuery(id));
        return car == null ? NotFound() : Ok(ClientResourceFromEntityAssembler.ToClientResourceFromEntity(car));
    }

}