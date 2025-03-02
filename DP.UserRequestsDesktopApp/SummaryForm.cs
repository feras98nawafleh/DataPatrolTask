using System;
using System.Net.Http;
using System.Windows.Forms;

namespace DP.UserRequestsDesktopApp
{
    public partial class SummaryForm : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public SummaryForm()
        {
            InitializeComponent();
            LoadSummary();
        }

        private async void LoadSummary()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://yourapi.com/request/summary");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    string summaryData = System.Text.Json.JsonSerializer.Serialize(json);
                    //summaryDataGridView.DataSource = summaryData;
                }
                else
                {
                    MessageBox.Show("Failed to load summary.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, EventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadSummary();
        }
    }
}