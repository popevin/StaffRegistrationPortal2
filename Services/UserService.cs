using StaffApplication2.DTOs;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using StaffApplication2.Common;
using Dapper;
using System.Security.Cryptography.Xml;
using Newtonsoft.Json.Linq;

namespace StaffApplication2.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserService> _logger;
        public UserService(HttpClient httpClient, ILogger<UserService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }



        public async Task<BaseResponse> CreateUser(CreateUser request)
        {
            var baseresponse = new BaseResponse();
            try
            {

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7117/api/User/CreateUser", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Creating User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"API call failed:";
                    baseresponse.Data = null;
                    return baseresponse;
                }

                var responseJson = await response.Content.ReadAsStringAsync();

                var resp = JsonConvert.DeserializeObject<BaseResponse>(responseJson);
                if (resp.ResponseCode == "00")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    var userData = resp.Data.ToString();
                    User userList = JsonConvert.DeserializeObject<User>(userData);
                    baseresponse.Data = userList;
                    return baseresponse;
                }
                if (resp.ResponseCode == "01")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    baseresponse.Data = null;
                    return baseresponse;

                }
                else
                {
                    _logger.LogInformation("Error  occur  While Creating User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur while Creating user: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while creating user ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while creating user ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> UpdateUser(UpdateUser request)
        {
            var baseresponse = new BaseResponse();
            try
            {

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7117/api/User/UpdateUser", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Updating User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur while Updating user: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

                var responseJson = await response.Content.ReadAsStringAsync();

                var resp = JsonConvert.DeserializeObject<BaseResponse>(responseJson);
                if (resp.ResponseCode == "00")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    var userData = resp.Data.ToString();
                    User userList = JsonConvert.DeserializeObject<User>(userData);
                    baseresponse.Data = userList;
                    return baseresponse;
                }
                if (resp.ResponseCode == "01")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    baseresponse.Data = null;
                    return baseresponse;

                }

                else
                {
                    _logger.LogInformation("Error  occur  While Updating User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"Error  occur  While Updating User: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"An exception occured while Updating user ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Updating user ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> LogInUser(EmailandPassword request)
        {
            var baseresponse = new BaseResponse();
            try
            {

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7117/api/User/LogInUser", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Logging In User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"API call failed:";
                    baseresponse.Data = null;
                    return baseresponse;
                }

                var responseJson = await response.Content.ReadAsStringAsync();

                var resp = JsonConvert.DeserializeObject<BaseResponse>(responseJson);
                if (resp.ResponseCode == "00")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                   var userData = resp.Data.ToString();
                  User userList = JsonConvert.DeserializeObject<User>(userData);
                    baseresponse.Data = userList;
                    return baseresponse;
                }
                if (resp.ResponseCode == "01")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    baseresponse.Data = null;
                    return baseresponse;

                }

                else
                {
                    _logger.LogInformation("Error  occur  While Logging In User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur while Logging In User: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"An exception occured while Logging In User ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Logging In User ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> LogOutUser(EmailandPassword request)
        {
            var baseresponse = new BaseResponse();
            try
            {

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7117/api/User/LogOutUser", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Logging Out User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"API call failed:";
                    baseresponse.Data = null;
                    return baseresponse;
                }

                var responseJson = await response.Content.ReadAsStringAsync();

                var resp = JsonConvert.DeserializeObject<BaseResponse>(responseJson);
                if (resp.ResponseCode == "00")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    var userData = resp.Data.ToString();
                    User userList = JsonConvert.DeserializeObject<User>(userData);
                    baseresponse.Data = userList;
                    return baseresponse;
                }
                if (resp.ResponseCode == "01")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    baseresponse.Data = null;
                    return baseresponse;

                }

                else
                {
                    _logger.LogInformation("Error  occur while  Logging Out  User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur Logging Out User: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while Logging Out User ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Logging Out User ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> DeActivate(DeactivateUser request)
        {
            var baseresponse = new BaseResponse();
            try
            {

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7117/api/User/DeActivateUser", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Deactivating User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"API call failed:";
                    baseresponse.Data = null;
                    return baseresponse;
                }

                var responseJson = await response.Content.ReadAsStringAsync();

                var resp = JsonConvert.DeserializeObject<BaseResponse>(responseJson);
                if (resp.ResponseCode == "00")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    var userData = resp.Data.ToString();
                    User userList = JsonConvert.DeserializeObject<User>(userData);
                    baseresponse.Data = userList;
                    return baseresponse;
                }
                if (resp.ResponseCode == "01")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    baseresponse.Data = null;
                    return baseresponse;

                }

                else
                {
                    _logger.LogInformation("Error  occur  While Deactivating User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur while Deactivating User: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while Deactivating User ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Deactivating User ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> ReActivate(ReactivateUser request)
        {
            var baseresponse = new BaseResponse();
            try
            {

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7117/api/User/ReActivateUser", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Reactivating User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"API call failed:";
                    baseresponse.Data = null;
                    return baseresponse;
                }

                var responseJson = await response.Content.ReadAsStringAsync();

                var resp = JsonConvert.DeserializeObject<BaseResponse>(responseJson);
                if (resp.ResponseCode == "00")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    var userData = resp.Data.ToString();
                    User userList = JsonConvert.DeserializeObject<User>(userData);
                    baseresponse.Data = userList;
                    return baseresponse;
                }
                if (resp.ResponseCode == "01")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    baseresponse.Data = null;
                    return baseresponse;

                }

                else
                {
                    _logger.LogInformation("Error  occur  While Reactivating User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur while Reactivating User: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while Reactivating User ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Reactivating User ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> FindUser(string? userEmail)
        {
            var baseresponse = new BaseResponse();
            try
            {

                //var json = JsonConvert.SerializeObject(requestData);
                // var content = new StringContent(json, Encoding.UTF8, "application/json");
                var url = $"https://localhost:7117/api/User/FindUserbyEmail?userEmail={userEmail}";
                //  var response = await _httpClient.PostAsync("https://localhost:7117/api/User/FindUserbyEmail", content);

                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Finding User by Email");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"API call failed:";
                    baseresponse.Data = null;
                    return baseresponse;
                }

                var responseJson = await response.Content.ReadAsStringAsync();

                var resp = JsonConvert.DeserializeObject<BaseResponse>(responseJson);
                if (resp.ResponseCode == "00")
                {

                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    var userData = resp.Data.ToString();
                    User userList = JsonConvert.DeserializeObject<User>(userData);
                    baseresponse.Data = userList;
                    return baseresponse;

                }
                if (resp.ResponseCode == "01")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    baseresponse.Data = null;
                    return baseresponse;

                }

                else
                {
                    _logger.LogInformation("Error  occur  While Finding user By Email");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur while Finding user By Email: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while Finding user By Email ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Finding user By Email ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> FindUser(long userId)
        {
            var baseresponse = new BaseResponse();
            try
            {

                //var json = JsonConvert.SerializeObject(userId);
              //  var content = new StringContent(json, Encoding.UTF8, "application/json");

                var url = $"https://localhost:7117/api/User/FindUserbyId?userId={userId}";
                var response = await _httpClient.GetAsync(url);
                //  var response = await _httpClient.PostAsync("https://localhost:7117/api/User/FindUserbyId", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Finding User By Id");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"API call failed:";
                    baseresponse.Data = null;
                    return baseresponse;
                }

                var responseJson = await response.Content.ReadAsStringAsync();

                var resp = JsonConvert.DeserializeObject<BaseResponse>(responseJson);
                if (resp.ResponseCode == "00")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    var userData = resp.Data.ToString();
                    User userList = JsonConvert.DeserializeObject<User>(userData);
                    baseresponse.Data = userList;
                    return baseresponse;
                }
                if (resp.ResponseCode == "01")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    baseresponse.Data = null;
                    return baseresponse;

                }

                else
                {
                    _logger.LogInformation("Error  occur  While Finding user By Id");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur while Finding user By id: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while Finding user By id ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Finding User By Id ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> GetAllUsers()
        {
            var baseresponse = new BaseResponse();
            try
            {


                var response = await _httpClient.GetAsync("https://localhost:7117/api/User/GetAllUsers");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Getting all Users");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"API call failed:";
                    baseresponse.Data = null;
                    return baseresponse;
                }

                var responseJson = await response.Content.ReadAsStringAsync();

                var resp = JsonConvert.DeserializeObject<BaseResponse>(responseJson);
                if (resp.ResponseCode == "00")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    var userData = resp.Data.ToString();
                    List<User> userList = JsonConvert.DeserializeObject<List<User>>(userData);
                    baseresponse.Data = userList;
                    return baseresponse;
                }
                else
                {
                    _logger.LogInformation("Error  occur  While Getting all Users");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur Getting all Users: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while Getting all Users ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Getting all Users  ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> GetAllActiveUsers()
        {
            var baseresponse = new BaseResponse();
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7117/api/User/GetAllActiveUsers");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed Getting all active Users");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"API call failed:";
                    baseresponse.Data = null;
                    return baseresponse;
                }

                var responseJson = await response.Content.ReadAsStringAsync();

               var resp = JsonConvert.DeserializeObject<BaseResponse>(responseJson);
                if (resp.ResponseCode == "00")
                {
                    baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    var userData = resp.Data.ToString();
                    List<User> userList = JsonConvert.DeserializeObject<List<User>>(userData);
                    baseresponse.Data = userList;
                    return baseresponse;
                }
                else
                {
                    _logger.LogInformation("Error  occur  While Getting all Active Users User");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur while Getting all Active Users: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while Getting all Active Users user ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured Getting all Active Users ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }
    }
}
