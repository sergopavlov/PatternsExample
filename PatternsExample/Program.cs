// See https://aka.ms/new-console-template for more information
using PatternsExample;
using PatternsExample.MediatorExample;
using PatternsExample.ObjectPoolExample;

IMediator mediator = new Mediator();
new Waiter(mediator);
new Chef(mediator);
var visitor = new Visitor(mediator);
var dinner = await visitor.GiveOrder(["Булочка с сосискою", "чай бутерброд", "иии и пряники то чаю", "и все!"]);
/*
Visitor gave an order to waiter
Waiter took an order from visitor
Chef Took an order from Waiter
Chef Took an order from Waiter
Chef Took an order from Waiter
Chef Took an order from Waiter
Waiter took dishes from chef
Visitor took a dinner from waiter
 */
int counter = 1;

Func<string> factory = () => $"string number {counter++}";
var pool = new ObjectPool<string>(factory);
var obj1 = pool.GetObject();
Console.WriteLine(obj1);
var obj2 = pool.GetObject();
Console.WriteLine(obj2);
var obj3 = pool.GetObject();
Console.WriteLine(obj3);
pool.ReleaseObject(obj2);
var obj4 = pool.GetObject();
Console.WriteLine(obj4);
Console.WriteLine(ReferenceEquals(obj2, obj4));
/*
string number 1
string number 2
string number 3
string number 2
True
 */



