using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExample.MediatorExample;

public record CookRequest(string MenuPosition) : IRequest<Food> { }
public class Chef : IRequestHandler<CookRequest, Food>
{
    public Type RequestType => typeof(CookRequest);

    public Chef(IMediator mediator)
    {
        mediator.AddHandler(this);
    }
    private bool IsEnoughIngridients(string MenuPosition)
    {
        return true;
    }
    public async Task<Food> Handle(CookRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Chef Took an order from Waiter");
        if (!IsEnoughIngridients(request.MenuPosition))
            throw new Exception($"Not enough ingridients for menu position {request.MenuPosition}");
        return new Food(request.MenuPosition);
    }
}
