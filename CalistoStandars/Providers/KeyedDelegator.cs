﻿using System;

using CalistoStandards.Definitions.Enumerations;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace CalistoStandards.Providers;

public interface IKeyedDelegation
{
    void SetupDelegations();
}

public sealed class KeyedDelegators : KeyedCollection<int, Delegate>
{
    private readonly Dictionary<string, int> _mappedHashMethods;

    public KeyedDelegators(int capacity)
    {
        _mappedHashMethods = new Dictionary<string, int>(capacity);
    }

    public void Add(Delegate item, bool addToHashMap = true)
    {
        base.Add(item);

        if (addToHashMap)
            _mappedHashMethods.Add(item.Method.Name,
                item.Method.GetHashCode());
    }

    public Delegate GetByName(string methodName)
    {
        if (!_mappedHashMethods.ContainsKey(methodName)) return null!;

        if (TryGetValue(_mappedHashMethods[methodName], out Delegate? deleg))
            return deleg;

        return null!;
    }

    public bool TryRemoveByName(string methodName)
    {
        bool removed = Remove(_mappedHashMethods[methodName]);

        if (!removed) return removed;

        _mappedHashMethods.Remove(methodName);
        _mappedHashMethods.TrimExcess();

        return removed;
    }

    public void CleanMappedHashMethods(int? ensureCapacity = null)
    {
        _mappedHashMethods.Clear();

        if (ensureCapacity is { } ensuredCapacity)
            _mappedHashMethods.EnsureCapacity(ensuredCapacity);
    }

    public IEnumerable<string> EnumerateDelegatesNames() =>
        from del in Items select del.Method.Name;

    protected override int GetKeyForItem(Delegate item) => item.Method.GetHashCode();

}

public sealed class KeyedDelegator
{
    private const int KeyedDelegatorsCapacity = 25;

    #region ThreadSafe Singleton Pattern

    private static KeyedDelegator _instance;
    private static readonly object _padlock = new();

    private KeyedDelegator()
    {
        _delegates = new KeyedDelegators(KeyedDelegatorsCapacity);
    }

    public static KeyedDelegator Instance
    {
        get
        {
            lock (_padlock)
            {
                if (_instance is null)
                    _instance = new KeyedDelegator();

                return _instance;
            }
        }
    }

    #endregion

    private bool _disposed;

    private readonly KeyedDelegators _delegates;

    public bool SetupDelegate(Delegate deleg, bool addMethodHash = true)
    {
        if (_delegates.Contains(deleg)) return false;
        _delegates.Add(deleg, addMethodHash);
        return true;
    }
    public bool SetupDelegates(bool addMethodsHashs = true, params Delegate[] delegs)
    {
        int hit = delegs.Count(deleg => SetupDelegate(deleg, addMethodsHashs));
        return hit == delegs.Length;
    }
    

    public bool RemoveDelegate(Delegate deleg) => _delegates.Contains(deleg) && _delegates.TryRemoveByName(deleg.Method.Name);
    public bool RemoveDelegate(string methodName) => _delegates.TryRemoveByName(methodName);
    

    public void Execute(Delegate deleg)
    {
        _delegates.TryGetValue(deleg.Method.GetHashCode(), out deleg);
        deleg?.DynamicInvoke();
    }
    public void Execute(Delegate deleg, params object[] invokeParams)
    {
        _delegates.TryGetValue(deleg.Method.GetHashCode(), out deleg);
        deleg?.DynamicInvoke(invokeParams);
    }
    public void Execute(string methodName)
    {
        Delegate deleg = _delegates.GetByName(methodName);
        if (deleg is null) return;
        deleg.DynamicInvoke();

    }
    public void Execute(string methodName, params object[] invokeParams)
    {
        Delegate deleg = _delegates.GetByName(methodName);
        if (deleg is null) return;
        deleg.DynamicInvoke(invokeParams);

    }
    

    public object ExecuteValue(Delegate deleg)
    {
        _delegates.TryGetValue(deleg.Method.GetHashCode(), out deleg);
        return deleg?.DynamicInvoke()!;
    }
    public object ExecuteValue(Delegate deleg, params object[] invokeParams)
    {
        _delegates.TryGetValue(deleg.Method.GetHashCode(), out deleg);
        return deleg?.DynamicInvoke(invokeParams)!;
    }
    public object ExecuteValue(string methodName)
    {
        Delegate deleg = _delegates.GetByName(methodName);
        return deleg is null ? null! : deleg.DynamicInvoke()!;
    }
    public object ExecuteValue(string methodName, params object[] invokeParams)
    {
        Delegate deleg = _delegates.GetByName(methodName);
        return deleg is null ? null! : deleg.DynamicInvoke(invokeParams)!;
    }
    

    public TValue Execute<TValue>(Delegate deleg) => (TValue)ExecuteValue(deleg);
    public TValue Execute<TValue>(Delegate deleg, params object[] invokeParams) => (TValue)ExecuteValue(deleg, invokeParams);
    public TValue Execute<TValue>(string methodName) => (TValue)ExecuteValue(methodName);
    public TValue Execute<TValue>(string methodName, params object[] invokeParams) => (TValue)ExecuteValue(methodName, invokeParams);


}