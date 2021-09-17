using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(LayerAttribute))]
public class LayerDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		if (property.propertyType != SerializedPropertyType.Integer)
		{
			EditorGUI.LabelField(position, label.text, "Use integer type");

			return;
		}

		property.intValue = EditorGUI.LayerField(position, label, property.intValue);
	}
}

#endif
