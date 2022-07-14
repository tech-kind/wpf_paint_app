using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Prism.Ioc;
using Prism.DryIoc;
using MessagePipe;
using WpfPaintApp.Views;

namespace WpfPaintApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private Container ConvertToDryIocContainer(IEnumerable<ServiceDescriptor> services, Func<IRegistrator, ServiceDescriptor, bool>? registerService = null)
    {
        var rules = CreateContainerRules();
        var container = new Container(rules);

        container.Use<IServiceScopeFactory>(r => new DryIocServiceScopeFactory(r));
        container.Populate(services, registerService);

        return container;
    }

    protected override Rules CreateContainerRules() => Rules.Default.WithAutoConcreteTypeResolution()
        .WithoutThrowOnRegisteringDisposableTransient();

    protected override IContainerExtension CreateContainerExtension()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddMessagePipe();

        var container = ConvertToDryIocContainer(serviceCollection);
        var ext = new DryIocContainerExtension(container);
        return ext;
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }

    protected override Window CreateShell()
        => this.Container.Resolve<MainWindow>();
}
