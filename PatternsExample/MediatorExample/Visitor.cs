using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExample.MediatorExample;
public class Visitor
{
    private readonly IMediator _mediator;

    public Visitor(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Dinner> GiveOrder(IEnumerable<string> order)
    {
        Console.WriteLine("Visitor gave an order to waiter");
        var dinner = await _mediator.Send<FoodRequest, Dinner>(new FoodRequest(order));
        Console.WriteLine("Visitor took a dinner from waiter");
        return dinner;
    }
}
