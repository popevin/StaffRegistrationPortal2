using Newtonsoft.Json;
using StaffApplication2.Common;
using StaffApplication2.DTOs;
using System.Text;

namespace StaffApplication2.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(HttpClient httpClient, ILogger<EmployeeService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<BaseResponse> CreateEmployee(CreateEmployee request)
        {
            var baseresponse = new BaseResponse();
            try
            {

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7117/api/Employee/CreateEmployeeDetails", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Creating Employee");
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
                    var employeeData = resp.Data.ToString();
                    User employeeList = JsonConvert.DeserializeObject<User>(employeeData);
                    baseresponse.Data = employeeList;
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
                    _logger.LogInformation("Error  occur  While Creating Employee");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur while Creating Employee: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while creating Employee ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while creating Employee ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> UpdateEmployee(UpdateEmployee request)
        {
            var baseresponse = new BaseResponse();
            try
            {

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7117/api/Employee/UpdateEmployeeDetails", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Updating Employee");
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
                    var employeeData = resp.Data.ToString();
                    User employeeList = JsonConvert.DeserializeObject<User>(employeeData);
                    baseresponse.Data = employeeList;
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
                    _logger.LogInformation("Error  occur  While Updating Employee");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur while Updating Employee: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while Updating Employee==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Updating Employee ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> DeleteEmployee(DeleteEmployee request)
        {
            var baseresponse = new BaseResponse();
            try
            {

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7117/api/Employee/DeleteEmployeeDetails", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Deleting Employee");
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
                    var employeeData = resp.Data.ToString();
                    User employeeList = JsonConvert.DeserializeObject<User>(employeeData);
                    baseresponse.Data = employeeList;
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
                    _logger.LogInformation("Error  occur  While Deleting Employee");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur while Deleting Employee: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while Deleting Employee ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Deleting Employee ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> FindEmployee(string? email)
        {
            var baseresponse = new BaseResponse();
            try
            {

                var json = JsonConvert.SerializeObject(email);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7117/api/User/FindEmployeebyEmail", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Finding Employee by Email");
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
                    var employeeData = resp.Data.ToString();
                    User employeeList = JsonConvert.DeserializeObject<User>(employeeData);
                    baseresponse.Data = employeeList;
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
                    _logger.LogInformation("An error occur Finding Employee by Email");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur Finding Employee by Email: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while creating user ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Finding Employee by Email ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> FindEmployee(long userId)
        {
            var baseresponse = new BaseResponse();
            try
            {

                var json = JsonConvert.SerializeObject(userId);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7117/api/User/FindEmployeebyId", content);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("aAPI call failed While Finding Employee by Id");
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
                    var employeeData = resp.Data.ToString();
                    User employeeList = JsonConvert.DeserializeObject<User>(employeeData);
                    baseresponse.Data = employeeList;
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
                    _logger.LogInformation("An error occur Finding Employee by Id");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur Finding Employee by Id: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while creating user ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Finding Employee by Id ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> GetAllEmployee()
        {
            var baseresponse = new BaseResponse();
            try
            {


                var response = await _httpClient.GetAsync("https://localhost:7117/api/User/GetAllEmployee");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Getting All Employee");
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
                    var employeeData = resp.Data.ToString();
                    List<User> employeeList = JsonConvert.DeserializeObject<List<User>>(employeeData);
                    baseresponse.Data = employeeList;
                    return baseresponse;
                }
                else
                {
                    _logger.LogInformation("Error  occur  While Getting All  Employee");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"Error  occur  While Getting All  Employee: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while creating user ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Getting All Employee ==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }

        public async Task<BaseResponse> GetAllActiveEmployee()
        {
            var baseresponse = new BaseResponse();
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7117/api/User/GetAllActiveEmployee");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("API call failed While Getting All Active Employee");
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
                    var employeeData = resp.Data.ToString();
                    List<User> employeeList = JsonConvert.DeserializeObject<List<User>>(employeeData);
                    baseresponse.Data = employeeList;
                    return baseresponse; ;
                }
                else
                {
                    _logger.LogInformation("Error  occur  While Getting All Active Employee");
                    baseresponse.ResponseCode = "401";
                    baseresponse.ResponseMessage = $"An error occur while Getting All Active Employee: {response.StatusCode}";
                    baseresponse.Data = null;
                    return baseresponse;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"An exception occured while creating user ==> Message: {ex.Message}");

                baseresponse.ResponseMessage = $"An exception occured while Getting All Active Employee==> Message: {ex.Message}";
                baseresponse.ResponseCode = "401";
                baseresponse.Data = null;
                return baseresponse;
            }

        }
    }
}
