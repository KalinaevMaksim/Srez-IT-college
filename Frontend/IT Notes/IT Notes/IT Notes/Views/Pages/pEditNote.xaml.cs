using IT_Notes.Models;
using IT_Notes.Utils;
using MailXamarin.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT_Notes.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pEditNote : ContentPage
    {
        public Notes Note { get; set; } = new Notes();

        public pEditNote()
        {
            InitializeComponent();
        }

        public pEditNote(Notes note) : this()
        {
            Note = note;
        }

        private void PEditNote_Appearing(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void RefreshView()
        {
            pEditNote copy = this;
            BindingContext = null;

            Note = copy.Note;
            BindingContext = this;
        }

        private async void BtnAddPhoto_Clicked(object sender, EventArgs e)
        {
            await AddImage();
            RefreshView();
        }

        private async Task AddImage()
        {
            try
            {
                FileResult selectedImage = await SelectImage();

                if (selectedImage == null)
                {
                    return;
                }

                await WriteImage(selectedImage);
            }
            catch (Exception ex)
            {
                await this.ShowInfoAlert(ex.Message);
            }
        }

        private async Task WriteImage(FileResult selectedImage)
        {
            Stream data = await selectedImage.OpenReadAsync();
            Note.photo = data.GetBytesStream();

            ImgPhoto.Source = ImageSource.FromStream(() => data);
        }

        private static async Task<FileResult> SelectImage()
        {
            return await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Выберите изображение"
            });
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Note.description))
                {
                    await this.ShowInfoAlert("Заполните описание");
                    return;
                }

                string data = JsonConvert.SerializeObject(Note);
                (Note.id == 0 ? AddNote(data) : UpdateNote(data)).Invoke();
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                await this.ShowInfoAlert(ex.Message);
            }
        }

        private Action UpdateNote(string data)
        {
            return new Action(async () => await ServerRequestFacade.Send($"api/Notes/{Note.id}", HttpMethod.Put, data));
        }

        private static Action AddNote(string data)
        {
            return new Action(async () => await ServerRequestFacade.Send($"api/Notes", HttpMethod.Post, data));
        }
    }
}