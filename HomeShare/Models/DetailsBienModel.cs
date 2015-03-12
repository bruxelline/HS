using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeShare.Areas.Member.Models;
using HomeShareDAL;

namespace HomeShare.Models
{
    public class DetailsBienModel:MembreModel
    {
        public BienEchange CurrentBien
        {
            get;
            set;
        }

        public Pays PaysDuBien
        {
            get;
            set;
        }

        public List<OptionsBien> ListeOptions
        {
            get;
            set;
        }

        public List<Options> ListeLibelleOptions
        {
            get;
            set;
        }
    }
}