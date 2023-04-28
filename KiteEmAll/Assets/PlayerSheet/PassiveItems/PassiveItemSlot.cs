using UnityEngine;
using UnityEngine.UI;
public class PassiveItemSlot : MonoBehaviour
{
    [SerializeField] Image Image;
    private PassiveItem _passiveItem;
    public PassiveItem passiveItem
    {
        get { return _passiveItem; }
        set
        {
            _passiveItem = value;
            if (_passiveItem == null)
            {
                Image.enabled = false;
            }
            else
            {
                Image.sprite = _passiveItem.Icon;
                Image.enabled = true;
            }
        }
    }

    protected virtual void OnValidate()
    {
        if (Image == null)
            Image = GetComponent<Image>();
    }
}
