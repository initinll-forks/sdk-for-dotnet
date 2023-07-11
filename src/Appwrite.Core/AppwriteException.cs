﻿namespace Appwrite.Core;

public class AppwriteException : Exception
{
    public int? Code { get; set; }
    public string? Response { get; set; } = null;

    public AppwriteException(string? message = null, int? code = null, string? response = null) : base(message)
    {
        this.Code = code;
        this.Response = response;
    }
    public AppwriteException(string message, Exception inner) : base(message, inner)
    {
    }
}
