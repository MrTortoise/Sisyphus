using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
  public static  class ScenarioContextExtensions
    {
      public static void AddUpdate(this ScenarioContext context, string key, object value)
      {
          if (context.ContainsKey(key))
          {
              context[key] = value;
          }
          else
          {
              context.Add(key, value);
          }
      }
    }
}
