﻿namespace CalistoStandards.Definitions.Exceptions;

public abstract class EducativaBuilderException : Exception
{
    protected EducativaBuilderException(string message) : base(message)
    {
    }
}