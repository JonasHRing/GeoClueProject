﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoClueProject.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GeoClueProject.Models
{
    public class AccountService
    {
        UserManager<MyIdentityUser> userManager;
        SignInManager<MyIdentityUser> signInManager;
        MyIdentityContext myIdentityContext;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(
            UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> signInManager,
            IHttpContextAccessor httpContextAccessor, MyIdentityContext myIdentityContext
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._httpContextAccessor = httpContextAccessor;
            this.myIdentityContext = myIdentityContext;
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

        //public async Task<AccountScoreboardVM> GetUsers()
        //{
        //    string userId = userManager.GetUserId(_httpContextAccessor.HttpContext.User);
        //    MyIdentityUser user = await userManager.FindByIdAsync(userId);
        //    var viewModel = new AccountScoreboardVM();
        //    var hej = user.UserName;
        //    viewModel.Users = user.UserName;
        //    viewModel.Score = user.Score;;
        //    return viewModel;
        //}

        public async Task HandleCorrectGuess(int score)
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return;
            }

            string userId = userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            MyIdentityUser user = await userManager.FindByIdAsync(userId);
            user.Score += score;

            await userManager.UpdateAsync(user);
        }

        public async Task<AccountWelcomeVM> GetUserScore()
        {
            string userId = userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            if (userId == null)
                return new AccountWelcomeVM();
            MyIdentityUser user = await userManager.FindByIdAsync(userId);
            var viewModel = new AccountWelcomeVM { Score = user.Score }; 

            return viewModel;
        }

        public AccountScoreboardVM GetAllUsers()
        {
            var Users = myIdentityContext.Users.ToList();

            var orderedList = Users
                .OrderByDescending(o => o.Score);

            AccountScoreboardVM viewModel = new AccountScoreboardVM();
            var users = new List<User>();
            viewModel.Users = users;
            foreach (var item in Users)
            {

               viewModel.Users.Add(new User {Score = item.Score, Name = item.UserName}); 
            }

            
            return viewModel;
        }

        public AccountScoreboardVM GetPlayerList()
        {
            AccountScoreboardVM accountScoreboardVM = new AccountScoreboardVM();

            var usersList = GetAllUsers().Users;

            accountScoreboardVM.PlayerList = new SelectListItem[usersList.Count];

            for (int i = 0; i < usersList.Count; i++)
            {
                accountScoreboardVM.PlayerList[i] = new SelectListItem { Value = i.ToString(), Text = usersList[i].Name };
            }

            return accountScoreboardVM;
        }

    }
}