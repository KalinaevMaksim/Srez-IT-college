using IT_Notes.Models;
using MailXamarin.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT_Notes.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pStartPage : ContentPage
    {
        public List<Notes> Notes { get; set; }

        public pStartPage()
        {
            InitializeComponent();
        }

        private async void PStartPage_Appearing(object sender, EventArgs e)
        {
            await RefreshView();
        }

        private async Task RefreshView()
        {
            await GetNotes();
            BindingContext = null;
            BindingContext = this;
        }

        private async Task GetNotes()
        {
            string result = await ServerRequestFacade.Send("api/Notes", HttpMethod.Get);
            Notes = JsonConvert.DeserializeObject<List<Notes>>(result);
        }

        private async void BtnAddNote_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new pEditNote());
            await RefreshView();
        }

        private async void BtnEditNote_Clicked(object sender, EventArgs e)
        {
            Notes notes = LstVNotes.SelectedItem as Notes;
            await Navigation.PushModalAsync(new pEditNote(notes));
            await RefreshView();
        }

        private async void BtnDeleteNote_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool response = await this.ShowQuestionAlert("Вы действительно хотите удалить эту записку ?");

                if (!response)
                {
                    return;
                }

                var button = sender as Button;
                Notes note = button.CommandParameter as Notes;

                await ServerRequestFacade.Send($"api/Notes/{note.id}", HttpMethod.Delete);

                await RefreshView();
            }
            catch (Exception ex)
            {
                await this.ShowInfoAlert(ex.Message);
            }
        }
    }
}