﻿using CRUDCaminhoes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDCaminhoes.Data
{
    public class BancoContext : DbContext
    {


        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<CaminhaoModel> Caminhao { get; set; }
           

    }
}
