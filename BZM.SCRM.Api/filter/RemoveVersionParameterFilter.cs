using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;

namespace BZM.SCRM.Api.filter
{
    /// <summary>
    /// 移除swagger版本
    /// </summary>
    public class RemoveVersionParameterFilter: IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var versionParam = operation.Parameters.Single(c => c.Name == "version");
            operation.Parameters.Remove(versionParam);
        }
    }
}
