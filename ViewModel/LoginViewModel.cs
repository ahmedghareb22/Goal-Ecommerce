namespace Goal.ViewModel
{
    [Keyless]
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }


        public bool RememberMe { get; set; }
    }
}
