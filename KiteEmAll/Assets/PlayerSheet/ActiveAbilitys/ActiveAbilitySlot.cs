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
    float imageAnimationTimer = 0;
    float activeTime;
    AbilityState state = AbilityState.ready;
    public KeyCode key;// Trigger - Podpiać pod to button
    private bool buttonPressed = false;
    [SerializeField] Image Image;
    private Color currentColor;
    [SerializeField] private float colorSpeed = 1f;
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
                if (buttonPressed)
                {
                    activeAbility.Activate();
                    activeTime = activeAbility.activeTime;
                    state = AbilityState.active;
                }
                buttonPressed = false;
                break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                    currentColor = Image.color;
                    currentColor.r = Mathf.Sin(Time.time * colorSpeed) * 0.5f + 0.5f;
                    currentColor.g = Mathf.Sin(Time.time * colorSpeed + Mathf.PI * 2f / 3f) * 0.5f + 0.5f;
                    currentColor.b = Mathf.Sin(Time.time * colorSpeed + Mathf.PI * 4f / 3f) * 0.5f + 0.5f;
                    Image.color = currentColor;
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
                    imageAnimationTimer += Time.deltaTime;
                    Image.fillAmount = imageAnimationTimer / activeAbility.cooldownTime;
                    Image.color = Color.white;
                }
                else
                {
                    Image.fillAmount = 1;
                    imageAnimationTimer = 0;
                    state = AbilityState.ready;
                }
                break;
        }
    }
    public void setButtonPressed()
    {
        if (state == AbilityState.ready)
            buttonPressed = true;
    }
}
