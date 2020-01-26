using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StandardTextTag : TextTag
{
    static Vector2 originOffset = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
    public float duration = 1f;
    public float upDistance = 1f;

    public float targetAlpha = 1f;

    private RectTransform rectTransform;
    private Vector2 startPos;
    public override void StartAnimation(GameObject target, Vector2 offset, string content, Camera camera)
    {
        base.StartAnimation(target, offset, content, camera);
        TextMeshProUGUI textMesh = GetComponentInChildren<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();

        startPos = camera.WorldToScreenPoint(target.transform.position) + new Vector3(offset.x, offset.y);
        startPos = startPos - originOffset;

        rectTransform.anchoredPosition = startPos;
        textMesh.text = content;
        textMesh.CrossFadeColor(
            new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, targetAlpha),
            duration,
            false,
            true);
        StartCoroutine(animating());
    }

    IEnumerator animating()
    {
        float timer = 0f;
        Vector2 endPos = startPos + Vector2.up * upDistance;
        while (timer < duration)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, timer / duration);
        }
        rectTransform.anchoredPosition = endPos;
        factory.Reclaim(this);
    }

}
