using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
namespace DP.UserRequestsDesktopApp
{
    public partial class LoginForm : Form
    {
        private static readonly HttpClient client = new HttpClient();


        public LoginForm()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = passwordTextbox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                missingCredentialsErrorLabel.Visible = true;
                return;
            }

            var registrationData = new
            {
                username = username,
                password = password
            };

            string json = System.Text.Json.JsonSerializer.Serialize(registrationData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/v1/DataPatrol/reg", content);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responseObject = System.Text.Json.JsonSerializer.Deserialize<RegistrationResponse>(responseBody);

                    string userId = responseObject.data.userId;
                    string token = responseObject.data.token;

                    MessageBox.Show("Registration successful!");
                    this.Hide();
                    var requestForm = new RequestForm(userId, token);
                    requestForm.Show();
                }
                else
                {
                    missingCredentialsErrorLabel.Text = "Failed to register!";
                }
            }
            catch (Exception ex)
            {
                missingCredentialsErrorLabel.Text = $"Error: {ex.Message}";
            }
        }

        private void missingCredentialsErrorLabel_DoubleClick(object sender, EventArgs e)
        {
            missingCredentialsErrorLabel.Visible = false;
        }

        public class RegistrationResponse
        {
            public bool success { get; set; }
            public Data data { get; set; }
            public string message { get; set; }
            public int statusCode { get; set; }
        }

        public class Data
        {
            public string userId { get; set; }
            public bool isEnabled { get; set; }
            public string token { get; set; }
        }
    }
}
