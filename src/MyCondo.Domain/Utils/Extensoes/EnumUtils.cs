using System.ComponentModel;
using System.Reflection;

namespace MyCondo.Domain.Utils.Extensoes;

public static class EnumUtils
{
    public static string ObterDescriaoEnum(this Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] array = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);

        if (array.Length > 0)
            return value.ToString();

        return array[0].Description;
    }

}
