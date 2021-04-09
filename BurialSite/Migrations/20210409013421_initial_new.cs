﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BurialSite.Migrations
{
    public partial class initial_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BurialLocations",
                columns: table => new
                {
                    BurLocID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dig_Site_Name = table.Column<string>(type: "text", nullable: false),
                    N_S_Grid_Site_Upper = table.Column<int>(type: "integer", nullable: true),
                    N_S_Grid_Site_Lower = table.Column<int>(type: "integer", nullable: true),
                    E_W_Grid_Site_Upper = table.Column<int>(type: "integer", nullable: true),
                    E_W_Grid_Site_Lower = table.Column<int>(type: "integer", nullable: true),
                    Area = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurialLocations", x => x.BurLocID);
                });

            migrationBuilder.CreateTable(
                name: "FileUrls",
                columns: table => new
                {
                    FileUrlId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUrls", x => x.FileUrlId);
                });

            migrationBuilder.CreateTable(
                name: "OneToOneFields",
                columns: table => new
                {
                    OneToOneFieldId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneToOneFields", x => x.OneToOneFieldId);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestEntId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    test_string = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestEntId);
                });

            migrationBuilder.CreateTable(
                name: "YearsExcavatedFrom",
                columns: table => new
                {
                    YearsExcavatedFromId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearsExcavatedFrom", x => x.YearsExcavatedFromId);
                });

            migrationBuilder.CreateTable(
                name: "Burials",
                columns: table => new
                {
                    BurialID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BurLocID = table.Column<int>(type: "integer", nullable: false),
                    Gamous = table.Column<int>(type: "integer", nullable: true),
                    Burial_Number = table.Column<int>(type: "integer", nullable: false),
                    West_To_Head = table.Column<decimal>(type: "numeric", nullable: true),
                    West_To_Feet = table.Column<decimal>(type: "numeric", nullable: true),
                    East_To_Head = table.Column<decimal>(type: "numeric", nullable: true),
                    East_To_Feet = table.Column<decimal>(type: "numeric", nullable: true),
                    South_To_Head = table.Column<decimal>(type: "numeric", nullable: true),
                    South_To_Feet = table.Column<decimal>(type: "numeric", nullable: true),
                    Depth = table.Column<decimal>(type: "numeric", nullable: true),
                    Preservation_State = table.Column<string>(type: "text", nullable: true),
                    Burial_Icon = table.Column<string>(type: "text", nullable: true),
                    Burial_Icon2 = table.Column<string>(type: "text", nullable: true),
                    Sex_Method = table.Column<string>(type: "text", nullable: true),
                    Sex = table.Column<char>(type: "character(1)", nullable: true),
                    GE_Function_Total = table.Column<decimal>(type: "numeric", nullable: true),
                    Gender = table.Column<char>(type: "character(1)", nullable: true),
                    Gender_By_Measurement = table.Column<char>(type: "character(1)", nullable: true),
                    Age_At_Death = table.Column<decimal>(type: "numeric", nullable: true),
                    Age_Method = table.Column<string>(type: "text", nullable: true),
                    Hair_Color = table.Column<string>(type: "text", nullable: true),
                    Sample_Collected = table.Column<bool>(type: "boolean", nullable: true),
                    Burial_Situation = table.Column<string>(type: "text", nullable: true),
                    Length_Of_Remains = table.Column<decimal>(type: "numeric", nullable: true),
                    Cranial_Sample_Number = table.Column<int>(type: "integer", nullable: true),
                    Basilar_Suture = table.Column<bool>(type: "boolean", nullable: true),
                    Ventral_Arc = table.Column<int>(type: "integer", nullable: true),
                    Subpubic_Angle = table.Column<int>(type: "integer", nullable: true),
                    Sciatic_Notch = table.Column<int>(type: "integer", nullable: true),
                    Pubic_Bone = table.Column<int>(type: "integer", nullable: true),
                    Preaur_Sulcus = table.Column<int>(type: "integer", nullable: true),
                    Medial_IP_Ramus = table.Column<int>(type: "integer", nullable: true),
                    Dorsal_Pitting = table.Column<int>(type: "integer", nullable: true),
                    Femur_Head = table.Column<decimal>(type: "numeric", nullable: true),
                    Humerus_Head = table.Column<decimal>(type: "numeric", nullable: true),
                    Osteophytosis = table.Column<string>(type: "text", nullable: true),
                    Pubic_Symphysis = table.Column<string>(type: "text", nullable: true),
                    Femur_Length = table.Column<decimal>(type: "numeric", nullable: true),
                    Humerus_Length = table.Column<decimal>(type: "numeric", nullable: true),
                    Tibia_Length = table.Column<decimal>(type: "numeric", nullable: true),
                    Robust = table.Column<int>(type: "integer", nullable: true),
                    Supraorbital_Ridges = table.Column<int>(type: "integer", nullable: true),
                    Orbit_Edge = table.Column<int>(type: "integer", nullable: true),
                    Parietal_Bossing = table.Column<int>(type: "integer", nullable: true),
                    Gonian = table.Column<int>(type: "integer", nullable: true),
                    Nuchal_Crest = table.Column<int>(type: "integer", nullable: true),
                    Zygomatic_Crest = table.Column<int>(type: "integer", nullable: true),
                    Cranial_Suture = table.Column<string>(type: "text", nullable: true),
                    Maximum_Cranial_Length = table.Column<decimal>(type: "numeric", nullable: true),
                    Maximum_Cranial_Breadth = table.Column<decimal>(type: "numeric", nullable: true),
                    Basion_Bregma_Height = table.Column<decimal>(type: "numeric", nullable: true),
                    Basion_Nasion = table.Column<decimal>(type: "numeric", nullable: true),
                    Basion_Prosthion_Length = table.Column<decimal>(type: "numeric", nullable: true),
                    Bizygomatic_Diameter = table.Column<decimal>(type: "numeric", nullable: true),
                    Nasion_Prosthion = table.Column<decimal>(type: "numeric", nullable: true),
                    Maximum_Nasal_Breadth = table.Column<decimal>(type: "numeric", nullable: true),
                    Interorbital_Breadth = table.Column<decimal>(type: "numeric", nullable: true),
                    Artifacts_Description = table.Column<string>(type: "text", nullable: true),
                    Preservation_Index = table.Column<int>(type: "integer", nullable: true),
                    Hair_Taken = table.Column<bool>(type: "boolean", nullable: true),
                    Soft_Tissue_Taken = table.Column<bool>(type: "boolean", nullable: true),
                    Bone_Taken = table.Column<bool>(type: "boolean", nullable: true),
                    Tooth_Taken = table.Column<bool>(type: "boolean", nullable: true),
                    Textile_Taken = table.Column<bool>(type: "boolean", nullable: true),
                    Description_Of_Taken = table.Column<string>(type: "text", nullable: true),
                    Artifact_Found = table.Column<bool>(type: "boolean", nullable: true),
                    Estimate_Living_Stature = table.Column<decimal>(type: "numeric", nullable: true),
                    Tooth_Attrition = table.Column<int>(type: "integer", nullable: true),
                    Tooth_Eruption = table.Column<string>(type: "text", nullable: true),
                    Pathology_Anomalies = table.Column<string>(type: "text", nullable: true),
                    Epiphyseal_Union = table.Column<string>(type: "text", nullable: true),
                    Date_Excavated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Head_Direction = table.Column<bool>(type: "boolean", nullable: true),
                    Area = table.Column<string>(type: "text", nullable: true),
                    Artifact_Description = table.Column<string>(type: "text", nullable: true),
                    Artifacts_Found = table.Column<bool>(type: "boolean", nullable: true),
                    Year_On_Skull = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Month_On_Skull = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Day_On_Skull = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Field_Book = table.Column<string>(type: "text", nullable: true),
                    Field_Book_Page_Number = table.Column<int>(type: "integer", nullable: true),
                    Initials_Of_Data_Entry_Expert = table.Column<string>(type: "text", nullable: true),
                    Initials_Of_Data_Entry_Checker = table.Column<string>(type: "text", nullable: true),
                    BYU_Sample = table.Column<bool>(type: "boolean", nullable: true),
                    Body_Analysis = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Skull_At_Magazine = table.Column<bool>(type: "boolean", nullable: true),
                    Postcrania_At_Magazine = table.Column<bool>(type: "boolean", nullable: true),
                    Age = table.Column<string>(type: "text", nullable: true),
                    Rack_And_Shelf = table.Column<string>(type: "text", nullable: true),
                    Skull_Trauma = table.Column<bool>(type: "boolean", nullable: true),
                    Postcrania_Trauma = table.Column<bool>(type: "boolean", nullable: true),
                    Cribra_Orbitala = table.Column<bool>(type: "boolean", nullable: true),
                    Porotic_Hyperostosis = table.Column<string>(type: "text", nullable: true),
                    Porotic_Hyperostosis_Locations = table.Column<string>(type: "text", nullable: true),
                    Metopic_Suture = table.Column<bool>(type: "boolean", nullable: true),
                    Button_Osteoma = table.Column<bool>(type: "boolean", nullable: true),
                    Osteology_Unknown_Comment = table.Column<string>(type: "text", nullable: true),
                    Temporal_Mandibular_Joint_Osteoarthritis = table.Column<bool>(type: "boolean", nullable: true),
                    Linear_Hypoplasia_Enamel = table.Column<bool>(type: "boolean", nullable: true),
                    Tomb = table.Column<int>(type: "integer", nullable: true),
                    Length = table.Column<decimal>(type: "numeric", nullable: true),
                    Burial_Preservation = table.Column<string>(type: "text", nullable: true),
                    Burial_Wrapping = table.Column<char>(type: "character(1)", nullable: true),
                    Burial_Adult_Child = table.Column<char>(type: "character(1)", nullable: true),
                    Age_Code = table.Column<char>(type: "character(1)", nullable: true),
                    Burial_Sample_Taken = table.Column<bool>(type: "boolean", nullable: true),
                    Length_In_Meters = table.Column<decimal>(type: "numeric", nullable: true),
                    Length_In_Centimeters = table.Column<decimal>(type: "numeric", nullable: true),
                    Length_In_Millimeters = table.Column<decimal>(type: "numeric", nullable: true),
                    Goods = table.Column<string>(type: "text", nullable: true),
                    Cluster = table.Column<string>(type: "text", nullable: true),
                    Face_Bundle = table.Column<bool>(type: "boolean", nullable: true),
                    Rank = table.Column<int>(type: "integer", nullable: true),
                    Tube_Number = table.Column<int>(type: "integer", nullable: true),
                    Burial_Description = table.Column<string>(type: "text", nullable: true),
                    Foci = table.Column<int>(type: "integer", nullable: true),
                    C14_Sample = table.Column<int>(type: "integer", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Questions = table.Column<string>(type: "text", nullable: true),
                    Conventional_14C_Age_BP = table.Column<int>(type: "integer", nullable: true),
                    C14_Calendar_Date = table.Column<int>(type: "integer", nullable: true),
                    Calibrated_95_Calendar_Date_Max = table.Column<int>(type: "integer", nullable: true),
                    Calibrated_95_Calendar_Date_Min = table.Column<int>(type: "integer", nullable: true),
                    Calibrated_95_Calendar_Date_Span = table.Column<int>(type: "integer", nullable: true),
                    Calibrated_95_Calendar_Date_Avg = table.Column<int>(type: "integer", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Bag = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Previously_Sampled = table.Column<bool>(type: "boolean", nullable: true),
                    Initials = table.Column<string>(type: "text", nullable: true),
                    BurialLocationId = table.Column<long>(type: "bigint", nullable: false),
                    BurialLocationBurLocID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burials", x => x.BurialID);
                    table.ForeignKey(
                        name: "FK_Burials_BurialLocations_BurialLocationBurLocID",
                        column: x => x.BurialLocationBurLocID,
                        principalTable: "BurialLocations",
                        principalColumn: "BurLocID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BurialLocationYearsExcavatedFrom",
                columns: table => new
                {
                    BurialLocationBurLocID = table.Column<int>(type: "integer", nullable: false),
                    YearsExcavatedFromsYearsExcavatedFromId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurialLocationYearsExcavatedFrom", x => new { x.BurialLocationBurLocID, x.YearsExcavatedFromsYearsExcavatedFromId });
                    table.ForeignKey(
                        name: "FK_BurialLocationYearsExcavatedFrom_BurialLocations_BurialLoca~",
                        column: x => x.BurialLocationBurLocID,
                        principalTable: "BurialLocations",
                        principalColumn: "BurLocID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BurialLocationYearsExcavatedFrom_YearsExcavatedFrom_YearsEx~",
                        column: x => x.YearsExcavatedFromsYearsExcavatedFromId,
                        principalTable: "YearsExcavatedFrom",
                        principalColumn: "YearsExcavatedFromId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BurialFileUrl",
                columns: table => new
                {
                    BurialID = table.Column<int>(type: "integer", nullable: false),
                    FileUrlId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurialFileUrl", x => new { x.BurialID, x.FileUrlId });
                    table.ForeignKey(
                        name: "FK_BurialFileUrl_Burials_BurialID",
                        column: x => x.BurialID,
                        principalTable: "Burials",
                        principalColumn: "BurialID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BurialFileUrl_FileUrls_FileUrlId",
                        column: x => x.FileUrlId,
                        principalTable: "FileUrls",
                        principalColumn: "FileUrlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NotesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "text", nullable: true),
                    BurialID = table.Column<long>(type: "bigint", nullable: false),
                    BurialID1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NotesId);
                    table.ForeignKey(
                        name: "FK_Notes_Burials_BurialID1",
                        column: x => x.BurialID1,
                        principalTable: "Burials",
                        principalColumn: "BurialID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OneToOneValues",
                columns: table => new
                {
                    OneToneValueId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OneToOneFieldId = table.Column<int>(type: "integer", nullable: false),
                    BurialId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneToOneValues", x => x.OneToneValueId);
                    table.ForeignKey(
                        name: "FK_OneToOneValues_Burials_BurialId",
                        column: x => x.BurialId,
                        principalTable: "Burials",
                        principalColumn: "BurialID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OneToOneValues_OneToOneFields_OneToOneFieldId",
                        column: x => x.OneToOneFieldId,
                        principalTable: "OneToOneFields",
                        principalColumn: "OneToOneFieldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BurialFileUrl_FileUrlId",
                table: "BurialFileUrl",
                column: "FileUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_BurialLocationYearsExcavatedFrom_YearsExcavatedFromsYearsEx~",
                table: "BurialLocationYearsExcavatedFrom",
                column: "YearsExcavatedFromsYearsExcavatedFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Burials_BurialLocationBurLocID",
                table: "Burials",
                column: "BurialLocationBurLocID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_BurialID1",
                table: "Notes",
                column: "BurialID1");

            migrationBuilder.CreateIndex(
                name: "IX_OneToOneValues_BurialId",
                table: "OneToOneValues",
                column: "BurialId");

            migrationBuilder.CreateIndex(
                name: "IX_OneToOneValues_OneToOneFieldId",
                table: "OneToOneValues",
                column: "OneToOneFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BurialFileUrl");

            migrationBuilder.DropTable(
                name: "BurialLocationYearsExcavatedFrom");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "OneToOneValues");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "FileUrls");

            migrationBuilder.DropTable(
                name: "YearsExcavatedFrom");

            migrationBuilder.DropTable(
                name: "Burials");

            migrationBuilder.DropTable(
                name: "OneToOneFields");

            migrationBuilder.DropTable(
                name: "BurialLocations");
        }
    }
}
