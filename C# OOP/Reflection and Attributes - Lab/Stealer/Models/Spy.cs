using System.Reflection;
using System.Text;
namespace Stealer;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] investigatedFields)
    {
        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields = classType.GetFields((BindingFlags)60);
        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        StringBuilder sb = new();
        sb.AppendLine($"Class under investigation: {investigatedClass}");
        foreach (FieldInfo field in classFields.Where(f => investigatedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().TrimEnd();
    }
}
