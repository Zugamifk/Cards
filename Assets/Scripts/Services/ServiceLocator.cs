using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ServiceLocator
{
    static Dictionary<System.Type, IService> s_Services = new Dictionary<System.Type, IService>();

    public static void Register(IService service)
    {
        var type = service.GetType();
        if(s_Services.ContainsKey(type))
        {
            throw new System.InvalidOperationException($"Already registered a service of type \'{type}\'!");
        }

        s_Services[type] = service;
    }

    public static TService Get<TService>() where TService : IService
    {
        IService result = null;
        if(!s_Services.TryGetValue(typeof(TService), out result))
        {
            if(typeof(IConstructableService).IsAssignableFrom(typeof(TService)))
            {
                result = Activator.CreateInstance<TService>();
                s_Services[typeof(TService)] = result;
            }
        }

        return (TService)result;
    }
}
