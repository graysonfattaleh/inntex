﻿// <auto-generated />
using System;
using BurialSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BurialSite.Migrations
{
    [DbContext(typeof(ArcDBContext))]
    partial class ArcDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BurialFileUrl", b =>
                {
                    b.Property<int>("BurialID")
                        .HasColumnType("integer");

                    b.Property<int>("FileUrlId")
                        .HasColumnType("integer");

                    b.HasKey("BurialID", "FileUrlId");

                    b.HasIndex("FileUrlId");

                    b.ToTable("BurialFileUrl");
                });

            modelBuilder.Entity("BurialLocationYearsExcavatedFrom", b =>
                {
                    b.Property<int>("BurialLocationId")
                        .HasColumnType("integer");

                    b.Property<int>("YearsExcavatedFromsYearsExcavatedFromId")
                        .HasColumnType("integer");

                    b.HasKey("BurialLocationId", "YearsExcavatedFromsYearsExcavatedFromId");

                    b.HasIndex("YearsExcavatedFromsYearsExcavatedFromId");

                    b.ToTable("BurialLocationYearsExcavatedFrom");
                });

            modelBuilder.Entity("BurialSite.Models.Burial", b =>
                {
                    b.Property<int>("BurialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Age")
                        .HasColumnType("text");

                    b.Property<decimal?>("Age_At_Death")
                        .HasColumnType("numeric");

                    b.Property<char?>("Age_Code")
                        .HasColumnType("character(1)");

                    b.Property<string>("Age_Method")
                        .HasColumnType("text");

                    b.Property<string>("Artifact_Found")
                        .HasColumnType("text");

                    b.Property<string>("Artifacts_Description")
                        .HasColumnType("text");

                    b.Property<string>("BYU_Sample")
                        .HasColumnType("text");

                    b.Property<int?>("Bag")
                        .HasColumnType("integer");

                    b.Property<string>("Basilar_Suture")
                        .HasColumnType("text");

                    b.Property<decimal?>("Basion_Bregma_Height")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Basion_Nasion")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Basion_Prosthion_Length")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Bizygomatic_Diameter")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("Body_Analysis")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Bone_Taken")
                        .HasColumnType("text");

                    b.Property<int>("BurialLocationId")
                        .HasColumnType("integer");

                    b.Property<char?>("Burial_Adult_Child")
                        .HasColumnType("character(1)");

                    b.Property<string>("Burial_Description")
                        .HasColumnType("text");

                    b.Property<string>("Burial_Icon")
                        .HasColumnType("text");

                    b.Property<string>("Burial_Icon2")
                        .HasColumnType("text");

                    b.Property<string>("Burial_Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Burial_Preservation")
                        .HasColumnType("text");

                    b.Property<string>("Burial_Sample_Taken")
                        .HasColumnType("text");

                    b.Property<string>("Burial_Situation")
                        .HasColumnType("text");

                    b.Property<char?>("Burial_Wrapping")
                        .HasColumnType("character(1)");

                    b.Property<string>("Button_Osteoma")
                        .HasColumnType("text");

                    b.Property<int?>("C14_Calendar_Date")
                        .HasColumnType("integer");

                    b.Property<int?>("C14_Sample")
                        .HasColumnType("integer");

                    b.Property<int?>("Calibrated_95_Calendar_Date_Avg")
                        .HasColumnType("integer");

                    b.Property<int?>("Calibrated_95_Calendar_Date_Max")
                        .HasColumnType("integer");

                    b.Property<int?>("Calibrated_95_Calendar_Date_Min")
                        .HasColumnType("integer");

                    b.Property<int?>("Calibrated_95_Calendar_Date_Span")
                        .HasColumnType("integer");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<string>("Cluster")
                        .HasColumnType("text");

                    b.Property<int?>("Conventional_14C_Age_BP")
                        .HasColumnType("integer");

                    b.Property<int?>("Cranial_Sample_Number")
                        .HasColumnType("integer");

                    b.Property<string>("Cranial_Suture")
                        .HasColumnType("text");

                    b.Property<string>("Cribra_Orbitala")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Date_Excavated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Day_On_Skull")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal?>("Depth")
                        .HasColumnType("numeric");

                    b.Property<string>("Description_Of_Taken")
                        .HasColumnType("text");

                    b.Property<int?>("Dorsal_Pitting")
                        .HasColumnType("integer");

                    b.Property<decimal?>("East_To_Feet")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("East_To_Head")
                        .HasColumnType("numeric");

                    b.Property<string>("Epiphyseal_Union")
                        .HasColumnType("text");

                    b.Property<decimal?>("Estimate_Living_Stature")
                        .HasColumnType("numeric");

                    b.Property<string>("Face_Bundle")
                        .HasColumnType("text");

                    b.Property<decimal?>("Femur_Head")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Femur_Length")
                        .HasColumnType("numeric");

                    b.Property<string>("Field_Book")
                        .HasColumnType("text");

                    b.Property<int?>("Field_Book_Page_Number")
                        .HasColumnType("integer");

                    b.Property<int?>("Foci")
                        .HasColumnType("integer");

                    b.Property<string>("GE_Function_Total")
                        .HasColumnType("text");

                    b.Property<int?>("Gamous")
                        .HasColumnType("integer");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Gender_By_Measurement")
                        .HasColumnType("text");

                    b.Property<int?>("Gonian")
                        .HasColumnType("integer");

                    b.Property<string>("Goods")
                        .HasColumnType("text");

                    b.Property<string>("Hair_Color")
                        .HasColumnType("text");

                    b.Property<string>("Hair_Taken")
                        .HasColumnType("text");

                    b.Property<string>("Head_Direction")
                        .HasColumnType("text");

                    b.Property<decimal?>("Humerus_Head")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Humerus_Length")
                        .HasColumnType("numeric");

                    b.Property<string>("Initials")
                        .HasColumnType("text");

                    b.Property<string>("Initials_Of_Data_Entry_Checker")
                        .HasColumnType("text");

                    b.Property<string>("Initials_Of_Data_Entry_Expert")
                        .HasColumnType("text");

                    b.Property<decimal?>("Interorbital_Breadth")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Length")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Length_In_Centimeters")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Length_In_Meters")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Length_In_Millimeters")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Length_Of_Remains")
                        .HasColumnType("numeric");

                    b.Property<string>("Linear_Hypoplasia_Enamel")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<decimal?>("Maximum_Cranial_Breadth")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Maximum_Cranial_Length")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Maximum_Nasal_Breadth")
                        .HasColumnType("numeric");

                    b.Property<int?>("Medial_IP_Ramus")
                        .HasColumnType("integer");

                    b.Property<string>("Metopic_Suture")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Month_On_Skull")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal?>("Nasion_Prosthion")
                        .HasColumnType("numeric");

                    b.Property<int?>("Nuchal_Crest")
                        .HasColumnType("integer");

                    b.Property<int?>("Orbit_Edge")
                        .HasColumnType("integer");

                    b.Property<string>("Osteology_Unknown_Comment")
                        .HasColumnType("text");

                    b.Property<string>("Osteophytosis")
                        .HasColumnType("text");

                    b.Property<int?>("Parietal_Bossing")
                        .HasColumnType("integer");

                    b.Property<string>("Pathology_Anomalies")
                        .HasColumnType("text");

                    b.Property<string>("Porotic_Hyperostosis")
                        .HasColumnType("text");

                    b.Property<string>("Porotic_Hyperostosis_Locations")
                        .HasColumnType("text");

                    b.Property<string>("Postcrania_At_Magazine")
                        .HasColumnType("text");

                    b.Property<string>("Postcrania_Trauma")
                        .HasColumnType("text");

                    b.Property<int?>("Preaur_Sulcus")
                        .HasColumnType("integer");

                    b.Property<string>("Preservation_Index")
                        .HasColumnType("text");

                    b.Property<string>("Preservation_State")
                        .HasColumnType("text");

                    b.Property<string>("Previously_Sampled")
                        .HasColumnType("text");

                    b.Property<int?>("Pubic_Bone")
                        .HasColumnType("integer");

                    b.Property<string>("Pubic_Symphysis")
                        .HasColumnType("text");

                    b.Property<string>("Questions")
                        .HasColumnType("text");

                    b.Property<int?>("Rack")
                        .HasColumnType("integer");

                    b.Property<string>("Rack_And_Shelf")
                        .HasColumnType("text");

                    b.Property<int?>("Robust")
                        .HasColumnType("integer");

                    b.Property<char?>("Sample_Collected")
                        .HasColumnType("character(1)");

                    b.Property<int?>("Sciatic_Notch")
                        .HasColumnType("integer");

                    b.Property<char?>("Sex")
                        .HasColumnType("character(1)");

                    b.Property<string>("Sex_Method")
                        .HasColumnType("text");

                    b.Property<string>("Skull_At_Magazine")
                        .HasColumnType("text");

                    b.Property<string>("Skull_Trauma")
                        .HasColumnType("text");

                    b.Property<string>("Soft_Tissue_Taken")
                        .HasColumnType("text");

                    b.Property<decimal?>("South_To_Feet")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("South_To_Head")
                        .HasColumnType("numeric");

                    b.Property<int?>("Subpubic_Angle")
                        .HasColumnType("integer");

                    b.Property<int?>("Supraorbital_Ridges")
                        .HasColumnType("integer");

                    b.Property<string>("Temporal_Mandibular_Joint_Osteoarthritis")
                        .HasColumnType("text");

                    b.Property<string>("Textile_Taken")
                        .HasColumnType("text");

                    b.Property<decimal?>("Tibia_Length")
                        .HasColumnType("numeric");

                    b.Property<int?>("Tomb")
                        .HasColumnType("integer");

                    b.Property<string>("Tooth_Attrition")
                        .HasColumnType("text");

                    b.Property<string>("Tooth_Eruption")
                        .HasColumnType("text");

                    b.Property<string>("Tooth_Taken")
                        .HasColumnType("text");

                    b.Property<int?>("Tube_Number")
                        .HasColumnType("integer");

                    b.Property<int?>("Ventral_Arc")
                        .HasColumnType("integer");

                    b.Property<decimal?>("West_To_Feet")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("West_To_Head")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("Year_On_Skull")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("Zygomatic_Crest")
                        .HasColumnType("integer");

                    b.HasKey("BurialID");

                    b.HasIndex("BurialLocationId");

                    b.ToTable("Burials");
                });

            modelBuilder.Entity("BurialSite.Models.BurialLocation", b =>
                {
                    b.Property<int>("BurialLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Area")
                        .HasColumnType("text");

                    b.Property<string>("Dig_Site_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("E_W_Grid_Site_Lower")
                        .HasColumnType("integer");

                    b.Property<int?>("E_W_Grid_Site_Upper")
                        .HasColumnType("integer");

                    b.Property<int?>("N_S_Grid_Site_Lower")
                        .HasColumnType("integer");

                    b.Property<int?>("N_S_Grid_Site_Upper")
                        .HasColumnType("integer");

                    b.HasKey("BurialLocationId");

                    b.ToTable("BurialLocations");
                });

            modelBuilder.Entity("BurialSite.Models.FileUrl", b =>
                {
                    b.Property<int>("FileUrlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("FileUrlId");

                    b.ToTable("FileUrls");
                });

            modelBuilder.Entity("BurialSite.Models.Notes", b =>
                {
                    b.Property<int>("NotesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("BurialID")
                        .HasColumnType("bigint");

                    b.Property<int?>("BurialID1")
                        .HasColumnType("integer");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("NotesId");

                    b.HasIndex("BurialID1");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("BurialSite.Models.OneToOneField", b =>
                {
                    b.Property<int>("OneToOneFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("OneToOneFieldId");

                    b.ToTable("OneToOneFields");
                });

            modelBuilder.Entity("BurialSite.Models.OneToOneValue", b =>
                {
                    b.Property<int>("OneToneValueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BurialId")
                        .HasColumnType("integer");

                    b.Property<int>("OneToOneFieldId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("OneToneValueId");

                    b.HasIndex("BurialId");

                    b.HasIndex("OneToOneFieldId");

                    b.ToTable("OneToOneValues");
                });

            modelBuilder.Entity("BurialSite.Models.ResearchUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BurialSite.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("BurialSite.Models.TestEnt", b =>
                {
                    b.Property<int>("TestEntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("test_string")
                        .HasColumnType("text");

                    b.HasKey("TestEntId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("BurialSite.Models.YearsExcavatedFrom", b =>
                {
                    b.Property<int>("YearsExcavatedFromId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Year")
                        .HasColumnType("text");

                    b.HasKey("YearsExcavatedFromId");

                    b.ToTable("YearsExcavatedFrom");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BurialFileUrl", b =>
                {
                    b.HasOne("BurialSite.Models.Burial", null)
                        .WithMany()
                        .HasForeignKey("BurialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurialSite.Models.FileUrl", null)
                        .WithMany()
                        .HasForeignKey("FileUrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BurialLocationYearsExcavatedFrom", b =>
                {
                    b.HasOne("BurialSite.Models.BurialLocation", null)
                        .WithMany()
                        .HasForeignKey("BurialLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurialSite.Models.YearsExcavatedFrom", null)
                        .WithMany()
                        .HasForeignKey("YearsExcavatedFromsYearsExcavatedFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BurialSite.Models.Burial", b =>
                {
                    b.HasOne("BurialSite.Models.BurialLocation", "BurialLocation")
                        .WithMany("Burials")
                        .HasForeignKey("BurialLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BurialLocation");
                });

            modelBuilder.Entity("BurialSite.Models.Notes", b =>
                {
                    b.HasOne("BurialSite.Models.Burial", "Burial")
                        .WithMany("Notes")
                        .HasForeignKey("BurialID1");

                    b.Navigation("Burial");
                });

            modelBuilder.Entity("BurialSite.Models.OneToOneValue", b =>
                {
                    b.HasOne("BurialSite.Models.Burial", "Burial")
                        .WithMany("OneToOneValues")
                        .HasForeignKey("BurialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurialSite.Models.OneToOneField", "OneToOneField")
                        .WithMany("OneToOneValue")
                        .HasForeignKey("OneToOneFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burial");

                    b.Navigation("OneToOneField");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("BurialSite.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BurialSite.Models.ResearchUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BurialSite.Models.ResearchUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("BurialSite.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurialSite.Models.ResearchUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BurialSite.Models.ResearchUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BurialSite.Models.Burial", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("OneToOneValues");
                });

            modelBuilder.Entity("BurialSite.Models.BurialLocation", b =>
                {
                    b.Navigation("Burials");
                });

            modelBuilder.Entity("BurialSite.Models.OneToOneField", b =>
                {
                    b.Navigation("OneToOneValue");
                });
#pragma warning restore 612, 618
        }
    }
}
