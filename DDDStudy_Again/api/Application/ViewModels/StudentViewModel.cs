using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    /// <summary>
    /// 子领域 Student 的视图模型
    /// </summary>
    public class StudentViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name Field is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email Field is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The BirthDate Field is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formater invalided")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The Phone Field is Required")]
        [MaxLength(11)]
        [MinLength(11)]
        [DisplayName("Phone")]
        public string Phone { get; private set; }

        [Required(ErrorMessage = "The Province Field is Required")]
        [DisplayName("Province")]
        public string Province { get; set; }
        
        public string City { get; set; }
        
        public string County { get; set; }

        public string Street { get; set; }
    }
}
