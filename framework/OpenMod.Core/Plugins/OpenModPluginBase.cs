﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenMod.API;
using OpenMod.API.Plugins;
using Semver;

namespace OpenMod.Core.Plugins
{
    public abstract class OpenModPluginBase : IOpenModPlugin, IAsyncDisposable
    {
        public string OpenModComponentId { get; }
        public string WorkingDirectory { get; }
        public bool IsComponentAlive { get; protected set; }
        public string DisplayName { get; }
        public string Author { get; }
        public SemVersion Version { get; }
        public IRuntime Runtime { get; }

        public ILifetimeScope LifetimeScope { get; }

        protected OpenModPluginBase(IServiceProvider serviceProvider)
        {
            LifetimeScope = serviceProvider.GetRequiredService<ILifetimeScope>();
            Configuration = serviceProvider.GetRequiredService<IConfiguration>();

            Runtime = serviceProvider.GetRequiredService<IRuntime>();

            var metadata = GetType().Assembly.GetCustomAttribute<PluginMetadataAttribute>();
            OpenModComponentId = metadata.Id;
            Version = metadata.Version;
            DisplayName = metadata.DisplayName;
            Author = metadata.Author;
            WorkingDirectory = PluginHelper.GetWorkingDirectory(Runtime, metadata.Id);
        }

        public IConfiguration Configuration { get; set; }

        public abstract Task LoadAsync();

        public abstract Task UnloadAsync();

        public async ValueTask DisposeAsync()
        {
            if (!await OnDispose())
            {
                await UnloadAsync();
            }

            LifetimeScope?.Dispose();
        }

        protected virtual ValueTask<bool> OnDispose()
        {
            return new ValueTask<bool>(false);
        }
    }
}