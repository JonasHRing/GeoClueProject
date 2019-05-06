using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoClueProject.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GeoClueProject.Models
{
    public class AccountService
    {
        UserManager<MyIdentityUser> userManager;
        SignInManager<MyIdentityUser> signInManager;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(
            UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> signInManager,
            IHttpContextAccessor httpContextAccessor
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<IdentityResult> TryRegisterAsync(AccountRegisterVM viewModel)
        {
            return await userManager.CreateAsync(
                new MyIdentityUser { UserName = viewModel.Username },
          viewModel.Password);
        }

        public async Task<SignInResult> TryLoginAsync(AccountLoginVM viewModel)
        {
            // Try to sign user
            return await signInManager.PasswordSignInAsync(
                viewModel.Username,
                viewModel.Password,
                isPersistent: false,
                lockoutOnFailure: false);
        }

        public async Task LogoutAsync() // asynchrona metoder som inte returnerar något har task istället för void. Behöver inte return 
        {
            // Try to sign user
            await signInManager.SignOutAsync();
        }

        public async Task<AccountScoreboardVM> GetUsers()
        {
            string userId = userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            MyIdentityUser user = await userManager.FindByIdAsync(userId);
            var viewModel = new AccountScoreboardVM();
            var hej = user.UserName;
            viewModel.Users = user.UserName;
            viewModel.Score = user.Score;;
            return viewModel;
        }

        public async Task HandleCorrectGuess(int score)
        {
            string userId = userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            MyIdentityUser user = await userManager.FindByIdAsync(userId);
            user.Score += score;

            await userManager.UpdateAsync(user);
        }
    }
}