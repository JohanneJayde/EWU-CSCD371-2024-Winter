﻿using System;
using System.Globalization;

namespace Logger.Tests;

    public class ConsoleLogger : BaseLogger
    {
        public ConsoleLogger()
        {
        }

    public override void Log(LogLevel level, string message)
    {
        Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} {ClassName} {level}: {message}");
    }
}