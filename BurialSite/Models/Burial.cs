using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
#nullable enable

namespace BurialSite.Models
{
    // Burial Model; comments are associated with the field above them
    public class Burial
    {
        [Key]
        [Required]
        public int BurialID { get; set; }

        public int BurLocID { get; set; }
        // foreign key
        public int? Gamous { get; set; } 
        [Required]
        public string Burial_Number { get; set; }

        public decimal? West_To_Head { get; set; }

        public decimal? West_To_Feet { get; set; }

        public decimal? East_To_Head { get; set; }

        public decimal? East_To_Feet { get; set; }

        public decimal? South_To_Head { get; set; }

        public decimal? South_To_Feet { get; set; }

        public decimal? Depth { get; set; }

        public string? Preservation_State { get; set; }

        public string? Burial_Icon { get; set; }

        public string? Burial_Icon2 { get; set; }

        public string? Sex_Method { get; set; }

        public char? Sex { get; set; }

        public decimal? GE_Function_Total { get; set; }

        public char? Gender { get; set; }

        public char? Gender_By_Measurement { get; set; }

        public decimal? Age_At_Death { get; set; }

        public string? Age_Method { get; set; }

        public string? Hair_Color { get; set; }

        public bool? Sample_Collected { get; set; }

        public string? Burial_Situation { get; set; }

        public decimal? Length_Of_Remains { get; set; }

        public int? Cranial_Sample_Number { get; set; }

        public string? Basilar_Suture { get; set; }
        // True = Closed, False = Open

        [Range(0, 3)]
        public int? Ventral_Arc { get; set; }
        // Range of 0-3
        [Range(0, 3)]
        public int? Subpubic_Angle { get; set; }
        // Range of 0-3
        [Range(0, 3)]
        public int? Sciatic_Notch { get; set; }
        // Range of 0-3
        [Range(0, 3)]
        public int? Pubic_Bone { get; set; }
        // Range of 0-3
        [Range(0, 3)]
        public int? Preaur_Sulcus { get; set; }
        // Range of 0-3
        [Range(0, 3)]
        public int? Medial_IP_Ramus { get; set; }
        // Range of 0-3
        [Range(0, 3)]
        public int? Dorsal_Pitting { get; set; }
        // Range of 0-3
        public decimal? Femur_Head { get; set; }

        public decimal? Humerus_Head { get; set; }

        public string? Osteophytosis { get; set; }

        public string? Pubic_Symphysis { get; set; }

        public decimal? Femur_Length { get; set; }

        public decimal? Humerus_Length { get; set; }

        public decimal? Tibia_Length { get; set; }

        public int? Robust { get; set; }
        // Range of 0-3
        public int? Supraorbital_Ridges { get; set; }
        // Range of 0-3
        public int? Orbit_Edge { get; set; }
        // Range of 0-3
        public int? Parietal_Bossing { get; set; }
        // Range of 0-3
        public int? Gonian { get; set; }
        // Range of 0-3
        public int? Nuchal_Crest { get; set; }
        // Range of 0-3
        public int? Zygomatic_Crest { get; set; }
        // Range of 0-3
        public string? Cranial_Suture { get; set; }
        // Closed, Mostly Closed, or Closed

        public decimal? Maximum_Cranial_Length { get; set; }

        public decimal? Maximum_Cranial_Breadth { get; set; }

        public decimal? Basion_Bregma_Height { get; set; }

        public decimal? Basion_Nasion { get; set; }

        public decimal? Basion_Prosthion_Length { get; set; }

        public decimal? Bizygomatic_Diameter { get; set; }

        public decimal? Nasion_Prosthion { get; set; }

        public decimal? Maximum_Nasal_Breadth { get; set; }

        public decimal? Interorbital_Breadth { get; set; }

        public string? Artifacts_Description { get; set; }

        public int? Preservation_Index { get; set; }
        // Romman Numerals

        public bool? Hair_Taken { get; set; }

        public bool? Soft_Tissue_Taken { get; set; }

        public bool? Bone_Taken { get; set; }

        public bool? Tooth_Taken { get; set; }

        public bool? Textile_Taken { get; set; }

        public string? Description_Of_Taken { get; set; }

        public bool? Artifact_Found { get; set; }

