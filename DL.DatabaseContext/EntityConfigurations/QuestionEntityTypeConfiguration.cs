using System;
using System.Collections.Generic;
using System.Text;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.DatabaseContext.EntityConfigurations
{
    public class QuestionEntityTypeConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder
                .HasDiscriminator<string>("QuestionType")
                .HasValue<PollQuestion>("Poll")
                .HasValue<TriviaQuestion>("Trivia");

            builder.HasMany(x => x.QuestionItems)
                .WithOne()
                .HasForeignKey(x => x.QuestionId)
                .IsRequired();
        }
    }
}
