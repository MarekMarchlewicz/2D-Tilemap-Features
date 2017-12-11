using UnityEngine;

public class CinemachineExampleWindow : MonoBehaviour
{
    [SerializeField]
    private string m_Title;
    [Multiline]
    [SerializeField]
    private string m_Description;

    private bool mShowingHelpWindow = true;

    private const float kPadding = 40f;

    private void OnGUI()
    {
        if (mShowingHelpWindow)
        {
            Vector2 size = GUI.skin.label.CalcSize(new GUIContent(m_Description));
            Vector2 halfSize = size * 0.5f;

            float maxWidth = Mathf.Min(Screen.width - kPadding, size.x);
            float left = Screen.width * 0.5f - maxWidth * 0.5f;
            float top = Screen.height * 0.4f - halfSize.y;

            Rect windowRect = new Rect(left, top, maxWidth, size.y);
            GUILayout.Window(400, windowRect, (id) => DrawWindow(id, maxWidth), m_Title);
        }
    }

    private void DrawWindow(int id, float maxWidth)
    {
        GUILayout.BeginVertical(GUI.skin.box);
        GUILayout.Label(m_Description);
        GUILayout.EndVertical();
        if (GUILayout.Button("Got it!"))
        {
            mShowingHelpWindow = false;
        }
    }
}
