using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assistant {

    class Program
    {
        static string PREFIX = "wonoly";

        public string getFunction(string text)
        {
            
            
            Dictionary<string, string> result = getConversations(removePrefix(text));
            
            foreach(var item in result)
            {
                switch (item.Key) 
                {
                    case "search":
                        openSearchURI(item.Value);
                        break;
                }
            }

            return text;
        }

        private void openSearchURI(string query) {
            string url = "https://search.wonoly.net/search?q=" + query;
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch
            {
                if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
            }
        }

        private string removePrefix(string text) {
            return text.Replace(PREFIX, "");
        }

        private Dictionary<string, string> getConversations(string text) {
            
            Dictionary<string, string> conversations = new Dictionary<string, string>(){
                // looku
                {"can you lookup for", "search"},
                {"can you lookup", "search"},
                {"lookup", "search"},
                // search
                {"can you search for", "search"},
                {"can you search", "search"},
                {"search for", "search"},
                {"search", "search"},
            };

            foreach(var item in conversations)
            {
                
                if (text.Contains(item.Key))
                    return new Dictionary<string, string>(){
                        {item.Value, text.Replace(item.Key, "").Replace(" ", "")}
                    };
            }

            return new Dictionary<string, string>(){
                {"undefined", "undefined"}
            };

        }
    }
}