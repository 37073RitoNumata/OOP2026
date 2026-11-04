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

	public DbSet<Order> Orders => Set<Order>();
	public DbSet<OrderItem> OrderItems => Set<OrderItem>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Order>()
			.HasIndex(o => o.PublicId)
			.IsUnique();                 // 公開IDの重複を防止 

		modelBuilder.Entity<OrderItem>()
			.HasOne(i => i.Product)
			.WithMany()
			.HasForeignKey(i => i.ProductId)
			.OnDelete(DeleteBehavior.Restrict); // 注文履歴を保護 
	}
}
