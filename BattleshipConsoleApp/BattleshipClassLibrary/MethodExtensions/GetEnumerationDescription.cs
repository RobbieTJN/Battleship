using System;

namespace BattleshipClassLibrary.Methods
{
    public static class GetEnumerationDescription
    {
        public static T GetDescription<T>(this Enum enumerationValue) where T : Attribute
        {
            var type = enumerationValue.GetType();
            var memberInfo = type.GetMember(enumerationValue.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }
    }
}
