using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinDoctors.Models;

namespace XamarinDoctors.Repositories
{
    public class RepositoryDoctor
    {
        String UrlApi;
        public RepositoryDoctor()
        {
            UrlApi = "https://apidoctoresxamarinasr.azurewebsites.net/";
        }
        private HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        public async Task<List<Doctor>> GetDoctor()
        {
            HttpClient client = GetHttpClient();
            String request = "api/Doctor/";
            Uri uri = new Uri(UrlApi + request);
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                String content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Doctor>>(content);
            }
            else
                return null;
        }
        public async Task<Doctor> GetDoctor(int id)
        {
            HttpClient client = GetHttpClient();
            String request = "api/Doctor/" + id;
            Uri uri = new Uri(UrlApi + request);
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                String content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Doctor>(content);
            }
            else
                return null;
        }
        public async Task InsertDoctor(Doctor newDoc)
        {
            newDoc.Id = 0;
            String jsonDoc = JsonConvert.SerializeObject(newDoc, Formatting.Indented);
            byte[] bufferDoc = Encoding.UTF8.GetBytes(jsonDoc);
            //En xamarin hay que enviar los datos como ByteArrayContent
            ByteArrayContent content = new ByteArrayContent(bufferDoc);
            //Y hay que indicar que tipo de contenido estamos enviando
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient client = GetHttpClient();
            String request = "api/Doctor/";
            Uri uri = new Uri(UrlApi + request);
            HttpResponseMessage response = await client.PostAsync(uri, content);
        }
        public async Task DeleteDoctor(int id)
        {
            HttpClient client = GetHttpClient();
            String request = "api/Doctor/" + id;
            Uri uri = new Uri(UrlApi + request);
            HttpResponseMessage response = await client.DeleteAsync(uri);
        }
        public async Task UpdateDoctor(int id, Doctor doc)
        {            
            String jsonDoc = JsonConvert.SerializeObject(doc, Formatting.Indented);
            byte[] bufferDoc = Encoding.UTF8.GetBytes(jsonDoc);
            //En xamarin hay que enviar los datos como ByteArrayContent
            ByteArrayContent content = new ByteArrayContent(bufferDoc);
            //Y hay que indicar que tipo de contenido estamos enviando
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient client = GetHttpClient();
            String request = "api/Doctor/" + id;
            Uri uri = new Uri(UrlApi + request);
            HttpResponseMessage response = await client.PutAsync(uri, content);
        }
    }
}
