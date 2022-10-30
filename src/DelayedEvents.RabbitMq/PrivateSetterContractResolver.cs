// using System.Reflection;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Serialization;
//
// namespace DelayedEvents.RabbitMq;
//
// /// <summary>
// /// The private setter contract resolver.
// /// </summary>
// public class PrivateSetterContractResolver : DefaultContractResolver
// {
//     protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
//     {
//         var jsonProperty = base.CreateProperty(member, memberSerialization);
//         if (!jsonProperty.Writable)
//         {
//             if (member is PropertyInfo propertyInfo)
//             {
//                 jsonProperty.Writable = propertyInfo.GetSetMethod(true) != null;
//             }
//         }
//
//         return jsonProperty;
//     }
// }
