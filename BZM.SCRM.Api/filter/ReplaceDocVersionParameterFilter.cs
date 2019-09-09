using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BZM.SCRM.Api.filter
{
    /// <summary>
    /// 替换swagger文档版本参数
    /// </summary>
    public class ReplaceDocVersionParameterFilter: IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Paths = swaggerDoc.Paths
                .ToDictionary(path => path.Key.Replace("v{version}", swaggerDoc.Info.Version), path => path.Value);
        }
    }
}
