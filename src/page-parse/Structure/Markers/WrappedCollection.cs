﻿using System.Collections;
using System.Collections.Generic;
using CSGOStats.Extensions.Extensions;

namespace CSGOStats.Infrastructure.PageParse.Structure.Markers
{
    public abstract class WrappedCollection
    {
        public abstract void Add(object instance);
    }

    public class WrappedCollection<T> : WrappedCollection, IEnumerable<T>
    {
        private readonly List<T> _innerCollection = new List<T>();

        public override void Add(object instance) => _innerCollection.Add(instance.OfType<T>());

        public IEnumerator<T> GetEnumerator() => _innerCollection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}