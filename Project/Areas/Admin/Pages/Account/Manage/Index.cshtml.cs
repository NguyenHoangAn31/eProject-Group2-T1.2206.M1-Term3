// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Services.IRepository;

namespace Project.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _env = env;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }
        public string DisplayDepartment { get; set; }
        public string PathImage { get; set; }




        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            public string Department_Id { get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> DepartmentList { get; set; }
            public string Employeecode { get; set; }
            public string Fullname { get; set; }
            public string Image { get; set; }
            [DataType(DataType.Date)]
            public DateTime? Birthday { get; set; }
            public string Ward { get; set; }
            public string District { get; set; }
            public string Province { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            AppUser a = (await _unitOfWork.AppUser.GetAll("Department")).SingleOrDefault(u => u.Id == user.Id);
            Username = userName;
            DisplayDepartment = a.Department_Id!=null?a.Department.Name:null;
            PathImage = a.Image;

             Input = new InputModel
            {
                Department_Id = a.Department_Id,
                PhoneNumber = a.PhoneNumber,
                Employeecode = a.Employeecode,
                Fullname = a.Fullname,
                Birthday = a.Birthday,
                Ward = a.Ward,
                District = a.District,
                Province = a.Province,
                DepartmentList = (await _unitOfWork.Department.GetAll()).Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Department_Id
                })
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile? file)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                StatusMessage = "Error Unexpected error when trying to set phone number.";
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var department = user.Department_Id;
            var fullName = user.Fullname;
            var employeeCode = user.Employeecode;
            var birthDay = user.Birthday;
            var ward = user.Ward;
            var district = user.District;
            var province = user.Province;

            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Error Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            if (Input.Department_Id != department)
            {
                user.Department_Id = Input.Department_Id;
            }
            if (Input.Fullname != fullName)
            {
                user.Fullname = Input.Fullname;
            }
            if (Input.Employeecode != employeeCode)
            {
                user.Employeecode = Input.Employeecode;
            }
            if (Input.Birthday != birthDay)
            {
                user.Birthday = Input.Birthday;
            }
            if (Input.Ward != ward)
            {
                user.Ward = Input.Ward;
            }
            if (Input.District != district)
            {
                user.District = Input.District;
            }
            if (Input.Province != province)
            {
                user.Province = Input.Province;
            }
            string wwwRootPath = _env.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string applicantPath = Path.Combine(wwwRootPath, @"assets\admin\img\img-user");
                if (user.Image != "assets\\admin\\img\\img-user\\default-image-user.png")
                {
                    if (!string.IsNullOrEmpty(user.Image))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, user.Image.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(applicantPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                user.Image = @"assets\admin\img\img-user\" + fileName;
            }

            await _userManager.UpdateAsync(user);


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
