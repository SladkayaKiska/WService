﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoscowM.InfrastructureServices.Gateways.Database;

namespace MoscowM.WebService.Migrations
{
    [DbContext(typeof(MetroContext))]
    [Migration("20200523194802_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("MoscowM.DomainObjects.InOutMetro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MetroLine")
                        .HasColumnType("TEXT");

                    b.Property<string>("MetroStation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Schedule1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Schedule2")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("InOutMetros");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            MetroLine = "Калужско-Рижская линия  ",
                            MetroStation = "Китай-город  ",
                            Name = "Китай-город, вход-выход 9 в северный вестибюль",
                            Schedule1 = "Режим работы по нечётным дням: открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:43:05, по 2 пути в 05:49:50; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:24  ",
                            Schedule2 = "Режим работы по чётным дням: открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:44:00, по 2 пути в 05:49:05; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:24  "
                        },
                        new
                        {
                            Id = 2L,
                            MetroLine = "Калужско-Рижская линия ",
                            MetroStation = "Китай-город ",
                            Name = "Китай-город, вход-выход 5 в северный вестибюль",
                            Schedule1 = "Режим работы по нечётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:43:05, по 2 пути в 05:49:50; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:16",
                            Schedule2 = "Режим работы по чётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:44:00, по 2 пути в 05:49:05; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:16 "
                        },
                        new
                        {
                            Id = 3L,
                            MetroLine = "Люблинско-Дмитровская линия",
                            MetroStation = "Братиславская  ",
                            Name = "Братиславская, вход-выход 5 в северный вестибюль",
                            Schedule1 = "Режим работы по нечётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:56:00, по 2 пути в 05:42:00; последний поезд по 1 пути в 01:52:00, по 2 пути в 01:12:00  ",
                            Schedule2 = "Режим работы по чётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 06:00:00, по 2 пути в 05:49:00; последний поезд по 1 пути в 01:52:00, по 2 пути в 01:12:00 "
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
