﻿// <auto-generated />
using System;
using HKCBusbarInspection.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HKCBusbarInspection.Migrations
{
    [DbContext(typeof(로그테이블))]
    [Migration("20240529082211_logs")]
    partial class logs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HKCBusbarInspection.Schemas.로그정보", b =>
                {
                    b.Property<DateTime>("시간")
                        .HasColumnName("ltime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("구분")
                        .HasColumnName("ltype")
                        .HasColumnType("integer");

                    b.Property<string>("내용")
                        .HasColumnName("lcont")
                        .HasColumnType("text");

                    b.Property<string>("영역")
                        .HasColumnName("larea")
                        .HasColumnType("text");

                    b.Property<string>("작업자")
                        .HasColumnName("luser")
                        .HasColumnType("text");

                    b.Property<string>("제목")
                        .HasColumnName("lsubj")
                        .HasColumnType("text");

                    b.HasKey("시간");

                    b.ToTable("logs");
                });
#pragma warning restore 612, 618
        }
    }
}
