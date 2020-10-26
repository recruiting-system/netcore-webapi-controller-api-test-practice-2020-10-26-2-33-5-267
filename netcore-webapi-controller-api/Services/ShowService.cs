using System;
namespace netcore_webapi_controller_api.Services
{
    public class ShowService
    {
        private readonly TextService _textService;

        public ShowService(TextService textService)
        {
            _textService = textService;
        }

        public virtual string GetShowLabel()
        {
            return _textService.GetText();
        }
    }
}
