namespace Shop
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// DTO used to authenticate user
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// User name
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long. And not more then {1}", MinimumLength = 3)]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}