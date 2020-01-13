using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace VegaModel
{
    public partial class VegetableModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Id { get; set; }

        [Column("Vegetable_Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50)]
        [Required(ErrorMessage = "Vegetable Required")]
        //[Remote("IsVegNameExists", "Vegetable", HttpMethod = "POST")]
        public string Vegetable { get; set; }

        [Column("Vegetable_Arhat")]
        [Range(0, 100)]
        [DisplayFormat(DataFormatString = @"{0:#\%}")]
       public decimal Arhat { get; set; }

        [Column("Vegetable_Laga")]
        [Range(0, 100)]
        [DataType(DataType.Currency)]
        public decimal Laga { get; set; }

        [Column("Vegetable_RDF")]
        [Range(0, 100)]
        [DisplayFormat(DataFormatString = @"{0:#\%}")]
        public decimal RDF { get; set; }

        [Column("Vegetable_Market_Fee")]

        [Range(0, 100)]
        [DisplayFormat(DataFormatString = @"{0:#\%}")]
        public decimal MDF { get; set; }

        [Column("Vegetable_Bardana_Fee")]

        [Range(0, 100)]
        [DataType(DataType.Currency)]
        public decimal? Bardana { get; set; }

        [Column("Vegetable_Crate_Option")]
        public bool Crate { get; set; }
    }
}
