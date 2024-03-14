using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExample.MediatorExample;


public record FoodRequest(IEnumerable<string> MenuPositions) : IRequest<Dinner> { }
public class Waiter : IRequestHandler<FoodRequest, Dinner>
{
    private readonly IMediator _mediator;

    public Waiter(IMediator mediator)
    {
        mediator.AddHandler(this);
        _mediator = mediator;
    }

    public Type RequestType => typeof(FoodRequest);

    public async Task<Dinner> Handle(FoodRequest request, CancellationToken cancellationToken)
    {
        List<Food> Dishes = [];
        Console.WriteLine("Waiter took an order from visitor");
        foreach (var position in request.MenuPositions)
        {
            Dishes.Add(await _mediator.Send<CookRequest, Food>(new CookRequest(position), cancellationToken));
        }
        Console.WriteLine("Waiter took dishes from chef");
        return new Dinner(Dishes);
    }
}
