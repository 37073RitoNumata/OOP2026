using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Data;
using SelfOrderSystem.Services;
using SelfOrderSystem.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using SelfOrderSystem.Models;

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

builder.Services.AddScoped<IOrderService, OrderService>(); // IOrderServiceをDIへ登録しControllerで受け取れるようにする
builder.Services.AddSignalR(); // SignalRを使えるようにする

// スタッフのパスワード照合用のサービス 
builder.Services.AddScoped<IPasswordHasher<StaffUser>,
PasswordHasher<StaffUser>>();
// Cookie を使ったログイン方式を登録 
builder.Services.AddAuthentication(
CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
	options.LoginPath = "/Account/Login";
	// 未ログイン時の遷移先 
	options.AccessDeniedPath = "/Account/Denied"; // 権限不足時の遷移先 
	options.Cookie.HttpOnly = true;
	// JavaScript から読み取り不可 
	options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // HTTPS 限定 
	options.ExpireTimeSpan = TimeSpan.FromHours(8); // 認証チケットの有効期間 
});

builder.Services.AddAuthorization();

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
app.UseSession();		 // 既存のカートSessionを有効にする 
app.UseAuthentication(); // 認証Cookie からログイン状態を復元 
app.UseAuthorization();  // Staff 権限などを検査 

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Menu}/{action=Index}/{id?}"); // 既定画面をMenuにする 

app.MapHub<StaffOrdersHub>("/staffOrdersHub"); // SignalRのHubを使えるようにする

// 初回だけスタッフアカウントを登録 
await StaffAccountSeeder.InitializeAsync(app.Services);

app.Run();