﻿using Core.CrossCuttingConcerns.Cacheing;
using Core.CrossCuttingConcerns.Cacheing.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection collection)
        {
            collection.AddMemoryCache();
            collection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            collection.AddSingleton<ICacheManager, MemoryCacheManager>();
            collection.AddSingleton<Stopwatch>();
        }
    }
}
