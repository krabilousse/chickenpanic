
using System.Collections.Generic;

namespace ChickenPanic.Utilities
{
    public class ObjectPool<T>
    {
        public delegate T CreateObjectMethod(params object[] args);
        public delegate void RecycleObjectMethod(T recycledObject, params object[] args);

        private CreateObjectMethod createObjectMethod;
        private RecycleObjectMethod recycleObjectMethod;

        private Stack<T> freedObjects;

        private int capacity;

        public ObjectPool(CreateObjectMethod createObjectMethod, RecycleObjectMethod recycleObjectMethod, int capacity)
        {
            this.createObjectMethod = createObjectMethod;
            this.recycleObjectMethod = recycleObjectMethod;

            this.capacity = capacity;
            this.freedObjects = new Stack<T>(capacity);
        }

        public T SeekObject(params object[] args)
        {
            /* "default" returns null if T is a Ref Type or 0 if T is a Value Type. */
            T soughtObject = default(T);

            if (freedObjects.Count == 0)
            {
                soughtObject = createObjectMethod(args);
            }
            else
            {
                soughtObject = freedObjects.Pop();
                recycleObjectMethod(soughtObject, args);
            }

            return soughtObject;
        }

        public void FreeObject(T freedObject)
        {
            if (freedObjects.Count < capacity)
            {
                freedObjects.Push(freedObject);
            }
        }
    }
}
