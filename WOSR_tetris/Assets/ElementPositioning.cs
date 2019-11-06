using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementPositioning : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform rectTransform;
    public List<SpriteRenderer> sprites;
    private bool isInUI = true;

    private Vector3 screenPoint;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isInUI)
        {
            PuzzleManager.Instance.powerGauge.CurrentValue -= GetComponent<ElementValue>().Power;
            PuzzleManager.Instance.handlingGauge.CurrentValue -= GetComponent<ElementValue>().Handling;
            PuzzleManager.Instance.brakeGauge.CurrentValue -= GetComponent<ElementValue>().Brake;
        }

        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector2 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);

        PolygonCollider2D collider = GetComponent<PolygonCollider2D>();

        bool canBePlaced = true;
        List<Collider2D> gridColliders = new List<Collider2D> ();
        Vector3 translateBy = Vector3.zero;
        foreach (SpriteRenderer renderer in sprites)
        {
            Physics2D.OverlapCollider(renderer.GetComponent<BoxCollider2D>(), new ContactFilter2D().NoFilter(), gridColliders);
            for (int i = gridColliders.Count - 1; i >= 0; --i)
            {
                if (!gridColliders[i].GetComponent<SpriteRenderer>().enabled || gridColliders[i].gameObject.CompareTag("Part"))
                    gridColliders.RemoveAt(i);
            }

            if (gridColliders.Count != 1)
            {
                canBePlaced = false;
                break;
            }
            if (gridColliders.Count != 0)
                translateBy = gridColliders[0].transform.position - renderer.transform.position;
        }

        if (canBePlaced)
        {
            PuzzleManager.Instance.powerGauge.CurrentValue += GetComponent<ElementValue>().Power;
            PuzzleManager.Instance.handlingGauge.CurrentValue += GetComponent<ElementValue>().Handling;
            PuzzleManager.Instance.brakeGauge.CurrentValue += GetComponent<ElementValue>().Brake;

            isInUI = false;
            transform.Translate(translateBy);
        }
        else
        {
            isInUI = true;
            transform.position = transform.parent.position;
        }
    }

    public void ResetPosition()
    {
        rectTransform.anchoredPosition = Vector3.zero;
    }

}
