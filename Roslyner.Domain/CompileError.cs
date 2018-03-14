using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using B6.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Roslyner.Domain.ClassForInject;

namespace Roslyner.Domain
{
    public class CompileError
    {
        public CompileError(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}