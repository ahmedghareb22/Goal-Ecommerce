namespace Goal.ViewModel
{
    [Keyless]
    public class RegisterViewModel
    {

        [Display(Name= "Birth Date")]
        [Required]
        public DateOnly BirthDate { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name="Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        [Display(Name = "Password Confirmation")]
        public string PasswordConfirmation { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string? FullName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string Phone {  get; set; }

        [Required]
        [NotMapped]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Personal Image")]
        public IFormFile Photo {  get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string Adress { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string city { get; set; }

    }
}
