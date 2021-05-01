
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ConstellationOverlayText : MonoBehaviour
{
    public Text text;
    public ConstellationData constellationData;

    private float scaleSize;

    private void Start()
    {
        scaleSize = GameManager.Instance.scaleSize;
    }

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
        Vector3 viewPortPos = Camera.allCameras[1].WorldToViewportPoint(constellationData.position);
        Vector2 screenPos = viewPortPos * canvasSize;
        text.rectTransform.anchoredPosition = screenPos;
        text.gameObject.SetActive(viewPortPos.z > 0);
    }
}