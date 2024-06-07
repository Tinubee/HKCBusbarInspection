﻿// <auto-generated />
using System;
using HKCBusbarInspection.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HKCBusbarInspection.Migrations.검사결과테이블Migrations
{
    [DbContext(typeof(검사결과테이블))]
    [Migration("20240607022314_AddShuttle")]
    partial class AddShuttle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HKCBusbarInspection.Schemas.검사결과", b =>
                {
                    b.Property<DateTime>("검사일시")
                        .HasColumnName("ilwdt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CTQ결과")
                        .HasColumnName("ilctq")
                        .HasColumnType("integer");

                    b.Property<int>("검사코드")
                        .HasColumnName("ilnum")
                        .HasColumnType("integer");

                    b.Property<int>("모델구분")
                        .HasColumnName("ilmcd")
                        .HasColumnType("integer");

                    b.Property<int>("셔틀위치")
                        .HasColumnName("ilshu")
                        .HasColumnType("integer");

                    b.Property<int>("외관결과")
                        .HasColumnName("ilsuf")
                        .HasColumnType("integer");

                    b.Property<int>("측정결과")
                        .HasColumnName("ilres")
                        .HasColumnType("integer");

                    b.HasKey("검사일시");

                    b.ToTable("inspl");
                });

            modelBuilder.Entity("HKCBusbarInspection.Schemas.검사정보", b =>
                {
                    b.Property<DateTime>("검사일시")
                        .HasColumnName("idwdt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("검사항목")
                        .HasColumnName("iditm")
                        .HasColumnType("integer");

                    b.Property<int>("검사그룹")
                        .HasColumnName("idgrp")
                        .HasColumnType("integer");

                    b.Property<int>("검사장치")
                        .HasColumnName("iddev")
                        .HasColumnType("integer");

                    b.Property<decimal>("결과값")
                        .HasColumnName("idval")
                        .HasColumnType("numeric");

                    b.Property<int>("결과분류")
                        .HasColumnName("idcat")
                        .HasColumnType("integer");

                    b.Property<decimal>("교정값")
                        .HasColumnName("idcal")
                        .HasColumnType("numeric");

                    b.Property<decimal>("기준값")
                        .HasColumnName("idstd")
                        .HasColumnType("numeric");

                    b.Property<decimal>("보정값")
                        .HasColumnName("idoff")
                        .HasColumnType("numeric");

                    b.Property<decimal>("최대값")
                        .HasColumnName("idmax")
                        .HasColumnType("numeric");

                    b.Property<decimal>("최소값")
                        .HasColumnName("idmin")
                        .HasColumnType("numeric");

                    b.Property<decimal>("측정값")
                        .HasColumnName("idmes")
                        .HasColumnType("numeric");

                    b.Property<int>("측정결과")
                        .HasColumnName("idres")
                        .HasColumnType("integer");

                    b.Property<int>("측정단위")
                        .HasColumnName("iduni")
                        .HasColumnType("integer");

                    b.HasKey("검사일시", "검사항목");

                    b.ToTable("inspd");
                });
#pragma warning restore 612, 618
        }
    }
}
