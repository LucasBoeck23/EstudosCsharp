﻿namespace ApiCatalogo.Loggin;

public class CustomLoggerProviderConfiguration
{
    public LogLevel Loglevel { get; set; } = LogLevel.Warning;
    public int EventId { get; set; } = 0;
}
