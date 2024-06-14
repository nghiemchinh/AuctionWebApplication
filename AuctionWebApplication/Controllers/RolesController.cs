﻿using AuctionWebApplication.Models;
using AuctionWebApplication.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuctionWebApplication.Controllers
{
	[Authorize(Roles = "admin")]
	public class RolesController : Controller

	{
		RoleManager<IdentityRole> _roleManager;
		UserManager<UserIdent> _userManager;
		public RolesController(RoleManager<IdentityRole> roleManager, UserManager<UserIdent> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}
		/*public IActionResult*/
		public IActionResult Index() => View(_roleManager.Roles.ToList());
		public IActionResult UserList() => View(_userManager.Users.ToList());
		public async Task<IActionResult> Edit(string userId)
		{
		
			UserIdent user = await _userManager.FindByIdAsync(userId);
			if (user != null)
			{
			
				var userRoles = await _userManager.GetRolesAsync(user);
				var allRoles = _roleManager.Roles.ToList();
				ChangeRoleViewModel model = new ChangeRoleViewModel
				{
					UserId = user.Id,
					UserEmail = user.Email,
					UserRoles = userRoles,
					AllRoles = allRoles
				};
				return View(model);
			}
			return NotFound();
		}
		[HttpPost]
		public async Task<IActionResult> Edit(string userId, List<string> roles)
		{
	
			UserIdent user = await _userManager.FindByIdAsync(userId);
			if (user != null)
			{
				
				var userRoles = await _userManager.GetRolesAsync(user);
			
				var allRoles = _roleManager.Roles.ToList();
				
				var addedRoles = roles.Except(userRoles);
		
				var removedRoles = userRoles.Except(roles);
				await _userManager.AddToRolesAsync(user, addedRoles);
				await _userManager.RemoveFromRolesAsync(user, removedRoles);
				return RedirectToAction("UserList");
			}
			return NotFound();
		}
	}
}