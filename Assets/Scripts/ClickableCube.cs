using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClickableCube : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();
    [SerializeField] private float scaleDownTimer = .4f;
    [SerializeField] private float scaleFactor = 1.2f;

    private Vector3 originalScale;
    private GameObject cube;

    private void Start()
    {
        originalScale = transform.localScale;
        cube = this.gameObject;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                unityEvent.Invoke();
                StartCoroutine(ScaleFeedback());
            }
        }
    }

    private IEnumerator ScaleFeedback()
    {
        Vector3 orig = originalScale;
        Vector3 big = originalScale * scaleFactor;
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime * 8;
            transform.localScale = Vector3.Lerp(orig, big, t);
            yield return null;
        }

        t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime * 8;
            transform.localScale = Vector3.Lerp(big, orig, t);
            yield return null;
        }

        transform.localScale = orig;
    }

}
