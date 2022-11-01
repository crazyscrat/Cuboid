using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
  [SerializeField] private TMP_InputField _inputSpeed;
  [SerializeField] private TMP_InputField _inputDistance;
  [SerializeField] private TMP_InputField _inputCooldown;

  private Controller _controller;

  private void Awake()
  {
    _inputSpeed.onValidateInput += OnValidateDecimal;
    _inputDistance.onValidateInput += OnValidateDecimal;
    _inputCooldown.onValidateInput += OnValidateDecimal;
    
    _inputSpeed.onEndEdit.AddListener(SpeedChange);
    _inputDistance.onEndEdit.AddListener(DistanceChange);
    _inputCooldown.onEndEdit.AddListener(CooldownChange);
  }

  private char OnValidateDecimal(string text, int charindex, char addedchar)
  {
    if (addedchar == '.') addedchar = ',';

    return addedchar;
  }

  public void Init(Controller controller)
  {
    _controller = controller;
  }

  private void SpeedChange(string value)
  {
    if (value.Contains(","))
    {
      value = value.Replace(",", ".");
    }
    float newValue = float.Parse(value, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
    SetSpeed(newValue);
  }

  private void DistanceChange(string value)
  {
    if (value.Contains(","))
    {
      value = value.Replace(",", ".");
    }
    float newValue = float.Parse(value, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
    SetDistance(newValue);
  }

  private void CooldownChange(string value)
  {
    if (value.Contains(","))
    {
      value = value.Replace(",", ".");
    }
    float newValue = float.Parse(value, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
    SetCooldown(newValue);
  }

  void SetSpeed(float speed)
  {
    _controller.SetSpeed(speed);
  }

  void SetDistance(float distance)
  {
    _controller.SetDistance(distance);
  }

  void SetCooldown(float cooldown)
  {
    _controller.SetCooldown(cooldown);
  }
}