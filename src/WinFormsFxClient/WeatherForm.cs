using System;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;
using Grpc.Net.Client;
using Weather;
using WeatherClientLib;

namespace WeatherWinFormsFx
{
    public partial class WeatherForm : Form
    {
        bool isCollapsed = true;
        readonly CancellationTokenSource cts = new CancellationTokenSource();
        readonly string serviceUrl = ConfigurationManager.AppSettings.Get("WeatherServiceUrl");

        public WeatherForm()
        {
            InitializeComponent();
            PollWeather();
        }

        private async void PollWeather()
        {
            var client = new Weather.Weather.WeatherClient(GrpcChannel.ForAddress(serviceUrl));
            var weatherService = new GrpcWeatherForecastService(client);

            await foreach (var message in weatherService.GetStreamingWeather(cts.Token))
            {
                UpdateForm(message);
            };
        }

        private void UpdateForm(WeatherResponse weatherResponse)
        {
            City.Text = weatherResponse.Location;
            WeatherIcon.Load(weatherResponse.WeartherUri);
            Temperature.Text = (weatherResponse.Temperature == -432) ? "9K" : weatherResponse.Temperature.ToString();
            WeatherText.Text = weatherResponse.WeatherText;
            Pressure.Text = $"{weatherResponse.Pressure.ToString()} in";
            Wind.Text = $"{weatherResponse.WindSpeed.ToString()} mph";
            Humidity.Text = $"{weatherResponse.RelativeHumidity.ToString()} %";
            UVIndex.Text = weatherResponse.UvIndex.ToString();
            var localTime = weatherResponse.RetrievedDateTimeOffset.ToLocalTime();
            Updated.Text = $"Updated at {localTime.ToString("h:mm:ss tt")}";
        }

        private void CollapseExpandButton_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                this.Size = new System.Drawing.Size(this.Size.Width, 640);
                CollapseExpandButton.Text = "ꓥ";
                isCollapsed = false;
            }
            else
            {
                this.Size = new System.Drawing.Size(this.Size.Width, 380);
                CollapseExpandButton.Text = "ꓦ";
                isCollapsed = true;
            }
        }
    }
}
