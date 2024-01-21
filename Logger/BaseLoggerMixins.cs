﻿using System;
using System.Linq;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(BaseLogger? logger, string message,params string [] arguments)
    {
        if(logger == null)
            throw new ArgumentNullException();

        if(arguments == null)
        {
            logger.Log(LogLevel.Error, message);

        }
        else
        {
            string argumentsAsString = string.Join(" ", arguments);
            string combinedMessage = message + " " + argumentsAsString;
            logger.Log(LogLevel.Error, combinedMessage);

        }


    }
}
