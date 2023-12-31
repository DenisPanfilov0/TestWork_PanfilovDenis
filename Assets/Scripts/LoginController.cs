using System;
using UnityEngine;

public class LoginController : MonoBehaviour
{
    [SerializeField] private LoginView _loginView;
    [SerializeField] private AuthApi _authApi;

    public async void OnLoginButtonClick()
    {
        try
        {
            string login = _loginView.GetLoginInput();
            string password = _loginView.GetPasswordInput();

            AuthApi.AuthResponse authResponse = await _authApi.Login(login, password);

            string accessToken = authResponse.accessToken.token;
            Debug.LogError("AccessToken: " + accessToken);
        }
        catch (Exception e)
        {
            string fullResponse = e.Message;
            int start = fullResponse.IndexOf("{");
            int end = fullResponse.LastIndexOf("}");
            string jsonBody = fullResponse.Substring(start, end - start + 1);
            
            var errorResponse = JsonUtility.FromJson<AuthApi.ErrorResponse>(jsonBody);
            
            _loginView.ShowError(errorResponse.message);
        }
    }
}