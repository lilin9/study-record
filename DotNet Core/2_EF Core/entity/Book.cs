namespace EF_Core.entity;

public class Book {
    public long Id { get; set; } //主键
    public string Title { get; set; } //标题
    public string Author { get; set; } //作者
    public DateTime PubTime { get; set; } //发布日期
    public double Price { get; set; } //单价
}