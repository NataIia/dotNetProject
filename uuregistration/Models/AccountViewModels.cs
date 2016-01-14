using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using uuregistration.Services;

namespace uuregistration.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        // New Fields added to extend Application User class:

        [Display(Name = "Voornaam")]
        public string Voornaam { get; set; }

        [Display(Name = "Achternaam")]
        public string Achternaam { get; set; }

        public string Login { get; set; }

        // Return a pre-poulated instance of AppliationUser:
        public ApplicationUser GetUser()
        {
            var user = new ApplicationUser()
            {
                Voornaam = this.Voornaam,
                Achternaam = this.Achternaam,
                Email = this.Email,
                Login = this.Login,
                UserName = this.Login
            };
            return user;
        }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    //=====================added====================
    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage =
            "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage =
            "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    //======added=============
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            var Db = new ApplicationDbContext();
            this.Users = Db.Users.ToList<ApplicationUser>();
            this.Roles = Db.Roles.ToList<IdentityRole>();
            DepartementenService ds = new DepartementenService();
            Departments = ds.GetAllDepartementen();
        }

        // Allow Initialization with an instance of ApplicationUser:
        public EditUserViewModel(ApplicationUser user) : this()
        {
            this.Voornaam = user.Voornaam;
            this.Achternaam = user.Achternaam;
            this.Email = user.Email;
            this.Login = user.Login;
            this.User = user;
            this.Departement = user.Departement;
        }

        [Display(Name = "Voornaam")]
        public string Voornaam { get; set; }

        [Display(Name = "Achternaam")]
        public string Achternaam { get; set; }
        public string Login { get; set; }

        [Required]
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public ApplicationUser GetUser()
        {
            Departement dep = Departments.First(d => d.departementCode == Departement.departementCode);
            var user = new ApplicationUser()
            {
                Login = this.Login,
                Voornaam = this.Voornaam,
                Achternaam = this.Achternaam,
                Email = this.Email,
                UserName = this.Login,
 //               Departement = dep
            };
            user.DepartementId = dep.DepartementId;
            return user;
        }
        public ApplicationUser User { get; set; }
        public Departement Departement { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<Departement> Departments { get; set; }
        public ICollection<IdentityRole> Roles { get; set; }
    }


    public class SelectUserRolesViewModel
    {
        public SelectUserRolesViewModel()
        {
            this.Roles = new List<SelectRoleEditorViewModel>();
        }


        // Enable initialization with an instance of ApplicationUser:
        public SelectUserRolesViewModel(ApplicationUser user) : this()
        {
            this.Voornaam = user.Voornaam;
            this.Achternaam = user.Achternaam;
            this.Login = user.Login;

            var Db = new ApplicationDbContext();

            // Add all available roles to the list of EditorViewModels:
            var allRoles = Db.Roles;
            foreach (var role in allRoles)
            {
                // An EditorViewModel will be used by Editor Template:
                var rvm = new SelectRoleEditorViewModel(role);
                this.Roles.Add(rvm);
            }

            // Set the Selected property to true for those roles for 
            // which the current user is a member:

               foreach (var userRole in user.Roles)
               {
                   var checkUserRole =
                       this.Roles.Find(r => r.Id == userRole.RoleId);
//                       this.Roles.Find(r => r.RoleName == userRole.Role.Name);
                           checkUserRole.Selected = true;
               }
        }

        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Login { get; set; }
        public List<SelectRoleEditorViewModel> Roles { get; set; }
    }

    // Used to display a single role with a checkbox, within a list structure:
    public class SelectRoleEditorViewModel
    {
        public SelectRoleEditorViewModel() { }
        public SelectRoleEditorViewModel(IdentityRole role)
        {
            this.RoleName = role.Name;
            this.Id = role.Id;
        }

        public bool Selected { get; set; }

        [Required]
        public string RoleName { get; set; }

        public string Id { get; set; }
    }
}
