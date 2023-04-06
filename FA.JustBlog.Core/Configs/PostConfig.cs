using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Configs
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
      
            public void Configure(EntityTypeBuilder<Post> builder)
            {
                builder.ToTable("Posts");
                builder.HasKey(p => p.PostId);
                builder.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId);
            }
        
    }
}
