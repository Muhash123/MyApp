using MediatR;
using System.Runtime.ConstrainedExecution;
using TMCars.Domain.Entities;

namespace TMCars.Application.Cars.Commands;

// The Command (What you want to do)
public record CreateCarCommand(
    string Brand, string Model, int Year, decimal Price, string Location) : IRequest<int>;

// The Handler (How to do it)
public class CreateCarHandler(IAppDbContext context) : IRequestHandler<CreateCarCommand, int>
{
    public async Task<int> Handle(CreateCarCommand request, CancellationToken ct)
    {
        var car = new Car
        {
            Brand = request.Brand,
            Model = request.Model,
            Year = request.Year,
            Price = request.Price,
            Location = request.Location
        };

        context.Cars.Add(car);
        await context.SaveChangesAsync(ct);
        return car.Id;
    }
}