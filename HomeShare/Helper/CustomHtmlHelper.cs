using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Helper
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString WelcomeTitle(this HtmlHelper Origin, string texte, string bienvenue)
        {
            
            TagBuilder ta = new TagBuilder("h3"); 
            ta.InnerHtml = texte; 
            ta.AddCssClass(bienvenue);

            return new MvcHtmlString(ta.ToString());
        }
        
    }
}
