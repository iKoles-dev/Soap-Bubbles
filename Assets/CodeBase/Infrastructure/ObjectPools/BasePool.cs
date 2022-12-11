using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Infrastructure.ObjectPools
{
    public abstract class BasePool<TObject>
    {
        private readonly Stack<TObject> _pool = new();
        private TObject _prefab;

        public TObject Get()
        {
            if (_pool.Any() == false)
            {
                CreateObjectInstance();
            }
            TObject obj = _pool.Pop();
            Activate(obj);
            return obj;
        }

        public void Return(TObject obj)
        {
            Deactivate(obj);
            _pool.Push(obj);
        }

        protected void Fill(int size, TObject prefab)
        {
            _prefab = prefab;
            for (var i = 0; i < size; i++)
            {
                CreateObjectInstance();
            }
        }

        private void CreateObjectInstance()
        {
            TObject obj = CreateObject(_prefab);
            Deactivate(obj);
            _pool.Push(obj);
        }

        protected abstract TObject CreateObject(TObject prefab);
        protected abstract void Deactivate(TObject obj);
        protected abstract void Activate(TObject obj);
    }
}