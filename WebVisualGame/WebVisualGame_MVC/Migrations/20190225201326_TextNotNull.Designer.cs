﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebVisualGame_MVC.Data;

namespace WebVisualGame_MVC.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190225201326_TextNotNull")]
    partial class TextNotNull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebVisualGame_MVC.Data.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(300);

                    b.Property<double>("Rating");

                    b.Property<string>("SourceCode")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UrlIcon")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("WebVisualGame_MVC.Data.GameData.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KeyСondition");

                    b.Property<int>("TransitionId");

                    b.Property<bool>("Type");

                    b.HasKey("Id");

                    b.HasIndex("TransitionId");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("WebVisualGame_MVC.Data.GameData.PointDialog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Background_imageURL")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("GameId");

                    b.Property<int>("StateNumber");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("PointDialogs");
                });

            modelBuilder.Entity("WebVisualGame_MVC.Data.GameData.PointDialogAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KeyAction");

                    b.Property<int>("PointDialogId");

                    b.Property<bool>("Type");

                    b.HasKey("Id");

                    b.HasIndex("PointDialogId");

                    b.ToTable("PointDialogActions");
                });

            modelBuilder.Entity("WebVisualGame_MVC.Data.GameData.Transition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId");

                    b.Property<int>("NextPoint");

                    b.Property<int>("StartPoint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Transitions");
                });

            modelBuilder.Entity("WebVisualGame_MVC.Data.GameData.TransitionAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KeyAction");

                    b.Property<int>("TransitionId");

                    b.Property<bool>("Type");

                    b.HasKey("Id");

                    b.HasIndex("TransitionId");

                    b.ToTable("TransitionActions");
                });

            modelBuilder.Entity("WebVisualGame_MVC.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessLevel");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PasswordConfirm");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebVisualGame_MVC.Data.Game", b =>
                {
                    b.HasOne("WebVisualGame_MVC.Data.User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebVisualGame_MVC.Data.GameData.Condition", b =>
                {
                    b.HasOne("WebVisualGame_MVC.Data.GameData.Transition")
                        .WithMany("Conditions")
                        .HasForeignKey("TransitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebVisualGame_MVC.Data.GameData.PointDialog", b =>
                {
                    b.HasOne("WebVisualGame_MVC.Data.Game")
                        .WithMany("PointDialogues")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebVisualGame_MVC.Data.GameData.PointDialogAction", b =>
                {
                    b.HasOne("WebVisualGame_MVC.Data.GameData.PointDialog")
                        .WithMany("PointDialogActions")
                        .HasForeignKey("PointDialogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebVisualGame_MVC.Data.GameData.Transition", b =>
                {
                    b.HasOne("WebVisualGame_MVC.Data.Game")
                        .WithMany("Transitions")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebVisualGame_MVC.Data.GameData.TransitionAction", b =>
                {
                    b.HasOne("WebVisualGame_MVC.Data.GameData.Transition")
                        .WithMany("TransitionActions")
                        .HasForeignKey("TransitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
