﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Runtime.Serialization;

namespace TodoListSPA.Helpers;

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema model, SchemaFilterContext context)
    {
        if (context.Type.IsEnum)
        {
            model.Enum.Clear();

            foreach (string enumName in Enum.GetNames(context.Type))
            {
                MemberInfo? memberInfo = context.Type.GetMember(enumName)
                    .FirstOrDefault(m => m.DeclaringType == context.Type);
                EnumMemberAttribute? enumMemberAttribute = memberInfo?.GetCustomAttributes(typeof(EnumMemberAttribute), false)
                        .OfType<EnumMemberAttribute>().FirstOrDefault();

                string label = enumMemberAttribute == null ||
                    string.IsNullOrWhiteSpace(enumMemberAttribute.Value)
                    ? enumName
                    : enumMemberAttribute.Value;

                model.Enum.Add(new OpenApiString(label));
            }
        }
    }
}
