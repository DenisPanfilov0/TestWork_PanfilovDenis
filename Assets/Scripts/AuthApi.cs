using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class AuthApi : MonoBehaviour
{
    private string apiUrl = "https://stage.arenagames.api.ldtc.space/";
    private string authEndpoint = "api/v3/gamedev/client/auth/sign-in";

    [Serializable]
    public class LoginData
    {
        public string password;
        public string login;
    }

    [Serializable]
    public class AuthResponse
    {
        public AccessTokenData accessToken;
        public RefreshTokenData refreshToken;

        [Serializable]
        public class AccessTokenData
        {
            public string token;
            public long expiresIn;
        }

        [Serializable]
        public class RefreshTokenData
        {
            public string token;
            public long expiresIn;
        }
    }

    [Serializable]
    public class ErrorResponse
    {
        public string type;
        public string code;
        public string message;
    }

    public async UniTask<AuthResponse> Login(string login, string password)
    {
        var jsonData = new LoginData
        {
            password = password,
            login = login
        };

        string jsonBody = JsonUtility.ToJson(jsonData);
        using var request = new UnityWebRequest(apiUrl + authEndpoint, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        var sendRequest = request.SendWebRequest();

        await sendRequest.ToUniTask();

        return JsonUtility.FromJson<AuthResponse>(request.downloadHandler.text);
    }
}