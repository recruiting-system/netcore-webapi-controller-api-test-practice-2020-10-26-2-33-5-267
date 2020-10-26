using System;
namespace netcore_webapi_controller_api.Services
{
    public class TextService
    {
        public static string ORIGINAL_OUTPUT = "Original Text Service Text";

        public TextService()
        {
        }

        public string GetText()
        {
            return ORIGINAL_OUTPUT;
        }
    }
}
