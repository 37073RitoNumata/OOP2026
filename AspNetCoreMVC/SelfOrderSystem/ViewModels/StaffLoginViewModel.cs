using System.ComponentModel.DataAnnotations;

namespace SelfOrderSystem.ViewModels;

public class StaffLoginViewModel
{
	[Required(ErrorMessage = "ユーザー名を入力してください")]
	public string UserName { get; set; } = "";

	[Required(ErrorMessage = "パスワードを入力してください")]
	[DataType(DataType.Password)]
	public string Password { get; set; } = "";

	// ログイン後にリダイレクトするURLを保持するプロパティ
	public string? ReturnUrl { get; set; }
}
