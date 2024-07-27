using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBooks; 

public class BookConfig: IEntityTypeConfiguration<Book> {
    public void Configure(EntityTypeBuilder<Book> builder) {
        builder.ToTable("T_Books");
    }
}