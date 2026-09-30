using Microsoft.AspNetCore.Mvc;

namespace MvcBasicSample.Controllers;

//URLのHelloに対応する要求を受け取るControllerクラス
public class HelloController : Controller
{
	// ../Hello/Indexで呼び出されるアクションメソッド
	public IActionResult Index()
	{
		//Viewを使用せず、文字列をHTTPのレスポンスとして返す
		//return Content("初めてのASP.NET Core");
		return View();
	}
}

