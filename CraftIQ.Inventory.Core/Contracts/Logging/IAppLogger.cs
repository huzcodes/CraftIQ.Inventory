﻿namespace CraftIQ.Inventory.Core.Contracts.Logging;

public interface IAppLogger<T>
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);
}

