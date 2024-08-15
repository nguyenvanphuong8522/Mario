using UnityEngine;
using UnityEngine.UI;

public class BasePopup : MonoBehaviour
{
    public Button btnClose;
    public bool isShow = false;


    protected virtual void Awake() 
    {
        if (btnClose)
        {
            btnClose.onClick.AddListener(Hide);
        }
    }

    public virtual void Show(object data = null)
    {
        isShow = true;
        gameObject.SetActive(true);
    }   

    public virtual void Hide()
    {
        isShow = false;
        gameObject.SetActive(false);
    }
}
