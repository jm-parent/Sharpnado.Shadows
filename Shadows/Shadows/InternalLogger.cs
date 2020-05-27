﻿using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Sharpnado.Shadows.Android")]
[assembly:InternalsVisibleTo("Sharpnado.Shadows.iOS")]
[assembly:InternalsVisibleTo("Sharpnado.Shadows.UWP")]
[assembly:InternalsVisibleTo("Sharpnado.Presentation.Forms")]

namespace Sharpnado.Shades
{
    internal static class InternalLogger
    {
        public static bool EnableLogging { get; set; } = false;

        public static bool EnableDebug { get; set; } = false;

        public static void Debug(string tag, string format, params object[] parameters)
        {
            if (!EnableDebug)
            {
                return;
            }

            DiagnosticLog(tag + " | DBUG | " + format, parameters);
        }

        public static void Debug(string format, params object[] parameters)
        {
            if (!EnableDebug)
            {
                return;
            }

            DiagnosticLog("DBUG | " + format, parameters);
        }

        public static void Info(string tag, string format, params object[] parameters)
        {
            DiagnosticLog(tag + " | INFO | " + format, parameters);
        }

        public static void Info(string format, params object[] parameters)
        {
            DiagnosticLog("INFO | " + format, parameters);
        }

        public static void Warn(string format, params object[] parameters)
        {
            DiagnosticLog("WARN | " + format, parameters);
        }

        public static void Error(string format, params object[] parameters)
        {
            DiagnosticLog("ERRO | " + format, parameters);
        }

        public static void Error(Exception exception)
        {
            Error($"{exception.Message}{Environment.NewLine}{exception}");
        }

        private static void DiagnosticLog(string format, params object[] parameters)
        {
            if (!EnableLogging)
            {
                return;
            }

#if DEBUG
            if (parameters.Length == 0)
            {
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("MM-dd H:mm:ss.fff") + " | SharpnadoInternals | " + format);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(
                    DateTime.Now.ToString("MM-dd H:mm:ss.fff") + " | SharpnadoInternals | " + format,
                    parameters);
            }
#else
            Console.WriteLine(DateTime.Now.ToString("MM-dd H:mm:ss.fff") + " | SharpnadoInternals | " + format, parameters);
#endif
        }
    }
}