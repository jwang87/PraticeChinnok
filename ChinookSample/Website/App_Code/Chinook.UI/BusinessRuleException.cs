using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BussinessRuleException
/// the contents that will be placed in an instance
/// of this class will come from user code within
/// your app source (ie. BLL business rule exceptio)
/// </summary>
[Serializable]
public class BusinessRuleException : Exception
{
    public List<string> RuleDetails { get; set; }
    public BusinessRuleException(string message, List<string> reasons)
        : base(message)
    {
        this.RuleDetails = reasons;
    }
}