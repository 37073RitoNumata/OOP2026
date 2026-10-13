using System.ComponentModel.DataAnnotations;

namespace SelfOrderSystem.Models;

public class Category
{
	public int Id { get; set; } //主キー
	[Required]
	[StringLength(50)]
	public string Name { get; set; } = string.Empty; //カテゴリ名

	public int SortOrder { get; set; } //表示順序
	public List<Product> Products { get; set; } = new(); //カテゴリに属する商品リスト
}
