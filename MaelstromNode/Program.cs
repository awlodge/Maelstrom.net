﻿// See https://aka.ms/new-console-template for more information
using MaelstromNode.Interfaces;
using MaelstromNode.Workloads;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MaelstromNode;

class Program
{
    static async Task Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        //builder.Logging.AddConsole();
        builder.Services.AddHostedService<EchoServer>();
        builder.Services.AddSingleton<IReceiver, StdinReceiver>();
        builder.Services.AddSingleton<ISender, StdoutSender>();

        using IHost host = builder.Build();
        await host.RunAsync();
    }
}
