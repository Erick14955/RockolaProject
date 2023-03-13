using System.Windows;
using System.Windows.Input;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using RockolaProject.Clase;
using System.Net;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace RockolaProject
{
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();
        string ruta = "/api/playlist";
        static ObservableCollection<Canciones> song2 = new ObservableCollection<Canciones>();

        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://apirockola-production.up.railway.app");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            GetSongAsync(ruta);
            song2.CollectionChanged += Cambios;
            //this.DataContext = song2;
            song2.Add(new Canciones(3, 3, "Ese", "No importa", "03:45"));
            //LlamadaAsync();
        }

        /*public async void LlamadaAsync()
        {
            //var timeToWait = 5000; //ms
            this.Dispatcher.Invoke(async () =>
            {
                var task = Task.Run(() => SongGrid.ItemsSource = song2);
                await task.WaitAsync(TimeSpan.FromSeconds(12));
            });

            /*Task.Run(async () =>
            {
                await Task.Delay(timeToWait);
                //do your timed task i.e. --
                await GetSongAsync(ruta);

                song2.CollectionChanged += Cambios;
               this.DataContext = song2;
            });*/
            /*var espera = Task.Run(() => GetSongAsync(ruta));
            if(espera.Wait(TimeSpan.FromSeconds(5)))
            {
                song2.CollectionChanged += Cambios;
                this.DataContext = song2;
            }
        }*/

        public void Cambios(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                this.DataContext = song2;
            }
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                this.DataContext = song2;
            }
        }

        static async Task<ObservableCollection<Canciones>> GetSongAsync(string path)
        {
            object song;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                song = await response.Content.ReadAsAsync<object>();
                song2 = JsonConvert.DeserializeObject<ObservableCollection<Canciones>>(song.ToString());
            }
            return song2;
        }

        static async Task<HttpStatusCode> DeleteSongAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/music/{id}");
            return response.StatusCode;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left )
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Play_Button.Content == FindResource("Pause"))
            {
                Play_Button.Content = FindResource("Play");
            }
            else
            {
                Play_Button.Content = FindResource("Pause");
            }
        }
    }
}
