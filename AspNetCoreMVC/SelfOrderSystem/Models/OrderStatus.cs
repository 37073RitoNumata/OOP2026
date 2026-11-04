namespace SelfOrderSystem.Models;

public enum OrderStatus          // 注文の状態を4種類で表す 
{
	New,                    // 新規注文 
	Accepted,               // 受付済み 
	Cooking,                // 調理中 
	Served                  // 提供済み 
}
