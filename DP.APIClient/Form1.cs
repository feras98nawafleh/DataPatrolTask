using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DP.APIClient
{
    public partial class Form1 : Form
    {
        private APIClient apiClient = new APIClient();
        private List<Listener> listeners = new List<Listener>();
        private int listenerCounter = 1;

        public Form1()
        {
            InitializeComponent();

            listViewListeners.Columns.Add("Name", 100);
            listViewListeners.Columns.Add("Target", 100);
            listViewListeners.Columns.Add("Counter", 100);
            listViewListeners.View = View.Details;
            apiClient.ListenersUpdated += ApiClient_ListenersUpdated;
        }

        private void ApiClient_ListenersUpdated(object sender, EventArgs e)
        {
            UpdatelistViewListeners();
        }

        private async void startThreadButton_Click(object sender, EventArgs e)
        {
            string endpointUrl = endpointTextBox.Text;
            if (string.IsNullOrEmpty(endpointUrl))
            {
                MessageBox.Show("Please enter a valid URL.");
                return;
            }

            await apiClient.Start(endpointUrl);
        }

        private void stopThreadsButton_Click(object sender, EventArgs e)
        {
            apiClient.Stop();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int targetNumber = random.Next(1, 5);
            string listenerName = $"Listener {listenerCounter++}";
            Listener listener = new Listener(listenerName, targetNumber);
            apiClient.AddListener(listener);
            listeners.Add(listener);
            UpdatelistViewListeners();
        }

        private void buttonUnregister_Click(object sender, EventArgs e)
        {
            if (listViewListeners.SelectedItems.Count > 0)
            {
                var selectedListener = listViewListeners.SelectedItems[0].Tag as Listener;
                apiClient.RemoveListener(selectedListener);
                listeners.Remove(selectedListener);
                UpdatelistViewListeners();
            }
        }

        private void UpdatelistViewListeners()
        {
            if (listViewListeners.InvokeRequired)
            {
                listViewListeners.Invoke(new Action(UpdatelistViewListeners));
                return;
            }

            listViewListeners.Items.Clear();

            foreach (var listener in listeners)
            {
                var item = new ListViewItem(new[]
                {
                listener.Name,
                listener.TargetNumber.ToString(),
                listener.Counter.ToString()
            });

                item.Tag = listener;
                listViewListeners.Items.Add(item);
            }
        }
    }
}
