﻿using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShare.Areas.Member.Models
{
    public class MembreModel:BiensModel
    {
        public Membre CurrentMembre
        {
            get;
            set;
        }

        public List<AvisMembreBien> ListeAvis
        {
            get;
            set;
        }
    }
}