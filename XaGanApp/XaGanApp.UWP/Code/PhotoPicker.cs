using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using XaGanApp.Interfaces;
using XaGanApp.UWP.Code;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhotoPicker))]
namespace XaGanApp.UWP.Code
{
    public class PhotoPicker : IPhotoPicker
    {
        private List<StorageFile> imagelist = new List<StorageFile>();
        private List<string> path_List = new List<string>();

        public PhotoPicker()
        {
            // openBtn_Click();
        }

        public async Task<List<string>> openBtn_Click()
        {
            imagelist.Clear();
            imagelist = await process();

            return path_List;
        }

        public List<string> pathList()
        {
            return path_List;
        }

        private async Task<List<StorageFile>> process()
        {
            FileOpenPicker openPicker = new FileOpenPicker();

            openPicker.ViewMode = PickerViewMode.Thumbnail;

            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;

            openPicker.FileTypeFilter.Add(".jpg");

            openPicker.FileTypeFilter.Add(".png");

            var filelist = await openPicker.PickMultipleFilesAsync();

            if (filelist != null)

            {
                foreach (var files in filelist)

                {

                    var stream = await files.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    
                    imagelist.Add(files);
                    path_List.Add(files.Path);

                }

            }
            else
            {
                //
            }
            return imagelist;
        }

        public async Task<List<string>> Upload()
        {
            List<string> listResponse = new List<string>();

            foreach (var file in imagelist)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://dangnguyenthehung.somee.com/UploadToServer/api/Files/Upload");

                MultipartFormDataContent form = new MultipartFormDataContent();
                HttpContent content = new StringContent("fileToUpload");
                form.Add(content, "fileToUpload");
                var stream = await file.OpenStreamForReadAsync();
                content = new StreamContent(stream);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "fileToUpload",
                    FileName = file.Name
                };
                form.Add(content);

                var response = await client.PostAsync(client.BaseAddress, form);
                listResponse.Add(response.Content.ReadAsStringAsync().Result);
            }

            return listResponse;

        }
    }
}
