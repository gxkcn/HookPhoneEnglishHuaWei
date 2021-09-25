using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public enum E_JoystickType
{
    Normal,
    CanChangePos,
    CanMove,
}
public class JoystickPanel : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public E_JoystickType type = E_JoystickType.CanMove;

    public float maxL = 70;

    public Image imgTouchRect;

    public Image imgBk, imgControl;

    private float angle;

    public JoystickEvent OnValueChanged = new JoystickEvent(); //事件 ： 摇杆被 拖拽时

    // Use this for initialization
    void Start () {
	
        if( type != E_JoystickType.Normal)
        {
            imgBk.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        float _d = Tools.GetTwointDistance2D(imgControl.transform.localPosition, Vector3.zero);
        if (_d <= 0|| _d > 70)
        {
            _d = 70;
        }
        OnValueChanged.Invoke(imgControl.transform.localPosition /_d);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        imgBk.gameObject.SetActive(true);

        if (type != E_JoystickType.Normal)
        {
            Vector2 localPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                imgTouchRect.rectTransform,
                eventData.position, eventData.pressEventCamera, out localPos);

            imgBk.transform.localPosition = localPos;
        }
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        imgControl.transform.localPosition = Vector3.zero;

        if(type != E_JoystickType.Normal)
        {
            imgBk.gameObject.SetActive(false);
        }
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imgBk.rectTransform, eventData.position,
            eventData.pressEventCamera, out localPos);

        imgControl.transform.localPosition = localPos;

        if( localPos.magnitude > maxL)
        {
            if(type == E_JoystickType.CanMove)
            {
                imgBk.transform.localPosition += (Vector3)(localPos.normalized*(localPos.magnitude-maxL));
            }
            imgControl.transform.localPosition = localPos.normalized * maxL;
        }

        angle = Tools.GetAngle_360(imgControl.transform.localPosition, Vector3.zero);
    }

}
[System.Serializable] public class JoystickEvent : UnityEvent<Vector2> { }