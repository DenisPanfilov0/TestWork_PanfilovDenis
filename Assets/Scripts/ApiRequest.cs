//TODO сначала написал всё в один класс, потом разбил на 3. Вью, запрос на сервер и обработчик.

// using System;
// using UnityEngine;
// using Cysharp.Threading.Tasks;
// using TMPro;
// using UnityEngine.Networking;
//
// public class ApiRequest : MonoBehaviour
// {
//     [SerializeField] private TMP_InputField _inputLogin;
//     [SerializeField] private TMP_InputField _inputPassword;
//     [SerializeField] private GameObject _errorConsole;
//     [SerializeField] private TextMeshProUGUI _errorText;
//     
//     private string apiUrl = "https://stage.arenagames.api.ldtc.space/";
//     private string authEndpoint = "api/v3/gamedev/client/auth/sign-in";
//     
//     [Serializable]
//     public class LoginData
//     {
//         public string password;
//         public string login;
//     }
//     
//     [Serializable]
//     public class ErrorResponse
//     {
//         public string type;
//         public string code;
//         public string message;
//     }
//
//     public async void OnLoginButtonClick()
//     {
//         var jsonData = new LoginData
//         {
//             password = _inputPassword.text,
//             login = _inputLogin.text
//         };
//
//         string jsonBody = JsonUtility.ToJson(jsonData);
//         
//         using var request = new UnityWebRequest(apiUrl + authEndpoint, "POST");
//         
//         byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
//         
//         request.uploadHandler = new UploadHandlerRaw(bodyRaw);
//         request.downloadHandler = new DownloadHandlerBuffer();
//         request.SetRequestHeader("Content-Type", "application/json");
//         
//         var sendRequest = request.SendWebRequest();
//
//         try
//         {
//             await sendRequest.ToUniTask();
//             AuthResponse authResponse = JsonUtility.FromJson<AuthResponse>(request.downloadHandler.text);
//             string accessToken = authResponse.accessToken.token;
//             Debug.LogError("AccessToken: " + accessToken);
//         }
//         catch (Exception e)
//         {
//             _errorConsole.SetActive(true);
//             var errorResponse = JsonUtility.FromJson<ErrorResponse>(request.downloadHandler.text);
//             _errorText.text = ("Error: " + errorResponse.message);
//         }
//     }
//     
//     [Serializable]
//     public class AuthResponse
//     {
//         public AccessTokenData accessToken;
//         public RefreshTokenData refreshToken;
//
//         [Serializable]
//         public class AccessTokenData
//         {
//             public string token;
//             public long expiresIn;
//         }
//
//         [Serializable]
//         public class RefreshTokenData
//         {
//             public string token;
//             public long expiresIn;
//         }
//     }
// }