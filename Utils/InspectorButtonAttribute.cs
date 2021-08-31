using UnityEngine;

/// <summary>
/// This attribute can only be applied to fields because its
/// associated PropertyDrawer only operates on fields (either
/// public or tagged with the [SerializeField] attribute) in
/// the target MonoBehaviour.
/// SOURCE: https://www.reddit.com/r/Unity3D/comments/1s6czv/inspectorbutton_add_a_custom_button_to_your/
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Field)]
public class InspectorButtonAttribute : PropertyAttribute
{
    public static float kDefaultButtonWidth = 80;

    /// <summary>
    /// The name of the method we call if the button is pressed.
    /// </summary>
    public readonly string MethodName;

    /// <summary>
    /// Customize the width of the button.
    /// </summary>
    public float ButtonWidth { get; set; } = kDefaultButtonWidth;

    /// <summary>
    /// Customize the text of the button.
    /// </summary>
    public string ButtonName { get; set; } = "Execute";

    public InspectorButtonAttribute(string methodName) => MethodName = methodName;
}
