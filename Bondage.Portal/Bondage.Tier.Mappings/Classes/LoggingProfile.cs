﻿using System;
using System.Collections.Generic;

using Bondage.Tier.Constants.Enums;

using Microsoft.Extensions.Logging;

namespace Bondage.Tier.Mappings.Classes
{
    /// <summary>
    /// Represents a <see cref="LoggingProfile"/> class
    /// </summary>
    public static class LoggingProfile
    {
        /// <summary>
        /// Instance of <see cref="Dictionary{Enum, LogLevel}"/>
        /// </summary>
        public static readonly Dictionary<Enum, LogLevel> LogLevelMapings = new Dictionary<Enum, LogLevel>
    {
    { ApplicationEvents.InsertItem, LogLevel.Information },
    { ApplicationEvents.UpdateItem, LogLevel.Information },
    { ApplicationEvents.DeleteItem, LogLevel.Information },
    { ApplicationEvents.UserAuthenticated, LogLevel.Information },
    { ApplicationEvents.GetItemNotFound, LogLevel.Error },
    { ApplicationEvents.GetItemFound, LogLevel.Error },
    { ApplicationEvents.UserNotAuthenticated, LogLevel.Error },
    };
    }
}