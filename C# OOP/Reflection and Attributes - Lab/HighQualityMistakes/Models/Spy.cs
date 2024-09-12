using System.Reflection;
using System.Text;
namespace Stealer;

public class Spy
{
    public string AnalyzeAccessModifiers(string className)
    {
        StringBuilder sb = new();
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields((BindingFlags)28);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }

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
