using Microsoft.AspNetCore.Mvc; //MVCの機能を使用
using Microsoft.EntityFrameworkCore;    //ToListAsyncを使用
using MvcBasicSample.Data; //AppDbContextを使用

namespace MvcBasicSample.Controllers;

public class ProductsController : Controller
{
	private readonly AppDbContext _db; //AppDbContextのインスタンスを保持するフィールド

	//ASP.NET CoreのDIコンテナからAppDbContextを受け取るコンストラクタ
	public ProductsController(AppDbContext db)
	{
		_db = db;
	}
	// ../Products/Indexで呼び出されるアクションメソッド
	public async Task<IActionResult> Index()
	{
		//Idの昇順で全件取得し、結果をListに変換してViewに渡す
		var products = await _db.Products.Where(p => p.Price > 500).OrderBy(p => p.Id).ToListAsync();
		//商品一覧をViewに渡す
		return View(products);
	}

}

