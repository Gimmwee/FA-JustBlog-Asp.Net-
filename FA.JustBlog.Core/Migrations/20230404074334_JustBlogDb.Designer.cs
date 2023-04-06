﻿// <auto-generated />
using System;
using FA.JustBlog.Core.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    [DbContext(typeof(JustBlogContext))]
    [Migration("20230404074334_JustBlogDb")]
    partial class JustBlogDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FA.JustBlog.Core.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Desciption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Desciption = "This is an example page for demonstration purposes.",
                            Name = "Chân dung giám đốc trốn nợ được ông Chung cho làm dự án cây xanh",
                            UrlSlug = "chan-dung-giam-dc-trn-n-duc-ong-chung-cho-lam-d-an-cay-xanh"
                        },
                        new
                        {
                            CategoryId = 2,
                            Desciption = "Learn more about our company and what we do.",
                            Name = "About Us",
                            UrlSlug = "about-us"
                        },
                        new
                        {
                            CategoryId = 3,
                            Desciption = "Get in touch with us for any questions or inquiries.",
                            Name = "Contact to customer",
                            UrlSlug = "contact-to-customer"
                        },
                        new
                        {
                            CategoryId = 4,
                            Desciption = "Read our reviews of the latest tech gadgets and consumer products.",
                            Name = "Product Reviews",
                            UrlSlug = "product-reviews"
                        },
                        new
                        {
                            CategoryId = 5,
                            Desciption = "Discover tips and advice for living a healthy and balanced life.",
                            Name = "Health and Wellness",
                            UrlSlug = "health-and-wellness"
                        },
                        new
                        {
                            CategoryId = 6,
                            Desciption = "Explore new destinations and plan your next vacation with our travel guides.",
                            Name = "Travel and Leisure",
                            UrlSlug = "travel-and-leisure"
                        },
                        new
                        {
                            CategoryId = 7,
                            Desciption = "Discover new recipes, cooking techniques, and dining experiences.",
                            Name = "Food and Drink",
                            UrlSlug = "food-and-drink"
                        },
                        new
                        {
                            CategoryId = 8,
                            Desciption = "Learn new skills and advance your career with our expert advice and resources.",
                            Name = "Career Development",
                            UrlSlug = "career-development"
                        },
                        new
                        {
                            CategoryId = 9,
                            Desciption = "Find inspiration and advice for improving your living space and outdoor areas.",
                            Name = "Home and Garden",
                            UrlSlug = "home-and-garden"
                        },
                        new
                        {
                            CategoryId = 10,
                            Desciption = "Get in shape and stay active with our fitness tips and coverage of the latest sports news.",
                            Name = "Sports and Fitness",
                            UrlSlug = "sports-and-fitness"
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("CommentHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments", (string)null);

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            CommentHeader = "Great article!",
                            CommentText = "This article provided a lot of useful information. I learned a lot from it. Thank you!",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6104),
                            Email = "john.smith@example.com",
                            Name = "John Smith",
                            PostId = 1
                        },
                        new
                        {
                            CommentId = 13,
                            CommentHeader = "Interesting perspective!",
                            CommentText = "I never thought about the topic from this angle before. Your article gave me a lot to think about. Thanks for sharing!",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6106),
                            Email = "jane.doe@example.com",
                            Name = "KienDc",
                            PostId = 3
                        },
                        new
                        {
                            CommentId = 12,
                            CommentHeader = "Question about the topic",
                            CommentText = "I have a question about one of the points you made in the article. Can you provide more information about XYZ? Thanks!",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6106),
                            Email = "SonPP@example.com",
                            Name = "Son PP",
                            PostId = 2
                        },
                        new
                        {
                            CommentId = 14,
                            CommentHeader = "Great article!",
                            CommentText = "This article provided a lot of useful information. I learned a lot from it. Thank you!",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6107),
                            Email = "john.smith@example.com",
                            Name = "John Smith",
                            PostId = 2
                        },
                        new
                        {
                            CommentId = 2,
                            CommentHeader = "Excellent post!",
                            CommentText = "I really enjoyed reading this post. The examples were very helpful.",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6108),
                            Email = "emily.jones@example.com",
                            Name = "Emily Jones",
                            PostId = 2
                        },
                        new
                        {
                            CommentId = 3,
                            CommentHeader = "Thanks for sharing",
                            CommentText = "This post helped me understand machine learning better. Keep up the good work!",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6109),
                            Email = "david.lee@example.com",
                            Name = "David Lee",
                            PostId = 2
                        },
                        new
                        {
                            CommentId = 4,
                            CommentHeader = "Insightful article",
                            CommentText = "I learned a lot from this post. Thank you for sharing your knowledge with us.",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6110),
                            Email = "sarah.johnson@example.com",
                            Name = "Sarah Johnson",
                            PostId = 1
                        },
                        new
                        {
                            CommentId = 5,
                            CommentHeader = "Well-written post",
                            CommentText = "This post was easy to read and understand. The examples were very helpful.",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6111),
                            Email = "michael.brown@example.com",
                            Name = "Michael Brown",
                            PostId = 5
                        },
                        new
                        {
                            CommentId = 6,
                            CommentHeader = "Thank you for this post",
                            CommentText = "I was struggling to understand machine learning before reading this post. It has helped me a lot.",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6111),
                            Email = "linda.davis@example.com",
                            Name = "Linda Davis",
                            PostId = 4
                        },
                        new
                        {
                            CommentId = 7,
                            CommentHeader = "Great job!",
                            CommentText = "This post was very informative. I learned a lot from it.",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6112),
                            Email = "tom.smith@example.com",
                            Name = "Tom Smith",
                            PostId = 3
                        },
                        new
                        {
                            CommentId = 8,
                            CommentHeader = "Thanks for sharing your knowledge",
                            CommentText = "This post was well-written and very informative. I appreciate you sharing your knowledge with us.",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6113),
                            Email = "katie.lee@example.com",
                            Name = "Katie Lee",
                            PostId = 2
                        },
                        new
                        {
                            CommentId = 9,
                            CommentHeader = "Very helpful post",
                            CommentText = "I was looking for an introduction to machine learning and this post was exactly what I needed. Thank you!",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6114),
                            Email = "peter.johnson@example.com",
                            Name = "Peter Johnson",
                            PostId = 1
                        },
                        new
                        {
                            CommentId = 10,
                            CommentHeader = "Thanks for the explanation",
                            CommentText = "This post explained machine learning in a way that was easy to understand. I appreciate it!",
                            CommentTime = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6114),
                            Email = "amanda.brown@example.com",
                            Name = "Amanda Brown",
                            PostId = 2
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PostedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<int>("RateCount")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalRate")
                        .HasColumnType("int");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts", (string)null);

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            CategoryId = 1,
                            Modified = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6048),
                            PostContent = "The finance ministers and central bank governors of the Association of Southeast Asian Nations (ASEAN) held a meeting on March 30-31 in Bali, Indonesia. One of the topics they discussed was reducing reliance on western currencies, such as the U.S. dollar. ASEAN comprises Brunei, Cambodia, Indonesia, Laos, Malaysia, Myanmar, the Philippines, Singapore, Thailand, and Vietnam.\r\n\r\nThe meeting was also attended by representatives from six international\r\norganizations, namely Asian Development Bank (ADB), ASEAN+3 Macroeconomic Research Office (AMRO), the International Monetary Fund (IMF), the Financial Supervisory Board (FSB), the Bank for International Settlement (BIS), and the World Bank.\r\n\r\nAt the conclusion of the two-day meeting, the ASEAN finance ministers and central bank governors released a joint statement, stating that they agreed to “reinforce financial resilience, among others, through the use of local currency to support cross-border trade and investment in the ASEAN region.”",
                            PostedOn = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6040),
                            Published = true,
                            RateCount = 2,
                            ShortDescription = "The finance ministers and central bank governors of the Association of Southeast Asian Nations (ASEAN) are exploring ways to decrease their countries’ dependence on the U.S. dollar and promote the use of local currencies in trade settlements. “We must remember the sanctions imposed by the US on Russia,” said Indonesian President Joko Widodo.",
                            Title = "ASEAN Countries Take Steps to Reduce Reliance on US Dollar for Trade Settlements",
                            TotalRate = 32,
                            UrlSlug = "asean-countries-take-steps-to-reduce-reliance-on-us-dollar-for-trade-settlements",
                            ViewCount = 23
                        },
                        new
                        {
                            PostId = 2,
                            CategoryId = 2,
                            Modified = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6051),
                            PostContent = "According to Amboko Julians, a Kenyan economist and blogger, the East African nation’s parliament is set to debate a bill that proposes to place blockchain technology and digital currencies under the purview of Kenya’s Capital Markets Authority (CMA). Besides seeking to incorporate the definitions of blockchain and cryptocurrencies, Julians claimed that the bill also proposes “to widen the meaning of ‘securities’ to capture digital currencies.”\r\n\r\nIn his March 28 Twitter thread, Julians shared the supposed screenshots of the bill that is being sponsored by the Kenyan legislator Abraham Kipsang Kirwa. As shown in the screenshots, Kirwa’s bill proposes that persons seeking to introduce a cryptocurrency must first obtain a license from the capital markets regulator.",
                            PostedOn = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6051),
                            Published = true,
                            RateCount = 23,
                            ShortDescription = "A bill seeking to put blockchain and crypto assets under the purview of the Kenyan Capital Markets Authority is supposedly set to be debated in the country’s parliament. The bill also seeks to “widen the meaning of ‘securities’ to capture digital currencies.” The persons that receive licenses from the regulator are also required to maintain records of all digital currency transactions and to pay taxes on any gains made.",
                            Title = "Alleged Kenyan Bill Proposes Widening Definition of Securities to Include Crypto Assets",
                            TotalRate = 14,
                            UrlSlug = "alleged-kenyan-bill-proposes-widening-definition-of-securities-to-include-crypto-assets",
                            ViewCount = 223
                        },
                        new
                        {
                            PostId = 3,
                            CategoryId = 3,
                            Modified = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6053),
                            PostContent = "Time management is an essential skill for success in both personal and professional life. In this article, we will share 10 tips for better time management, including setting goals, prioritizing tasks, minimizing distractions, and delegating responsibilities. By following these tips, you can improve your productivity, reduce stress, and achieve your goals more efficiently.",
                            PostedOn = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6052),
                            Published = false,
                            RateCount = 22,
                            ShortDescription = "Learn how to manage your time more effectively with these 10 simple tips.",
                            Title = "10 Tips for Better Time Management",
                            TotalRate = 44,
                            UrlSlug = "10-tips-for-better-time-management",
                            ViewCount = 111
                        },
                        new
                        {
                            PostId = 4,
                            CategoryId = 4,
                            Modified = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6054),
                            PostContent = "Xuan Changneng, a deputy governor at the People’s Bank of China (PBOC), the Chinese central bank, spoke at the Boao Forum on Friday about the potential dangers of financial innovations, including cryptocurrencies, that could cause banks and lenders to fail. He was quoted by Bloomberg as saying:\r\n\r\nRisks and fraud associated with cryptocurrency, including the two American banks who ran into troubles after providing many services for cryptocurrency from taking deposits to settlement, showed that regulators should respect rules when innovating regulation.",
                            PostedOn = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6054),
                            Published = true,
                            RateCount = 33,
                            ShortDescription = "A senior People’s Bank of China (PBOC) official has urged regulators to consider cryptocurrency risks and fraud that could lead to bank failures when innovating regulation. ",
                            Title = "Regulators Should Heed Crypto Risks When Innovating Regulation, Says Chinese Central Bank Official",
                            TotalRate = 66,
                            UrlSlug = "regulators-should-heed-crypto-risks-when-innovating-regulation-says-chinese-central-bank-official",
                            ViewCount = 222
                        },
                        new
                        {
                            PostId = 5,
                            CategoryId = 5,
                            Modified = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6056),
                            PostContent = "React Native is a popular framework for building native mobile apps using JavaScript and React. In this tutorial, we will cover the basics of React Native, including components, styling, navigation, and data management. By the end of this tutorial, you will have a working mobile app that you can deploy on both iOS and Android devices.",
                            PostedOn = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6055),
                            Published = true,
                            RateCount = 11,
                            ShortDescription = "Learn how to build a mobile app using React Native framework.",
                            Title = "Building a Mobile App with React Native",
                            TotalRate = 22,
                            UrlSlug = "building-a-mobile-app-with-react-native",
                            ViewCount = 333
                        },
                        new
                        {
                            PostId = 6,
                            CategoryId = 6,
                            Modified = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6060),
                            PostContent = "Starting a blog is a great way to express your creativity, share your knowledge, and connect with like-minded people. In this tutorial, we will cover the basics of starting a blog, including choosing a niche, selecting a platform, setting up your website, and creating content. Whether you want to blog for fun or profit, this tutorial will help you get started.",
                            PostedOn = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6057),
                            Published = true,
                            RateCount = 44,
                            ShortDescription = "Learn how to start a blog and share your ideas with the world.",
                            Title = "How to Start a Blog",
                            TotalRate = 88,
                            UrlSlug = "how-to-start-a-blog",
                            ViewCount = 444
                        },
                        new
                        {
                            PostId = 7,
                            CategoryId = 7,
                            Modified = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6061),
                            PostContent = "Git is a popular version control system that is widely used in software development to manage changes to source code. GitHub is a web-based platform that provides hosting for Git repositories and a range of collaboration features. In this tutorial, we will cover the basics of Git and GitHub, including creating repositories, branching, merging, and pull requests. By the end of this tutorial, you will be able to use Git and GitHub to manage your own projects and collaborate with others.",
                            PostedOn = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6061),
                            Published = true,
                            RateCount = 32,
                            ShortDescription = "Learn how to use Git and GitHub for version control and collaboration.",
                            Title = "Mastering Git and GitHub",
                            TotalRate = 12,
                            UrlSlug = "mastering-git-and-github",
                            ViewCount = 234
                        },
                        new
                        {
                            PostId = 8,
                            CategoryId = 8,
                            Modified = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6064),
                            PostContent = "Yoga is a mind-body practice that has been around for thousands of years. It involves physical postures, breathing techniques, and meditation or relaxation. Regular practice of yoga has been shown to improve flexibility, strength, balance, and reduce stress and anxiety. In this article, we will discuss the benefits of yoga and how you can incorporate it into your daily routine.",
                            PostedOn = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6063),
                            Published = true,
                            RateCount = 32,
                            ShortDescription = "Learn about the physical and mental benefits of practicing yoga regularly.",
                            Title = "The Benefits of Yoga",
                            TotalRate = 12,
                            UrlSlug = "the-benefits-of-yoga",
                            ViewCount = 234
                        },
                        new
                        {
                            PostId = 9,
                            CategoryId = 9,
                            Modified = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6065),
                            PostContent = "Starting a successful business requires careful planning, research, and execution. In this article, we will cover the key steps to starting a successful business, including identifying a profitable niche, conducting market research, developing a business plan, and marketing your business. We will also discuss some common challenges and how to overcome them.",
                            PostedOn = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6065),
                            Published = true,
                            RateCount = 41,
                            ShortDescription = "Learn the key steps to starting and growing a successful business.",
                            Title = "How to Start a Successful Business",
                            TotalRate = 32,
                            UrlSlug = "how-to-start-a-successful-business",
                            ViewCount = 123
                        },
                        new
                        {
                            PostId = 10,
                            CategoryId = 10,
                            Modified = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6066),
                            PostContent = "Self-care is the practice of taking care of oneself to maintain physical, mental, and emotional health. It involves activities such as eating healthy, getting enough sleep, exercising regularly, and engaging in activities that bring joy and relaxation. In this article, we will discuss the importance of self-care and provide tips for how to practice it.",
                            PostedOn = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6066),
                            Published = true,
                            RateCount = 23,
                            ShortDescription = "Learn why self-care is essential for overall well-being and how to practice it.",
                            Title = "The Importance of Self-Care",
                            TotalRate = 46,
                            UrlSlug = "the-importance-of-self-care",
                            ViewCount = 223
                        },
                        new
                        {
                            PostId = 11,
                            CategoryId = 2,
                            Modified = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6068),
                            PostContent = "Learning a new language can be challenging, but it can also be a rewarding and enriching experience. In this article, we will discuss effective strategies for learning a new language, including setting realistic goals, practicing regularly, immersing yourself in the language, and using language learning apps and resources.",
                            PostedOn = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6067),
                            Published = true,
                            RateCount = 12,
                            ShortDescription = "Learn effective strategies for learning a new language, whether for travel or personal growth.",
                            Title = "How to Learn a New Language",
                            TotalRate = 48,
                            UrlSlug = "how-to-learn-a-new-language",
                            ViewCount = 543
                        },
                        new
                        {
                            PostId = 12,
                            CategoryId = 2,
                            Modified = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6069),
                            PostContent = "Mindfulness meditation is a practice that involves focusing your attention on the present moment, without judgment. It has been shown to reduce stress, anxiety, and depression, as well as improve overall well-being. In this article, we will discuss the benefits of mindfulness meditation and provide tips for how to incorporate it into your daily routine.",
                            PostedOn = new DateTime(2023, 4, 4, 14, 43, 34, 716, DateTimeKind.Local).AddTicks(6069),
                            Published = true,
                            RateCount = 23,
                            ShortDescription = "Learn about the benefits of mindfulness meditation and how to incorporate it into your daily routine.",
                            Title = "The Benefits of Mindfulness Meditation",
                            TotalRate = 48,
                            UrlSlug = "the-benefits-of-mindfulness-meditation",
                            ViewCount = 113
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.PostTagMap", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTagMap", (string)null);

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            TagId = 1
                        },
                        new
                        {
                            PostId = 2,
                            TagId = 2
                        },
                        new
                        {
                            PostId = 3,
                            TagId = 3
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tag", (string)null);

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            Count = 2,
                            Description = "C# programming language",
                            Name = "C#",
                            UrlSlug = "c-sharp"
                        },
                        new
                        {
                            TagId = 2,
                            Count = 1,
                            Description = "Creating responsive web layouts",
                            Name = "Responsive Design",
                            UrlSlug = "responsive-design"
                        },
                        new
                        {
                            TagId = 3,
                            Count = 3,
                            Description = "Tips for better time management",
                            Name = "Time Management",
                            UrlSlug = "time-management"
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Comment", b =>
                {
                    b.HasOne("FA.JustBlog.Core.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Post", b =>
                {
                    b.HasOne("FA.JustBlog.Core.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.PostTagMap", b =>
                {
                    b.HasOne("FA.JustBlog.Core.Models.Post", "Post")
                        .WithMany("PostTagMaps")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FA.JustBlog.Core.Models.Tag", "Tag")
                        .WithMany("PostTagMaps")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostTagMaps");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Tag", b =>
                {
                    b.Navigation("PostTagMaps");
                });
#pragma warning restore 612, 618
        }
    }
}
