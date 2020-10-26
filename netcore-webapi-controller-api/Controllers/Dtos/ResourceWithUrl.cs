using System;
namespace netcore_webapi_controller_api.Controllers.Dtos
{
    public class ResourceWithUrl<T>
    {
        public ResourceWithUrl()
        {
        }

        public ResourceWithUrl(T content, string url)
        {
            Content = content;
            Url = url;
        }

        public T Content { get; set; }
        public string Url { get; set; }

    }
}
