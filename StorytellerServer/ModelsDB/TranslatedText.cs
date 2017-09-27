using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StorytellerServer.ModelsDB
{
    public class TranslatedText
    {
        public int idText { get; set; }
        public string idLanguage { get; set; }
        public string value { get; set; }
    }
}