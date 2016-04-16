using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(StringLibrary.StringPair))]
public class PropertyDrawer_StringPair : PropertyDrawer
{
	float h = EditorGUIUtility.singleLineHeight;

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return property.isExpanded? h * 5: h;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);

		property.isExpanded = EditorGUI.Foldout(new Rect(position.x, position.y, position.width, h), property.isExpanded, label);
		if (property.isExpanded) {
			SerializedProperty key = property.FindPropertyRelative("key");
			SerializedProperty value = property.FindPropertyRelative("value");

			EditorGUI.indentLevel++;
			Rect keyRect = EditorGUI.PrefixLabel(new Rect(position.x, position.y + h, position.width, h), new GUIContent("Key"));
			EditorGUI.PropertyField(keyRect, key, GUIContent.none);

			Rect valueRect = new Rect(position.x, position.y + h * 2, position.width, h * 3);
			value.stringValue = EditorGUI.TextArea(valueRect, value.stringValue, EditorStyles.textArea);
			EditorGUI.indentLevel--;
		}

		EditorGUI.EndProperty();
	}
}
