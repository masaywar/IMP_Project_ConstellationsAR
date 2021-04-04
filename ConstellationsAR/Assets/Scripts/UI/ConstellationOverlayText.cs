
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ConstellationOverlayText : MonoBehaviour
{
    public Text text;
    public ConstellationData constellationData;

    public void SetConstellation(ConstellationData _info)
    {
        constellationData = _info;
        text.text = constellationData.name;
    }

    private void Update()
    {
        if (constellationData != null)
            UpdateTextPosition();
    }

    void UpdateTextPosition()
    {
        var canvasSize = text.canvas.GetComponent<RectTransform>().sizeDelta;
        Vector3 viewPortPos = Camera.allCameras[0].WorldToViewportPoint(constellationData.position);
        Vector2 screenPos = viewPortPos * canvasSize;
        text.rectTransform.anchoredPosition = screenPos;
        text.gameObject.SetActive(viewPortPos.z > 0);
    }
}