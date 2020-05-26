using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        return (TService)s_Services[typeof(TService)];
    }
}
