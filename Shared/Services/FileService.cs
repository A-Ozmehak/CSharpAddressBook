﻿using Newtonsoft.Json;
using Shared.Interfaces;
using Shared.Models;
using System.Diagnostics;

namespace Shared.Services;

internal class FileService : IFileService
{

    public string GetContactsFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;

    }

    public bool SaveContactToFile(string filePath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}