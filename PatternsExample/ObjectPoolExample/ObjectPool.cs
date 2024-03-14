using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExample.ObjectPoolExample;
public class ObjectPool<T>
{
    private readonly Func<T> _creationFactory;
    private readonly List<T> _objects = [];

    public ObjectPool(Func<T> creationFactory)
    {
        _creationFactory = creationFactory;
    }

    public T GetObject()
    {

        if (_objects.Count > 0)
        {
            lock (_objects)
            {
                var obj = _objects[0];
                _objects.RemoveAt(0);
                return obj;
            }
        }
        return _creationFactory();
    }
    public void ReleaseObject(T obj)
    {
        if (obj == null)
            throw new NullReferenceException(nameof(obj));
        lock (_objects)
        {
            _objects.Add(obj);
        }
    }
}
