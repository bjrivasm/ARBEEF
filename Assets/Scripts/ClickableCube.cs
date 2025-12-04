using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClickableCube : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();
    private GameObject cube;

    private void Start()
    {
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
            }
        }
    }
}
