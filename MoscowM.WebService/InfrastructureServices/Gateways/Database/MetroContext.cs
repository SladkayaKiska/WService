using Microsoft.EntityFrameworkCore;
using MoscowM.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowM.InfrastructureServices.Gateways.Database
{
    public class MetroContext : DbContext
    {
        public DbSet<InOutMetro> InOutMetros { get; set; }

        public MetroContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<InOutMetro>().HasData(
                new
  {
                    Id = 1L,
                    Name = "Китай-город, вход-выход 9 в северный вестибюль",
                    MetroStation = "Китай-город  ",
                    MetroLine = "Калужско-Рижская линия  ",

                    Schedule1 = "Режим работы по нечётным дням: открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:43:05, по 2 пути в 05:49:50; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:24  ",

                    Schedule2 = "Режим работы по чётным дням: открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:44:00, по 2 пути в 05:49:05; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:24  "

                },
                new
                {
                    Id = 2L,
                     Name = "Китай-город, вход-выход 5 в северный вестибюль",
                    MetroStation = "Китай-город ",
                    MetroLine = "Калужско-Рижская линия ",

                    Schedule1 = "Режим работы по нечётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:43:05, по 2 пути в 05:49:50; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:16",

                    Schedule2 = "Режим работы по чётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:44:00, по 2 пути в 05:49:05; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:16 "
                },
                new
                {
                    Id = 3L,
                   Name = "Братиславская, вход-выход 5 в северный вестибюль",
                    MetroStation = "Братиславская  ",
                    MetroLine = "Люблинско-Дмитровская линия",

                    Schedule1 = "Режим работы по нечётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:56:00, по 2 пути в 05:42:00; последний поезд по 1 пути в 01:52:00, по 2 пути в 01:12:00  ",

                    Schedule2 = "Режим работы по чётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 06:00:00, по 2 пути в 05:49:00; последний поезд по 1 пути в 01:52:00, по 2 пути в 01:12:00 "
                }
               
            );
        }
    }
}
