using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessageBird;
using MessageBird.Exceptions;
using MessageBird.Objects;

/// <summary>
/// Summary description for ErrorGenerator
/// </summary>
public static class ErrorGenerator
{
    public static String Generate(ErrorException errorException) 
    {
        string result = "";
        // Either the request fails with error descriptions from the endpoint.
        if (errorException.HasErrors)
        {
            foreach (Error error in errorException.Errors)
            {
                result += error.Description + "\n";
            }
        }
        // or fails without error information from the endpoint, in which case the reason contains a 'best effort' description.
        if (errorException.HasReason)
            result += errorException.Reason;
        return result;
    }
}