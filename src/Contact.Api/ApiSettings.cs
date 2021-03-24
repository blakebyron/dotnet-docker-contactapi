using System;
namespace Contact.Api
{
    /// <summary>
    /// Stores Application wide configuration settings
    /// </summary>
    public class ApiSettings
    {
        public bool IsDummyDataRequired { get; set; }

        public ApiSettings()
        {
        }
    }
}
