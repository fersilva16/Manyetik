using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(SceneAttribute))]
public class SceneDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
  {
		if (property.propertyType != SerializedPropertyType.String)
    {
			EditorGUI.LabelField(position, label.text, "Use string type");

			return;
    }

		SceneAsset scene = null;

		if (!string.IsNullOrEmpty(property.stringValue))
    {
			foreach (EditorBuildSettingsScene editorScene in EditorBuildSettings.scenes)
			{
				if (editorScene.path.IndexOf(property.stringValue) != -1)
				{
					scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(editorScene.path);
				}
			}

			if (scene == null) Debug.LogWarning("Scene [" + property.stringValue + "] cannot be used. Add this scene to the 'Scenes in the Build' in build settings.");
		}

		scene = (SceneAsset) EditorGUI.ObjectField(position, label, scene, typeof(SceneAsset), true);

		if (scene != null) property.stringValue = scene.name;
	}
}

#endif
