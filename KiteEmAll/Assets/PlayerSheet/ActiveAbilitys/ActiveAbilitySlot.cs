using UnityEngine;
using UnityEngine.UI;

enum AbilityState
{
    ready,
    active,
    cooldown,
}
public class ActiveAbilitySlot : MonoBehaviour
{
    float cooldownTime;
    float activeTime;
    AbilityState state = AbilityState.ready;
    public KeyCode key;// Trigger - Podpiać pod to button
    private bool buttonPressed = false;
    [SerializeField] Image Image;
    private ActiveAbility _activeAbility;
    public ActiveAbility activeAbility
    {
        get { return _activeAbility; }
        set
        {
            _activeAbility = value;
            if (_activeAbility == null)
            {
                Image.enabled = false;
            }
            else
            {
                Image.sprite = _activeAbility.icon;
                Image.enabled = true;
            }
        }
    }
    protected virtual void OnValidate()
    {
        if (Image == null)
            Image = GetComponent<Image>();
    }

    void Update()//Ability state managment
    {

        switch (state)
        {
            case AbilityState.ready:
                if (buttonPressed || Input.GetKeyDown(key))
                {
                    Debug.Log("Ability Activated");
                    activeAbility.Activate();//Aktywuj z źródła
                    activeTime = activeAbility.activeTime;
                    state = AbilityState.active;
                }
                buttonPressed = false;
                break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    activeAbility.DeActivate();
                    cooldownTime = activeAbility.cooldownTime;
                    state = AbilityState.cooldown;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }

    }
    public void setButtonPressed()
    {
        Debug.Log("AbilitySlot Pressed");
        buttonPressed = true;

    }
}
