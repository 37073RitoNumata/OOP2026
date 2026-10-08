using Microsoft.AspNetCore.Mvc;
using MvcBasicSample.Models;

namespace MvcBasicSample.Controllers;

//URLのHelloに対応する要求を受け取るControllerクラス
public class HelloController : Controller
{
	// ../Hello/Indexで呼び出されるアクションメソッド
	public IActionResult Index()
	{
		var product = new List<Product>
		{
			new Product
			{
				Name = "りんご",
				Price = 100
			},
			new Product
			{
				Name = "みかん",
				Price = 80
			},
			new Product
			{
				Name = "ぶどう",
				Price = 150
			},
						new Product
			{
				Name = "りんご",
				Price = 100
			},
			new Product
			{
				Name = "みかん",
				Price = 80
			},
			new Product
			{
				Name = "ぶどう",
				Price = 150
			},
						new Product
			{
				Name = "りんご",
				Price = 100
			},
			new Product
			{
				Name = "みかん",
				Price = 80
			},
			new Product
			{
				Name = "ぶどう",
				Price = 150
			}
		};

		return View(product); //Viewに商品オブジェクトを渡す
	}
}

