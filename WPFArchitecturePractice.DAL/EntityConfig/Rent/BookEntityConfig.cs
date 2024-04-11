using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFArchitecturePractice.Model.Rent;

namespace WPFArchitecturePractice.DAL.EntityConfig.Rent;

internal class BookEntityConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        // 在数据库的配置中，已经配置了全部的外键的删除模式为限制删除，如果要单独设置删除模式为级联删除，请在此处单独设置
        //builder.HasOne(b => b.Category).WithMany(bc => bc.Books).HasForeignKey(b => b.CategoryId).OnDelete(DeleteBehavior.Cascade);
    }
}
