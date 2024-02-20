using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Rigidbody2D playerRB;

    void Start()
    { 
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
        playerRB.velocity = Vector3.zero;
        playerRB.AddForce(Vector3.right * dragVectorDirection.x, ForceMode2D.Impulse);
              
       
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
}
