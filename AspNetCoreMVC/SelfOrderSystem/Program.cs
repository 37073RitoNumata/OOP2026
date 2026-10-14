using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Data;
using SelfOrderSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddDbContext<AppDbContext>(...) の後へ追加する 
builder.Services.AddDistributedMemoryCache(); // Sessionの保存領域としてアプリのメモリを使う


builder.Services.AddSession(options => // Session機能を登録 
{
	options.IdleTimeout = TimeSpan.FromHours(2); // 2時間操作がなければ期限切れ 
	options.Cookie.HttpOnly = true; // JavaScriptからSession IDを読めないようにする

	options.Cookie.IsEssential = true; // Session ID用Cookieを必須Cookieとして扱う
});

builder.Services.AddHttpContextAccessor(); // Controller以外のクラスからHttpContextを取得できるようにする
builder.Services.AddScoped<CartService>(); // CartServiceをDIへ登録しControllerで受け取れるようにする

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	using var scope = app.Services.CreateScope();
	var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
	await SeedData.InitializeAsync(db);
}

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // このリクエストでSessionを使えるようにする
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Menu}/{action=Index}/{id?}"); // 既定画面をMenuにする 

app.Run();