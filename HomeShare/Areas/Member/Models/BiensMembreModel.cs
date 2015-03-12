using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeShareDAL;

namespace HomeShare.Areas.Member.Models
{
    public class BiensMembreModel
    {

        public List<BienEchange> LstBiens
        {
            get;
            set;
        }

        public string Titre
        {
            get;
            set;
        }

        public string DescCourte
        {
            get;
            set;
        }

        public DateTime DateCreation
        {
            get;
            set;
        }
    }
}