using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Data;
using SelfOrderSystem.ViewModels;
using SelfOrderSystem.Services;

namespace SelfOrderSystem.Controllers;

public class MenuController: Controller
{
	private readonly AppDbContext _db;  //DBへアクセスするためのコンテキスト
	private readonly CartService _cart; //カートサービス

	//ASP.NET CoreのDIコンテナからAppDbContextを注入するコンストラクタ
	public MenuController(AppDbContext db, CartService cart)
	{
		_db = db; //コンテキストを初期化
		_cart = cart;
	}

	public async Task<IActionResult> Index(int? categoryId)
	{
		var categories = await _db.Categories
			.AsNoTracking()
			.OrderBy(c => c.SortOrder)
			.ToListAsync();

		var query = _db.Products
			.AsNoTracking()
			.Include(p => p.Category)
			.Where(p => p.IsActive);

		if (categoryId.HasValue)
		{
			query = query.Where(p => p.CategoryId == categoryId.Value);
		}

		var products = await query
			.OrderBy(p => p.Category!.SortOrder)
			.ThenBy(p => p.Name)
			.ToListAsync();

		// Indexでproductsを取得した後へ追加する
		var cartItems = _cart.GetItems();

		var vm = new MenuViewModel
		{
			Categories = categories,
			Products = products,
			SelectedCategoryId = categoryId,
			CartItemCount = cartItems.Sum(x => x.Quantity), // 商品数量の合計 
			CartTotal = cartItems.Sum(x => x.LineTotal) // 小計の合計 
		};

		return View(vm);
	}
}
