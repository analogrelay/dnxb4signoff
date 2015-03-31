using System;
using Microsoft.AspNet.Mvc;

namespace DnxSignOff.StarterForCopying.Compiler.Preprocess
{
    public class RazorPreCompilation : RazorPreCompileModule
    {
        public RazorPreCompilation(IServiceProvider provider) : base(provider)
        {
        }
    }
}
