using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShare.Areas.Member.Models
{
    public class MembreModel:BiensMembreModel
    {
        public MembreModel CurrentMembre
        {
            get;
            set;
        }
    }
}