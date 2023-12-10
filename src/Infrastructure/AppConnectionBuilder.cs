﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;

namespace Microsoft.eShopWeb.Infrastructure;

public class AppConnectionBuilder : IAppConnectionBuilder
{
    private readonly IConfiguration _configuration;
    public ConnectionProfile Profile { get; private set; }
    // shows the use of the options binding to get configuration options from appsettings. 
    // enables us to override the user and password from dotnet user-secrets in dev mode.
    // TO Do: inject in a ILogger perhaps, for console and error catch
    public AppConnectionBuilder(IConfiguration configuration, string connectionName)
    {
        (_configuration) = (configuration);

        string connectionString = configuration.GetConnectionString(connectionName)?? "";

        ConnectionOptions options = new ConnectionOptions();
        var section = _configuration.GetSection(ConnectionOptions.Connection);
        _configuration.GetSection(ConnectionOptions.Connection).Bind(options);
        int commandTimeout = options.CommandTimeout; 
        SqlConnectionStringBuilder builder = new(connectionString);
        // Override
        var overrideUser = _configuration["sql_user"];
        var overridePassword = _configuration["sql_password"];
        if (!string.IsNullOrWhiteSpace(overrideUser)) { builder.UserID = overrideUser; }
        if (!string.IsNullOrWhiteSpace(overridePassword)) { builder.Password = overridePassword; }
        this.Profile = new ConnectionProfile(builder.ConnectionString, commandTimeout);

        var serviceName = nameof(AppConnectionBuilder);
        // we are not connected to an ILogger at this stage of the app startup. 
        Console.WriteLine($"{serviceName} has configured connection string for {connectionName}", serviceName, connectionName);
    }
}
