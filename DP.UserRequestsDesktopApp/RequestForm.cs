using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP.UserRequestsDesktopApp
{
    public partial class RequestForm : Form
    {
        private static readonly HttpClient client = new HttpClient();


        private static string userId;
        private static string token;
        public RequestForm(string userId, string token)
        {
            userId = userId;
            token = token;
            InitializeComponent();
        }

        private async void createRequestButton_Click(object sender, EventArgs e)
        {
            string code = requestCodeTextbox.Text;
            string description = requestDescriptionLabel.Text;

            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Title and description are required.");
                return;
            }

            var requestData = new
            {
                userId = "string_3",
                title = code,
                description = description
            };

            string json = System.Text.Json.JsonSerializer.Serialize(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiJzdHJpbmdfMyIsIklzRW5hYmxlZCI6dHJ1ZSwibmJmIjoxNzQwODc2NDg5LCJleHAiOjE3NDA4ODAwODksImlhdCI6MTc0MDg3NjQ4OSwiaXNzIjoiaHR0cHM6Ly9hcGkuRFAuY29tIiwiYXVkIjoiaHR0cHM6Ly9hcHAuRFAuY29tIn0.HJN06SaneM_K3SRUZRtg18TisozddQPjsfegdmKsT1U");

            try
            {
                HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/v1/DataPatrol/request/create", content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Request created successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to create request.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ViewSummaryButton_Click(object sender, EventArgs e)
        {
            var summaryForm = new SummaryForm();
            summaryForm.Show();
        }
    }
}
