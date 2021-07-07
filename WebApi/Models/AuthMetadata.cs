using System;

namespace WebApi.Models
{
    public class AuthMetadata
    {
        // can optionally include other metadata, such as user agent, ip address, device name, and so on
        public string UserName { get; set; }

        public DateTime ExpireAt { get; set; }
    }
}