        public decimal? Estimate_Living_Stature { get; set; }
        public int? Tooth_Attrition { get; set; }
        // Roman Numerals
        public string? Tooth_Eruption { get; set; }
        public string? Pathology_Anomalies { get; set; }
        public string? Epiphyseal_Union { get; set; }
        public DateTime? Date_Excavated { get; set; }
        // specifc day, month, and year
        public bool? Head_Direction { get; set; }
        // True = West, False = East
        public string? Area { get; set; }
        public string? Artifact_Description { get; set; }
        public bool? Artifacts_Found { get; set; }
        public DateTime? Year_On_Skull { get; set; }
        // datetime.year
        public DateTime? Month_On_Skull { get; set; }
        // datetime.month
        public DateTime? Day_On_Skull { get; set; }
        // DateTime.day
        public string? Field_Book { get; set; }
        public int? Field_Book_Page_Number { get; set; }
        public string? Initials_Of_Data_Entry_Expert { get; set; }
        public string? Initials_Of_Data_Entry_Checker { get; set; }
        public bool? BYU_Sample { get; set; }
        public DateTime? Body_Analysis { get; set; }
        // datetime.year
        public bool? Skull_At_Magazine { get; set; }
        public bool? Postcrania_At_Magazine { get; set; }
        public string? Age { get; set; }
        // This includes words
        public string? Rack_And_Shelf { get; set; }
        public bool? Skull_Trauma { get; set; }
        public bool? Postcrania_Trauma { get; set; }
        public bool? Cribra_Orbitala { get; set; }
        public string? Porotic_Hyperostosis { get; set; }
        // would be bool but also includes 'BM'
        public string? Porotic_Hyperostosis_Locations { get; set; }
        public bool? Metopic_Suture { get; set; }
        public bool? Button_Osteoma { get; set; }
        public string? Osteology_Unknown_Comment { get; set; }
        public bool? Temporal_Mandibular_Joint_Osteoarthritis { get; set; }
        public bool? Linear_Hypoplasia_Enamel { get; set; }
        public int? Tomb { get; set; }
        public decimal? Length { get; set; }
        public string? Burial_Preservation { get; set; }
        public char? Burial_Wrapping { get; set; }
        //just uses B,H,S,U,W 
        public char? Burial_Adult_Child { get; set; }
        // uses A, C, U
        public char? Age_Code { get; set; }
        // uses A,C,I,N,U
        public bool? Burial_Sample_Taken { get; set; }
        public decimal? Length_In_Meters { get; set; }
        public decimal? Length_In_Centimeters { get; set; }
        public decimal? Length_In_Millimeters { get; set; }
        public string? Goods { get; set; }
        public string? Cluster { get; set; }
        public bool? Face_Bundle { get; set; }
        public int? Rank { get; set; }
        public int? Tube_Number { get; set; }
        public string? Burial_Description { get; set; }
        public int? Foci { get; set; }
        //only goes from 1-5
        public int? C14_Sample { get; set; }
        public string? Location { get; set; }
        public string? Questions { get; set; }
        public int? Conventional_14C_Age_BP { get; set; }
        public int? C14_Calendar_Date { get; set; }
        // might be negative, datetime.year
        public int? Calibrated_95_Calendar_Date_Max { get; set; }
        // can be negative, datetime.year
        public int? Calibrated_95_Calendar_Date_Min { get; set; }
        // can be negative, datetime.year        
        public int? Calibrated_95_Calendar_Date_Span { get; set; }
        // datetime.year
        public int? Calibrated_95_Calendar_Date_Avg { get; set; }
        // you will have to include BC in it, datetime.year
        public string? Category { get; set; }
        // options are Deepest East, Deepest West, Hill B, One Meter Deep
        public int? Bag { get; set; }
        public DateTime? Date { get; set; }
        // this will be a year only
        public bool? Previously_Sampled { get; set; }
        public string? Initials { get; set; }
        // options are MBB, GM, AWA, and CIE for now


        public long BurialLocationId { get; set; }

        public virtual BurialLocation BurialLocation { get; set; }

        public virtual ICollection<OneToOneValue> OneToOneValues { get; set; }

        public virtual ICollection<Notes> Notes { get; set; }

        public virtual ICollection<FileUrl> FileUrl { get; set; }
    }
}
