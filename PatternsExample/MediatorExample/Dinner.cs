using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExample.MediatorExample;
public class Dinner
{
    public Dinner(IEnumerable<Food> dishes)
    {
        Dishes = dishes;
    }

    public IEnumerable<Food> Dishes { get; }
}
