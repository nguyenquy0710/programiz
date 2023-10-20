// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.ComponentModel;
using System.Reflection;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Type staticClassType = typeof(RespCode); // Lấy thông tin về lớp
        FieldInfo[] fields = staticClassType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        
        foreach (FieldInfo field in fields)
        {
            if (field.IsLiteral && !field.IsInitOnly)
            {
                // Kiểm tra nếu trường là hằng số (const) và không phải là read-only
                Console.WriteLine($"ten hang so: {field.Name}, gia tri: {field.GetValue(null)}");
            }
        
            // Kiểm tra xem trường có gắn DescriptionAttribute không
            if (Attribute.IsDefined(field, typeof(DescriptionAttribute)))
            {
                DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                string description = attribute.Description;
        
                Console.WriteLine($"ten truong: {field.Name}, mo ta: {description}");
            }
        }
        
        Console.WriteLine ($"Hello Mono World");
    }
}

public static partial class RespCode
{
    /// <summary>
    /// success
    /// </summary>
    [Description(description: "success")]
    public const int SUCCESS = 100;
    
    /// <summary>
    /// failure
    /// </summary>
    [Description(description: "failure")]
    public const int FAILURE = 99;
}