using UnityEngine;

[System.AttributeUsage(System.AttributeTargets.Field)]
public class InspectorButtonAttribute : PropertyAttribute
{
    /// <summary>
    /// The name of the method we call if the button is pressed.
    /// </summary>
    public string MethodName { get; set; }

    /// <summary>
    /// The parameters to give at the method called.
    /// </summary>
    public object[] Parameters { get; set; }

    /// <summary>
    /// Customize the text of the button.
    /// </summary>
    public string ButtonName { get; set; } = "Execute";

    public InspectorButtonAttribute(string methodName) => MethodName = methodName;
}
