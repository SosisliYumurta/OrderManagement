﻿using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;

		public SignalRHub(ICategoryService categoryService, IProductService productService)
		{
			_categoryService = categoryService;
			_productService = productService;
		}

		public async Task SendCategoryCount()
		{
			var value = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", value);
		}
		public async Task SendProductCount()
		{
			var value = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value);
		}
	}
}
