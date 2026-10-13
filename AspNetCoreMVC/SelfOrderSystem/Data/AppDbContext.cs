using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Models;

namespace SelfOrderSystem.Data;

public class AppDbContext : DbContext
{
	// Program.csで登録した接続設定を受け取る
	// コンストラクタでDbContextOptions<AppDbContext>を受け取り、基底クラスのコンストラクタに渡す
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options) // 受け取った設定を親クラスの渡す　DbContextクラスのコンストラクタを呼び出す
	{
	}

	// DbSet<Category>型のCategoriesプロパティを定義することで、Categoryエンティティに対するデータベース操作を行うことができます。
	public DbSet<Category> Categories => Set<Category>();        // カテゴリ
	// DbSet<Product>型のProductsプロパティを定義することで、Productエンティティに対するデータベース操作を行うことができます。
	public DbSet<Product> Products => Set<Product>();            // 商品 
}
