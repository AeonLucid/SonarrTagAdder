﻿using System;

namespace SonarrTagAdder.Sonarr.Data
{
    internal class StatusResponse
    {
        public string Version { get; set; }
        public DateTime BuildTime { get; set; }
        public bool IsDebug { get; set; }
        public bool IsProduction { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsUserInteractive { get; set; }
        public string StartupPath { get; set; }
        public string AppData { get; set; }
        public string OsName { get; set; }
        public string OsVersion { get; set; }
        public bool IsMonoRuntime { get; set; }
        public bool IsMono { get; set; }
        public bool IsLinux { get; set; }
        public bool IsOsx { get; set; }
        public bool IsWindows { get; set; }
        public string Branch { get; set; }
        public string Authentication { get; set; }
        public string SqliteVersion { get; set; }
        public string UrlBase { get; set; }
        public string RuntimeVersion { get; set; }
        public string RuntimeName { get; set; }
    }
}
