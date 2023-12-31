using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class LoginView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputLogin;
    [SerializeField] private TMP_InputField _inputPassword;
    [FormerlySerializedAs("_errorConsole")] [SerializeField] private GameObject _errorForm;
    [SerializeField] private TextMeshProUGUI _errorText;

    public string GetLoginInput()
    {
        return _inputLogin.text;
    }

    public string GetPasswordInput()
    {
        return _inputPassword.text;
    }

    public void ShowError(string errorMessage)
    {
        _errorForm.SetActive(true);
        _errorText.text = "Error: " + errorMessage;
    }
}