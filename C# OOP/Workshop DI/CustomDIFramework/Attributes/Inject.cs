using System;

namespace CustomDIFramework.Attributes
{

    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class Inject : Attribute
    {
    }
}