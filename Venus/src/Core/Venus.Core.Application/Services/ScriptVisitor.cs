using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Scriban.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Services.Models;

namespace Venus.Core.Application.Services
{
    public class CustomScriptVisitor : ScriptVisitor
    {
        public List<ScriptVisitModel> Variables => variables;
        private List<ScriptVisitModel> variables = new List<ScriptVisitModel>();

        private void AddVariable(ScriptVisitModel item)
        {
            var variable = variables.FirstOrDefault(x => x.PropertyRoute == item.PropertyRoute);
            if (variable == null)
            {
                variables.Add(item);
            }else if((variable.Type == null && variable.Label == null) && (item.Label != null && item.Type != null))
            {
                variable = item;
            }
            
        }
        public override void Visit(ScriptNode node)
        {
            try
            {
                // Member access (person.name, a.b.c)
                if (node is ScriptMemberExpression member)
                {
                    var path = BuildPath(member);
                    
                    ScriptVisitModel item = new ScriptVisitModel()
                    {
                        PropertyRoute = path
                    };
                    AddVariable(item);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            base.Visit(node);
        }

        private string BuildPath(ScriptExpression expr)
        {
            try
            {
                var parts = new Stack<string>();

                while (expr is ScriptMemberExpression member)
                {
                    parts.Push(member.Member.Name);
                    expr = member.Target;
                }

                if (expr is ScriptVariableGlobal global)
                {
                    parts.Push(global.Name);
                }

                return string.Join(".", parts);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public override void Visit(ScriptFunctionCall node)
        {
            if (node.Target.ToString() == "field")
            {
                ScriptVisitModel item = new ScriptVisitModel();
                foreach (var argument in node.Arguments)
                {
                    if (argument is ScriptNamedArgument namedArg)
                    {
                        string key = namedArg.Name?.ToString();
                        string value =  namedArg.Value?.ToString().Replace("\"","").Replace("\\","").Replace("/","").Replace("'","");

                        if (key.Trim().ToLower() == "type")
                        {
                            item.Type = value.ToString();
                        }else if (key.Trim().ToLower() == "name")
                        {
                            item.PropertyRoute = value.ToString();
                        }else if (key.Trim().ToLower() == "label")
                        {
                            item.Label = value.ToString();
                        }
                    }
                }
                AddVariable(item);
            }
        }
    }
}
