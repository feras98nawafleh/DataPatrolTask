using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DP.APIClient
{
    public class APIClient
    {
        private List<Listener> listeners = new List<Listener>();
        private bool isRunning = false;
        private CancellationTokenSource cancellationTokenSource;
        private HttpClient httpClient = HttpClientFactory.CreateHttpClient();

        public List<Listener> Listeners => listeners;

        public event EventHandler ListenersUpdated;

        public async Task Start(string endpointUrl)
        {
            isRunning = true;
            cancellationTokenSource = new CancellationTokenSource();

            while (isRunning)
            {
                try
                {
                    int result = await CallAPI(endpointUrl);
                    BroadcastResult(result);
                    await Task.Delay(10000, cancellationTokenSource.Token);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"API Error: {ex.Message}");
                }
            }
        }

        public void Stop()
        {
            isRunning = false;
            cancellationTokenSource?.Cancel();
        }

        private async Task<int> CallAPI(string endpointUrl)
        {
            HttpResponseMessage response = await httpClient.GetAsync(endpointUrl);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            JsonDocument doc = JsonDocument.Parse(content);
            JsonElement root = doc.RootElement;
            int number = root.GetProperty("data").GetProperty("number").GetInt32();

            return number;
        }

        private void BroadcastResult(int result)
        {
            foreach (var listener in listeners)
            {
                listener.ProcessResult(result);
            }

            ListenersUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void AddListener(Listener listener)
        {
            listeners.Add(listener);
            ListenersUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveListener(Listener listener)
        {
            listeners.Remove(listener);
            ListenersUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}